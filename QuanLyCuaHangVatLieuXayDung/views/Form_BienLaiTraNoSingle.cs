﻿using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_BienLaiTraNoSingle : Form
    {
        private readonly IPhieuGhiNoService phieuGhiNoService = new PhieuGhiNoService();
        private readonly MyDatabase myDatabase = new MyDatabase();
        private readonly PhieuGhiNo phieuGhiNo;
        private readonly StringUtility stringUtility = new StringUtility();
        internal Form_BienLaiTraNoSingle(PhieuGhiNo phieu)
        {
            InitializeComponent();
            this.phieuGhiNo = phieu;
            InitializeFormData();
        }

        private void Form_BienLaiTraNoSingle_Load(object sender, EventArgs e)
        {

        }

        private void InitializeFormData()
        {
            this.txtMaBienLai.Text = stringUtility.GenerateRandomString(10);
            while (this.phieuGhiNoService.findByMaPhieu(this.txtMaPhieu.Text) != null)
            {
                this.txtMaBienLai.Text = stringUtility.GenerateRandomString(10);
            }
            this.txtMaPhieu.Text = phieuGhiNo.MaPhieu;
            this.txtTenDoiTac.Text = phieuGhiNo.DoiTac.Ten;
            this.txtTienNo.Text = phieuGhiNo.DoiTac.SoDienThoai;
            this.txtTienTra.Text = phieuGhiNo.TienNo.ToString("N0");
        }

        private int GetNextBienLaiId()
        {
            try
            {
                myDatabase.OpenConnection();
                string query = "SELECT COUNT(*) FROM BienLaiTraNo";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count + 1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã biên lai: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1; // Bắt đầu từ 1 nếu có lỗi
            }
            finally
            {
                myDatabase.CloseConnection();
            }
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                string maBienLai = txtMaBienLai.Text.Trim();
                if (string.IsNullOrEmpty(maBienLai))
                {
                    MessageBox.Show("Mã biên lai không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtTienTra.Text.Trim().Replace(",", ""), out double tienTra) || tienTra <= 0)
                {
                    MessageBox.Show("Số tiền trả không hợp lệ. Vui lòng nhập số tiền lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime thoiGianTra = dtpThoiGianTra.Value;
                if (thoiGianTra < phieuGhiNo.ThoiGianLap)
                {
                    MessageBox.Show("Thời gian trả không được nhỏ hơn thời gian lập phiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận hành động
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn tạo biên lai trả nợ cho phiếu {phieuGhiNo.MaPhieu} với số tiền {tienTra:N0}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                // Thực hiện cập nhật trạng thái và chèn biên lai trong một giao dịch
                SqlTransaction transaction = null;
                try
                {
                    myDatabase.OpenConnection();
                    transaction = myDatabase.Connection.BeginTransaction();

                    // Cập nhật trạng thái phiếu ghi nợ
                    bool updateSuccess = phieuGhiNoService.updateTrangThai(phieuGhiNo.MaPhieu, true);
                    if (!updateSuccess)
                    {
                        throw new Exception("Không thể cập nhật trạng thái phiếu ghi nợ.");
                    }

                    // Chèn biên lai trả nợ
                    string query = @"INSERT INTO BienLaiTraNo (MaBienLai, ThoiGianTra, TienTra, MaPhieuGhiNo)
                                    VALUES (@MaBienLai, @ThoiGianTra, @TienTra, @MaPhieuGhiNo)";
                    using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaBienLai", maBienLai);
                        cmd.Parameters.AddWithValue("@ThoiGianTra", thoiGianTra);
                        cmd.Parameters.AddWithValue("@TienTra", tienTra);
                        cmd.Parameters.AddWithValue("@MaPhieuGhiNo", phieuGhiNo.MaPhieu);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Trả nợ thành công và đã tạo biên lai trả nợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi xử lý trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myDatabase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtTienTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (backspace, delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

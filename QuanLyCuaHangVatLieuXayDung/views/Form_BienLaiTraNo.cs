using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangVatLieuXayDung.model;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_BienLaiTraNo : Form
    {
        private readonly IBienLaiTraNoService bienLaiTraNoService = new BienLaiTraNoService();
        public Form_BienLaiTraNo()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form_BienLaiTraNo_Load);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            panelBienLaiTraNo.Visible = false;
        }

        private void Form_BienLaiTraNo_Load(object sender, EventArgs e)
        {
            LoadBienLaiTraNoData();
            panelBienLaiTraNo.Visible = false;
        }


        private void LoadBienLaiTraNoData(List<BienLaiTraNo> bienLaiTraNos = null)
        {
            try
            {
                // Nếu không truyền danh sách, lấy toàn bộ dữ liệu
                if (bienLaiTraNos == null)
                {
                    bienLaiTraNos = bienLaiTraNoService.FindAll();
                }

                // Kiểm tra danh sách rỗng hoặc null
                if (bienLaiTraNos == null || !bienLaiTraNos.Any())
                {
                    dataGridView1.Rows.Clear();
                    MessageBox.Show("Không có dữ liệu biên lai trả nợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xóa các hàng hiện tại trong DataGridView
                dataGridView1.Rows.Clear();

                // Thêm dữ liệu vào các cột đã thiết kế sẵn
                foreach (var bienLai in bienLaiTraNos)
                {
                    dataGridView1.Rows.Add(
                        bienLai.MaBienLai,
                        bienLai.MaPhieuGhiNo,
                        bienLai.TenDoiTac,
                        bienLai.SoDienThoai,
                        bienLai.DiaChi,
                        bienLai.ThoiGianTra.ToString("dd/MM/yyyy HH:mm"),
                        bienLai.TienTra.ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string maBienLai = dataGridView1.Rows[e.RowIndex].Cells["MaBienLai"].Value?.ToString();
                    if (string.IsNullOrEmpty(maBienLai))
                    {
                        MessageBox.Show("Mã biên lai không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    BienLaiTraNo bienLai = bienLaiTraNoService.FindByMaBienLai(maBienLai);
                    if (bienLai != null)
                    {
                        panelBienLaiTraNo.Visible = true;
                        txtMaBienLai.Text = bienLai.MaBienLai;
                        txtMaPhieuGhiNo.Text = bienLai.MaPhieuGhiNo;
                        txtTenDoiTac.Text = bienLai.TenDoiTac;
                        txtSoDienThoai.Text = bienLai.SoDienThoai;
                        txtDiaChi.Text = bienLai.DiaChi;
                        textBox1.Text = bienLai.ThoiGianTra.ToString("dd/MM/yyyy HH:mm");
                        textBox2.Text = bienLai.TienTra.ToString("N0");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin biên lai trả nợ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị thông tin biên lai: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputFields()
        {
            txtMaBienLai.Text = string.Empty;
            txtMaPhieuGhiNo.Text = string.Empty;
            txtTenDoiTac.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBienLaiTraNoData();
            panelBienLaiTraNo.Visible = false;
            ClearInputFields();
            radioButtonKhachHang.Checked = false;
            radioButtonCuaHang.Checked = false;
            txtTimKiem.Text = string.Empty;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadBienLaiTraNoData();
                    return;
                }

                List<BienLaiTraNo> bienLaiTraNos = bienLaiTraNoService.SearchByKey(searchText);
                LoadBienLaiTraNoData(bienLaiTraNos);

                if (bienLaiTraNos == null || !bienLaiTraNos.Any())
                {
                    MessageBox.Show("Không tìm thấy biên lai trả nợ khớp với từ khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                panelBienLaiTraNo.Visible = false;
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButtonCuaHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCuaHang.Checked)
            {
                LoadBienLaiTraNoData(bienLaiTraNoService.FindByLoaiPhieu(2));
            }
        }

        private void radioButtonKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKhachHang.Checked)
            {
                LoadBienLaiTraNoData(bienLaiTraNoService.FindByLoaiPhieu(1));
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            // TODO: Thêm logic in biên lai trả nợ (sẽ được triển khai nếu cần)
            MessageBox.Show("Chức năng in phiếu đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


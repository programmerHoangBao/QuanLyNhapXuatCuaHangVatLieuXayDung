using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service.impl;
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
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ChiPhiPhatSinh : Form
    {
        private StringUtility stringUtility = new StringUtility();
        private IChiPhiPhatSinhService chiPhiService = new ChiPhiPhatSinhService();
        public Form_ChiPhiPhatSinh()
        {
            InitializeComponent();
        }
        private void Form_ChiPhiPhatSinh_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            List<ChiPhiPhatSinh> danhSach = chiPhiService.SearchByKeyword(keyword);

            this.dataGridViewShowChiPhiPhatSinh.Rows.Clear();
            foreach (ChiPhiPhatSinh chiPhi in danhSach)
            {
                dataGridViewShowChiPhiPhatSinh.Rows.Add(
                    chiPhi.MaChiPhi,
                    chiPhi.LoaiChiPhi,
                    chiPhi.ThoiGianLap.ToString("dd/MM/yyyy HH:mm"),
                    chiPhi.MoTa,
                    chiPhi.ChiPhi.ToString("N0") + " VND"
                );
            }
        }
        private ChiPhiPhatSinh CreateChiPhiPhatSinhInput()
        {
            string maChiPhi = this.txtMaChiPhi.Text.Trim();
            byte loaiChiPhi = (byte)(this.cboLoaiChiPhi.SelectedIndex + 1);
            DateTime thoiGianLap = this.dtpThoiGianLap.Value;
            string moTa = this.txtMoTa.Text.Trim();

            if (string.IsNullOrWhiteSpace(this.txtChiPhi.Text))
            {
                MessageBox.Show("Chi phí không được để trống!");
            }

            if (!double.TryParse(this.txtChiPhi.Text.Trim(), out double chiPhi))
            {
                MessageBox.Show("Chi phí phải là một số hợp lệ!");
            }

            return new ChiPhiPhatSinh(maChiPhi, loaiChiPhi, thoiGianLap, moTa, chiPhi);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChiPhiPhatSinh chiPhi = this.CreateChiPhiPhatSinhInput();
            if (this.chiPhiService.InsertChiPhi(chiPhi))
            {
                MessageBox.Show("Đã thêm thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            resetForm();
            LoadData();
        }
        private void LoadData()
        {
            this.dataGridViewShowChiPhiPhatSinh.Rows.Clear();
            List<ChiPhiPhatSinh> danhSach = chiPhiService.FindAllChiPhiSortDateDesc();
            foreach (ChiPhiPhatSinh chiPhi in danhSach)
            {
                this.dataGridViewShowChiPhiPhatSinh.Rows.Add(
                                                              chiPhi.MaChiPhi, chiPhi.loaiChiPhi_ToString()
                                                              , chiPhi.ThoiGianLap, chiPhi.MoTa, chiPhi.ChiPhi);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
            LoadData();
        }
        private void resetForm()
        {
            this.txtMaChiPhi.Text = this.TaoMaChiPhiTuDong();
            this.txtChiPhi.Text = "";
            this.cboLoaiChiPhi.Text = "";
            this.txtMoTa.Text = "";
            this.txtChiPhi.Text = "";

        }
        private string TaoMaChiPhiTuDong()
        {
             string maChiPhi = "";
             while (true)
             {
                    maChiPhi = this.stringUtility.GenerateRandomString(10);
                    if (this.chiPhiService.FindByMaChiPhi(maChiPhi) == null)
                    {
                        break;
                    }
             }
            return maChiPhi;

        }
      

        private void txtChiPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép điều khiển (backspace, delete, ...)
            if (!char.IsControl(e.KeyChar))
            {
                // Chỉ cho phép số và dấu '.'
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Không cho nhập
                }

                // Không cho nhập nhiều hơn một dấu '.'
                if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnUpdateVatLieu_Click(object sender, EventArgs e)
        {
            ChiPhiPhatSinh UpdateChiPhi = this.CreateChiPhiPhatSinhInput();
            if (UpdateChiPhi != null)
            {
                if (this.chiPhiService.UpdateChiPhi(UpdateChiPhi))
                {
                    MessageBox.Show("Chi phí đã được chỉnh sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Chi phí đã được chỉnh sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            else
            {
                MessageBox.Show("Bạn cần cung cấp đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            resetForm();
            LoadData();
        }

        private void btnDeleteVatLieu_Click(object sender, EventArgs e)
        {
            ChiPhiPhatSinh deleteChiPhi = this.CreateChiPhiPhatSinhInput();
            if (deleteChiPhi != null)
            {
                if (this.chiPhiService.DeleteChiPhi(deleteChiPhi.MaChiPhi))
                {
                    MessageBox.Show("Đối tác đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
            else
            {
                MessageBox.Show("Bạn cần cung cấp đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            resetForm();
            LoadData();
        }

        private void dataGridViewShowChiPhiPhatSinh_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string maChiPhi = this.dataGridViewShowChiPhiPhatSinh.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ChiPhiPhatSinh chiPhi = this.chiPhiService.FindByMaChiPhi(maChiPhi);
                    if (chiPhi != null)
                    {
                        this.txtMaChiPhi.Text = chiPhi.MaChiPhi.ToString();
                        this.txtChiPhi.Text = chiPhi.ChiPhi.ToString();
                        this.cboLoaiChiPhi.Text = chiPhi.loaiChiPhi_ToString();
                        this.dtpThoiGianLap.Text = chiPhi.ThoiGianLap.ToString();
                        this.txtMoTa.Text = chiPhi.MoTa.ToString();
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
   
}

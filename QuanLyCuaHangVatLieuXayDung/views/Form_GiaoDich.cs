using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
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

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_GiaoDich : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        private Form_ChonSoLuongVatLieu formChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
        List<UserControl> userControls = new List<UserControl>();
        public Form_GiaoDich()
        {
            InitializeComponent();
        }

        private void Form_GiaoDich_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.radioButtonXuatHang.Checked = true;
            this.btnAnHoaDon.Enabled = false;
            this.labelDate.Text = DateTime.Now.ToString();
            this.txtTienThanhToan.Text = "0";
            this.txtTienGiam.Text = "0";
            this.panelHoaDon.Hide();
            this.panelVatLieu.Size = new Size(this.panelHoaDon.Size.Width, 350);
            this.comboBoxPhuongThucThanhToan.SelectedIndex = 0;
            this.ShowVatLieus();
        }
        private void ShowVatLieus()
        {
            
            this.flowLayoutPanelShowVatLieu.Controls.Clear();
            List<VatLieu> vatLieus = this.vatLieuService.findAll();
            UserControlShowVatLieu userControl = null;
            foreach (VatLieu vatLieu in vatLieus)
            {
                userControl = new UserControlShowVatLieu();
                userControl.VatLieu = vatLieu;
                userControl.Size = new Size(200, 280);
                if (this.radioButtonXuatHang.Checked && vatLieu.SoLuong > 0)
                {
                    userControl.ShowVatLieu(1);
                }
                else if (this.radioButtonNhapHang.Checked)
                {
                    userControl.ShowVatLieu(2);
                }
                if (userControl != null)
                {
                    this.formChonSoLuongVatLieu.LoaiHoaDon = this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2;
                    this.formChonSoLuongVatLieu.VatLieu = userControl.VatLieu;
                    this.formChonSoLuongVatLieu.btnOkClick += this.btnOk_Click;
                    userControl.btnTransactionClick += this.btnTransaction_Click;
                    this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                }
            }
            
        }
        private void resetPanelHoaDon()
        {
            this.txtMaHoaDon.Text = new StringUtility().GenerateRandomString(10);
            this.txtNameDoiTac.Text = "";
            this.txtSDT.Text = "";
            this.txtAddress.Text = "";
            this.comboBoxPhuongThucThanhToan.SelectedIndex = 0;
            this.txtTienThanhToan.Text = "0";
            this.txtTienGiam.Text = "0";
            this.labelNoCu.Text = "Nợ cũ:";
            this.labelTongHoaDon.Text = "Tổng hóa đơn:";
            this.labelTienThanhToan.Text = "Tiền thanh toán:";
            this.dataGridViewShowVatLieu.Rows.Clear(); // Xóa tất cả các hàng trong DataGridView
        }
        private bool isExitsVatLieuInHoaDon(VatLieu vatLieu)
        {
            foreach (DataGridViewRow row in this.dataGridViewShowVatLieu.Rows)
            {
                if (!row.IsNewRow) // Kiểm tra để loại bỏ hàng mới không được sử dụng
                {
                    var cellValue = row.Cells["MaVatLieu"].Value;
                    if (cellValue != null && cellValue.ToString() == vatLieu.MaVatLieu) // Kiểm tra giá trị null
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool setSoLuongVatLieuInHoDon(VatLieu vatLieu, float soLuong)
        {
            double gia;
            foreach (DataGridViewRow row in this.dataGridViewShowVatLieu.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["MaVatLieu"].Value.ToString() == vatLieu.MaVatLieu)
                    {
                        row.Cells["SoLuong"].Value = soLuong;
                        gia = new StringUtility().ConvertFromVietnameseCurrency(row.Cells["Gia"].Value.ToString());
                        row.Cells["TongTien"].Value = new StringUtility().ConvertToVietnameseCurrency(gia * soLuong);
                        return true;
                    }
                }
            }
            return false;
        }
        private bool addVatlieuToHoaDon(VatLieu vatLieu, float soLuong)
        {
            if (soLuong <= 0)
            {
                return false;
            }

            if (this.isExitsVatLieuInHoaDon(vatLieu))
            {
                this.setSoLuongVatLieuInHoDon(vatLieu, soLuong);
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridViewShowVatLieu);
                row.Cells[1].Value = vatLieu.MaVatLieu;
                row.Cells[2].Value = vatLieu.Ten;
                double gia = 0;
                if (this.radioButtonXuatHang.Checked)
                {
                    gia = vatLieu.GiaXuat;
                }
                else
                {
                    gia = vatLieu.GiaNhap;
                }
                row.Cells[3].Value = new StringUtility().ConvertToVietnameseCurrency(gia);
                row.Cells[4].Value = vatLieu.DonVi;
                row.Cells[5].Value = soLuong;
                double tongTien = double.Parse(row.Cells[3].Value.ToString()) * soLuong;
                row.Cells[6].Value = new StringUtility().ConvertToVietnameseCurrency(tongTien);
                this.dataGridViewShowVatLieu.Rows.Add(row);
            }
            return this.isExitsVatLieuInHoaDon(vatLieu);
        }
        private bool removeVatLieuInHoaDon(VatLieu vatLieu)
        {
            foreach (DataGridViewRow row in this.dataGridViewShowVatLieu.Rows)
            {
                if (row.Cells["MaVatLieu"].Value.ToString() == vatLieu.MaVatLieu)
                {
                    this.dataGridViewShowVatLieu.Rows.Remove(row);
                    return true;
                }
            }
            return false;
        }

        private void radioButtonXuatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonXuatHang.Checked)
            {
                this.ShowVatLieus();
                this.labelTitle.Text = "Hóa đơn xuất";
                this.resetPanelHoaDon();
            }
        }

        private void radioButtonNhapHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonNhapHang.Checked)
            {
                this.ShowVatLieus();
                this.labelTitle.Text = "Hóa đơn nhập";
                this.resetPanelHoaDon();
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Show();
            this.btnAnHoaDon.Enabled = true;
        }

        private void btnAnHoaDon_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Hide();
            this.btnAnHoaDon.Enabled = false;
        }
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Show();
            this.btnAnHoaDon.Enabled = true;
            this.formChonSoLuongVatLieu.ShowDialog();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isExitsVatLieuInHoaDon(this.formChonSoLuongVatLieu.VatLieu))
            {
                if (this.formChonSoLuongVatLieu.GetSoLuong() == 0)
                {
                    this.removeVatLieuInHoaDon(this.formChonSoLuongVatLieu.VatLieu);
                }
                else
                {
                    this.setSoLuongVatLieuInHoDon(this.formChonSoLuongVatLieu.VatLieu, this.formChonSoLuongVatLieu.GetSoLuong());
                }
            }
            else
            {
                this.addVatlieuToHoaDon(this.formChonSoLuongVatLieu.VatLieu, this.formChonSoLuongVatLieu.GetSoLuong());
            }
            this.formChonSoLuongVatLieu.Close();
        }

        private void dataGridViewShowVatLieu_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int stt = 1; // Bắt đầu từ 1
            foreach (DataGridViewRow row in this.dataGridViewShowVatLieu.Rows)
            {
                if (!row.IsNewRow) // Loại bỏ hàng mới
                {
                    row.Cells["STT"].Value = stt;
                    stt++;
                }
            }
        }

        private void dataGridViewShowVatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells["MaVatLieu"].Value != null)
            {
                string maVatLieu = this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells["MaVatLieu"].Value.ToString();
                float soLuong = float.Parse(this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString());
                VatLieu vatLieu = this.vatLieuService.findByMaVatLieu(maVatLieu);
                if (vatLieu != null)
                {
                    this.formChonSoLuongVatLieu.VatLieu = vatLieu;
                    this.formChonSoLuongVatLieu.LoaiHoaDon = this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2;
                    this.formChonSoLuongVatLieu.SetSoLuong(soLuong);
                    this.formChonSoLuongVatLieu.btnOkClick += this.btnOk_Click;
                    this.formChonSoLuongVatLieu.ShowDialog();
                }
            }
        }

        private void btnTaoVatLieuMoi_Click(object sender, EventArgs e)
        {

        }
    }
}
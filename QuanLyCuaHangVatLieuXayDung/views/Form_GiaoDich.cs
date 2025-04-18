using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private FileUtility fileUtility = new FileUtility();

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
                    userControl.btnTransactionClick += this.btnTransaction_Click;
                    this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                }
            }
            
        }
        private void loadVatLieuInHoaDon()
        {
            string filePath = "";
            if (this.radioButtonXuatHang.Checked)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonxuat.json");
            }
            else 
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonnhap.json");
            }
            List<ChiTiet> chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(filePath);
            this.dataGridViewShowVatLieu.Rows.Clear();
            DataGridViewRow dataGridViewRow;
            foreach (ChiTiet chiTiet in chiTiets)
            {
                dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dataGridViewShowVatLieu);
                dataGridViewRow.Cells["MaVatLieu"].Value = chiTiet.VatLieu.MaVatLieu;
                dataGridViewRow.Cells["TenVatLieu"].Value = chiTiet.VatLieu.Ten;
                if (this.radioButtonXuatHang.Checked)
                {
                    dataGridViewRow.Cells["Gia"].Value = chiTiet.VatLieu.GiaXuat;
                }
                else
                {
                    dataGridViewRow.Cells["Gia"].Value = chiTiet.VatLieu.GiaNhap;
                }
                dataGridViewRow.Cells["DonVi"].Value = chiTiet.VatLieu.DonVi;
                dataGridViewRow.Cells["SoLuong"].Value = chiTiet.SoLuong;
                dataGridViewRow.Cells["TongTien"].Value = double.Parse(dataGridViewRow.Cells["Gia"].Value.ToString()) * chiTiet.SoLuong;
                this.dataGridViewShowVatLieu.Rows.Add(dataGridViewRow);
            }
        }
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Show();
            this.btnAnHoaDon.Enabled = true;
            this.formChonSoLuongVatLieu.ShowDialog();
            //Hiển thị vật liệu giao dịch trong hóa đơn
            this.loadVatLieuInHoaDon();
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
                    this.formChonSoLuongVatLieu.ShowDialog();
                    //Cập nhật lại danh sách vật liệu giao dịch trong hóa đơn
                    this.loadVatLieuInHoaDon();
                }
            }
        }

        private void btnTaoVatLieuMoi_Click(object sender, EventArgs e)
        {
            Form_TaoVatLieuMoi form_TaoVatLieuMoi = new Form_TaoVatLieuMoi();
            form_TaoVatLieuMoi.ShowDialog();
            this.loadVatLieuInHoaDon();
            this.ShowVatLieus();
        }

        private void btnChonVatLieu_Click(object sender, EventArgs e)
        {
            Form_SelectVatLieu form_SelectVatLieu = new Form_SelectVatLieu();
            form_SelectVatLieu.ShowDialog();
            this.loadVatLieuInHoaDon();
        }
    }
}
using QuanLyCuaHangVatLieuXayDung.model;
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
    public partial class Form_TaiKhoan : Form

    {
        private TaiKhoanService taiKhoanService = new TaiKhoanService();
        private FileUtility fileUtility = new FileUtility();
        private TaiKhoan taiKhoan;
        private string qrPath = string.Empty;
        public Form_TaiKhoan()
        {
            InitializeComponent();
        }
        

        private void Form_TaiKhoan_Load(object sender, EventArgs e)
        {
            this.taiKhoan = this.GetTaiKhoan();
            if (this.taiKhoan != null)
            {
                this.ShowTaiKhoan();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private TaiKhoan GetTaiKhoan()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dirTempFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "false", "taikhoan.json");
            List<TaiKhoan> taiKhoans = this.fileUtility.ReadObjectsFromJsonFile<TaiKhoan>(dirTempFalse);
            if (taiKhoans.Count > 0)
            {
                return taiKhoans[0];
            }
            else
            {
                return null;
            }
        }
        private void ShowTaiKhoan()
        {
            this.txtMaTaiKhoan.Text = this.taiKhoan.MaTaiKhoan;
            this.txtTenDangNhap.Text = this.taiKhoan.TenDangNhap;
            this.txtMatKhau.Text = this.taiKhoan.MatKhau;
            this.txtTenCuaHang.Text = this.taiKhoan.TenCuaHang;
            this.txtSoDienThoai.Text = this.taiKhoan.SoDienThoai;
            this.txtDiaChi.Text = this.taiKhoan.DiaChi;
            this.txtEmail.Text = this.taiKhoan.Email;
            this.cboNganHang.Text = this.taiKhoan.NganHang;
            this.txtSoTaiKhoan.Text = this.taiKhoan.SoTaiKhoan;
            // Load ảnh QR code
            if (!string.IsNullOrEmpty(this.taiKhoan.QR) && File.Exists(this.taiKhoan.QR))
            {
                this.picQR.Image = Image.FromFile(this.taiKhoan.QR);
                this.picQR.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                this.picQR.Image = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.MaTaiKhoan = this.txtMaTaiKhoan.Text.Trim();
            taiKhoan.TenDangNhap = this.txtTenDangNhap.Text.Trim();
            taiKhoan.MatKhau = this.txtMatKhau.Text.Trim();
            taiKhoan.TenCuaHang = this.txtTenCuaHang.Text.Trim();   
            taiKhoan.SoDienThoai = this.txtSoDienThoai.Text.Trim();
            taiKhoan.DiaChi = this.txtEmail.Text.Trim();
            taiKhoan.Email = this.txtEmail.Text.Trim();
            taiKhoan.NganHang = this.cboNganHang.Text.Trim();
            taiKhoan.SoTaiKhoan = this.txtSoTaiKhoan.Text.Trim();
            taiKhoan.QR = this.qrPath;
            if (this.taiKhoanService.updateTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Lưu thông tin tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.taiKhoan = taiKhoan;
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string dirTempFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "false", "taikhoan.json");
                string dirTempTrue = Path.Combine(projectDirectory, "temp", "taikhoan", "true", "taikhoan.json");
                this.fileUtility.WriteObjectJsonFile(taiKhoan, dirTempFalse);
                this.fileUtility.WriteObjectJsonFile(taiKhoan, dirTempTrue);
            }
            else
            {
                MessageBox.Show("Lưu thông tin tài khoản thất bại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ShowTaiKhoan();
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh QR code";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.qrPath = openFileDialog.FileName;
                    if (!string.IsNullOrEmpty(this.qrPath))
                    {
                        this.picQR.Image = Image.FromFile(this.qrPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

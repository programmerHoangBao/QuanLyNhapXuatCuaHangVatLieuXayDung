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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_DangNhap : Form
    {
        private TaiKhoanService taiKhoanService = new TaiKhoanService();
        private FileUtility fileUtility = new FileUtility();
        private bool isPasswordVisible = false;
        public Form_DangNhap()
        {
            InitializeComponent();
        }
        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = this.GetTaiKhoan();
            this.checkBoxghiNho.Checked = true;
            if (taiKhoan != null)
            {
                this.textBoxtenDN.Text = taiKhoan.TenDangNhap;
                this.textBoxmatKhau.Text = taiKhoan.MatKhau;
            }
        }
        private TaiKhoan GetTaiKhoan()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dirTempFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "true", "taikhoan.json");
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
        private void btnShowPass_Click(object sender, EventArgs e)
        {
            {
                isPasswordVisible = !isPasswordVisible;
                textBoxmatKhau.UseSystemPasswordChar = !isPasswordVisible;   
            }

        }
        private void buttnhdangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBoxtenDN.Text.Trim();
            string matKhau = textBoxmatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string username = textBoxtenDN.Text.Trim();
            string password = textBoxmatKhau.Text;
            TaiKhoan tk = taiKhoanService.login(username, password);

            if (tk != null && tk.MatKhau == matKhau)
            {
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string taiKhoanJsonFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "false", "taikhoan.json");
                this.fileUtility.WriteObjectJsonFile(tk, taiKhoanJsonFalse);
                // Ghi nhớ nếu checkbox được chọn
                if (checkBoxghiNho.Checked)
                {
                    string taiKhoanJsonTrue = Path.Combine(projectDirectory, "temp", "taikhoan", "true", "taikhoan.json");
                    this.fileUtility.WriteObjectJsonFile(tk, taiKhoanJsonTrue);
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form login, mở form chính
                this.Hide();
                new Form_TrangChu().ShowDialog(); // form chính
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

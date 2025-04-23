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
        private bool isPasswordVisible = false;
        public Form_DangNhap()
        {
            InitializeComponent();
        }
        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = this.GetTaiKhoan();
            if (taiKhoan != null)
            {
                this.textBoxtenDN.Text = taiKhoan.TenDangNhap;
                this.textBoxmatKhau.Text = taiKhoan.MatKhau;
            }
        }
        private void writeFileToJson(TaiKhoan taiKhoan)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dirTempTrue = Path.Combine(projectDirectory, "temp", "taikhoan", "true", "taikhoan.json");
            string dirTempFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "false", "taikhoan.json");
            new FileUtility().WriteObjectJsonFile(taiKhoan, dirTempTrue);
            new FileUtility().WriteObjectJsonFile(taiKhoan, dirTempFalse);
        }
        private TaiKhoan GetTaiKhoan()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dirTempFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "true", "taikhoan.json");
            List<TaiKhoan> taiKhoans = new FileUtility().ReadObjectsFromJsonFile<TaiKhoan>(dirTempFalse);
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

            TaiKhoan taiKhoan = taiKhoanService.login(username, password);

            if (tk != null && tk.MatKhau == matKhau)
            {
                // Ghi nhớ nếu checkbox được chọn
                if (checkBoxghiNho.Checked)
                {
                    Properties.Settings.Default.TenDangNhap = tenDangNhap;
                    Properties.Settings.Default.MatKhau = matKhau;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.TenDangNhap = "";
                    Properties.Settings.Default.MatKhau = "";
                    Properties.Settings.Default.Save();
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Thưc hiện ghi file
                writeFileToJson(tk);
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

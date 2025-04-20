using QuanLyCuaHangVatLieuXayDung.config;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using QuanLyCuaHangVatLieuXayDung.config;
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
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_TaoDoiTacMoi : Form
    {
        private byte loaiDoiTac;
        private IDoiTacService doiTacService = new DoiTacService();
        private string imagePath;

        public byte LoaiDoiTac { get => loaiDoiTac; set => loaiDoiTac = value; }

        public Form_TaoDoiTacMoi()
        {
            InitializeComponent();
        }
        private void Form_TaoDoiTacMoi_Load(object sender, EventArgs e)
        {
            string maDoiTac = "";
            while (true)
            {
                maDoiTac = new StringUtility().GenerateRandomString(10);
                if (this.doiTacService.findByMaDoiTac(maDoiTac) == null)
                {
                    break;
                }
            }
            this.txtMaDoiTac.Text = maDoiTac;
            this.txtSoDienThoai.MaxLength = 10;
            this.comboBoxNganHang.SelectedIndex = 0;
        }
        private DoiTac CreateDoiTacToInput()
        {
            DoiTac doiTac = null;
            string maDoiTac = string.IsNullOrEmpty(this.txtMaDoiTac.Text.Trim()) ? null : this.txtMaDoiTac.Text.Trim();
            string tenDoiTac = string.IsNullOrEmpty(this.txtTenDoiTac.Text.Trim()) ? null : this.txtTenDoiTac.Text.Trim();
            string sdt = string.IsNullOrEmpty(this.txtSoDienThoai.Text.Trim()) ? null : this.txtSoDienThoai.Text.Trim();
            string diaChi = string.IsNullOrEmpty(this.txtDiaChi.Text.Trim()) ? null : this.txtDiaChi.Text.Trim();
            string email = string.IsNullOrEmpty(this.txtEmail.Text.Trim()) ? null : this.txtEmail.Text.Trim();
            string nganHang = string.IsNullOrEmpty(this.comboBoxNganHang.Text.Trim()) ? null : this.comboBoxNganHang.Text.Trim();
            string stk = string.IsNullOrEmpty(this.txtSoTK.Text.Trim()) ? null : this.txtSoTK.Text.Trim();
            this.imagePath = string.IsNullOrEmpty(this.imagePath) ? null : this.imagePath;
            if (this.LoaiDoiTac == 1)
            {
                doiTac = new KhachHang(maDoiTac, tenDoiTac, sdt, diaChi, email, nganHang, stk, imagePath);
            }
            else
            {
                doiTac = doiTac = new NhaCungCap(maDoiTac, tenDoiTac, sdt, diaChi, email, nganHang, stk, imagePath);
            }
            return doiTac;
        }
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoTK_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBoxImageQR.Image = Image.FromFile(openFileDialog.FileName);
                    this.imagePath = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DoiTac doiTac = CreateDoiTacToInput();
            string saveImagePath = null;

            //Thực hiện ghi file hình ảnh vào thưu mục hệ thống
            if (!string.IsNullOrEmpty(this.imagePath))
            {
                string imageName = Path.GetFileNameWithoutExtension(this.imagePath);
                string extension = Path.GetExtension(this.imagePath);
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string newImageName = $"{imageName}_{timestamp}{extension}";
                string dirDoiTac = new FormApp().DOITAC_DATA;
                saveImagePath = new FileUtility().CopyAndRenameFile(this.imagePath, dirDoiTac, newImageName);
            }

            //Thực hiện thêm dữ liệu vào database
            if (doiTac != null)
            {
                doiTac.QR = saveImagePath;
                if (this.doiTacService.insertDoiTac(doiTac))
                {
                    MessageBox.Show("Đối tác đã được tạo mới!", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ghi thông tin đối tác vào file Json
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string filePath = "";
                    if (doiTac is KhachHang)
                    {
                        filePath = Path.Combine(projectDirectory, "temp", "hoadon", "khachHang.json");
                    }
                    else
                    {
                        filePath = Path.Combine(projectDirectory, "temp", "hoadon", "nhacungcap.json");
                    }
                    new FileUtility().WriteObjectJsonFile<DoiTac>(doiTac, filePath);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tạo mới đối tác thất bại!", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

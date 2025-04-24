using QuanLyCuaHangVatLieuXayDung.config;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_TaoVatLieuMoi : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        private StringUtility stringUtility = new StringUtility();
        private FileUtility fileUtility = new FileUtility();
        private List<string> hinhAnhPaths = new List<string>();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        int index = 0;
        private byte loaiHoaDon = 1;

        public byte LoaiHoaDon { get => loaiHoaDon; set => loaiHoaDon = value; }

        public Form_TaoVatLieuMoi()
        {
            InitializeComponent();
        }

        private void Form_TaoVatLieuMoi_Load(object sender, EventArgs e)
        {
            //SetUp mã vật liệu từ động
            string maVatLieuNew = this.stringUtility.GenerateRandomString(10);
            while (this.vatLieuService.findByMaVatLieu(maVatLieuNew) != null)
            {
                maVatLieuNew = this.stringUtility.GenerateRandomString(10);
            }
            this.txtMaVatLieu.Text = maVatLieuNew;

            //Thực hiện chọn vào text box tên vật liệu
            this.txtTenVatlieu.Select();

            this.nhaCungCaps = new DoiTacService().findAllNhaCungCap();
            foreach (NhaCungCap nhaCungCap in nhaCungCaps)
            {
                this.comboBoxNhaCungCap.Items.Add(nhaCungCap.Ten);
            }
        }
        //Thực hiện lấy ra số lượng vật liệu
        public float GetSoLuong()
        {
            if (this.txtSoLuong.Text == "" || float.Parse(this.txtSoLuong.Text) <= 0)
            {
                return 0;
            }
            return float.Parse(this.txtSoLuong.Text);
        }
        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ShowImage(string imagePath)
        {
            if (this.fileUtility.IsFileExists(imagePath))
            {
                try
                {
                    // Giải phóng bộ nhớ hình cũ nếu có
                    if (this.pictureBoxShowImage.Image != null)
                    {
                        this.pictureBoxShowImage.Image.Dispose();
                    }

                    // Load ảnh mới
                    this.pictureBoxShowImage.Image = Image.FromFile(imagePath);
                    this.pictureBoxShowImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("Can't find the image path:" + imagePath);
            }
        }

        private void txtGiaNhap_Leave(object sender, EventArgs e)
        {
            if (this.txtGiaNhap.Text.Trim() == "")
            {
                this.txtGiaNhap.Text = "0";
            }
        }
        private void txtGiaXuat_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtGiaXuat_Leave(object sender, EventArgs e)
        {
            if (this.txtGiaXuat.Text.Trim() == "")
            {
                this.txtGiaXuat.Text = "0";
            }
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (this.txtSoLuong.Text.Trim() == "")
            {
                this.txtSoLuong.Text = "0";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            float soLuong = this.GetSoLuong();
            soLuong += 1;
            this.txtSoLuong.Text = soLuong.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            float soLuong = this.GetSoLuong();
            soLuong -= 1;
            if (soLuong >= 0)
            {
                this.txtSoLuong.Text = soLuong.ToString();
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            int count = this.hinhAnhPaths.Count;
            if (count <= 0)
            {
                return;
            }
            index += 1;
            if (index >= count)
            {
                index = 0;
            }
            ShowImage(this.hinhAnhPaths[index]);
        }

        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            int count = this.hinhAnhPaths.Count;
            if (count <= 0)
            {
                return;
            }
            if (index - 1 < 0)
            {
                index = 0;
            }
            else
            {
                index -= 1;
            }
            ShowImage(this.hinhAnhPaths[index]);
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    this.hinhAnhPaths.Add(imagePath);
                    if (this.hinhAnhPaths.Count > 0)
                    {
                        this.index = this.hinhAnhPaths.Count - 1;
                        this.ShowImage(this.hinhAnhPaths[index]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            if (this.pictureBoxShowImage.Image != null)
            {
                this.pictureBoxShowImage.Image.Dispose();
                this.pictureBoxShowImage.Image = null;
            }

            if (this.fileUtility.DeleteFile(this.hinhAnhPaths[index]))
            {
                this.hinhAnhPaths.RemoveAt(index);
                index = 0;
                if (this.hinhAnhPaths.Count > 0)
                {
                    this.ShowImage(this.hinhAnhPaths[index]);
                }
            }
        }

        private void btnTaoVatLieu_Click(object sender, EventArgs e)
        {
            string maVatLieu = this.txtMaVatLieu.Text.Trim();
            string tenVatLieu = this.txtTenVatlieu.Text.Trim();
            double giaNhap = double.Parse(this.txtGiaNhap.Text.Trim());
            double giaXuat = double.Parse(this.txtGiaXuat.Text.Trim());
            string donVi = this.txtDonVi.Text.Trim();
            NhaCungCap nhaCungCap;
            if (this.comboBoxNhaCungCap.Text.Trim() == "")
            {
                nhaCungCap = null;
            }
            else
            {
                nhaCungCap = this.nhaCungCaps[this.comboBoxNhaCungCap.SelectedIndex];
            }
            float soLuong = float.Parse(this.txtSoLuong.Text.Trim());
            //Lưu hình ảnh vào thư mục hệ thống
            string dirHinhAnh = new FormApp().VATLIEU_DATA;
            string dirName = maVatLieu + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            dirHinhAnh = Path.Combine(dirHinhAnh, dirName);
            if (this.fileUtility.FolderExists(dirHinhAnh))
            {
                this.fileUtility.CreateFolder(dirHinhAnh);
            }
            string imageName = "";
            string extension = "";
            string timestamp = "";
            string newImageName = "";
            foreach (string imagePath in this.hinhAnhPaths)
            {
                imageName = Path.GetFileNameWithoutExtension(imagePath);
                extension = Path.GetExtension(imagePath);
                timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                newImageName = $"{imageName}_{timestamp}{extension}";
                this.fileUtility.CopyAndRenameFile(imagePath, dirHinhAnh, newImageName);
            }
            VatLieu vatLieu = new VatLieu(maVatLieu, tenVatLieu, giaNhap, giaXuat
                , donVi, DateTime.Now, dirHinhAnh, nhaCungCap, soLuong);
            //Ghi đối tượng vật liệu mới vào file json
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");
            if (this.fileUtility.AppendObjectJsonFile(new ChiTiet(vatLieu, vatLieu.SoLuong), filePath))
            {
                MessageBox.Show("Tạo vật liệu mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo vật liệu mới thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.fileUtility.DeleteFolder(vatLieu.DirHinhAnh);
                this.fileUtility.DeleteFile(filePath);
            }
        }
    }
}

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
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dir_temp = Path.Combine(projectDirectory, "temp", "image", "vatlieu");
            if (dir_temp == "")
            {
                MessageBox.Show("có nơi lưu tạm thời hình ảnh", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Sao chép hình ảnh vào temp/image/vatlieu và lưu đường dẫn đó vào hinhAnhPaths
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    string imageName = Path.GetFileNameWithoutExtension(imagePath);
                    string extension = Path.GetExtension(imagePath);

                    //Tạo nơi lưu trử temp cho hình ảnh
                    this.fileUtility.CreateFolder(dir_temp);
                    if (this.fileUtility.FolderExists(dir_temp))
                    {
                        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                        string newImageName = $"{imageName}_{timestamp}{extension}";

                        string newImagePath = this.fileUtility.CopyAndRenameFile(imagePath, dir_temp, newImageName);
                        if (!String.IsNullOrEmpty(newImagePath))
                        {
                            this.hinhAnhPaths.Add(newImagePath);
                            if (this.hinhAnhPaths.Count > 0)
                            {
                                this.index = this.hinhAnhPaths.Count - 1;
                                this.ShowImage(this.hinhAnhPaths[index]);
                            }
                        }
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
            NhaCungCap nhaCungCap = this.nhaCungCaps[this.comboBoxNhaCungCap.SelectedIndex];
            float soLuong = float.Parse(this.txtSoLuong.Text.Trim());
            string dir_temp = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "image", "vatlieu");
            string dirHinhAnh = new FormApp().VATLIEU_DATA;
            string dirName = maVatLieu + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            dirHinhAnh = Path.Combine(dirHinhAnh, dirName);
            if (this.fileUtility.FolderExists(dirHinhAnh))
            {
                this.fileUtility.CreateFolder(dirHinhAnh);
            }
            List<string> imagePaths = this.fileUtility.GetImagePathsFromFolder(dir_temp);
            foreach (string imagePath in imagePaths)
            {
                this.fileUtility.SaveImages(imagePath, dirHinhAnh);
            }
            VatLieu vatLieu = new VatLieu(maVatLieu, tenVatLieu, giaNhap, giaXuat
                , donVi, DateTime.Now, dirHinhAnh, nhaCungCap, soLuong);
            if (this.vatLieuService.insertVatLieu(vatLieu))
            {
                MessageBox.Show("Tạo vật liệu thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string chiTietJson = "";
                if (this.LoaiHoaDon == 1)
                {
                    chiTietJson = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonxuat.json");
                }
                else if (this.LoaiHoaDon == 2)
                {
                    chiTietJson = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonnhap.json");
                }
                ChiTiet chiTiet = new ChiTiet(vatLieu.SoLuong, vatLieu);
                if (!this.fileUtility.IsFileExists(chiTietJson))
                {
                    this.fileUtility.WriteObjectJsonFile(chiTiet, chiTietJson);
                }
                else
                {
                    this.fileUtility.AppendObjectToJsonFile(chiTiet, chiTietJson);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo vật liệu thất bại!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

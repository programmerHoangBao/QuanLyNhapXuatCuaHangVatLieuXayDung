using QuanLyCuaHangVatLieuXayDung.config;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_VatLieu : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        private IDoiTacService doiTacService = new DoiTacService();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        private List<string> imagePaths = new List<string>();
        private StringUtility stringUtility = new StringUtility();
        private FileUtility fileUtility = new FileUtility();
        private int index = 0;
        public Form_VatLieu()
        {
            InitializeComponent();
        }

        private void Form_VatLieu_Load(object sender, EventArgs e)
        {
            this.SetUpComboBoxNhaCungCap();
            this.resetForm();
        }
        private void ShowDanhSachVatLieu()
        {
            this.dataGridViewShowVatLieu.Rows.Clear();
            List<VatLieu> vatLieus = this.vatLieuService.findAllSortedByClosestDate();
            foreach(VatLieu vatLieu in vatLieus)
            {
                this.dataGridViewShowVatLieu.Rows.Add(
                    vatLieu.MaVatLieu, vatLieu.Ten, vatLieu.GiaNhap, vatLieu.GiaXuat,
                    vatLieu.DonVi, vatLieu.NgayNhap,
                    vatLieu.NhaCungCap != null ? vatLieu.NhaCungCap.Ten : "Unknown",
                    vatLieu.SoLuong,
                    vatLieu.GetDanhSachHinhAnhVatLieus().Any() ? Image.FromFile(vatLieu.GetDanhSachHinhAnhVatLieus()[0]) : null
                );
            }
        }
        private void SetUpComboBoxNhaCungCap()
        {
            this.comboBoxNhaCungCap.Items.Clear();
            this.nhaCungCaps = this.doiTacService.findAllNhaCungCap();
            foreach (NhaCungCap nhaCungCap in nhaCungCaps)
            {
                this.comboBoxNhaCungCap.Items.Add(nhaCungCap.Ten);
            }
        }
        private string TaoMaVatLieuTuDong()
        {
            string maVatLieu = this.stringUtility.GenerateRandomString(10);
            while (this.vatLieuService.findByMaVatLieu(maVatLieu) != null)
            {
                maVatLieu = this.stringUtility.GenerateRandomString(10);
            }
            return maVatLieu;
        }
        private string TaoGiaXuatTuDong()
        {
            if (this.txtGiaNhap.Text.Trim() == "")
            {
                return "";
            }
            else
            {
                double giaNhap = double.Parse(this.txtGiaNhap.Text.Trim());
                double giaXuat = giaNhap * 1.3;
                return giaXuat.ToString();
            }
        }
        private VatLieu CreateVatLieuInput()
        {
            VatLieu vatLieu = new VatLieu();
            vatLieu.MaVatLieu = this.txtMaVatLieu.Text.Trim();
            vatLieu.Ten = this.txtTenVatlieu.Text.Trim();
            vatLieu.GiaNhap = double.Parse(this.txtGiaNhap.Text.Trim());
            vatLieu.GiaXuat = double.Parse(this.txtGiaXuat.Text.Trim());
            vatLieu.DonVi = this.txtDonVi.Text.Trim();
            vatLieu.NgayNhap = this.dateTimePickerNgayNhap.Value;
            if (this.comboBoxNhaCungCap.SelectedIndex != -1)
            {
                vatLieu.NhaCungCap = this.nhaCungCaps[this.comboBoxNhaCungCap.SelectedIndex];
            }
            vatLieu.SoLuong = int.Parse(this.txtSoLuong.Text.Trim());
            string dirHinhAnh = string.Empty;
            if (this.imagePaths.Count > 0)
            {
                //Lấy đường dẫn hệ thống và tạo folder chứ hình ảnh vật liệu
                dirHinhAnh = new FormApp().VATLIEU_DATA;
                string dirName = vatLieu.MaVatLieu + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                dirHinhAnh = Path.Combine(dirHinhAnh, dirName);
                if (this.fileUtility.FolderExists(dirHinhAnh))
                {
                    this.fileUtility.CreateFolder(dirHinhAnh);
                }
                //Copy và đổi tên hình ảnh
                string imageName = "";
                string extension = "";
                string timestamp = "";
                string newImageName = "";
                foreach (string imagePath in this.imagePaths)
                {
                    imageName = Path.GetFileNameWithoutExtension(imagePath);
                    extension = Path.GetExtension(imagePath);
                    timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    newImageName = $"{imageName}_{timestamp}{extension}";
                    this.fileUtility.CopyAndRenameFile(imagePath, dirHinhAnh, newImageName);
                }
                vatLieu.DirHinhAnh = dirHinhAnh;
            }
            return vatLieu;
        }

        private void resetForm()
        {
            this.txtTimKiem.Text = "";
            this.txtMaVatLieu.Text = this.TaoMaVatLieuTuDong();
            this.txtTenVatlieu.Text = "";
            this.txtGiaNhap.Text = "0";
            this.txtGiaXuat.Text = "0";
            this.txtDonVi.Text = "";
            this.dateTimePickerNgayNhap.Value = DateTime.Now;
            this.comboBoxNhaCungCap.Text = "";
            this.txtSoLuong.Text = "0";
            this.pictureBoxShowImage.Image = null;
            this.ShowDanhSachVatLieu();
            this.imagePaths.Clear();
            this.index = 0;
        }
        public float GetSoLuong()
        {
            if (this.txtSoLuong.Text == "" || float.Parse(this.txtSoLuong.Text) <= 0)
            {
                return 0;
            }
            return float.Parse(this.txtSoLuong.Text);
        }
        private void dataGridViewShowVatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string maVatLieu = this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                    VatLieu vatLieu = this.vatLieuService.findByMaVatLieu(maVatLieu);
                    if (vatLieu != null)
                    {
                        this.txtMaVatLieu.Text = vatLieu.MaVatLieu;
                        this.txtTenVatlieu.Text = vatLieu.Ten;
                        this.txtGiaNhap.Text = vatLieu.GiaNhap.ToString();
                        this.txtGiaXuat.Text = vatLieu.GiaXuat.ToString();
                        this.txtDonVi.Text = vatLieu.DonVi;
                        this.dateTimePickerNgayNhap.Value = vatLieu.NgayNhap;
                        if (vatLieu.NhaCungCap != null)
                        {
                            for (int i =0; i < this.nhaCungCaps.Count; i++)
                            {
                                if (vatLieu.NhaCungCap.MaDoiTac == this.nhaCungCaps[i].MaDoiTac)
                                {
                                    this.comboBoxNhaCungCap.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                        this.txtSoLuong.Text = vatLieu.SoLuong.ToString();
                        if (vatLieu.GetDanhSachHinhAnhVatLieus().Count > 0)
                        {
                            this.pictureBoxShowImage.Image = Image.FromFile(vatLieu.GetDanhSachHinhAnhVatLieus()[0]);
                            this.imagePaths.Clear();
                            foreach (string imagePath in vatLieu.GetDanhSachHinhAnhVatLieus())
                            {
                                this.imagePaths.Add(imagePath);
                            }
                            index = 0;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = this.txtTimKiem.Text.Trim();
            if (key == "")
            {
                this.ShowDanhSachVatLieu();
            }
            else
            {
                List<VatLieu> vatLieus = this.vatLieuService.searchByKey(key);
                this.dataGridViewShowVatLieu.Rows.Clear();
                foreach (VatLieu vatLieu in vatLieus)
                {
                    this.dataGridViewShowVatLieu.Rows.Add(
                                                      vatLieu.MaVatLieu, vatLieu.Ten
                                                      , vatLieu.GiaNhap, vatLieu.GiaXuat
                                                      , vatLieu.DonVi, vatLieu.NgayNhap
                                                      , vatLieu.NhaCungCap.Ten, vatLieu.SoLuong
                                                      , Image.FromFile(vatLieu.GetDanhSachHinhAnhVatLieus()[0])
                                                       );
                }
            }
        }
        private void txtGiaNhap_MouseLeave(object sender, EventArgs e)
        {
            this.txtGiaXuat.Text = this.TaoGiaXuatTuDong();
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
            if (!float.TryParse(this.txtSoLuong.Text, out float result) && this.txtSoLuong.Text != "")
            {
                MessageBox.Show("Giá trị không hợp lệ! Vui lòng nhập số thực.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSoLuong.Focus();
            }
            else if (this.txtSoLuong.Text == "")
            {
                this.txtSoLuong.Text = "0";
            }
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
                    this.imagePaths.Add(imagePath);
                    if (this.imagePaths.Count > 0)
                    {
                        this.index = this.imagePaths.Count - 1;
                        this.pictureBoxShowImage.Image = Image.FromFile(this.imagePaths[this.index]);
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
                this.imagePaths.RemoveAt(index);
                index = 0;
                if (this.imagePaths.Count > 0)
                {
                    this.pictureBoxShowImage.Image = Image.FromFile(this.imagePaths[this.index]);
                }
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            int count = this.imagePaths.Count;
            if (count <= 0)
            {
                return;
            }
            index += 1;
            if (index >= count)
            {
                index = 0;
            }
            this.pictureBoxShowImage.Image = Image.FromFile(this.imagePaths[this.index]);
        }

        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            int count = this.imagePaths.Count;
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
            this.pictureBoxShowImage.Image = Image.FromFile(this.imagePaths[this.index]);
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

        private void btnThemVatLieu_Click(object sender, EventArgs e)
        {
            VatLieu vatLieuNew = this.CreateVatLieuInput();
            if (vatLieuNew != null)
            {
                if (this.vatLieuService.insertVatLieu(vatLieuNew))
                {
                    MessageBox.Show("Thêm vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.resetForm();
                }
                else
                {
                    MessageBox.Show("Thêm vật liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.fileUtility.DeleteFolder(vatLieuNew.DirHinhAnh);
                }
            }
        }

        private void btnUpdateVatLieu_Click(object sender, EventArgs e)
        {
            VatLieu vatLieuUpdate = this.CreateVatLieuInput();
            if (vatLieuUpdate != null)
            {
                string oldDirHinhAnh = this.vatLieuService.findByMaVatLieu(vatLieuUpdate.MaVatLieu).DirHinhAnh;
                if (this.vatLieuService.updateVatLieu(vatLieuUpdate))
                {
                    MessageBox.Show("Cập nhật vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ShowDanhSachVatLieu();
                }
                else
                {
                    MessageBox.Show("Cập nhật vật liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteVatLieu_Click(object sender, EventArgs e)
        {
            VatLieu vatLieuDelete = this.CreateVatLieuInput();
            if(vatLieuDelete != null)
            {
                if (this.vatLieuService.deleteVatLieu(vatLieuDelete))
                {
                    MessageBox.Show("Xóa vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.resetForm();
                }
                else
                {
                    MessageBox.Show("Xóa vật liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.resetForm();
        }
    }
}

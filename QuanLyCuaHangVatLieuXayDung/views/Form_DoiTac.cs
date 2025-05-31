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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_DoiTac : Form
    {
        private IDoiTacService doiTacService = new DoiTacService();
        private StringUtility stringUtility = new StringUtility();
        private string qrPath = string.Empty;
        private FileUtility fileUtility = new FileUtility();
        public Form_DoiTac()
        {
            InitializeComponent();
        }

        private void Form_DoiTac_Load(object sender, EventArgs e)
        {
            this.radioButtonKhachHang.Checked = true;
            this.txtSoDienThoai.MaxLength = 10;
            this.resetFrom();
        }
        private void ShowDanhSachKhachHang()
        {
            this.dataGridViewShowDoiTac.Rows.Clear();
            List<KhachHang> khachHangs = doiTacService.findAllKhachHang();
            foreach(KhachHang khachHang in khachHangs)
            {
                this.dataGridViewShowDoiTac.Rows.Add(
                                                      khachHang.MaDoiTac, khachHang.Ten
                                                      , khachHang.SoDienThoai, khachHang.DiaChi);
            }
        }
        private void ShowDanhSachNhaCungCap()
        {
            this.dataGridViewShowDoiTac.Rows.Clear();
            List<NhaCungCap> nhaCungCaps = doiTacService.findAllNhaCungCap();
            foreach (NhaCungCap nhaCungCap in nhaCungCaps)
            {
                this.dataGridViewShowDoiTac.Rows.Add(
                                                      nhaCungCap.MaDoiTac, nhaCungCap.Ten
                                                      , nhaCungCap.SoDienThoai, nhaCungCap.DiaChi);
            }
        }
        private string taoMaDoiTacTuDong()
        {
            string maDoiTac = "";
            while (true)
            {
                maDoiTac = stringUtility.GenerateRandomString(10);
                if (this.doiTacService.findByMaDoiTac(maDoiTac) == null)
                {
                    break;
                }
            }
            return maDoiTac;
        }
        private void resetFrom()
        {
            this.txtTimKiem.Text = "";
            this.txtMaDoiTac.Text = this.taoMaDoiTacTuDong();
            this.txtTenDoiTac.Text = "";
            this.txtSoDienThoai.Text = "";
            this.txtDiaChi.Text = "";
            this.txtEmail.Text = "";
            this.comboBoxNganHang.SelectedIndex = 0;
            this.txtSoTK.Text = "";
            this.pictureBoxImageQR.Image = null;
            this.qrPath = String.Empty;
            this.dataGridViewShowDoiTac.Rows.Clear();
            if (this.radioButtonKhachHang.Checked)
            {
                this.ShowDanhSachKhachHang();
            }
            else
            {
                this.ShowDanhSachNhaCungCap();
            }
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
            this.qrPath = string.IsNullOrEmpty(this.qrPath) ? null : this.qrPath;
            if (!string.IsNullOrEmpty(qrPath))
            {
                if (this.fileUtility.IsFileExists(qrPath))
                {
                    string imageName = Path.GetFileNameWithoutExtension(this.qrPath);
                    string extension = Path.GetExtension(this.qrPath);
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string newImageName = $"{imageName}_{timestamp}{extension}";
                    string dirDoiTac = new FormApp().DOITAC_DATA;
                    this.qrPath = this.fileUtility.CopyAndRenameFile(this.qrPath, dirDoiTac, newImageName);
                }
            }
            if (this.radioButtonKhachHang.Checked)
            {
                doiTac = new KhachHang(maDoiTac, tenDoiTac, sdt, diaChi, email, nganHang, stk, qrPath);
            }
            else
            {
                doiTac = doiTac = new NhaCungCap(maDoiTac, tenDoiTac, sdt, diaChi, email, nganHang, stk, qrPath);
            }
            return doiTac;
        }
        private void dataGridViewShowDoiTac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string maDoiTac = this.dataGridViewShowDoiTac.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DoiTac doiTacSelect = this.doiTacService.findByMaDoiTac(maDoiTac);
                    this.txtMaDoiTac.Text = doiTacSelect.MaDoiTac;
                    this.txtTenDoiTac.Text = doiTacSelect.Ten;
                    this.txtSoDienThoai.Text = doiTacSelect.SoDienThoai;
                    this.txtDiaChi.Text = doiTacSelect.DiaChi;
                    this.txtEmail.Text = doiTacSelect.Email;
                    this.comboBoxNganHang.Text = doiTacSelect.NganHang;
                    this.txtSoTK.Text = doiTacSelect.SoTaiKhoan;
                    if (!string.IsNullOrEmpty(doiTacSelect.QR))
                    {
                        this.pictureBoxImageQR.Image = Image.FromFile(doiTacSelect.QR);
                    }
                    else
                    {
                        this.pictureBoxImageQR.Image = null;
                    }
                }
            }
            catch
            {
                return;
            }
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

        private void radioButtonKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonKhachHang.Checked)
            {
                this.ShowDanhSachKhachHang();
                this.resetFrom();
            }
        }

        private void radioButtonNhaCungCap_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonNhaCungCap.Checked)
            {
                this.ShowDanhSachNhaCungCap();
                this.resetFrom();
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = this.txtTimKiem.Text.Trim();
            if (this.radioButtonKhachHang.Checked)
            {
                List<KhachHang> khachHangs = doiTacService.searchKhachHangByKey(key);
                this.dataGridViewShowDoiTac.Rows.Clear();
                foreach (KhachHang khachHang in khachHangs)
                {
                    this.dataGridViewShowDoiTac.Rows.Add(
                                                          khachHang.MaDoiTac, khachHang.Ten
                                                          , khachHang.SoDienThoai, khachHang.DiaChi);
                }
            }
            else
            {
                List<NhaCungCap> nhaCungCaps = doiTacService.searchNhaCungCapByKey(key);
                this.dataGridViewShowDoiTac.Rows.Clear();
                foreach (NhaCungCap nhaCungCap in nhaCungCaps)
                {
                    this.dataGridViewShowDoiTac.Rows.Add(
                                                          nhaCungCap.MaDoiTac, nhaCungCap.Ten
                                                          , nhaCungCap.SoDienThoai, nhaCungCap.DiaChi);
                }
            }
        }
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBoxImageQR.Image = Image.FromFile(openFileDialog.FileName);
                    this.qrPath = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetFrom();
        }

        private void btnThemDoiTac_Click(object sender, EventArgs e)
        {
            DoiTac doiTacNew = this.CreateDoiTacToInput();
            if (doiTacNew != null)
            {
                if (this.doiTacService.insertDoiTac(doiTacNew))
                {
                    MessageBox.Show("Đối tác đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.resetFrom();
                }
            }
            else
            {
                MessageBox.Show("Bạn cần cung cấp đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateDoiTac_Click(object sender, EventArgs e)
        {
            DoiTac doiTacUpdate = this.CreateDoiTacToInput();
            if (doiTacUpdate != null)
            {
                if (this.doiTacService.updateDoiTac(doiTacUpdate))
                {
                    MessageBox.Show("Đối tác đã được chỉnh sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.qrPath = string.Empty;
                    if (this.radioButtonKhachHang.Checked)
                    {
                        this.ShowDanhSachKhachHang();
                    }
                    else
                    {
                        this.ShowDanhSachNhaCungCap();
                    }
                }
                else
                {
                    MessageBox.Show("Đối tác đã được chỉnh sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.fileUtility.DeleteFile(doiTacUpdate.QR);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần cung cấp đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDoiTac_Click(object sender, EventArgs e)
        {
            DoiTac doiTacDelete = this.CreateDoiTacToInput();
            if (doiTacDelete != null)
            {
                if (this.doiTacService.deleteDoiTac(doiTacDelete))
                {
                    MessageBox.Show("Đối tác đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.radioButtonKhachHang.Checked)
                    {
                        this.ShowDanhSachKhachHang();
                    }
                    else
                    {
                        this.ShowDanhSachNhaCungCap();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần cung cấp đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

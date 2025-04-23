using QuanLyCuaHangVatLieuXayDung.model;
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
    public partial class Form_NhanVien : Form
    {
        NhanVienService nhanVienService = new NhanVienService();
        ChamCongService chamCongService = new ChamCongService();
        private StringUtility stringUtility = new StringUtility();
        public Form_NhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
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

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTinNhanVien())
                return;
            NhanVien nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                Ten = txtTenNhanVien.Text,
                SoDienThoai = txtSoDienThoai.Text,
                DiaChi = txtDiaChi.Text,
                VaiTro = comboBoxVaiTro.Text,
                Email = txtEmail.Text,
                LuongTrenNgay = double.TryParse(txtLuongTrenNgay.Text, out double luong) ? luong : 0
            };

            if (nhanVienService.insertnhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnRefresh_Click(sender, e);
        }

        private void btnUpdateNhanVien_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTinNhanVien())
                return;
            NhanVien nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                Ten = txtTenNhanVien.Text,
                SoDienThoai = txtSoDienThoai.Text,
                DiaChi = txtDiaChi.Text,
                VaiTro = comboBoxVaiTro.Text,
                Email = txtEmail.Text,
                LuongTrenNgay = double.TryParse(txtLuongTrenNgay.Text, out double luong) ? luong : 0
            };

            if (nhanVienService.updatenhanVien(nv))
            {
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnRefresh_Click(sender, e);
        }

        private void btnDeleteNhanVien_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text;

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (nhanVienService.deletenhanVien(maNV))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            btnRefresh_Click(sender, e);
        }
        private void LoadNhanVien()
        {
            // Bật tự sinh cột nếu chưa khai báo cột tay
            dataGridViewShowNhanVien.AutoGenerateColumns = true;

            List<NhanVien> list = nhanVienService.findAllNhanVien();
            // dataGridViewShowNhanVien.DataSource = null;
            dataGridViewShowNhanVien.DataSource = list;

            // Cập nhật trạng thái checkbox (nếu bạn có thêm tay cột ChonChamCong)
            foreach (DataGridViewRow row in dataGridViewShowNhanVien.Rows)
            {
                if (!row.IsNewRow)
                {
                    string maNV = row.Cells["MaNhanVien"].Value?.ToString();
                    if (!string.IsNullOrEmpty(maNV))
                    {
                        bool daChamCong = chamCongService.DaChamCongHomNay(maNV);
                        row.Cells["ChonChamCong"].Value = daChamCong;
                        row.Cells["ChonChamCong"].ReadOnly = daChamCong;
                    }
                }
            }
        }




        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var results = nhanVienService.findAllNhanVien()
                .Where(nv => nv.MaNhanVien.ToLower().Contains(keyword) || nv.Ten.ToLower().Contains(keyword))
                .ToList();

            dataGridViewShowNhanVien.DataSource = results;
        }

        private void dataGridViewShowNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewShowNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewShowNhanVien.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNhanVien.Text = row.Cells["Ten"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                comboBoxVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtLuongTrenNgay.Text = row.Cells["LuongTrenNgay"].Value.ToString();
                CapNhatThongTinChamCong(txtMaNhanVien.Text);
            }
        }
        private void ClearFields()
        {
            txtMaNhanVien.Text = TaoMaNhanVienTuDong();
            txtTenNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            comboBoxVaiTro.SelectedIndex = -1;
            txtEmail.Clear();
            txtLuongTrenNgay.Clear();
            labelSoNgayDiLam.Text = "Số ngày nhân viên đã làm: " ;
            labelSoNgayNghi.Text = "Số ngày nhân viên nghỉ: " ;
            labelTongSoTienLuongDaNhan.Text = "Tổng lương nhân viên được nhận: ";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadNhanVien();
        }

        private void Form_NhanVien_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadNhanVien();
        }

        private void dataGridViewShowNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewShowNhanVien.SelectedRows.Count > 0)
            {
                string maNV = dataGridViewShowNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();
                txtMaNhanVien.Text = maNV;
                CapNhatThongTinChamCong(maNV);
            }
        }

        
        private void CapNhatThongTinChamCong(string maNV)
        {
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            int soNgayLam = chamCongService.GetSoNgayCong(maNV);
            int soNgayNghi = chamCongService.TinhSoNgayNghi(maNV, thang, nam);
            double tongLuong = chamCongService.TinhLuongTheoNam(maNV, nam);

            labelSoNgayDiLam.Text = "Số ngày nhân viên đã làm: " + soNgayLam.ToString();
            labelSoNgayNghi.Text = "Số ngày nhân viên nghỉ: " + soNgayNghi.ToString();
            labelTongSoTienLuongDaNhan.Text = "Tổng lương nhân viên được nhận: " + tongLuong.ToString("N0") + " VND";
        }
        private string TaoMaNhanVienTuDong()
        {
            string maNhanVien = this.stringUtility.GenerateRandomString(10);
            while (this.nhanVienService.FindByMaNhanVien(maNhanVien) != null)
            {
                maNhanVien = this.stringUtility.GenerateRandomString(10);
            }
            return maNhanVien;
        }

        private void dataGridViewShowNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewShowNhanVien.Columns[e.ColumnIndex].Name == "ChonChamCong" && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridViewShowNhanVien.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string maNV = dataGridViewShowNhanVien.Rows[e.RowIndex].Cells["MaNhanVien"].Value?.ToString();

                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Không tìm được mã nhân viên!");
                    return;
                }

                bool daChamCong = chamCongService.DaChamCongHomNay(maNV);

                if (daChamCong)
                {
                    DialogResult result = MessageBox.Show("Nhân viên đã được chấm công hôm nay.\nBạn có muốn xóa chấm công?",
                                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        bool xoaThanhCong = chamCongService.XoaChamCongHomNay(maNV);
                        if (xoaThanhCong)
                        {
                            MessageBox.Show("Đã xóa chấm công!");
                            checkBoxCell.Value = false;
                            checkBoxCell.ReadOnly = false;
                            CapNhatThongTinChamCong(maNV);
                        }
                        else
                        {
                            MessageBox.Show("Xóa chấm công thất bại!");
                            checkBoxCell.Value = true;
                        }
                    }
                    else
                    {
                        checkBoxCell.Value = true; // Giữ nguyên tick
                    }

                    return;
                }

                // Nếu chưa chấm công → xử lý tick để chấm công
                bool isChecked = (checkBoxCell.Value == null ? false : (bool)checkBoxCell.Value);

                if (!isChecked) // tránh double click gây bỏ check trước khi xử lý
                {
                    checkBoxCell.Value = true; // giả định tick
                    bool chamCongThanhCong = chamCongService.ChamCong(maNV);
                    if (chamCongThanhCong)
                    {
                        MessageBox.Show("Chấm công thành công!");
                        checkBoxCell.ReadOnly = true;
                        CapNhatThongTinChamCong(maNV);
                    }
                    else
                    {
                        MessageBox.Show("Chấm công thất bại!");
                        checkBoxCell.Value = false;
                    }
                }
            }
        }

        private bool KiemTraThongTinNhanVien()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                string.IsNullOrWhiteSpace(txtTenNhanVien.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(comboBoxVaiTro.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtLuongTrenNgay.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtLuongTrenNgay.Text, out _))
            {
                MessageBox.Show("Lương trên ngày không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


    }
}

using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangVatLieuXayDung.model;
using System.Drawing.Printing;


namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_LichSuGiaoDich : Form
    {
        private readonly IHoaDonService hoaDonService = new HoaDonService();
        private HoaDon selectedHoaDon; // Biến lưu hóa đơn được chọn để in
        private int currentRowIndex;
        public Form_LichSuGiaoDich()
        {
            InitializeComponent();
            dataGridViewShowHoaDon.AutoGenerateColumns = false;
            dataGridViewShowHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShowHoaDon.MultiSelect = false;
            dataGridViewShowHoaDon.CellClick += new DataGridViewCellEventHandler(dataGridViewShowHoaDon_CellClick);
            dataGridViewShowVatLieu.AutoGenerateColumns = false;
        }

        private void Form_LichSuGiaoDich_Load(object sender, EventArgs e)
        {
            LoadHoaDonData();
            panelHoaDon.Visible = false;
        }

        private void LoadHoaDonData(List<HoaDon> hoaDons = null)
        {
            try
            {
                if (hoaDons == null)
                {
                    hoaDons = hoaDonService.findAll();
                }

                dataGridViewShowHoaDon.Rows.Clear();

                foreach (var hoaDon in hoaDons)
                {
                    dataGridViewShowHoaDon.Rows.Add(
                        hoaDon.MaHoaDon,
                        hoaDon.ThoiGianLap.ToString("dd/MM/yyyy HH:mm"),
                        hoaDon.phuongThucThanhToan_toString(),
                        hoaDon.TienThanhToan.ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewShowHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string maHoaDon = dataGridViewShowHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value?.ToString();
                    if (string.IsNullOrEmpty(maHoaDon))
                    {
                        MessageBox.Show("Mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    HoaDon hoaDon = hoaDonService.findByMaHoaDon(maHoaDon);
                    selectedHoaDon = hoaDonService.findByMaHoaDon(maHoaDon);
                    if (hoaDon != null)
                    {
                        panelHoaDon.Visible = true;
                        txtMaHoaDon.Text = hoaDon.MaHoaDon;
                        txtThoiGian.Text = hoaDon.ThoiGianLap.ToString("dd/MM/yyyy HH:mm");
                        txtNameDoiTac.Text = hoaDon.DoiTac?.Ten ?? string.Empty;
                        txtSDT.Text = hoaDon.DoiTac?.SoDienThoai ?? string.Empty;
                        txtAddress.Text = hoaDon.DoiTac?.DiaChi ?? string.Empty;
                        comboBoxPhuongThucThanhToan.SelectedItem = hoaDon.phuongThucThanhToan_toString();
                        txtTienThanhToan.Text = hoaDon.TienThanhToan.ToString("N0");
                        txtTienGiam.Text = hoaDon.TienGiam.ToString("N0");
                        labelNoCu.Text = $"Nợ cũ: {(hoaDon.tinhTongTien() - hoaDon.TienThanhToan):N0}";
                        labelTongHoaDon.Text = $"Tổng hóa đơn: {hoaDon.tinhTongTien():N0}";
                        labelTienThanhToan.Text = $"Tiền thanh toán: {hoaDon.TienThanhToan:N0}";

                        // Load danh sách vật liệu vào dataGridViewShowVatLieu
                        dataGridViewShowVatLieu.Rows.Clear();
                        if (hoaDon.ChiTiets != null && hoaDon.ChiTiets.Any())
                        {
                            int stt = 1;
                            foreach (var chiTiet in hoaDon.ChiTiets)
                            {
                                double tongTien = chiTiet.VatLieu.GiaXuat * chiTiet.SoLuong;
                                dataGridViewShowVatLieu.Rows.Add(
                                    stt,
                                    chiTiet.VatLieu.MaVatLieu,
                                    chiTiet.VatLieu.Ten,
                                    chiTiet.VatLieu.GiaXuat.ToString("N0"),
                                    chiTiet.VatLieu.DonVi,
                                    chiTiet.SoLuong,
                                    tongTien.ToString("N0")
                                );
                                stt++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị thông tin hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radioButtonXuatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonXuatHang.Checked)
            {
                LoadHoaDonData(hoaDonService.findByLoaiHoaDon(2));
            }
        }

        private void radioButtonNhapHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNhapHang.Checked)
            {
                LoadHoaDonData(hoaDonService.findByLoaiHoaDon(1));
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadHoaDonData();
                    return;
                }

                List<HoaDon> hoaDons = hoaDonService.searchByKey(searchText);
                LoadHoaDonData(hoaDons);

                if (hoaDons == null || !hoaDons.Any())
                {
                    MessageBox.Show("Không tìm thấy hóa đơn khớp với từ khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                panelHoaDon.Visible = false;
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHoaDonData();
            panelHoaDon.Visible = false;
            ClearInputFields();
            radioButtonXuatHang.Checked = false;
            radioButtonNhapHang.Checked = false;
            txtTimKiem.Text = string.Empty;
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            panelHoaDon.Visible = false;
            ClearInputFields();
        }
        private void ClearInputFields()
        {
            txtMaHoaDon.Text = string.Empty;
            txtThoiGian.Text = string.Empty;
            txtNameDoiTac.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtAddress.Text = string.Empty;
            comboBoxPhuongThucThanhToan.SelectedIndex = -1;
            txtTienThanhToan.Text = string.Empty;
            txtTienGiam.Text = string.Empty;
            labelNoCu.Text = "Nợ cũ: ";
            labelTongHoaDon.Text = "Tổng hóa đơn: ";
            labelTienThanhToan.Text = "Tiền thanh toán: ";
            dataGridViewShowVatLieu.Rows.Clear();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string maHoaDon = this.txtMaHoaDon.Text;
            if (!string.IsNullOrEmpty(maHoaDon))
            {
                HoaDon hoaDon = this.hoaDonService.findByMaHoaDon(maHoaDon);
                Form_ReportHoaDon form_ReportHoaDon = new Form_ReportHoaDon();
                form_ReportHoaDon.HoaDon = hoaDon;
                form_ReportHoaDon.ShowDialog(); 
            }

        }

    }
}

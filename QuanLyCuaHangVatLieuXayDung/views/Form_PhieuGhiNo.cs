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
using Microsoft.Reporting.WinForms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_PhieuGhiNo : Form
    {
        private readonly IPhieuGhiNoService phieuGhiNoService = new PhieuGhiNoService();
        public Form_PhieuGhiNo()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form_PhieuGhiNo_Load);
            dataGridViewShowPhieuNo.AutoGenerateColumns = false;
            dataGridViewShowPhieuNo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShowPhieuNo.MultiSelect = false;
            dataGridViewShowPhieuNo.CellClick += new DataGridViewCellEventHandler(dataGridViewShowPhieuNo_CellClick);
        }

        private void Form_PhieuGhiNo_Load(object sender, EventArgs e)
        {
            LoadPhieuGhiNoData();
        }

        private void LoadPhieuGhiNoData(List<PhieuGhiNo> phieuGhiNos = null)
        {
            try
            {
                // Nếu không truyền danh sách, lấy toàn bộ dữ liệu
                if (phieuGhiNos == null)
                {
                    phieuGhiNos = phieuGhiNoService.findAll();
                }
                // Xóa các hàng hiện tại trong DataGridView
                dataGridViewShowPhieuNo.Rows.Clear();

                // Thêm dữ liệu vào các cột đã thiết kế sẵn
                foreach (var phieu in phieuGhiNos)
                {
                    dataGridViewShowPhieuNo.Rows.Add(
                        phieu.MaPhieu, // Mã phiếu
                        phieu is PhieuNoKhachHang khachHang ? khachHang.KhachHang?.Ten ?? string.Empty
                            : phieu is PhieuNoCuaHang cuaHang ? cuaHang.NhaCungCap?.Ten ?? string.Empty : string.Empty, // Tên đối tác
                        phieu is PhieuNoKhachHang kh ? kh.KhachHang?.SoDienThoai ?? string.Empty
                            : phieu is PhieuNoCuaHang ch ? ch.NhaCungCap?.SoDienThoai ?? string.Empty : string.Empty, // Số điện thoại
                        phieu is PhieuNoKhachHang kh1 ? kh1.KhachHang?.DiaChi ?? string.Empty
                            : phieu is PhieuNoCuaHang ch1 ? ch1.NhaCungCap?.DiaChi ?? string.Empty : string.Empty, // Địa chỉ
                        phieu.ThoiGianLap.ToString("dd/MM/yyyy HH:mm"), // Thời gian lập
                        phieu.ThoiGianTra.ToString("dd/MM/yyyy HH:mm"), // Thời gian trả
                        phieu.TienNo.ToString("N0"), // Tiền nợ
                        phieu.TrangThai ? "Đã trả" : "Chưa trả" // Trạng thái
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu ghi nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButtonKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKhachHang.Checked)
            {
                LoadPhieuGhiNoData(phieuGhiNoService.findByLoaiPhieu(1));
            }
        }

        private void radioButtonNoCuaHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNoCuaHang.Checked)
            {
                LoadPhieuGhiNoData(phieuGhiNoService.findByLoaiPhieu(2));
            }
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            panelPhieuGhiNo.Visible = false;
        }

        PhieuGhiNo selectedPhieuGhiNo = null;
        private void dataGridViewShowPhieuNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy mã phiếu từ cột MaPhieuGhiNo
                    string maPhieu = dataGridViewShowPhieuNo.Rows[e.RowIndex].Cells["MaPhieuGhiNo"].Value?.ToString();
                    if (string.IsNullOrEmpty(maPhieu))
                    {
                        MessageBox.Show("Mã phiếu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PhieuGhiNo phieu = phieuGhiNoService.findByMaPhieu(maPhieu);
                    selectedPhieuGhiNo=phieu;
                    if (phieu != null)
                    {
                        // Hiển thị panelPhieuGhiNo
                        panelPhieuGhiNo.Visible = true;

                        // Điền thông tin vào các TextBox
                        textBox1.Text = phieu.MaPhieu;
                        txtThoiGianLap.Text = phieu.ThoiGianLap.ToString("dd/MM/yyyy HH:mm");
                        txtThoiGianTra.Text = phieu.ThoiGianTra.ToString("dd/MM/yyyy HH:mm");
                        txtSoTienNo.Text = phieu.TienNo.ToString("N0");
                        txtTrangThai.Text = phieu.TrangThai ? "Đã trả" : "Chưa trả";

                        btnTra.Enabled = !phieu.TrangThai; // Bật nếu chưa trả, tắt nếu đã trả

                        if (phieu is PhieuNoKhachHang khachHang && khachHang.KhachHang != null)
                        {
                            txtDoiTac.Text = khachHang.KhachHang.Ten;
                            textBox2.Text = khachHang.KhachHang.SoDienThoai;
                            txtDiaChi.Text = khachHang.KhachHang.DiaChi;
                            txtMaHoaDon.Text = phieu.MaHoaDon;
                        }
                        else if (phieu is PhieuNoCuaHang cuaHang && cuaHang.NhaCungCap != null)
                        {
                            txtDoiTac.Text = cuaHang.NhaCungCap.Ten;
                            textBox2.Text = cuaHang.NhaCungCap.SoDienThoai;
                            txtDiaChi.Text = cuaHang.NhaCungCap.DiaChi;
                            txtMaHoaDon.Text = cuaHang.HoaDonNhap?.MaHoaDon ?? "Hiếu đẹp trai";
                        }
                        else
                        {
                            txtDoiTac.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            txtDiaChi.Text = string.Empty;
                            txtMaHoaDon.Text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin phiếu ghi nợ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnTra.Enabled = false; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị thông tin phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnTra.Enabled = false; 
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPhieuGhiNoData();

            textBox1.Text = string.Empty;
            txtDoiTac.Text = string.Empty;
            textBox2.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMaHoaDon.Text = string.Empty;
            txtThoiGianLap.Text = string.Empty;
            txtThoiGianTra.Text = string.Empty;
            txtSoTienNo.Text = string.Empty;
            txtTrangThai.Text = string.Empty;

            radioButtonKhachHang.Checked = false;
            radioButtonNoCuaHang.Checked = false;

            txtTimKiem.Text = string.Empty;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            try
            {
                // Kiểm tra từ khóa tìm kiếm
                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadPhieuGhiNoData(); // Tải lại toàn bộ dữ liệu nếu từ khóa rỗng
                    return;
                }

                // Tìm kiếm phiếu ghi nợ theo từ khóa
                List<PhieuGhiNo> phieuGhiNos = phieuGhiNoService.searchByKey(searchText);

                // Tải dữ liệu tìm kiếm vào DataGridView
                LoadPhieuGhiNoData(phieuGhiNos);

                // Nếu không tìm thấy kết quả
                if (phieuGhiNos == null || !phieuGhiNos.Any())
                {
                    MessageBox.Show("Không tìm thấy phiếu ghi nợ khớp với từ khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Ẩn panelPhieuGhiNo và xóa nội dung TextBox để giữ giao diện sạch
                panelPhieuGhiNo.Visible = false;
                textBox1.Text = string.Empty;
                txtDoiTac.Text = string.Empty;
                textBox2.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtMaHoaDon.Text = string.Empty;
                txtThoiGianLap.Text = string.Empty;
                txtThoiGianTra.Text = string.Empty;
                txtSoTienNo.Text = string.Empty;
                txtTrangThai.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm phiếu ghi nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(maPhieu))
                {
                    MessageBox.Show("Vui lòng chọn một phiếu ghi nợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PhieuGhiNo phieu = phieuGhiNoService.findByMaPhieu(maPhieu);
                if (phieu == null)
                {
                    MessageBox.Show("Phiếu ghi nợ không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra trạng thái
                if (phieu.TrangThai)
                {
                    MessageBox.Show("Phiếu ghi nợ đã được trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở form Biên Lai Trả Nợ
                using (Form_BienLaiTraNoSingle formBienLai = new Form_BienLaiTraNoSingle(phieu))
                {
                    if (formBienLai.ShowDialog() == DialogResult.OK)
                    {
                        // Tải lại danh sách và đặt lại giao diện
                        LoadPhieuGhiNoData();
                        panelPhieuGhiNo.Visible = false;
                        textBox1.Text = string.Empty;
                        txtDoiTac.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        txtDiaChi.Text = string.Empty;
                        txtMaHoaDon.Text = string.Empty;
                        txtThoiGianLap.Text = string.Empty;
                        txtThoiGianTra.Text = string.Empty;
                        txtSoTienNo.Text = string.Empty;
                        txtTrangThai.Text = string.Empty;
                        btnTra.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (selectedPhieuGhiNo == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu ghi nợ để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo form mới để hiển thị báo cáo
                Form reportForm = new Form
                {
                    Text = "Xem trước phiếu ghi nợ",
                    Size = new System.Drawing.Size(800, 600),
                    StartPosition = FormStartPosition.CenterScreen
                };

                ReportViewer reportViewer = new ReportViewer
                {
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0)
                };
                reportForm.Controls.Add(reportViewer);

                // Thiết lập báo cáo
                reportViewer.LocalReport.ReportEmbeddedResource = "QuanLyCuaHangVatLieuXayDung.views.report.Report_PhieuGhiNo.rdlc";
                MessageBox.Show($"Report path: {reportViewer.LocalReport.ReportEmbeddedResource}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportViewer.LocalReport.DataSources.Clear();

                // Chuẩn bị dữ liệu cho báo cáo
                var reportData = new List<PhieuGhiNoReportData>
        {
            new PhieuGhiNoReportData
            {
                MaPhieu = selectedPhieuGhiNo.MaPhieu ?? "N/A",
                ThoiGianLap = selectedPhieuGhiNo.ThoiGianLap,
                ThoiGianTra = selectedPhieuGhiNo.ThoiGianTra,
                TienNo = selectedPhieuGhiNo.TienNo,
                TrangThai = selectedPhieuGhiNo.TrangThai,
                MaHoaDon = selectedPhieuGhiNo is PhieuNoKhachHang khachHang ? khachHang.HoaDonXuat?.MaHoaDon ?? "Không có hóa đơn" : selectedPhieuGhiNo is PhieuNoCuaHang cuaHang ? cuaHang.HoaDonNhap?.MaHoaDon ?? "Không có hóa đơn" : "Không có hóa đơn",
                TenDoiTac = selectedPhieuGhiNo is PhieuNoKhachHang kh ? kh.KhachHang?.Ten ?? "N/A" : selectedPhieuGhiNo is PhieuNoCuaHang ch ? ch.NhaCungCap?.Ten ?? "N/A" : "N/A",
                SoDienThoai = selectedPhieuGhiNo is PhieuNoKhachHang kh1 ? kh1.KhachHang?.SoDienThoai ?? "N/A" : selectedPhieuGhiNo is PhieuNoCuaHang ch1 ? ch1.NhaCungCap?.SoDienThoai ?? "N/A" : "N/A",
                DiaChi = selectedPhieuGhiNo is PhieuNoKhachHang kh2 ? kh2.KhachHang?.DiaChi ?? "N/A" : selectedPhieuGhiNo is PhieuNoCuaHang ch2 ? ch2.NhaCungCap?.DiaChi ?? "N/A" : "N/A"
            }
        };

                // Debug dữ liệu
                MessageBox.Show($"Loaded {reportData.Count} record(s)\nMaPhieu: {reportData[0].MaPhieu}\nThoiGianLap: {reportData[0].ThoiGianLap}\nMaHoaDon: {reportData[0].MaHoaDon}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("PhieuGhiNoData", reportData));
                reportViewer.RefreshReport();

                // Hiển thị form báo cáo
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in phiếu ghi nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class PhieuGhiNoReportData
        {
            public string MaPhieu { get; set; }
            public string MaHoaDon { get; set; }
            public DateTime ThoiGianLap { get; set; }
            public DateTime ThoiGianTra { get; set; }
            public double TienNo { get; set; }
            public bool TrangThai { get; set; }
            public string TenDoiTac { get; set; }
            public string SoDienThoai { get; set; }
            public string DiaChi { get; set; }
        }
    }
}

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

                if (hoaDons == null || !hoaDons.Any())
                {
                    dataGridViewShowHoaDon.Rows.Clear();
                    MessageBox.Show("Không có dữ liệu hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
            if (selectedHoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintHoaDon);

            // Hiển thị cửa sổ xem trước
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();

        }

        private void PrintHoaDon(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 50; // Vị trí Y bắt đầu
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            float pageWidth = e.MarginBounds.Width;

            // Font chữ cho tiêu đề và nội dung
            Font titleFont = new Font("Times New Roman", 16, FontStyle.Bold);
            Font contentFont = new Font("Times New Roman", 12);
            Font boldFont = new Font("Times New Roman", 12, FontStyle.Bold);

            // Tiêu đề hóa đơn
            string title = "HÓA ĐƠN GIAO DỊCH";
            float titleWidth = g.MeasureString(title, titleFont).Width;
            g.DrawString(title, titleFont, Brushes.Black, (pageWidth - titleWidth) / 2 + leftMargin, yPos);
            yPos += 40;

            // Thông tin hóa đơn
            g.DrawString($"Mã hóa đơn: {selectedHoaDon.MaHoaDon}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString($"Thời gian lập: {selectedHoaDon.ThoiGianLap:dd/MM/yyyy HH:mm}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString($"Phương thức thanh toán: {selectedHoaDon.phuongThucThanhToan_toString()}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString($"Số tiền thanh toán: {selectedHoaDon.TienThanhToan:N0}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Thông tin đối tác
            g.DrawString("Thông tin đối tác", boldFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString($"Tên: {selectedHoaDon.DoiTac?.Ten ?? "N/A"}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString($"Số điện thoại: {selectedHoaDon.DoiTac?.SoDienThoai ?? "N/A"}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString($"Địa chỉ: {selectedHoaDon.DoiTac?.DiaChi ?? "N/A"}", contentFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Tiêu đề bảng danh sách vật liệu
            g.DrawString("Danh sách vật liệu", boldFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            // Vẽ tiêu đề cột
            float[] columnWidths = { 50, 100, 150, 100, 100, 100, 100 }; // Độ rộng các cột
            string[] headers = { "STT", "Mã VL", "Tên vật liệu", "Giá xuất", "Đơn vị", "Số lượng", "Tổng tiền" };
            float xPos = leftMargin;
            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], boldFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[i];
            }
            yPos += 30;

            // Vẽ đường kẻ ngang dưới tiêu đề
            g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 5;

            // In danh sách vật liệu
            bool hasMorePages = false;
            if (selectedHoaDon.ChiTiets != null && selectedHoaDon.ChiTiets.Any())
            {
                int rowsPerPage = 20; // Số hàng tối đa mỗi trang
                int startIndex = currentRowIndex;
                int endIndex = Math.Min(startIndex + rowsPerPage, selectedHoaDon.ChiTiets.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    var chiTiet = selectedHoaDon.ChiTiets[i];
                    double tongTien = chiTiet.VatLieu.GiaXuat * chiTiet.SoLuong;
                    xPos = leftMargin;

                    // In từng cột
                    g.DrawString((i + 1).ToString(), contentFont, Brushes.Black, xPos, yPos);
                    xPos += columnWidths[0];
                    g.DrawString(chiTiet.VatLieu.MaVatLieu, contentFont, Brushes.Black, xPos, yPos);
                    xPos += columnWidths[1];
                    g.DrawString(chiTiet.VatLieu.Ten, contentFont, Brushes.Black, xPos, yPos);
                    xPos += columnWidths[2];
                    g.DrawString(chiTiet.VatLieu.GiaXuat.ToString("N0"), contentFont, Brushes.Black, xPos, yPos);
                    xPos += columnWidths[3];
                    g.DrawString(chiTiet.VatLieu.DonVi, contentFont, Brushes.Black, xPos, yPos);
                    xPos += columnWidths[4];
                    g.DrawString(chiTiet.SoLuong.ToString(), contentFont, Brushes.Black, xPos, yPos);
                    xPos += columnWidths[5];
                    g.DrawString(tongTien.ToString("N0"), contentFont, Brushes.Black, xPos, yPos);

                    yPos += 25;

                    // Kiểm tra nếu vượt quá trang
                    if (yPos > e.MarginBounds.Bottom - 100)
                    {
                        currentRowIndex = i + 1;
                        hasMorePages = currentRowIndex < selectedHoaDon.ChiTiets.Count;
                        break;
                    }
                }
            }

            // Nếu không còn hàng để in, hiển thị tổng hợp
            if (!hasMorePages)
            {
                yPos += 20;
                g.DrawString($"Tiền giảm: {selectedHoaDon.TienGiam:N0}", contentFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                g.DrawString($"Tổng hóa đơn: {selectedHoaDon.tinhTongTien():N0}", contentFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                g.DrawString($"Tiền thanh toán: {selectedHoaDon.TienThanhToan:N0}", contentFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                g.DrawString($"Nợ cũ: {(selectedHoaDon.tinhTongTien() - selectedHoaDon.TienThanhToan):N0}", contentFont, Brushes.Black, leftMargin, yPos);
            }

            e.HasMorePages = hasMorePages; // Xác định nếu cần in trang tiếp theo
        }
    }
}

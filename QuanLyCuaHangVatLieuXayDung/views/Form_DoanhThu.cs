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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_DoanhThu : Form
    {
        private readonly IDoanhThuService doanhThuService = new DoanhThuService();

        public Form_DoanhThu()
        {
            InitializeComponent();

            // Thêm các tùy chọn vào ComboBox
            comboBoxLocThoiGian.Items.AddRange(new string[] { "Hôm nay", "Tuần này", "Tháng này", "Năm này" });
            comboBoxLocThoiGian.SelectedIndex = 0;

            // Thêm các tùy chọn cho ComboBox loại biểu đồ
            comboBoxLoaiBieuDo.Items.AddRange(new string[] { "Ngày", "Tháng", "Năm" });
            comboBoxLoaiBieuDo.SelectedIndex = 0;

            // Đặt ngày mặc định cho DateTimePicker
            dtpTuNgay.Value = DateTime.Now.Date;
            dtpDenNgay.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
        }
        private void comboBoxLocThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            switch (comboBoxLocThoiGian.SelectedItem.ToString())
            {
                case "Hôm nay":
                    dtpTuNgay.Value = today;
                    dtpDenNgay.Value = today.AddDays(1).AddSeconds(-1);
                    break;
                case "Tuần này":
                    dtpTuNgay.Value = today.AddDays(-(int)today.DayOfWeek);
                    dtpDenNgay.Value = dtpTuNgay.Value.AddDays(7).AddSeconds(-1);
                    break;
                case "Tháng này":
                    dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
                    dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddSeconds(-1);
                    break;
                case "Năm này":
                    dtpTuNgay.Value = new DateTime(today.Year, 1, 1);
                    dtpDenNgay.Value = new DateTime(today.Year, 12, 31).AddDays(1).AddSeconds(-1);
                    break;
            }
        }
        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính tổng doanh thu và tổng tiền thanh toán
                decimal tongDoanhThu = 0;
                decimal tongTienThanhToan = 0;
                var doanhThuTheoThoiGian = doanhThuService.TinhDoanhThuTheoKhoangThoiGian(tuNgay, denNgay, comboBoxLoaiBieuDo.SelectedItem.ToString());

                foreach (var doanhThu in doanhThuTheoThoiGian.Values)
                {
                    tongTienThanhToan += doanhThu;
                    tongDoanhThu += doanhThu; // Logic doanh thu cần xem xét lại nếu có thêm yếu tố khác
                }

                // Hiển thị tổng quan
                lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0}";
                lblTongTienThanhToan.Text = $"Tổng tiền đã thanh toán: {tongTienThanhToan:N0}";

                // Vẽ biểu đồ doanh thu
                VeBieuDoDoanhThu(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VeBieuDoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string loaiThoiGian = comboBoxLoaiBieuDo.SelectedItem.ToString();
                var doanhThuTheoThoiGian = doanhThuService.TinhDoanhThuTheoKhoangThoiGian(tuNgay, denNgay, loaiThoiGian);

                // Debug dữ liệu trả về
                StringBuilder debugMessage = new StringBuilder();
                debugMessage.AppendLine($"Số lượng dữ liệu: {doanhThuTheoThoiGian.Count}");
                debugMessage.AppendLine($"Thời gian đầu: {tuNgay:dd/MM/yyyy}");
                debugMessage.AppendLine($"Thời gian cuối: {denNgay:dd/MM/yyyy}");
                foreach (var kvp in doanhThuTheoThoiGian)
                {
                    debugMessage.AppendLine($"Thời gian: {kvp.Key:dd/MM/yyyy}, Doanh thu: {kvp.Value:N0}");
                }
                MessageBox.Show(debugMessage.ToString(), "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kiểm tra dữ liệu trả về
                if (doanhThuTheoThoiGian == null || doanhThuTheoThoiGian.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xóa dữ liệu cũ trong biểu đồ
                chartDoanhThu.Series.Clear();
                chartDoanhThu.ChartAreas.Clear();

                // Tạo ChartArea
                ChartArea chartArea = new ChartArea();
                chartArea.Name = "ChartAreaDoanhThu";
                chartDoanhThu.ChartAreas.Add(chartArea);

                // Tạo Series
                Series series = new Series("DoanhThu");
                series.ChartType = SeriesChartType.Column; // Biểu đồ cột
                series.XValueType = ChartValueType.DateTime;
                series.YValueType = ChartValueType.Double; // Sử dụng Double
                series.Color = Color.OliveDrab; // Màu xanh olive cho cột
                series.BorderWidth = 3; // Độ dày viền cột
                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                series.LabelFormat = "N0"; // Định dạng giá trị trên cột
                series.LabelForeColor = Color.Black; // Màu chữ giá trị trên cột
                chartDoanhThu.Series.Add(series);

                // Định dạng trục X
                chartArea.AxisX.LabelStyle.Format = loaiThoiGian.ToLower() == "ngày" ? "dd/MM/yyyy" : loaiThoiGian.ToLower() == "tháng" ? "MM/yyyy" : "yyyy";
                chartArea.AxisX.IntervalType = loaiThoiGian.ToLower() == "ngày" ? DateTimeIntervalType.Days : loaiThoiGian.ToLower() == "tháng" ? DateTimeIntervalType.Months : DateTimeIntervalType.Years;
                chartArea.AxisX.Interval = loaiThoiGian.ToLower() == "tháng" && tuNgay.Month == denNgay.Month ? 0 : 1; // Hiển thị đúng khi chỉ có 1 tháng
                chartArea.AxisX.LabelStyle.Angle = -45; // Xoay nhãn trục X để tránh chồng lấn
                chartArea.AxisX.IsLabelAutoFit = true;

                // Định dạng trục Y
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.AxisY.Title = "Doanh thu (VNĐ)";
                chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

                // Định dạng trục X
                chartArea.AxisX.Title = loaiThoiGian;
                chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;

                // Điền dữ liệu vào biểu đồ
                foreach (var kvp in doanhThuTheoThoiGian)
                {
                    var point = series.Points.AddXY(kvp.Key, Convert.ToDouble(kvp.Value));
                    if (kvp.Value == 0) // Ẩn cột nếu doanh thu = 0
                    {
                        series.Points[point].IsEmpty = true;
                    }
                }

                // Định dạng biểu đồ
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Titles.Add(new Title($"Doanh thu theo {loaiThoiGian}", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));
                chartDoanhThu.BackColor = Color.WhiteSmoke;
                chartDoanhThu.BorderlineColor = Color.Gray;
                chartDoanhThu.BorderlineDashStyle = ChartDashStyle.Solid;
                chartDoanhThu.BorderlineWidth = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

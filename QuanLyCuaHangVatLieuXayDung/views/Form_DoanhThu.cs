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
using QuanLyCuaHangVatLieuXayDung.utilities;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_DoanhThu : Form
    {
        private readonly IDoanhThuService doanhThuService = new DoanhThuService();
        private StringUtility stringUitility = new StringUtility();

        public Form_DoanhThu()
        {
            InitializeComponent();
        }
        private void Form_DoanhThu_Load(object sender, EventArgs e)
        {
            // Thêm các tùy chọn vào ComboBox
            comboBoxLocThoiGian.Items.AddRange(new string[] { "Hôm nay", "Tuần này", "Tháng này", "Năm này" });
            comboBoxLocThoiGian.SelectedIndex = 0;

            // Thêm các tùy chọn cho ComboBox loại biểu đồ
            comboBoxLoaiBieuDo.Items.AddRange(new string[] { "Ngày", "Tháng", "Năm" });
            comboBoxLoaiBieuDo.SelectedIndex = 0;
            // Đặt ngày mặc định cho DateTimePicker
            dtpTuNgay.Value = DateTime.Now.Date;
            dtpDenNgay.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            // Hiển thị biểu đồ khi load form
            LoadChartOnFormLoad();
        }

        private void LoadChartOnFormLoad()
        {
            // Gọi logic hiển thị biểu đồ ngay khi load form
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
                tongDoanhThu += doanhThu;
            }

            // Hiển thị tổng quan
            lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0}";

            // Tính và hiển thị các thông tin
            int soHoaDonNhap = doanhThuService.TinhTongHoaDonNhap(tuNgay, denNgay);
            int soHoaDonXuat = doanhThuService.TinhTongHoaDonXuat(tuNgay, denNgay);
            int soBienLaiTraNo = doanhThuService.TinhSoBienLaiTraNo(tuNgay, denNgay);
            int soNoChuaTra = doanhThuService.TinhSoNoChuaTra(tuNgay, denNgay);
            decimal tongGiaTriHoaDonNhap = doanhThuService.TinhTongGiaTriHoaDonNhap(tuNgay, denNgay);
            decimal tongGiaTriHoaDonXuat = doanhThuService.TinhTongGiaTriHoaDonXuat(tuNgay, denNgay);
            decimal tongGiaTriNoChuaTra = doanhThuService.TinhTongGiaTriNoChuaTra(tuNgay, denNgay);
            decimal tongTienTraNo = doanhThuService.TinhTongTienTraNo(tuNgay, denNgay);

            labelSoHoaDonNhap.Text = $"Số hóa đơn nhập: {soHoaDonNhap}";
            labelTongTienHoaDonNhap.Text = $"Tiền nhập: {tongGiaTriHoaDonNhap:N0}";
            labelSoHoaDonXuat.Text = $"Số hóa đơn xuất: {soHoaDonXuat}";
            labelTongTienHoaDonXuat.Text = $"Tổng tiền xuất: {tongGiaTriHoaDonXuat:N0}";
            labelSoNoChuaTra.Text = $"Số nợ chưa trả: {soNoChuaTra}";
            labelTienNoChuaTra.Text = $"Tiền nợ chưa trả: {tongGiaTriNoChuaTra:N0}";
            labelSoBienLaiTraNo.Text = $"Số biên lai trả nợ: {soBienLaiTraNo}";
            labelTienNoDaTra.Text = $"Tiền nợ đã trả: {tongTienTraNo:N0}";

            // Vẽ biểu đồ doanh thu
            VeBieuDoDoanhThu(tuNgay, denNgay);
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
            LoadChartOnFormLoad();
        }
        private void VeBieuDoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string loaiThoiGian = comboBoxLoaiBieuDo.SelectedItem.ToString();
                var doanhThuXuat = doanhThuService.TinhDoanhThuTheoKhoangThoiGian(tuNgay, denNgay, loaiThoiGian);
                var doanhThuNhap = doanhThuService.TinhDoanhThuNhapTheoKhoangThoiGian(tuNgay, denNgay, loaiThoiGian);

                // Kiểm tra dữ liệu trả về
                if ((doanhThuXuat == null || doanhThuXuat.Count == 0) && (doanhThuNhap == null || doanhThuNhap.Count == 0))
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

                // Tạo Series cho doanh thu hóa đơn xuất
                Series seriesXuat = new Series("DoanhThuXuat");
                seriesXuat.ChartType = SeriesChartType.Column;
                seriesXuat.XValueType = ChartValueType.DateTime;
                seriesXuat.YValueType = ChartValueType.Double;
                seriesXuat.Color = Color.OliveDrab; // Màu xanh olive cho hóa đơn xuất
                seriesXuat.BorderWidth = 3;
                seriesXuat.IsValueShownAsLabel = true;
                seriesXuat.LabelFormat = "N0";
                seriesXuat.LabelForeColor = Color.Black;
                chartDoanhThu.Series.Add(seriesXuat);

                // Tạo Series cho doanh thu hóa đơn nhập
                Series seriesNhap = new Series("DoanhThuNhap");
                seriesNhap.ChartType = SeriesChartType.Column;
                seriesNhap.XValueType = ChartValueType.DateTime;
                seriesNhap.YValueType = ChartValueType.Double;
                seriesNhap.Color = Color.SteelBlue; // Màu xanh dương cho hóa đơn nhập
                seriesNhap.BorderWidth = 3;
                seriesNhap.IsValueShownAsLabel = true;
                seriesNhap.LabelFormat = "N0";
                seriesNhap.LabelForeColor = Color.Black;
                chartDoanhThu.Series.Add(seriesNhap);

                // Định dạng trục X
                chartArea.AxisX.LabelStyle.Format = loaiThoiGian.ToLower() == "ngày" ? "dd/MM/yyyy" : loaiThoiGian.ToLower() == "tháng" ? "MM/yyyy" : "yyyy";
                chartArea.AxisX.IntervalType = loaiThoiGian.ToLower() == "ngày" ? DateTimeIntervalType.Days : loaiThoiGian.ToLower() == "tháng" ? DateTimeIntervalType.Months : DateTimeIntervalType.Years;
                chartArea.AxisX.Interval = loaiThoiGian.ToLower() == "tháng" && tuNgay.Month == denNgay.Month ? 0 : 1;
                chartArea.AxisX.LabelStyle.Angle = -45;
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
                foreach (var kvp in doanhThuXuat)
                {
                    var point = seriesXuat.Points.AddXY(kvp.Key, Convert.ToDouble(kvp.Value));
                    if (kvp.Value == 0)
                    {
                        seriesXuat.Points[point].IsEmpty = true;
                    }
                }

                foreach (var kvp in doanhThuNhap)
                {
                    var point = seriesNhap.Points.AddXY(kvp.Key, Convert.ToDouble(kvp.Value));
                    if (kvp.Value == 0)
                    {
                        seriesNhap.Points[point].IsEmpty = true;
                    }
                }

                // Định dạng biểu đồ
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Titles.Add(new Title($"Doanh thu theo {loaiThoiGian}", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));
                chartDoanhThu.BackColor = Color.WhiteSmoke;
                chartDoanhThu.BorderlineColor = Color.Gray;
                chartDoanhThu.BorderlineDashStyle = ChartDashStyle.Solid;
                chartDoanhThu.BorderlineWidth = 1;

                // Thêm chú thích (Legend) để phân biệt hai Series
                chartDoanhThu.Legends.Clear();
                Legend legend = new Legend("ChartLegend");
                legend.Docking = Docking.Top;
                chartDoanhThu.Legends.Add(legend);
                seriesXuat.LegendText = "Doanh thu hóa đơn xuất";
                seriesNhap.LegendText = "Doanh thu hóa đơn nhập";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

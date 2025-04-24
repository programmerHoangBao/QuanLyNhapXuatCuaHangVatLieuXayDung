using Microsoft.Reporting.WinForms;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using QuanLyCuaHangVatLieuXayDung.views.report.model_report;
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

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ReportTraHang : Form
    {
        private PhieuTraHang phieuTraHang;
        private StringUtility stringUtility = new StringUtility();
        public Form_ReportTraHang()
        {
            InitializeComponent();
        }

        internal PhieuTraHang PhieuTraHang { get => phieuTraHang; set => phieuTraHang = value; }

        private void Form_ReportTraHang_Load(object sender, EventArgs e)
        {

            if (phieuTraHang.loaiPhieu_toByte() == 1)
            {
                this.InPhieuTraHangTuKhachHang((PhieuTraHangTuKhachHang)this.phieuTraHang);
            }
            else if (phieuTraHang.loaiPhieu_toByte() == 2)
            {
                this.InPhieuTraHangChoNhaCungCap((PhieuTraHangChoNhaCungCap)this.phieuTraHang);
            }
        }
        private void InPhieuTraHangTuKhachHang(PhieuTraHangTuKhachHang phieuTraHangTuKhachHang)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string tenPhieuTraHang = "Phiếu Trả Hàng Từ Khách Hàng";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "ReportPhieuTraHang.rdlc");
            this.reportViewerTraHang.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChuCuaHang", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("NganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp6 = new ReportParameter("TenPhieu", tenPhieuTraHang);
            ReportParameter rp7 = new ReportParameter("MaPhieu", phieuTraHangTuKhachHang.MaPhieu);
            ReportParameter rp8 = new ReportParameter("ThoiGianLap", phieuTraHangTuKhachHang.ThoiGianLap.ToString("dd/MM/yy - HH:mm:ss"));
            ReportParameter rp9 = new ReportParameter("MaHoaDon", phieuTraHangTuKhachHang.HoaDon.MaHoaDon);
            ReportParameter rp10 = new ReportParameter("LyDo", string.IsNullOrEmpty(phieuTraHangTuKhachHang.LyDo) ? " " : phieuTraHangTuKhachHang.LyDo);
            ReportParameter rp11 = new ReportParameter("TongTien", this.stringUtility.ConvertToVietnameseCurrency(phieuTraHangTuKhachHang.TongTien));
            this.reportViewerTraHang.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11 });
            List<ChiTietHoaDonReport> chiTietPhieuTraHangReports = new List<ChiTietHoaDonReport>();
            ChiTietHoaDonReport chiTietPhieuTraHangReport;
            int stt = 1;
            foreach (ChiTiet chiTiet in phieuTraHangTuKhachHang.ChiTiets)
            {
                chiTietPhieuTraHangReport = new ChiTietHoaDonReport();
                chiTietPhieuTraHangReport.Stt = stt.ToString();
                chiTietPhieuTraHangReport.MaVatlieu = chiTiet.VatLieu.MaVatLieu;
                chiTietPhieuTraHangReport.TenVatLieu = chiTiet.VatLieu.Ten;
                chiTietPhieuTraHangReport.DonVi = chiTiet.VatLieu.DonVi;
                chiTietPhieuTraHangReport.SoLuong = chiTiet.SoLuong.ToString();
                chiTietPhieuTraHangReport.Gia = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaXuat);
                chiTietPhieuTraHangReport.TongTien = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaXuat * chiTiet.SoLuong);
                chiTietPhieuTraHangReports.Add(chiTietPhieuTraHangReport);
                stt++;
            }
            ReportDataSource rds = new ReportDataSource("DataSetChiTietPhieuTraHang", chiTietPhieuTraHangReports);
            this.reportViewerTraHang.LocalReport.DataSources.Clear();
            this.reportViewerTraHang.LocalReport.DataSources.Add(rds);
            this.reportViewerTraHang.RefreshReport();
        }

        private void InPhieuTraHangChoNhaCungCap(PhieuTraHangChoNhaCungCap phieuTraHangChoNhaCungCap)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string tenPhieuTraHang = "Phiếu Trả Hàng Cho Nhà Cung Cấp";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "ReportPhieuTraHang.rdlc");
            this.reportViewerTraHang.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChuCuaHang", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("NganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp6 = new ReportParameter("TenPhieu", tenPhieuTraHang);
            ReportParameter rp7 = new ReportParameter("MaPhieu", phieuTraHangChoNhaCungCap.MaPhieu);
            ReportParameter rp8 = new ReportParameter("ThoiGianLap", phieuTraHangChoNhaCungCap.ThoiGianLap.ToString("dd/MM/yy - HH:mm:ss"));
            ReportParameter rp9 = new ReportParameter("MaHoaDon", phieuTraHangChoNhaCungCap.HoaDon.MaHoaDon);
            ReportParameter rp10 = new ReportParameter("LyDo", string.IsNullOrEmpty(phieuTraHangChoNhaCungCap.LyDo) ? " " : phieuTraHangChoNhaCungCap.LyDo);
            ReportParameter rp11 = new ReportParameter("TongTien", this.stringUtility.ConvertToVietnameseCurrency(phieuTraHangChoNhaCungCap.TongTien));
            this.reportViewerTraHang.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11 });
            List<ChiTietHoaDonReport> chiTietPhieuTraHangReports = new List<ChiTietHoaDonReport>();
            ChiTietHoaDonReport chiTietPhieuTraHangReport;
            int stt = 1;
            foreach (ChiTiet chiTiet in phieuTraHangChoNhaCungCap.ChiTiets)
            {
                chiTietPhieuTraHangReport = new ChiTietHoaDonReport();
                chiTietPhieuTraHangReport.Stt = stt.ToString();
                chiTietPhieuTraHangReport.MaVatlieu = chiTiet.VatLieu.MaVatLieu;
                chiTietPhieuTraHangReport.TenVatLieu = chiTiet.VatLieu.Ten;
                chiTietPhieuTraHangReport.DonVi = chiTiet.VatLieu.DonVi;
                chiTietPhieuTraHangReport.SoLuong = chiTiet.SoLuong.ToString();
                chiTietPhieuTraHangReport.Gia = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaNhap);
                chiTietPhieuTraHangReport.TongTien = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaNhap * chiTiet.SoLuong);
                chiTietPhieuTraHangReports.Add(chiTietPhieuTraHangReport);
                stt++;
            }
            ReportDataSource rds = new ReportDataSource("DataSetChiTietPhieuTraHang", chiTietPhieuTraHangReports);
            this.reportViewerTraHang.LocalReport.DataSources.Clear();
            this.reportViewerTraHang.LocalReport.DataSources.Add(rds);
            this.reportViewerTraHang.RefreshReport();
        }
    }
}

using Microsoft.Reporting.WinForms;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.utilities;
using QuanLyCuaHangVatLieuXayDung.views.report.model_report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ReportHoaDon : Form
    {
        private HoaDon hoaDon;
        private StringUtility stringUtility = new StringUtility();
        public Form_ReportHoaDon()
        {
            InitializeComponent();
        }

        internal HoaDon HoaDon { get => hoaDon; set => hoaDon = value; }

        private void Form_ReportHoaDon_Load(object sender, EventArgs e)
        {

            this.reportViewerHoaDon.RefreshReport();
            if (this.hoaDon.loaiHoaDon_toByte() == 1)
            {
                this.InHoDonXuat((HoaDonXuat)this.hoaDon);
            }
            else if (this.hoaDon.loaiHoaDon_toByte() == 2)
            {
                this.InHoaDonNhap((HoaDonNhap)this.hoaDon);
            }
        }
        private void InHoDonXuat(HoaDonXuat hoaDonXuat)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string tenHoaDon = "Hoá Đơn Xuất";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "ReportHoaDon.rdlc");
            this.reportViewerHoaDon.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChu", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("TenNganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp6 = new ReportParameter("TenHoaDon", tenHoaDon);
            ReportParameter rp7 = new ReportParameter("MaHoaDon", hoaDonXuat.MaHoaDon);
            ReportParameter rp8 = new ReportParameter("ThoiGianLap", hoaDonXuat.ThoiGianLap.ToString("dd/MM/yy - HH:mm:ss"));
            ReportParameter rp9 = new ReportParameter("TenDoiTac", hoaDonXuat.DoiTac.Ten);
            ReportParameter rp10 = new ReportParameter("SoDienThoaiDoiTac", hoaDonXuat.DoiTac.SoDienThoai);
            ReportParameter rp11 = new ReportParameter("DiaChiDoiTac", hoaDonXuat.DiaChi);
            ReportParameter rp12 = new ReportParameter("PhuongThucThanhToan", hoaDonXuat.phuongThucThanhToan_toString());
            ReportParameter rp13 = new ReportParameter("SoTienGiam", this.stringUtility.ConvertToVietnameseCurrency(hoaDonXuat.TienGiam));
            ReportParameter rp14 = new ReportParameter("SoTienThanhToan", this.stringUtility.ConvertToVietnameseCurrency(hoaDonXuat.TienThanhToan));
            ReportParameter rp15 = new ReportParameter("TongTienHoaDon", this.stringUtility.ConvertToVietnameseCurrency(hoaDonXuat.tinhTongTien()));
            this.reportViewerHoaDon.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15});

            List<ChiTietHoaDonReport> chiTietHoaDonReports = new List<ChiTietHoaDonReport>();
            ChiTietHoaDonReport chiTietHoaDonReport;
            int stt = 1;
            foreach (ChiTiet chiTiet in hoaDonXuat.ChiTiets)
            {
                chiTietHoaDonReport = new ChiTietHoaDonReport();
                chiTietHoaDonReport.Stt = stt.ToString();
                chiTietHoaDonReport.MaVatlieu = chiTiet.VatLieu.MaVatLieu;
                chiTietHoaDonReport.TenVatLieu = chiTiet.VatLieu.Ten;
                chiTietHoaDonReport.DonVi = chiTiet.VatLieu.DonVi;
                chiTietHoaDonReport.SoLuong = chiTiet.SoLuong.ToString();
                chiTietHoaDonReport.Gia = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaXuat);
                chiTietHoaDonReport.TongTien = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaXuat * chiTiet.SoLuong);
                chiTietHoaDonReports.Add(chiTietHoaDonReport);
                stt++;
            }
            ReportDataSource rds = new ReportDataSource("DataSetChiTietHoaDon", chiTietHoaDonReports);
            this.reportViewerHoaDon.LocalReport.DataSources.Clear();
            this.reportViewerHoaDon.LocalReport.DataSources.Add(rds);
            this.reportViewerHoaDon.RefreshReport();
        }
        private void InHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string tenHoaDon = "Hoá Đơn Nhập";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "ReportHoaDon.rdlc");
            this.reportViewerHoaDon.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChu", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("TenNganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp6 = new ReportParameter("TenHoaDon", tenHoaDon);
            ReportParameter rp7 = new ReportParameter("MaHoaDon", hoaDonNhap.MaHoaDon);
            ReportParameter rp8 = new ReportParameter("ThoiGianLap", hoaDonNhap.ThoiGianLap.ToString("dd/MM/yy - HH:mm:ss"));
            ReportParameter rp9 = new ReportParameter("TenDoiTac", hoaDonNhap.DoiTac.Ten);
            ReportParameter rp10 = new ReportParameter("SoDienThoaiDoiTac", hoaDonNhap.DoiTac.SoDienThoai);
            ReportParameter rp11 = new ReportParameter("DiaChiDoiTac", hoaDonNhap.DiaChi);
            ReportParameter rp12 = new ReportParameter("PhuongThucThanhToan", hoaDonNhap.phuongThucThanhToan_toString());
            ReportParameter rp13 = new ReportParameter("SoTienGiam", this.stringUtility.ConvertToVietnameseCurrency(hoaDonNhap.TienGiam));
            ReportParameter rp14 = new ReportParameter("SoTienThanhToan", this.stringUtility.ConvertToVietnameseCurrency(hoaDonNhap.TienThanhToan));
            ReportParameter rp15 = new ReportParameter("TongTienHoaDon", this.stringUtility.ConvertToVietnameseCurrency(hoaDonNhap.tinhTongTien()));
            this.reportViewerHoaDon.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15 });

            List<ChiTietHoaDonReport> chiTietHoaDonReports = new List<ChiTietHoaDonReport>();
            ChiTietHoaDonReport chiTietHoaDonReport;
            int stt = 1;
            foreach (ChiTiet chiTiet in hoaDonNhap.ChiTiets)
            {
                chiTietHoaDonReport = new ChiTietHoaDonReport();
                chiTietHoaDonReport.Stt = stt.ToString();
                chiTietHoaDonReport.MaVatlieu = chiTiet.VatLieu.MaVatLieu;
                chiTietHoaDonReport.TenVatLieu = chiTiet.VatLieu.Ten;
                chiTietHoaDonReport.DonVi = chiTiet.VatLieu.DonVi;
                chiTietHoaDonReport.SoLuong = chiTiet.SoLuong.ToString();
                chiTietHoaDonReport.Gia = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaNhap);
                chiTietHoaDonReport.TongTien = this.stringUtility.ConvertToVietnameseCurrency(chiTiet.VatLieu.GiaNhap * chiTiet.SoLuong);
                chiTietHoaDonReports.Add(chiTietHoaDonReport);
                stt++;
            }
            ReportDataSource rds = new ReportDataSource("DataSetChiTietHoaDon", chiTietHoaDonReports);
            this.reportViewerHoaDon.LocalReport.DataSources.Clear();
            this.reportViewerHoaDon.LocalReport.DataSources.Add(rds);
            this.reportViewerHoaDon.RefreshReport();
        }
    }
}

using Microsoft.Reporting.WinForms;
using QuanLyCuaHangVatLieuXayDung.model;
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

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ReportPhieuGhiNo : Form
    {
        private PhieuGhiNo phieuGhiNo;
        private StringUtility stringUtility = new StringUtility();
        public Form_ReportPhieuGhiNo()
        {
            InitializeComponent();
        }

        internal PhieuGhiNo PhieuGhiNo { get => phieuGhiNo; set => phieuGhiNo = value; }

        private void Form_ReportPhieuGhiNo_Load(object sender, EventArgs e)
        {
            if (phieuGhiNo.loaiPhieu_toByte() == 1)
            {
                this.InPhieuGhiNoKhachHang((PhieuNoKhachHang)this.phieuGhiNo);
            }
            else if (phieuGhiNo.loaiPhieu_toByte() == 2)
            {
                this.InPhieuGhiNoCuaHang((PhieuNoCuaHang)this.phieuGhiNo);
            }
        }
        private void InPhieuGhiNoKhachHang(PhieuNoKhachHang phieuNoKhachHang)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string tenPhieuNo = "Phiếu Nợ Của Khách Hàng";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "ReportPhieuGhiNo.rdlc");
            this.reportViewerPhieuGhiNo.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChu", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("TenNganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp6 = new ReportParameter("TenPhieu", tenPhieuNo);
            ReportParameter rp7 = new ReportParameter("MaPhieu", phieuNoKhachHang.MaPhieu);
            ReportParameter rp8 = new ReportParameter("ThoiGianLap", phieuNoKhachHang.ThoiGianLap.ToString("dd/MM/yyyy"));
            ReportParameter rp9 = new ReportParameter("ThoiGianTra", phieuNoKhachHang.ThoiGianTra.ToString("dd/MM/yyyy"));
            ReportParameter rp10 = new ReportParameter("TenDoiTac", phieuNoKhachHang.DoiTac.Ten);
            ReportParameter rp11 = new ReportParameter("SoDienThoaiDoiTac", phieuNoKhachHang.DoiTac.SoDienThoai);
            ReportParameter rp12 = new ReportParameter("DiaChiDoiTac", phieuNoKhachHang.DoiTac.DiaChi);
            ReportParameter rp13 = new ReportParameter("MaHoaDon", phieuNoKhachHang.HoaDon.MaHoaDon);
            ReportParameter rp14 = new ReportParameter("SoTienNo", stringUtility.ConvertToVietnameseCurrency(phieuNoKhachHang.TienNo));
            ReportParameter rp15 = new ReportParameter("TrangThai", phieuNoKhachHang.TrangThai ? "Đã trả" : "Chưa trả");
            this.reportViewerPhieuGhiNo.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15 });
            this.reportViewerPhieuGhiNo.RefreshReport();
        }
        private void InPhieuGhiNoCuaHang(PhieuNoCuaHang phieuNoCuaHang)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string tenPhieuNo = "Phiếu Nợ Cửa Cửa Hàng";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "ReportPhieuGhiNo.rdlc");
            this.reportViewerPhieuGhiNo.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChu", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("TenNganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp6 = new ReportParameter("TenPhieu", tenPhieuNo);
            ReportParameter rp7 = new ReportParameter("MaPhieu", phieuNoCuaHang.MaPhieu);
            ReportParameter rp8 = new ReportParameter("ThoiGianLap", phieuNoCuaHang.ThoiGianLap.ToString("dd/MM/yyyy"));
            ReportParameter rp9 = new ReportParameter("ThoiGianTra", phieuNoCuaHang.ThoiGianTra.ToString("dd/MM/yyyy"));
            ReportParameter rp10 = new ReportParameter("TenDoiTac", phieuNoCuaHang.DoiTac.Ten);
            ReportParameter rp11 = new ReportParameter("SoDienThoaiDoiTac", phieuNoCuaHang.DoiTac.SoDienThoai);
            ReportParameter rp12 = new ReportParameter("DiaChiDoiTac", phieuNoCuaHang.DoiTac.DiaChi);
            ReportParameter rp13 = new ReportParameter("MaHoaDon", phieuNoCuaHang.HoaDon.MaHoaDon);
            ReportParameter rp14 = new ReportParameter("SoTienNo", stringUtility.ConvertToVietnameseCurrency(phieuNoCuaHang.TienNo));
            ReportParameter rp15 = new ReportParameter("TrangThai", phieuNoCuaHang.TrangThai ? "Đã trả" : "Chưa trả");
            this.reportViewerPhieuGhiNo.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15 });
            this.reportViewerPhieuGhiNo.RefreshReport();
        }
    }
}

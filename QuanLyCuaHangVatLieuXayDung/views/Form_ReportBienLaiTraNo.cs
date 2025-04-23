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
    public partial class Form_ReportBienLaiTraNo : Form
    {
        private BienLaiTraNo bienLaiTraNo;
        private StringUtility stringUtility = new StringUtility();
        public Form_ReportBienLaiTraNo()
        {
            InitializeComponent();
        }

        internal BienLaiTraNo BienLaiTraNo { get => bienLaiTraNo; set => bienLaiTraNo = value; }

        private void Form_ReportBienLaiTraNo_Load(object sender, EventArgs e)
        {
            if (this.bienLaiTraNo != null)
            {
                InBienLaiTraNoCuaKhach(this.bienLaiTraNo);
            }
        }
        private void InBienLaiTraNoCuaKhach(BienLaiTraNo bl)
        {
            string tenCuaHang = "Cửa Hàng Vật Liệu Xây Dựng Minh Kha";
            string diaChiCuaHang = "Cầu số 8, Phú Mỹ, Phú Hội, An Phú, An Giang";
            string tenChu = "Nguyễn Minh Kha";
            string soDienThoaiChu = "0398518273";
            string nganHang = "Ngân hàng Vietcombank";
            string soTaiKhoan = "123456789";
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(projectDirectory, "views", "report", "Report_BienLaiTraNo.rdlc");
            this.reportViewerBienLaiTraNo.LocalReport.ReportPath = reportPath;
            ReportParameter rp = new ReportParameter("TenCuaHang", tenCuaHang);
            ReportParameter rp1 = new ReportParameter("DiaChiCuaHang", diaChiCuaHang);
            ReportParameter rp2 = new ReportParameter("TenChuCuaHang", tenChu);
            ReportParameter rp3 = new ReportParameter("SoDienThoaiChu", soDienThoaiChu);
            ReportParameter rp4 = new ReportParameter("TenNganHang", nganHang);
            ReportParameter rp5 = new ReportParameter("SoTaiKhoan", soTaiKhoan);
            ReportParameter rp7 = new ReportParameter("MaBienLai", bl.MaBienLai);
            ReportParameter rp8 = new ReportParameter("MaPhieuGhiNo", bl.MaPhieuGhiNo);
            ReportParameter rp9 = new ReportParameter("ThoiGianTra", bl.ThoiGianTra.ToString("dd/MM/yyyy"));
            ReportParameter rp10 = new ReportParameter("TenDoiTac", bl.TenDoiTac);
            ReportParameter rp11 = new ReportParameter("SoDienThoaiDoiTac", bl.SoDienThoai);
            ReportParameter rp12 = new ReportParameter("DiaChiDoiTac", bl.DiaChi);
            ReportParameter rp13 = new ReportParameter("TienTra", stringUtility.ConvertToVietnameseCurrency(bl.TienTra));
            this.reportViewerBienLaiTraNo.LocalReport.SetParameters(new ReportParameter[] { rp, rp1, rp2, rp3, rp4, rp5, rp7, rp8, rp9, rp10, rp11, rp12, rp13 });
            this.reportViewerBienLaiTraNo.RefreshReport();
        }
    }
}

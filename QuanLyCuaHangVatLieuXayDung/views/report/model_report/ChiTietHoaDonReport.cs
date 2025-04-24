using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.views.report.model_report
{
    internal class ChiTietHoaDonReport
    {
        private string stt;
        private string maVatlieu;
        private string tenVatLieu;
        private string gia;
        private string donVi;
        private string soLuong;
        private string tongTien;
        public ChiTietHoaDonReport()
        {
        }

        public string Stt { get => stt; set => stt = value; }
        public string MaVatlieu { get => maVatlieu; set => maVatlieu = value; }
        public string TenVatLieu { get => tenVatLieu; set => tenVatLieu = value; }
        public string Gia { get => gia; set => gia = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
    }
}

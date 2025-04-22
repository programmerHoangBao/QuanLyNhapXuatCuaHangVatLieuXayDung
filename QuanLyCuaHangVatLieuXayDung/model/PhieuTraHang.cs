using System.Collections.Generic;
using System;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class PhieuTraHang
    {
        private string maPhieu;
        private DateTime thoiGianLap;
        private string maHoaDon;
        private string lyDo;
        private double tongTien;
        private List<ChiTiet> chiTiets;

        public PhieuTraHang()
        {
        }

        public PhieuTraHang(string maPhieu, DateTime thoiGianLap,string maHoaDon, string lyDo,
            double tongTien, List<ChiTiet> chiTiets)
        {
            this.MaPhieu = maPhieu;
            this.ThoiGianLap = thoiGianLap;
            this.MaHoaDon = maHoaDon;
            this.LyDo = lyDo;
            this.TongTien = tongTien;
            this.ChiTiets = chiTiets;
        }

        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public List<ChiTiet> ChiTiets { get => chiTiets; set => chiTiets = value; }

        public abstract byte loaiPhieu_toByte();
        public abstract string loaiPhieu_toString();
    }
}

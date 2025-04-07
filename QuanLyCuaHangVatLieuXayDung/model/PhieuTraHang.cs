using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class PhieuTraHang
    {
        private string maPhieu;
        private DateTime thoiGianLap;
        private string lyDo;
        private double tongTien;
        private List<(VatLieu vatLieu, float soLuong)> chiTiets;

        public PhieuTraHang()
        {
        }

        public PhieuTraHang(string maPhieu, DateTime thoiGianLap, string lyDo, 
            double tongTien, List<(VatLieu vatLieu, float soLuong)> chiTiets)
        {
            this.MaPhieu = maPhieu;
            this.ThoiGianLap = thoiGianLap;
            this.LyDo = lyDo;
            this.TongTien = tongTien;
            this.ChiTiets = chiTiets;
        }
        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public List<(VatLieu vatLieu, float soLuong)> ChiTiets { get => chiTiets; set => chiTiets = value; }

        public abstract byte loaiPhieu_toByte();
        public abstract string loaiPhieu_toString();
    }
}

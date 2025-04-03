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

        protected PhieuTraHang()
        {
        }

        protected PhieuTraHang(string maPhieu, DateTime thoiGianLap, string lyDo, 
            double tongTien, List<(VatLieu vatLieu, float soLuong)> chiTiets)
        {
            this.MaPhieu = maPhieu;
            this.ThoiGianLap = thoiGianLap;
            this.LyDo = lyDo;
            this.TongTien = tongTien;
            this.ChiTiets = chiTiets;
        }
        protected string MaPhieu { get => maPhieu; set => maPhieu = value; }
        protected DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        protected string LyDo { get => lyDo; set => lyDo = value; }
        protected double TongTien { get => tongTien; set => tongTien = value; }
        protected List<(VatLieu vatLieu, float soLuong)> ChiTiets { get => chiTiets; set => chiTiets = value; }
        protected abstract string LoaiPhieu();
    }
}

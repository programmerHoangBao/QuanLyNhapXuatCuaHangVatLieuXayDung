using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class PhieuTraHang
    {
        private int index;
        private string maPhieu;
        private DateTime thoiGianLap;
        private string lyDoTraHang;
        private HoaDon hoaDon;
        private List<(VatLieu vatLieu, double soLuong)> dsVatLieu = new List<(VatLieu vatLieu, double soLuong)>();

        protected PhieuTraHang()
        {
        }

        public int Index { get => index; set => index = value; }
        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public string LyDoTraHang { get => lyDoTraHang; set => lyDoTraHang = value; }
        internal HoaDon HoaDon { get => hoaDon; set => hoaDon = value; }
        internal List<(VatLieu vatLieu, double soLuong)> DsVatLieu { get => dsVatLieu; set => dsVatLieu = value; }

        public abstract string LoaiHoaDon();
        public double TongTien()
        {
            double tongTien = 0;
            foreach (var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaXuat * vatLieu.soLuong;
            }
            return tongTien + this.HoaDon.GiamChietKhau;
        }
    }
}

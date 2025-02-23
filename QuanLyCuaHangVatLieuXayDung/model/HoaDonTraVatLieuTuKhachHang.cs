using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonTraVatLieuTuKhachHang : HoaDon
    {

        private DoiTac khachHang = new KhachHang();

        public HoaDonTraVatLieuTuKhachHang()
        {
        }

        internal DoiTac KhachHang { get => khachHang; set => khachHang = value; }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn trả vật liệu từ khách hàng";
        }

        public override double TongTien()
        {
            double tongTien = 0;
            foreach (var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaXuat * vatLieu.soLuong;
            }
            return tongTien;
        }
    }
}

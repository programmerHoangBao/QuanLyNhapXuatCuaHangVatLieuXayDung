using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonBanLe : HoaDon
    {
        public HoaDonBanLe()
        {
        }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn bán lẻ";
        }

        public override double TongTien()
        {
            double tongTien = 0; 
            foreach(var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaXuat * vatLieu.soLuong;
            }
            return tongTien + this.GiamChietKhau;
        }
    }
}

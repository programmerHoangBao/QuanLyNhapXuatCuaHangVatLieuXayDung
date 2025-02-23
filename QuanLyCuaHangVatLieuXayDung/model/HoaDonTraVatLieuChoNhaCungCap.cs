using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonTraVatLieuChoNhaCungCap : HoaDon
    {
        private DoiTac nhaCungCap = new NhaCungCap();

        public HoaDonTraVatLieuChoNhaCungCap()
        {
        }

        internal DoiTac NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn trả vật liệu cho nhà cung cấp";
        }

        public override double TongTien()
        {
            double tongTien = 0;
            foreach (var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaNhap * vatLieu.soLuong;
            }
            return tongTien;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonNhap : HoaDon
    {
        public HoaDonNhap()
        {
        }
        public HoaDonNhap(string maHoaDon, DateTime thoiGianLap, DoiTac doiTac, string diaChi,
            double tienGiam, byte phuongThucThanhToan, double tienThanhToan, List<ChiTiet> chiTiets) : base(maHoaDon, thoiGianLap, doiTac, diaChi,
            tienGiam, phuongThucThanhToan, tienThanhToan, chiTiets)
        {
        }
        public override string loaiHoaDon_toString()
        {
            return "Hóa đơn nhập hàng";
        }
        public override byte loaiHoaDon_toByte()
        {
            return 2;
        }

        public override double tinhTongTien()
        {
            double tongTien = 0;
            foreach (ChiTiet chiTiet in this.ChiTiets)
            {
                tongTien += chiTiet.VatLieu.GiaNhap;
            }
            return tongTien - this.tienGiam;
        }
    }
}

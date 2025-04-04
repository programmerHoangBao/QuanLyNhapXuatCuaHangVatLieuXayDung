using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonXuat : HoaDon
    {
        private KhachHang khachHang;
        public HoaDonXuat()
        {
        }
        public HoaDonXuat(string maHoaDon, DateTime thoiGianLap, string diaChi,
            double tienGiam, byte phuongThucThanhToan, double tienThanhToan, List<(VatLieu, float)> chiTiets, KhachHang khachHang) : base(maHoaDon, thoiGianLap, diaChi, tienGiam, phuongThucThanhToan, tienThanhToan, chiTiets)
        {
            this.khachHang = khachHang;
        }
        public override byte loaiHoaDon_toByte()
        {
            return 1;
        }
        public override string loaiHoaDon_toString()
        {
            return "Hóa đơn xuất hàng";
        }
    }
}

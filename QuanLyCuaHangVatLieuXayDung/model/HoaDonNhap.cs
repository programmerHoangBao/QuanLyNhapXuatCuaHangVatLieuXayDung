using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonNhap : HoaDon
    {
        private NhaCungCap nhaCungCap;
        public HoaDonNhap()
        {
        }
        public HoaDonNhap(string maHoaDon, DateTime thoiGianLap, string diaChi,
            double tienGiam, byte phuongThucThanhToan, double tienThanhToan, List<(VatLieu, float)> chiTiets, NhaCungCap nhaCungCap) : base(maHoaDon, thoiGianLap, diaChi, tienGiam, phuongThucThanhToan, tienThanhToan, chiTiets)
        {
            this.nhaCungCap = nhaCungCap;
        }
        public override string loaiHoaDon_toString()
        {
            return "Hóa đơn nhập hàng";
        }

        public override byte loaiHoaDon_toByte()
        {
            return 2;
        }

        public NhaCungCap NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
    }
}

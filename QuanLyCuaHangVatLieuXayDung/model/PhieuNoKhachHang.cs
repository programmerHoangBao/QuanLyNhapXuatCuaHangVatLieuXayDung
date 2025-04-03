using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuNoKhachHang : PhieuGhiNo
    {
        private KhachHang khachHang;
        private HoaDonXuat hoaDonXuat;
        public PhieuNoKhachHang()
        {
        }
        public PhieuNoKhachHang(string maPhieu, DateTime thoiGianLap, DateTime thoiGianTra, double tienNo, bool trangThai, KhachHang khachHang, HoaDonXuat hoaDonXuat) : base(maPhieu, thoiGianLap, thoiGianTra, tienNo, trangThai)
        {
            this.KhachHang = khachHang;
            this.HoaDonXuat = hoaDonXuat;
        }

        internal KhachHang KhachHang { get => khachHang; set => khachHang = value; }
        internal HoaDonXuat HoaDonXuat { get => hoaDonXuat; set => hoaDonXuat = value; }

        protected override string LoaiPhieu()
        {
            return "Phiếu ghi nợ của khách hàng";
        }
    }
}

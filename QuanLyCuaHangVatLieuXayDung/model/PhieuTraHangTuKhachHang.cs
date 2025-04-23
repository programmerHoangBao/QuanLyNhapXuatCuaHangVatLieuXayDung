using System;
using System.Collections.Generic;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangTuKhachHang : PhieuTraHang
    {
        private HoaDonXuat hoaDonXuat;

        public PhieuTraHangTuKhachHang()
        {
        }

        public PhieuTraHangTuKhachHang(string maPhieu, DateTime thoiGianLap,string maHoaDon, string lyDo,
            double tongTien, List<ChiTiet> chiTiets, HoaDonXuat hoaDonXuat)
            : base(maPhieu, thoiGianLap,maHoaDon, lyDo, tongTien, chiTiets)
        {
            this.hoaDonXuat = hoaDonXuat;
        }

        public override string loaiPhieu_toString()
        {
            return "Phiếu trả hàng từ khách hàng";
        }

        public override byte loaiPhieu_toByte()
        {
            return 1;
        }

        internal HoaDonXuat HoaDonXuat
        {
            get => hoaDonXuat;
            set => hoaDonXuat = value;
        }
    }
}

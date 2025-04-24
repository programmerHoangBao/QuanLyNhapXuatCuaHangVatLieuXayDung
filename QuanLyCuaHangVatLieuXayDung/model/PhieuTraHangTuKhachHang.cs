using System;
using System.Collections.Generic;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangTuKhachHang : PhieuTraHang
    {
        public PhieuTraHangTuKhachHang()
        {
        }
        public PhieuTraHangTuKhachHang(string maPhieu, DateTime thoiGianLap, HoaDon hoaDon, string lyDo,
            double tongTien, List<ChiTiet> chiTiets) : base(maPhieu, thoiGianLap, hoaDon, lyDo, tongTien, chiTiets)
        {
        }

        public override string loaiPhieu_toString()
        {
            return "Phiếu trả hàng từ khách hàng";
        }

        public override byte loaiPhieu_toByte()
        {
            return 1;
        }
    }
}

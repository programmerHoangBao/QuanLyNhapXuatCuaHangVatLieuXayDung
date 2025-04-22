using System;
using System.Collections.Generic;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangChoNhaCungCap : PhieuTraHang
    {
        public PhieuTraHangChoNhaCungCap()
        {
        }
        public PhieuTraHangChoNhaCungCap(string maPhieu, DateTime thoiGianLap, HoaDon hoaDon, string lyDo,
            double tongTien, List<ChiTiet> chiTiets) : base(maPhieu, thoiGianLap, hoaDon, lyDo, tongTien, chiTiets)
        {
        }

        public override string loaiPhieu_toString()
        {
            return "Phiếu trả hàng cho nhà cung cấp";
        }

        public override byte loaiPhieu_toByte()
        {
            return 2;
        }
    }
}

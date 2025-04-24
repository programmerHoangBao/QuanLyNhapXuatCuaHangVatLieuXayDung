using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuNoCuaHang : PhieuGhiNo
    {
        public PhieuNoCuaHang()
        {
        }
        public PhieuNoCuaHang(string maPhieu, DateTime thoiGianLap, DateTime thoiGianTra, double tienNo, bool trangThai, DoiTac doiTac, HoaDon hoaDon) : base(maPhieu, thoiGianLap, thoiGianTra, tienNo, trangThai, doiTac, hoaDon)
        {
        }
        public override byte loaiPhieu_toByte()
        {
            return 2;
        }

        public override string loaiPhieu_toString()
        {
            return "Phiếu ghi nợ của cửa hàng";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangTuKhachHang : PhieuTraHang
    {
        private HoaDonXuat hoaDonXuat;
        public PhieuTraHangTuKhachHang()
        {
        }
        public PhieuTraHangTuKhachHang(string maPhieu, DateTime thoiGianLap, string lyDo,
            double tongTien, List<(VatLieu vatLieu, float soLuong)> chiTiets, HoaDonXuat hoaDonXuat) : base(maPhieu, thoiGianLap, lyDo, tongTien, chiTiets)
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

        internal HoaDonXuat HoaDonXuat { get => hoaDonXuat; set => hoaDonXuat = value; }
    }
}

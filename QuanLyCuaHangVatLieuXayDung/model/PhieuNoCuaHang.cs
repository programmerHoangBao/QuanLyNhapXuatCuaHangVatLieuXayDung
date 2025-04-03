using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuNoCuaHang : PhieuGhiNo
    {
        private NhaCungCap nhaCungCap;
        private HoaDonNhap hoaDonNhap;
        public PhieuNoCuaHang()
        {
        }
        public PhieuNoCuaHang(string maPhieu, DateTime thoiGianLap, DateTime thoiGianTra, double tienNo, bool trangThai, NhaCungCap nhaCungCap, HoaDonNhap hoaDonNhap) : base(maPhieu, thoiGianLap, thoiGianTra, tienNo, trangThai)
        {
            this.NhaCungCap = nhaCungCap;
            this.HoaDonNhap = hoaDonNhap;
        }

        internal NhaCungCap NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        internal HoaDonNhap HoaDonNhap { get => hoaDonNhap; set => hoaDonNhap = value; }

        protected override string LoaiPhieu()
        {
            return "Phiếu ghi nợ của cửa hàng";
        }
    }
}

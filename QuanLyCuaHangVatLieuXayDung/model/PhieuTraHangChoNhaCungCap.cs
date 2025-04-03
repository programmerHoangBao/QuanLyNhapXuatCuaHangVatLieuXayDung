using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangChoNhaCungCap : PhieuTraHang
    {
        private HoaDonNhap hoaDonNhap;
        public PhieuTraHangChoNhaCungCap()
        {
        }
        public PhieuTraHangChoNhaCungCap(string maPhieu, DateTime ngayLap, NhanVien nhanVien, NhaCungCap nhaCungCap, HoaDonNhap hoaDonNhap) : base(maPhieu, ngayLap, nhanVien, nhaCungCap)
        {
            this.HoaDonNhap = hoaDonNhap;
        }
        protected override string LoaiPhieu()
        {
            return "Phiếu trả hàng cho nhà cung cấp";
        }
        internal HoaDonNhap HoaDonNhap
        {
            get => hoaDonNhap; set => hoaDonNhap = value;
        }
}

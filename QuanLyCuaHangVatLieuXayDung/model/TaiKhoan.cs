using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class TaiKhoan
    {
        private string maTaiKhoan;
        private string tenDangNhap;
        private string matKhau;
        private string tenCuaHang;
        private string soDienThoai;
        private string diaChi;
        private string email;
        private string nganHang;
        private string soTaiKhoan;
        private string qR;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string maTaiKhoan, string tenDangNhap, string matKhau, string tenCuaHang, 
            string soDienThoai, string diaChi, string email, string nganHang, string soTaiKhoan, string QR)
        {
            this.MaTaiKhoan = maTaiKhoan;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.TenCuaHang = tenCuaHang;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.Email = email;
            this.NganHang = nganHang;
            this.SoTaiKhoan = soTaiKhoan;
            this.QR = QR;
        }

        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string TenCuaHang { get => tenCuaHang; set => tenCuaHang = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string NganHang { get => nganHang; set => nganHang = value; }
        public string SoTaiKhoan { get => soTaiKhoan; set => soTaiKhoan = value; }
        public string QR { get => qR; set => qR = value; }
    }
}

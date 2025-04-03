using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class DoiTac
    {
        private string maDoiTac;
        private string ten;
        private string soDienThoai;
        private string diaChi;
        private string email;
        private string nganHang;
        private string soTaiKhoan;
        private string qR;
        protected DoiTac()
        {
        }
        protected DoiTac(string maDoiTac, string ten, string soDienThoai, string diaChi, string email, string nganHang, string soTaiKhoan, string qR)
        {
            this.maDoiTac = maDoiTac;
            this.ten = ten;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
            this.email = email;
            this.nganHang = nganHang;
            this.soTaiKhoan = soTaiKhoan;
            this.qR = qR;
        }
        protected string MaDoiTac { get => maDoiTac; set => maDoiTac = value; }
        protected string Ten { get => ten; set => ten = value; }
        protected string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        protected string DiaChi { get => diaChi; set => diaChi = value; }
        protected string Email { get => email; set => email = value; }
        protected string NganHang { get => nganHang; set => nganHang = value; }
        protected string SoTaiKhoan { get => soTaiKhoan; set => soTaiKhoan = value; }
        protected string QR { get => qR; set => qR = value; }

        protected abstract string loaiDoiTac();
    }
}
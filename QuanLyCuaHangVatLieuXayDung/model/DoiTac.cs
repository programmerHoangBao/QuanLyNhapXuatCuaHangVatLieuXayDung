using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class DoiTac
    {
        protected string maDoiTac;
        protected string ten;
        protected string soDienThoai;
        protected string diaChi;
        protected string email;
        protected string nganHang;
        protected string soTaiKhoan;
        protected string qR;
        public DoiTac()
        {
        }
        public DoiTac(string maDoiTac, string ten, string soDienThoai, string diaChi, string email, string nganHang, string soTaiKhoan, string qR)
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
        public string MaDoiTac { get => maDoiTac; set => maDoiTac = value; }
        public string Ten { get => ten; set => ten = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string NganHang { get => nganHang; set => nganHang = value; }
        public string SoTaiKhoan { get => soTaiKhoan; set => soTaiKhoan = value; }
        public string QR { get => qR; set => qR = value; }

        public abstract byte loaiDoiTac_toByte();
        public abstract string loaiDoiTac_toString();
    }
}
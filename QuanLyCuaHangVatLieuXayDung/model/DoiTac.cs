using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class DoiTac
    {
        private int index;
        private string maDoiTac;
        private string tenDoiTac;
        private string soDienThoai;
        private string diaChi;
        private string email;
        private string soTaiKhoan;
        private string nganHang;
        private bool trangThai;

        protected DoiTac()
        {
        }

        public string MaDoiTac { get => maDoiTac; set => maDoiTac = value; }
        public string TenDoiTac { get => tenDoiTac; set => tenDoiTac = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string SoTaiKhoan { get => soTaiKhoan; set => soTaiKhoan = value; }
        public string NganHang { get => nganHang; set => nganHang = value; }
        public int Index { get => index; set => index = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }

        public abstract string LoaiDoiTac();
    }
}

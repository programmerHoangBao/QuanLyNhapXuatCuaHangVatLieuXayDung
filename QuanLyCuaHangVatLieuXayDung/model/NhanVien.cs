using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class NhanVien
    {
        private string maNhanVien;
        private string ten;
        private string soDienThoai;
        private string diaChi;
        private string vaiTro;
        private string email;
        private double luongTrenNgay;
        public NhanVien()
        {
        }

        public NhanVien(string maNhanVien, string ten, string soDienThoai, string diaChi, string vaiTro, string email, double luongTrenNgay)
        {
            this.MaNhanVien = maNhanVien;
            this.Ten = ten;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.VaiTro = vaiTro;
            this.Email = email;
            this.LuongTrenNgay = luongTrenNgay;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string Ten { get => ten; set => ten = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string VaiTro { get => vaiTro; set => vaiTro = value; }
        public string Email { get => email; set => email = value; }
        public double LuongTrenNgay { get => luongTrenNgay; set => luongTrenNgay = value; }
    }
}

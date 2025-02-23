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
        private string tenNhanVien;
        private string soDienThoai;
        private string diaChi;
        private double tienLuongTrenNgay;

        public NhanVien()
        {
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public double TienLuongTrenNgay { get => tienLuongTrenNgay; set => tienLuongTrenNgay = value; }
    }
}

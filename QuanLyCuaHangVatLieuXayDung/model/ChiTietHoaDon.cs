using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class ChiTietHoaDon
    {
        public string MaHoaDon { get; set; }

        public VatLieu VatLieu { get; set; }

        public float SoLuong { get; set; }

        public string TenVatLieu { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaXuat { get; set; }

        public string DonVi { get; set; }

        public DateTime NgayNhap { get; set; }

        public NhaCungCap NhaCungCap { get; set; }

        public string HinhAnh { get; set; }

        public ChiTietHoaDon()
        {
            MaHoaDon = string.Empty;
            VatLieu = null;
            SoLuong = 0;
            TenVatLieu = string.Empty;
            GiaNhap = 0;
            GiaXuat = 0;
            DonVi = string.Empty;
            NgayNhap = DateTime.Now; 
            NhaCungCap = null; 
            HinhAnh = string.Empty;
        }

        public ChiTietHoaDon(string maHoaDon, VatLieu vatLieu, float soLuong, string tenVatLieu,
            decimal giaNhap, decimal giaXuat, string donVi, DateTime ngayNhap, NhaCungCap nhaCungCap, string hinhAnh)
        {
            MaHoaDon = maHoaDon;
            VatLieu = vatLieu;
            SoLuong = soLuong;
            TenVatLieu = tenVatLieu;
            GiaNhap = giaNhap;
            GiaXuat = giaXuat;
            DonVi = donVi;
            NgayNhap = ngayNhap;
            NhaCungCap = nhaCungCap;
            HinhAnh = hinhAnh;
        }
    }
}

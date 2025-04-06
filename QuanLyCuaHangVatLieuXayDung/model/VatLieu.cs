using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class VatLieu
    {
        private string maVatLieu;
        private string ten;
        private double giaNhap;
        private double giaXuat;
        private string donVi;
        private DateTime ngayNhap;
        private NhaCungCap nhaCungCap;
        private string dirHinhAnh;
        private List<string> hinhAnhPaths;
        private List<(Kho kho, float soLuong)> tonKhos;
        
        public VatLieu()
        {
        }
        public VatLieu(string maVatLieu, string ten, double giaNhap, double giaXuat, string donVi, DateTime ngayNhap, NhaCungCap nhaCungCap, List<string> hinhAnhPaths, string dirHinhAnh)
        {
            this.MaVatLieu = maVatLieu;
            this.Ten = ten;
            this.GiaNhap = giaNhap;
            this.GiaXuat = giaXuat;
            this.DonVi = donVi;
            this.NgayNhap = ngayNhap;
            this.NhaCungCap = nhaCungCap;
            this.HinhAnhPaths = hinhAnhPaths;
            this.DirHinhAnh = dirHinhAnh;
        }
        public string MaVatLieu { get => maVatLieu; set => maVatLieu = value; }
        public string Ten { get => ten; set => ten = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
        public double GiaXuat { get => giaXuat; set => giaXuat = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public List<string> HinhAnhPaths { get => hinhAnhPaths; set => hinhAnhPaths = value; }
        public string DirHinhAnh { get => dirHinhAnh; set => dirHinhAnh = value; }
        internal NhaCungCap NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        internal List<(Kho kho, float soLuong)> TonKhos { get => tonKhos; set => tonKhos = value; }
    }
}
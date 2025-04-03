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
        private string hinhAnhURL;
        private NhaCungCap nhaCungCap;
        private List<string> hinhAnhs;
        private List<(Kho, float)> tonKhos;

        public VatLieu()
        {
        }

        public VatLieu(string maVatLieu, string ten, double giaNhap, double giaXuat, string donVi, 
            DateTime ngayNhap, string hinhAnhURL, NhaCungCap nhaCungCap, List<string> hinhAnhs, List<(Kho, float)> tonKhos)
        {
            this.MaVatLieu = maVatLieu;
            this.Ten = ten;
            this.GiaNhap = giaNhap;
            this.GiaXuat = giaXuat;
            this.DonVi = donVi;
            this.NgayNhap = ngayNhap;
            this.HinhAnhURL = hinhAnhURL;
            this.NhaCungCap = nhaCungCap;
            this.HinhAnhs = hinhAnhs;
            this.TonKhos = tonKhos;
        }

        public string MaVatLieu { get => maVatLieu; set => maVatLieu = value; }
        public string Ten { get => ten; set => ten = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
        public double GiaXuat { get => giaXuat; set => giaXuat = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string HinhAnhURL { get => hinhAnhURL; set => hinhAnhURL = value; }
        public List<string> HinhAnhs { get => hinhAnhs; set => hinhAnhs = value; }
        internal NhaCungCap NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        internal List<(Kho, float)> TonKhos { get => tonKhos; set => tonKhos = value; }
    }
}
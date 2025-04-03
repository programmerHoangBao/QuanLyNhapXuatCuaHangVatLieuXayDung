using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class Kho
    {
        private string maKho;
        private string ten;
        private string diaChi;

        public Kho()
        {
        }

        public Kho(string maKho, string ten, string diaChi)
        {
            this.MaKho = maKho;
            this.Ten = ten;
            this.DiaChi = diaChi;
        }

        public string MaKho { get => maKho; set => maKho = value; }
        public string Ten { get => ten; set => ten = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}

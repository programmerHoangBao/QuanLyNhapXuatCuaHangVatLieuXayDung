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
        private string tenKho;
        private string diaChi;

        public Kho()
        {
        }

        public string MaKho { get => maKho; set => maKho = value; }
        public string TenKho { get => tenKho; set => tenKho = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}

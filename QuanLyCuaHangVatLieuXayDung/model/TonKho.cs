using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class TonKho
    {
        private VatLieu vatLieu;
        private Kho kho;
        private double soLuong;

        public TonKho()
        {
            this.VatLieu = new VatLieu();
            this.Kho = new Kho();
        }

        public double SoLuong { get => soLuong; set => soLuong = value; }
        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }
        internal Kho Kho { get => kho; set => kho = value; }
    }
}

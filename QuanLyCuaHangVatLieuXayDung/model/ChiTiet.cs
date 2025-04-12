using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class ChiTiet
    {
        private VatLieu vatLieu;
        private float soLuong;
        public ChiTiet()
        {
        }
        public ChiTiet(float soLuong, VatLieu vatLieu)
        {
            SoLuong = soLuong;
            VatLieu = vatLieu;
        }

        public float SoLuong { get => soLuong; set => soLuong = value; }
        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }

    }
}

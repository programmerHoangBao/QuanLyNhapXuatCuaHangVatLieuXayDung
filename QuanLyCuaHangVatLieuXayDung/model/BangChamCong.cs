using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class BangChamCong
    {
        private NhanVien nhanVien;
        private DateTime thoiGianChamCong;
        public BangChamCong()
        {
        }

        public BangChamCong(NhanVien nhanVien, DateTime thoiGianChamCong)
        {
            this.NhanVien = nhanVien;
            this.ThoiGianChamCong = thoiGianChamCong;
        }

        public DateTime ThoiGianChamCong { get => thoiGianChamCong; set => thoiGianChamCong = value; }
        internal NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }
    }
}

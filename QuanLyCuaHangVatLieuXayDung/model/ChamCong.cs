using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class ChamCong
    {
        private NhanVien nhanVien;
        private DateTime ngayChamCong;

        public ChamCong()
        {
        }

        public DateTime NgayChamCong { get => ngayChamCong; set => ngayChamCong = value; }
        internal NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }
    }
}

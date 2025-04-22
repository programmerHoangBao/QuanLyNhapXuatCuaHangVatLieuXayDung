using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class BienLaiTraNo
    {
        public string MaBienLai { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public double TienTra { get; set; }
        public string MaPhieuGhiNo { get; set; }
        public string TenDoiTac { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public byte LoaiPhieu { get; set; } // 1: Khách hàng, 2: Cửa hàng
    }
}

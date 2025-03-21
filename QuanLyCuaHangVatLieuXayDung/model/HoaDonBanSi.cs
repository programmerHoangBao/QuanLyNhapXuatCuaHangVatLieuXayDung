using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonBanSi: HoaDon
    {
        private DoiTac khachHang = new KhachHang();
        private int phuongThucThanhToan;

        public HoaDonBanSi()
        {
        }

        public int PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        internal DoiTac KhachHang { get => khachHang; set => khachHang = value; }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn xuất";
        }
    }
}

/*
    Phương thức thanh toán:
    1. Trả một lần
    2. Trả trước
    3. Ghi nợ
 */

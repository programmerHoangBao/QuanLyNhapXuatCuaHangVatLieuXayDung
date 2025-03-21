using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonNhapHang : HoaDon
    {
        private DoiTac nhaCungCap = new NhaCungCap();
        private int phuongThucThanhToan;

        public HoaDonNhapHang()
        {
        }

        public int PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        internal DoiTac NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn nhập vật liệu";
        }
    }
}

/*
    Phương thức thanh toán:
    1. Trả một lần
    2. Trả trước
    3. Ghi nợ
 */

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
        private double giamChietKhau = 0;

        public HoaDonBanSi()
        {
        }

        public int PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public double GiamChietKhau { get => giamChietKhau; set => giamChietKhau = value; }
        internal DoiTac KhachHang { get => khachHang; set => khachHang = value; }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn xuất";
        }

        public override double TongTien()
        {
            double tongTien = 0;
            foreach (var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaXuat * vatLieu.soLuong;
            }
            return tongTien + this.giamChietKhau;
        }
    }
}

/*
    Phương thức thanh toán:
    1. Trả một lần
    2. Trả trước
    3. Ghi nợ
 */

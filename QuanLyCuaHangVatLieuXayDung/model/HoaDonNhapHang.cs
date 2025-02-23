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
        private double giamChietKhau = 0;

        public HoaDonNhapHang()
        {
        }

        public int PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public double GiamChietKhau { get => giamChietKhau; set => giamChietKhau = value; }
        internal DoiTac NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn nhập hàng";
        }

        public override double TongTien()
        {
            double tongTien = 0;
            foreach (var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaNhap * vatLieu.soLuong;
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

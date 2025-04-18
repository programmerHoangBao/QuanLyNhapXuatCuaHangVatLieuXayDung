﻿using System;
using System.Collections.Generic;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangChoNhaCungCap : PhieuTraHang
    {
        private HoaDonNhap hoaDonNhap;

        public PhieuTraHangChoNhaCungCap()
        {
        }

        public PhieuTraHangChoNhaCungCap(string maPhieu, DateTime thoiGianLap, string lyDo,
            double tongTien, List<ChiTiet> chiTiets, HoaDonNhap hoaDonNhap)
            : base(maPhieu, thoiGianLap, lyDo, tongTien, chiTiets)
        {
            this.hoaDonNhap = hoaDonNhap;
        }

        public override string loaiPhieu_toString()
        {
            return "Phiếu trả hàng cho nhà cung cấp";
        }

        public override byte loaiPhieu_toByte()
        {
            return 2;
        }

        internal HoaDonNhap HoaDonNhap
        {
            get => hoaDonNhap;
            set => hoaDonNhap = value;
        }
    }
}

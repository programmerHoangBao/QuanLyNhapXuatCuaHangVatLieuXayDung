﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class HoaDon
    {
        private int index;
        private string maHoaDon;
        private DateTime thoiGianLap;
        private double giamChietKhau = 0;
        private List<(VatLieu vatLieu, double soLuong)> dsVatLieu = new List<(VatLieu vatLieu, double soLuong)>();

        protected HoaDon()
        {
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        internal List<(VatLieu vatLieu, double soLuong)> DsVatLieu { get => dsVatLieu; set => dsVatLieu = value; }
        public int Index { get => index; set => index = value; }
        public double GiamChietKhau { get => giamChietKhau; set => giamChietKhau = value; }

        public abstract string LoaiHoaDon();
        public double TongTien()
        {
            double tongTien = 0;
            foreach (var vatLieu in this.DsVatLieu)
            {
                tongTien += vatLieu.vatLieu.DonGiaNhap * vatLieu.soLuong;
            }
            return tongTien + this.GiamChietKhau;
        }
    }
}

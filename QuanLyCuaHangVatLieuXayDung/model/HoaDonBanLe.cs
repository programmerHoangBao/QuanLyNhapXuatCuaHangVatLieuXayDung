﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class HoaDonBanLe : HoaDon
    {
        public HoaDonBanLe()
        {
        }

        public override string LoaiHoaDon()
        {
            return "Hóa đơn bán lẻ";
        }
    }
}

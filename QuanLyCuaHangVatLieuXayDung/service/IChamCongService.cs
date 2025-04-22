using System;
using System.Collections.Generic;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IChamCongService
    {
        bool ChamCong(string maNV);
        double TinhTongLuong(string maNV);
        double TinhLuongTheoThang(string maNV, int thang, int nam);
        double TinhLuongTheoNam(string maNV, int nam);
        int TinhSoNgayNghi(string maNV, int thang, int nam);
    }
}

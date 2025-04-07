using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal interface IPhieuTraHangService
    {
        void ThemPhieu(PhieuTraHang phieu);
        void XoaPhieu(string maPhieu);
        void CapNhatPhieu(PhieuTraHang phieu);
        PhieuTraHang TimPhieuTheoMa(string maPhieu);
        List<PhieuTraHang> LayTatCaPhieu();
        List<PhieuTraHang> TimPhieuTheoNgay(DateTime tuNgay, DateTime denNgay);
    }
}

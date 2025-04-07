using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service.impl;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal class PhieuTraHangService : IPhieuTraHangService
    {
        private List<PhieuTraHang> danhSachPhieuTraHang;

        public PhieuTraHangService()
        {
            danhSachPhieuTraHang = new List<PhieuTraHang>();
        }

        public void ThemPhieu(PhieuTraHang phieu)
        {
            danhSachPhieuTraHang.Add(phieu);
        }

        public void XoaPhieu(string maPhieu)
        {
            var phieu = TimPhieuTheoMa(maPhieu);
            if (phieu != null)
            {
                danhSachPhieuTraHang.Remove(phieu);
            }
        }

        public void CapNhatPhieu(PhieuTraHang phieu)
        {
            var index = danhSachPhieuTraHang.FindIndex(p => p.MaPhieu == phieu.MaPhieu);
            if (index != -1)
            {
                danhSachPhieuTraHang[index] = phieu;
            }
        }

        public PhieuTraHang TimPhieuTheoMa(string maPhieu)
        {
            return danhSachPhieuTraHang.FirstOrDefault(p => p.MaPhieu == maPhieu);
        }

        public List<PhieuTraHang> LayTatCaPhieu()
        {
            return new List<PhieuTraHang>(danhSachPhieuTraHang);
        }

        public List<PhieuTraHang> TimPhieuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return danhSachPhieuTraHang
                .Where(p => p.ThoiGianLap >= tuNgay && p.ThoiGianLap <= denNgay)
                .ToList();
        }
    }
}

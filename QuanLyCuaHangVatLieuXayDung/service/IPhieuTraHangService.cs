using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IPhieuTraHangService
    {
        bool insertphieuTraHang(PhieuTraHang phieu);
        bool deletephieuTraHang(string maPhieu);
        List<PhieuTraHang> findallphieuTraHang();
        PhieuTraHang findbyMaPhieu(string maPhieu);
        bool updatephieuTraHang(PhieuTraHang phieu);
        List<PhieuTraHang> findphieuTraHangByDay(DateTime tuNgay, DateTime denNgay);
        List<PhieuTraHang> searchByKey(string keyword);


    }
}

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
        bool insertPhieuTraHang(PhieuTraHang phieu);
        bool deletePhieuTraHang(string maPhieu);
        bool updatePhieuTraHang(PhieuTraHang phieu);
        List<PhieuTraHang> findAll();
        List<PhieuTraHang> searchByKey(string key);
        List<PhieuTraHang> findByDateRange(DateTime startDate, DateTime endDate);
        List<PhieuTraHang> findByLoaiPhieu(byte loaiPhieu);
        PhieuTraHang findByMaPhieu(string maPhieu);




    }
}

using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IChiTietHoaDonService
    {
        List<ChiTietHoaDon> findAll();

        List<ChiTietHoaDon> findByMaHoaDon(string maHoaDon);

        List<ChiTietHoaDon> findByMaVatLieu(string maVatLieu);

        bool insertChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);

        bool updateChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);

        bool deleteChiTietHoaDon(string maHoaDon, string maVatLieu);

        bool deleteByMaHoaDon(string maHoaDon);

        List<ChiTietHoaDon> searchByKey(string key);
    }
}

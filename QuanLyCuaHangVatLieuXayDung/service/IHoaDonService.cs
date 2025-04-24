using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IHoaDonService
    {
        List<HoaDon> findAll();

        HoaDon findByMaHoaDon(string maHoaDon);

        bool insertHoaDon(HoaDon hoaDon);

        bool deleteHoaDon(string maHoaDon);

        List<HoaDon> searchByKey(string key);

        List<HoaDon> findByLoaiHoaDon(byte loaiHoaDon);

        List<HoaDon> findByDateRange(DateTime startDate, DateTime endDate);

        List<HoaDon> findByDoiTac(string maDoiTac);
        //
        ChiTiet chiTietVatLieuConLaiCuaHoaDon(string maHoaDon, VatLieu vatLieu);
    }
}

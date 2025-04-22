using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IChiTietService
    {
        List<ChiTiet> GetChiTietHoaDon(string maHoaDon);
        bool insertChiTietHoaDon(string maHoaDon, ChiTiet chiTiet);
        List<ChiTiet> getChiTietTraHangByPhieu(string maPhieu);
        bool insertChiTietTraHang(string maPhieu, ChiTiet chiTiet);

    }
}

using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IDoiTacService
    {
        List<KhachHang> findAllKhachHang();
        List<NhaCungCap> findAllNhaCungCap();
        DoiTac findByMaDoiTac(string maDoiTac);
        bool insertDoiTac(DoiTac doiTac);
        bool updateDoiTac(DoiTac doiTac);
        bool deleteDoiTac(DoiTac doiTac);
        List<DoiTac> searchByKey(string key);
        List<KhachHang> searchKhachHangByKey(string key);
        List<NhaCungCap> searchNhaCungCapByKey(string key);
    }
}

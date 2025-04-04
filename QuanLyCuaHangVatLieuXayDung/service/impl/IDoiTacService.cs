using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal interface IDoiTacService
    {
        List<KhachHang> findAllKhachHang();
        List<NhaCungCap> findNhaCungCap();
        DoiTac findByMaDoiTac(string maDoiTac);
        bool insertDoiTac(DoiTac doiTac);
        bool updateDoiTac(DoiTac doiTac);
        bool deleteDoiTac(DoiTac doiTac);
        List<DoiTac> searchByKey(string key);
    }
}


using QuanLyCuaHangVatLieuXayDung.model;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface INhanVienService
    {
        bool insertnhanVien(NhanVien nv);
        bool updatenhanVien(NhanVien nv);
        bool deletenhanVien(string maNV);
        List<NhanVien> findAllNhanVien();
        
    }
}

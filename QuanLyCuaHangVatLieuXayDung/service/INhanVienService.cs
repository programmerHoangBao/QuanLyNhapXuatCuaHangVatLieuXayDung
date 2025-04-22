using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface INhanVienService
    {
        bool insertnhanVien(NhanVien nv);
        bool updatenhanVien(NhanVien nv);
        bool deletenhanVien(string maNV);
        List<NhanVien> findAllNhanVien();
        NhanVien FindByMaNhanVien(string maNhanVien);


    }
}

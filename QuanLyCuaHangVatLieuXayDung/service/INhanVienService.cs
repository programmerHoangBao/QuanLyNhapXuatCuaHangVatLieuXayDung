
using QuanLyCuaHangVatLieuXayDung.model;
using System.Data;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface INhanVienService
    {
        bool insertnhanVien(NhanVien nv);
        bool updatenhanVien(NhanVien nv);
        bool deletenhanVien(string maNV);
        DataTable getallNhanVien();
        bool ChamCong(string maNV);
        double TinhTongLuong(string maNV);
        double TinhLuongTheoThang(string maNV, int thang, int nam);
        double TinhLuongTheoNam(string maNV, int nam);

    }
}

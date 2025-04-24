using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IDoanhThuService
    {
        Dictionary<DateTime, decimal> TinhDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string loaiThoiGian);
        Dictionary<DateTime, decimal> TinhDoanhThuNhapTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string loaiThoiGian); // Thêm phương thức mới

        int TinhTongHoaDonNhap(DateTime tuNgay, DateTime denNgay);
        int TinhTongHoaDonXuat(DateTime tuNgay, DateTime denNgay);
        int TinhSoBienLaiTraNo(DateTime tuNgay, DateTime denNgay);
        int TinhSoNoChuaTra(DateTime tuNgay, DateTime denNgay);
        decimal TinhTongGiaTriHoaDonNhap(DateTime tuNgay, DateTime denNgay);
        decimal TinhTongGiaTriHoaDonXuat(DateTime tuNgay, DateTime denNgay);
        decimal TinhTongGiaTriNoChuaTra(DateTime tuNgay, DateTime denNgay);
        int TinhSoDonTraHang(DateTime tuNgay, DateTime denNgay);
        decimal TinhTongTienTraNo(DateTime tuNgay, DateTime denNgay);
    }
}

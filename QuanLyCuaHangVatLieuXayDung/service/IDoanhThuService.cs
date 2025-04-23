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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class HoaDon
    {
        protected string maHoaDon;
        protected DateTime thoiGianLap;
        protected string diaChi;
        protected double tienGiam;
        protected byte phuongThucThanhToan;
        protected List<(VatLieu vatLieu, float soLuong)> chiTiets;
        protected HoaDon()
        {
        }

        protected HoaDon(string maHoaDon, DateTime thoiGianLap, string diaChi, 
            double tienGiam, byte phuongThucThanhToan, List<(VatLieu vatLieu, float soLuong)> chiTiets)
        {
            this.maHoaDon = maHoaDon;
            this.thoiGianLap = thoiGianLap;
            this.diaChi = diaChi;
            this.tienGiam = tienGiam;
            this.phuongThucThanhToan = phuongThucThanhToan;
            this.chiTiets = chiTiets;
        }

        protected string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        protected DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        protected string DiaChi { get => diaChi; set => diaChi = value; }
        protected double TienGiam { get => tienGiam; set => tienGiam = value; }
        protected byte PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        protected double TienThanhToan { get => tienThanhToan; set => tienThanhToan = value; }
        protected List<(VatLieu vatLieu, float soLuong)> ChiTiets { get => chiTiets; set => chiTiets = value; }

        protected abstract string LoaiHoaDon();
        protected string PhuongThucThanhToan_ToString()
        {
            if (this.phuongThucThanhToan == 1)
            {
                return "Trả một lần";
            }
            else if (this.phuongThucThanhToan == 2)
            {
                return "Trả trước";
            }
            return "Ghi nợ";
        }
    }
}

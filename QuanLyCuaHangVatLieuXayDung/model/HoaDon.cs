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
        protected double tienThanhToan;
        protected byte phuongThucThanhToan;
        protected List<(VatLieu vatLieu, float soLuong)> chiTiets;
        protected HoaDon()
        {
        }
        protected HoaDon(string maHoaDon, DateTime thoiGianLap, string diaChi,
            double tienGiam, byte phuongThucThanhToan, double tienThanhToan, List<(VatLieu, float)> chiTiets)
        {
            this.maHoaDon = maHoaDon;
            this.thoiGianLap = thoiGianLap;
            this.diaChi = diaChi;
            this.tienGiam = tienGiam;
            this.phuongThucThanhToan = phuongThucThanhToan;
            this.tienThanhToan = tienThanhToan;
            this.chiTiets = chiTiets;
        }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public double TienGiam { get => tienGiam; set => tienGiam = value; }
        public byte PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public double TienThanhToan { get => tienThanhToan; set => tienThanhToan = value; }
        public List<(VatLieu vatLieu, float soLuong)> ChiTiets { get => chiTiets; set => chiTiets = value; }

        public abstract byte loaiHoaDon_toByte();
        public abstract string loaiHoaDon_toString();
        public string phuongThucThanhToan_toString()
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

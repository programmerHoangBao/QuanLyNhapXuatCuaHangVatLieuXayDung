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
        private DoiTac doiTac;
        protected string diaChi;
        protected double tienGiam;
        protected double tienThanhToan;
        protected byte phuongThucThanhToan;
        protected List<ChiTiet> chiTiets;
        protected HoaDon()
        {
        }
        protected HoaDon(string maHoaDon, DateTime thoiGianLap, DoiTac doiTac, string diaChi,
            double tienGiam, byte phuongThucThanhToan, double tienThanhToan, List<ChiTiet> chiTiets)
        {
            this.maHoaDon = maHoaDon;
            this.thoiGianLap = thoiGianLap;
            this.doiTac = doiTac;
            this.diaChi = diaChi;
            this.tienGiam = tienGiam;
            this.phuongThucThanhToan = phuongThucThanhToan;
            this.tienThanhToan = tienThanhToan;
            this.ChiTiets = chiTiets;
        }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public double TienGiam { get => tienGiam; set => tienGiam = value; }
        public byte PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public double TienThanhToan { get => tienThanhToan; set => tienThanhToan = value; }
        public List<ChiTiet> ChiTiets { get => chiTiets; set => chiTiets = value; }
        public DoiTac DoiTac { get => doiTac; set => doiTac = value; }

        public abstract byte loaiHoaDon_toByte();
        public abstract string loaiHoaDon_toString();
        public abstract double tinhTongTien();
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

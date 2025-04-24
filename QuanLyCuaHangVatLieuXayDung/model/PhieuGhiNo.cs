using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class PhieuGhiNo
    {
        protected string maPhieu;
        protected string maHoaDon;
        protected DateTime thoiGianLap;
        protected DateTime thoiGianTra;
        protected double tienNo;
        protected bool trangThai;
        private DoiTac doiTac;
        private HoaDon hoaDon;
        protected PhieuGhiNo()
        {
        }
        protected PhieuGhiNo(string maPhieu, DateTime thoiGianLap, DateTime thoiGianTra, double tienNo, bool trangThai, DoiTac doiTac, HoaDon hoaDon)
        {
            this.maPhieu = maPhieu;
            this.thoiGianLap = thoiGianLap;
            this.thoiGianTra = thoiGianTra;
            this.tienNo = tienNo;
            this.trangThai = trangThai;
            this.doiTac = doiTac;
            this.hoaDon = hoaDon;
        }
        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public DateTime ThoiGianTra { get => thoiGianTra; set => thoiGianTra = value; }
        public double TienNo { get => tienNo; set => tienNo = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public DoiTac DoiTac { get => doiTac; set => doiTac = value; }
        public HoaDon HoaDon { get => hoaDon; set => hoaDon = value; }

        public abstract byte loaiPhieu_toByte();
        public abstract string loaiPhieu_toString();
    }
}

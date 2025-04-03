using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal abstract class PhieuGhiNo
    {
        private string maPhieu;
        private DateTime thoiGianLap;
        private DateTime thoiGianTra;
        private double tienNo;
        private bool trangThai;
        protected PhieuGhiNo()
        {
        }
        protected PhieuGhiNo(string maPhieu, DateTime thoiGianLap, DateTime thoiGianTra, double tienNo, bool trangThai)
        {
            this.MaPhieu = maPhieu;
            this.ThoiGianLap = thoiGianLap;
            this.ThoiGianTra = thoiGianTra;
            this.TienNo = tienNo;
            this.TrangThai = trangThai;
        }
        protected string MaPhieu { get => maPhieu; set => maPhieu = value; }
        protected DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        protected DateTime ThoiGianTra { get => thoiGianTra; set => thoiGianTra = value; }
        protected double TienNo { get => tienNo; set => tienNo = value; }
        protected bool TrangThai { get => trangThai; set => trangThai = value; }
        protected abstract string LoaiPhieu();
    }
}

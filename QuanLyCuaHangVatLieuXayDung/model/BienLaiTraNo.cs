using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class BienLaiTraNo
    {
        private string maBienLai;
        private DateTime thoiGianLap;
        private double tienTra;
        private PhieuGhiNo phieuGhiNo;
        public BienLaiTraNo()
        {
        }
        public BienLaiTraNo(string maBienLai, DateTime thoiGianLap, double tienTra, PhieuGhiNo phieuGhiNo)
        {
            this.MaBienLai = maBienLai;
            this.ThoiGianLap = thoiGianLap;
            this.TienTra = tienTra;
            this.PhieuGhiNo = phieuGhiNo;
        }

        public string MaBienLai { get => maBienLai; set => maBienLai = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public double TienTra { get => tienTra; set => tienTra = value; }
        internal PhieuGhiNo PhieuGhiNo { get => phieuGhiNo; set => phieuGhiNo = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class ChiPhiPhatSinh
    {
        private int index;
        private string maChiPhi;
        private DateTime ngayLap;
        private string noiDung;
        private double soTien;

        public ChiPhiPhatSinh()
        {
        }

        public ChiPhiPhatSinh(int index, string maChiPhi, DateTime ngayLap, string noiDung, double soTien)
        {
            this.Index = index;
            this.MaChiPhi = maChiPhi;
            this.NgayLap = ngayLap;
            this.NoiDung = noiDung;
            this.SoTien = soTien;
        }

        public int Index { get => index; set => index = value; }
        public string MaChiPhi { get => maChiPhi; set => maChiPhi = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public double SoTien { get => soTien; set => soTien = value; }
    }
}

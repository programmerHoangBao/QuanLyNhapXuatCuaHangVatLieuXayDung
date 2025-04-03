using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class ChiPhiPhatSinh
    {
        private string maChiPhi;
        private byte loaiChiPhi;
        private DateTime thoiGianLap;
        private string moTa;
        private double chiPhi;
        public ChiPhiPhatSinh()
        {
        }

        public ChiPhiPhatSinh(string maChiPhi, byte loaiChiPhi, DateTime thoiGianLap, string moTa, double chiPhi)
        {
            this.MaChiPhi = maChiPhi;
            this.LoaiChiPhi = loaiChiPhi;
            this.ThoiGianLap = thoiGianLap;
            this.MoTa = moTa;
            this.ChiPhi = chiPhi;
        }

        public string MaChiPhi { get => maChiPhi; set => maChiPhi = value; }
        public byte LoaiChiPhi { get => loaiChiPhi; set => loaiChiPhi = value; }
        public DateTime ThoiGianLap { get => thoiGianLap; set => thoiGianLap = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public double ChiPhi { get => chiPhi; set => chiPhi = value; }

        public string loaiChiPhi_ToString()
        {
            switch (this.loaiChiPhi)
            {
                case 1:
                    return "Chi phí dịch vụ";
                case 2:
                    return "Chi phí vận chuyển";
                case 3:
                    return "Chi phí nhân viên";
                case 4:
                    return "Chi phí đối tác";
                default:
                    return "Chi phí khác";
            }
        }
    }
}

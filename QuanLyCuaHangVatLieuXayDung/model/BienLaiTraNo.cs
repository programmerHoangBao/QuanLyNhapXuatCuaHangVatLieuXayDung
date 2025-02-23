using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class BienLaiTraNo
    {
        private int index;
        private string maBienLai;
        private DateTime NgayLap;
        private double soTienTra;
        private TienNo khoanNo = new TienNo();
        private string loaiBienLai;

        public BienLaiTraNo()
        {
        }

        public string MaBienLai { get => maBienLai; set => maBienLai = value; }
        public DateTime NgayLap1 { get => NgayLap; set => NgayLap = value; }
        public double SoTienTra { get => soTienTra; set => soTienTra = value; }
        /// <summary>
        /// "BLTNCKH": Biên lai tra nợ của khách hàng, "BLTNCCH" Biên lai trả nợ của cửa hàng cho nhà cung cấp
        public string LoaiBienLai { get => loaiBienLai; set => loaiBienLai = value; }
        public int Index { get => index; set => index = value; }
        internal TienNo KhoanNo { get => khoanNo; set => khoanNo = value; }
    }
}

/*
    Loại biên lai: 
    1. "BLTNCKH": Biên lai tra nợ của khách hàng
    2. "BLTNCCH" Biên lai trả nợ của cửa hàng cho nhà cung cấp
 */

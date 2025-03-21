using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangTuKhachHang : PhieuTraHang
    {
        public PhieuTraHangTuKhachHang()
        {
        }

        public override string LoaiHoaDon()
        {
            return "Phiếu trả hàng từ khách hàng";
        }
    }
}

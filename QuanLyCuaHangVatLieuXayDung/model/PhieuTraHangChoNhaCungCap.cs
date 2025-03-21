using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class PhieuTraHangChoNhaCungCap : PhieuTraHang
    {
        public PhieuTraHangChoNhaCungCap()
        {
        }
        public override string LoaiHoaDon()
        {
            return "Phiếu trả hàng cho nhà cung cấp";
        }
    }
}

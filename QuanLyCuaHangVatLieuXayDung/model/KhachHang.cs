using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class KhachHang : DoiTac
    {
        public KhachHang()
        {
        }

        public override string LoaiDoiTac()
        {
            return "Khách hàng";
        }
    }
}

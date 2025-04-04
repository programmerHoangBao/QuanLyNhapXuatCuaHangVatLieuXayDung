using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class NhaCungCap : DoiTac
    {
        public NhaCungCap()
        {
        }

        public NhaCungCap(string maDoiTac, string ten, string soDienThoai, string diaChi, string email, string nganHang, string soTaiKhoan, string qR) : base(maDoiTac, ten, soDienThoai, diaChi, email, nganHang, soTaiKhoan, qR)
        {
        }

        public override byte loaiDoiTac_toByte()
        {
            return 2;
        }

        public override string loaiDoiTac_toString()
        {
            return "Nhà cung cấp";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    /// <summary>
    /// model ChiTiet đại diện cho quan hệ ChiTietHoaDon và ChiTietTraHang trong database
    /// ChiTiet là một lớp dùng để lưu trữ thông tin chi tiết của một hóa đơn hoặc phiếu trả hàng.
    /// Thông tin chi tiết bao gồm vật liệu (VatLieu) và số lượng vật liệu (float).
    /// </summary>
    internal class ChiTiet
    {
        private VatLieu vatLieu;
        private float soLuong;
        public ChiTiet()
        {
        }
        public ChiTiet(VatLieu vatLieu, float soLuong)
        {
            SoLuong = soLuong;
            VatLieu = vatLieu;
        }

        public float SoLuong { get => soLuong; set => soLuong = value; }
        public VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }
    }
}

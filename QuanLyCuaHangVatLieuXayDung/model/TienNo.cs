using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class TienNo
    {
        private int index;
        private string maTienNo;
        private DateTime ngayNo;
        private int thoiGiaThanhToan;
        private double soTienNo;
        private string loaiNo;
        private HoaDon hoaDon;
        private bool trangThai;

        public TienNo()
        {
        }

        public string MaTienNo { get => maTienNo; set => maTienNo = value; }
        public DateTime NgayNo { get => ngayNo; set => ngayNo = value; }
        public int ThoiGiaThanhToan { get => thoiGiaThanhToan; set => thoiGiaThanhToan = value; }
        public double SoTienNo { get => soTienNo; set => soTienNo = value; }
        /// <summary>
        /// "NNCC": Cửa hàng nợ nhà cung cấp, "NCKH": khách hàng nợ cửa hàng
        public string LoaiNo { get => loaiNo; set => loaiNo = value; }
        public int Index { get => index; set => index = value; }
        internal HoaDon HoaDon { get => hoaDon; set => hoaDon = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}

/*
    Loại nợ (loaiNo):
    - "NNCC": Cửa hàng nợ nhà cung cấp
    - "NCKH": khách hàng nợ cửa hàng
 */

/*
    Thuộc tính trạng thái:
        - true: sẽ hiển thị cho actor
        - false: sẽ không hiển thị cho actor thấy
 */
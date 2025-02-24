using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class VatLieu
    {
        private int index;
        private string maVatLieu;
        private string tenVatLieu;
        private double donGiaNhap;
        private double donGiaXuat;
        private string donVi;
        private string hinhAnhURL;
        private DoiTac nhaCungCap = new NhaCungCap();
        private bool trangThai;

        public VatLieu()
        {
        }

        public string MaVatLieu { get => maVatLieu; set => maVatLieu = value; }
        public string TenVatLieu { get => tenVatLieu; set => tenVatLieu = value; }
        public double DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        public double DonGiaXuat { get => donGiaXuat; set => donGiaXuat = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public string HinhAnhURL { get => hinhAnhURL; set => hinhAnhURL = value; }
        public int Index { get => index; set => index = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        internal DoiTac NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
    }
}

/*
    Thuộc tính trạng thái:
        - true: sẽ hiển thị cho actor
        - false: sẽ không hiển thị cho actor thấy
 */
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ChonSoLuongVatLieu : Form
    {
        private VatLieu vatLieu;
        private byte loaiHoaDon = 0;
        private float maxSoLuongTra = 0; /*Dành cho việc kiểm tra vật liệu khi trả hàng*/

        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }
        public byte LoaiHoaDon { get => loaiHoaDon; set => loaiHoaDon = value; }
        public float MaxSoLuongTra { get => maxSoLuongTra; set => maxSoLuongTra = value; }

        public Form_ChonSoLuongVatLieu()
        {
            InitializeComponent();
        }
        private void Form_ChonSoLuongVatLieu_Load(object sender, EventArgs e)
        {
            this.ShowSoLuongVatLieu();
        }
        public void ShowSoLuongVatLieu()
        {
            string filePath = "";
            if (this.loaiHoaDon == 1)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonxuat.json");
            }
            else if (this.loaiHoaDon == 2)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonnhap.json");
            }
            else if (this.loaiHoaDon == 0 && this.MaxSoLuongTra <= 0)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "phieutrahang", "chitietphieutrahang.json");
            }
            float soLuong = 0;
            FileUtility fileUtility = new FileUtility();
            if (fileUtility.IsFileExists(filePath))
            {
                List<ChiTiet> chiTiets = fileUtility.ReadObjectsFromJsonFile<ChiTiet>(filePath);
                foreach (ChiTiet chiTiet in chiTiets)
                {
                    if (chiTiet.VatLieu.MaVatLieu == this.vatLieu.MaVatLieu)
                    {
                        soLuong = chiTiet.SoLuong;
                        break;
                    }
                }
            }
            this.txtSoLuong.Text = soLuong.ToString();
        }
        public float GetSoLuong()
        {
            if (this.txtSoLuong.Text == "" || float.Parse(this.txtSoLuong.Text) <= 0)
            {
                return 0;
            }
            return float.Parse(this.txtSoLuong.Text);
        }
        public void SetSoLuong(float soLuong)
        {
            this.txtSoLuong.Text = soLuong.ToString();
        }
        public bool checkSoLuongVatLieuCuaHoaDonXuat()
        {
            if (this.loaiHoaDon == 1)
            {
                if (this.vatLieu.SoLuong >= this.GetSoLuong())
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkSoLuongVatLieuTraHang()
        {
            if (this.MaxSoLuongTra < this.GetSoLuong() && this.loaiHoaDon == 0)
            {
                return false;
            }
            return true;
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép điều khiển (backspace, delete, ...)
            if (!char.IsControl(e.KeyChar))
            {
                // Chỉ cho phép số và dấu '.'
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Không cho nhập
                }

                // Không cho nhập nhiều hơn một dấu '.'
                if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.txtSoLuong.Text, out float result) && this.txtSoLuong.Text != "")
            {
                MessageBox.Show("Giá trị không hợp lệ! Vui lòng nhập số thực.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSoLuong.Focus();
            }
            else if (!this.checkSoLuongVatLieuCuaHoaDonXuat())
            {
                this.txtSoLuong.Text = this.vatLieu.SoLuong.ToString();
            }
            else if (!this.checkSoLuongVatLieuTraHang())
            {
                this.txtSoLuong.Text = this.MaxSoLuongTra.ToString();
            }
            else if (this.txtSoLuong.Text == "")
            {
                this.txtSoLuong.Text = "0";
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            float soLuong = this.GetSoLuong();
            soLuong++;
            if (soLuong > this.VatLieu.SoLuong && this.LoaiHoaDon == 1)
            {
                soLuong = this.vatLieu.SoLuong;
            }
            else if (soLuong > this.MaxSoLuongTra && this.loaiHoaDon == 0)
            {
                soLuong = this.MaxSoLuongTra;
            }
            this.txtSoLuong.Text = soLuong.ToString();
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            float soLuong = this.GetSoLuong();
            soLuong--;
            if (soLuong < 0)
            {
                soLuong = 0;
            }
            this.txtSoLuong.Text = soLuong.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string filePath = "";
            if (this.loaiHoaDon == 1)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonxuat.json");
            }
            else if (this.loaiHoaDon == 2)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonnhap.json");
            }
            else if (this.loaiHoaDon == 0 && this.MaxSoLuongTra <= 0)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "phieutrahang", "chitietphieutrahang.json");
            }
            FileUtility fileUtility = new FileUtility();
            VatLieu vatLieu = this.vatLieu;
            if (!fileUtility.IsFileExists(filePath))
            {
                fileUtility.WriteObjectJsonFile(vatLieu, filePath);
            }
            else
            {
                if (!fileUtility.ExistsObjectInJsonFile(vatLieu, filePath))
                {
                    fileUtility.AppendObjectToJsonFile(vatLieu, filePath);
                }
                else
                {
                    fileUtility.UpdateObjectInJsonFile(vatLieu, filePath);
                }
            }
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string filePath = "";
            if (this.loaiHoaDon == 1)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonxuat.json");
            }
            else if (this.loaiHoaDon == 2)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "hoadon", "chitiethoadonnhap.json");
            }
            else if (this.loaiHoaDon == 0 && this.MaxSoLuongTra <= 0)
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "temp", "phieutrahang", "chitietphieutrahang.json");
            }
            FileUtility fileUtility = new FileUtility();
            if (fileUtility.IsFileExists(filePath))
            {
                if (fileUtility.ExistsObjectInJsonFile(this.vatLieu, filePath))
                {
                    fileUtility.RemoveObjectFromJsonFile(this.vatLieu, filePath);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy vật liệu trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

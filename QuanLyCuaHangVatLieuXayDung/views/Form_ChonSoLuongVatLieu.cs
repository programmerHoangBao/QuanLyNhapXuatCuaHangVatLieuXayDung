using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ChonSoLuongVatLieu : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        private VatLieu vatLieu;
        private byte loaiHoaDon = 0;

        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }
        public byte LoaiHoaDon { get => loaiHoaDon; set => loaiHoaDon = value; }

        public Form_ChonSoLuongVatLieu()
        {
            InitializeComponent();
        }
        private void Form_ChonSoLuongVatLieu_Load(object sender, EventArgs e)
        {
            if (this.loaiHoaDon == 0)
            {
                this.btnPlus.Enabled = false;
            }
            //else
            //{
            //    this.ShowSoLuongVatLieu();
            //}
        }
        public void ShowSoLuongVatLieu()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.loaiHoaDon == 1)
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonxuat.json");
            }
            else if (this.loaiHoaDon == 2)
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhap.json");
            }
            else if (this.loaiHoaDon == 0)
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahang.json");
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
        //Lấy ra số lượng vật liệu
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
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.loaiHoaDon == 1)
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonxuat.json");
            }
            else if (this.loaiHoaDon == 2)
            {
                if (this.vatLieuService.findByMaVatLieu(this.vatLieu.MaVatLieu) != null)
                {
                    filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieucu.json");
                }
                else
                {
                    filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");
                }
            }
            else if (this.loaiHoaDon == 0)
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahang.json");
            }

            FileUtility fileUtility = new FileUtility();
            ChiTiet chiTiet = new ChiTiet(this.vatLieu, this.GetSoLuong());
            Func<JsonElement, bool> matchPredicate = (ChiTiet) =>
            {
                if (ChiTiet.TryGetProperty("VatLieu", out var vatLieuProperty))
                {
                    return vatLieuProperty.GetProperty("MaVatLieu").ToString() == this.vatLieu.MaVatLieu;
                }
                return false;
            };


            if (!fileUtility.IsExistsObjectInJsonFile<ChiTiet>(filePath, matchPredicate))
            {
                fileUtility.AppendObjectJsonFile(chiTiet, filePath);
            }
            else
            {
                fileUtility.UpdateObjectInJsonFileById(chiTiet, filePath, matchPredicate);
            }
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.loaiHoaDon == 1)
            {
                filePath = Path.Combine(projectDirectory,"temp", "hoadon", "chitiethoadonxuat.json");
            }
            else if (this.loaiHoaDon == 2)
            {
                if (this.vatLieuService.findByMaVatLieu(this.vatLieu.MaVatLieu) != null)
                {
                    filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieucu.json");
                }
                else
                {
                    filePath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");
                }
            }
            else if (this.loaiHoaDon == 0)
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahang.json");
            }
            FileUtility fileUtility = new FileUtility();
            Func<JsonElement, bool> matchPredicate = (VatLieu) =>
            {
                return VatLieu.GetProperty("MaVatLieu").ToString() == this.vatLieu.MaVatLieu;
            };
            if (fileUtility.IsFileExists(filePath))
            {
                if (!fileUtility.RemoveObjectFromJsonFile<VatLieu>(filePath, matchPredicate))
                {
                    MessageBox.Show("Không tìm thấy vật liệu trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

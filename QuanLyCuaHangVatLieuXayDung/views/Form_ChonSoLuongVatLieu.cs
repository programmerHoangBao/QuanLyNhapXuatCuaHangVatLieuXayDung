using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ChonSoLuongVatLieu : Form
    {
        private VatLieu vatLieu;
        private byte loaiHoaDon;
        public event EventHandler btnOkClick;

        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }
        public byte LoaiHoaDon { get => loaiHoaDon; set => loaiHoaDon = value; }

        public Form_ChonSoLuongVatLieu()
        {
            InitializeComponent();
            this.txtSoLuong.Text = "0";
            this.btnOk.Click += (s, e) =>
            {
                this.btnOkClick?.Invoke(s, e);
            };
        }
        private void Form_ChonSoLuongVatLieu_Load(object sender, EventArgs e)
        {

        }
        public float GetSoLuong()
        {
            return float.Parse(this.txtSoLuong.Text);
        }
        public void SetSoLuong(float soLuong)
        {
            this.txtSoLuong.Text = soLuong.ToString();
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
            else if (this.loaiHoaDon == 1 && this.vatLieu.totalSoLuong() < float.Parse(this.txtSoLuong.Text))
            {
                this.txtSoLuong.Text = this.vatLieu.totalSoLuong().ToString();
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
            if (soLuong > this.VatLieu.totalSoLuong() && this.LoaiHoaDon == 1)
            {
                soLuong = this.vatLieu.totalSoLuong();
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
    }
}

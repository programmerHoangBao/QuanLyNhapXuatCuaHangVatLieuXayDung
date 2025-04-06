using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
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
    public partial class UserControlShowVatLieu : UserControl
    {
        private VatLieu vatLieu;
        public UserControlShowVatLieu()
        {
            InitializeComponent();
            this.VatLieu = null;
        }

        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }

        private void UserControlShowVatLieu_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Hiển thị thông tin về vật liệu lên giao diện người dùng.
        /// </summary>
        /// <param name="loaiVatLieu">
        /// Loại vật liệu cần hiển thị: 
        /// - 1: Hiển thị giá xuất.
        /// - 2: Hiển thị giá nhập.
        /// </param>
        /// <remarks>
        /// Hàm sẽ hiển thị thông tin gồm: 
        /// - Tên vật liệu (VatLieu.Ten).
        /// - Số lượng tồn kho (TonKhos, nếu có).
        /// - Giá xuất hoặc giá nhập, tùy thuộc vào tham số loaiVatLieu.
        /// </remarks>
        public void ShowVatLieu(byte loaiVatLieu = 1)
        {
            if (loaiVatLieu < 1 || loaiVatLieu > 2)
            {
                MessageBox.Show("Loại vật liệu không hợp lệ!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.labelName.Text = "Tên: " + this.VatLieu.Ten;
            float soLuong = 0;
            if (this.VatLieu.TonKhos != null)
            {
                foreach (var item in this.VatLieu.TonKhos)
                {
                        soLuong += item.soLuong;
                }
            }
            this.labelQuantity.Text = "Số lượng: " + soLuong.ToString() + " " + this.VatLieu.DonVi;
            if (loaiVatLieu == 1)
            {
                this.labelPrice.Text = "Giá xuất: " + new StringUtility().ConvertToVietnameseCurrency(this.VatLieu.GiaXuat) 
                    + "/" + this.VatLieu.DonVi;
            }
            else
            {
                this.labelPrice.Text = "Giá nhập: " + new StringUtility().ConvertToVietnameseCurrency(this.VatLieu.GiaNhap) 
                    + "/" + this.VatLieu.DonVi;
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            //return this.VatLieu;
        }
    }
}

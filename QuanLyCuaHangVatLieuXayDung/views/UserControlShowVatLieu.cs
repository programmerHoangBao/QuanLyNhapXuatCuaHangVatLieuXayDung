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
        public event EventHandler btnTransactionClick;
        public UserControlShowVatLieu()
        {
            InitializeComponent();
            this.VatLieu = null;
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.btnTransaction.Click += (s, e) =>
            {
                this.btnTransactionClick?.Invoke(s, e);
            };
        }

        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }

        private void UserControlShowVatLieu_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Hiển thị thông tin về vật liệu lên giao diện người dùng.
        /// </summary>
        /// <param name="loaiHoaDon">
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
        public void ShowVatLieu(byte loaiHoaDon = 1)
        {
            if (loaiHoaDon < 1 || loaiHoaDon > 2)
            {
                MessageBox.Show("Loại vật liệu không hợp lệ!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.labelId.Text = "Mã: " + this.VatLieu.MaVatLieu;
            this.labelName.Text = "Tên: " + this.VatLieu.Ten;
            this.labelQuantity.Text = "Số lượng: " + this.VatLieu.SoLuong.ToString() + " " + this.VatLieu.DonVi;
            if (loaiHoaDon == 1)
            {
                this.labelPrice.Text = "Giá xuất: " + new StringUtility().ConvertToVietnameseCurrency(this.VatLieu.GiaXuat)
                    + "/" + this.VatLieu.DonVi;
            }
            else
            {
                this.labelPrice.Text = "Giá nhập: " + new StringUtility().ConvertToVietnameseCurrency(this.VatLieu.GiaNhap)
                    + "/" + this.VatLieu.DonVi;
            }
            if (this.VatLieu.GetDanhSachHinhAnhVatLieus().Count > 0)
            {
                this.pictureBoxImage.ImageLocation = this.VatLieu.GetDanhSachHinhAnhVatLieus()[0];
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form_ChiTietVatlieu form_ChiTietVatlieu = new Form_ChiTietVatlieu();
            form_ChiTietVatlieu.VatLieu = this.VatLieu;
            form_ChiTietVatlieu.ShowDialog();
        }
    }
}

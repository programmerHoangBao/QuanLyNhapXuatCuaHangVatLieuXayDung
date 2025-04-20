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
    public partial class Form_ChiTietVatlieu : Form
    {
        private VatLieu vatLieu;
        List<string> imagePaths = new List<string>();
        int index = 0;

        internal VatLieu VatLieu { get => vatLieu; set => vatLieu = value; }

        public Form_ChiTietVatlieu()
        {
            InitializeComponent();
        }

        private void Form_ChiTietVatlieu_Load(object sender, EventArgs e)
        {
            ShowVatLieu();
        }
        private void ShowVatLieu()
        {
            this.txtMaVatLieu.Text = this.vatLieu.MaVatLieu;
            this.txtTenVatlieu.Text = this.vatLieu.Ten;
            this.txtDonVi.Text = this.vatLieu.DonVi;
            this.txtGiaNhap.Text = new StringUtility().ConvertToVietnameseCurrency(this.vatLieu.GiaNhap);
            this.txtGiaXuat.Text = new StringUtility().ConvertToVietnameseCurrency(this.vatLieu.GiaXuat);
            if (this.VatLieu.NhaCungCap != null)
            {
                this.txtNhaCungCap.Text = this.vatLieu.NhaCungCap.Ten;
            }
            this.txtSoLuong.Text = this.vatLieu.SoLuong.ToString();
            if (!string.IsNullOrEmpty(this.vatLieu.DirHinhAnh))
            {
                this.imagePaths = new FileUtility().GetImagePathsFromFolder(this.vatLieu.DirHinhAnh);
                if (this.imagePaths.Count > 0)
                {
                    this.pictureBoxShowImage.Image = Image.FromFile(imagePaths[index]);
                }
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            int count = this.imagePaths.Count;
            if (count <= 0)
            {
                return;
            }
            index += 1;
            if (index >= count)
            {
                index = 0;
            }
            this.pictureBoxShowImage.Image = Image.FromFile(imagePaths[index]);
        }

        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            int count = this.imagePaths.Count;
            if (count <= 0)
            {
                return;
            }
            if (index - 1 < 0)
            {
                index = 0;
            }
            else
            {
                index -= 1;
            }
            this.pictureBoxShowImage.Image = Image.FromFile(imagePaths[index]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

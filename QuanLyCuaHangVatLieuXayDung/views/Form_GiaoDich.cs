using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
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
    public partial class Form_GiaoDich : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        public Form_GiaoDich()
        {
            InitializeComponent();
        }

        private void Form_GiaoDich_Load(object sender, EventArgs e)
        {
            this.radioButtonXuatHang.Checked = true;
            this.btnAnHoaDon.Enabled = false;
            this.labelDate.Text = DateTime.Now.ToString();
            this.panelHoaDon.Hide();
            this.panelVatLieu.Size = new Size(this.panelHoaDon.Size.Width, 350);
            this.comboBoxPhuongThucThanhToan.SelectedIndex = 0;
            this.ShowVatLieus();
        }
        private void ShowVatLieus()
        {
            this.flowLayoutPanelShowVatLieu.Controls.Clear();
            List<VatLieu> vatLieus = this.vatLieuService.findAll();
            UserControlShowVatLieu userControl = null;
            foreach (VatLieu vatLieu in vatLieus)
            {
                userControl = new UserControlShowVatLieu();
                userControl.VatLieu = vatLieu;
                userControl.Size = new Size(200, 280);
                if (this.radioButtonXuatHang.Checked && vatLieu.totalSoLuong() > 0)
                {
                    userControl.ShowVatLieu(1);
                }
                else if (this.radioButtonNhapHang.Checked)
                {
                    userControl.ShowVatLieu(2);
                }
                if (userControl != null)
                {
                    this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                }
            }
        }

        private void radioButtonXuatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonXuatHang.Checked)
            {
                this.ShowVatLieus();
                this.labelTitle.Text = "Hóa đơn xuất";
            }
        }

        private void radioButtonNhapHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonNhapHang.Checked)
            {
                this.ShowVatLieus();
                this.labelTitle.Text = "Hóa đơn nhập";
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Show();
            this.btnAnHoaDon.Enabled = true;
        }

        private void btnAnHoaDon_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Hide();
            this.btnAnHoaDon.Enabled = false;
        }
    }
}

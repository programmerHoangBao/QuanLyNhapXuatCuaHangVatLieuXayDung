using QuanLyCuaHangVatLieuXayDung.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_TrangChu : Form
    {
        private Form formChild;
        public Form_TrangChu()
        {
            InitializeComponent();
        }

        private void Form_TrangChu_Load(object sender, EventArgs e)
        {
            this.btnGiaoDich_Click(this.btnGiaoDich, EventArgs.Empty);
        }

        private void OpenFormChild(Form formChild)
        {
            this.panelBody.Controls.Clear();
            this.formChild = new Form();
            this.formChild = formChild;
            this.formChild.TopLevel = false;
            this.panelBody.Controls.Add(this.formChild);
            this.formChild.Dock = DockStyle.Fill;
            this.formChild.FormBorderStyle = FormBorderStyle.None;
            this.formChild.Show();
        }
        private void SetCollorAllButton()
        {
            for (int i = 0; i < this.panelOptional.Controls.Count; i++)
            {
                var control = this.panelOptional.Controls[i];
                if (control is Button)
                {
                    control.BackColor = Color.MediumSpringGreen;
                }
            }
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            this.SetCollorAllButton();
            this.btnGiaoDich.BackColor = Color.FromArgb(255, 165, 0);
            this.OpenFormChild(new Form_GiaoDich());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.SetCollorAllButton();
            this.btnNhanVien.BackColor = Color.FromArgb(255, 165, 0);
            this.OpenFormChild(new Form_NhanVien());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            this.SetCollorAllButton();
            this.btnTaiKhoan.BackColor = Color.FromArgb(255, 165, 0);
            this.OpenFormChild(new Form_TaiKhoan());

        }
    }
}

using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_SelectVatLieu : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        private FileUtility fileUtility = new FileUtility();
        private Form_ChonSoLuongVatLieu form_ChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
        private byte loaiHoaDon = 1;
        public byte LoaiHoaDon { get => loaiHoaDon; set => loaiHoaDon = value; }

        public Form_SelectVatLieu()
        {
            InitializeComponent();
        }

        private void Form_InsertVatLieu_Load(object sender, EventArgs e)
        {
            this.ShowVatLieu();
        }
        private void ShowVatLieu()
        {
            try
            {
                List<VatLieu> vatLieus = vatLieuService.findAll();
                this.dataGridViewShowVatLieu.Rows.Clear();
                foreach (VatLieu vatLieu in vatLieus)
                {
                    string nhaCungCapTen = vatLieu.NhaCungCap != null ? vatLieu.NhaCungCap.Ten : "Unknown";
                    this.dataGridViewShowVatLieu.Rows.Add(vatLieu.MaVatLieu, vatLieu.Ten, vatLieu.GiaXuat, vatLieu.GiaNhap, vatLieu.DonVi, nhaCungCapTen, vatLieu.SoLuong);
                }
                DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)this.dataGridViewShowVatLieu.Columns["btnChon"];
                buttonColumn.Text = "Chọn"; // Đặt văn bản cho nút
                //Set BackColor cho các button
                buttonColumn.DefaultCellStyle.BackColor = Color.LightBlue; // Màu nền cho nút
                buttonColumn.UseColumnTextForButtonValue = true; // Sử dụng văn bản mặc định cho toàn bộ cột
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewShowVatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewShowVatLieu.Columns[e.ColumnIndex].Name == "btnChon" && e.RowIndex >= 0)
                {
                    var cellValue = this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells["MaVatLieu"].Value;
                    if (cellValue == null)
                    {
                        return;
                    }
                    VatLieu vatLieu = this.vatLieuService.findByMaVatLieu(this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells["MaVatLieu"].Value.ToString());
                    if (vatLieu != null)
                    {
                        this.form_ChonSoLuongVatLieu.VatLieu = vatLieu;
                        this.form_ChonSoLuongVatLieu.LoaiHoaDon = this.LoaiHoaDon;
                        this.form_ChonSoLuongVatLieu.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

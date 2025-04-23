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
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_ChonDoiTac : Form
    {
        private IDoiTacService doiTacService = new DoiTacService();
        private byte loaiDoiTac = 1;
        public Form_ChonDoiTac()
        {
            InitializeComponent();
        }

        public byte LoaiDoiTac { get => loaiDoiTac; set => loaiDoiTac = value; }

        private void Form_ChonDoiTac_Load(object sender, EventArgs e)
        {
            if (this.LoaiDoiTac == 1)
            {
                this.ShowKhachHang();
            }
            else
            {
                this.ShowNhaCungCap();
            }
        }
        private void ShowKhachHang()
        {
            this.dataGridViewShowDoiTac.Rows.Clear();
            List<KhachHang> khachHangs = this.doiTacService.findAllKhachHang();
            foreach (KhachHang khachHang in khachHangs)
            {
                this.dataGridViewShowDoiTac.Rows.Add(khachHang.MaDoiTac, khachHang.Ten, khachHang.SoDienThoai, khachHang.DiaChi);
            }
            DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)this.dataGridViewShowDoiTac.Columns["btnChon"];
            buttonColumn.Text = "Chọn"; // Đặt văn bản cho nút
                                        //Set BackColor cho các button
            buttonColumn.DefaultCellStyle.BackColor = Color.LightBlue; // Màu nền cho nút
            buttonColumn.UseColumnTextForButtonValue = true; // Sử dụng văn bản mặc định cho toàn bộ cột
        }
        private void ShowNhaCungCap()
        {
            this.dataGridViewShowDoiTac.Rows.Clear();
            List<NhaCungCap> nhaCungCaps = this.doiTacService.findAllNhaCungCap();
            foreach (NhaCungCap nhaCungCap in nhaCungCaps)
            {
                this.dataGridViewShowDoiTac.Rows.Add(nhaCungCap.MaDoiTac, nhaCungCap.Ten, nhaCungCap.SoDienThoai, nhaCungCap.DiaChi);
            }
            DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)this.dataGridViewShowDoiTac.Columns["btnChon"];
            buttonColumn.Text = "Chọn"; // Đặt văn bản cho nút
                                        //Set BackColor cho các button
            buttonColumn.DefaultCellStyle.BackColor = Color.LightBlue; // Màu nền cho nút
            buttonColumn.UseColumnTextForButtonValue = true; // Sử dụng văn bản mặc định cho toàn bộ cột
        }

        private void dataGridViewShowDoiTac_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dataGridViewShowDoiTac.Columns[e.ColumnIndex].Name == "btnChon")
                    {
                        var cellValue = this.dataGridViewShowDoiTac.Rows[e.RowIndex].Cells[0].Value;
                        if (cellValue == null)
                        {
                            return;
                        }
                        string maDoiTac = this.dataGridViewShowDoiTac.Rows[e.RowIndex].Cells[0].Value.ToString();
                        DoiTac doiTac = this.doiTacService.findByMaDoiTac(maDoiTac);
                        string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                        string filePath = "";
                        if (doiTac is KhachHang)
                        {
                            filePath = Path.Combine(projectDirectory, "temp", "hoadon", "khachHang.json");
                        }
                        else
                        {
                            filePath = Path.Combine(projectDirectory, "temp", "hoadon", "nhacungcap.json");
                        }

                        FileUtility fileUtility = new FileUtility();
                        fileUtility.WriteObjectJsonFile(doiTac, filePath);
                        Debug.WriteLine("Write down Doitac data into the JSON file successfully!");
                        this.Close();
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

using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_TraHang : Form
    {
        private IPhieuTraHangService phieuTraHangService = new PhieuTraHangService();
        private IHoaDonService hoaDonService = new HoaDonService();
        private IVatLieuService vatLieuService = new VatLieuService();
        private FileUtility fileUtility = new FileUtility();
        private StringUtility stringUtility = new StringUtility();
        public Form_TraHang()
        {
            InitializeComponent();
        }

        private void Form_TraHang_Load(object sender, EventArgs e)
        {
            this.radioButtonTraHangTuKhach.Checked = true;
            this.resetForm();
        }
        private void ShowDanhSachPhieuTraHangTuKhachHang()
        {
            this.dataGridViewShowPhieuTraHang.Rows.Clear();
            List<PhieuTraHang> phieuTraHangs = this.phieuTraHangService.findByLoaiPhieu(1);
            foreach (PhieuTraHang phieu in phieuTraHangs)
            {
                this.dataGridViewShowPhieuTraHang.Rows.Add(phieu.MaPhieu, phieu.HoaDon.MaHoaDon
                                                            , phieu.ThoiGianLap, phieu.LyDo, phieu.TongTien);
            }
        }
        private void ShowDanhSachPhieuTraHangChoNhaCungCap()
        {
            this.dataGridViewShowPhieuTraHang.Rows.Clear();
            List<PhieuTraHang> phieuTraHangs = this.phieuTraHangService.findByLoaiPhieu(2);
            foreach (PhieuTraHang phieu in phieuTraHangs)
            {
                this.dataGridViewShowPhieuTraHang.Rows.Add(phieu.MaPhieu, phieu.HoaDon.MaHoaDon
                                                            , phieu.ThoiGianLap, phieu.LyDo, phieu.TongTien);
            }
        }

        private void ShowChiTietPhieuTraHang(List<ChiTiet> chiTiets)
        {
            this.dataGridViewChiTiet.Rows.Clear();
            DataGridViewRow row;

            // Lấy danh sách ChiTietVatLieuConLaiCuaHoaDon từ HoaDonService, truyền vào maHoaDon và vật liệu từ chiTiets
            foreach (ChiTiet chiTiet in chiTiets)
            {
                // Gọi phương thức chiTietVatLieuConLaiCuaHoaDon để lấy chi tiết vật liệu còn lại sau khi trừ đi số lượng trả hàng
                ChiTiet chiTietConLai = this.hoaDonService.chiTietVatLieuConLaiCuaHoaDon(this.comboBoxMaHoaDon.Text.Trim(), chiTiet.VatLieu);

                if (chiTietConLai.SoLuong > 0) // Chỉ hiển thị nếu còn vật liệu
                {
                    row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewChiTiet);

                    // Hiển thị mã vật liệu, tên vật liệu
                    row.Cells[1].Value = chiTietConLai.VatLieu.MaVatLieu;
                    row.Cells[2].Value = chiTietConLai.VatLieu.Ten;

                    // Nếu là trả hàng từ khách, lấy giá xuất; ngược lại, lấy giá nhập
                    if (this.radioButtonTraHangTuKhach.Checked)
                    {
                        row.Cells[3].Value = chiTietConLai.VatLieu.GiaXuat;
                    }
                    else
                    {
                        row.Cells[3].Value = chiTietConLai.VatLieu.GiaNhap;
                    }

                    // Hiển thị đơn vị tính và số lượng còn lại
                    row.Cells[4].Value = chiTietConLai.VatLieu.DonVi;
                    row.Cells[5].Value = chiTietConLai.SoLuong;

                    // Tính tổng tiền cho chi tiết trả hàng
                    double giaTien = (this.radioButtonTraHangTuKhach.Checked) ? chiTietConLai.VatLieu.GiaXuat : chiTietConLai.VatLieu.GiaNhap;
                    row.Cells[6].Value = giaTien * chiTietConLai.SoLuong;

                    // Thêm dòng vào DataGridView
                    this.dataGridViewChiTiet.Rows.Add(row);
                }
            }
        }


        private void SetUpComboBoxHoaDon()
        {
            this.comboBoxMaHoaDon.Items.Clear();
            List<HoaDon> hoaDons = new List<HoaDon>();
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                hoaDons = this.hoaDonService.findByLoaiHoaDon(1);
            }
            else
            {
                hoaDons = this.hoaDonService.findByLoaiHoaDon(2);
            }
            foreach (HoaDon hoaDon in hoaDons)
            {
                this.comboBoxMaHoaDon.Items.Add(hoaDon.MaHoaDon);
            }
        }
        private string TaoMaPhieuTraHangTuDong()
        {
            string maPhieuTraHang = this.stringUtility.GenerateRandomString(10);
            while (this.phieuTraHangService.findByMaPhieu(maPhieuTraHang) != null)
            {
                maPhieuTraHang = this.stringUtility.GenerateRandomString(10);
            }
            return maPhieuTraHang;
        }
        private void resetForm()
        {
            this.txtTimKiem.Text = "";
            this.txtMaPhieu.Text = this.TaoMaPhieuTraHangTuDong();
            this.comboBoxMaHoaDon.Text = "";
            this.SetUpComboBoxHoaDon();
            this.txtLyDo.Text = "";
            this.txtThoiGianLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtThoiGianLap.Enabled = false;
            this.labelTongTienHoaDon.Text = "Tổng tiền hóa đơn: 0";
            this.labelTongTienTraHang.Text = "Tổng tiền trả hàng: 0";
            this.dataGridViewChiTiet.Rows.Clear();
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                this.ShowDanhSachPhieuTraHangTuKhachHang();
            }
            else
            {
                this.ShowDanhSachPhieuTraHangChoNhaCungCap();
            }
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangkhachhang.json");
            }
            else
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangcuahang.json");
            }
            this.fileUtility.DeleteFile(filePath);
        }
        private PhieuTraHang CreatePhieuTraHangInput()
        {
            string maPhieuTraHang = this.txtMaPhieu.Text.Trim();
            string maHoaDon = this.comboBoxMaHoaDon.Text.Trim();
            HoaDon hoaDon = this.hoaDonService.findByMaHoaDon(maHoaDon);
            DateTime thoiGianLap = DateTime.ParseExact(this.txtThoiGianLap.Text.Trim(), "dd/MM/yyyy", null);
            string lyDo = this.txtLyDo.Text.Trim();
            double tongTien = 0;
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangkhachhang.json");
            }
            else
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangcuahang.json");
            }
            List<ChiTiet> chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(filePath);
            foreach (ChiTiet chiTiet in chiTiets)
            {
                if (this.radioButtonTraHangTuKhach.Checked)
                {
                    tongTien += chiTiet.SoLuong * chiTiet.VatLieu.GiaXuat;
                }
                else
                {
                    tongTien += chiTiet.SoLuong * chiTiet.VatLieu.GiaNhap;
                }
            }
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                PhieuTraHangTuKhachHang phieuTraHangTuKhach = new PhieuTraHangTuKhachHang(maPhieuTraHang, thoiGianLap, hoaDon, lyDo, tongTien, chiTiets);
                return phieuTraHangTuKhach;
            }
            else
            {
                PhieuTraHangChoNhaCungCap phieuTraHangChoNhaCungCap = new PhieuTraHangChoNhaCungCap(maPhieuTraHang, thoiGianLap, hoaDon, lyDo, tongTien, chiTiets);
                return phieuTraHangChoNhaCungCap;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = this.txtTimKiem.Text.Trim();
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                List<PhieuTraHang> phieuTraHangs = this.phieuTraHangService.searchByKeyByLoaiPhieuTraHang(key, 1);
                this.dataGridViewShowPhieuTraHang.Rows.Clear();
                foreach (PhieuTraHang phieu in phieuTraHangs)
                {
                    this.dataGridViewShowPhieuTraHang.Rows.Add(phieu.MaPhieu, phieu.HoaDon.MaHoaDon
                                                                , phieu.ThoiGianLap, phieu.LyDo, phieu.TongTien);
                }
            }
            else
            {
                List<PhieuTraHang> phieuTraHangs = this.phieuTraHangService.searchByKeyByLoaiPhieuTraHang(key, 2);
                this.dataGridViewShowPhieuTraHang.Rows.Clear();
                foreach (PhieuTraHang phieu in phieuTraHangs)
                {
                    this.dataGridViewShowPhieuTraHang.Rows.Add(phieu.MaPhieu, phieu.HoaDon.MaHoaDon
                                                                , phieu.ThoiGianLap, phieu.LyDo, phieu.TongTien);
                }
            }
        }
        private void comboBoxMaHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangkhachhang.json");
            }
            else
            {
                filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangcuahang.json");
            }
            this.fileUtility.DeleteFile(filePath);
            string maHoaDon = this.comboBoxMaHoaDon.Text.Trim();
            HoaDon hoaDon = this.hoaDonService.findByMaHoaDon(maHoaDon);
            if (hoaDon != null)
            {
                this.ShowChiTietPhieuTraHang(hoaDon.ChiTiets);
                foreach (ChiTiet chiTiet in hoaDon.ChiTiets)
                {
                    this.fileUtility.AppendObjectJsonFile(chiTiet, filePath);
                }
                this.labelTongTienHoaDon.Text = "Tổng tiền hóa đơn: " + this.stringUtility.ConvertToVietnameseCurrency(hoaDon.TienThanhToan);
            }
        }
        private void dataGridViewShowPhieuTraHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string maPhieuTraHang = this.dataGridViewShowPhieuTraHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                    PhieuTraHang phieuTraHang = this.phieuTraHangService.findByMaPhieu(maPhieuTraHang);
                    this.txtMaPhieu.Text = phieuTraHang.MaPhieu;
                    for (int i = 0; i < this.comboBoxMaHoaDon.Items.Count; i++)
                    {
                        if (this.comboBoxMaHoaDon.Items[i].ToString() == phieuTraHang.HoaDon.MaHoaDon)
                        {
                            this.comboBoxMaHoaDon.SelectedIndex = i;
                            break;
                        }
                    }
                    this.txtThoiGianLap.Text = phieuTraHang.ThoiGianLap.ToString("dd/MM/yyyy");
                    this.txtLyDo.Text = phieuTraHang.LyDo;
                    this.ShowChiTietPhieuTraHang(phieuTraHang.ChiTiets);
                    this.labelTongTienHoaDon.Text = "Tổng hóa đơn: " + stringUtility.ConvertToVietnameseCurrency(phieuTraHang.HoaDon.TienThanhToan);
                    this.labelTongTienTraHang.Text = "Tổng tiền trả hàng " + stringUtility.ConvertToVietnameseCurrency(phieuTraHang.TongTien);
                }
            }
            catch
            {
                return;
            }
        }

        private void dataGridViewChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string filePath = "";
                    if (this.radioButtonTraHangTuKhach.Checked)
                    {
                        filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangkhachhang.json");
                    }
                    else
                    {
                        filePath = Path.Combine(projectDirectory, "temp", "phieutrahang", "chitietphieutrahangcuahang.json");
                    }
                    List<ChiTiet> chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(filePath);
                    string maVatLieu = this.dataGridViewChiTiet.Rows[e.RowIndex].Cells[1].Value.ToString();
                    foreach (ChiTiet chiTiet in chiTiets)
                    {
                        if (chiTiet.VatLieu.MaVatLieu == maVatLieu)
                        {
                            Form_ChonSoLuongVatLieu form_ChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
                            form_ChonSoLuongVatLieu.VatLieu = chiTiet.VatLieu;
                            if (this.radioButtonTraHangTuKhach.Checked)
                            {
                                form_ChonSoLuongVatLieu.LoaiPhieuTraHang = 1;
                            }
                            else
                            {
                                form_ChonSoLuongVatLieu.LoaiPhieuTraHang = 2;
                            }
                            form_ChonSoLuongVatLieu.ShowDialog();
                        }
                    }
                    chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(filePath);
                    this.ShowChiTietPhieuTraHang(chiTiets);
                    double tongTien = 0;
                    foreach (ChiTiet chiTiet in chiTiets)
                    {
                        if (this.radioButtonTraHangTuKhach.Checked)
                        {
                            tongTien += chiTiet.SoLuong * chiTiet.VatLieu.GiaXuat;
                        }
                        else
                        {
                            tongTien += chiTiet.SoLuong * chiTiet.VatLieu.GiaNhap;
                        }
                    }
                    this.labelTongTienTraHang.Text = "Tổng tiền trả hàng: " + this.stringUtility.ConvertToVietnameseCurrency(tongTien);
                }
            }
            catch
            {
                return;
            }
        }
        private void dataGridViewChiTiet_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int stt = 1; // Bắt đầu từ 1
            foreach (DataGridViewRow row in this.dataGridViewChiTiet.Rows)
            {
                if (!row.IsNewRow) // Loại bỏ hàng mới
                {
                    row.Cells["STT"].Value = stt;
                    stt++;
                }
            }
        }

        private void radioButtonTraHangTuKhach_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonTraHangTuKhach.Checked)
            {
                this.resetForm();
            }
        }

        private void radioButtonTraHangChoNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonTraHangChoNCC.Checked)
            {
                this.resetForm();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.resetForm();
        }

        private void btnXuatPhieu_Click(object sender, EventArgs e)
        {
            string maPhieuTraHang = this.txtMaPhieu.Text.Trim();
            if (string.IsNullOrEmpty(maPhieuTraHang))
            {
                MessageBox.Show("Vui lòng chọn phiếu trả hàng để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PhieuTraHang phieuTraHang = this.CreatePhieuTraHangInput();
            if (this.phieuTraHangService.findByMaPhieu(maPhieuTraHang) == null)
            {
                if (this.phieuTraHangService.insertPhieuTraHang(phieuTraHang))
                {
                    MessageBox.Show("Xuất phiếu trả hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.resetForm();
                    if (phieuTraHang is PhieuTraHangTuKhachHang)
                    {
                        VatLieu vatLieu = null;
                        foreach (ChiTiet chiTiet in phieuTraHang.ChiTiets)
                        {
                            vatLieu = chiTiet.VatLieu;
                            vatLieu.SoLuong = chiTiet.VatLieu.SoLuong + chiTiet.SoLuong;
                            this.vatLieuService.updateVatLieu(vatLieu);
                        }
                    }
                    else
                    {
                        VatLieu vatLieu = null;
                        foreach (ChiTiet chiTiet in phieuTraHang.ChiTiets)
                        {
                            vatLieu = chiTiet.VatLieu;
                            vatLieu.SoLuong = chiTiet.VatLieu.SoLuong - chiTiet.SoLuong;
                            this.vatLieuService.updateVatLieu(vatLieu);
                        }
                    }
                    Form_ReportTraHang form_ReportTraHang = new Form_ReportTraHang();
                    form_ReportTraHang.PhieuTraHang = phieuTraHang;
                    form_ReportTraHang.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Xuất phiếu trả hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Form_ReportTraHang form_ReportTraHang = new Form_ReportTraHang();
                form_ReportTraHang.PhieuTraHang = phieuTraHang;
                form_ReportTraHang.ShowDialog();
            }
        }
    }
}

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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_GiaoDich : Form
    {
        private IVatLieuService vatLieuService = new VatLieuService();
        private IHoaDonService hoaDonService = new HoaDonService();
        private Form_ChonSoLuongVatLieu formChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
        private FileUtility fileUtility = new FileUtility();
        private StringUtility stringUtility = new StringUtility();

        public Form_GiaoDich()
        {
            InitializeComponent();
        }

        private void Form_GiaoDich_Load(object sender, EventArgs e)
        {
            this.txtTienThanhToan.Text = "0";
            this.txtTienGiam.Text = "0";
            this.txtSDT.MaxLength = 10;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.radioButtonXuatHang.Checked = true;
            this.btnAnHoaDon.Enabled = false;
            this.labelDate.Text = DateTime.Now.ToString();
            this.panelHoaDon.Hide();
            this.panelVatLieu.Size = new Size(this.panelHoaDon.Size.Width, 350);
            this.comboBoxPhuongThucThanhToan.SelectedIndex = 0;
            this.ShowVatLieus();
            this.loadDoiTacInHoaDon();
            this.loadVatLieuInHoaDon();
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
                if (this.radioButtonXuatHang.Checked && vatLieu.SoLuong > 0)
                {
                    userControl.ShowVatLieu(1);
                }
                else if (this.radioButtonNhapHang.Checked)
                {
                    userControl.ShowVatLieu(2);
                }
                if (userControl != null)
                {
                    this.formChonSoLuongVatLieu.LoaiHoaDon = this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2;
                    this.formChonSoLuongVatLieu.VatLieu = userControl.VatLieu;
                    userControl.btnTransactionClick += this.btnTransaction_Click;
                    this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                }
            }  
        }
        private List<ChiTiet> GetChiTetHoaDon()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            List<ChiTiet> chiTiets = new List<ChiTiet>();
            if (this.radioButtonXuatHang.Checked)
            {
                string chiTietPath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonxuat.json");
                chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietPath);
            }
            else
            {
                string chiTietNhapCu = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieucu.json");
                string chiTietNhapMoi = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");
                chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapCu);
                chiTiets.AddRange(this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapMoi));
            }
            return chiTiets;
        }
        private DoiTac GetDoiTac()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            DoiTac doiTac = null;
            if (this.radioButtonXuatHang.Checked)
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "khachhang.json");
                List<KhachHang> khachHangs = this.fileUtility.ReadObjectsFromJsonFile<KhachHang>(filePath);
                if (khachHangs.Count > 0)
                {
                    doiTac = khachHangs[0];
                }
            }
            else
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "nhacungcap.json");
                List<NhaCungCap> nhaCungCaps = this.fileUtility.ReadObjectsFromJsonFile<NhaCungCap>(filePath);
                if (nhaCungCaps.Count > 0)
                {
                    doiTac = nhaCungCaps[0];
                }
            }
            return doiTac;
        }
        private void SetCacGiaTriTienTe(List<ChiTiet> chiTiets)
        {
            double tongTienVatLieu = 0;
            double tienGiam = 0;
            foreach (ChiTiet chiTiet in chiTiets)
            {
                if (this.radioButtonXuatHang.Checked)
                {
                    tongTienVatLieu += chiTiet.VatLieu.GiaXuat * chiTiet.SoLuong;
                }
                else
                {
                    tongTienVatLieu += chiTiet.VatLieu.GiaNhap * chiTiet.SoLuong;
                }
            }
            if (this.comboBoxPhuongThucThanhToan.SelectedIndex == 0 
                && (this.txtTienThanhToan.Text.Trim() != "" || this.txtTienThanhToan.Text.Trim() == "0"))
            {
                if (this.txtTienGiam.Text.Trim() != "")
                {
                    tienGiam = double.Parse(this.txtTienGiam.Text.Trim());
                }
                this.txtTienThanhToan.Text = (tongTienVatLieu + tienGiam).ToString();
            }
            //Cần bổ sung nợ cũ

            //Xét giá trị tổng hóa đơn:
            this.labelTongHoaDon.Text = "Tổng hóa đơn: " + this.stringUtility.ConvertToVietnameseCurrency(tongTienVatLieu + tienGiam) + "VNĐ";
            this.labelTienThanhToan.Text = "Tiền thanh toán: " + this.stringUtility.ConvertToVietnameseCurrency(double.Parse(this.txtTienThanhToan.Text.Trim())) + "VNĐ";
        }
        private void ShowChiTietHoaDon(List<ChiTiet> chiTiets)
        {
            this.dataGridViewShowVatLieu.Rows.Clear();
            DataGridViewRow dataGridViewRow;
            foreach (ChiTiet chiTiet in chiTiets)
            {
                double gia = 0;
                double tongTien = 0;
                if (this.radioButtonXuatHang.Checked)
                {
                    gia = chiTiet.VatLieu.GiaXuat;
                }
                else
                {
                    gia = chiTiet.VatLieu.GiaNhap;
                }
                tongTien = gia * chiTiet.SoLuong;
                dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(this.dataGridViewShowVatLieu);
                dataGridViewRow.Cells[1].Value = chiTiet.VatLieu.MaVatLieu;
                dataGridViewRow.Cells[2].Value = chiTiet.VatLieu.Ten;
                dataGridViewRow.Cells[3].Value = gia;
                dataGridViewRow.Cells[4].Value = chiTiet.VatLieu.DonVi;
                dataGridViewRow.Cells[5].Value = chiTiet.SoLuong;
                dataGridViewRow.Cells[6].Value = tongTien;
                this.dataGridViewShowVatLieu.Rows.Add(dataGridViewRow);
            }
        }
        private void loadVatLieuInHoaDon()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            if (this.radioButtonXuatHang.Checked)
            {
                string chiTietPath = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonxuat.json");
                List<ChiTiet> chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietPath);
                this.ShowChiTietHoaDon(chiTiets);
                this.SetCacGiaTriTienTe(chiTiets);
            }
            else 
            {
                string chiTietNhapCu = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieucu.json");
                string chiTietNhapMoi = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");
                List<ChiTiet> chiTiets = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapCu);
                chiTiets.AddRange(this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapMoi));
                this.ShowChiTietHoaDon(chiTiets);
                this.SetCacGiaTriTienTe(chiTiets);
            }
        }
        private void loadDoiTacInHoaDon()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            if (this.radioButtonXuatHang.Checked)
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "khachhang.json");
                List<KhachHang> khachHangs = this.fileUtility.ReadObjectsFromJsonFile<KhachHang>(filePath);
                if (khachHangs.Count > 0)
                {
                    this.txtNameDoiTac.Text = khachHangs[0].Ten;
                    this.txtSDT.Text = khachHangs[0].SoDienThoai;
                    this.txtAddress.Text = khachHangs[0].DiaChi;
                }
            }
            else
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "nhacungcap.json");
                List<NhaCungCap> nhaCungCaps = this.fileUtility.ReadObjectsFromJsonFile<NhaCungCap>(filePath);
                if (nhaCungCaps.Count > 0)
                {
                    this.txtNameDoiTac.Text = nhaCungCaps[0].Ten;
                    this.txtSDT.Text = nhaCungCaps[0].SoDienThoai;
                    this.txtAddress.Text = nhaCungCaps[0].DiaChi;
                }
            }
        }
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            this.panelHoaDon.Show();
            this.btnAnHoaDon.Enabled = true;
            this.formChonSoLuongVatLieu.ShowDialog();
            //Hiển thị vật liệu giao dịch trong hóa đơn
            this.loadVatLieuInHoaDon();
        }
        private void resetPanelHoaDon()
        {
            this.txtMaHoaDon.Text = new StringUtility().GenerateRandomString(10);
            this.txtNameDoiTac.Text = "";
            this.txtSDT.Text = "";
            this.txtAddress.Text = "";
            this.comboBoxPhuongThucThanhToan.SelectedIndex = 0;
            this.txtTienThanhToan.Text = "0";
            this.txtTienGiam.Text = "0";
            this.labelNoCu.Text = "Nợ cũ:";
            this.labelTongHoaDon.Text = "Tổng hóa đơn:";
            this.labelTienThanhToan.Text = "Tiền thanh toán:";
            this.dataGridViewShowVatLieu.Rows.Clear(); // Xóa tất cả các hàng trong DataGridView
        }

        private void radioButtonXuatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonXuatHang.Checked)
            {
                this.ShowVatLieus();
                this.labelTitle.Text = "Hóa đơn xuất";
                this.resetPanelHoaDon();
                this.btnTaoVatLieuMoi.Enabled = false;
                this.btnTaoVatLieuMoi.Hide();
                this.loadDoiTacInHoaDon();
                this.loadVatLieuInHoaDon();
            }
        }

        private void radioButtonNhapHang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonNhapHang.Checked)
            {
                this.ShowVatLieus();
                this.labelTitle.Text = "Hóa đơn nhập";
                this.resetPanelHoaDon();
                this.btnTaoVatLieuMoi.Enabled = true;
                this.btnTaoVatLieuMoi.Show();
                this.loadDoiTacInHoaDon();
                this.loadVatLieuInHoaDon();
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
        private void dataGridViewShowVatLieu_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int stt = 1; // Bắt đầu từ 1
            foreach (DataGridViewRow row in this.dataGridViewShowVatLieu.Rows)
            {
                if (!row.IsNewRow) // Loại bỏ hàng mới
                {
                    row.Cells["STT"].Value = stt;
                    stt++;
                }
            }
        }

        private void dataGridViewShowVatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string maVatLieu = this.dataGridViewShowVatLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
                    List<ChiTiet> chiTiets = this.GetChiTetHoaDon();
                    foreach (ChiTiet chiTiet in chiTiets)
                    {
                        if (chiTiet.VatLieu.MaVatLieu == maVatLieu)
                        {
                            Form_ChonSoLuongVatLieu form_ChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
                            form_ChonSoLuongVatLieu.VatLieu = chiTiet.VatLieu;
                            form_ChonSoLuongVatLieu.SetSoLuong(chiTiet.SoLuong);
                            form_ChonSoLuongVatLieu.LoaiHoaDon = (this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2);
                            form_ChonSoLuongVatLieu.ShowDialog();
                            this.loadVatLieuInHoaDon();
                            break;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnTaoVatLieuMoi_Click(object sender, EventArgs e)
        {
            Form_TaoVatLieuMoi form_TaoVatLieuMoi = new Form_TaoVatLieuMoi();
            if (this.radioButtonXuatHang.Checked)
            {
                form_TaoVatLieuMoi.LoaiHoaDon = 1;
            }
            else
            {
                form_TaoVatLieuMoi.LoaiHoaDon = 2;
            }
            form_TaoVatLieuMoi.ShowDialog();
            this.loadVatLieuInHoaDon();
            this.ShowVatLieus();
        }

        private void btnChonVatLieu_Click(object sender, EventArgs e)
        {
            Form_SelectVatLieu form_SelectVatLieu = new Form_SelectVatLieu();
            if (this.radioButtonXuatHang.Checked)
            {
                form_SelectVatLieu.LoaiHoaDon = 1;
            }
            else
            {
                form_SelectVatLieu.LoaiHoaDon = 2;
            }
            form_SelectVatLieu.ShowDialog();
            this.loadVatLieuInHoaDon();
        }

        private void btnChonDoiTac_Click(object sender, EventArgs e)
        {
            Form_ChonDoiTac form_ChonDoiTac = new Form_ChonDoiTac();
            if (this.radioButtonXuatHang.Checked)
            {
                form_ChonDoiTac.LoaiDoiTac = 1;
            }
            else
            {
                form_ChonDoiTac.LoaiDoiTac = 2;
            }
            form_ChonDoiTac.ShowDialog();
            this.loadDoiTacInHoaDon();
        }

        private void btnTaoMoiDoiTac_Click(object sender, EventArgs e)
        {
            Form_TaoDoiTacMoi form_TaoDoiTacMoi = new Form_TaoDoiTacMoi();
            if (this.radioButtonXuatHang.Checked)
            {
                form_TaoDoiTacMoi.LoaiDoiTac = 1;
            }
            else
            {
                form_TaoDoiTacMoi.LoaiDoiTac = 2;
            }
            form_TaoDoiTacMoi.ShowDialog();
            this.loadDoiTacInHoaDon();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = this.txtSearch.Text;
            List<VatLieu> vatLieus = this.vatLieuService.searchByKey(key);
            this.flowLayoutPanelShowVatLieu.Controls.Clear();
            UserControlShowVatLieu userControl = null;
            foreach (VatLieu vatLieu in vatLieus)
            {
                userControl = new UserControlShowVatLieu();
                userControl.VatLieu = vatLieu;
                userControl.Size = new Size(200, 280);
                if (this.radioButtonXuatHang.Checked && vatLieu.SoLuong > 0)
                {
                    userControl.ShowVatLieu(1);
                }
                else if (this.radioButtonNhapHang.Checked)
                {
                    userControl.ShowVatLieu(2);
                }
                if (userControl != null)
                {
                    this.formChonSoLuongVatLieu.LoaiHoaDon = this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2;
                    this.formChonSoLuongVatLieu.VatLieu = userControl.VatLieu;
                    userControl.btnTransactionClick += this.btnTransaction_Click;
                    this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                }
            }
        }

        private void txtTienThanhToan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTienGiam_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTienThanhToan_Leave(object sender, EventArgs e)
        {
            if (this.txtTienThanhToan.Text.Trim() == "")
            {
                this.txtTienThanhToan.Text = "0";
            }
            this.labelTienThanhToan.Text = "Tiền thanh toán: " + this.stringUtility.ConvertToVietnameseCurrency(double.Parse(this.txtTienThanhToan.Text.Trim())) + "VNĐ";
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string maHoaDon = this.txtMaHoaDon.Text.Trim();
            DoiTac doiTac = this.GetDoiTac();
            List<ChiTiet> chiTiets = this.GetChiTetHoaDon();
            string diaChi = this.txtAddress.Text.Trim();
            byte phuongThucThanhToan = (byte)(this.comboBoxPhuongThucThanhToan.SelectedIndex + 1);
            double tienGiam = double.Parse(this.txtTienGiam.Text.Trim());
            double soTienThanhToan = double.Parse(this.txtTienThanhToan.Text.Trim());
            DateTime thoiGianLap = DateTime.Now;
            HoaDon hoaDon = null;
            if (this.radioButtonXuatHang.Checked)
            {
                hoaDon = new HoaDonXuat(
                          maHoaDon, thoiGianLap, doiTac, diaChi, tienGiam, phuongThucThanhToan, soTienThanhToan, chiTiets       
                    );
            }
            else
            {
                hoaDon = new HoaDonNhap(
                        maHoaDon, thoiGianLap, doiTac, diaChi, tienGiam, phuongThucThanhToan, soTienThanhToan, chiTiets
                    );
            }

            //Thêm vật liệu mới vào database của đơn nhập
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string chiTietNhapMoi = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");
            List<ChiTiet> chiTietsNhapMoi = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapMoi);
            if (chiTietsNhapMoi.Count > 0)
            {
                foreach (ChiTiet chiTiet in chiTietsNhapMoi)
                {
                    VatLieu vatLieu = chiTiet.VatLieu;
                    vatLieu.SoLuong = chiTiet.SoLuong;
                    this.vatLieuService.insertVatLieu(vatLieu);
                }
            }
            
            //Thêm hóa đơn vào cơ sở dữ liệu
            if (this.hoaDonService.insertHoaDon(hoaDon))
            {
                MessageBox.Show("Tạo hóa đơn thành công!", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Thực hiện cập nhật lại số lượng vật liệu
                if (this.radioButtonXuatHang.Checked)
                {
                    VatLieu vatLieu = null;
                    foreach (ChiTiet chiTiet in chiTiets)
                    {
                        vatLieu = chiTiet.VatLieu;
                        vatLieu.SoLuong = vatLieu.SoLuong - chiTiet.SoLuong;
                        this.vatLieuService.updateVatLieu(vatLieu);
                    }
                }

                //Thực hiện ghi nợ cho hóa đơn có phương thức thanh toán là trả trước và ghi nợ
                if (hoaDon.PhuongThucThanhToan == 2 || hoaDon.PhuongThucThanhToan == 3)
                {
                    string maPhieuGhiNo = this.stringUtility.GenerateRandomString(10);
                    //Cần bổ sung đối tượng phiếu ghi nợ service mới làm được
                }

                //Thực hiện xóa các file temp
                List<string> filePaths = new List<string>();
                if (this.radioButtonXuatHang.Checked)
                {
                    filePaths.Add(Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonxuat.json"));
                    filePaths.Add(Path.Combine(projectDirectory, "temp", "hoadon", "khachhang.json"));
                }
                else
                {
                    filePaths.Add(Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json"));
                    filePaths.Add(Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieucu.json"));
                    filePaths.Add(Path.Combine(projectDirectory, "temp", "hoadon", "nhacungcap.json"));
                }
                foreach (string path in filePaths)
                {
                    this.fileUtility.DeleteFile(path);
                }
                this.resetPanelHoaDon();
                this.ShowVatLieus();
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn thất bại!", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
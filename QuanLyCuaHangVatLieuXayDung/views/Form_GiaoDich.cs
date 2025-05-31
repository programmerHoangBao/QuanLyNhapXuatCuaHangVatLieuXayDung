using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private IPhieuGhiNoService phieuGhiNoService = new PhieuGhiNoService();
        private IDoiTacService doiTacService = new DoiTacService();
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
                //Thêm sự kiện click
                if (userControl != null)
                {
                    userControl.btnTransactionClick += (s, ev) =>
                    {
                        this.panelHoaDon.Show();
                        this.btnAnHoaDon.Enabled = true;
                        Form_ChonSoLuongVatLieu formChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
                        formChonSoLuongVatLieu.LoaiHoaDon = this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2;
                        formChonSoLuongVatLieu.VatLieu = vatLieu;
                        formChonSoLuongVatLieu.ShowDialog();
                        this.loadVatLieuInHoaDon();
                    };
                    if (this.radioButtonXuatHang.Checked && vatLieu.SoLuong > 0)
                    {
                        userControl.ShowVatLieu(1);
                        this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                    }
                    else if (this.radioButtonNhapHang.Checked)
                    {
                        userControl.ShowVatLieu(2);
                        this.flowLayoutPanelShowVatLieu.Controls.Add(userControl);
                    }
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
        private string TaoMaDoiTacTuDong()
        {
            string maDoiTac = this.stringUtility.GenerateRandomString(10);
            while (this.doiTacService.findByMaDoiTac(maDoiTac) != null)
            {
                maDoiTac = this.stringUtility.GenerateRandomString(10);
            }
            return maDoiTac;
        }
        private DoiTac GetDoiTac()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = "";
            DoiTac doiTac = null;
            if (this.radioButtonXuatHang.Checked)
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "khachhang.json");
                if (this.fileUtility.IsFileExists(filePath))
                {
                    List<KhachHang> khachHangs = this.fileUtility.ReadObjectsFromJsonFile<KhachHang>(filePath);
                    if (khachHangs.Count > 0)
                    {
                        doiTac = khachHangs[0];
                    }
                }
                else
                {
                    doiTac = new KhachHang();
                    doiTac.MaDoiTac = this.TaoMaDoiTacTuDong();
                    doiTac.Ten = this.txtNameDoiTac.Text.Trim();
                    doiTac.SoDienThoai = this.txtSDT.Text.Trim();
                    doiTac.DiaChi = this.txtAddress.Text.Trim();
                    this.doiTacService.insertDoiTac(doiTac);
                }
            }
            else
            {
                filePath = Path.Combine(projectDirectory, "temp", "hoadon", "nhacungcap.json");
                if (this.fileUtility.IsFileExists(filePath))
                {
                    List<NhaCungCap> nhaCungCaps = this.fileUtility.ReadObjectsFromJsonFile<NhaCungCap>(filePath);
                    if (nhaCungCaps.Count > 0)
                    {
                        doiTac = nhaCungCaps[0];
                    }
                }
                else
                {
                    doiTac = new NhaCungCap();
                    doiTac.MaDoiTac = this.TaoMaDoiTacTuDong();
                    doiTac.Ten = this.txtNameDoiTac.Text.Trim();
                    doiTac.SoDienThoai = this.txtSDT.Text.Trim();
                    doiTac.DiaChi = this.txtAddress.Text.Trim();
                    this.doiTacService.insertDoiTac(doiTac);
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
        private void resetPanelHoaDon()
        {
            this.txtMaHoaDon.Text = new StringUtility().GenerateRandomString(10);
            this.txtNameDoiTac.Text = "";
            this.txtSDT.Text = "";
            this.txtAddress.Text = "";
            this.comboBoxPhuongThucThanhToan.SelectedIndex = 0;
            this.txtTienThanhToan.Text = "0";
            this.txtTienGiam.Text = "0";
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

                    userControl.btnTransactionClick += (s, ev) =>
                    {
                        this.panelHoaDon.Show();
                        this.btnAnHoaDon.Enabled = true;
                        Form_ChonSoLuongVatLieu formChonSoLuongVatLieu = new Form_ChonSoLuongVatLieu();
                        formChonSoLuongVatLieu.LoaiHoaDon = this.radioButtonXuatHang.Checked ? (byte)1 : (byte)2;
                        formChonSoLuongVatLieu.VatLieu = vatLieu;
                        formChonSoLuongVatLieu.ShowDialog();
                        this.loadVatLieuInHoaDon();
                    };
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

            if (chiTiets.Count <= 0 || this.txtNameDoiTac.Text.Trim() == "" || this.txtSDT.Text.Trim() == "" || this.txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            // Lấy đường dẫn chi tiết hóa đơn xuất và nhập
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string chiTietXuatJson = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonxuat.json");
            string chiTietNhapCuJson  = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieucu.json");
            string chiTietNhapMoiJson = Path.Combine(projectDirectory, "temp", "hoadon", "chitiethoadonnhapvatlieumoi.json");

            //Hóa đơn thực hiện thêm vật liệu mới
            VatLieu vatLieu = null;
            List<ChiTiet> chiTietNhapMois = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapMoiJson);
            foreach (ChiTiet chiTiet in chiTietNhapMois)
            {
                vatLieu = chiTiet.VatLieu;
                vatLieu.SoLuong = chiTiet.SoLuong;
                this.vatLieuService.insertVatLieu(vatLieu);
            }
            // Thêm hóa đơn vào cơ sở dữ liệu
            if (this.hoaDonService.insertHoaDon(hoaDon))
            {
                MessageBox.Show("Tạo hóa đơn thành công!", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Thực hiện cập nhật lại số lượng vật liệu
                if (this.radioButtonXuatHang.Checked)
                {
                    //Hóa đơn xuất thực hiện cập nhật số lượng vật liệu
                    List<ChiTiet> chiTietXuats = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietXuatJson);
                    foreach (ChiTiet chiTiet in chiTietXuats)
                    {
                        vatLieu = chiTiet.VatLieu;
                        vatLieu.SoLuong = vatLieu.SoLuong - chiTiet.SoLuong;
                        this.vatLieuService.updateVatLieu(vatLieu);
                    }
                }
                else
                {
                    //Hóa đơn nhập thực hiện cập nhật số lượng vât liệu cũ
                    List<ChiTiet> chiTietNhapCus = this.fileUtility.ReadObjectsFromJsonFile<ChiTiet>(chiTietNhapCuJson);
                    foreach (ChiTiet chiTiet in chiTietNhapCus)
                    {
                        vatLieu = chiTiet.VatLieu;
                        vatLieu.SoLuong = vatLieu.SoLuong + chiTiet.SoLuong;
                        this.vatLieuService.updateVatLieu(vatLieu);
                    }
                }

                // Thực hiện ghi nợ cho hóa đơn có phương thức thanh toán là trả trước và ghi nợ
                if (hoaDon.PhuongThucThanhToan == 2 || hoaDon.PhuongThucThanhToan == 3)
                {
                    string maPhieuGhiNo = this.stringUtility.GenerateRandomString(10);
                    while (this.phieuGhiNoService.findByMaPhieu(maPhieuGhiNo) != null)
                    {
                        maPhieuGhiNo = this.stringUtility.GenerateRandomString(10);
                    }
                    DateTime thoiGianTra = DateTime.Now.AddDays(540);
                    double tienNo = hoaDon.tinhTongTien() - hoaDon.TienThanhToan;

                    if (this.radioButtonXuatHang.Checked && doiTac is KhachHang khachHang && hoaDon is HoaDonXuat hoaDonXuat)
                    {
                        PhieuGhiNo phieuGhiNo = new PhieuNoKhachHang(maPhieuGhiNo, hoaDon.ThoiGianLap, thoiGianTra, tienNo, false, khachHang, hoaDonXuat);
                        this.phieuGhiNoService.insertPhieuGhiNo(phieuGhiNo);
                    }
                    else if (this.radioButtonNhapHang.Checked && doiTac is NhaCungCap nhaCungCap && hoaDon is HoaDonNhap hoaDonNhap)
                    {
                        PhieuGhiNo phieuGhiNo = new PhieuNoCuaHang(maPhieuGhiNo, hoaDon.ThoiGianLap, thoiGianTra, tienNo, false, nhaCungCap, hoaDonNhap);
                        this.phieuGhiNoService.insertPhieuGhiNo(phieuGhiNo);
                    }
                }

                // Thực hiện xóa các file temp
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

                //Thực hiện in hóa đơn
                Form_ReportHoaDon form_ReportHoaDon = new Form_ReportHoaDon();
                form_ReportHoaDon.HoaDon = hoaDon;
                form_ReportHoaDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn thất bại!", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxPhuongThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ChiTiet> chiTiets = this.GetChiTetHoaDon();
            if (this.comboBoxPhuongThucThanhToan.SelectedIndex == 0)
            {
                double tongTien = 0;
                foreach(ChiTiet chiTiet in chiTiets)
                {
                    if (this.radioButtonXuatHang.Checked)
                    {
                        tongTien += chiTiet.VatLieu.GiaXuat * chiTiet.SoLuong;
                    }
                    else
                    {
                        tongTien += chiTiet.VatLieu.GiaNhap * chiTiet.SoLuong;
                    }
                }
                tongTien -= double.Parse(this.txtTienGiam.Text.Trim());
                this.txtTienThanhToan.Text = tongTien.ToString();
            }
            if (this.comboBoxPhuongThucThanhToan.SelectedIndex == 2)
            {
                this.txtTienThanhToan.Text = "0";
                this.SetCacGiaTriTienTe(chiTiets);
            }
        }
    }
}
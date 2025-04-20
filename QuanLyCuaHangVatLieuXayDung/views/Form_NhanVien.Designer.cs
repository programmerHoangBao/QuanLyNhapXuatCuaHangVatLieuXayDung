namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelNhanVien = new System.Windows.Forms.Panel();
            this.panelShowNhanVien = new System.Windows.Forms.Panel();
            this.dataGridViewShowNhanVien = new System.Windows.Forms.DataGridView();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.labelNhanVien = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.labelTenNhanVien = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.labelDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.labelVaiTro = new System.Windows.Forms.Label();
            this.comboBoxVaiTro = new System.Windows.Forms.ComboBox();
            this.labelLuongTrenNgay = new System.Windows.Forms.Label();
            this.txtLuongTrenNgay = new System.Windows.Forms.TextBox();
            this.labelSoNgayDiLam = new System.Windows.Forms.Label();
            this.labelTongSoTienLuongDaNhan = new System.Windows.Forms.Label();
            this.labelSoNgayNghi = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteVatLieu = new System.Windows.Forms.Button();
            this.btnUpdateVatLieu = new System.Windows.Forms.Button();
            this.btnThemVatLieu = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelNhanVien.SuspendLayout();
            this.panelShowNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowNhanVien)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.txtTimKiem);
            this.panelTop.Controls.Add(this.btnTimKiem);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1326, 100);
            this.panelTop.TabIndex = 0;
            // 
            // panelNhanVien
            // 
            this.panelNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNhanVien.Controls.Add(this.panelInput);
            this.panelNhanVien.Controls.Add(this.panelButton);
            this.panelNhanVien.Controls.Add(this.panelTitle);
            this.panelNhanVien.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelNhanVien.Location = new System.Drawing.Point(826, 100);
            this.panelNhanVien.Name = "panelNhanVien";
            this.panelNhanVien.Size = new System.Drawing.Size(500, 888);
            this.panelNhanVien.TabIndex = 1;
            // 
            // panelShowNhanVien
            // 
            this.panelShowNhanVien.Controls.Add(this.dataGridViewShowNhanVien);
            this.panelShowNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowNhanVien.Location = new System.Drawing.Point(0, 100);
            this.panelShowNhanVien.Name = "panelShowNhanVien";
            this.panelShowNhanVien.Size = new System.Drawing.Size(826, 888);
            this.panelShowNhanVien.TabIndex = 2;
            // 
            // dataGridViewShowNhanVien
            // 
            this.dataGridViewShowNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShowNhanVien.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewShowNhanVien.Name = "dataGridViewShowNhanVien";
            this.dataGridViewShowNhanVien.RowHeadersVisible = false;
            this.dataGridViewShowNhanVien.RowHeadersWidth = 62;
            this.dataGridViewShowNhanVien.RowTemplate.Height = 28;
            this.dataGridViewShowNhanVien.Size = new System.Drawing.Size(826, 888);
            this.dataGridViewShowNhanVien.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.label_Title);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(498, 60);
            this.panelTitle.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.btnDeleteVatLieu);
            this.panelButton.Controls.Add(this.btnUpdateVatLieu);
            this.panelButton.Controls.Add(this.btnThemVatLieu);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 752);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(498, 134);
            this.panelButton.TabIndex = 1;
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.labelTongSoTienLuongDaNhan);
            this.panelInput.Controls.Add(this.labelSoNgayNghi);
            this.panelInput.Controls.Add(this.labelSoNgayDiLam);
            this.panelInput.Controls.Add(this.txtLuongTrenNgay);
            this.panelInput.Controls.Add(this.comboBoxVaiTro);
            this.panelInput.Controls.Add(this.labelLuongTrenNgay);
            this.panelInput.Controls.Add(this.labelVaiTro);
            this.panelInput.Controls.Add(this.labelDiaChi);
            this.panelInput.Controls.Add(this.txtDiaChi);
            this.panelInput.Controls.Add(this.txtSoDienThoai);
            this.panelInput.Controls.Add(this.txtTenNhanVien);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.labelTenNhanVien);
            this.panelInput.Controls.Add(this.txtMaNhanVien);
            this.panelInput.Controls.Add(this.labelNhanVien);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 60);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(498, 692);
            this.panelInput.TabIndex = 2;
            // 
            // label_Title
            // 
            this.label_Title.BackColor = System.Drawing.Color.LightCoral;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(498, 60);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "Nhân viên";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNhanVien
            // 
            this.labelNhanVien.AutoSize = true;
            this.labelNhanVien.Location = new System.Drawing.Point(15, 15);
            this.labelNhanVien.Name = "labelNhanVien";
            this.labelNhanVien.Size = new System.Drawing.Size(161, 29);
            this.labelNhanVien.TabIndex = 0;
            this.labelNhanVien.Text = "Mã nhân viên:";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(182, 12);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(288, 37);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // labelTenNhanVien
            // 
            this.labelTenNhanVien.AutoSize = true;
            this.labelTenNhanVien.Location = new System.Drawing.Point(15, 71);
            this.labelTenNhanVien.Name = "labelTenNhanVien";
            this.labelTenNhanVien.Size = new System.Drawing.Size(167, 29);
            this.labelTenNhanVien.TabIndex = 0;
            this.labelTenNhanVien.Text = "Tên nhân viên:";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(182, 68);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(288, 37);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số điện thoại:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(182, 121);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(288, 37);
            this.txtSoDienThoai.TabIndex = 1;
            // 
            // labelDiaChi
            // 
            this.labelDiaChi.AutoSize = true;
            this.labelDiaChi.Location = new System.Drawing.Point(20, 173);
            this.labelDiaChi.Name = "labelDiaChi";
            this.labelDiaChi.Size = new System.Drawing.Size(94, 29);
            this.labelDiaChi.TabIndex = 2;
            this.labelDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(182, 170);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(288, 110);
            this.txtDiaChi.TabIndex = 1;
            // 
            // labelVaiTro
            // 
            this.labelVaiTro.AutoSize = true;
            this.labelVaiTro.Location = new System.Drawing.Point(20, 312);
            this.labelVaiTro.Name = "labelVaiTro";
            this.labelVaiTro.Size = new System.Drawing.Size(89, 29);
            this.labelVaiTro.TabIndex = 2;
            this.labelVaiTro.Text = "Vai trò:";
            // 
            // comboBoxVaiTro
            // 
            this.comboBoxVaiTro.FormattingEnabled = true;
            this.comboBoxVaiTro.Items.AddRange(new object[] {
            "Tài xế",
            "Khuyên vát"});
            this.comboBoxVaiTro.Location = new System.Drawing.Point(182, 312);
            this.comboBoxVaiTro.Name = "comboBoxVaiTro";
            this.comboBoxVaiTro.Size = new System.Drawing.Size(288, 37);
            this.comboBoxVaiTro.TabIndex = 3;
            // 
            // labelLuongTrenNgay
            // 
            this.labelLuongTrenNgay.AutoSize = true;
            this.labelLuongTrenNgay.Location = new System.Drawing.Point(20, 386);
            this.labelLuongTrenNgay.Name = "labelLuongTrenNgay";
            this.labelLuongTrenNgay.Size = new System.Drawing.Size(192, 29);
            this.labelLuongTrenNgay.TabIndex = 2;
            this.labelLuongTrenNgay.Text = "Lương trên ngày:";
            // 
            // txtLuongTrenNgay
            // 
            this.txtLuongTrenNgay.Location = new System.Drawing.Point(219, 388);
            this.txtLuongTrenNgay.Name = "txtLuongTrenNgay";
            this.txtLuongTrenNgay.Size = new System.Drawing.Size(251, 37);
            this.txtLuongTrenNgay.TabIndex = 4;
            // 
            // labelSoNgayDiLam
            // 
            this.labelSoNgayDiLam.AutoSize = true;
            this.labelSoNgayDiLam.Location = new System.Drawing.Point(20, 506);
            this.labelSoNgayDiLam.Name = "labelSoNgayDiLam";
            this.labelSoNgayDiLam.Size = new System.Drawing.Size(174, 29);
            this.labelSoNgayDiLam.TabIndex = 5;
            this.labelSoNgayDiLam.Text = "Số ngày đi làm:";
            // 
            // labelTongSoTienLuongDaNhan
            // 
            this.labelTongSoTienLuongDaNhan.AutoSize = true;
            this.labelTongSoTienLuongDaNhan.Location = new System.Drawing.Point(15, 588);
            this.labelTongSoTienLuongDaNhan.Name = "labelTongSoTienLuongDaNhan";
            this.labelTongSoTienLuongDaNhan.Size = new System.Drawing.Size(304, 29);
            this.labelTongSoTienLuongDaNhan.TabIndex = 5;
            this.labelTongSoTienLuongDaNhan.Text = "Tổng số tiền lương đã nhận:";
            // 
            // labelSoNgayNghi
            // 
            this.labelSoNgayNghi.AutoSize = true;
            this.labelSoNgayNghi.Location = new System.Drawing.Point(20, 547);
            this.labelSoNgayNghi.Name = "labelSoNgayNghi";
            this.labelSoNgayNghi.Size = new System.Drawing.Size(154, 29);
            this.labelSoNgayNghi.TabIndex = 5;
            this.labelSoNgayNghi.Text = "Số ngày nghĩ:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.Location = new System.Drawing.Point(16, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 42);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnDeleteVatLieu
            // 
            this.btnDeleteVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnDeleteVatLieu.Location = new System.Drawing.Point(340, 1);
            this.btnDeleteVatLieu.Name = "btnDeleteVatLieu";
            this.btnDeleteVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnDeleteVatLieu.TabIndex = 7;
            this.btnDeleteVatLieu.Text = "Xóa";
            this.btnDeleteVatLieu.UseVisualStyleBackColor = false;
            // 
            // btnUpdateVatLieu
            // 
            this.btnUpdateVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateVatLieu.Location = new System.Drawing.Point(182, 1);
            this.btnUpdateVatLieu.Name = "btnUpdateVatLieu";
            this.btnUpdateVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnUpdateVatLieu.TabIndex = 8;
            this.btnUpdateVatLieu.Text = "Chỉnh sửa";
            this.btnUpdateVatLieu.UseVisualStyleBackColor = false;
            // 
            // btnThemVatLieu
            // 
            this.btnThemVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnThemVatLieu.Location = new System.Drawing.Point(16, 1);
            this.btnThemVatLieu.Name = "btnThemVatLieu";
            this.btnThemVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnThemVatLieu.TabIndex = 9;
            this.btnThemVatLieu.Text = "Thêm";
            this.btnThemVatLieu.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(218, 33);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(593, 37);
            this.txtTimKiem.TabIndex = 25;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Magenta;
            this.btnTimKiem.Location = new System.Drawing.Point(826, 27);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(136, 47);
            this.btnTimKiem.TabIndex = 26;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // Form_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 988);
            this.Controls.Add(this.panelShowNhanVien);
            this.Controls.Add(this.panelNhanVien);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form_NhanVien";
            this.Text = "Form_NhanVien";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelNhanVien.ResumeLayout(false);
            this.panelShowNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowNhanVien)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelNhanVien;
        private System.Windows.Forms.Panel panelShowNhanVien;
        private System.Windows.Forms.DataGridView dataGridViewShowNhanVien;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label labelNhanVien;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTenNhanVien;
        private System.Windows.Forms.Label labelDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox comboBoxVaiTro;
        private System.Windows.Forms.Label labelVaiTro;
        private System.Windows.Forms.TextBox txtLuongTrenNgay;
        private System.Windows.Forms.Label labelLuongTrenNgay;
        private System.Windows.Forms.Label labelTongSoTienLuongDaNhan;
        private System.Windows.Forms.Label labelSoNgayNghi;
        private System.Windows.Forms.Label labelSoNgayDiLam;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteVatLieu;
        private System.Windows.Forms.Button btnUpdateVatLieu;
        private System.Windows.Forms.Button btnThemVatLieu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}
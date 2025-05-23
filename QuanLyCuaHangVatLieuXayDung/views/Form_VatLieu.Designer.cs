﻿namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_VatLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VatLieu));
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelVatLieu = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteVatLieu = new System.Windows.Forms.Button();
            this.btnUpdateVatLieu = new System.Windows.Forms.Button();
            this.btnThemVatLieu = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.btnThemAnh = new System.Windows.Forms.Button();
            this.btnLeftArrow = new System.Windows.Forms.Button();
            this.btnRightArrow = new System.Windows.Forms.Button();
            this.pictureBoxShowImage = new System.Windows.Forms.PictureBox();
            this.dateTimePickerNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.comboBoxNhaCungCap = new System.Windows.Forms.ComboBox();
            this.labelNhaCungCap = new System.Windows.Forms.Label();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.labelDonVi = new System.Windows.Forms.Label();
            this.txtGiaXuat = new System.Windows.Forms.TextBox();
            this.labelGiaXuat = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.labelGiaNhap = new System.Windows.Forms.Label();
            this.txtTenVatlieu = new System.Windows.Forms.TextBox();
            this.labelTenVatLieu = new System.Windows.Forms.Label();
            this.txtMaVatLieu = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelMa = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelShowVatLieu = new System.Windows.Forms.Panel();
            this.dataGridViewShowVatLieu = new System.Windows.Forms.DataGridView();
            this.MaVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelTimKiem.SuspendLayout();
            this.panelVatLieu.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowImage)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.panelShowVatLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowVatLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.Controls.Add(this.txtTimKiem);
            this.panelTimKiem.Controls.Add(this.btnTimKiem);
            this.panelTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimKiem.Location = new System.Drawing.Point(0, 0);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(1326, 75);
            this.panelTimKiem.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(239, 18);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(571, 32);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Magenta;
            this.btnTimKiem.Location = new System.Drawing.Point(834, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(136, 47);
            this.btnTimKiem.TabIndex = 22;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panelVatLieu
            // 
            this.panelVatLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelVatLieu.Controls.Add(this.panelButton);
            this.panelVatLieu.Controls.Add(this.panelInput);
            this.panelVatLieu.Controls.Add(this.panelTitle);
            this.panelVatLieu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelVatLieu.Location = new System.Drawing.Point(826, 75);
            this.panelVatLieu.Name = "panelVatLieu";
            this.panelVatLieu.Size = new System.Drawing.Size(500, 778);
            this.panelVatLieu.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.AutoSize = true;
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.btnDeleteVatLieu);
            this.panelButton.Controls.Add(this.btnUpdateVatLieu);
            this.panelButton.Controls.Add(this.btnThemVatLieu);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButton.Location = new System.Drawing.Point(0, 638);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(500, 108);
            this.panelButton.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.Location = new System.Drawing.Point(11, 63);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 42);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnDeleteVatLieu
            // 
            this.btnDeleteVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnDeleteVatLieu.Location = new System.Drawing.Point(335, 6);
            this.btnDeleteVatLieu.Name = "btnDeleteVatLieu";
            this.btnDeleteVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnDeleteVatLieu.TabIndex = 1;
            this.btnDeleteVatLieu.Text = "Xóa";
            this.btnDeleteVatLieu.UseVisualStyleBackColor = false;
            // 
            // btnUpdateVatLieu
            // 
            this.btnUpdateVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateVatLieu.Location = new System.Drawing.Point(177, 6);
            this.btnUpdateVatLieu.Name = "btnUpdateVatLieu";
            this.btnUpdateVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnUpdateVatLieu.TabIndex = 1;
            this.btnUpdateVatLieu.Text = "Chỉnh sửa";
            this.btnUpdateVatLieu.UseVisualStyleBackColor = false;
            // 
            // btnThemVatLieu
            // 
            this.btnThemVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnThemVatLieu.Location = new System.Drawing.Point(11, 6);
            this.btnThemVatLieu.Name = "btnThemVatLieu";
            this.btnThemVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnThemVatLieu.TabIndex = 1;
            this.btnThemVatLieu.Text = "Thêm";
            this.btnThemVatLieu.UseVisualStyleBackColor = false;
            this.btnThemVatLieu.Click += new System.EventHandler(this.btnThemVatLieu_Click_1);
            // 
            // panelInput
            // 
            this.panelInput.AutoSize = true;
            this.panelInput.Controls.Add(this.btnXoaAnh);
            this.panelInput.Controls.Add(this.btnThemAnh);
            this.panelInput.Controls.Add(this.btnLeftArrow);
            this.panelInput.Controls.Add(this.btnRightArrow);
            this.panelInput.Controls.Add(this.pictureBoxShowImage);
            this.panelInput.Controls.Add(this.dateTimePickerNgayNhap);
            this.panelInput.Controls.Add(this.btnPlus);
            this.panelInput.Controls.Add(this.btnMinus);
            this.panelInput.Controls.Add(this.txtSoLuong);
            this.panelInput.Controls.Add(this.labelSoLuong);
            this.panelInput.Controls.Add(this.comboBoxNhaCungCap);
            this.panelInput.Controls.Add(this.labelNhaCungCap);
            this.panelInput.Controls.Add(this.txtDonVi);
            this.panelInput.Controls.Add(this.labelDonVi);
            this.panelInput.Controls.Add(this.txtGiaXuat);
            this.panelInput.Controls.Add(this.labelGiaXuat);
            this.panelInput.Controls.Add(this.txtGiaNhap);
            this.panelInput.Controls.Add(this.labelGiaNhap);
            this.panelInput.Controls.Add(this.txtTenVatlieu);
            this.panelInput.Controls.Add(this.labelTenVatLieu);
            this.panelInput.Controls.Add(this.txtMaVatLieu);
            this.panelInput.Controls.Add(this.labelDate);
            this.panelInput.Controls.Add(this.labelMa);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(0, 60);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(500, 578);
            this.panelInput.TabIndex = 2;
            // 
            // btnXoaAnh
            // 
            this.btnXoaAnh.AutoSize = true;
            this.btnXoaAnh.BackColor = System.Drawing.Color.Red;
            this.btnXoaAnh.Location = new System.Drawing.Point(101, 527);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(136, 47);
            this.btnXoaAnh.TabIndex = 21;
            this.btnXoaAnh.Text = "Xóa ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = false;
            this.btnXoaAnh.Click += new System.EventHandler(this.btnXoaAnh_Click);
            // 
            // btnThemAnh
            // 
            this.btnThemAnh.AutoSize = true;
            this.btnThemAnh.BackColor = System.Drawing.Color.Magenta;
            this.btnThemAnh.Location = new System.Drawing.Point(274, 528);
            this.btnThemAnh.Name = "btnThemAnh";
            this.btnThemAnh.Size = new System.Drawing.Size(136, 47);
            this.btnThemAnh.TabIndex = 22;
            this.btnThemAnh.Text = "Thêm ảnh";
            this.btnThemAnh.UseVisualStyleBackColor = false;
            this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
            // 
            // btnLeftArrow
            // 
            this.btnLeftArrow.BackgroundImage = global::QuanLyCuaHangVatLieuXayDung.Properties.Resources.left_arrow;
            this.btnLeftArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeftArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftArrow.Location = new System.Drawing.Point(51, 380);
            this.btnLeftArrow.Name = "btnLeftArrow";
            this.btnLeftArrow.Size = new System.Drawing.Size(78, 92);
            this.btnLeftArrow.TabIndex = 20;
            this.btnLeftArrow.UseVisualStyleBackColor = true;
            this.btnLeftArrow.Click += new System.EventHandler(this.btnLeftArrow_Click);
            // 
            // btnRightArrow
            // 
            this.btnRightArrow.BackgroundImage = global::QuanLyCuaHangVatLieuXayDung.Properties.Resources.right_arrow;
            this.btnRightArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRightArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightArrow.Location = new System.Drawing.Point(394, 382);
            this.btnRightArrow.Name = "btnRightArrow";
            this.btnRightArrow.Size = new System.Drawing.Size(78, 92);
            this.btnRightArrow.TabIndex = 19;
            this.btnRightArrow.UseVisualStyleBackColor = true;
            this.btnRightArrow.Click += new System.EventHandler(this.btnRightArrow_Click);
            // 
            // pictureBoxShowImage
            // 
            this.pictureBoxShowImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxShowImage.Location = new System.Drawing.Point(147, 318);
            this.pictureBoxShowImage.Name = "pictureBoxShowImage";
            this.pictureBoxShowImage.Size = new System.Drawing.Size(230, 200);
            this.pictureBoxShowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxShowImage.TabIndex = 18;
            this.pictureBoxShowImage.TabStop = false;
            // 
            // dateTimePickerNgayNhap
            // 
            this.dateTimePickerNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgayNhap.Location = new System.Drawing.Point(147, 51);
            this.dateTimePickerNgayNhap.Name = "dateTimePickerNgayNhap";
            this.dateTimePickerNgayNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerNgayNhap.Size = new System.Drawing.Size(330, 32);
            this.dateTimePickerNgayNhap.TabIndex = 17;
            // 
            // btnPlus
            // 
            this.btnPlus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlus.BackgroundImage")));
            this.btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlus.Location = new System.Drawing.Point(424, 275);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(50, 37);
            this.btnPlus.TabIndex = 16;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinus.BackgroundImage")));
            this.btnMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinus.Location = new System.Drawing.Point(147, 275);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(50, 37);
            this.btnMinus.TabIndex = 15;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(203, 280);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(218, 32);
            this.txtSoLuong.TabIndex = 14;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            this.txtSoLuong.Leave += new System.EventHandler(this.txtSoLuong_Leave);
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(4, 283);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(97, 25);
            this.labelSoLuong.TabIndex = 13;
            this.labelSoLuong.Text = "Số lượng:";
            // 
            // comboBoxNhaCungCap
            // 
            this.comboBoxNhaCungCap.FormattingEnabled = true;
            this.comboBoxNhaCungCap.Location = new System.Drawing.Point(147, 241);
            this.comboBoxNhaCungCap.Name = "comboBoxNhaCungCap";
            this.comboBoxNhaCungCap.Size = new System.Drawing.Size(330, 33);
            this.comboBoxNhaCungCap.TabIndex = 12;
            // 
            // labelNhaCungCap
            // 
            this.labelNhaCungCap.AutoSize = true;
            this.labelNhaCungCap.Location = new System.Drawing.Point(3, 244);
            this.labelNhaCungCap.Name = "labelNhaCungCap";
            this.labelNhaCungCap.Size = new System.Drawing.Size(138, 25);
            this.labelNhaCungCap.TabIndex = 11;
            this.labelNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(147, 203);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(330, 32);
            this.txtDonVi.TabIndex = 10;
            this.txtDonVi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDonVi
            // 
            this.labelDonVi.AutoSize = true;
            this.labelDonVi.Location = new System.Drawing.Point(6, 203);
            this.labelDonVi.Name = "labelDonVi";
            this.labelDonVi.Size = new System.Drawing.Size(79, 25);
            this.labelDonVi.TabIndex = 9;
            this.labelDonVi.Text = "Đơn vị:";
            // 
            // txtGiaXuat
            // 
            this.txtGiaXuat.Location = new System.Drawing.Point(147, 165);
            this.txtGiaXuat.Name = "txtGiaXuat";
            this.txtGiaXuat.Size = new System.Drawing.Size(330, 32);
            this.txtGiaXuat.TabIndex = 8;
            this.txtGiaXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGiaXuat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaXuat_KeyPress);
            // 
            // labelGiaXuat
            // 
            this.labelGiaXuat.AutoSize = true;
            this.labelGiaXuat.Location = new System.Drawing.Point(5, 165);
            this.labelGiaXuat.Name = "labelGiaXuat";
            this.labelGiaXuat.Size = new System.Drawing.Size(93, 25);
            this.labelGiaXuat.TabIndex = 7;
            this.labelGiaXuat.Text = "Gía xuất:";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(147, 127);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(330, 32);
            this.txtGiaNhap.TabIndex = 6;
            this.txtGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaNhap_KeyPress);
            this.txtGiaNhap.MouseLeave += new System.EventHandler(this.txtGiaNhap_MouseLeave);
            // 
            // labelGiaNhap
            // 
            this.labelGiaNhap.AutoSize = true;
            this.labelGiaNhap.Location = new System.Drawing.Point(6, 126);
            this.labelGiaNhap.Name = "labelGiaNhap";
            this.labelGiaNhap.Size = new System.Drawing.Size(97, 25);
            this.labelGiaNhap.TabIndex = 5;
            this.labelGiaNhap.Text = "Gía nhập:";
            // 
            // txtTenVatlieu
            // 
            this.txtTenVatlieu.Location = new System.Drawing.Point(147, 89);
            this.txtTenVatlieu.Name = "txtTenVatlieu";
            this.txtTenVatlieu.Size = new System.Drawing.Size(330, 32);
            this.txtTenVatlieu.TabIndex = 4;
            this.txtTenVatlieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTenVatLieu
            // 
            this.labelTenVatLieu.AutoSize = true;
            this.labelTenVatLieu.Location = new System.Drawing.Point(6, 92);
            this.labelTenVatLieu.Name = "labelTenVatLieu";
            this.labelTenVatLieu.Size = new System.Drawing.Size(124, 25);
            this.labelTenVatLieu.TabIndex = 3;
            this.labelTenVatLieu.Text = "Tên vật liệu:";
            // 
            // txtMaVatLieu
            // 
            this.txtMaVatLieu.Location = new System.Drawing.Point(147, 13);
            this.txtMaVatLieu.Name = "txtMaVatLieu";
            this.txtMaVatLieu.Size = new System.Drawing.Size(330, 32);
            this.txtMaVatLieu.TabIndex = 2;
            this.txtMaVatLieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(5, 53);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(112, 25);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Ngày nhập:";
            // 
            // labelMa
            // 
            this.labelMa.AutoSize = true;
            this.labelMa.Location = new System.Drawing.Point(6, 16);
            this.labelMa.Name = "labelMa";
            this.labelMa.Size = new System.Drawing.Size(119, 25);
            this.labelMa.TabIndex = 1;
            this.labelMa.Text = "Mã vật liệu:";
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(500, 60);
            this.panelTitle.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.LightCoral;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(500, 60);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Vật liệu";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelShowVatLieu
            // 
            this.panelShowVatLieu.Controls.Add(this.dataGridViewShowVatLieu);
            this.panelShowVatLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowVatLieu.Location = new System.Drawing.Point(0, 75);
            this.panelShowVatLieu.Name = "panelShowVatLieu";
            this.panelShowVatLieu.Size = new System.Drawing.Size(826, 778);
            this.panelShowVatLieu.TabIndex = 2;
            // 
            // dataGridViewShowVatLieu
            // 
            this.dataGridViewShowVatLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowVatLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowVatLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVatLieu,
            this.TenVatLieu,
            this.GiaNhap,
            this.GiaXuat,
            this.DonVi,
            this.NgayNhap,
            this.NhaCungCap,
            this.SoLuong,
            this.HinhAnh});
            this.dataGridViewShowVatLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShowVatLieu.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewShowVatLieu.Name = "dataGridViewShowVatLieu";
            this.dataGridViewShowVatLieu.RowHeadersVisible = false;
            this.dataGridViewShowVatLieu.RowHeadersWidth = 62;
            this.dataGridViewShowVatLieu.RowTemplate.Height = 50;
            this.dataGridViewShowVatLieu.Size = new System.Drawing.Size(826, 778);
            this.dataGridViewShowVatLieu.TabIndex = 0;
            this.dataGridViewShowVatLieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShowVatLieu_CellContentClick);
            // 
            // MaVatLieu
            // 
            this.MaVatLieu.HeaderText = "Mã vật liệu";
            this.MaVatLieu.MinimumWidth = 8;
            this.MaVatLieu.Name = "MaVatLieu";
            // 
            // TenVatLieu
            // 
            this.TenVatLieu.HeaderText = "Tên Vật Liệu";
            this.TenVatLieu.MinimumWidth = 8;
            this.TenVatLieu.Name = "TenVatLieu";
            // 
            // GiaNhap
            // 
            this.GiaNhap.HeaderText = "Gía nhập";
            this.GiaNhap.MinimumWidth = 8;
            this.GiaNhap.Name = "GiaNhap";
            // 
            // GiaXuat
            // 
            this.GiaXuat.HeaderText = "Gía xuất";
            this.GiaXuat.MinimumWidth = 8;
            this.GiaXuat.Name = "GiaXuat";
            // 
            // DonVi
            // 
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.MinimumWidth = 8;
            this.DonVi.Name = "DonVi";
            // 
            // NgayNhap
            // 
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.MinimumWidth = 8;
            this.NgayNhap.Name = "NgayNhap";
            // 
            // NhaCungCap
            // 
            this.NhaCungCap.HeaderText = "Nhà cung cấp";
            this.NhaCungCap.MinimumWidth = 8;
            this.NhaCungCap.Name = "NhaCungCap";
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            // 
            // HinhAnh
            // 
            this.HinhAnh.HeaderText = "Hình ảnh";
            this.HinhAnh.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.HinhAnh.MinimumWidth = 8;
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HinhAnh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form_VatLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 853);
            this.Controls.Add(this.panelShowVatLieu);
            this.Controls.Add(this.panelVatLieu);
            this.Controls.Add(this.panelTimKiem);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_VatLieu";
            this.Text = "Form_VatLieu";
            this.Load += new System.EventHandler(this.Form_VatLieu_Load);
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.panelVatLieu.ResumeLayout(false);
            this.panelVatLieu.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowImage)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelShowVatLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowVatLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.Panel panelVatLieu;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelShowVatLieu;
        private System.Windows.Forms.DataGridView dataGridViewShowVatLieu;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMa;
        private System.Windows.Forms.TextBox txtMaVatLieu;
        private System.Windows.Forms.Label labelTenVatLieu;
        private System.Windows.Forms.TextBox txtTenVatlieu;
        private System.Windows.Forms.Label labelGiaNhap;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtGiaXuat;
        private System.Windows.Forms.Label labelGiaXuat;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label labelDonVi;
        private System.Windows.Forms.ComboBox comboBoxNhaCungCap;
        private System.Windows.Forms.Label labelNhaCungCap;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayNhap;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.PictureBox pictureBoxShowImage;
        private System.Windows.Forms.Button btnRightArrow;
        private System.Windows.Forms.Button btnLeftArrow;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Button btnThemAnh;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewImageColumn HinhAnh;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteVatLieu;
        private System.Windows.Forms.Button btnUpdateVatLieu;
        private System.Windows.Forms.Button btnThemVatLieu;
    }
}
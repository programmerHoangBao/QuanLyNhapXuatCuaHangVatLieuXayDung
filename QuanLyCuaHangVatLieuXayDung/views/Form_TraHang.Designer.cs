namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_TraHang
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
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelRadioButton = new System.Windows.Forms.Panel();
            this.radioButtonTraHangChoNCC = new System.Windows.Forms.RadioButton();
            this.radioButtonTraHangTuKhach = new System.Windows.Forms.RadioButton();
            this.panelPhieuTraHang = new System.Windows.Forms.Panel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panelChiTiet = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTongTien = new System.Windows.Forms.Panel();
            this.labelTongTienTraHang = new System.Windows.Forms.Label();
            this.labelTongTienHoaDon = new System.Windows.Forms.Label();
            this.panelMa = new System.Windows.Forms.Panel();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.comboBoxMaHoaDon = new System.Windows.Forms.ComboBox();
            this.labelMaphieu = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.txtThoiGianLap = new System.Windows.Forms.TextBox();
            this.labelLyDo = new System.Windows.Forms.Label();
            this.labelThoiGianLap = new System.Windows.Forms.Label();
            this.labelMaHoaDon = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnXuatPhieu = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.panelShowPhieuTraHang = new System.Windows.Forms.Panel();
            this.dataGridViewShowPhieuTraHang = new System.Windows.Forms.DataGridView();
            this.MaPhieuTraHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panelTimKiem.SuspendLayout();
            this.panelRadioButton.SuspendLayout();
            this.panelPhieuTraHang.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.panelChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTongTien.SuspendLayout();
            this.panelMa.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelShowPhieuTraHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowPhieuTraHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTimKiem);
            this.panelTop.Controls.Add(this.panelRadioButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1326, 100);
            this.panelTop.TabIndex = 0;
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.Controls.Add(this.txtTimKiem);
            this.panelTimKiem.Controls.Add(this.btnTimKiem);
            this.panelTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTimKiem.Location = new System.Drawing.Point(729, 0);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(597, 100);
            this.panelTimKiem.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(36, 33);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(348, 37);
            this.txtTimKiem.TabIndex = 25;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Magenta;
            this.btnTimKiem.Location = new System.Drawing.Point(390, 27);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(136, 47);
            this.btnTimKiem.TabIndex = 26;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // panelRadioButton
            // 
            this.panelRadioButton.Controls.Add(this.radioButtonTraHangChoNCC);
            this.panelRadioButton.Controls.Add(this.radioButtonTraHangTuKhach);
            this.panelRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelRadioButton.Location = new System.Drawing.Point(0, 0);
            this.panelRadioButton.Name = "panelRadioButton";
            this.panelRadioButton.Size = new System.Drawing.Size(729, 100);
            this.panelRadioButton.TabIndex = 0;
            // 
            // radioButtonTraHangChoNCC
            // 
            this.radioButtonTraHangChoNCC.AutoSize = true;
            this.radioButtonTraHangChoNCC.Location = new System.Drawing.Point(379, 27);
            this.radioButtonTraHangChoNCC.Name = "radioButtonTraHangChoNCC";
            this.radioButtonTraHangChoNCC.Size = new System.Drawing.Size(322, 33);
            this.radioButtonTraHangChoNCC.TabIndex = 1;
            this.radioButtonTraHangChoNCC.TabStop = true;
            this.radioButtonTraHangChoNCC.Text = "Trả hàng cho nhà cung cấp";
            this.radioButtonTraHangChoNCC.UseVisualStyleBackColor = true;
            // 
            // radioButtonTraHangTuKhach
            // 
            this.radioButtonTraHangTuKhach.AutoSize = true;
            this.radioButtonTraHangTuKhach.Location = new System.Drawing.Point(62, 27);
            this.radioButtonTraHangTuKhach.Name = "radioButtonTraHangTuKhach";
            this.radioButtonTraHangTuKhach.Size = new System.Drawing.Size(229, 33);
            this.radioButtonTraHangTuKhach.TabIndex = 2;
            this.radioButtonTraHangTuKhach.TabStop = true;
            this.radioButtonTraHangTuKhach.Text = "Trả hàng từ khách";
            this.radioButtonTraHangTuKhach.UseVisualStyleBackColor = true;
            // 
            // panelPhieuTraHang
            // 
            this.panelPhieuTraHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelPhieuTraHang.Controls.Add(this.panelInput);
            this.panelPhieuTraHang.Controls.Add(this.panelButton);
            this.panelPhieuTraHang.Controls.Add(this.panelTitle);
            this.panelPhieuTraHang.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPhieuTraHang.Location = new System.Drawing.Point(626, 100);
            this.panelPhieuTraHang.Name = "panelPhieuTraHang";
            this.panelPhieuTraHang.Size = new System.Drawing.Size(700, 888);
            this.panelPhieuTraHang.TabIndex = 1;
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.panelChiTiet);
            this.panelInput.Controls.Add(this.panelTongTien);
            this.panelInput.Controls.Add(this.panelMa);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 60);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(700, 642);
            this.panelInput.TabIndex = 2;
            // 
            // panelChiTiet
            // 
            this.panelChiTiet.Controls.Add(this.dataGridView1);
            this.panelChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChiTiet.Location = new System.Drawing.Point(0, 293);
            this.panelChiTiet.Name = "panelChiTiet";
            this.panelChiTiet.Size = new System.Drawing.Size(700, 242);
            this.panelChiTiet.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaVatLieu,
            this.TenVatLieu,
            this.Gia,
            this.DonVi,
            this.SoLuong,
            this.TongTienVatLieu});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(700, 242);
            this.dataGridView1.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 8;
            this.STT.Name = "STT";
            // 
            // MaVatLieu
            // 
            this.MaVatLieu.HeaderText = "Mã";
            this.MaVatLieu.MinimumWidth = 8;
            this.MaVatLieu.Name = "MaVatLieu";
            // 
            // TenVatLieu
            // 
            this.TenVatLieu.HeaderText = "Tên";
            this.TenVatLieu.MinimumWidth = 8;
            this.TenVatLieu.Name = "TenVatLieu";
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Gía";
            this.Gia.MinimumWidth = 8;
            this.Gia.Name = "Gia";
            // 
            // DonVi
            // 
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.MinimumWidth = 8;
            this.DonVi.Name = "DonVi";
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            // 
            // panelTongTien
            // 
            this.panelTongTien.Controls.Add(this.labelTongTienTraHang);
            this.panelTongTien.Controls.Add(this.labelTongTienHoaDon);
            this.panelTongTien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTongTien.Location = new System.Drawing.Point(0, 535);
            this.panelTongTien.Name = "panelTongTien";
            this.panelTongTien.Size = new System.Drawing.Size(700, 107);
            this.panelTongTien.TabIndex = 4;
            // 
            // labelTongTienTraHang
            // 
            this.labelTongTienTraHang.AutoSize = true;
            this.labelTongTienTraHang.Location = new System.Drawing.Point(27, 66);
            this.labelTongTienTraHang.Name = "labelTongTienTraHang";
            this.labelTongTienTraHang.Size = new System.Drawing.Size(210, 29);
            this.labelTongTienTraHang.TabIndex = 0;
            this.labelTongTienTraHang.Text = "Tổng tiền trả hàng:";
            // 
            // labelTongTienHoaDon
            // 
            this.labelTongTienHoaDon.AutoSize = true;
            this.labelTongTienHoaDon.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTongTienHoaDon.Location = new System.Drawing.Point(27, 17);
            this.labelTongTienHoaDon.Name = "labelTongTienHoaDon";
            this.labelTongTienHoaDon.Size = new System.Drawing.Size(241, 29);
            this.labelTongTienHoaDon.TabIndex = 0;
            this.labelTongTienHoaDon.Text = "Tổng giá trị hóa đơn:";
            // 
            // panelMa
            // 
            this.panelMa.Controls.Add(this.txtMaPhieu);
            this.panelMa.Controls.Add(this.comboBoxMaHoaDon);
            this.panelMa.Controls.Add(this.labelMaphieu);
            this.panelMa.Controls.Add(this.txtLyDo);
            this.panelMa.Controls.Add(this.txtThoiGianLap);
            this.panelMa.Controls.Add(this.labelLyDo);
            this.panelMa.Controls.Add(this.labelThoiGianLap);
            this.panelMa.Controls.Add(this.labelMaHoaDon);
            this.panelMa.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMa.Location = new System.Drawing.Point(0, 0);
            this.panelMa.Name = "panelMa";
            this.panelMa.Size = new System.Drawing.Size(700, 293);
            this.panelMa.TabIndex = 3;
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(205, 18);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(389, 37);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // comboBoxMaHoaDon
            // 
            this.comboBoxMaHoaDon.FormattingEnabled = true;
            this.comboBoxMaHoaDon.Location = new System.Drawing.Point(205, 64);
            this.comboBoxMaHoaDon.Name = "comboBoxMaHoaDon";
            this.comboBoxMaHoaDon.Size = new System.Drawing.Size(389, 37);
            this.comboBoxMaHoaDon.TabIndex = 2;
            // 
            // labelMaphieu
            // 
            this.labelMaphieu.AutoSize = true;
            this.labelMaphieu.Location = new System.Drawing.Point(62, 21);
            this.labelMaphieu.Name = "labelMaphieu";
            this.labelMaphieu.Size = new System.Drawing.Size(118, 29);
            this.labelMaphieu.TabIndex = 0;
            this.labelMaphieu.Text = "Mã phiếu:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(205, 158);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(389, 106);
            this.txtLyDo.TabIndex = 1;
            // 
            // txtThoiGianLap
            // 
            this.txtThoiGianLap.Location = new System.Drawing.Point(205, 112);
            this.txtThoiGianLap.Name = "txtThoiGianLap";
            this.txtThoiGianLap.Size = new System.Drawing.Size(389, 37);
            this.txtThoiGianLap.TabIndex = 1;
            // 
            // labelLyDo
            // 
            this.labelLyDo.AutoSize = true;
            this.labelLyDo.Location = new System.Drawing.Point(62, 158);
            this.labelLyDo.Name = "labelLyDo";
            this.labelLyDo.Size = new System.Drawing.Size(80, 29);
            this.labelLyDo.TabIndex = 0;
            this.labelLyDo.Text = "Lý do:";
            // 
            // labelThoiGianLap
            // 
            this.labelThoiGianLap.AutoSize = true;
            this.labelThoiGianLap.Location = new System.Drawing.Point(62, 115);
            this.labelThoiGianLap.Name = "labelThoiGianLap";
            this.labelThoiGianLap.Size = new System.Drawing.Size(118, 29);
            this.labelThoiGianLap.TabIndex = 0;
            this.labelThoiGianLap.Text = "Thời gian:";
            // 
            // labelMaHoaDon
            // 
            this.labelMaHoaDon.AutoSize = true;
            this.labelMaHoaDon.Location = new System.Drawing.Point(62, 72);
            this.labelMaHoaDon.Name = "labelMaHoaDon";
            this.labelMaHoaDon.Size = new System.Drawing.Size(146, 29);
            this.labelMaHoaDon.TabIndex = 0;
            this.labelMaHoaDon.Text = "Mã hóa đơn:";
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.btnXuatPhieu);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 702);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(700, 186);
            this.panelButton.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.Location = new System.Drawing.Point(396, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 42);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnXuatPhieu
            // 
            this.btnXuatPhieu.BackColor = System.Drawing.Color.Orange;
            this.btnXuatPhieu.Location = new System.Drawing.Point(139, 6);
            this.btnXuatPhieu.Name = "btnXuatPhieu";
            this.btnXuatPhieu.Size = new System.Drawing.Size(142, 42);
            this.btnXuatPhieu.TabIndex = 6;
            this.btnXuatPhieu.Text = "Xuất phiếu";
            this.btnXuatPhieu.UseVisualStyleBackColor = false;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.label_Title);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(700, 60);
            this.panelTitle.TabIndex = 0;
            // 
            // label_Title
            // 
            this.label_Title.BackColor = System.Drawing.Color.LightCoral;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(700, 60);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "Phiếu trả hàng";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelShowPhieuTraHang
            // 
            this.panelShowPhieuTraHang.Controls.Add(this.dataGridViewShowPhieuTraHang);
            this.panelShowPhieuTraHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowPhieuTraHang.Location = new System.Drawing.Point(0, 100);
            this.panelShowPhieuTraHang.Name = "panelShowPhieuTraHang";
            this.panelShowPhieuTraHang.Size = new System.Drawing.Size(626, 888);
            this.panelShowPhieuTraHang.TabIndex = 2;
            // 
            // dataGridViewShowPhieuTraHang
            // 
            this.dataGridViewShowPhieuTraHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowPhieuTraHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowPhieuTraHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuTraHang,
            this.MaHoaDon,
            this.ThoiGianLap,
            this.LyDo,
            this.TongTien});
            this.dataGridViewShowPhieuTraHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShowPhieuTraHang.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewShowPhieuTraHang.Name = "dataGridViewShowPhieuTraHang";
            this.dataGridViewShowPhieuTraHang.RowHeadersVisible = false;
            this.dataGridViewShowPhieuTraHang.RowHeadersWidth = 62;
            this.dataGridViewShowPhieuTraHang.RowTemplate.Height = 28;
            this.dataGridViewShowPhieuTraHang.Size = new System.Drawing.Size(626, 888);
            this.dataGridViewShowPhieuTraHang.TabIndex = 0;
            // 
            // MaPhieuTraHang
            // 
            this.MaPhieuTraHang.HeaderText = "Mã phiếu";
            this.MaPhieuTraHang.MinimumWidth = 8;
            this.MaPhieuTraHang.Name = "MaPhieuTraHang";
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.HeaderText = "Mã hóa đơn";
            this.MaHoaDon.MinimumWidth = 8;
            this.MaHoaDon.Name = "MaHoaDon";
            // 
            // ThoiGianLap
            // 
            this.ThoiGianLap.HeaderText = "Thời gian lập";
            this.ThoiGianLap.MinimumWidth = 8;
            this.ThoiGianLap.Name = "ThoiGianLap";
            // 
            // LyDo
            // 
            this.LyDo.HeaderText = "Lý do";
            this.LyDo.MinimumWidth = 8;
            this.LyDo.Name = "LyDo";
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.MinimumWidth = 8;
            this.TongTien.Name = "TongTien";
            // 
            // TongTienVatLieu
            // 
            this.TongTienVatLieu.HeaderText = "Tổng tiền";
            this.TongTienVatLieu.MinimumWidth = 8;
            this.TongTienVatLieu.Name = "TongTienVatLieu";
            // 
            // Form_TraHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 988);
            this.Controls.Add(this.panelShowPhieuTraHang);
            this.Controls.Add(this.panelPhieuTraHang);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_TraHang";
            this.Text = "Form_TraHang";
            this.panelTop.ResumeLayout(false);
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.panelRadioButton.ResumeLayout(false);
            this.panelRadioButton.PerformLayout();
            this.panelPhieuTraHang.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTongTien.ResumeLayout(false);
            this.panelTongTien.PerformLayout();
            this.panelMa.ResumeLayout(false);
            this.panelMa.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelShowPhieuTraHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowPhieuTraHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.Panel panelRadioButton;
        private System.Windows.Forms.Panel panelPhieuTraHang;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelShowPhieuTraHang;
        private System.Windows.Forms.ComboBox comboBoxMaHoaDon;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label labelMaHoaDon;
        private System.Windows.Forms.Label labelMaphieu;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label labelThoiGianLap;
        private System.Windows.Forms.TextBox txtThoiGianLap;
        private System.Windows.Forms.Panel panelMa;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label labelLyDo;
        private System.Windows.Forms.DataGridView dataGridViewShowPhieuTraHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuTraHang;
        private System.Windows.Forms.Panel panelTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.Panel panelChiTiet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.Label labelTongTienTraHang;
        private System.Windows.Forms.Label labelTongTienHoaDon;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnXuatPhieu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton radioButtonTraHangChoNCC;
        private System.Windows.Forms.RadioButton radioButtonTraHangTuKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienVatLieu;
    }
}
namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_TaoVatLieuMoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TaoVatLieuMoi));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelInputVatLieu = new System.Windows.Forms.Panel();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.btnThemAnh = new System.Windows.Forms.Button();
            this.btnLeftArrow = new System.Windows.Forms.Button();
            this.btnRightArrow = new System.Windows.Forms.Button();
            this.pictureBoxShowImage = new System.Windows.Forms.PictureBox();
            this.comboBoxNhaCungCap = new System.Windows.Forms.ComboBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtGiaXuat = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.labelNhaCungCap = new System.Windows.Forms.Label();
            this.txtTenVatlieu = new System.Windows.Forms.TextBox();
            this.labelDonVi = new System.Windows.Forms.Label();
            this.labelGiaXuat = new System.Windows.Forms.Label();
            this.txtMaVatLieu = new System.Windows.Forms.TextBox();
            this.labelGiaNhap = new System.Windows.Forms.Label();
            this.labelTenVatLieu = new System.Windows.Forms.Label();
            this.labelMa = new System.Windows.Forms.Label();
            this.panelBtnTao = new System.Windows.Forms.Panel();
            this.btnTaoVatLieu = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panelInputVatLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowImage)).BeginInit();
            this.panelBtnTao.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(678, 60);
            this.panelTitle.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.LightCoral;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(678, 60);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Tạo vật liệu mới";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInputVatLieu
            // 
            this.panelInputVatLieu.Controls.Add(this.btnXoaAnh);
            this.panelInputVatLieu.Controls.Add(this.btnThemAnh);
            this.panelInputVatLieu.Controls.Add(this.btnLeftArrow);
            this.panelInputVatLieu.Controls.Add(this.btnRightArrow);
            this.panelInputVatLieu.Controls.Add(this.pictureBoxShowImage);
            this.panelInputVatLieu.Controls.Add(this.comboBoxNhaCungCap);
            this.panelInputVatLieu.Controls.Add(this.btnMinus);
            this.panelInputVatLieu.Controls.Add(this.btnPlus);
            this.panelInputVatLieu.Controls.Add(this.txtSoLuong);
            this.panelInputVatLieu.Controls.Add(this.txtDonVi);
            this.panelInputVatLieu.Controls.Add(this.txtGiaXuat);
            this.panelInputVatLieu.Controls.Add(this.txtGiaNhap);
            this.panelInputVatLieu.Controls.Add(this.labelSoLuong);
            this.panelInputVatLieu.Controls.Add(this.labelNhaCungCap);
            this.panelInputVatLieu.Controls.Add(this.txtTenVatlieu);
            this.panelInputVatLieu.Controls.Add(this.labelDonVi);
            this.panelInputVatLieu.Controls.Add(this.labelGiaXuat);
            this.panelInputVatLieu.Controls.Add(this.txtMaVatLieu);
            this.panelInputVatLieu.Controls.Add(this.labelGiaNhap);
            this.panelInputVatLieu.Controls.Add(this.labelTenVatLieu);
            this.panelInputVatLieu.Controls.Add(this.labelMa);
            this.panelInputVatLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInputVatLieu.Location = new System.Drawing.Point(0, 60);
            this.panelInputVatLieu.Name = "panelInputVatLieu";
            this.panelInputVatLieu.Size = new System.Drawing.Size(678, 724);
            this.panelInputVatLieu.TabIndex = 1;
            // 
            // btnXoaAnh
            // 
            this.btnXoaAnh.BackColor = System.Drawing.Color.Red;
            this.btnXoaAnh.Location = new System.Drawing.Point(200, 669);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(136, 47);
            this.btnXoaAnh.TabIndex = 8;
            this.btnXoaAnh.Text = "Xóa ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = false;
            this.btnXoaAnh.Click += new System.EventHandler(this.btnXoaAnh_Click);
            // 
            // btnThemAnh
            // 
            this.btnThemAnh.BackColor = System.Drawing.Color.Magenta;
            this.btnThemAnh.Location = new System.Drawing.Point(364, 669);
            this.btnThemAnh.Name = "btnThemAnh";
            this.btnThemAnh.Size = new System.Drawing.Size(136, 47);
            this.btnThemAnh.TabIndex = 8;
            this.btnThemAnh.Text = "Thêm ảnh";
            this.btnThemAnh.UseVisualStyleBackColor = false;
            this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
            // 
            // btnLeftArrow
            // 
            this.btnLeftArrow.BackgroundImage = global::QuanLyCuaHangVatLieuXayDung.Properties.Resources.left_arrow;
            this.btnLeftArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeftArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftArrow.Location = new System.Drawing.Point(116, 484);
            this.btnLeftArrow.Name = "btnLeftArrow";
            this.btnLeftArrow.Size = new System.Drawing.Size(78, 92);
            this.btnLeftArrow.TabIndex = 7;
            this.btnLeftArrow.UseVisualStyleBackColor = true;
            this.btnLeftArrow.Click += new System.EventHandler(this.btnLeftArrow_Click);
            // 
            // btnRightArrow
            // 
            this.btnRightArrow.BackgroundImage = global::QuanLyCuaHangVatLieuXayDung.Properties.Resources.right_arrow;
            this.btnRightArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRightArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightArrow.Location = new System.Drawing.Point(506, 484);
            this.btnRightArrow.Name = "btnRightArrow";
            this.btnRightArrow.Size = new System.Drawing.Size(78, 92);
            this.btnRightArrow.TabIndex = 7;
            this.btnRightArrow.UseVisualStyleBackColor = true;
            this.btnRightArrow.Click += new System.EventHandler(this.btnRightArrow_Click);
            // 
            // pictureBoxShowImage
            // 
            this.pictureBoxShowImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxShowImage.Location = new System.Drawing.Point(200, 413);
            this.pictureBoxShowImage.Name = "pictureBoxShowImage";
            this.pictureBoxShowImage.Size = new System.Drawing.Size(300, 250);
            this.pictureBoxShowImage.TabIndex = 6;
            this.pictureBoxShowImage.TabStop = false;
            // 
            // comboBoxNhaCungCap
            // 
            this.comboBoxNhaCungCap.FormattingEnabled = true;
            this.comboBoxNhaCungCap.Location = new System.Drawing.Point(200, 281);
            this.comboBoxNhaCungCap.Name = "comboBoxNhaCungCap";
            this.comboBoxNhaCungCap.Size = new System.Drawing.Size(421, 37);
            this.comboBoxNhaCungCap.TabIndex = 5;
            // 
            // btnMinus
            // 
            this.btnMinus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinus.BackgroundImage")));
            this.btnMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinus.Location = new System.Drawing.Point(171, 334);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(50, 37);
            this.btnMinus.TabIndex = 4;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlus.BackgroundImage")));
            this.btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlus.Location = new System.Drawing.Point(569, 334);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(50, 37);
            this.btnPlus.TabIndex = 3;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(225, 334);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(338, 37);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            this.txtSoLuong.Leave += new System.EventHandler(this.txtSoLuong_Leave);
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(171, 223);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(450, 37);
            this.txtDonVi.TabIndex = 1;
            this.txtDonVi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGiaXuat
            // 
            this.txtGiaXuat.Location = new System.Drawing.Point(171, 169);
            this.txtGiaXuat.Name = "txtGiaXuat";
            this.txtGiaXuat.Size = new System.Drawing.Size(450, 37);
            this.txtGiaXuat.TabIndex = 1;
            this.txtGiaXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGiaXuat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaXuat_KeyPress);
            this.txtGiaXuat.Leave += new System.EventHandler(this.txtGiaXuat_Leave);
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(171, 117);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(450, 37);
            this.txtGiaNhap.TabIndex = 1;
            this.txtGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaNhap_KeyPress);
            this.txtGiaNhap.Leave += new System.EventHandler(this.txtGiaNhap_Leave);
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(27, 337);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(112, 29);
            this.labelSoLuong.TabIndex = 0;
            this.labelSoLuong.Text = "Số lượng:";
            // 
            // labelNhaCungCap
            // 
            this.labelNhaCungCap.AutoSize = true;
            this.labelNhaCungCap.Location = new System.Drawing.Point(29, 281);
            this.labelNhaCungCap.Name = "labelNhaCungCap";
            this.labelNhaCungCap.Size = new System.Drawing.Size(164, 29);
            this.labelNhaCungCap.TabIndex = 0;
            this.labelNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // txtTenVatlieu
            // 
            this.txtTenVatlieu.Location = new System.Drawing.Point(171, 64);
            this.txtTenVatlieu.Name = "txtTenVatlieu";
            this.txtTenVatlieu.Size = new System.Drawing.Size(450, 37);
            this.txtTenVatlieu.TabIndex = 1;
            this.txtTenVatlieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDonVi
            // 
            this.labelDonVi.AutoSize = true;
            this.labelDonVi.Location = new System.Drawing.Point(29, 223);
            this.labelDonVi.Name = "labelDonVi";
            this.labelDonVi.Size = new System.Drawing.Size(89, 29);
            this.labelDonVi.TabIndex = 0;
            this.labelDonVi.Text = "Đơn vị:";
            // 
            // labelGiaXuat
            // 
            this.labelGiaXuat.AutoSize = true;
            this.labelGiaXuat.Location = new System.Drawing.Point(29, 169);
            this.labelGiaXuat.Name = "labelGiaXuat";
            this.labelGiaXuat.Size = new System.Drawing.Size(107, 29);
            this.labelGiaXuat.TabIndex = 0;
            this.labelGiaXuat.Text = "Gía xuất:";
            // 
            // txtMaVatLieu
            // 
            this.txtMaVatLieu.Location = new System.Drawing.Point(171, 18);
            this.txtMaVatLieu.Name = "txtMaVatLieu";
            this.txtMaVatLieu.Size = new System.Drawing.Size(450, 37);
            this.txtMaVatLieu.TabIndex = 1;
            this.txtMaVatLieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelGiaNhap
            // 
            this.labelGiaNhap.AutoSize = true;
            this.labelGiaNhap.Location = new System.Drawing.Point(29, 117);
            this.labelGiaNhap.Name = "labelGiaNhap";
            this.labelGiaNhap.Size = new System.Drawing.Size(113, 29);
            this.labelGiaNhap.TabIndex = 0;
            this.labelGiaNhap.Text = "Gía nhập:";
            // 
            // labelTenVatLieu
            // 
            this.labelTenVatLieu.AutoSize = true;
            this.labelTenVatLieu.Location = new System.Drawing.Point(29, 64);
            this.labelTenVatLieu.Name = "labelTenVatLieu";
            this.labelTenVatLieu.Size = new System.Drawing.Size(141, 29);
            this.labelTenVatLieu.TabIndex = 0;
            this.labelTenVatLieu.Text = "Tên vật liệu:";
            // 
            // labelMa
            // 
            this.labelMa.AutoSize = true;
            this.labelMa.Location = new System.Drawing.Point(29, 18);
            this.labelMa.Name = "labelMa";
            this.labelMa.Size = new System.Drawing.Size(135, 29);
            this.labelMa.TabIndex = 0;
            this.labelMa.Text = "Mã vật liệu:";
            // 
            // panelBtnTao
            // 
            this.panelBtnTao.Controls.Add(this.btnTaoVatLieu);
            this.panelBtnTao.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBtnTao.Location = new System.Drawing.Point(0, 784);
            this.panelBtnTao.Name = "panelBtnTao";
            this.panelBtnTao.Size = new System.Drawing.Size(678, 58);
            this.panelBtnTao.TabIndex = 2;
            // 
            // btnTaoVatLieu
            // 
            this.btnTaoVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnTaoVatLieu.Location = new System.Drawing.Point(524, 6);
            this.btnTaoVatLieu.Name = "btnTaoVatLieu";
            this.btnTaoVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnTaoVatLieu.TabIndex = 0;
            this.btnTaoVatLieu.Text = "Tạo";
            this.btnTaoVatLieu.UseVisualStyleBackColor = false;
            this.btnTaoVatLieu.Click += new System.EventHandler(this.btnTaoVatLieu_Click);
            // 
            // Form_TaoVatLieuMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(678, 842);
            this.Controls.Add(this.panelBtnTao);
            this.Controls.Add(this.panelInputVatLieu);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_TaoVatLieuMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_TaoVatLieuMoi";
            this.Load += new System.EventHandler(this.Form_TaoVatLieuMoi_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelInputVatLieu.ResumeLayout(false);
            this.panelInputVatLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowImage)).EndInit();
            this.panelBtnTao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelInputVatLieu;
        private System.Windows.Forms.Label labelMa;
        private System.Windows.Forms.Panel panelBtnTao;
        private System.Windows.Forms.TextBox txtMaVatLieu;
        private System.Windows.Forms.TextBox txtTenVatlieu;
        private System.Windows.Forms.Label labelTenVatLieu;
        private System.Windows.Forms.TextBox txtGiaXuat;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label labelGiaXuat;
        private System.Windows.Forms.Label labelGiaNhap;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Label labelDonVi;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.ComboBox comboBoxNhaCungCap;
        private System.Windows.Forms.Label labelNhaCungCap;
        private System.Windows.Forms.PictureBox pictureBoxShowImage;
        private System.Windows.Forms.Button btnRightArrow;
        private System.Windows.Forms.Button btnLeftArrow;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Button btnThemAnh;
        private System.Windows.Forms.Button btnTaoVatLieu;
    }
}
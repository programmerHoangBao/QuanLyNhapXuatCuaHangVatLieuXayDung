namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_BienLaiTraNoSingle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMaPhieu = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.labelTenDoiTac = new System.Windows.Forms.Label();
            this.txtTenDoiTac = new System.Windows.Forms.TextBox();
            this.labelTienNo = new System.Windows.Forms.Label();
            this.txtTienNo = new System.Windows.Forms.TextBox();
            this.labelMaBienLai = new System.Windows.Forms.Label();
            this.txtMaBienLai = new System.Windows.Forms.TextBox();
            this.labelThoiGianTra = new System.Windows.Forms.Label();
            this.dtpThoiGianTra = new System.Windows.Forms.DateTimePicker();
            this.labelTienTra = new System.Windows.Forms.Label();
            this.txtTienTra = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(199, 32);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(237, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Biên Lai Trả Nợ";
            // 
            // labelMaPhieu
            // 
            this.labelMaPhieu.AutoSize = true;
            this.labelMaPhieu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaPhieu.Location = new System.Drawing.Point(56, 112);
            this.labelMaPhieu.Name = "labelMaPhieu";
            this.labelMaPhieu.Size = new System.Drawing.Size(129, 33);
            this.labelMaPhieu.TabIndex = 1;
            this.labelMaPhieu.Text = "Mã phiếu:";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieu.Location = new System.Drawing.Point(227, 100);
            this.txtMaPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.ReadOnly = true;
            this.txtMaPhieu.Size = new System.Drawing.Size(332, 39);
            this.txtMaPhieu.TabIndex = 2;
            // 
            // labelTenDoiTac
            // 
            this.labelTenDoiTac.AutoSize = true;
            this.labelTenDoiTac.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenDoiTac.Location = new System.Drawing.Point(56, 182);
            this.labelTenDoiTac.Name = "labelTenDoiTac";
            this.labelTenDoiTac.Size = new System.Drawing.Size(147, 33);
            this.labelTenDoiTac.TabIndex = 3;
            this.labelTenDoiTac.Text = "Tên đối tác:";
            // 
            // txtTenDoiTac
            // 
            this.txtTenDoiTac.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDoiTac.Location = new System.Drawing.Point(227, 170);
            this.txtTenDoiTac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDoiTac.Name = "txtTenDoiTac";
            this.txtTenDoiTac.ReadOnly = true;
            this.txtTenDoiTac.Size = new System.Drawing.Size(332, 39);
            this.txtTenDoiTac.TabIndex = 4;
            // 
            // labelTienNo
            // 
            this.labelTienNo.AutoSize = true;
            this.labelTienNo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTienNo.Location = new System.Drawing.Point(56, 252);
            this.labelTienNo.Name = "labelTienNo";
            this.labelTienNo.Size = new System.Drawing.Size(108, 33);
            this.labelTienNo.TabIndex = 5;
            this.labelTienNo.Text = "Tiền nợ:";
            // 
            // txtTienNo
            // 
            this.txtTienNo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienNo.Location = new System.Drawing.Point(227, 240);
            this.txtTienNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTienNo.Name = "txtTienNo";
            this.txtTienNo.ReadOnly = true;
            this.txtTienNo.Size = new System.Drawing.Size(332, 39);
            this.txtTienNo.TabIndex = 6;
            // 
            // labelMaBienLai
            // 
            this.labelMaBienLai.AutoSize = true;
            this.labelMaBienLai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaBienLai.Location = new System.Drawing.Point(56, 322);
            this.labelMaBienLai.Name = "labelMaBienLai";
            this.labelMaBienLai.Size = new System.Drawing.Size(150, 33);
            this.labelMaBienLai.TabIndex = 7;
            this.labelMaBienLai.Text = "Mã biên lai:";
            // 
            // txtMaBienLai
            // 
            this.txtMaBienLai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBienLai.Location = new System.Drawing.Point(227, 310);
            this.txtMaBienLai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaBienLai.Name = "txtMaBienLai";
            this.txtMaBienLai.Size = new System.Drawing.Size(332, 39);
            this.txtMaBienLai.TabIndex = 8;
            // 
            // labelThoiGianTra
            // 
            this.labelThoiGianTra.AutoSize = true;
            this.labelThoiGianTra.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThoiGianTra.Location = new System.Drawing.Point(56, 392);
            this.labelThoiGianTra.Name = "labelThoiGianTra";
            this.labelThoiGianTra.Size = new System.Drawing.Size(166, 33);
            this.labelThoiGianTra.TabIndex = 9;
            this.labelThoiGianTra.Text = "Thời gian trả:";
            // 
            // dtpThoiGianTra
            // 
            this.dtpThoiGianTra.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGianTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianTra.Location = new System.Drawing.Point(227, 380);
            this.dtpThoiGianTra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpThoiGianTra.Name = "dtpThoiGianTra";
            this.dtpThoiGianTra.Size = new System.Drawing.Size(332, 39);
            this.dtpThoiGianTra.TabIndex = 10;
            // 
            // labelTienTra
            // 
            this.labelTienTra.AutoSize = true;
            this.labelTienTra.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTienTra.Location = new System.Drawing.Point(56, 462);
            this.labelTienTra.Name = "labelTienTra";
            this.labelTienTra.Size = new System.Drawing.Size(108, 33);
            this.labelTienTra.TabIndex = 11;
            this.labelTienTra.Text = "Tiền trả:";
            // 
            // txtTienTra
            // 
            this.txtTienTra.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienTra.Location = new System.Drawing.Point(227, 450);
            this.txtTienTra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTienTra.Name = "txtTienTra";
            this.txtTienTra.Size = new System.Drawing.Size(332, 39);
            this.txtTienTra.TabIndex = 12;
            this.txtTienTra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienTra_KeyPress);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(227, 539);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(129, 50);
            this.btnXacNhan.TabIndex = 13;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightSalmon;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(448, 539);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 50);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.btnHuy);
            this.panelMain.Controls.Add(this.btnXacNhan);
            this.panelMain.Controls.Add(this.txtTienTra);
            this.panelMain.Controls.Add(this.labelTienTra);
            this.panelMain.Controls.Add(this.dtpThoiGianTra);
            this.panelMain.Controls.Add(this.labelThoiGianTra);
            this.panelMain.Controls.Add(this.txtMaBienLai);
            this.panelMain.Controls.Add(this.labelMaBienLai);
            this.panelMain.Controls.Add(this.txtTienNo);
            this.panelMain.Controls.Add(this.labelTienNo);
            this.panelMain.Controls.Add(this.txtTenDoiTac);
            this.panelMain.Controls.Add(this.labelTenDoiTac);
            this.panelMain.Controls.Add(this.txtMaPhieu);
            this.panelMain.Controls.Add(this.labelMaPhieu);
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(630, 652);
            this.panelMain.TabIndex = 15;
            // 
            // Form_BienLaiTraNoSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 652);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form_BienLaiTraNoSingle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Biên Lai Trả Nợ";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMaPhieu;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label labelTenDoiTac;
        private System.Windows.Forms.TextBox txtTenDoiTac;
        private System.Windows.Forms.Label labelTienNo;
        private System.Windows.Forms.TextBox txtTienNo;
        private System.Windows.Forms.Label labelMaBienLai;
        private System.Windows.Forms.TextBox txtMaBienLai;
        private System.Windows.Forms.Label labelThoiGianTra;
        private System.Windows.Forms.DateTimePicker dtpThoiGianTra;
        private System.Windows.Forms.Label labelTienTra;
        private System.Windows.Forms.TextBox txtTienTra;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel panelMain;


    }
}
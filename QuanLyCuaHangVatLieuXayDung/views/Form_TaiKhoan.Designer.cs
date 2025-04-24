namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_TaiKhoan
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.labeltenDN = new System.Windows.Forms.Label();
            this.labelmaTK = new System.Windows.Forms.Label();
            this.labelMK = new System.Windows.Forms.Label();
            this.labeltenCH = new System.Windows.Forms.Label();
            this.labelSDT = new System.Windows.Forms.Label();
            this.labeldiaChi = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.EmailnganHang = new System.Windows.Forms.Label();
            this.labelSTK = new System.Windows.Forms.Label();
            this.labelmaQR = new System.Windows.Forms.Label();
            this.txtMaTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenCuaHang = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSoTaiKhoan = new System.Windows.Forms.TextBox();
            this.cboNganHang = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 643);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1326, 146);
            this.panel2.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonSave.Location = new System.Drawing.Point(509, 7);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(160, 59);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.Image = global::QuanLyCuaHangVatLieuXayDung.Properties.Resources.man1;
            this.picAvatar.Location = new System.Drawing.Point(136, 21);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(4);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(265, 198);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // labeltenDN
            // 
            this.labeltenDN.AutoSize = true;
            this.labeltenDN.Location = new System.Drawing.Point(587, 84);
            this.labeltenDN.Name = "labeltenDN";
            this.labeltenDN.Size = new System.Drawing.Size(146, 25);
            this.labeltenDN.TabIndex = 1;
            this.labeltenDN.Text = "Tên đăng nhập:";
            // 
            // labelmaTK
            // 
            this.labelmaTK.AutoSize = true;
            this.labelmaTK.Location = new System.Drawing.Point(587, 42);
            this.labelmaTK.Name = "labelmaTK";
            this.labelmaTK.Size = new System.Drawing.Size(133, 25);
            this.labelmaTK.TabIndex = 2;
            this.labelmaTK.Text = "Mã tài khoản:";
            // 
            // labelMK
            // 
            this.labelMK.AutoSize = true;
            this.labelMK.Location = new System.Drawing.Point(587, 135);
            this.labelMK.Name = "labelMK";
            this.labelMK.Size = new System.Drawing.Size(101, 25);
            this.labelMK.TabIndex = 3;
            this.labelMK.Text = "Mật khẩu:";
            // 
            // labeltenCH
            // 
            this.labeltenCH.AutoSize = true;
            this.labeltenCH.Location = new System.Drawing.Point(587, 186);
            this.labeltenCH.Name = "labeltenCH";
            this.labeltenCH.Size = new System.Drawing.Size(136, 25);
            this.labeltenCH.TabIndex = 5;
            this.labeltenCH.Text = "Tên cửa hàng:";
            // 
            // labelSDT
            // 
            this.labelSDT.AutoSize = true;
            this.labelSDT.Location = new System.Drawing.Point(587, 237);
            this.labelSDT.Name = "labelSDT";
            this.labelSDT.Size = new System.Drawing.Size(133, 25);
            this.labelSDT.TabIndex = 6;
            this.labelSDT.Text = "Số điện thoại:";
            // 
            // labeldiaChi
            // 
            this.labeldiaChi.AutoSize = true;
            this.labeldiaChi.Location = new System.Drawing.Point(587, 290);
            this.labeldiaChi.Name = "labeldiaChi";
            this.labeldiaChi.Size = new System.Drawing.Size(82, 25);
            this.labeldiaChi.TabIndex = 7;
            this.labeldiaChi.Text = "Địa chỉ:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(587, 417);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(69, 25);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Text = "Email:";
            // 
            // EmailnganHang
            // 
            this.EmailnganHang.AutoSize = true;
            this.EmailnganHang.Location = new System.Drawing.Point(17, 237);
            this.EmailnganHang.Name = "EmailnganHang";
            this.EmailnganHang.Size = new System.Drawing.Size(110, 25);
            this.EmailnganHang.TabIndex = 9;
            this.EmailnganHang.Text = "Ngân hàng:";
            // 
            // labelSTK
            // 
            this.labelSTK.AutoSize = true;
            this.labelSTK.Location = new System.Drawing.Point(17, 299);
            this.labelSTK.Name = "labelSTK";
            this.labelSTK.Size = new System.Drawing.Size(127, 25);
            this.labelSTK.TabIndex = 10;
            this.labelSTK.Text = "Số tài khoản:";
            // 
            // labelmaQR
            // 
            this.labelmaQR.AutoSize = true;
            this.labelmaQR.Location = new System.Drawing.Point(17, 346);
            this.labelmaQR.Name = "labelmaQR";
            this.labelmaQR.Size = new System.Drawing.Size(83, 25);
            this.labelmaQR.TabIndex = 11;
            this.labelmaQR.Text = "Mã QR:";
            // 
            // txtMaTaiKhoan
            // 
            this.txtMaTaiKhoan.Location = new System.Drawing.Point(760, 34);
            this.txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            this.txtMaTaiKhoan.Size = new System.Drawing.Size(309, 33);
            this.txtMaTaiKhoan.TabIndex = 12;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(760, 84);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(309, 33);
            this.txtTenDangNhap.TabIndex = 13;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(760, 135);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(309, 33);
            this.txtMatKhau.TabIndex = 14;
            // 
            // txtTenCuaHang
            // 
            this.txtTenCuaHang.Location = new System.Drawing.Point(760, 186);
            this.txtTenCuaHang.Name = "txtTenCuaHang";
            this.txtTenCuaHang.Size = new System.Drawing.Size(309, 33);
            this.txtTenCuaHang.TabIndex = 15;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(760, 237);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(309, 33);
            this.txtSoDienThoai.TabIndex = 16;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(760, 287);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(309, 104);
            this.txtDiaChi.TabIndex = 16;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(760, 409);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(309, 33);
            this.txtEmail.TabIndex = 16;
            // 
            // txtSoTaiKhoan
            // 
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(190, 291);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(309, 33);
            this.txtSoTaiKhoan.TabIndex = 16;
            // 
            // cboNganHang
            // 
            this.cboNganHang.FormattingEnabled = true;
            this.cboNganHang.Location = new System.Drawing.Point(190, 237);
            this.cboNganHang.Name = "cboNganHang";
            this.cboNganHang.Size = new System.Drawing.Size(309, 33);
            this.cboNganHang.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUploadImage);
            this.panel1.Controls.Add(this.picQR);
            this.panel1.Controls.Add(this.cboNganHang);
            this.panel1.Controls.Add(this.txtSoTaiKhoan);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtSoDienThoai);
            this.panel1.Controls.Add(this.txtTenCuaHang);
            this.panel1.Controls.Add(this.txtMatKhau);
            this.panel1.Controls.Add(this.txtTenDangNhap);
            this.panel1.Controls.Add(this.txtMaTaiKhoan);
            this.panel1.Controls.Add(this.labelmaQR);
            this.panel1.Controls.Add(this.labelSTK);
            this.panel1.Controls.Add(this.EmailnganHang);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labeldiaChi);
            this.panel1.Controls.Add(this.labelSDT);
            this.panel1.Controls.Add(this.labeltenCH);
            this.panel1.Controls.Add(this.labelMK);
            this.panel1.Controls.Add(this.labelmaTK);
            this.panel1.Controls.Add(this.labeltenDN);
            this.panel1.Controls.Add(this.picAvatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 643);
            this.panel1.TabIndex = 0;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.PaleGreen;
            this.btnUploadImage.Location = new System.Drawing.Point(190, 597);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(281, 46);
            this.btnUploadImage.TabIndex = 0;
            this.btnUploadImage.Text = "Tải ảnh lên";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // picQR
            // 
            this.picQR.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picQR.Location = new System.Drawing.Point(190, 346);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(281, 232);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 18;
            this.picQR.TabStop = false;
            // 
            // Form_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 988);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_TaiKhoan";
            this.Text = "Form_TaiKhoan";
            this.Load += new System.EventHandler(this.Form_TaiKhoan_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label labeltenDN;
        private System.Windows.Forms.Label labelmaTK;
        private System.Windows.Forms.Label labelMK;
        private System.Windows.Forms.Label labeltenCH;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.Label labeldiaChi;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label EmailnganHang;
        private System.Windows.Forms.Label labelSTK;
        private System.Windows.Forms.Label labelmaQR;
        private System.Windows.Forms.TextBox txtMaTaiKhoan;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenCuaHang;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSoTaiKhoan;
        private System.Windows.Forms.ComboBox cboNganHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button btnUploadImage;
    }
}
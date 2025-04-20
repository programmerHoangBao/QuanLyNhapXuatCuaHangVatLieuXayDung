namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_TaoDoiTacMoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TaoDoiTacMoi));
            this.panel_Title = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.panel_Input = new System.Windows.Forms.Panel();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.pictureBoxImageQR = new System.Windows.Forms.PictureBox();
            this.comboBoxNganHang = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelNganHang = new System.Windows.Forms.Label();
            this.txtSoTK = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelSoTK = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.labelDiaChi = new System.Windows.Forms.Label();
            this.txtTenDoiTac = new System.Windows.Forms.TextBox();
            this.labelSDT = new System.Windows.Forms.Label();
            this.labelTenDoiTac = new System.Windows.Forms.Label();
            this.txtMaDoiTac = new System.Windows.Forms.TextBox();
            this.lableMaDoiTac = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTao = new System.Windows.Forms.Button();
            this.panel_Title.SuspendLayout();
            this.panel_Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageQR)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.Controls.Add(this.label_Title);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(678, 60);
            this.panel_Title.TabIndex = 0;
            // 
            // label_Title
            // 
            this.label_Title.BackColor = System.Drawing.Color.LightCoral;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(678, 60);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Tạo đối tác mới";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Input
            // 
            this.panel_Input.Controls.Add(this.btnUploadImage);
            this.panel_Input.Controls.Add(this.pictureBoxImageQR);
            this.panel_Input.Controls.Add(this.comboBoxNganHang);
            this.panel_Input.Controls.Add(this.txtEmail);
            this.panel_Input.Controls.Add(this.labelNganHang);
            this.panel_Input.Controls.Add(this.txtSoTK);
            this.panel_Input.Controls.Add(this.txtDiaChi);
            this.panel_Input.Controls.Add(this.labelEmail);
            this.panel_Input.Controls.Add(this.labelSoTK);
            this.panel_Input.Controls.Add(this.txtSoDienThoai);
            this.panel_Input.Controls.Add(this.labelDiaChi);
            this.panel_Input.Controls.Add(this.txtTenDoiTac);
            this.panel_Input.Controls.Add(this.labelSDT);
            this.panel_Input.Controls.Add(this.labelTenDoiTac);
            this.panel_Input.Controls.Add(this.txtMaDoiTac);
            this.panel_Input.Controls.Add(this.lableMaDoiTac);
            this.panel_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Input.Location = new System.Drawing.Point(0, 60);
            this.panel_Input.Name = "panel_Input";
            this.panel_Input.Size = new System.Drawing.Size(678, 700);
            this.panel_Input.TabIndex = 1;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(222, 623);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(300, 40);
            this.btnUploadImage.TabIndex = 4;
            this.btnUploadImage.Text = "Tải ảnh lên";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // pictureBoxImageQR
            // 
            this.pictureBoxImageQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxImageQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImageQR.Location = new System.Drawing.Point(222, 416);
            this.pictureBoxImageQR.Name = "pictureBoxImageQR";
            this.pictureBoxImageQR.Size = new System.Drawing.Size(300, 200);
            this.pictureBoxImageQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImageQR.TabIndex = 3;
            this.pictureBoxImageQR.TabStop = false;
            // 
            // comboBoxNganHang
            // 
            this.comboBoxNganHang.FormattingEnabled = true;
            this.comboBoxNganHang.Items.AddRange(new object[] {
            "VPBank",
            "BIDV",
            "Vietcombank",
            "VietinBank",
            "MBBANK",
            "ACB",
            "SHB",
            "Techcombank",
            "Agribank",
            "HDBank",
            "LienVietPostBank",
            "VIB",
            "SeABank",
            "VBSP",
            "TPBank",
            "OCB",
            "MSB",
            "Sacombank",
            "Eximbank",
            "SCB",
            "VDB",
            "Nam A Bank",
            "ABBANK",
            "PVcomBank",
            "Bac A Bank",
            "UOB",
            "Woori",
            "HSBC",
            "SCBVL",
            "PBVN",
            "SHBVN",
            "NCB",
            "VietABank",
            "BVBank",
            "Vikki Bank",
            "Vietbank",
            "ANZVL",
            "MBV",
            "CIMB",
            "Kienlongbank",
            "IVB",
            "BAOVIET Bank",
            "SAIGONBANK",
            "Co-opBank",
            "GPBank",
            "VRB",
            "VCBNeo",
            "HLBVN",
            "PGBank"});
            this.comboBoxNganHang.Location = new System.Drawing.Point(222, 295);
            this.comboBoxNganHang.Name = "comboBoxNganHang";
            this.comboBoxNganHang.Size = new System.Drawing.Size(300, 37);
            this.comboBoxNganHang.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(222, 234);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 37);
            this.txtEmail.TabIndex = 1;
            // 
            // labelNganHang
            // 
            this.labelNganHang.AutoSize = true;
            this.labelNganHang.Location = new System.Drawing.Point(70, 295);
            this.labelNganHang.Name = "labelNganHang";
            this.labelNganHang.Size = new System.Drawing.Size(132, 29);
            this.labelNganHang.TabIndex = 0;
            this.labelNganHang.Text = "Ngân hàng:";
            // 
            // txtSoTK
            // 
            this.txtSoTK.Location = new System.Drawing.Point(222, 351);
            this.txtSoTK.Name = "txtSoTK";
            this.txtSoTK.Size = new System.Drawing.Size(300, 37);
            this.txtSoTK.TabIndex = 1;
            this.txtSoTK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTK_KeyPress);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(222, 180);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(300, 37);
            this.txtDiaChi.TabIndex = 1;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(70, 237);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(79, 29);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email:";
            // 
            // labelSoTK
            // 
            this.labelSoTK.AutoSize = true;
            this.labelSoTK.Location = new System.Drawing.Point(70, 354);
            this.labelSoTK.Name = "labelSoTK";
            this.labelSoTK.Size = new System.Drawing.Size(88, 29);
            this.labelSoTK.TabIndex = 0;
            this.labelSoTK.Text = "Số TK:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(222, 125);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(300, 37);
            this.txtSoDienThoai.TabIndex = 1;
            this.txtSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoDienThoai_KeyPress);
            // 
            // labelDiaChi
            // 
            this.labelDiaChi.AutoSize = true;
            this.labelDiaChi.Location = new System.Drawing.Point(70, 183);
            this.labelDiaChi.Name = "labelDiaChi";
            this.labelDiaChi.Size = new System.Drawing.Size(94, 29);
            this.labelDiaChi.TabIndex = 0;
            this.labelDiaChi.Text = "Địa chỉ:";
            // 
            // txtTenDoiTac
            // 
            this.txtTenDoiTac.Location = new System.Drawing.Point(228, 73);
            this.txtTenDoiTac.Name = "txtTenDoiTac";
            this.txtTenDoiTac.Size = new System.Drawing.Size(300, 37);
            this.txtTenDoiTac.TabIndex = 1;
            // 
            // labelSDT
            // 
            this.labelSDT.AutoSize = true;
            this.labelSDT.Location = new System.Drawing.Point(70, 128);
            this.labelSDT.Name = "labelSDT";
            this.labelSDT.Size = new System.Drawing.Size(155, 29);
            this.labelSDT.TabIndex = 0;
            this.labelSDT.Text = "Số điện thoại:";
            // 
            // labelTenDoiTac
            // 
            this.labelTenDoiTac.AutoSize = true;
            this.labelTenDoiTac.Location = new System.Drawing.Point(76, 76);
            this.labelTenDoiTac.Name = "labelTenDoiTac";
            this.labelTenDoiTac.Size = new System.Drawing.Size(137, 29);
            this.labelTenDoiTac.TabIndex = 0;
            this.labelTenDoiTac.Text = "Tên đối tác:";
            // 
            // txtMaDoiTac
            // 
            this.txtMaDoiTac.Location = new System.Drawing.Point(228, 19);
            this.txtMaDoiTac.Name = "txtMaDoiTac";
            this.txtMaDoiTac.Size = new System.Drawing.Size(300, 37);
            this.txtMaDoiTac.TabIndex = 1;
            // 
            // lableMaDoiTac
            // 
            this.lableMaDoiTac.AutoSize = true;
            this.lableMaDoiTac.Location = new System.Drawing.Point(76, 22);
            this.lableMaDoiTac.Name = "lableMaDoiTac";
            this.lableMaDoiTac.Size = new System.Drawing.Size(131, 29);
            this.lableMaDoiTac.TabIndex = 0;
            this.lableMaDoiTac.Text = "Mã đối tác:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 760);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 85);
            this.panel1.TabIndex = 2;
            // 
            // btnTao
            // 
            this.btnTao.BackColor = System.Drawing.Color.Orange;
            this.btnTao.Location = new System.Drawing.Point(512, 21);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(136, 40);
            this.btnTao.TabIndex = 4;
            this.btnTao.Text = "Tạo";
            this.btnTao.UseVisualStyleBackColor = false;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // Form_TaoDoiTacMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(678, 842);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Input);
            this.Controls.Add(this.panel_Title);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(700, 898);
            this.Name = "Form_TaoDoiTacMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_TaoDoiTacMoi";
            this.Load += new System.EventHandler(this.Form_TaoDoiTacMoi_Load);
            this.panel_Title.ResumeLayout(false);
            this.panel_Input.ResumeLayout(false);
            this.panel_Input.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageQR)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Panel panel_Input;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox txtTenDoiTac;
        private System.Windows.Forms.Label labelTenDoiTac;
        private System.Windows.Forms.TextBox txtMaDoiTac;
        private System.Windows.Forms.Label lableMaDoiTac;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label labelDiaChi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelNganHang;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.PictureBox pictureBoxImageQR;
        private System.Windows.Forms.ComboBox comboBoxNganHang;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.Label labelSoTK;
        private System.Windows.Forms.Button btnTao;
    }
}
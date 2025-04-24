namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DangNhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxmatKhau = new System.Windows.Forms.TextBox();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.buttnhdangNhap = new System.Windows.Forms.Button();
            this.checkBoxghiNho = new System.Windows.Forms.CheckBox();
            this.textBoxtenDN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labeltenDN = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.buttnhdangNhap);
            this.panel2.Controls.Add(this.checkBoxghiNho);
            this.panel2.Controls.Add(this.textBoxtenDN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labeltenDN);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 294);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.textBoxmatKhau);
            this.panel3.Controls.Add(this.btnShowPass);
            this.panel3.Location = new System.Drawing.Point(184, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 37);
            this.panel3.TabIndex = 6;
            // 
            // textBoxmatKhau
            // 
            this.textBoxmatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxmatKhau.Location = new System.Drawing.Point(0, 0);
            this.textBoxmatKhau.Name = "textBoxmatKhau";
            this.textBoxmatKhau.Size = new System.Drawing.Size(245, 37);
            this.textBoxmatKhau.TabIndex = 3;
            // 
            // btnShowPass
            // 
            this.btnShowPass.BackgroundImage = global::QuanLyCuaHangVatLieuXayDung.Properties.Resources.view;
            this.btnShowPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPass.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowPass.Location = new System.Drawing.Point(245, 0);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(37, 37);
            this.btnShowPass.TabIndex = 0;
            this.btnShowPass.UseVisualStyleBackColor = true;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // buttnhdangNhap
            // 
            this.buttnhdangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttnhdangNhap.Location = new System.Drawing.Point(17, 215);
            this.buttnhdangNhap.Name = "buttnhdangNhap";
            this.buttnhdangNhap.Size = new System.Drawing.Size(449, 60);
            this.buttnhdangNhap.TabIndex = 5;
            this.buttnhdangNhap.Text = "Đăng nhập";
            this.buttnhdangNhap.UseVisualStyleBackColor = false;
            this.buttnhdangNhap.Click += new System.EventHandler(this.buttnhdangNhap_Click);
            // 
            // checkBoxghiNho
            // 
            this.checkBoxghiNho.AutoSize = true;
            this.checkBoxghiNho.Location = new System.Drawing.Point(344, 160);
            this.checkBoxghiNho.Name = "checkBoxghiNho";
            this.checkBoxghiNho.Size = new System.Drawing.Size(122, 33);
            this.checkBoxghiNho.TabIndex = 4;
            this.checkBoxghiNho.Text = "Ghi nhớ";
            this.checkBoxghiNho.UseVisualStyleBackColor = true;
            // 
            // textBoxtenDN
            // 
            this.textBoxtenDN.Location = new System.Drawing.Point(184, 37);
            this.textBoxtenDN.Name = "textBoxtenDN";
            this.textBoxtenDN.Size = new System.Drawing.Size(282, 37);
            this.textBoxtenDN.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            // 
            // labeltenDN
            // 
            this.labeltenDN.AutoSize = true;
            this.labeltenDN.Location = new System.Drawing.Point(12, 40);
            this.labeltenDN.Name = "labeltenDN";
            this.labeltenDN.Size = new System.Drawing.Size(175, 29);
            this.labeltenDN.TabIndex = 0;
            this.labeltenDN.Text = "Tên đăng nhập:";
            // 
            // Form_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 394);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_DangNhap";
            this.Load += new System.EventHandler(this.Form_DangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttnhdangNhap;
        private System.Windows.Forms.CheckBox checkBoxghiNho;
        private System.Windows.Forms.TextBox textBoxmatKhau;
        private System.Windows.Forms.TextBox textBoxtenDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labeltenDN;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnShowPass;
    }
}
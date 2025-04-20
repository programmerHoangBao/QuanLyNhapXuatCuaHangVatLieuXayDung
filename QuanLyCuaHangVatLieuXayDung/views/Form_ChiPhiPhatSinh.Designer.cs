namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_ChiPhiPhatSinh
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
            this.panelChiPhiPhatSinh = new System.Windows.Forms.Panel();
            this.panelShowChiPhiPhatSinh = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaChiPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiChiPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelLoaiChiPhi = new System.Windows.Forms.Label();
            this.comboBoxLoaiChiPhi = new System.Windows.Forms.ComboBox();
            this.labelThoiGianLap = new System.Windows.Forms.Label();
            this.dateTimePickerThoiGianLap = new System.Windows.Forms.DateTimePicker();
            this.labelMoTa = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelChiPhi = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteVatLieu = new System.Windows.Forms.Button();
            this.btnUpdateVatLieu = new System.Windows.Forms.Button();
            this.btnThemVatLieu = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelChiPhiPhatSinh.SuspendLayout();
            this.panelShowChiPhiPhatSinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // panelChiPhiPhatSinh
            // 
            this.panelChiPhiPhatSinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelChiPhiPhatSinh.Controls.Add(this.panelInput);
            this.panelChiPhiPhatSinh.Controls.Add(this.panelButton);
            this.panelChiPhiPhatSinh.Controls.Add(this.panelTitle);
            this.panelChiPhiPhatSinh.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChiPhiPhatSinh.Location = new System.Drawing.Point(826, 100);
            this.panelChiPhiPhatSinh.Name = "panelChiPhiPhatSinh";
            this.panelChiPhiPhatSinh.Size = new System.Drawing.Size(500, 888);
            this.panelChiPhiPhatSinh.TabIndex = 1;
            // 
            // panelShowChiPhiPhatSinh
            // 
            this.panelShowChiPhiPhatSinh.Controls.Add(this.dataGridView1);
            this.panelShowChiPhiPhatSinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowChiPhiPhatSinh.Location = new System.Drawing.Point(0, 100);
            this.panelShowChiPhiPhatSinh.Name = "panelShowChiPhiPhatSinh";
            this.panelShowChiPhiPhatSinh.Size = new System.Drawing.Size(826, 888);
            this.panelShowChiPhiPhatSinh.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiPhi,
            this.LoaiChiPhi,
            this.ThoiGianLap,
            this.MoTa,
            this.ChiPhi});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(826, 888);
            this.dataGridView1.TabIndex = 0;
            // 
            // MaChiPhi
            // 
            this.MaChiPhi.HeaderText = "Mã chi phí";
            this.MaChiPhi.MinimumWidth = 8;
            this.MaChiPhi.Name = "MaChiPhi";
            // 
            // LoaiChiPhi
            // 
            this.LoaiChiPhi.HeaderText = "Loại chi phí";
            this.LoaiChiPhi.MinimumWidth = 8;
            this.LoaiChiPhi.Name = "LoaiChiPhi";
            // 
            // ThoiGianLap
            // 
            this.ThoiGianLap.HeaderText = "Thời gian lập";
            this.ThoiGianLap.MinimumWidth = 8;
            this.ThoiGianLap.Name = "ThoiGianLap";
            // 
            // MoTa
            // 
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.MinimumWidth = 8;
            this.MoTa.Name = "MoTa";
            // 
            // ChiPhi
            // 
            this.ChiPhi.HeaderText = "Chi phí";
            this.ChiPhi.MinimumWidth = 8;
            this.ChiPhi.Name = "ChiPhi";
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.label_Title);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(500, 60);
            this.panelTitle.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.btnDeleteVatLieu);
            this.panelButton.Controls.Add(this.btnUpdateVatLieu);
            this.panelButton.Controls.Add(this.btnThemVatLieu);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 606);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(500, 282);
            this.panelButton.TabIndex = 1;
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.dateTimePickerThoiGianLap);
            this.panelInput.Controls.Add(this.comboBoxLoaiChiPhi);
            this.panelInput.Controls.Add(this.labelLoaiChiPhi);
            this.panelInput.Controls.Add(this.labelThoiGianLap);
            this.panelInput.Controls.Add(this.textBox2);
            this.panelInput.Controls.Add(this.labelMoTa);
            this.panelInput.Controls.Add(this.textBox3);
            this.panelInput.Controls.Add(this.labelChiPhi);
            this.panelInput.Controls.Add(this.textBox1);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 60);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(500, 546);
            this.panelInput.TabIndex = 2;
            // 
            // label_Title
            // 
            this.label_Title.BackColor = System.Drawing.Color.LightCoral;
            this.label_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(0, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(500, 60);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "Chi phí phát sinh";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã chi phí:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 37);
            this.textBox1.TabIndex = 1;
            // 
            // labelLoaiChiPhi
            // 
            this.labelLoaiChiPhi.AutoSize = true;
            this.labelLoaiChiPhi.Location = new System.Drawing.Point(18, 88);
            this.labelLoaiChiPhi.Name = "labelLoaiChiPhi";
            this.labelLoaiChiPhi.Size = new System.Drawing.Size(143, 29);
            this.labelLoaiChiPhi.TabIndex = 0;
            this.labelLoaiChiPhi.Text = "Loại chi phí:";
            // 
            // comboBoxLoaiChiPhi
            // 
            this.comboBoxLoaiChiPhi.FormattingEnabled = true;
            this.comboBoxLoaiChiPhi.Items.AddRange(new object[] {
            "Dịch vụ",
            "Qùa tặng",
            "Sửa chửa",
            "Khác"});
            this.comboBoxLoaiChiPhi.Location = new System.Drawing.Point(168, 88);
            this.comboBoxLoaiChiPhi.Name = "comboBoxLoaiChiPhi";
            this.comboBoxLoaiChiPhi.Size = new System.Drawing.Size(308, 37);
            this.comboBoxLoaiChiPhi.TabIndex = 2;
            // 
            // labelThoiGianLap
            // 
            this.labelThoiGianLap.AutoSize = true;
            this.labelThoiGianLap.Location = new System.Drawing.Point(18, 162);
            this.labelThoiGianLap.Name = "labelThoiGianLap";
            this.labelThoiGianLap.Size = new System.Drawing.Size(156, 29);
            this.labelThoiGianLap.TabIndex = 0;
            this.labelThoiGianLap.Text = "Thời gian lập:";
            // 
            // dateTimePickerThoiGianLap
            // 
            this.dateTimePickerThoiGianLap.Location = new System.Drawing.Point(190, 164);
            this.dateTimePickerThoiGianLap.Name = "dateTimePickerThoiGianLap";
            this.dateTimePickerThoiGianLap.Size = new System.Drawing.Size(286, 37);
            this.dateTimePickerThoiGianLap.TabIndex = 3;
            // 
            // labelMoTa
            // 
            this.labelMoTa.AutoSize = true;
            this.labelMoTa.Location = new System.Drawing.Point(18, 240);
            this.labelMoTa.Name = "labelMoTa";
            this.labelMoTa.Size = new System.Drawing.Size(81, 29);
            this.labelMoTa.TabIndex = 0;
            this.labelMoTa.Text = "Mô tả:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(156, 237);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(320, 192);
            this.textBox2.TabIndex = 1;
            // 
            // labelChiPhi
            // 
            this.labelChiPhi.AutoSize = true;
            this.labelChiPhi.Location = new System.Drawing.Point(18, 465);
            this.labelChiPhi.Name = "labelChiPhi";
            this.labelChiPhi.Size = new System.Drawing.Size(95, 29);
            this.labelChiPhi.TabIndex = 0;
            this.labelChiPhi.Text = "Chi phí:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 462);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(320, 37);
            this.textBox3.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.Location = new System.Drawing.Point(2, 82);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 42);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnDeleteVatLieu
            // 
            this.btnDeleteVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnDeleteVatLieu.Location = new System.Drawing.Point(326, 25);
            this.btnDeleteVatLieu.Name = "btnDeleteVatLieu";
            this.btnDeleteVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnDeleteVatLieu.TabIndex = 7;
            this.btnDeleteVatLieu.Text = "Xóa";
            this.btnDeleteVatLieu.UseVisualStyleBackColor = false;
            // 
            // btnUpdateVatLieu
            // 
            this.btnUpdateVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateVatLieu.Location = new System.Drawing.Point(168, 25);
            this.btnUpdateVatLieu.Name = "btnUpdateVatLieu";
            this.btnUpdateVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnUpdateVatLieu.TabIndex = 8;
            this.btnUpdateVatLieu.Text = "Chỉnh sửa";
            this.btnUpdateVatLieu.UseVisualStyleBackColor = false;
            // 
            // btnThemVatLieu
            // 
            this.btnThemVatLieu.BackColor = System.Drawing.Color.Orange;
            this.btnThemVatLieu.Location = new System.Drawing.Point(2, 25);
            this.btnThemVatLieu.Name = "btnThemVatLieu";
            this.btnThemVatLieu.Size = new System.Drawing.Size(142, 42);
            this.btnThemVatLieu.TabIndex = 9;
            this.btnThemVatLieu.Text = "Thêm";
            this.btnThemVatLieu.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(306, 22);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(501, 37);
            this.txtTimKiem.TabIndex = 25;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Magenta;
            this.btnTimKiem.Location = new System.Drawing.Point(826, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(136, 47);
            this.btnTimKiem.TabIndex = 26;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // Form_ChiPhiPhatSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 988);
            this.Controls.Add(this.panelShowChiPhiPhatSinh);
            this.Controls.Add(this.panelChiPhiPhatSinh);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form_ChiPhiPhatSinh";
            this.Text = "Form_ChiPhiPhatSinh";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelChiPhiPhatSinh.ResumeLayout(false);
            this.panelShowChiPhiPhatSinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelChiPhiPhatSinh;
        private System.Windows.Forms.Panel panelShowChiPhiPhatSinh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiChiPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianLap;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiPhi;
        private System.Windows.Forms.ComboBox comboBoxLoaiChiPhi;
        private System.Windows.Forms.Label labelLoaiChiPhi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.DateTimePicker dateTimePickerThoiGianLap;
        private System.Windows.Forms.Label labelThoiGianLap;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelMoTa;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label labelChiPhi;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteVatLieu;
        private System.Windows.Forms.Button btnUpdateVatLieu;
        private System.Windows.Forms.Button btnThemVatLieu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}
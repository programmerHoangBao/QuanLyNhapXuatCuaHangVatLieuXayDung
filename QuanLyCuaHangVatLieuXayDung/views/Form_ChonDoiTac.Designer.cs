namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_ChonDoiTac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ChonDoiTac));
            this.panelShowDoiTac = new System.Windows.Forms.Panel();
            this.dataGridViewShowDoiTac = new System.Windows.Forms.DataGridView();
            this.MaDoiTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDoiTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelShowDoiTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowDoiTac)).BeginInit();
            this.SuspendLayout();
            // 
            // panelShowDoiTac
            // 
            this.panelShowDoiTac.Controls.Add(this.dataGridViewShowDoiTac);
            this.panelShowDoiTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowDoiTac.Location = new System.Drawing.Point(0, 0);
            this.panelShowDoiTac.Name = "panelShowDoiTac";
            this.panelShowDoiTac.Size = new System.Drawing.Size(978, 444);
            this.panelShowDoiTac.TabIndex = 1;
            // 
            // dataGridViewShowDoiTac
            // 
            this.dataGridViewShowDoiTac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowDoiTac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowDoiTac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDoiTac,
            this.TenDoiTac,
            this.SoDienThoai,
            this.DiaChi,
            this.btnChon});
            this.dataGridViewShowDoiTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShowDoiTac.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewShowDoiTac.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewShowDoiTac.Name = "dataGridViewShowDoiTac";
            this.dataGridViewShowDoiTac.RowHeadersVisible = false;
            this.dataGridViewShowDoiTac.RowHeadersWidth = 62;
            this.dataGridViewShowDoiTac.RowTemplate.Height = 28;
            this.dataGridViewShowDoiTac.Size = new System.Drawing.Size(978, 444);
            this.dataGridViewShowDoiTac.TabIndex = 1;
            this.dataGridViewShowDoiTac.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShowDoiTac_CellContentClick_1);
            // 
            // MaDoiTac
            // 
            this.MaDoiTac.HeaderText = "Mã";
            this.MaDoiTac.MinimumWidth = 8;
            this.MaDoiTac.Name = "MaDoiTac";
            // 
            // TenDoiTac
            // 
            this.TenDoiTac.HeaderText = "Tên đối tác";
            this.TenDoiTac.MinimumWidth = 8;
            this.TenDoiTac.Name = "TenDoiTac";
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.MinimumWidth = 8;
            this.SoDienThoai.Name = "SoDienThoai";
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 8;
            this.DiaChi.Name = "DiaChi";
            // 
            // btnChon
            // 
            this.btnChon.HeaderText = "Chọn";
            this.btnChon.MinimumWidth = 8;
            this.btnChon.Name = "btnChon";
            // 
            // Form_ChonDoiTac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 444);
            this.Controls.Add(this.panelShowDoiTac);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_ChonDoiTac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ChonDoiTac";
            this.Load += new System.EventHandler(this.Form_ChonDoiTac_Load);
            this.panelShowDoiTac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowDoiTac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelShowDoiTac;
        private System.Windows.Forms.DataGridView dataGridViewShowDoiTac;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDoiTac;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDoiTac;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewButtonColumn btnChon;
    }
}
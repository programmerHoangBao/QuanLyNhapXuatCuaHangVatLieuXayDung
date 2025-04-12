namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_SelectVatLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelectVatLieu));
            this.dataGridViewShowVatLieu = new System.Windows.Forms.DataGridView();
            this.MaVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVatLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChon = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowVatLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShowVatLieu
            // 
            this.dataGridViewShowVatLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShowVatLieu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewShowVatLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShowVatLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVatLieu,
            this.TenVatLieu,
            this.GiaXuat,
            this.GiaNhap,
            this.DonVi,
            this.NhaCungCap,
            this.SoLuong,
            this.btnChon});
            this.dataGridViewShowVatLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShowVatLieu.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewShowVatLieu.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewShowVatLieu.Name = "dataGridViewShowVatLieu";
            this.dataGridViewShowVatLieu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewShowVatLieu.RowHeadersVisible = false;
            this.dataGridViewShowVatLieu.RowHeadersWidth = 80;
            this.dataGridViewShowVatLieu.RowTemplate.Height = 28;
            this.dataGridViewShowVatLieu.Size = new System.Drawing.Size(1378, 544);
            this.dataGridViewShowVatLieu.TabIndex = 0;
            this.dataGridViewShowVatLieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShowVatLieu_CellContentClick);
            // 
            // MaVatLieu
            // 
            this.MaVatLieu.HeaderText = "Mã";
            this.MaVatLieu.MinimumWidth = 10;
            this.MaVatLieu.Name = "MaVatLieu";
            // 
            // TenVatLieu
            // 
            this.TenVatLieu.FillWeight = 290F;
            this.TenVatLieu.HeaderText = "Tên";
            this.TenVatLieu.MinimumWidth = 10;
            this.TenVatLieu.Name = "TenVatLieu";
            // 
            // GiaXuat
            // 
            this.GiaXuat.FillWeight = 195F;
            this.GiaXuat.HeaderText = "Gía xuất";
            this.GiaXuat.MinimumWidth = 10;
            this.GiaXuat.Name = "GiaXuat";
            // 
            // GiaNhap
            // 
            this.GiaNhap.FillWeight = 195F;
            this.GiaNhap.HeaderText = "Gía nhập";
            this.GiaNhap.MinimumWidth = 10;
            this.GiaNhap.Name = "GiaNhap";
            // 
            // DonVi
            // 
            this.DonVi.FillWeight = 195F;
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.MinimumWidth = 10;
            this.DonVi.Name = "DonVi";
            // 
            // NhaCungCap
            // 
            this.NhaCungCap.FillWeight = 195F;
            this.NhaCungCap.HeaderText = "Nhà cung cấp";
            this.NhaCungCap.MinimumWidth = 10;
            this.NhaCungCap.Name = "NhaCungCap";
            // 
            // SoLuong
            // 
            this.SoLuong.FillWeight = 195F;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            // 
            // btnChon
            // 
            this.btnChon.FillWeight = 195F;
            this.btnChon.HeaderText = "Chọn";
            this.btnChon.MinimumWidth = 8;
            this.btnChon.Name = "btnChon";
            this.btnChon.Text = "Chọn";
            // 
            // Form_InsertVatLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 544);
            this.Controls.Add(this.dataGridViewShowVatLieu);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_InsertVatLieu";
            this.Text = "Form_InsertVatLieu";
            this.Load += new System.EventHandler(this.Form_InsertVatLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShowVatLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShowVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVatLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewButtonColumn btnChon;
    }
}
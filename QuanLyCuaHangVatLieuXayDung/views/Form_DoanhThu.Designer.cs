namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_DoanhThu
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
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.comboBoxLocThoiGian = new System.Windows.Forms.ComboBox();
            this.comboBoxLoaiBieuDo = new System.Windows.Forms.ComboBox();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblLocThoiGian = new System.Windows.Forms.Label();
            this.lblLoaiBieuDo = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongTienThanhToan = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelMetrics = new QuanLyCuaHangVatLieuXayDung.views.GradientPanel();
            this.lblTongHoaDonNhap = new System.Windows.Forms.Label();
            this.lblTongHoaDonXuat = new System.Windows.Forms.Label();
            this.lblSoBienLaiTraNo = new System.Windows.Forms.Label();
            this.lblSoNoChuaTra = new System.Windows.Forms.Label();
            this.lblTongGiaTriHoaDonNhap = new System.Windows.Forms.Label();
            this.lblTongGiaTriHoaDonXuat = new System.Windows.Forms.Label();
            this.lblTongGiaTriNoChuaTra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panelMetrics.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(114, 21);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(228, 22);
            this.dtpTuNgay.TabIndex = 0;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(441, 21);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(228, 22);
            this.dtpDenNgay.TabIndex = 1;
            // 
            // comboBoxLocThoiGian
            // 
            this.comboBoxLocThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocThoiGian.Location = new System.Drawing.Point(790, 21);
            this.comboBoxLocThoiGian.Name = "comboBoxLocThoiGian";
            this.comboBoxLocThoiGian.Size = new System.Drawing.Size(171, 24);
            this.comboBoxLocThoiGian.TabIndex = 2;
            this.comboBoxLocThoiGian.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocThoiGian_SelectedIndexChanged);
            // 
            // comboBoxLoaiBieuDo
            // 
            this.comboBoxLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoaiBieuDo.Location = new System.Drawing.Point(1074, 21);
            this.comboBoxLoaiBieuDo.Name = "comboBoxLoaiBieuDo";
            this.comboBoxLoaiBieuDo.Size = new System.Drawing.Size(171, 24);
            this.comboBoxLoaiBieuDo.TabIndex = 3;
            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.BackColor = System.Drawing.Color.Orange;
            this.btnXemDoanhThu.Location = new System.Drawing.Point(1269, 21);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(137, 37);
            this.btnXemDoanhThu.TabIndex = 4;
            this.btnXemDoanhThu.Text = "Xem doanh thu";
            this.btnXemDoanhThu.UseVisualStyleBackColor = false;
            this.btnXemDoanhThu.Click += new System.EventHandler(this.btnXemDoanhThu_Click);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(23, 26);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(59, 16);
            this.lblTuNgay.TabIndex = 5;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(361, 26);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(67, 16);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblLocThoiGian
            // 
            this.lblLocThoiGian.AutoSize = true;
            this.lblLocThoiGian.Location = new System.Drawing.Point(686, 26);
            this.lblLocThoiGian.Name = "lblLocThoiGian";
            this.lblLocThoiGian.Size = new System.Drawing.Size(85, 16);
            this.lblLocThoiGian.TabIndex = 7;
            this.lblLocThoiGian.Text = "Lọc thời gian:";
            // 
            // lblLoaiBieuDo
            // 
            this.lblLoaiBieuDo.AutoSize = true;
            this.lblLoaiBieuDo.Location = new System.Drawing.Point(983, 26);
            this.lblLoaiBieuDo.Name = "lblLoaiBieuDo";
            this.lblLoaiBieuDo.Size = new System.Drawing.Size(84, 16);
            this.lblLoaiBieuDo.TabIndex = 8;
            this.lblLoaiBieuDo.Text = "Loại biểu đồ:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(23, 75);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(186, 28);
            this.lblTongDoanhThu.TabIndex = 9;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0";
            // 
            // lblTongTienThanhToan
            // 
            this.lblTongTienThanhToan.AutoSize = true;
            this.lblTongTienThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTienThanhToan.Location = new System.Drawing.Point(373, 75);
            this.lblTongTienThanhToan.Name = "lblTongTienThanhToan";
            this.lblTongTienThanhToan.Size = new System.Drawing.Size(0, 28);
            this.lblTongTienThanhToan.TabIndex = 10;
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Location = new System.Drawing.Point(23, 107);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(1383, 480);
            this.chartDoanhThu.TabIndex = 11;
            this.chartDoanhThu.Text = "chartDoanhThu";
            // 
            // panelMetrics
            // 
            this.panelMetrics.Controls.Add(this.lblTongHoaDonNhap);
            this.panelMetrics.Controls.Add(this.lblTongHoaDonXuat);
            this.panelMetrics.Controls.Add(this.lblSoBienLaiTraNo);
            this.panelMetrics.Controls.Add(this.lblSoNoChuaTra);
            this.panelMetrics.Controls.Add(this.lblTongGiaTriHoaDonNhap);
            this.panelMetrics.Controls.Add(this.lblTongGiaTriHoaDonXuat);
            this.panelMetrics.Controls.Add(this.lblTongGiaTriNoChuaTra);
            this.panelMetrics.Location = new System.Drawing.Point(23, 607);
            this.panelMetrics.Name = "panelMetrics";
            this.panelMetrics.Size = new System.Drawing.Size(1383, 80);
            this.panelMetrics.TabIndex = 12;
            // 
            // lblTongHoaDonNhap
            // 
            this.lblTongHoaDonNhap.AutoSize = true;
            this.lblTongHoaDonNhap.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblTongHoaDonNhap.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDonNhap.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblTongHoaDonNhap.Location = new System.Drawing.Point(30, 15);
            this.lblTongHoaDonNhap.Name = "lblTongHoaDonNhap";
            this.lblTongHoaDonNhap.Size = new System.Drawing.Size(0, 29);
            this.lblTongHoaDonNhap.TabIndex = 0;
            // 
            // lblTongHoaDonXuat
            // 
            this.lblTongHoaDonXuat.AutoSize = true;
            this.lblTongHoaDonXuat.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblTongHoaDonXuat.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDonXuat.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblTongHoaDonXuat.Location = new System.Drawing.Point(380, 15);
            this.lblTongHoaDonXuat.Name = "lblTongHoaDonXuat";
            this.lblTongHoaDonXuat.Size = new System.Drawing.Size(0, 29);
            this.lblTongHoaDonXuat.TabIndex = 1;
            // 
            // lblSoBienLaiTraNo
            // 
            this.lblSoBienLaiTraNo.AutoSize = true;
            this.lblSoBienLaiTraNo.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblSoBienLaiTraNo.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoBienLaiTraNo.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblSoBienLaiTraNo.Location = new System.Drawing.Point(730, 15);
            this.lblSoBienLaiTraNo.Name = "lblSoBienLaiTraNo";
            this.lblSoBienLaiTraNo.Size = new System.Drawing.Size(0, 29);
            this.lblSoBienLaiTraNo.TabIndex = 2;
            // 
            // lblSoNoChuaTra
            // 
            this.lblSoNoChuaTra.AutoSize = true;
            this.lblSoNoChuaTra.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblSoNoChuaTra.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoNoChuaTra.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblSoNoChuaTra.Location = new System.Drawing.Point(1080, 15);
            this.lblSoNoChuaTra.Name = "lblSoNoChuaTra";
            this.lblSoNoChuaTra.Size = new System.Drawing.Size(0, 29);
            this.lblSoNoChuaTra.TabIndex = 3;
            // 
            // lblTongGiaTriHoaDonNhap
            // 
            this.lblTongGiaTriHoaDonNhap.AutoSize = true;
            this.lblTongGiaTriHoaDonNhap.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblTongGiaTriHoaDonNhap.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTriHoaDonNhap.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblTongGiaTriHoaDonNhap.Location = new System.Drawing.Point(30, 45);
            this.lblTongGiaTriHoaDonNhap.Name = "lblTongGiaTriHoaDonNhap";
            this.lblTongGiaTriHoaDonNhap.Size = new System.Drawing.Size(0, 29);
            this.lblTongGiaTriHoaDonNhap.TabIndex = 4;
            // 
            // lblTongGiaTriHoaDonXuat
            // 
            this.lblTongGiaTriHoaDonXuat.AutoSize = true;
            this.lblTongGiaTriHoaDonXuat.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblTongGiaTriHoaDonXuat.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTriHoaDonXuat.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblTongGiaTriHoaDonXuat.Location = new System.Drawing.Point(480, 45);
            this.lblTongGiaTriHoaDonXuat.Name = "lblTongGiaTriHoaDonXuat";
            this.lblTongGiaTriHoaDonXuat.Size = new System.Drawing.Size(0, 29);
            this.lblTongGiaTriHoaDonXuat.TabIndex = 5;
            // 
            // lblTongGiaTriNoChuaTra
            // 
            this.lblTongGiaTriNoChuaTra.AutoSize = true;
            this.lblTongGiaTriNoChuaTra.BackColor = System.Drawing.Color.Transparent; // Đảm bảo nền trong suốt
            this.lblTongGiaTriNoChuaTra.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTriNoChuaTra.ForeColor = System.Drawing.Color.White; // Chữ trắng
            this.lblTongGiaTriNoChuaTra.Location = new System.Drawing.Point(930, 45);
            this.lblTongGiaTriNoChuaTra.Name = "lblTongGiaTriNoChuaTra";
            this.lblTongGiaTriNoChuaTra.Size = new System.Drawing.Size(0, 29);
            this.lblTongGiaTriNoChuaTra.TabIndex = 6;
            // 
            // Form_DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 721);
            this.Controls.Add(this.panelMetrics);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.lblTongTienThanhToan);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.lblLoaiBieuDo);
            this.Controls.Add(this.lblLocThoiGian);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.btnXemDoanhThu);
            this.Controls.Add(this.comboBoxLoaiBieuDo);
            this.Controls.Add(this.comboBoxLocThoiGian);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Name = "Form_DoanhThu";
            this.Text = "Doanh thu cửa hàng";
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panelMetrics.ResumeLayout(false);
            this.panelMetrics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.ComboBox comboBoxLocThoiGian;
        private System.Windows.Forms.ComboBox comboBoxLoaiBieuDo;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblLocThoiGian;
        private System.Windows.Forms.Label lblLoaiBieuDo;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTongTienThanhToan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private QuanLyCuaHangVatLieuXayDung.views.GradientPanel panelMetrics;
        private System.Windows.Forms.Label lblTongHoaDonNhap;
        private System.Windows.Forms.Label lblTongHoaDonXuat;
        private System.Windows.Forms.Label lblSoBienLaiTraNo;
        private System.Windows.Forms.Label lblSoNoChuaTra;
        private System.Windows.Forms.Label lblTongGiaTriHoaDonNhap;
        private System.Windows.Forms.Label lblTongGiaTriHoaDonXuat;
        private System.Windows.Forms.Label lblTongGiaTriNoChuaTra;
    }
}
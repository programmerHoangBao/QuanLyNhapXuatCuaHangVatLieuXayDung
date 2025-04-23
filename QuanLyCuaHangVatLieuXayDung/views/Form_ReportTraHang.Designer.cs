namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_ReportTraHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportTraHang));
            this.reportViewerTraHang = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerTraHang
            // 
            this.reportViewerTraHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerTraHang.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTraHang.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reportViewerTraHang.Name = "reportViewerTraHang";
            this.reportViewerTraHang.ServerReport.BearerToken = null;
            this.reportViewerTraHang.Size = new System.Drawing.Size(778, 744);
            this.reportViewerTraHang.TabIndex = 0;
            // 
            // Form_ReportTraHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.reportViewerTraHang);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_ReportTraHang";
            this.Text = "Form_ReportTraHang";
            this.Load += new System.EventHandler(this.Form_ReportTraHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTraHang;
    }
}
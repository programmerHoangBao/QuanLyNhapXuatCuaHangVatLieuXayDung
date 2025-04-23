namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_ReportPhieuGhiNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportPhieuGhiNo));
            this.reportViewerPhieuGhiNo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPhieuGhiNo
            // 
            this.reportViewerPhieuGhiNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerPhieuGhiNo.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPhieuGhiNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.reportViewerPhieuGhiNo.Name = "reportViewerPhieuGhiNo";
            this.reportViewerPhieuGhiNo.ServerReport.BearerToken = null;
            this.reportViewerPhieuGhiNo.Size = new System.Drawing.Size(778, 744);
            this.reportViewerPhieuGhiNo.TabIndex = 0;
            // 
            // Form_ReportPhieuGhiNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.reportViewerPhieuGhiNo);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form_ReportPhieuGhiNo";
            this.Text = "Form_ReportPhieuGhiNo";
            this.Load += new System.EventHandler(this.Form_ReportPhieuGhiNo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPhieuGhiNo;
    }
}
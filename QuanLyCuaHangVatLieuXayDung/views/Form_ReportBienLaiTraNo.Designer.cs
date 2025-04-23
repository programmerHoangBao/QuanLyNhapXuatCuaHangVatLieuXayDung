namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class Form_ReportBienLaiTraNo
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
            this.reportViewerBienLaiTraNo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerBienLaiTraNo
            // 
            this.reportViewerBienLaiTraNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerBienLaiTraNo.Location = new System.Drawing.Point(0, 0);
            this.reportViewerBienLaiTraNo.Name = "reportViewerBienLaiTraNo";
            this.reportViewerBienLaiTraNo.ServerReport.BearerToken = null;
            this.reportViewerBienLaiTraNo.Size = new System.Drawing.Size(778, 744);
            this.reportViewerBienLaiTraNo.TabIndex = 0;
            // 
            // Form_ReportBienLaiTraNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.reportViewerBienLaiTraNo);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form_ReportBienLaiTraNo";
            this.Text = "Form_ReportBienLaiTraNo";
            this.Load += new System.EventHandler(this.Form_ReportBienLaiTraNo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerBienLaiTraNo;
    }
}
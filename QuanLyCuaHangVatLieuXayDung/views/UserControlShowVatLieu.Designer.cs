namespace QuanLyCuaHangVatLieuXayDung.views
{
    partial class UserControlShowVatLieu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelBody = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelBody
            // 
            this.tableLayoutPanelBody.ColumnCount = 1;
            this.tableLayoutPanelBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBody.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanelBody.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBody.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBody.Name = "tableLayoutPanelBody";
            this.tableLayoutPanelBody.RowCount = 2;
            this.tableLayoutPanelBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBody.Size = new System.Drawing.Size(350, 400);
            this.tableLayoutPanelBody.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Controls.Add(this.btnTransaction);
            this.panel1.Controls.Add(this.labelQuantity);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 194);
            this.panel1.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(118, 25);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Tên vât liệu";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPrice.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(0, 25);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(44, 25);
            this.labelPrice.TabIndex = 0;
            this.labelPrice.Text = "Gía";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQuantity.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantity.Location = new System.Drawing.Point(0, 50);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(91, 25);
            this.labelQuantity.TabIndex = 0;
            this.labelQuantity.Text = "Số lượng";
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransaction.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.Location = new System.Drawing.Point(0, 75);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(344, 35);
            this.btnTransaction.TabIndex = 1;
            this.btnTransaction.Text = "Giao dịch";
            this.btnTransaction.UseVisualStyleBackColor = false;
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDetail.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.Location = new System.Drawing.Point(0, 110);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(344, 35);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBoxImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 194);
            this.panel2.TabIndex = 1;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(344, 194);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // UserControlShowVatLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.tableLayoutPanelBody);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControlShowVatLieu";
            this.Size = new System.Drawing.Size(350, 400);
            this.tableLayoutPanelBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}

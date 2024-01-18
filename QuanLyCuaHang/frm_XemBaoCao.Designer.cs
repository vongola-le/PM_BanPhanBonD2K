namespace QuanLyCuaHang
{
    partial class frm_XemBaoCao
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
            this.rpvBaoCao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radSanPham = new System.Windows.Forms.RadioButton();
            this.radHoaDon = new System.Windows.Forms.RadioButton();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvBaoCao
            // 
            this.rpvBaoCao.Location = new System.Drawing.Point(2, 13);
            this.rpvBaoCao.Name = "rpvBaoCao";
            this.rpvBaoCao.ServerReport.BearerToken = null;
            this.rpvBaoCao.Size = new System.Drawing.Size(928, 682);
            this.rpvBaoCao.TabIndex = 0;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(1005, 130);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(127, 46);
            this.btnXemBaoCao.TabIndex = 1;
            this.btnXemBaoCao.Text = "Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.radSanPham);
            this.groupBox1.Controls.Add(this.radHoaDon);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(936, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // radSanPham
            // 
            this.radSanPham.AutoSize = true;
            this.radSanPham.Location = new System.Drawing.Point(6, 71);
            this.radSanPham.Name = "radSanPham";
            this.radSanPham.Size = new System.Drawing.Size(90, 20);
            this.radSanPham.TabIndex = 1;
            this.radSanPham.TabStop = true;
            this.radSanPham.Text = "Sản Phẩm";
            this.radSanPham.UseVisualStyleBackColor = true;
            // 
            // radHoaDon
            // 
            this.radHoaDon.AutoSize = true;
            this.radHoaDon.Location = new System.Drawing.Point(6, 30);
            this.radHoaDon.Name = "radHoaDon";
            this.radHoaDon.Size = new System.Drawing.Size(80, 20);
            this.radHoaDon.TabIndex = 0;
            this.radHoaDon.TabStop = true;
            this.radHoaDon.Text = "Hóa đơn";
            this.radHoaDon.UseVisualStyleBackColor = true;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(103, 27);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(119, 22);
            this.dtpNgayLap.TabIndex = 2;
            // 
            // frm_XemBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1197, 685);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.rpvBaoCao);
            this.Name = "frm_XemBaoCao";
            this.Text = "frm_XemBaoCao";
            this.Load += new System.EventHandler(this.frm_XemBaoCao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBaoCao;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radSanPham;
        private System.Windows.Forms.RadioButton radHoaDon;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
    }
}
namespace QuanLyCuaHang
{
    partial class frm_HoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.MAHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYLAYHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MANV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENTRANGTHAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANGTHAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaHD = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayLapHD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.radMaNV = new System.Windows.Forms.RadioButton();
            this.radNgayLapHD = new System.Windows.Forms.RadioButton();
            this.radMaHD = new System.Windows.Forms.RadioButton();
            this.btnLapHD = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(541, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa Đơn";
            // 
            // dgvHD
            // 
            this.dgvHD.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvHD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHD.ColumnHeadersHeight = 24;
            this.dgvHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAHD,
            this.NGAYLAYHD,
            this.MANV,
            this.TENTRANGTHAI,
            this.TRANGTHAI});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHD.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHD.EnableHeadersVisualStyles = false;
            this.dgvHD.Location = new System.Drawing.Point(429, 96);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHD.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHD.RowHeadersWidth = 51;
            this.dgvHD.RowTemplate.Height = 24;
            this.dgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHD.Size = new System.Drawing.Size(774, 606);
            this.dgvHD.TabIndex = 18;
            this.dgvHD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHD_CellFormatting);
            // 
            // MAHD
            // 
            this.MAHD.DataPropertyName = "MAHD";
            this.MAHD.HeaderText = "Mã hóa đơn";
            this.MAHD.MinimumWidth = 6;
            this.MAHD.Name = "MAHD";
            // 
            // NGAYLAYHD
            // 
            this.NGAYLAYHD.DataPropertyName = "NGAYLAYHD";
            this.NGAYLAYHD.HeaderText = "Ngày lập hóa đơn";
            this.NGAYLAYHD.MinimumWidth = 6;
            this.NGAYLAYHD.Name = "NGAYLAYHD";
            // 
            // MANV
            // 
            this.MANV.DataPropertyName = "MANV";
            this.MANV.HeaderText = "Mã nhân viên";
            this.MANV.MinimumWidth = 6;
            this.MANV.Name = "MANV";
            // 
            // TENTRANGTHAI
            // 
            this.TENTRANGTHAI.HeaderText = "Trạng thái";
            this.TENTRANGTHAI.MinimumWidth = 6;
            this.TENTRANGTHAI.Name = "TENTRANGTHAI";
            // 
            // TRANGTHAI
            // 
            this.TRANGTHAI.DataPropertyName = "TRANGTHAI";
            this.TRANGTHAI.HeaderText = "Trạng thái";
            this.TRANGTHAI.MinimumWidth = 6;
            this.TRANGTHAI.Name = "TRANGTHAI";
            this.TRANGTHAI.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.dtpNgayLapHD);
            this.groupBox1.Controls.Add(this.radMaNV);
            this.groupBox1.Controls.Add(this.radNgayLapHD);
            this.groupBox1.Controls.Add(this.radMaHD);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(23, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 272);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm hóa đơn";
            // 
            // txtMaNV
            // 
            this.txtMaNV.BorderRadius = 10;
            this.txtMaNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNV.DefaultText = "";
            this.txtMaNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.txtMaNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNV.Location = new System.Drawing.Point(151, 180);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.PasswordChar = '\0';
            this.txtMaNV.PlaceholderText = "";
            this.txtMaNV.SelectedText = "";
            this.txtMaNV.Size = new System.Drawing.Size(193, 40);
            this.txtMaNV.TabIndex = 26;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderRadius = 10;
            this.txtMaHD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHD.DefaultText = "";
            this.txtMaHD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.txtMaHD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHD.Location = new System.Drawing.Point(151, 41);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.PasswordChar = '\0';
            this.txtMaHD.PlaceholderText = "";
            this.txtMaHD.SelectedText = "";
            this.txtMaHD.Size = new System.Drawing.Size(193, 40);
            this.txtMaHD.TabIndex = 25;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // dtpNgayLapHD
            // 
            this.dtpNgayLapHD.BorderRadius = 10;
            this.dtpNgayLapHD.Checked = true;
            this.dtpNgayLapHD.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLapHD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtpNgayLapHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayLapHD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLapHD.Location = new System.Drawing.Point(151, 113);
            this.dtpNgayLapHD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayLapHD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayLapHD.Name = "dtpNgayLapHD";
            this.dtpNgayLapHD.Size = new System.Drawing.Size(193, 36);
            this.dtpNgayLapHD.TabIndex = 24;
            this.dtpNgayLapHD.Value = new System.DateTime(2023, 5, 26, 16, 13, 4, 794);
            this.dtpNgayLapHD.ValueChanged += new System.EventHandler(this.dtpNgayLapHD_ValueChanged);
            // 
            // radMaNV
            // 
            this.radMaNV.AutoSize = true;
            this.radMaNV.Location = new System.Drawing.Point(7, 200);
            this.radMaNV.Name = "radMaNV";
            this.radMaNV.Size = new System.Drawing.Size(110, 20);
            this.radMaNV.TabIndex = 22;
            this.radMaNV.TabStop = true;
            this.radMaNV.Text = "Mã nhân viên:";
            this.radMaNV.UseVisualStyleBackColor = true;
            // 
            // radNgayLapHD
            // 
            this.radNgayLapHD.AutoSize = true;
            this.radNgayLapHD.Location = new System.Drawing.Point(7, 129);
            this.radNgayLapHD.Name = "radNgayLapHD";
            this.radNgayLapHD.Size = new System.Drawing.Size(138, 20);
            this.radNgayLapHD.TabIndex = 20;
            this.radNgayLapHD.TabStop = true;
            this.radNgayLapHD.Text = "Ngày lập hóa đơn:";
            this.radNgayLapHD.UseVisualStyleBackColor = true;
            // 
            // radMaHD
            // 
            this.radMaHD.AutoSize = true;
            this.radMaHD.Location = new System.Drawing.Point(7, 61);
            this.radMaHD.Name = "radMaHD";
            this.radMaHD.Size = new System.Drawing.Size(105, 20);
            this.radMaHD.TabIndex = 18;
            this.radMaHD.TabStop = true;
            this.radMaHD.Text = "Mã hóa đơn: ";
            this.radMaHD.UseVisualStyleBackColor = true;
            // 
            // btnLapHD
            // 
            this.btnLapHD.AutoRoundedCorners = true;
            this.btnLapHD.BorderColor = System.Drawing.Color.IndianRed;
            this.btnLapHD.BorderRadius = 21;
            this.btnLapHD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLapHD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLapHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLapHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLapHD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLapHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLapHD.ForeColor = System.Drawing.Color.Black;
            this.btnLapHD.Location = new System.Drawing.Point(121, 392);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(180, 45);
            this.btnLapHD.TabIndex = 20;
            this.btnLapHD.Text = "Lập hóa đơn";
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // frm_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1215, 732);
            this.Controls.Add(this.btnLapHD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_HoaDon";
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.frm_HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYLAYHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENTRANGTHAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANGTHAI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNgayLapHD;
        private System.Windows.Forms.RadioButton radMaHD;
        private System.Windows.Forms.RadioButton radMaNV;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNV;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHD;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayLapHD;
        private Guna.UI2.WinForms.Guna2Button btnLapHD;
    }
}
﻿namespace QuanLyCafe_ADO
{
    partial class frmThongKeTheoNgay
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
            this.dtgvThongKeTheoNgay = new System.Windows.Forms.DataGridView();
            this.TenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MC = new System.Windows.Forms.MonthCalendar();
            this.btnInBangThongKe = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbNgay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeTheoNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvThongKeTheoNgay
            // 
            this.dtgvThongKeTheoNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongKeTheoNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeTheoNgay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenHang,
            this.Gia,
            this.SoLuongMua,
            this.ThanhTien,
            this.NgayBan});
            this.dtgvThongKeTheoNgay.Location = new System.Drawing.Point(18, 192);
            this.dtgvThongKeTheoNgay.Name = "dtgvThongKeTheoNgay";
            this.dtgvThongKeTheoNgay.Size = new System.Drawing.Size(524, 150);
            this.dtgvThongKeTheoNgay.TabIndex = 7;
            // 
            // TenHang
            // 
            this.TenHang.DataPropertyName = "TenHang";
            this.TenHang.HeaderText = "Tên hàng";
            this.TenHang.Name = "TenHang";
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            // 
            // SoLuongMua
            // 
            this.SoLuongMua.DataPropertyName = "SoLuongMua";
            this.SoLuongMua.HeaderText = "Số lượng mua";
            this.SoLuongMua.Name = "SoLuongMua";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // NgayBan
            // 
            this.NgayBan.DataPropertyName = "NgayBan";
            this.NgayBan.HeaderText = "Ngày bán";
            this.NgayBan.Name = "NgayBan";
            // 
            // MC
            // 
            this.MC.Location = new System.Drawing.Point(6, 2);
            this.MC.Name = "MC";
            this.MC.TabIndex = 6;
            this.MC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MC_DateChanged);
            // 
            // btnInBangThongKe
            // 
            this.btnInBangThongKe.Location = new System.Drawing.Point(227, 348);
            this.btnInBangThongKe.Name = "btnInBangThongKe";
            this.btnInBangThongKe.Size = new System.Drawing.Size(130, 23);
            this.btnInBangThongKe.TabIndex = 11;
            this.btnInBangThongKe.Text = "In bảng thống kê";
            this.btnInBangThongKe.UseVisualStyleBackColor = true;
            this.btnInBangThongKe.Click += new System.EventHandler(this.btnInBangThongKe_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Các mặt hàng bán trong ngày";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Red;
            this.lbTongTien.Location = new System.Drawing.Point(300, 57);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(84, 20);
            this.lbTongTien.TabIndex = 9;
            this.lbTongTien.Text = "Tổng tiền";
            // 
            // lbNgay
            // 
            this.lbNgay.AutoSize = true;
            this.lbNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay.ForeColor = System.Drawing.Color.Red;
            this.lbNgay.Location = new System.Drawing.Point(300, 11);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(49, 20);
            this.lbNgay.TabIndex = 8;
            this.lbNgay.Text = "Ngày";
            // 
            // frmThongKeTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 373);
            this.Controls.Add(this.dtgvThongKeTheoNgay);
            this.Controls.Add(this.MC);
            this.Controls.Add(this.btnInBangThongKe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.lbNgay);
            this.Name = "frmThongKeTheoNgay";
            this.Text = "Thống kê bán hàng trong ngày";
            this.Load += new System.EventHandler(this.frmThongKeTheoNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeTheoNgay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvThongKeTheoNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBan;
        private System.Windows.Forms.MonthCalendar MC;
        private System.Windows.Forms.Button btnInBangThongKe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbNgay;
    }
}
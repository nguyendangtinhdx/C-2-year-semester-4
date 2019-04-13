namespace BaiTap5_LinQ
{
    partial class frmLinQ
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTongSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblMaxGia = new System.Windows.Forms.Label();
            this.lblMinGia = new System.Windows.Forms.Label();
            this.lblTBGia = new System.Windows.Forms.Label();
            this.lblTongThanhTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.masach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masach,
            this.tensach});
            this.dataGridView1.Location = new System.Drawing.Point(181, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(665, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(163, 329);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongSL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(858, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTongSL
            // 
            this.lblTongSL.Name = "lblTongSL";
            this.lblTongSL.Size = new System.Drawing.Size(111, 17);
            this.lblTongSL.Text = "Tổng số lượng sách";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(178, 308);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(46, 13);
            this.lblTong.TabIndex = 4;
            this.lblTong.Text = "Số sách";
            // 
            // lblMaxGia
            // 
            this.lblMaxGia.AutoSize = true;
            this.lblMaxGia.Location = new System.Drawing.Point(280, 308);
            this.lblMaxGia.Name = "lblMaxGia";
            this.lblMaxGia.Size = new System.Drawing.Size(44, 13);
            this.lblMaxGia.TabIndex = 5;
            this.lblMaxGia.Text = "Max giá";
            // 
            // lblMinGia
            // 
            this.lblMinGia.AutoSize = true;
            this.lblMinGia.Location = new System.Drawing.Point(401, 308);
            this.lblMinGia.Name = "lblMinGia";
            this.lblMinGia.Size = new System.Drawing.Size(41, 13);
            this.lblMinGia.TabIndex = 6;
            this.lblMinGia.Text = "Min giá";
            // 
            // lblTBGia
            // 
            this.lblTBGia.AutoSize = true;
            this.lblTBGia.Location = new System.Drawing.Point(517, 308);
            this.lblTBGia.Name = "lblTBGia";
            this.lblTBGia.Size = new System.Drawing.Size(75, 13);
            this.lblTBGia.TabIndex = 7;
            this.lblTBGia.Text = "Trung bình giá";
            // 
            // lblTongThanhTien
            // 
            this.lblTongThanhTien.AutoSize = true;
            this.lblTongThanhTien.Location = new System.Drawing.Point(673, 308);
            this.lblTongThanhTien.Name = "lblTongThanhTien";
            this.lblTongThanhTien.Size = new System.Drawing.Size(82, 13);
            this.lblTongThanhTien.TabIndex = 8;
            this.lblTongThanhTien.Text = "Tổng thành tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nhập tên sách hoặc tác giả";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(368, 21);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(190, 20);
            this.txtTim.TabIndex = 10;
            this.txtTim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTim_KeyPress);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(745, 21);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 12;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // masach
            // 
            this.masach.DataPropertyName = "masach";
            this.masach.HeaderText = "Mã sách";
            this.masach.Name = "masach";
            // 
            // tensach
            // 
            this.tensach.DataPropertyName = "Tensach";
            this.tensach.HeaderText = "Tên sách";
            this.tensach.Name = "tensach";
            // 
            // frmLinQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 357);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTongThanhTien);
            this.Controls.Add(this.lblTBGia);
            this.Controls.Add(this.lblMinGia);
            this.Controls.Add(this.lblMaxGia);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLinQ";
            this.Text = "frmLinQ";
            this.Load += new System.EventHandler(this.frmLinQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSL;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblMaxGia;
        private System.Windows.Forms.Label lblMinGia;
        private System.Windows.Forms.Label lblTBGia;
        private System.Windows.Forms.Label lblTongThanhTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensach;
    }
}
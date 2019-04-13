namespace BaiTap6_ADO
{
    partial class frmUpPicture
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
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnUpPicture = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(134, 15);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(153, 20);
            this.txtImage.TabIndex = 6;
            // 
            // btnUpPicture
            // 
            this.btnUpPicture.Location = new System.Drawing.Point(12, 13);
            this.btnUpPicture.Name = "btnUpPicture";
            this.btnUpPicture.Size = new System.Drawing.Size(100, 23);
            this.btnUpPicture.TabIndex = 5;
            this.btnUpPicture.Text = "Chọn và tải ảnh";
            this.btnUpPicture.UseVisualStyleBackColor = true;
            this.btnUpPicture.Click += new System.EventHandler(this.btnUpPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 188);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmUpPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 275);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.btnUpPicture);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmUpPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUpPicture";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnUpPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
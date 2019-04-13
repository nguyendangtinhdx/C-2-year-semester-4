using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap6_ADO
{
    public partial class frmUpPicture : Form
    {
        public frmUpPicture()
        {
            InitializeComponent();
        }

        private void btnUpPicture_Click(object sender, EventArgs e)
        {
            try
            {
                SearchImage();
                // Hỏi trước khi lưu ảnh
                DialogResult Question = MessageBox.Show("Bạn đã chọn đúng ảnh cần lưu chưa ?", "Lưu ảnh, Yes/No ?", MessageBoxButtons.YesNoCancel);
                if (Question == DialogResult.Yes)
                {
                    SaveImage();
                    //pictureBox1.Image = null;
                    MessageBox.Show("Ảnh đã được lưu thành công!");
                }
                if (Question == DialogResult.No)
                {
                    btnUpPicture_Click(null, null);
                }
                if (Question == DialogResult.Cancel)
                {
                    pictureBox1.Image = null;
                    //loadToolStripMenuItem_Click(null, null);
                }
            }
            catch
            {
            }
        }
        //a. Khởi tạo hàm Mở Dialog tìm ảnh
        private void SearchImage()
        {
            openFileDialog1.InitialDirectory = (@"C:\Users\nguye\Downloads");//Định đường dẫn khi mở cửa sổ tìm ảnh
            openFileDialog1.FileName = "";// Tên ảnh
            openFileDialog1.Filter = "Images(*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();// Hiện cửa sổ 
            if (openFileDialog1.FileName != "")
            {
                txtImage.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);// Hiển thị tên ảnh lên Textbox
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);//Hiện ảnh lên Picbox.
                //System.IO.Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath + "/image_sach");//Đường dẫn chứa file ảnh khi lưu.
                System.IO.Directory.SetCurrentDirectory(@"C:\Users\nguye\Documents\Visual Studio 2013\Projects\BaiTap6_ADO\BaiTap6_ADO\image_sach");//Đường dẫn chứa file ảnh khi lưu.
            }
            //MessageBox.Show("Link lưu ảnh là: " + System.Windows.Forms.Application.StartupPath);
        }
        //b. Khởi tạo hàm Save ảnh
        private void SaveImage()
        {
            saveFileDialog1.FileName = txtImage.Text;
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Gif);

                        break;
                }
                fs.Close();
            }
        }
    }
}

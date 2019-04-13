using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tạo ra textbox
            // định vị textbox: location
            // thiết lập size
            // gắn textbox lên form
            int y = 50;
            int n = int.Parse(textBox1.Text);
            for (int i = 1; i <= n; i++ )
            {
                TextBox tb = new TextBox();
                tb.Name = i.ToString();
                tb.Location = new Point(80, y);
                tb.Size = new Size(207, 20);
                this.Controls.Add(tb);
                y += 20;
            }
            
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


    }
}

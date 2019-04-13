using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap5_LinQ
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		        string server = txtServerName.Text;
                string database = txtDatabase.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                BO.DungChung.cs = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",server,database,username,password);
                BO.DungChung.db = new dbDataContext(BO.DungChung.cs);
                BO.DungChung.db.Connection.Open();
                MessageBox.Show("Kết nối thành công");
                frmShow f = new frmShow();
                f.Show();
                this.Hide();
	        }
	        catch (Exception tt)
	        {
		        MessageBox.Show(tt.Message);
	        }
          
        }

    }
}

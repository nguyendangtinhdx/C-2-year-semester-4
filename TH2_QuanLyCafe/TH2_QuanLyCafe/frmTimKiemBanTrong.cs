﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH2_QuanLyCafe
{
    public partial class frmTimKiemBanTrong : Form
    {
        public frmTimKiemBanTrong()
        {
            InitializeComponent();
        }

        private void frmTimKiemBanTrong_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CauHinh.db.BanTrongs;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH1_QuanLyNhanVien
{
    public partial class frmInNhanVien : Form
    {
        public frmInNhanVien()
        {
            InitializeComponent();
        }

        private void frmInNhanVien_Load(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("InNhanVien", db.NhanViens.ToList()));
            this.reportViewer1.RefreshReport();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace QuanLyCafe_ADO
{
    public partial class frmInThongKeTheoThang : Form
    {
        public frmInThongKeTheoThang()
        {
            InitializeComponent();
        }

        private void frmInThongKeTheoThang_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources.Clear();// xoa du lieu cu
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", frmThongKeTheoThang.ds));

            ReportParameter ts = new ReportParameter("Thang", frmThongKeTheoThang.thang);
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();
        }
    }
}

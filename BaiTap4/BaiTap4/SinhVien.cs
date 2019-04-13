using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap4
{
    public class SinhVien : Nguoi
    {
        private string masv;

        public string Masv
        {
            get { return masv; }
            set { masv = value; }
        }
        private string hoten;

        internal string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        private int tuoi;

        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }
        private double dtb;

        public double Dtb
        {
            get { return dtb; }
            set { dtb = value; }
        }

        public SinhVien(string masv, string hoten, int tuoi, double dtb):base(hoten,tuoi)
        {
            this.masv = masv;
            this.dtb = dtb;
        }
        // public new string getTen() // hiển thị nguoi
        public override string getTen()
        {
            return "ten sv: " + Hoten;
        }

    }
}

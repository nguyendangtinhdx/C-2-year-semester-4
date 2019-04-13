using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap4
{
    public class Nguoi
    {
        private string hoten;
        private int tuoi;

        public Nguoi(string hoten, int tuoi)
        {
            this.hoten = hoten;
            this.tuoi = tuoi;
        }
        public virtual string getTen()
        {
            return "ten nguoi: " + hoten;
        }

    }
}

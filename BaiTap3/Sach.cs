using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class Sach
    {
        private string masach;

        public string Masach
        {
          get { return masach; }
          set { masach = value; }
        }
        private string tensach;

        public string Tensach
        {
          get { return tensach; }
          set { tensach = value; }
        }
        private string tacgia;

        public string Tacgia
        {
            get { return tacgia; }
            set { tacgia = value; }
        }
        private long gia;

        public long Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public String GiamGia
        {
            get{
                if (gia >= 400)
                    return "10%";
                else
                    return "0%";
            }
            
        }

        public Sach(string masach, string tensach, string tacgia, long gia)
        {
            this.Masach = masach;
            this.Tensach = tensach;
            this.Tacgia = tacgia;
            this.Gia = gia;
        }

    }
}

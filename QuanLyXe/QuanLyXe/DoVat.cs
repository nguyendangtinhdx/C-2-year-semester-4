using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXe
{
    public class DoVat
    {
        private string ten;
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private DateTime ngaysanxuat;
        public DateTime Ngaysanxuat
        {
            get { return ngaysanxuat; }
            set { ngaysanxuat = value; }
        }

        public DoVat(string ten, DateTime ngaysanxuat)
        {
            this.Ten = ten;
            this.Ngaysanxuat = ngaysanxuat;
        }
    }

    public class Xe:DoVat
    {
        private string maxe;
        public string Maxe
        {
            get { return maxe; }
            set { maxe = value; }
        }

        private string loaixe;
        public string Loaixe
        {
            get { return loaixe; }
            set { loaixe = value; }
        }

        private long gia;

        public long Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public Xe(string maxe, string tenxe, string loaixe, DateTime ngaysanxuat , long gia):base(tenxe,ngaysanxuat)
        {
            this.Maxe = maxe;
            this.Loaixe = loaixe;
            this.Gia = gia;
        }
    }
}

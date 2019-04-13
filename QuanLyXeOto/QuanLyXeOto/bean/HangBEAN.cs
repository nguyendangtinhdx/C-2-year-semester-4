using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeOto.bean
{
    public class HangBEAN
    {
        private string maHang;

        public HangBEAN(string maHang, string tenHang)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
        }
        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }

        private string tenHang;

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.Model
{
    public class LoaiBean
    {
        private string maLoai;
        public LoaiBean(string maLoai, string tenLoai)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
        }
        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }
        private string tenLoai;

        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.Model
{
    public class DangNhapBean
    {
        private long tenDangNhap;

        public long TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        private string matKhau;
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
    }
}

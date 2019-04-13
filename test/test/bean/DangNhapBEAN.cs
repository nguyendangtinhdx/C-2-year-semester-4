using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.bean
{
    public class DangNhapBEAN
    {
        public DangNhapBEAN(string taiKhoan, string matKhau)
        {
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
        }
        private string taiKhoan;

        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }
        private string matKhau;

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
    }
}

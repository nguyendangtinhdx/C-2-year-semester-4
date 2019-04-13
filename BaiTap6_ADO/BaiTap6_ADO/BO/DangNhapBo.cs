using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.BO
{
    public class DangNhapBo
    {
        Model.DangNhapDao dangNhap = new Model.DangNhapDao();
        public bool DangNhap(long tenDangNhap, string matKhau)
        {
            return dangNhap.DangNhap(tenDangNhap, matKhau);
        }
    }
}

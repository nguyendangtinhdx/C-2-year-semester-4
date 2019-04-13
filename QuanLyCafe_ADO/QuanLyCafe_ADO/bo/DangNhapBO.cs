using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class DangNhapBO
    {
        DangNhapDAO dangNhap = new DangNhapDAO();
        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            return dangNhap.DangNhap(tenDangNhap,matKhau);
        }
    }
}

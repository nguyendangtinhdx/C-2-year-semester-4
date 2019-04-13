using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap5_LinQ.BO
{
    public class DangKyBO
    {
        dbDataContext db = new dbDataContext();
        Boolean ktDN(string tenDangNhap)
        {
            var q = from s in db.DangNhaps
                    where s.TenDangNhap.Equals(tenDangNhap)
                    select s;
            return q.Count() == 0 ? true : false;
        }
        public Boolean Them(string tenDangNhap, string matKhau, bool quyen)
        {
            
           
            if (ktDN(tenDangNhap) == false) return false;
            DangNhap dn = new DangNhap();
            dn.TenDangNhap = tenDangNhap;
            dn.MatKhau = matKhau;
            dn.Quyen = quyen;

            //if (ktDN(tenDangNhap) == false) return false;
            //DangNhap dn = new DangNhap();
            //dn.TenDangNhap = tenDangNhap;
            //dn.MatKhau = matKhau;
            //if (frmDangKy.quyen == true)
            //{
            //    dn.Quyen = true;
            //}
            //else
            //{
            //    dn.Quyen = false;
            //}

            db.DangNhaps.InsertOnSubmit(dn);
            db.SubmitChanges();
            return true;
        }
    }
}

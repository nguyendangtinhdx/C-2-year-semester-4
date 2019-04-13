using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap5_LinQ.BO
{
    public class DangNhapBO
    {
        dbDataContext db = new dbDataContext();
        public List<DangNhap> getList()
        {
            return db.DangNhaps.ToList();
        }
        public Boolean DangNhap(string tenDangNhap, string matKhau)
        {
            var q = from d in db.DangNhaps
                    where d.TenDangNhap.Equals(tenDangNhap) && d.MatKhau.Equals(matKhau)
                    select d;
            return q.Count() == 0 ? false : true;
        }
        public void Xoa(string tenDanhNhap)
        {
            var q = from s in db.DangNhaps
                    where s.TenDangNhap.Equals(tenDanhNhap)
                    select s;
            if (q.Count() != 0)
            {
                db.DangNhaps.DeleteOnSubmit(q.First());
                db.SubmitChanges();
            }
        }
    }
}

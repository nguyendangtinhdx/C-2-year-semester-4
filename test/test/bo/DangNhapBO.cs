using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.bean;
using test.dao;
namespace test.bo
{
    public class DangNhapBO
    {
        DangNhapDAO dangNhap = new DangNhapDAO();
        public bool DangNhap(string taiKhoan, string matKhau)
        {
            return dangNhap.DangNhap(taiKhoan, matKhau);
        }
        public List<DangNhapBEAN> getListDangNhap()
        {
            return dangNhap.getListDangNhap();
        }
        public List<DangNhapBEAN> themDangNhap(List<DangNhapBEAN> ds, string taiKhoan, string matKhau, out Boolean kq)
        {
            kq = false;
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.TaiKhoan.Equals(taiKhoan)
                    select l;
            if (q.Count() == 0)
            {
                // thêm csdl
                dangNhap.themDangNhap(taiKhoan, matKhau);
                // thêm bộ nhớ
                DangNhapBEAN b = new DangNhapBEAN(taiKhoan, matKhau);
                ds.Add(b);
                kq = true;
            }
            return ds;
        }
        public List<DangNhapBEAN> suaDangNhap(List<DangNhapBEAN> ds, string taiKhoan, string matKhau)
        {
            var q = from l in ds
                    where l.TaiKhoan.Equals(taiKhoan)
                    select l;
            if (q.Count() != 0)
            {
                q.First().TaiKhoan = taiKhoan;
                q.First().MatKhau = matKhau;
                dangNhap.suaDangNhap(taiKhoan, matKhau);
                return ds;
            }
            return null;
        }
        public List<DangNhapBEAN> xoaDangNhap(List<DangNhapBEAN> ds, string taiKhoan)
        {
            var q = from l in ds
                    where l.TaiKhoan.Equals(taiKhoan)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                dangNhap.xoaDangNhap(taiKhoan); // xóa csdl
            }
            return ds;
        }
        public List<DangNhapBEAN> timDangNhap(List<DangNhapBEAN> ds, string key)
        {
            //var q = from l in ds
            //        where l.TenBan.ToLower().Contains(key.ToLower())
            //        select l;
            //return q.ToList();

            return dangNhap.timDangNhap(key); // tìm trong csdl
        }

    }
}

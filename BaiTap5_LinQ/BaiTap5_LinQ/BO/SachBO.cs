using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap5_LinQ.BO
{
    public class SachBO
    {
        public List<sach> ds = new List<sach>();

        dbDataContext db = new dbDataContext();
        public List<sach> getSach()
        {
            return db.saches.ToList();
        }
        public List<sach> getSach(string maLoai)
        {
            return db.saches.Where(s => s.maloai.Equals(maLoai)).ToList();
        }

        public List<sach> getSum(string maLoai, out int sumSL, out int count, out long max, out long min, out long avg, out long tongTien)
        {
           var q = db.saches.Where(s => s.maloai.Equals(maLoai));
               sumSL = (int)q.Sum(s => s.soluong);
               count = (int)q.Count();
               max = (long)q.Max(s => s.gia);
               min = (long)q.Min(s => s.gia);
               avg = (long)q.Average(s => s.gia);
               tongTien = (long)q.Sum(s => s.gia * s.soluong);
               return q.ToList();
               
        }
        public List<sach> TimTenSachVaTacGia(string maLoai, string key)
        {
            var q = db.saches.Where(s => s.maloai.Equals(maLoai) &&
                (s.tensach.Contains(key) || s.tacgia.Contains(key)));

            //var q = from s in db.saches
            //        //join l in db.loais
            //        //on s.maloai equals l.maloai
            //        where s.maloai == maLoai && (s.tensach.Contains(key) || s.tacgia.Contains(key))
            //        select s;

            return q.ToList();
        }
        Boolean ktMa(string masach)
        {
            var q = from s in db.saches
                    where s.masach.Equals(masach)
                    select s;
            return q.Count() == 0 ? true : false;
        }
        public Boolean Them(string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, DateTime ngayNhap ,string maLoai)
        {
            if (ktMa(maSach) == false) return false;
            sach s = new sach();
            s.masach = maSach;
            s.tensach = tenSach;
            s.tacgia = tacGia;
            s.soluong = soLuong;
            s.gia = gia;
            s.sotap = soTap;
            s.NgayNhap = ngayNhap;
            s.maloai = maLoai;
            db.saches.InsertOnSubmit(s);
            db.SubmitChanges();
            return true;
        }
        public void Sua(string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, DateTime ngayNhap, string maLoai)
        {
            // tìm sách cần sửa
            var q = from s in db.saches
                    where s.masach.Equals(maSach)
                    select s;
            if(q.Count() != 0) // nếu tìm thấy
            {
                q.First().tensach = tenSach;
                q.First().tacgia = tacGia;
                q.First().soluong = soLuong;
                q.First().gia = gia;
                q.First().sotap = soTap;
                q.First().NgayNhap = ngayNhap;
                q.First().maloai = maLoai;
                db.SubmitChanges();
            }
        }
        public void Xoa(string maSach)
        {
            var q = from s in db.saches
                     where s.masach.Equals(maSach)
                     select s;
            if (q.Count() != 0)
            {
                db.saches.DeleteOnSubmit(q.First());
                db.SubmitChanges();
            }
        }
        public void NangGia(string maLoai, long giaTang)
        {
            // lấy về tất cả các sách có maloai = maLoai
            var q = from s in db.saches
                    where s.maloai.Equals(maLoai)
                    select s;
            foreach(sach s in q) // duyệt qua các sách trong q
                s.gia = s.gia + giaTang; // sửa lại giá
            db.SubmitChanges();
        }
    }
}

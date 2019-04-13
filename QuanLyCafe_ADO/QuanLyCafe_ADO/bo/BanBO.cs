using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class BanBO
    {
        BanDAO ban = new BanDAO();
        public List<BanBEAN> getListBan()
        {
            return ban.getListBan();
        }
        public List<BanBEAN> themBan(List<BanBEAN> ds, string maBan, string tenBan,long soGhe , out Boolean kq)
        {
            kq = false;
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.MaBan.Equals(maBan)
                    select l;
            if (q.Count() == 0)
            {
                // thêm csdl
                ban.themBan(maBan, tenBan,soGhe);
                // thêm bộ nhớ
                BanBEAN b = new BanBEAN(maBan, tenBan,soGhe);
                ds.Add(b);
                kq = true;
            }
            return ds;
        }
        public List<BanBEAN> suaBan(List<BanBEAN> ds, string maBan, string tenBan,long soGhe)
        {
            var q = from l in ds
                    where l.MaBan.Equals(maBan)
                    select l;
            if (q.Count() != 0)
            {
                q.First().TenBan = tenBan;
                q.First().SoGhe = soGhe;
                ban.suaBan(maBan, tenBan,soGhe);
                return ds;
            }
            return null;
        }
        public List<BanBEAN> xoaBan(List<BanBEAN> ds, string maBan)
        {
            var q = from l in ds
                    where l.MaBan.Equals(maBan)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                ban.xoaBan(maBan); // xóa csdl
            }
            return ds;
        }
        public List<BanBEAN> timBan(List<BanBEAN> ds, string key)
        {
            //var q = from l in ds
            //        where l.TenBan.ToLower().Contains(key.ToLower())
            //        select l;
            //return q.ToList();

            return ban.timBan(key); // tìm trong csdl
        }
        public string getTenBan(string maBan)
        {
            return ban.getTenBan(maBan); // tìm trong csdl
        }
    }
}

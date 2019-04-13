using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO.BO
{
    public class LoaiBo
    {
        LoaiDao loai = new LoaiDao();
        public List<LoaiBean> getLoai()
        {
            return loai.getLoai();
        }
        public static bool check;
        public List<LoaiBean> themLoai(List<LoaiBean> ds,string maLoai, string tenLoai, out Boolean kq)
        {
            kq = false;
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.MaLoai.Equals(maLoai)
                    select l;
            if (q.Count() == 0)
            {
                // thêm csdl
                loai.themLoai(maLoai,tenLoai);
                // thêm bộ nhớ
                LoaiBean lb = new LoaiBean(maLoai, tenLoai);
                ds.Add(lb);
                //check = true;
                kq = true;
            }
            //else
            //{
            //    check = false;
            //}
            return ds;
        }
        public List<LoaiBean> suaLoai(List<LoaiBean> ds, string maLoai, string tenLoai)
        {
            var q = from l in ds
                    where l.MaLoai.Equals(maLoai)
                    select l;
            if (q.Count() != 0)
            {
                q.First().TenLoai = tenLoai;
                loai.suaLoai(maLoai, tenLoai);
                return ds;
            }
            return null;
        }
        public List<LoaiBean> xoaLoai(List<LoaiBean> ds, string maLoai)
        {
            var q = from l in ds
                where l.MaLoai.Equals(maLoai)
                select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                loai.xoaLoai(maLoai); // xóa csdl
            }
            return ds;
        }
        public List<LoaiBean> timLoai(List<LoaiBean> ds, string key)
        {
            var q = from l in ds
                    where l.TenLoai.ToLower().Contains(key.ToLower())
                select l;
            //if (q.Count() != 0)
            //{
            //    ds = loai.timLoai(key);
            //}
            return q.ToList();
        }
    }
}

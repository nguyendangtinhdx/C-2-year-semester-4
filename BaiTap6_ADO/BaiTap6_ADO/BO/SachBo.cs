using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO.BO
{
    public class SachBo
    {
        Model.SachDao sach = new Model.SachDao();
        public List<SachBean> getSach()
        {
            return sach.getSach();
        }
        public List<SachBean> getSachByLoai(string ma)
        {
            return sach.getSachByLoai(ma);
        }
        public List<SachBean> getSachByMaSach(string ma)
        {
            return sach.getSachByMaSach(ma);
        }
        public int themSach(string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, string anh, string maLoai, DateTime ngayNhap)
        {
            return sach.themSach(maSach, tenSach, tacGia, soLuong, gia, soTap, anh, maLoai, ngayNhap);
        }
        public List<SachBean> themSach(List<SachBean> ds, string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, string anh, string maLoai, DateTime ngayNhap, out Boolean kq)
        {
            kq = false;
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.MaSach.Equals(maSach)
                    select l;
            if (q.Count() == 0)
            {
                // thêm csdl
                sach.themSach(maSach, tenSach,tacGia,soLuong,gia,soTap,anh,maLoai,ngayNhap);
                // thêm bộ nhớ
                SachBean sb = new SachBean(maSach, tenSach, tacGia, soLuong, gia, soTap, anh, maLoai, ngayNhap);
                ds.Add(sb);
                kq = true;
            }
            return ds;
        }
        public List<SachBean> suaSach(List<SachBean> ds, string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, string anh, string maLoai, DateTime ngayNhap)
        {
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.MaSach.Equals(maSach)
                    select l;
            if (q.Count() != 0)
            {
                q.First().TenSach = tenSach;
                q.First().TacGia = tacGia;
                q.First().SoLuong = soLuong;
                q.First().Gia = gia;
                q.First().SoTap = soTap;
                q.First().Anh = anh;
                q.First().MaLoai = maLoai;
                q.First().NgayNhap = ngayNhap;
                sach.suaSach(maSach, tenSach, tacGia, soLuong, gia, soTap, anh, maLoai, ngayNhap);
                return ds;
            }
            return null;
        }
        public List<SachBean> suaSoLuong(List<SachBean> ds, string maSach,long soLuong)
        {
            sach.suaSoLuong(maSach, soLuong);
            return ds;
        }
        public List<SachBean> xoaSach(List<SachBean> ds, string maSach)
        {
            var q = from l in ds
                    where l.MaSach.Equals(maSach)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                sach.xoaSach(maSach); // xóa csdl
            }
            return ds;
        }
        public List<SachBean> timSach(List<SachBean> ds, string key)
        {
            var q = from l in ds
                    where l.TenSach.ToLower().Contains(key.ToLower()) || l.TacGia.ToLower().Contains(key.ToLower())
                    select l;
            return q.ToList();
        }
    }
}

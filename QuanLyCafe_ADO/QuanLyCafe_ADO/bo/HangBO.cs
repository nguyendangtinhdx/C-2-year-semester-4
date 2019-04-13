using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class HangBO
    {
        HangDAO hang = new HangDAO();
        public List<HangBEAN> getListHang()
        {
            return hang.getListHang();
        }
        public List<HangBEAN> getListHangByMaHang(string ma)
        {
            return hang.getListHangByMaHang(ma);
        }
        public List<HangBEAN> themHang(List<HangBEAN> ds, string maHang, string tenHang, long gia, long soLuong, string donViTinh, out Boolean kq)
        {
            kq = false;
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.MaHang.Equals(maHang)
                    select l;
            if (q.Count() == 0)
            {
                // thêm csdl
                hang.themHang(maHang, tenHang, gia, soLuong, donViTinh);
                // thêm bộ nhớ
                HangBEAN h = new HangBEAN(maHang, tenHang, gia, soLuong, donViTinh);
                ds.Add(h);
                kq = true;
            }
            return ds;
        }
        public List<HangBEAN> suaHang(List<HangBEAN> ds, string maHang, string tenHang, long gia, long soLuong, string donViTinh)
        {
            var q = from l in ds
                    where l.MaHang.Equals(maHang)
                    select l;
            if (q.Count() != 0)
            {
                q.First().TenHang = tenHang;
                q.First().Gia = gia;
                q.First().SoLuong = soLuong;
                q.First().DonViTinh = donViTinh;
                hang.suaHang(maHang, tenHang, gia, soLuong, donViTinh);
                return ds;
            }
            return null;
        }
        public List<HangBEAN> xoaHang(List<HangBEAN> ds, string maHang)
        {
            var q = from l in ds
                    where l.MaHang.Equals(maHang)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                hang.xoaHang(maHang); // xóa csdl
            }
            return ds;
        }
        public List<HangBEAN> timHang(List<HangBEAN> ds, string key)
        {
            //var q = from l in ds
            //        where l.TenBan.ToLower().Contains(key.ToLower())
            //        select l;
            //return q.ToList();

            return hang.timHang(key); // tìm trong csdl
        }
        public List<HangBEAN> suaSoLuong(List<HangBEAN> ds, string maHang, long soLuong)
        {
            hang.suaSoLuong(maHang, soLuong);
            return ds;
        }
    }
}

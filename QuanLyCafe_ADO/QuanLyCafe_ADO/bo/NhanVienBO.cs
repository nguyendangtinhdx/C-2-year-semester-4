using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class NhanVienBO
    {
        NhanVienDAO nhanVien = new NhanVienDAO();
        public List<NhanVienBEAN> getListNhanVien()
        {
            return nhanVien.getListNhanVien();
        }
        public List<NhanVienBEAN> themNhanVien(List<NhanVienBEAN> ds, string maNhanVien, string hoTen, string diaChi,string matKhau, string quyen, out Boolean kq)
        {
            kq = false;
            // lấy về tất cả các loại có mã  là maLoai
            var q = from l in ds
                    where l.MaNhanVien.Equals(maNhanVien)
                    select l;
            if (q.Count() == 0)
            {
                // thêm csdl
                nhanVien.themNhanVien(maNhanVien, hoTen, diaChi, matKhau, quyen);
                // thêm bộ nhớ
                NhanVienBEAN nv = new NhanVienBEAN(maNhanVien, hoTen, diaChi, matKhau, quyen);
                ds.Add(nv);
                kq = true;
            }
            return ds;
        }
        public List<NhanVienBEAN> suaNhanVien(List<NhanVienBEAN> ds, string maNhanVien, string hoTen, string diaChi, string matKhau, string quyen)
        {
            var q = from l in ds
                    where l.MaNhanVien.Equals(maNhanVien)
                    select l;
            if (q.Count() != 0)
            {
                q.First().HoTen = hoTen;
                q.First().DiaChi = diaChi;
                q.First().MatKhau = matKhau;
                q.First().Quyen = quyen;
                nhanVien.suaNhanVien(maNhanVien, hoTen, diaChi, matKhau, quyen);
                return ds;
            }
            return null;
        }
        public List<NhanVienBEAN> xoaNhanVien(List<NhanVienBEAN> ds, string maNhanVien)
        {
            var q = from l in ds
                    where l.MaNhanVien.Equals(maNhanVien)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                nhanVien.xoaNhanVien(maNhanVien); // xóa csdl
            }
            return ds;
        }
        public List<NhanVienBEAN> timNhanVien(List<NhanVienBEAN> ds, string key)
        {
            //var q = from l in ds
            //        where l.TenBan.ToLower().Contains(key.ToLower())
            //        select l;
            //return q.ToList();

            return nhanVien.timNhanVien(key); // tìm trong csdl
        }
        public bool checkNhanVien(string maNhanVien)
        {
            return nhanVien.checkNhanVien(maNhanVien);
        }
    }
}

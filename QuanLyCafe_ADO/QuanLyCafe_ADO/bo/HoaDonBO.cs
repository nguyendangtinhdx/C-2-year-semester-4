using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class HoaDonBO
    {
        HoaDonDAO hoaDon = new HoaDonDAO();
        public List<HoaDonBEAN> getListHoaDon()
        {
            return hoaDon.getListHoaDon();
        }
        public List<HoaDonBEAN> xoaHoaDon(List<HoaDonBEAN> ds, long maHoaDon)
        {
            var q = from l in ds
                    where l.MaHoaDon.Equals(maHoaDon)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                hoaDon.xoaHoaDon(maHoaDon); // xóa csdl
            }
            return ds;
        }
        public List<HoaDonBEAN> themHoaDon(List<HoaDonBEAN> ds, string maNhanVien, string maBan)
        {
            // thêm csdl
            hoaDon.themHoaDon(maNhanVien, maBan);
            // thêm bộ nhớ
            //HoaDonBean hd = new HoaDonBean("",maKhachHang,ngayMua, 0);
            //ds.Add(hd);
            return ds;
        }
        public List<HoaDonBEAN> thanhToanHoaDon(List<HoaDonBEAN> ds,string maBan)
        {
            hoaDon.thanhToanHoaDon(maBan);
            return ds;
        }
        //public long getHonDonMax()
        //{
        //    return hoaDon.getHonDonMax();
        //}
        public void xoaHoaDonByMaBan(string maBan)
        {
            //var q = from l in ds
            //        where l.MaBan.Equals(maBan)
            //        select l;
            //if (q.Count() != 0)
            //{
            //    ds.Remove(q.First()); // xóa bộ nhớ
                hoaDon.xoaHoaDonByMaBan(maBan); // xóa csdl
            //}
            //return ds;
        }
        public long getMaHoaDonByMaBan(string ma)
        {
            return hoaDon.getMaHoaDonByMaBan(ma);
        }
        public string getMaBanByMaBan(string ma)
        {
            return hoaDon.getMaBanByMaBan(ma);
        }
        public List<HoaDonBEAN> chuyenBan(List<HoaDonBEAN> ds, string maBanCu, string maBanMoi)
        {
            hoaDon.chuyenBan(maBanCu,maBanMoi);
            return ds;
        }
    }
}

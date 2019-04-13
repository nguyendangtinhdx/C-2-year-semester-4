using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using QuanLyXeOto.dao;
namespace QuanLyXeOto.bo
{
    public class HoaDoBO
    {
        HoaDonDAO hoaDon = new HoaDonDAO();
        public List<HoaDonDEAN> getListHoaDon()
        {
            return hoaDon.getListHoaDon();
        }
        public List<HoaDonDEAN> themHoaDon(List<HoaDonDEAN> ds, string maXe, long soLuongMua, long thanhTien)
        {
            // thêm csdl
            hoaDon.themHoaDon(maXe, soLuongMua,thanhTien);
            // thêm bộ nhớ
            //HoaDonBean hd = new HoaDonBean("",maKhachHang,ngayMua, 0);
            //ds.Add(hd);
            return ds;
        }
        public long getTongTien()
        {
            return hoaDon.getTongTien();
        }
        public int thanhToanHoaDon()
        {
            return hoaDon.thanhToanHoaDon();
        }
        public string getMaXeByMaXe(string ma)
        {
            return hoaDon.getMaXeByMaXe(ma);
        }

        public int suaSoLuongHoaDonByTrungMaXe(string maXe, long soLuongMua)
        {
            return hoaDon.suaSoLuongHoaDonByTrungMaXe(maXe, soLuongMua);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class ChiTietHoaDonBO
    {
        ChiTietHoaDonDAO chiTietHoaDon = new ChiTietHoaDonDAO();
        public List<ChiTietHoaDonBEAN> getListChiTietHoaDon()
        {
            return chiTietHoaDon.getListChiTietHoaDon();
        }
        public List<ChiTietHoaDonBEAN> xoaChiTietHoaDon(List<ChiTietHoaDonBEAN> ds, long maChiTietHoaDon)
        {
            var q = from l in ds
                    where l.MaChiTietHoaDon.Equals(maChiTietHoaDon)
                    select l;
            if (q.Count() != 0)
            {
                ds.Remove(q.First()); // xóa bộ nhớ
                chiTietHoaDon.xoaChiTietHoaDon(maChiTietHoaDon); // xóa csdl
            }
            return ds;
        }
        public List<ChiTietHoaDonBEAN> themChiTietHoaDon(List<ChiTietHoaDonBEAN> ds, string maHang, long soLuongMua, long thanhTien)
        {
            // thêm csdl
            chiTietHoaDon.themChiTietHoaDon(maHang, soLuongMua, thanhTien);
            // thêm bộ nhớ
            //HoaDonBean hd = new HoaDonBean("",maKhachHang,ngayMua, 0);
            //ds.Add(hd);
            return ds;
        }
        public List<ChiTietHoaDonBEAN> themChiTietHoaDonKhiTonTaiMaHoaDon(List<ChiTietHoaDonBEAN> ds, string maHang, long soLuongMua, long thanhTien, long maHoaDon)
        {
            // thêm csdl
            chiTietHoaDon.themChiTietHoaDonKhiTonTaiMaHoaDon(maHang, soLuongMua, thanhTien,maHoaDon);
            return ds;
        }
        public string getMaHangByMaHang(string ma, long maHoaDon)
        {
            return chiTietHoaDon.getMaHangByMaHang(ma,maHoaDon);
        }
        public List<ChiTietHoaDonBEAN> suaSoLuongChiTietHoaDonByTrungMaHang(List<ChiTietHoaDonBEAN> ds, string maHang, long soLuongMua, long maHoaDon)
        {
            chiTietHoaDon.suaSoLuongChiTietHoaDonByTrungMaHang(maHang,soLuongMua,maHoaDon);
            return ds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO.BO
{
    public class HoaDonBo
    {
        HoaDonDao hoadon = new HoaDonDao();
        public List<HoaDonBean> themHoaDon(List<HoaDonBean> ds, long maKhachHang, DateTime ngayMua)
        {

            // thêm csdl
            hoadon.themHoaDon(maKhachHang, ngayMua);
            // thêm bộ nhớ
            //HoaDonBean hd = new HoaDonBean("",maKhachHang,ngayMua, 0);
            //ds.Add(hd);
            return ds;
        }
        public List<HoaDonBean> thanhToanHoaDon(List<HoaDonBean> ds)
        {
            hoadon.thanhToanHoaDon();
            return ds;
        }
        public long getHonDonMax()
        {
            return hoadon.getHonDonMax();
        }
    }
}

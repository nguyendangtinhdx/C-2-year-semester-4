using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO.BO
{
    public class ChiTietHoaDonBo
    {
        ChiTietHoaDonDao cthd = new ChiTietHoaDonDao();
        public List<ChiTietHoaDonBean> themChiTietHoaDon(List<ChiTietHoaDonBean> ds, string maSach, long soLuongMua, long gia)
        {

            // thêm csdl
            cthd.themChiTietHoaDon(maSach, soLuongMua,gia);
            // thêm bộ nhớ
            //HoaDonBean hd = new HoaDonBean("",maKhachHang,ngayMua, 0);
            //ds.Add(hd);
            return ds;
        }
    }
}

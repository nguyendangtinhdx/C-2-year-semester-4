using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class HoaDonBanHangBO
    {
        HoaDonBanHangDAO honDonBanHang = new HoaDonBanHangDAO();
        public List<HoaDonBanHangBEAN> getListHoaDonBanHang(string ma)
        {
            return honDonBanHang.getListHoaDonBanHang(ma);
        }
        public long getTongTien(string ma)
        {
            return honDonBanHang.getTongTien(ma);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO.BO
{
    public class HoaDonBanSachBo
    {
        HoaDonBanSachDao hoadon = new HoaDonBanSachDao();
        public List<HoaDonBanSachBean> getHoaDonBanSach()
        {
            return hoadon.getHoaDonBanSach();
        }
        public long getTongTien()
        {
            return hoadon.getTongTien();
        }
    }
}

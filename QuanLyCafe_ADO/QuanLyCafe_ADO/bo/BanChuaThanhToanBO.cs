using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class BanChuaThanhToanBO
    {
        BanChuaThanhToanDAO ban = new BanChuaThanhToanDAO();
        public List<BanChuaThanhToanBEAN> getListBanChuaThanhToan()
        {
            return ban.getListBanChuaThanhToan();
        }
    }
}

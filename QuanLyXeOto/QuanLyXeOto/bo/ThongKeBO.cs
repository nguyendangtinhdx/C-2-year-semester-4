using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using QuanLyXeOto.dao;
namespace QuanLyXeOto.bo
{
    public class ThongKeBO
    {
        ThongKeDAO tk = new ThongKeDAO();
        public List<ThongKeBEAN> getListThongKe(string ma)
        {
            return tk.getListThongKe(ma);
        }
    }
}

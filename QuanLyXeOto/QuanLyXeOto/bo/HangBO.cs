using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using QuanLyXeOto.dao;
namespace QuanLyXeOto.bo
{
    public class HangBO
    {
        HangDAO hang = new HangDAO();
        public List<HangBEAN> getListHang()
        {
            return hang.getListHang();
        }
    }
}

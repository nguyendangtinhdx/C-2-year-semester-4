using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using QuanLyXeOto.dao;
namespace QuanLyXeOto.bo
{
    public class OtoBO
    {
        OtoDAO oto = new OtoDAO();
        public List<OtoBEAN> getListOto()
        {
            return oto.getListOto();
        }
        public List<OtoBEAN> getListOtoByMa(string ma)
        {
            return oto.getListOtoByMa(ma);
        }
        public List<OtoBEAN> getListOtoByMaHang(string ma)
        {
            return oto.getListOtoByMaHang(ma);
        }
        public List<OtoBEAN> suaSoLuong(List<OtoBEAN> ds, string maXe, long soLuong)
        {
            oto.suaSoLuong(maXe, soLuong);
            return ds;
        }
    }
}

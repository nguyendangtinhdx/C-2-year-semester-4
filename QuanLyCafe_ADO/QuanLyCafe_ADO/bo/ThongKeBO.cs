using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO.bo
{
    public class ThongKeBO
    {
        ThongKeDAO thongKe = new ThongKeDAO();
        public List<ThongKeBEAN> getListThongKeTheoNgay(long ngay, long thang, long nam)
        {
            return thongKe.getListThongKeTheoNgay(ngay,thang,nam);
        }
        public long getTongTienTheoNgay(long ngay, long thang, long nam)
        {
            return thongKe.getTongTienTheoNgay(ngay, thang, nam);
        }
        public List<ThongKeBEAN> getListThongKeTheoThang(long thang, long nam)
        {
            return thongKe.getListThongKeTheoThang(thang,nam);
        }
        public long getTongTienTheoThang(long thang,long nam)
        {
            return thongKe.getTongTienTheoThang(thang, nam);
        }
        public List<ThongKeBEAN> getListThongKeTheoNam(long nam)
        {
            return thongKe.getListThongKeTheoNam(nam);
        }
        public long getTongTienTheoNam(long nam)
        {
            return thongKe.getTongTienTheoNam(nam);
        }
    }
}

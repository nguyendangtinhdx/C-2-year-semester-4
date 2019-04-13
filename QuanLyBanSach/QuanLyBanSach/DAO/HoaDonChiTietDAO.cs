using QuanLyBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DAO
{
    public class HoaDonChiTietDAO
    {
        private static HoaDonChiTietDAO instance;

        public static HoaDonChiTietDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonChiTietDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public HoaDonChiTietDAO() { }

        public List<HoaDonChiTietDTO> GetListHoaDonChiTiet(int mahoadon)
        {
            List<HoaDonChiTietDTO> list = new List<HoaDonChiTietDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = " + mahoadon);
            foreach (DataRow item in data.Rows)
            {
                HoaDonChiTietDTO hoadon = new HoaDonChiTietDTO(item);
                list.Add(hoadon);
            }
            return list;
        }
        public void InsertHoaDonChiTiet(int masach, int mahoadon, int soluong)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertChiTietHD @masach , @mahoadon , @soluong ", new object[]{masach, mahoadon, soluong});
        }
    }
}

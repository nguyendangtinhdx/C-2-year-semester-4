using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private HoaDonDAO() { }

        public void InsertHoaDon(int manhanvien)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertHoaDon @manhanvien",new object[] {manhanvien});
        }
        public int getBillMax()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT MAX(Mahoadon) FROM dbo.hoadon"));
            }
            catch
            {
                return 1;
            }
        }
        public void ThanhToan(int mahoadon, int tongtien)
        {
            string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "UPDATE dbo.hoadon SET damua = 1, tongtien = " + tongtien +", NgayBan = '" + a + "' WHERE MaHoaDon = " + mahoadon;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public bool HuyHoaDon(int mahoadon)
        {
            string query = string.Format("DELETE dbo.hoadon WHERE MaHoaDon = {0}", mahoadon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestBill()
        {
            string query1 = "SELECT COUNT(*) FROM dbo.hoadon WHERE damua = 0";
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query1));
            return result;
        }
    }
}

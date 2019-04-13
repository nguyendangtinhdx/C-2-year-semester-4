using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO // 9
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = "+ id +" AND status = 0");
            if (data.Rows.Count > 0) // số trường trả về > 0
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID; // đã lấy được ID của Bill
            }
            return -1; // không có thằng nào hết
        }

        public void CheckOut(int id,int discount, float totalPrice) // 12
        {
            string query = "UPDATE dbo.Bill SET DateCheckOut = GETDATE(), status = 1," + " discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id) // 11
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @idTable", new object[] { id });
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut) // 14
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @checkIn , @checkOut", new object[] {checkIn, checkOut });
        }

        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut,int pageNum) // phân trang  // 24
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum });

        }

        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut) // lấy tổng số trang  // 24
        {
            return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public int GetMaxIDBill() // 11
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch (Exception)
            {
                return 1; // nghĩa là chưa có ID nào
            }
            
        }
    }
}

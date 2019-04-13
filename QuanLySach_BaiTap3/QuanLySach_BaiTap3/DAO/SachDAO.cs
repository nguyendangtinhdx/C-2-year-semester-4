using QuanLySach_BaiTap3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach_BaiTap3.DAO
{
    public class SachDAO
    {
        private static SachDAO instance;  // singlton
        public static SachDAO Instance
        {
            get {
                if (instance == null)
                    instance = new SachDAO();
                return SachDAO.instance;
            }
            private set { SachDAO.instance = value; }
        }
        private SachDAO() { }

        public List<Sach> GetListSach()
        {
            List<Sach> listSach = new List<Sach>();
            string query = "SELECT * FROM dbo.Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Sach sach = new Sach(item);
                listSach.Add(sach);
            }
            return listSach;
        }

        public bool InsertSach(string maSach, string tenSach,string tacGia, int soLuong, float gia)
        {
            string query = string.Format("INSERT dbo.Sach( MaSach ,TenSach ,TacGia , SoLuong , Gia) VALUES  ( N'{0}' , N'{1}' , N'{2}' , {3} ,  {4})",maSach,tenSach,tacGia,soLuong,gia);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Sach> CheckMaSach(string maSach)
        {
            List<Sach> listSach = new List<Sach>();
            string query = "SELECT MaSach FROM dbo.Sach WHERE maSach = N'" + maSach + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Sach sach = new Sach(item);
                listSach.Add(sach);
            }
            return listSach;
        }

        public bool UpdateSach(string maSach, string tenSach,string tacGia, int soLuong, float gia)
        {
            string query = string.Format("UPDATE dbo.Sach SET TenSach = N'{0}', TacGia = N'{1}',SoLuong = {2}, Gia = {3} WHERE MaSach = N'{4}'",tenSach,tacGia,soLuong,gia,maSach);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            
            return result > 0;

        }
        public bool DeleteSach(string maSach)
        {
            string query = "DELETE dbo.Sach WHERE maSach = N'" + maSach + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Sach> SearchSach(string tenSach)
        {
            List<Sach> listSach = new List<Sach>();
            //string query = string.Format("SELECT * FROM dbo.Sach WHERE dbo.fChuyenCoDauThanhKhongDau(TenSach) LIKE N'%' + dbo.fChuyenCoDauThanhKhongDau(N'{0}') + '%' ", tenSach);
            string query = "SELECT * FROM dbo.Sach WHERE TenSach LIKE N'%" + tenSach + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Sach sach = new Sach(item);
                listSach.Add(sach);
            }
            return listSach;
        }

    }
}

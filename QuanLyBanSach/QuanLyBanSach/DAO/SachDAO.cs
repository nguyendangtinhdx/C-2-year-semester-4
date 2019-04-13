using QuanLyBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DAO
{
    public class SachDAO
    {
        private static SachDAO instance;

        public static SachDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SachDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private SachDAO() { }

        public List<SachDTO> GetListSach()
        {
            List<SachDTO> list = new List<SachDTO>();
            string query = "SELECT MaSach AS [Mã Sách],tensach AS [Tên Sách], loai.tenloai as [Loại Sách], tacgia AS [Tác Giả], soluong AS [Số Lượng], gia AS [Giá], sotap AS [Số Tập] FROM sach INNER JOIN loai ON sach.maloai = loai.maloai";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SachDTO sachDTO = new SachDTO(item);
                list.Add(sachDTO);
            }
            return list;
        }
        public List<SachDTO> SearchSach(int maSach, string tenSach, string loaiSach, string tacGia, int giamin, int giamax)
        {
            List<SachDTO> list = new List<SachDTO>();
            string query = string.Format("SELECT MaSach AS [Mã Sách], tensach AS [Tên Sách], loai.tenloai as [Loại Sách], tacgia AS [Tác Giả], soluong AS [Số Lượng], gia AS [Giá], sotap AS [Số Tập] FROM sach INNER JOIN loai ON sach.maloai = loai.maloai WHERE MaSach = '{0}' AND tensach like N'%{1}%' AND maloai = '{2}' AND TacGia like N'%{3}%' AND ({4} <= gia) AND (gia <= {5})", maSach,tenSach,loaiSach,tacGia,giamin,giamax);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SachDTO sachDTO = new SachDTO(item);
                list.Add(sachDTO);
            }
            return list;
        }
        public bool ThemSach(string tensach, int loaisach, string tacgia, int gia, int soluong, int sotap)
        {
            string query = string.Format("INSERT dbo.sach (tensach, tacgia, soluong, gia, sotap, maloai) VALUES(N'{0}', N'{1}', {2}, {3}, {4}, {5})",tensach,tacgia,soluong,gia,sotap,loaisach);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool SuaSach(int masach, string tensach, int loaisach, string tacgia, int gia, int soluong, int sotap)
        {
            string query = string.Format("UPDATE dbo.sach SET tensach = N'{0}', tacgia = N'{1}', soluong = {2}, gia = {3}, sotap = {4}, maloai = {5} WHERE MaSach = {6}", tensach, tacgia, soluong, gia, sotap, loaisach, masach);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool XoaSach(int masach)
        {
            string query = string.Format("DELETE dbo.sach WHERE MaSach = {0}", masach);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

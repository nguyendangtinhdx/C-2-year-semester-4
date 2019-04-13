using QuanLyBenXePhiaNamHue.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class TuyenXeDAO
    {
        private static TuyenXeDAO instance;

        public static TuyenXeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TuyenXeDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private TuyenXeDAO() { }

        public List<TuyenXeDTO> listTuyenXeChuaChay(string tentuyenxe)
        {
            List<TuyenXeDTO> listxe = new List<TuyenXeDTO>();
            string query = "SELECT * FROM TuyenXe WHERE (TrangThai = N'Chưa Chạy') AND (TuyenXe LIKE @tentuyenxe ) ORDER BY ThoiGianXuatPhat";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { '%'+tentuyenxe+'%' });
            foreach (DataRow item in data.Rows)
            {
                TuyenXeDTO tx = new TuyenXeDTO(item);
                listxe.Add(tx);
            }
            return listxe;
        }
        public void chuyenTrangThaiXe(string matuyenxe)
        {
            string query = "UPDATE TuyenXe SET TrangThai = N'Đã Chạy' WHERE(MaTuyenXe = @matuyenxe )";
            DataProvider.Instance.ExecuteQuery(query, new object[] { matuyenxe });
        }
        public bool themTuyenXe(string biensoxe, string tuyenxe, DateTime thoigianxuatphat, string tentaixe, int giave)
        {
            string query = "INSERT dbo.TuyenXe (MaTuyenXe, BienSoXe, TuyenXe, ThoiGianXuatPhat, TenTaiXe, TrangThai, GiaVe) VALUES(N'', @biensoxe , @tuyenxe , @hoigianxuatphat , @tentaixe , N'Chưa Chạy', @giave )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { biensoxe, tuyenxe, thoigianxuatphat, tentaixe, giave });
            return result > 0;
        }
        public bool huyTuyenXe(string matuyenxe)
        {
            string query = "DELETE FROM TuyenXe WHERE MaTuyenXe = @matuyenxe ";
            int result = DataProvider.Instance.ExecuteNonQuery(query , new object[] { matuyenxe });
            return result > 0;
        }
    }
}

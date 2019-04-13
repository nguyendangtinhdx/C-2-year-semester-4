using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class ThuongPhatDAO
    {
        private static ThuongPhatDAO instance;

        public static ThuongPhatDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThuongPhatDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ThuongPhatDAO() { }
        public bool themNhanVienThuongPhat(string manhanvien, DateTime thoigianthuongphat, string hinhthuc, int sotien, string lydo)
        {
            string query = "INSERT dbo.ThuongPhat (MaNhanVien, ThoiGianThuongPhat, HinhThuc, SoTien, LyDo) VALUES( @manhanvien , @thoigianthuongphat , @hinhthuc , @sotien , @lydo )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { manhanvien, thoigianthuongphat, hinhthuc, sotien, lydo });
            return result > 0;
        }
    }
}

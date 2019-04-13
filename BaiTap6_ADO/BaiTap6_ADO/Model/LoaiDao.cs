using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BaiTap6_ADO.Model
{
    public class LoaiDao
    {
        public List<LoaiBean> getLoai()
        {
            string sql = "SELECT * FROM loai";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<LoaiBean> ds = new List<LoaiBean>();
            while (rs.Read())
            {
                string maLoai = rs["maloai"].ToString();
                string tenLoai = rs["tenloai"].ToString();
                LoaiBean loai = new LoaiBean(maLoai, tenLoai);
                ds.Add(loai);

                //String[] st = new String[2];
                //st[0] = rs[0].ToString();
                //st[1] = rs[1].ToString();
            }
            rs.Close();
            return ds;
        }
        public int themLoai(string maLoai, string tenLoai)
        {
            string sql = " INSERT INTO loai VALUES(@maLoai,@tenLoai) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maLoai", maLoai);
            SqlParameter ts2 = new SqlParameter("@tenLoai", tenLoai);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            return cmd.ExecuteNonQuery();
        }
        public int suaLoai(string maLoai, string tenLoai)
        {
            string sql = " UPDATE loai SET tenloai = @tenLoai WHERE maloai = @maLoai ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@tenLoai", tenLoai);
            SqlParameter ts2 = new SqlParameter("@maLoai", maLoai);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            return cmd.ExecuteNonQuery();
        }
        public int xoaLoai(string maLoai)
        {
            string sql = " DELETE loai WHERE maloai = @maLoai ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maLoai", maLoai));
            return cmd.ExecuteNonQuery();
        }
        public List<LoaiBean> timLoai(string key)
        {
            string sql = "SELECT * FROM loai WHERE tenloai LIKE @tenLoai ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@tenLoai", key);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<LoaiBean> ds = new List<LoaiBean>();
            while (rs.Read())
            {
                string maLoai = rs["maloai"].ToString();
                string tenLoai = rs["tenloai"].ToString();
                LoaiBean loai = new LoaiBean(maLoai, tenLoai);
                ds.Add(loai);
            }
            rs.Close();
            return ds;
        }
    }
}

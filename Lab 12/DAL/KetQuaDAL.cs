using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    public class KetQuaDAL
    {
        // Lay danh sach lop (sp_Lop_GetAll)
        public DataTable GetLop()
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_Lop_GetAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Lay danh sach mon hoc (sp_MonHoc_GetAll)
        public DataTable GetMonHoc()
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_MonHoc_GetAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Lay sinh vien theo lop va mon, kem diem neu da co
        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_KetQua_GetByLopMon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaLop", maLop);
            cmd.Parameters.AddWithValue("@MaMon", maMon);
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Luu tat ca diem trong 1 transaction:
        // dong nao loi thi rollback het, thanh cong het moi commit
        public int SaveAll(string maMon, DataTable table)
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();

            try
            {
                int count = 0;

                foreach (DataRow row in table.Rows)
                {
                    string maSV = row["MaSV"].ToString() ?? "";
                    double diem = Convert.ToDouble(row["Diem"]);
                    string ghiChu = row["GhiChu"].ToString() ?? "";

                    // command phai gan transaction (tham so thu 3)
                    using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaMon", maMon);
                    cmd.Parameters.AddWithValue("@Diem", diem);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.ExecuteNonQuery();

                    count++;
                }

                trans.Commit(); // chi commit sau khi vong lap xong
                return count;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
    }
}

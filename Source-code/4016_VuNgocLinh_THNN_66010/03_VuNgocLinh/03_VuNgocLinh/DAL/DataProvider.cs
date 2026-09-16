using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _03_VuNgocLinh.DAL
{
    public static class DataProvider
    {
        // Load default connection string from App.config (key = "QuanLyDichVu").
        // If missing, fall back to the requested local server/database.
        private static string _connectionString = LoadDefaultConnectionString();

        public static string ConnectionString
        {
            get => _connectionString;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ConnectionString cannot be null or empty.", nameof(value));
                _connectionString = value;
            }
        }

        private static string LoadDefaultConnectionString()
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["QuanLyDichVu"]?.ConnectionString;
                if (!string.IsNullOrWhiteSpace(cs)) return cs;
            }
            catch
            {
                // ignore and fallback
            }

            // Fallback to the database specified in your SQL script.
            return @"Data Source=LAPTOP-0FBIHDMS\SQLEXPRESS;Initial Catalog=QuanLyDichVu_DaiDuongXanh;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;";
        }

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                adapter.Fill(dt);
            }
            return dt;
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        // Thêm vào DataProvider.cs
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                { conn.Open(); return true; }
            }
            catch { return false; }
        }

        // Thêm vào ChungTuDAL.cs (nếu chưa có)
        public static bool MaCTExists(string maCT)
        {
            object result = DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM ChungTu WHERE MACT = @mact",
                new System.Data.SqlClient.SqlParameter("@mact", maCT));
            return Convert.ToInt32(result) > 0;
        }
        public static void ExecuteTransaction(Action<SqlConnection, SqlTransaction> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        action(conn, tran);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _03_VuNgocLinh.DTO;

namespace _03_VuNgocLinh.DAL
{
    public static class ChiTietDonDichVuDAL
    {
        /// <summary>
        /// Lấy đầy đủ chi tiết dịch vụ của một đơn (JOIN DichVu để có tên + ĐVT)
        /// dùng để hiển thị (read-only) trong dgvDichVu của FrmChungTu.
        /// </summary>
        public static List<ChungTuDonDichVuChiTietItem> GetFullByDon(string maDon)
        {
            var list = new List<ChungTuDonDichVuChiTietItem>();
            if (string.IsNullOrWhiteSpace(maDon)) return list;

            var dt = DataProvider.ExecuteQuery(@"
SELECT CT.MADV, DV.TENDV, DV.DONVITINH, CT.SOLUONG, CT.DONGIA, CT.GHICHU
FROM ChiTietDonDichVu CT
JOIN DichVu DV ON DV.MADV = CT.MADV
WHERE CT.MADON = @m
ORDER BY CT.MADV", new SqlParameter("@m", maDon));

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChungTuDonDichVuChiTietItem
                {
                    MaDichVu = Convert.ToString(r["MADV"]),
                    TenDichVu = Convert.ToString(r["TENDV"]),
                    DonViTinh = Convert.ToString(r["DONVITINH"]),
                    SoLuong = Convert.ToInt32(r["SOLUONG"]),
                    DonGia = Convert.ToDecimal(r["DONGIA"]),
                    GhiChu = r["GHICHU"] == DBNull.Value ? null : Convert.ToString(r["GHICHU"])
                });
            }

            return list;
        }

        public static DataTable GetByDon(string maDon)
        {
            return DataProvider.ExecuteQuery(@"
SELECT MADON, MADV, SOLUONG, DONGIA, THANHTIEN, GHICHU
FROM ChiTietDonDichVu
WHERE MADON = @m ORDER BY MADV", new SqlParameter("@m", maDon));
        }

        public static bool DeleteAllForDon(string maDon)
        {
            int r = DataProvider.ExecuteNonQuery("DELETE FROM ChiTietDonDichVu WHERE MADON = @m", new SqlParameter("@m", maDon));
            return r > 0;
        }

        public static bool Insert(string maDon, string maDv, int soLuong, decimal donGia, string ghiChu = null)
        {
            int r = DataProvider.ExecuteNonQuery(@"
INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU)
VALUES (@madon, @madv, @soluong, @dongia, @ghichu)",
                new SqlParameter("@madon", maDon),
                new SqlParameter("@madv", maDv),
                new SqlParameter("@soluong", soLuong),
                new SqlParameter("@dongia", donGia),
                new SqlParameter("@ghichu", (object)ghiChu ?? DBNull.Value));
            return r > 0;
        }
    }
}
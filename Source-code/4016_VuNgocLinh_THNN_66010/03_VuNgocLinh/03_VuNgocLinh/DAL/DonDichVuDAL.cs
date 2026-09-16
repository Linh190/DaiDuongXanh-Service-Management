using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _03_VuNgocLinh.DTO;

namespace _03_VuNgocLinh.DAL
{
    public static class DonDichVuDAL
    {
        /// <summary>
        /// Lấy danh sách Đơn dịch vụ để đổ vào cboMaDon trên FrmChungTu.
        ///
        /// Điều kiện lọc:
        ///   1. TRANGTHAI phải là 'Đã xác nhận' | 'Đang xử lý' | 'Hoàn thành'
        ///      (đơn 'Chờ xác nhận' chưa xác nhận → chưa đủ điều kiện lập CT)
        ///      (đơn 'Hủy' → không lập CT)
        ///   2. Chưa có chứng từ nào liên kết (NOT EXISTS ChungTu.MADON)
        ///      → mỗi đơn chỉ được lập 1 chứng từ duy nhất
        /// </summary>
        public static List<ChungTuDonDichVuItem> GetAllForChungTu()
        {
            var list = new List<ChungTuDonDichVuItem>();
            var dt = DataProvider.ExecuteQuery(@"
                SELECT  D.MADON,
                        D.MAKH,
                        KH.TENKH,
                        D.DIEMDI,
                        D.DIEMDEN,
                        D.NGAYDAT,
                        D.NGAYTHUCHIEN,
                        D.TRANGTHAI
                FROM    DonDichVu  D
                JOIN    KhachHang  KH ON KH.MAKH = D.MAKH
                WHERE   D.TRANGTHAI IN (
                            N'Đã xác nhận',
                            N'Đang xử lý',
                            N'Hoàn thành'
                        )
                  AND   NOT EXISTS (
                            SELECT 1
                            FROM   ChungTu CT
                            WHERE  CT.MADON = D.MADON
                        )
                ORDER BY D.NGAYDAT DESC, D.MADON DESC");

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChungTuDonDichVuItem
                {
                    MaDon = Convert.ToString(r["MADON"]),
                    MaKhachHang = Convert.ToString(r["MAKH"]),
                    TenKhachHang = Convert.ToString(r["TENKH"]),
                    DiemDi = r["DIEMDI"] == DBNull.Value ? "" : Convert.ToString(r["DIEMDI"]),
                    DiemDen = r["DIEMDEN"] == DBNull.Value ? "" : Convert.ToString(r["DIEMDEN"]),
                    NgayDat = Convert.ToDateTime(r["NGAYDAT"]),
                    NgayThucHien = Convert.ToDateTime(r["NGAYTHUCHIEN"]),
                    TrangThai = r["TRANGTHAI"] == DBNull.Value ? "" : Convert.ToString(r["TRANGTHAI"])
                });
            }

            return list;
        }

        // ── Các method còn lại giữ nguyên ────────────────────────────────

        public static void CreateDonWithDetails(string maDon, DateTime ngayThucHien,
            string diemDi, string diemDen, string ghichu, string trangThai,
            string maKh, string maNvTiepNhan,
            IEnumerable<Tuple<string, int, decimal, string>> details)
        {
            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                using (var cmd = new SqlCommand(@"
INSERT INTO DonDichVu (MADON, NGAYDAT, NGAYTHUCHIEN, DIEMDI, DIEMDEN, GHICHU, TRANGTHAI, MAKH, MANV_TIEPNHAN)
VALUES (@madon, GETDATE(),
        CASE WHEN @ngaythuchien < GETDATE() THEN GETDATE() ELSE @ngaythuchien END,
        @diemdi, @diemden, @ghichu, @trangthai, @makh, @manv)", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@madon", maDon);
                    cmd.Parameters.AddWithValue("@ngaythuchien", ngayThucHien);
                    cmd.Parameters.AddWithValue("@diemdi", diemDi ?? string.Empty);
                    cmd.Parameters.AddWithValue("@diemden", diemDen ?? string.Empty);
                    cmd.Parameters.AddWithValue("@ghichu", (object)ghichu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@trangthai", trangThai ?? "Chờ xác nhận");
                    cmd.Parameters.AddWithValue("@makh", maKh);
                    cmd.Parameters.AddWithValue("@manv", (object)maNvTiepNhan ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                foreach (var d in details)
                {
                    using (var cmd = new SqlCommand(@"
INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU)
VALUES (@madon, @madv, @soluong, @dongia, @ghichu)", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@madon", maDon);
                        cmd.Parameters.AddWithValue("@madv", d.Item1);
                        cmd.Parameters.AddWithValue("@soluong", d.Item2);
                        cmd.Parameters.AddWithValue("@dongia", d.Item3);
                        cmd.Parameters.AddWithValue("@ghichu", (object)d.Item4 ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        public static bool Exists(string maDon)
        {
            return DataProvider.ExecuteScalar(
                "SELECT 1 FROM DonDichVu WHERE MADON = @m",
                new SqlParameter("@m", maDon)) != null;
        }

        public static void UpdateTrangThai(string maDon, string trangThai,
            string maNvCapNhat = null, string ghiChu = null)
        {
            object oldObj = DataProvider.ExecuteScalar(
                "SELECT TRANGTHAI FROM DonDichVu WHERE MADON = @m",
                new SqlParameter("@m", maDon));
            string trangThaiCu = (oldObj == null || oldObj == DBNull.Value)
                ? string.Empty
                : Convert.ToString(oldObj);

            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                using (var cmd = new SqlCommand(
                    "UPDATE DonDichVu SET TRANGTHAI = @tt WHERE MADON = @m", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@tt", trangThai);
                    cmd.Parameters.AddWithValue("@m", maDon);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand(@"
INSERT INTO LichSuTrangThaiDon (MADON, TRANGTHAI_CU, TRANGTHAI_MOI, MANV_CAPNHAT, GHICHU)
VALUES (@m, @old, @tt, @manv, @ghichu)", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@m", maDon);
                    cmd.Parameters.AddWithValue("@old", trangThaiCu);
                    cmd.Parameters.AddWithValue("@tt", trangThai);
                    cmd.Parameters.AddWithValue("@manv", (object)maNvCapNhat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ghichu", (object)ghiChu ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            });
        }
    }
}

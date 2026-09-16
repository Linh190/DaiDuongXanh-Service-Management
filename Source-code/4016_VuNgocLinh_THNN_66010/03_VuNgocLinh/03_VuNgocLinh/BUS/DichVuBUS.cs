using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _03_VuNgocLinh.BUS
{
    public class DichVuBUS
    {
        // Temporary in-memory cart per customer (app-lifetime). Replace with DB persistence later.
        private static readonly Dictionary<string, List<CartItem>> _carts = new Dictionary<string, List<CartItem>>();

        private class CartItem
        {
            public string MaDichVu { get; set; }
            public int SoLuong { get; set; }
        }

        public DataTable GetAllNhom()
        {
            // Return a DataTable suitable for binding to ComboBox (DisplayMember = "TenNhom", ValueMember = "MaNhom")
            return DataProvider.ExecuteQuery("SELECT MANHOM AS MaNhom, TENNHOM AS TenNhom FROM NhomDichVu ORDER BY TENNHOM");
        }

        public List<DichVuDTO> GetAllDichVu()
        {
            var sql = @"
                SELECT d.MADV AS MaDichVu,
                       d.TENDV AS TenDichVu,
                       d.GIABAN AS GiaBan,
                       d.DONVITINH AS DonViTinh,
                       d.MOTA AS MoTa,
                       d.TRANGTHAI AS TrangThai,
                       d.MANHOM AS MaNhom,
                       n.TENNHOM AS TenNhom,
                       0       AS SoLuongTon
                FROM DichVu d
                LEFT JOIN NhomDichVu n ON n.MANHOM = d.MANHOM
                ORDER BY d.MADV";
            var dt = DataProvider.ExecuteQuery(sql);
            var list = new List<DichVuDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(MapRow(r));
            }
            return list;
        }

        public DichVuDTO GetByMa(string maDv)
        {
            if (string.IsNullOrWhiteSpace(maDv)) return null;
            var sql = @"
                SELECT d.MADV AS MaDichVu,
                       d.TENDV AS TenDichVu,
                       d.GIABAN AS GiaBan,
                       d.DONVITINH AS DonViTinh,
                       d.MOTA AS MoTa,
                       d.TRANGTHAI AS TrangThai,
                       d.MANHOM AS MaNhom,
                       n.TENNHOM AS TenNhom,
                       0       AS SoLuongTon
                FROM DichVu d
                LEFT JOIN NhomDichVu n ON n.MANHOM = d.MANHOM
                WHERE d.MADV = @id";
            var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@id", maDv));
            if (dt.Rows.Count == 0) return null;
            return MapRow(dt.Rows[0]);
        }

        public List<DichVuDTO> TimKiemDichVu(string tenSP, string maDM, decimal? giaTu, decimal? giaDen)
        {
            var sql = @"
                SELECT d.MADV AS MaDichVu,
                       d.TENDV AS TenDichVu,
                       d.GIABAN AS GiaBan,
                       d.DONVITINH AS DonViTinh,
                       d.MOTA AS MoTa,
                       d.TRANGTHAI AS TrangThai,
                       d.MANHOM AS MaNhom,
                       n.TENNHOM AS TenNhom,
                       0       AS SoLuongTon
                FROM DichVu d
                LEFT JOIN NhomDichVu n ON n.MANHOM = d.MANHOM
                WHERE 1=1";
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(tenSP))
            {
                sql += " AND d.TENDV LIKE @ten";
                parameters.Add(new SqlParameter("@ten", "%" + tenSP.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(maDM))
            {
                sql += " AND d.MANHOM = @manhom";
                parameters.Add(new SqlParameter("@manhom", maDM));
            }

            if (giaTu.HasValue)
            {
                sql += " AND d.GIABAN >= @giatu";
                parameters.Add(new SqlParameter("@giatu", giaTu.Value));
            }

            if (giaDen.HasValue)
            {
                sql += " AND d.GIABAN <= @giaden";
                parameters.Add(new SqlParameter("@giaden", giaDen.Value));
            }

            sql += " ORDER BY d.MADV";

            var dt = DataProvider.ExecuteQuery(sql, parameters.ToArray());
            var list = new List<DichVuDTO>();
            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));
            return list;
        }

        // Minimal in-memory cart implementation used by UI until a persisted solution exists.
        // Returns true when operation succeeded (added/updated); false on invalid input.
        public bool ThemVaoGioHang(string maKhachHang, string maDv, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang) || string.IsNullOrWhiteSpace(maDv) || soLuong <= 0)
                return false;

            lock (_carts)
            {
                if (!_carts.TryGetValue(maKhachHang, out var cart))
                {
                    cart = new List<CartItem>();
                    _carts[maKhachHang] = cart;
                }

                var item = cart.Find(x => x.MaDichVu == maDv);
                if (item == null)
                {
                    cart.Add(new CartItem { MaDichVu = maDv, SoLuong = soLuong });
                }
                else
                {
                    item.SoLuong += soLuong;
                }
            }

            return true;
        }

        private DichVuDTO MapRow(DataRow r)
        {
            return new DichVuDTO
            {
                MaDichVu = Convert.ToString(r["MaDichVu"]),
                TenDichVu = Convert.ToString(r["TenDichVu"]),
                GiaBan = r["GiaBan"] == DBNull.Value ? 0m : Convert.ToDecimal(r["GiaBan"]),
                DonViTinh = Convert.ToString(r["DonViTinh"]),
                MoTa = Convert.ToString(r["MoTa"]),
                TrangThai = Convert.ToString(r["TrangThai"]),
                MaNhom = Convert.ToString(r["MaNhom"]),
                TenNhom = r.Table.Columns.Contains("TenNhom") ? Convert.ToString(r["TenNhom"]) : null,
            };
        }
    }
}
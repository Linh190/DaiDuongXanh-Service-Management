using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _03_VuNgocLinh.DTO;

namespace _03_VuNgocLinh.DAL
{
    public static class ChungTuDAL
    {
        // ════════════════════════════════════════════════════════════════
        // Ràng buộc từ DB (CHECK constraints + trigger)
        //
        // CK_ChungTu_LOAI:
        //   'Vận đơn' | 'Hợp đồng' | 'Biên bản giao nhận'
        //   | 'Chứng từ xuất nhập khẩu' | 'Khác'
        //
        // CK_ChungTu_TRANGTHAI:
        //   'Chờ duyệt' | 'Đã duyệt' | 'Trả lại' | 'Từ chối'
        //
        // trigger tg_ChungTu_KiemTraNguoiKiemTra:
        //   MANV_KIEMTRA phải có VAITRO = 'Chủ doanh nghiệp'
        //   và TRANGTHAI = 'Đang làm việc'
        // ════════════════════════════════════════════════════════════════

        // Các giá trị hợp lệ (dùng chung cho Validate và UI)
        public static readonly string[] LoaiHopLe =
        {
            "Vận đơn", "Hợp đồng", "Biên bản giao nhận",
            "Chứng từ xuất nhập khẩu", "Khác"
        };

        public static readonly string[] TrangThaiHopLe =
        {
            "Chờ duyệt", "Đã duyệt", "Trả lại", "Từ chối"
        };

        // ── READ ─────────────────────────────────────────────────────────

        /// <summary>Lấy toàn bộ chứng từ, JOIN tên NV kiểm tra và trạng thái đơn.</summary>
        public static List<ChungTuDTO> GetAll()
        {
            var list = new List<ChungTuDTO>();
            var dt = DataProvider.ExecuteQuery(@"
                SELECT CT.MACT, CT.LOAICHUNGTU, CT.SOCHUNGTU, CT.NGAYLAP,
                       CT.TONGTIEN, CT.TRANGTHAI, CT.GHICHU, CT.NGAYDUYET,
                       CT.MADON, CT.MANV_KIEMTRA,
                       NV.TENNV       AS TENNV_KIEMTRA,
                       DDV.TRANGTHAI  AS TRANGTHAI_DON
                FROM   ChungTu CT
                JOIN   DonDichVu DDV ON DDV.MADON = CT.MADON
                LEFT JOIN NhanVien NV ON NV.MANV = CT.MANV_KIEMTRA
                ORDER BY CT.NGAYLAP DESC, CT.MACT");

            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));

            return list;
        }

        /// <summary>Lấy chứng từ theo MACT.</summary>
        public static ChungTuDTO GetByMa(string maChungTu)
        {
            if (string.IsNullOrWhiteSpace(maChungTu)) return null;

            var dt = DataProvider.ExecuteQuery(@"
                SELECT CT.MACT, CT.LOAICHUNGTU, CT.SOCHUNGTU, CT.NGAYLAP,
                       CT.TONGTIEN, CT.TRANGTHAI, CT.GHICHU, CT.NGAYDUYET,
                       CT.MADON, CT.MANV_KIEMTRA,
                       NV.TENNV       AS TENNV_KIEMTRA,
                       DDV.TRANGTHAI  AS TRANGTHAI_DON
                FROM   ChungTu CT
                JOIN   DonDichVu DDV ON DDV.MADON = CT.MADON
                LEFT JOIN NhanVien NV ON NV.MANV = CT.MANV_KIEMTRA
                WHERE  CT.MACT = @mact",
                new SqlParameter("@mact", maChungTu));

            return dt.Rows.Count == 0 ? null : MapRow(dt.Rows[0]);
        }

        /// <summary>Lấy danh sách chứng từ theo MADON.</summary>
        public static List<ChungTuDTO> GetByMaDon(string maDon)
        {
            var list = new List<ChungTuDTO>();
            if (string.IsNullOrWhiteSpace(maDon)) return list;

            var dt = DataProvider.ExecuteQuery(@"
                SELECT CT.MACT, CT.LOAICHUNGTU, CT.SOCHUNGTU, CT.NGAYLAP,
                       CT.TONGTIEN, CT.TRANGTHAI, CT.GHICHU, CT.NGAYDUYET,
                       CT.MADON, CT.MANV_KIEMTRA,
                       NV.TENNV       AS TENNV_KIEMTRA,
                       DDV.TRANGTHAI  AS TRANGTHAI_DON
                FROM   ChungTu CT
                JOIN   DonDichVu DDV ON DDV.MADON = CT.MADON
                LEFT JOIN NhanVien NV ON NV.MANV = CT.MANV_KIEMTRA
                WHERE  CT.MADON = @madon
                ORDER BY CT.NGAYLAP DESC",
                new SqlParameter("@madon", maDon));

            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));

            return list;
        }

        /// <summary>Tìm kiếm theo số chứng từ, mã đơn hoặc mã CT.</summary>
        public static List<ChungTuDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();

            string kw = "%" + keyword.Trim() + "%";
            var list = new List<ChungTuDTO>();

            var dt = DataProvider.ExecuteQuery(@"
                SELECT CT.MACT, CT.LOAICHUNGTU, CT.SOCHUNGTU, CT.NGAYLAP,
                       CT.TONGTIEN, CT.TRANGTHAI, CT.GHICHU, CT.NGAYDUYET,
                       CT.MADON, CT.MANV_KIEMTRA,
                       NV.TENNV       AS TENNV_KIEMTRA,
                       DDV.TRANGTHAI  AS TRANGTHAI_DON
                FROM   ChungTu CT
                JOIN   DonDichVu DDV ON DDV.MADON = CT.MADON
                LEFT JOIN NhanVien NV ON NV.MANV = CT.MANV_KIEMTRA
                WHERE  CT.SOCHUNGTU LIKE @kw
                    OR CT.MADON     LIKE @kw
                    OR CT.MACT      LIKE @kw
                ORDER BY CT.NGAYLAP DESC",
                new SqlParameter("@kw", kw));

            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));

            return list;
        }

        // ── CREATE ───────────────────────────────────────────────────────

        /// <summary>
        /// Thêm chứng từ mới.
        /// Trigger tg_ChungTu_KiemTraNguoiKiemTra kiểm tra MANV_KIEMTRA
        /// phải có VAITRO = 'Chủ doanh nghiệp' và đang làm việc.
        /// </summary>
        public static bool Insert(ChungTuDTO ct)
        {
            ValidateDTO(ct);

            int rows = DataProvider.ExecuteNonQuery(@"
                INSERT INTO ChungTu
                    (MACT, LOAICHUNGTU, SOCHUNGTU, NGAYLAP,
                     TONGTIEN, TRANGTHAI, GHICHU, MADON, MANV_KIEMTRA)
                VALUES
                    (@mact, @loai, @soct, @ngaylap,
                     @tongtien, @trangthai, @ghichu, @madon, @manv)",
                new SqlParameter("@mact", ct.MaChungTu),
                new SqlParameter("@loai", ct.LoaiChungTu),
                new SqlParameter("@soct", ct.SoChungTu),
                new SqlParameter("@ngaylap", ct.NgayLap),
                new SqlParameter("@tongtien", ct.TongTien.HasValue
                                                ? (object)ct.TongTien.Value
                                                : DBNull.Value),
                new SqlParameter("@trangthai", ct.TrangThai),
                new SqlParameter("@ghichu", string.IsNullOrWhiteSpace(ct.GhiChu)
                                                ? (object)DBNull.Value
                                                : ct.GhiChu),
                new SqlParameter("@madon", ct.MaDon),
                new SqlParameter("@manv", string.IsNullOrWhiteSpace(ct.MaNhanVienKiemTra)
                                                ? (object)DBNull.Value
                                                : ct.MaNhanVienKiemTra));
            return rows > 0;
        }

        // ── UPDATE ───────────────────────────────────────────────────────

        /// <summary>
        /// Cập nhật chứng từ (LOAICHUNGTU, TONGTIEN, TRANGTHAI, GHICHU, MANV_KIEMTRA).
        /// SOCHUNGTU và MADON không được đổi sau khi tạo.
        /// </summary>
        public static bool Update(ChungTuDTO ct)
        {
            ValidateDTO(ct);

            int rows = DataProvider.ExecuteNonQuery(@"
                UPDATE ChungTu
                SET    LOAICHUNGTU  = @loai,
                       TONGTIEN     = @tongtien,
                       TRANGTHAI    = @trangthai,
                       GHICHU       = @ghichu,
                       MANV_KIEMTRA = @manv
                WHERE  MACT = @mact",
                new SqlParameter("@loai", ct.LoaiChungTu),
                new SqlParameter("@tongtien", ct.TongTien.HasValue
                                                ? (object)ct.TongTien.Value
                                                : DBNull.Value),
                new SqlParameter("@trangthai", ct.TrangThai),
                new SqlParameter("@ghichu", string.IsNullOrWhiteSpace(ct.GhiChu)
                                                ? (object)DBNull.Value
                                                : ct.GhiChu),
                new SqlParameter("@manv", string.IsNullOrWhiteSpace(ct.MaNhanVienKiemTra)
                                                ? (object)DBNull.Value
                                                : ct.MaNhanVienKiemTra),
                new SqlParameter("@mact", ct.MaChungTu));
            return rows > 0;
        }

        /// <summary>
        /// Cập nhật nhanh trạng thái chứng từ.
        /// Khi duyệt ('Đã duyệt') sẽ ghi NGAYDUYET = GETDATE().
        /// CK_ChungTu_TRANGTHAI: 'Chờ duyệt' | 'Đã duyệt' | 'Trả lại' | 'Từ chối'
        /// </summary>
        public static bool UpdateTrangThai(string maChungTu, string trangThai, string maNhanVienKiemTra)
        {
            if (string.IsNullOrWhiteSpace(maChungTu))
                throw new ArgumentException("Mã chứng từ không được trống.");

            if (Array.IndexOf(TrangThaiHopLe, trangThai) < 0)
                throw new ArgumentException(
                    $"Trạng thái '{trangThai}' không hợp lệ. " +
                    "Chỉ chấp nhận: Chờ duyệt, Đã duyệt, Trả lại, Từ chối.");

            // Khi duyệt → ghi ngày duyệt; các trạng thái khác → xóa ngày duyệt
            string sql = trangThai == "Đã duyệt"
                ? @"UPDATE ChungTu
                    SET    TRANGTHAI    = @trangthai,
                           MANV_KIEMTRA = @manv,
                           NGAYDUYET   = GETDATE()
                    WHERE  MACT = @mact"
                : @"UPDATE ChungTu
                    SET    TRANGTHAI    = @trangthai,
                           MANV_KIEMTRA = @manv,
                           NGAYDUYET   = NULL
                    WHERE  MACT = @mact";

            int rows = DataProvider.ExecuteNonQuery(sql,
                new SqlParameter("@trangthai", trangThai),
                new SqlParameter("@manv", string.IsNullOrWhiteSpace(maNhanVienKiemTra)
                                                ? (object)DBNull.Value
                                                : maNhanVienKiemTra),
                new SqlParameter("@mact", maChungTu));
            return rows > 0;
        }

        // ── DELETE ───────────────────────────────────────────────────────

        /// <summary>Xóa chứng từ. Nên kiểm tra TRANGTHAI = 'Chờ duyệt' trước khi xóa.</summary>
        public static bool Delete(string maChungTu)
        {
            if (string.IsNullOrWhiteSpace(maChungTu))
                throw new ArgumentException("Mã chứng từ không được trống.");

            int rows = DataProvider.ExecuteNonQuery(
                "DELETE FROM ChungTu WHERE MACT = @mact",
                new SqlParameter("@mact", maChungTu));
            return rows > 0;
        }

        // ── SINH MÃ ──────────────────────────────────────────────────────

        /// <summary>Kiểm tra MACT đã tồn tại trong DB chưa.</summary>
        public static bool MaCTExists(string maCT)
        {
            if (string.IsNullOrWhiteSpace(maCT)) return false;
            object result = DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM ChungTu WHERE MACT = @mact",
                new SqlParameter("@mact", maCT.Trim()));
            return Convert.ToInt32(result) > 0;
        }

        /// <summary>Sinh MACT mới: CT00001, CT00002, … (đảm bảo không trùng DB).</summary>
        public static string GenerateNewMaChungTu()
        {
            object v = DataProvider.ExecuteScalar("SELECT MAX(MACT) FROM ChungTu");
            string candidate = GenerateNextId(Convert.ToString(v), "CT", 5);
            while (MaCTExists(candidate))
                candidate = GenerateNextId(candidate, "CT", 5);
            return candidate;
        }

        /// <summary>Alias legacy.</summary>
        public static string GenerateNewMaCT() => GenerateNewMaChungTu();

        /// <summary>Kiểm tra SOCHUNGTU đã tồn tại trong DB chưa.</summary>
        public static bool SoChungTuExists(string soChungTu)
        {
            if (string.IsNullOrWhiteSpace(soChungTu)) return false;
            object result = DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM ChungTu WHERE SOCHUNGTU = @soct",
                new SqlParameter("@soct", soChungTu.Trim()));
            return Convert.ToInt32(result) > 0;
        }

        /// <summary>Sinh SOCHUNGTU mới theo loại chứng từ, đảm bảo không trùng DB.</summary>
        public static string GenerateNewSoChungTu(string loaiChungTu)
        {
            string prefix;
            switch (loaiChungTu)
            {
                case "Vận đơn": prefix = "VD"; break;
                case "Hợp đồng": prefix = "HD"; break;
                case "Biên bản giao nhận": prefix = "BB"; break;
                case "Chứng từ xuất nhập khẩu": prefix = "XNK"; break;
                default: prefix = "CT"; break;
            }

            object v = DataProvider.ExecuteScalar(
                "SELECT MAX(SOCHUNGTU) FROM ChungTu WHERE LOAICHUNGTU = @loai",
                new SqlParameter("@loai", loaiChungTu));
            string candidate = GenerateNextId(Convert.ToString(v), prefix, 5);
            // Đảm bảo không trùng UNIQUE KEY
            while (SoChungTuExists(candidate))
                candidate = GenerateNextId(candidate, prefix, 5);
            return candidate;
        }

        /// <summary>Alias legacy.</summary>
        public static string GenerateNewSoCT(string loaiChungTu) => GenerateNewSoChungTu(loaiChungTu);

        // ── LOOKUP cho ComboBox ───────────────────────────────────────────

        /// <summary>
        /// Lấy NV được phép duyệt chứng từ.
        /// Theo trigger tg_ChungTu_KiemTraNguoiKiemTra:
        ///   chỉ VAITRO = 'Chủ doanh nghiệp' và TRANGTHAI = 'Đang làm việc'.
        /// </summary>
        public static List<ChungTuNhanVienItem> GetNhanVienKiemTra()
        {
            var list = new List<ChungTuNhanVienItem>();
            var dt = DataProvider.ExecuteQuery(@"
                SELECT MANV, TENNV, VAITRO, EMAILNV
                FROM   NhanVien
                WHERE  TRANGTHAI = N'Đang làm việc'
                  AND  VAITRO   = N'Chủ doanh nghiệp'
                ORDER BY MANV");

            foreach (DataRow r in dt.Rows)
                list.Add(new ChungTuNhanVienItem
                {
                    MaNhanVien = Convert.ToString(r["MANV"]),
                    HoTen = Convert.ToString(r["TENNV"]),
                    VaiTro = Convert.ToString(r["VAITRO"]),
                    Email = r["EMAILNV"] != DBNull.Value
                                    ? Convert.ToString(r["EMAILNV"])
                                    : string.Empty
                });

            return list;
        }

        /// <summary>
        /// Lấy danh sách khách hàng đang hoạt động.
        /// Dùng đúng tên cột DB: MAKH, TENKH, DIENTHOAIKH, EMAILKH, DIACHIKH.
        /// </summary>
        public static List<ChungTuKhachHangItem> GetAllKhachHang()
        {
            var list = new List<ChungTuKhachHangItem>();
            var dt = DataProvider.ExecuteQuery(@"
                SELECT MAKH, TENKH, DIENTHOAIKH, EMAILKH, DIACHIKH
                FROM   KhachHang
                WHERE  TRANGTHAI = N'Hoạt động'
                ORDER BY TENKH");

            foreach (DataRow r in dt.Rows)
                list.Add(new ChungTuKhachHangItem
                {
                    MaKhachHang = Convert.ToString(r["MAKH"]),
                    HoTen = Convert.ToString(r["TENKH"]),
                    SoDienThoai = r["DIENTHOAIKH"] != DBNull.Value
                                    ? Convert.ToString(r["DIENTHOAIKH"])
                                    : string.Empty,
                    Email = r["EMAILKH"] != DBNull.Value
                                    ? Convert.ToString(r["EMAILKH"])
                                    : string.Empty,
                    DiaChi = r["DIACHIKH"] != DBNull.Value
                                    ? Convert.ToString(r["DIACHIKH"])
                                    : string.Empty
                });

            return list;
        }

        /// <summary>
        /// Lấy NV đang làm việc (dùng cho các ComboBox tổng quát).
        /// Dùng đúng tên cột DB: MANV, TENNV, EMAILNV.
        /// </summary>
        public static List<ChungTuNhanVienItem> GetAllNhanVien()
        {
            var list = new List<ChungTuNhanVienItem>();
            var dt = DataProvider.ExecuteQuery(@"
                SELECT MANV, TENNV, VAITRO, EMAILNV
                FROM   NhanVien
                WHERE  TRANGTHAI = N'Đang làm việc'
                ORDER BY TENNV");

            foreach (DataRow r in dt.Rows)
                list.Add(new ChungTuNhanVienItem
                {
                    MaNhanVien = Convert.ToString(r["MANV"]),
                    HoTen = Convert.ToString(r["TENNV"]),
                    VaiTro = Convert.ToString(r["VAITRO"]),
                    Email = r["EMAILNV"] != DBNull.Value
                                    ? Convert.ToString(r["EMAILNV"])
                                    : string.Empty
                });

            return list;
        }

        public static List<ChungTuDichVuItem> GetAllDichVu()
        {
            return ChungTuBanHangDAL.GetAllDichVu();
        }

        /// <summary>Generate new MADON — legacy alias.</summary>
        public static string GenerateNewMaDon()
        {
            return ChungTuBanHangDAL.GenerateNewMaDonHang();
        }

        /// <summary>
        /// Lưu đơn dịch vụ mới: DonDichVu + ChiTietDonDichVu (UI convenience wrapper).
        /// KHÔNG tạo ChungTu — chứng từ chỉ lập khi đơn đã hoàn thành (xem FrmChungTu).
        /// Tham số ct chỉ dùng để tương thích chữ ký cũ, không còn tác dụng tạo chứng từ.
        /// </summary>
        public static string SaveChungTu(DonDichVuDTO don, List<ChungTuChiTietData> chiTiet, ChungTuDTO ct = null)
        {
            if (don == null) throw new ArgumentNullException(nameof(don));
            if (chiTiet == null) throw new ArgumentNullException(nameof(chiTiet));

            var data = new ChungTuBanHangData
            {
                MaDonHang = don.MaDon,
                MaKhachHang = don.MaKhachHang,
                MaNhanVien = don.MaNhanVienTiepNhan,
                NgayChungTu = don.NgayThucHien != default(DateTime)
                                        ? don.NgayThucHien : don.NgayDat,
                DiemDi = don.DiemDi,
                DiemDen = don.DiemDen,
                DienGiai = don.GhiChu,
                TrangThai = string.IsNullOrWhiteSpace(don.TrangThai)
                                        ? "Chờ xác nhận" : don.TrangThai,
                ThanhTienTruocThue = ct?.TongTien ?? 0m,
                MaHoaDon = null,
                MaChungTu = ct?.MaChungTu
            };
            data.ChiTiet = new List<ChungTuChiTietData>(chiTiet);

            return ChungTuBanHangDAL.SaveChungTu(data, data.ChiTiet);
        }

        /// <summary>Overload nhận list ChiTietDonDV từ DTO namespace.</summary>
        public static void SaveChungTu(DonDichVuDTO don,
            List<_03_VuNgocLinh.DTO.ChiTietDonDV> chiTietModels, ChungTuDTO ct = null)
        {
            if (chiTietModels == null) throw new ArgumentNullException(nameof(chiTietModels));

            var chiTiet = new List<ChungTuChiTietData>();
            foreach (var m in chiTietModels)
            {
                chiTiet.Add(new ChungTuChiTietData
                {
                    MaDon = string.IsNullOrWhiteSpace(m.MADON) ? don.MaDon : m.MADON,
                    MaDichVu = m.MADV,
                    SoLuong = m.SOLUONG,
                    DonGia = m.DONGIA,
                    GhiChu = m.GHICHU
                });
            }
            SaveChungTu(don, chiTiet, ct);
        }

        /// <summary>Insert helper for legacy callers (ChungTuBUS).</summary>
        internal static bool InsertChungTu(string maCt, string loai, string soChungTu,
            DateTime ngayLap, decimal? tongTien, string trangThai,
            string maDon, string maNvKiemTra, string ghiChu = null)
        {
            var ct = new ChungTuDTO
            {
                MaChungTu = maCt,
                LoaiChungTu = loai,
                SoChungTu = soChungTu,
                NgayLap = ngayLap,
                TongTien = tongTien,
                TrangThai = trangThai,
                GhiChu = ghiChu,
                MaDon = maDon,
                MaNhanVienKiemTra = maNvKiemTra
            };
            return Insert(ct);
        }

        // ════════════════════════════════════════════════════════════════
        // PRIVATE HELPERS
        // ════════════════════════════════════════════════════════════════

        private static ChungTuDTO MapRow(DataRow r)
        {
            return new ChungTuDTO
            {
                MaChungTu = Convert.ToString(r["MACT"]),
                LoaiChungTu = Convert.ToString(r["LOAICHUNGTU"]),
                SoChungTu = Convert.ToString(r["SOCHUNGTU"]),
                NgayLap = Convert.ToDateTime(r["NGAYLAP"]),
                TongTien = r["TONGTIEN"] == DBNull.Value
                            ? (decimal?)null
                            : Convert.ToDecimal(r["TONGTIEN"]),
                TrangThai = Convert.ToString(r["TRANGTHAI"]),
                GhiChu = r["GHICHU"] == DBNull.Value
                            ? null
                            : Convert.ToString(r["GHICHU"]),
                NgayDuyet = r["NGAYDUYET"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(r["NGAYDUYET"]),
                MaDon = Convert.ToString(r["MADON"]),
                MaNhanVienKiemTra = r["MANV_KIEMTRA"] == DBNull.Value
                            ? null
                            : Convert.ToString(r["MANV_KIEMTRA"]),
                TenNhanVienKiemTra = r["TENNV_KIEMTRA"] == DBNull.Value
                            ? null
                            : Convert.ToString(r["TENNV_KIEMTRA"]),
                TrangThaiDon = Convert.ToString(r["TRANGTHAI_DON"])
            };
        }

        private static void ValidateDTO(ChungTuDTO ct)
        {
            if (ct == null)
                throw new ArgumentNullException(nameof(ct));
            if (string.IsNullOrWhiteSpace(ct.MaChungTu))
                throw new ArgumentException("Mã chứng từ không được trống.");
            if (string.IsNullOrWhiteSpace(ct.SoChungTu))
                throw new ArgumentException("Số chứng từ không được trống. (UQ_ChungTu_SOCHUNGTU)");
            if (string.IsNullOrWhiteSpace(ct.MaDon))
                throw new ArgumentException("Mã đơn dịch vụ không được trống. (MADON NOT NULL)");

            // CK_ChungTu_LOAI
            if (Array.IndexOf(LoaiHopLe, ct.LoaiChungTu) < 0)
                throw new ArgumentException(
                    $"Loại chứng từ '{ct.LoaiChungTu}' không hợp lệ. " +
                    "Chỉ chấp nhận: " + string.Join(", ", LoaiHopLe));

            // CK_ChungTu_TRANGTHAI
            if (Array.IndexOf(TrangThaiHopLe, ct.TrangThai) < 0)
                throw new ArgumentException(
                    $"Trạng thái '{ct.TrangThai}' không hợp lệ. " +
                    "Chỉ chấp nhận: " + string.Join(", ", TrangThaiHopLe));

            // CK_ChungTu_TONGTIEN
            if (ct.TongTien.HasValue && ct.TongTien.Value < 0)
                throw new ArgumentException("Tổng tiền không được âm.");
        }

        private static string GenerateNextId(string maxId, string prefix, int numberLength)
        {
            if (string.IsNullOrWhiteSpace(maxId))
                return prefix + "1".PadLeft(numberLength, '0');

            try
            {
                int i = maxId.Length - 1;
                while (i >= 0 && char.IsDigit(maxId[i])) i--;
                string numPart = (i < maxId.Length - 1) ? maxId.Substring(i + 1) : "0";
                int next = int.Parse(numPart) + 1;
                string newNum = next.ToString().PadLeft(Math.Max(numberLength, numPart.Length), '0');
                return (i >= 0 ? maxId.Substring(0, i + 1) : prefix) + newNum;
            }
            catch
            {
                return prefix + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }
    }
}
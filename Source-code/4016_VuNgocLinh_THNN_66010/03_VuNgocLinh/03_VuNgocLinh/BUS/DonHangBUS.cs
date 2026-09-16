using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03_VuNgocLinh.BUS
{
    public class DonHangBUS
    {
        /// <summary>
        /// Load danh sách ??n hàng (DonDichVu) ?? hi?n th?.
        /// </summary>
        public DataTable LoadDanhSachDonHang()
        {
            return DonHangDAL.GetAllDonHang();
        }

        /// <summary>
        /// Thêm ??n hàng + chi ti?t. Tr? v? true n?u thành công, ng??c l?i false và thông báo l?i.
        /// </summary>
        public bool ThemDonHang(DonDichVuDTO don, List<ChiTietDonDichVuDTO> chiTiet, out string thongBao)
        {
            thongBao = null;
            try
            {
                if (!ValidateDonHang(don, chiTiet, out thongBao)) return false;

                // Map DTO -> DAL parameters
                string maDon = don.MaDon;
                DateTime ngayThucHien = don.NgayThucHien;
                string diemDi = don.DiemDi;
                string diemDen = don.DiemDen;
                string ghiChu = don.GhiChu;
                string trangThai = string.IsNullOrWhiteSpace(don.TrangThai) ? "Chờ xác nhận" : don.TrangThai;
                string maKh = don.MaKhachHang;
                // Use property name that exists on DonDichVuDTO
                string maNv = don.MaNhanVienTiepNhan;

                // Convert ChiTiet DTO list used by DonHangDAL.InsertDonHang
                var details = chiTiet.Select(ct => new ChiTietDonDichVuDTO
                {
                    MaDon = ct.MaDon,
                    MaDichVu = ct.MaDichVu,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia,
                    GhiChu = ct.GhiChu
                }).ToList();

                DonHangDAL.InsertDonHang(maDon, ngayThucHien, diemDi, diemDen, ghiChu, trangThai, maKh, maNv, details);
                thongBao = "Thêm đơn hàng thành công.";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi thêm đơn hàng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật đơn hàng. Nếu chiTiet != null thì thay thế toàn bộ chi tiết.
        /// </summary>
        public bool CapNhatDonHang(DonDichVuDTO don, List<ChiTietDonDichVuDTO> chiTiet, out string thongBao)
        {
            thongBao = null;
            try
            {
                if (don == null || string.IsNullOrWhiteSpace(don.MaDon))
                { thongBao = "Mã đơn không hợp lệ."; return false; }

                if (chiTiet != null && chiTiet.Count == 0)
                { thongBao = "Nếu cung cấp chi tiết thì phải có ít nhất một dòng."; return false; }

                // Validate basic fields (reuse validator)
                if (!ValidateDonHang(don, chiTiet, out thongBao)) return false;

                DonHangDAL.UpdateDonHang(
                    don.MaDon,
                    don.NgayThucHien,
                    don.DiemDi,
                    don.DiemDen,
                    don.GhiChu,
                    don.TrangThai,
                    don.MaKhachHang,
                    // Use property name that exists on DonDichVuDTO
                    don.MaNhanVienTiepNhan,
                    chiTiet);
                thongBao = "Cập nhật đơn hàng thành công.";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi cập nhật đơn hàng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa đơn hàng theo mã.
        /// </summary>
        public bool XoaDonHang(string maDon, out string thongBao)
        {
            thongBao = null;
            try
            {
                if (string.IsNullOrWhiteSpace(maDon)) { thongBao = "Mã đơn không hợp lệ."; return false; }

                bool ok = DonHangDAL.DeleteDonHang(maDon);
                thongBao = ok ? "Xóa đơn hàng thành công." : "Xóa đơn hàng thất bại (không tìm thấy).";
                return ok;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi xóa đơn hàng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Tính tổng tiền trước thuế từ danh sách chi tiết.
        /// </summary>
        public decimal TinhTongTien(IEnumerable<ChiTietDonDichVuDTO> chiTiet)
        {
            if (chiTiet == null) return 0m;
            decimal tong = 0m;
            foreach (var ct in chiTiet)
            {
                int sl = Math.Max(0, ct.SoLuong);
                decimal dg = Math.Max(0m, ct.DonGia);
                tong += sl * dg;
            }
            return tong;
        }

        /// <summary>
        /// Validate đơn hàng; trả về true nếu hợp lệ, ngược lại false và thông báo lỗi.
        /// Kiểm tra các ràng buộc cơ bản: MADON, DIEMDI/DIEMDEN, tồn tại chi tiết, số lượng, đơn giá >=0.
        /// </summary>
        public bool ValidateDonHang(DonDichVuDTO don, IEnumerable<ChiTietDonDichVuDTO> chiTiet, out string thongBao)
        {
            thongBao = null;

            if (don == null) { thongBao = "Dữ liệu đơn rỗng."; return false; }
            if (string.IsNullOrWhiteSpace(don.MaDon)) { thongBao = "Mã đơn không được để trống."; return false; }
            if (string.IsNullOrWhiteSpace(don.DiemDi)) { thongBao = "Điểm đi không được để trống."; return false; }
            if (string.IsNullOrWhiteSpace(don.DiemDen)) { thongBao = "Điểm đến không được để trống."; return false; }

            // ✅ Chỉ validate chi tiết khi có truyền vào (không null)
            // null = "không thay đổi chi tiết", khác null = "thay thế chi tiết"
            if (chiTiet != null)
            {
                if (!chiTiet.Any())
                { thongBao = "Danh sách dịch vụ không được rỗng."; return false; }

                foreach (var ct in chiTiet)
                {
                    if (ct == null) { thongBao = "Chi tiết đơn không hợp lệ."; return false; }
                    if (string.IsNullOrWhiteSpace(ct.MaDichVu)) { thongBao = "Mã dịch vụ không được để trống."; return false; }
                    if (ct.SoLuong <= 0) { thongBao = $"Số lượng '{ct.MaDichVu}' phải lớn hơn 0."; return false; }
                    if (ct.DonGia < 0) { thongBao = $"Đơn giá '{ct.MaDichVu}' không được âm."; return false; }
                }
            }

            return true;
        }
    }
}
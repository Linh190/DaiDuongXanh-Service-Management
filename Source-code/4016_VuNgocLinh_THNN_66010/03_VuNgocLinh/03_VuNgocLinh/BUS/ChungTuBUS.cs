using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;

namespace _03_VuNgocLinh.BUS
{
    public class ChungTuBUS
    {
        /// <summary>
        /// Thêm chứng từ mới.
        /// trangThai hợp lệ: 'Chờ duyệt' | 'Đã duyệt' | 'Trả lại' | 'Từ chối'
        /// maNvKiemTra phải là Chủ doanh nghiệp đang làm việc (theo trigger).
        /// </summary>
        public bool InsertChungTu(string maCt, string loai, string soChungTu,
            DateTime ngayLap, decimal? tongTien, string trangThai,
            string maDon, string maNvKiemTra = null, string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(maCt))
                throw new ArgumentException("Mã chứng từ không được trống.");

            // Validate trạng thái trước khi gọi DAL
            if (Array.IndexOf(ChungTuDAL.TrangThaiHopLe, trangThai) < 0)
                throw new ArgumentException(
                    $"Trạng thái '{trangThai}' không hợp lệ. " +
                    "Chỉ chấp nhận: Chờ duyệt, Đã duyệt, Trả lại, Từ chối.");

            return ChungTuDAL.InsertChungTu(
                maCt, loai, soChungTu, ngayLap,
                tongTien, trangThai, maDon, maNvKiemTra, ghiChu);
        }

        /// <summary>Cập nhật toàn bộ thông tin chứng từ.</summary>
        public bool UpdateChungTu(ChungTuDTO ct)
        {
            return ChungTuDAL.Update(ct);
        }

        /// <summary>
        /// Duyệt / trả lại / từ chối chứng từ.
        /// Chỉ Chủ doanh nghiệp mới được thực hiện thao tác này (trigger).
        /// </summary>
        public bool CapNhatTrangThai(string maCt, string trangThai, string maNvKiemTra)
        {
            return ChungTuDAL.UpdateTrangThai(maCt, trangThai, maNvKiemTra);
        }

        /// <summary>Xóa chứng từ (chỉ nên xóa khi đang ở trạng thái 'Chờ duyệt').</summary>
        public bool DeleteChungTu(string maCt)
        {
            var ct = ChungTuDAL.GetByMa(maCt);
            if (ct == null)
                throw new Exception($"Không tìm thấy chứng từ '{maCt}'.");
            if (ct.TrangThai != "Chờ duyệt")
                throw new Exception("Chỉ được xóa chứng từ khi trạng thái là 'Chờ duyệt'.");

            return ChungTuDAL.Delete(maCt);
        }
    }
}

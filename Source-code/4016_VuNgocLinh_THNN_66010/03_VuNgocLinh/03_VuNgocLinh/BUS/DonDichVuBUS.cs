using _03_VuNgocLinh.DAL;
using System;
using System.Collections.Generic;

namespace _03_VuNgocLinh.BUS
{
    public class DonDichVuBUS
    {
        /// <summary>
        /// Create an order (DonDichVu) and its details in a single transaction.
        /// details: IEnumerable of Tuple(maDv, soLuong, donGia, ghiChu)
        /// </summary>
        public void CreateDon(string maDon, DateTime ngayThucHien, string diemDi, string diemDen,
            string ghiChu, string trangThai, string maKh, string maNvTiepNhan,
            IEnumerable<Tuple<string, int, decimal, string>> details)
        {
            if (string.IsNullOrWhiteSpace(maDon)) throw new ArgumentException(nameof(maDon));
            DonDichVuDAL.CreateDonWithDetails(maDon, ngayThucHien, diemDi, diemDen, ghiChu, trangThai, maKh, maNvTiepNhan, details);
        }

        public bool Exists(string maDon) => DonDichVuDAL.Exists(maDon);

        public void UpdateTrangThai(string maDon, string trangThai, string maNvCapNhat = null, string ghiChu = null)
        {
            DonDichVuDAL.UpdateTrangThai(maDon, trangThai, maNvCapNhat, ghiChu);
        }
    }
}
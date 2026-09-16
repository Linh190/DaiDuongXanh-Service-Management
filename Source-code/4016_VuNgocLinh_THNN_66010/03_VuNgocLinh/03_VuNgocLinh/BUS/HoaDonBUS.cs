using _03_VuNgocLinh.DAL;
using System;

namespace _03_VuNgocLinh.BUS
{
    public class HoaDonBUS
    {
        /// <summary>
        /// Create invoice for an order. Caller should generate MAHD (e.g., ChungTuBanHangDAL.GenerateNewMaHoaDon).
        /// </summary>
        public string CreateHoaDon(string maHoaDon, string maDon, string phuongThuc, decimal thueVatPercent, decimal chietKhauPercent, string maNvLap)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon)) throw new ArgumentException(nameof(maHoaDon));
            if (string.IsNullOrWhiteSpace(maDon)) throw new ArgumentException(nameof(maDon));
            return HoaDonDAL.CreateHoaDonForDon(maHoaDon, maDon, phuongThuc, thueVatPercent, chietKhauPercent, maNvLap);
        }

        public System.Data.DataRow GetById(string maHd) => HoaDonDAL.GetById(maHd);
    }
}
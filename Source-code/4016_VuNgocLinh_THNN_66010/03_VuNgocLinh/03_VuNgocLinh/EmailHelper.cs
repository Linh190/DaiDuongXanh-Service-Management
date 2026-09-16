using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace _03_VuNgocLinh.Helpers
{
    /// <summary>
    /// Gửi email qua Gmail SMTP (TLS port 587).
    ///
    /// ╔══════════════════════════════════════════════════════════════╗
    /// ║  HƯỚNG DẪN CẤU HÌNH (bắt buộc trước khi chạy)             ║
    /// ║                                                              ║
    /// ║  1. Đăng nhập Gmail: vnglinh19@gmail.com                    ║
    /// ║  2. Vào: myaccount.google.com → Bảo mật                     ║
    /// ║     → Xác minh 2 bước (bật nếu chưa bật)                   ║
    /// ║     → Mật khẩu ứng dụng → Tạo mật khẩu (16 ký tự)         ║
    /// ║  3. Dán 16 ký tự đó vào hằng SENDER_PASS bên dưới          ║
    /// ║     Ví dụ: "abcd efgh ijkl mnop"                            ║
    /// ╚══════════════════════════════════════════════════════════════╝
    /// </summary>
    public static class EmailHelper
    {
        private const string SMTP_HOST = "smtp.gmail.com";
        private const int SMTP_PORT = 587;

        private const string SENDER_EMAIL = "vnglinh19@gmail.com";
        private const string SENDER_PASS = "twwk dbub wecg nhed";
        private const string SENDER_NAME = "Đại Dương Xanh";

        // ──────────────────────────────────────────────────────────────────────
        /// <summary>
        /// Gửi mã xác minh OTP tới <paramref name="toEmail"/> (đồng bộ).
        /// Trả về <c>true</c> nếu gửi thành công.
        /// </summary>
        public static bool GuiMaXacMinh(string toEmail, string verificationCode)
        {
            try
            {
                using (var client = BuildSmtpClient())
                using (var mail = BuildMailMessage(toEmail, verificationCode))
                {
                    client.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n\nInner: " + ex.InnerException.Message;
                if (ex.InnerException?.InnerException != null)
                    msg += "\n" + ex.InnerException.InnerException.Message;

                System.Windows.Forms.MessageBox.Show(msg, "Debug SMTP");
                return false;
            }
        }

        /// <summary>
        /// Phiên bản bất đồng bộ — dùng khi gọi từ async method.
        /// Trả về <c>true</c> nếu gửi thành công.
        /// </summary>
        public static async Task<bool> GuiMaXacMinhAsync(string toEmail, string verificationCode)
        {
            try
            {
                using (var client = BuildSmtpClient())
                using (var mail = BuildMailMessage(toEmail, verificationCode))
                {
                    await client.SendMailAsync(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "[EmailHelper] Lỗi gửi mail (async): " + ex.Message);
                return false;
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        
       

        private static SmtpClient BuildSmtpClient()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12;

            return new SmtpClient(SMTP_HOST, SMTP_PORT)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    SENDER_EMAIL,
                    SENDER_PASS),
                Timeout = 20000
            };
        }
        private static MailMessage BuildMailMessage(string toEmail, string code)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(SENDER_EMAIL, SENDER_NAME),
                Subject = "[Đại Dương Xanh] Mã xác minh đặt lại mật khẩu",
                IsBodyHtml = true,
                Body = BuildEmailBody(code)
            };
            mail.To.Add(toEmail);
            return mail;
        }

        private static string BuildEmailBody(string code)
        {
            return $@"
<div style='font-family:Segoe UI,Arial,sans-serif; max-width:500px; margin:auto;
            border:1px solid #c8dded; border-radius:10px; overflow:hidden;
            box-shadow:0 2px 8px rgba(0,120,180,.15);'>

  <!-- Header -->
  <div style='background:#1C3664; padding:22px 28px;'>
    <h2 style='color:#fff; margin:0; font-size:20px; letter-spacing:.5px;'>
      🔒 Đặt lại mật khẩu
    </h2>
    <p style='color:#a8c8e8; margin:5px 0 0; font-size:13px;'>
      Đại Dương Xanh – Hệ thống quản lý dịch vụ vận tải quốc tế
    </p>
  </div>

  <!-- Body -->
  <div style='padding:28px; background:#ffffff;'>
    <p style='color:#1C3046; margin:0 0 12px;'>Xin chào,</p>
    <p style='color:#444; margin:0 0 20px;'>
      Chúng tôi nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn.
      Vui lòng sử dụng mã xác minh dưới đây:
    </p>

    <!-- OTP box -->
    <div style='text-align:center; margin:24px 0;'>
      <span style='display:inline-block; font-size:38px; font-weight:bold;
                   letter-spacing:12px; color:#0078B4;
                   background:#EBF5FB; padding:14px 32px;
                   border-radius:10px; border:2px solid #C8DDED;'>
        {code}
      </span>
    </div>

    <p style='color:#555; margin:0 0 8px;'>
      ⏱ Mã có hiệu lực trong <strong>10 phút</strong> kể từ khi nhận được email này.
    </p>
    <p style='color:#555; margin:0 0 20px;'>
      Nếu bạn không yêu cầu đặt lại mật khẩu, hãy bỏ qua email này.
      Tài khoản của bạn vẫn an toàn.
    </p>

    <hr style='border:none; border-top:1px solid #e0e8f0; margin:20px 0;'/>
    <p style='color:#aaa; font-size:11px; margin:0;'>
      © {DateTime.Now.Year} Đại Dương Xanh · Email này được gửi tự động, vui lòng không trả lời.
    </p>
  </div>
</div>";
        }
    }
}
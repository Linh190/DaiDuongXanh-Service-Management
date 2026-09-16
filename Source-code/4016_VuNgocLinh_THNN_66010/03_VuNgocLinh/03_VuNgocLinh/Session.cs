using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_VuNgocLinh
{
    /// <summary>
    /// Simple application session holder used across forms (login, role, user id).
    /// Kept minimal — extend later if you need more session data (e.g., token, expiry).
    /// </summary>
    public static class Session
    {
        public static string UserName { get; set; }
        public static string Role { get; set; }
        public static string UserID { get; set; }

        public static void Clear()
        {
            UserName = null;
            Role = null;
            UserID = null;
        }
    }
}
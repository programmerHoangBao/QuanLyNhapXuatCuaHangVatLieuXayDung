using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.utilities
{
    internal class StringUtility
    {
        public string ConvertToVietnameseCurrency(double amount)
        {
            return string.Format("{0:N0} VNĐ", amount);
        }
        public string GenerateRandomString(int length)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Bộ ký tự
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                // Lấy ngẫu nhiên một ký tự từ bộ ký tự
                char randomChar = allowedChars[random.Next(allowedChars.Length)];
                result.Append(randomChar);
            }

            return result.ToString();
        }

    }
}

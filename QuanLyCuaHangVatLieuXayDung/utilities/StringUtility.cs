using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.utilities
{
    /// <summary>
    /// Utilities related to String data type
    /// </summary>
    internal class StringUtility
    {

        /// <summary>
        /// Converts a numeric amount to a Vietnamese currency string format.
        /// </summary>
        /// <param name="amount">The numeric amount to convert.</param>
        /// <returns>A formatted string representing the amount in Vietnamese Dong (VNĐ).</returns>
        public string ConvertToVietnameseCurrency(double amount)
        {
            return string.Format("{0:N0}", amount);
        }

        /// <summary>
        /// Converts a Vietnamese currency string format back to a numeric amount.
        /// </summary>
        /// <param name="currencyString">The currency string to convert (e.g., "1,000,000 VNĐ").</param>
        /// <returns>A numeric value representing the amount.</returns>
        public double ConvertFromVietnameseCurrency(string currencyString)
        {
            string numericPart = currencyString.Trim();
            numericPart = numericPart.Replace(",", "");
            if (double.TryParse(numericPart, out double result))
            {
                return result;
            }
            else
            {
                throw new FormatException("The input string is not in the correct format.");
            }
        }

        /// <summary>
        /// Generates a random alphanumeric string of the specified length.
        /// </summary>
        /// <param name="length">The desired length of the generated string.</param>
        /// <returns>A random string consisting of uppercase letters, lowercase letters, and digits.</returns>
        public string GenerateRandomString(int length)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Character set
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                // Select a random character from the allowed character set
                char randomChar = allowedChars[random.Next(allowedChars.Length)];
                result.Append(randomChar);
            }

            return result.ToString();
        }
    }
}

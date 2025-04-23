using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class DoanhThuService : IDoanhThuService
    {
        private readonly MyDatabase myDatabase = new MyDatabase();

        public Dictionary<DateTime, decimal> TinhDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string loaiThoiGian)
        {
            var doanhThuTheoThoiGian = new Dictionary<DateTime, decimal>();
            string query = string.Empty;

            try
            {
                myDatabase.OpenConnection();

                // Xác định truy vấn dựa trên loại thời gian (Ngày, Tháng, Năm)
                switch (loaiThoiGian.ToLower())
                {
                    case "ngày":
                        query = @"SELECT CAST(hd.ThoiGianLap AS DATE) AS Ngay, SUM(hd.TienThanhToan) AS DoanhThu
                                 FROM HoaDon hd
                                 WHERE hd.LoaiHoaDon = 1 AND hd.ThoiGianLap BETWEEN @TuNgay AND @DenNgay
                                 GROUP BY CAST(hd.ThoiGianLap AS DATE)";
                        break;
                    case "tháng":
                        query = @"SELECT DATEADD(MONTH, DATEDIFF(MONTH, 0, hd.ThoiGianLap), 0) AS Thang, SUM(hd.TienThanhToan) AS DoanhThu
                                 FROM HoaDon hd
                                 WHERE hd.LoaiHoaDon = 1 AND hd.ThoiGianLap BETWEEN @TuNgay AND @DenNgay
                                 GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, hd.ThoiGianLap), 0)";
                        break;
                    case "năm":
                        query = @"SELECT DATEADD(YEAR, DATEDIFF(YEAR, 0, hd.ThoiGianLap), 0) AS Nam, SUM(hd.TienThanhToan) AS DoanhThu
                                 FROM HoaDon hd
                                 WHERE hd.LoaiHoaDon = 1 AND hd.ThoiGianLap BETWEEN @TuNgay AND @DenNgay
                                 GROUP BY DATEADD(YEAR, DATEDIFF(YEAR, 0, hd.ThoiGianLap), 0)";
                        break;
                    default:
                        throw new ArgumentException("Loại thời gian không hợp lệ. Chỉ hỗ trợ 'Ngày', 'Tháng', 'Năm'.");
                }

                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime thoiGian = reader.GetDateTime(0);
                        decimal doanhThu = reader.GetDecimal(reader.GetOrdinal("DoanhThu"));
                        doanhThuTheoThoiGian.Add(thoiGian, doanhThu);
                    }
                    reader.Close();
                }

                // Điền các khoảng thời gian bị thiếu bằng 0 và sắp xếp theo thời gian
                var sortedDoanhThu = new Dictionary<DateTime, decimal>();
                if (loaiThoiGian.ToLower() == "ngày")
                {
                    for (DateTime date = tuNgay.Date; date <= denNgay.Date; date = date.AddDays(1))
                    {
                        sortedDoanhThu.Add(date, doanhThuTheoThoiGian.ContainsKey(date) ? doanhThuTheoThoiGian[date] : 0);
                    }
                }
                else if (loaiThoiGian.ToLower() == "tháng")
                {
                    DateTime startMonth = new DateTime(tuNgay.Year, tuNgay.Month, 1);
                    DateTime endMonth = new DateTime(denNgay.Year, denNgay.Month, 1);
                    for (DateTime date = startMonth; date <= endMonth; date = date.AddMonths(1))
                    {
                        sortedDoanhThu.Add(date, doanhThuTheoThoiGian.ContainsKey(date) ? doanhThuTheoThoiGian[date] : 0);
                    }
                    // Đảm bảo hiển thị ít nhất 1 tháng nếu tuNgay và denNgay thuộc cùng tháng
                    if (sortedDoanhThu.Count == 0)
                    {
                        sortedDoanhThu.Add(startMonth, 0);
                    }
                }
                else if (loaiThoiGian.ToLower() == "năm")
                {
                    DateTime startYear = new DateTime(tuNgay.Year, 1, 1);
                    DateTime endYear = new DateTime(denNgay.Year, 1, 1);
                    for (DateTime date = startYear; date <= endYear; date = date.AddYears(1))
                    {
                        sortedDoanhThu.Add(date, doanhThuTheoThoiGian.ContainsKey(date) ? doanhThuTheoThoiGian[date] : 0);
                    }
                    // Đảm bảo hiển thị ít nhất 1 năm nếu tuNgay và denNgay thuộc cùng năm
                    if (sortedDoanhThu.Count == 0)
                    {
                        sortedDoanhThu.Add(startYear, 0);
                    }
                }

                return sortedDoanhThu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính doanh thu theo thời gian: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<DateTime, decimal>();
            }
            finally
            {
                myDatabase.CloseConnection();
            }
        }
    }
}

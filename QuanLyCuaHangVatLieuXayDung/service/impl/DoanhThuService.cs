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
        public int TinhTongHoaDonNhap(DateTime tuNgay, DateTime denNgay)
        {
            int tongHoaDonNhap = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COUNT(*) AS TongHoaDonNhap
                                FROM HoaDon
                                WHERE LoaiHoaDon = 2 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tongHoaDonNhap = reader.GetInt32(reader.GetOrdinal("TongHoaDonNhap"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return tongHoaDonNhap;
        }

        public int TinhTongHoaDonXuat(DateTime tuNgay, DateTime denNgay)
        {
            int tongHoaDonXuat = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COUNT(*) AS TongHoaDonXuat
                                FROM HoaDon
                                WHERE LoaiHoaDon = 1 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tongHoaDonXuat = reader.GetInt32(reader.GetOrdinal("TongHoaDonXuat"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng hóa đơn xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return tongHoaDonXuat;
        }

        public int TinhSoBienLaiTraNo(DateTime tuNgay, DateTime denNgay)
        {
            int soBienLaiTraNo = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COUNT(*) AS SoBienLaiTraNo
                                FROM PhieuGhiNo
                                WHERE TrangThai = 1 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        soBienLaiTraNo = reader.GetInt32(reader.GetOrdinal("SoBienLaiTraNo"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính số biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return soBienLaiTraNo;
        }

        public int TinhSoNoChuaTra(DateTime tuNgay, DateTime denNgay)
        {
            int soNoChuaTra = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COUNT(*) AS SoNoChuaTra
                                FROM PhieuGhiNo
                                WHERE TrangThai = 0 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        soNoChuaTra = reader.GetInt32(reader.GetOrdinal("SoNoChuaTra"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính số nợ chưa trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return soNoChuaTra;
        }

        public decimal TinhTongGiaTriHoaDonNhap(DateTime tuNgay, DateTime denNgay)
        {
            decimal tongGiaTriHoaDonNhap = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COALESCE(SUM(TienThanhToan), 0) AS TongGiaTriHoaDonNhap
                                FROM HoaDon
                                WHERE LoaiHoaDon = 2 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tongGiaTriHoaDonNhap = reader.GetDecimal(reader.GetOrdinal("TongGiaTriHoaDonNhap"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng giá trị hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return tongGiaTriHoaDonNhap;
        }

        public decimal TinhTongGiaTriHoaDonXuat(DateTime tuNgay, DateTime denNgay)
        {
            decimal tongGiaTriHoaDonXuat = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COALESCE(SUM(TienThanhToan), 0) AS TongGiaTriHoaDonXuat
                                FROM HoaDon
                                WHERE LoaiHoaDon = 1 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tongGiaTriHoaDonXuat = reader.GetDecimal(reader.GetOrdinal("TongGiaTriHoaDonXuat"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng giá trị hóa đơn xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return tongGiaTriHoaDonXuat;
        }

        public decimal TinhTongGiaTriNoChuaTra(DateTime tuNgay, DateTime denNgay)
        {
            decimal tongGiaTriNoChuaTra = 0;
            try
            {
                myDatabase.OpenConnection();
                string query = @"SELECT COALESCE(SUM(TienNo), 0) AS TongGiaTriNoChuaTra
                                FROM PhieuGhiNo
                                WHERE TrangThai = 0 AND ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tongGiaTriNoChuaTra = reader.GetDecimal(reader.GetOrdinal("TongGiaTriNoChuaTra"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng giá trị nợ chưa trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return tongGiaTriNoChuaTra;
        }

        public int TinhSoDonTraHang(DateTime tuNgay, DateTime denNgay)
        {
            int soDonTraHang = 0;
            try
            {
                myDatabase.OpenConnection();
                // Giả định rằng đơn trả hàng được lưu trong bảng PhieuTraHang
                string query = @"SELECT COUNT(*) AS SoDonTraHang
                                FROM PhieuTraHang
                                WHERE ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        soDonTraHang = reader.GetInt32(reader.GetOrdinal("SoDonTraHang"));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính số đơn trả hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return soDonTraHang;
        }
        public Dictionary<DateTime, decimal> TinhDoanhThuNhapTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay, string loaiThoiGian)
        {
            var doanhThuNhapTheoThoiGian = new Dictionary<DateTime, decimal>();
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
                                 WHERE hd.LoaiHoaDon = 2 AND hd.ThoiGianLap BETWEEN @TuNgay AND @DenNgay
                                 GROUP BY CAST(hd.ThoiGianLap AS DATE)";
                        break;
                    case "tháng":
                        DateTime startOfMonth = new DateTime(tuNgay.Year, tuNgay.Month, 1);
                        DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);
                        query = @"SELECT DATEADD(MONTH, DATEDIFF(MONTH, 0, hd.ThoiGianLap), 0) AS Thang, SUM(hd.TienThanhToan) AS DoanhThu
                                 FROM HoaDon hd
                                 WHERE hd.LoaiHoaDon = 2 AND hd.ThoiGianLap BETWEEN @TuNgay AND @DenNgay
                                 GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, hd.ThoiGianLap), 0)";
                        break;
                    case "năm":
                        query = @"SELECT DATEADD(YEAR, DATEDIFF(YEAR, 0, hd.ThoiGianLap), 0) AS Nam, SUM(hd.TienThanhToan) AS DoanhThu
                                 FROM HoaDon hd
                                 WHERE hd.LoaiHoaDon = 2 AND hd.ThoiGianLap BETWEEN @TuNgay AND @DenNgay
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
                        doanhThuNhapTheoThoiGian.Add(thoiGian, doanhThu);
                    }
                    reader.Close();
                }

                // Điền các khoảng thời gian bị thiếu bằng 0 và sắp xếp theo thời gian
                var sortedDoanhThuNhap = new Dictionary<DateTime, decimal>();
                if (loaiThoiGian.ToLower() == "ngày")
                {
                    for (DateTime date = tuNgay.Date; date <= denNgay.Date; date = date.AddDays(1))
                    {
                        sortedDoanhThuNhap.Add(date, doanhThuNhapTheoThoiGian.ContainsKey(date) ? doanhThuNhapTheoThoiGian[date] : 0);
                    }
                }
                else if (loaiThoiGian.ToLower() == "tháng")
                {
                    DateTime startMonth = new DateTime(tuNgay.Year, tuNgay.Month, 1);
                    sortedDoanhThuNhap.Add(startMonth, doanhThuNhapTheoThoiGian.ContainsKey(startMonth) ? doanhThuNhapTheoThoiGian[startMonth] : 0);
                }
                else if (loaiThoiGian.ToLower() == "năm")
                {
                    DateTime startYear = new DateTime(tuNgay.Year, 1, 1);
                    DateTime endYear = new DateTime(denNgay.Year, 1, 1);
                    for (DateTime date = startYear; date <= endYear; date = date.AddYears(1))
                    {
                        sortedDoanhThuNhap.Add(date, doanhThuNhapTheoThoiGian.ContainsKey(date) ? doanhThuNhapTheoThoiGian[date] : 0);
                    }
                    if (sortedDoanhThuNhap.Count == 0)
                    {
                        sortedDoanhThuNhap.Add(startYear, 0);
                    }
                }

                return sortedDoanhThuNhap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính doanh thu nhập theo thời gian: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<DateTime, decimal>();
            }
            finally
            {
                myDatabase.CloseConnection();
            }
        }

        public decimal TinhTongTienTraNo(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"SELECT SUM(TienTra) 
                            FROM BienLaiTraNo 
                            WHERE ThoiGianTra BETWEEN @NgayBatDau AND @NgayKetThuc";
            decimal tongTienTraNo = 0;
            try
            {
                myDatabase.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@NgayBatDau", tuNgay);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", denNgay);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tongTienTraNo = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return tongTienTraNo;
        }
    }
}

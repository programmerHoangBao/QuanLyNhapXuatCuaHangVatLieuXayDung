using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class ChamCongService : IChamCongService
    {
        private MyDatabase myDatabase = new MyDatabase();

        public bool ChamCong(string maNV)
        {
            SqlTransaction transaction = null;
            bool result = false;

            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();

                SqlCommand command = new SqlCommand(
                    @"INSERT INTO BangChamCong (MaNhanVien, TenNhanVien, SoDienThoai, DiaChi, Email, LuongTrenNgay, ThoiGianChamCong)
                      SELECT MaNhanVien, Ten, SoDienThoai, DiaChi, Email, LuongTrenNgay, @ThoiGian
                      FROM NhanVien
                      WHERE MaNhanVien = @MaNV",
                    this.myDatabase.Connection, transaction);

                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@ThoiGian", DateTime.Now);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    transaction.Commit();
                    result = true;
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi chấm công: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return result;
        }

        public double TinhTongLuong(string maNV)
        {
            int soNgayCong = GetSoNgayCong(maNV);
            double luongTrenNgay = LayLuongTrenNgay(maNV);
            return soNgayCong * luongTrenNgay;
        }

        public double TinhLuongTheoThang(string maNV, int thang, int nam)
        {
            double result = 0;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    @"SELECT COUNT(*) FROM BangChamCong 
                      WHERE MaNhanVien = @MaNV 
                        AND MONTH(ThoiGianChamCong) = @Thang 
                        AND YEAR(ThoiGianChamCong) = @Nam",
                    this.myDatabase.Connection);

                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@Thang", thang);
                command.Parameters.AddWithValue("@Nam", nam);

                int soNgayCong = (int)command.ExecuteScalar();
                double luongTrenNgay = LayLuongTrenNgay(maNV);
                result = soNgayCong * luongTrenNgay;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính lương tháng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return result;
        }

        public double TinhLuongTheoNam(string maNV, int nam)
        {
            double result = 0;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    @"SELECT COUNT(*) FROM BangChamCong 
                      WHERE MaNhanVien = @MaNV 
                        AND YEAR(ThoiGianChamCong) = @Nam",
                    this.myDatabase.Connection);

                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@Nam", nam);

                int soNgayCong = (int)command.ExecuteScalar();
                double luongTrenNgay = LayLuongTrenNgay(maNV);
                result = soNgayCong * luongTrenNgay;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính lương năm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return result;
        }

        public int GetSoNgayCong(string maNV)
        {
            int result = 0;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM BangChamCong WHERE MaNhanVien = @MaNV",
                    this.myDatabase.Connection);

                command.Parameters.AddWithValue("@MaNV", maNV);
                result = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy số ngày công: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return result;
        }

        public double LayLuongTrenNgay(string maNV)
        {
            double result = 0;

            try
            {
                SqlCommand command = new SqlCommand(
                    "SELECT LuongTrenNgay FROM NhanVien WHERE MaNhanVien = @MaNV",
                    this.myDatabase.Connection);

                command.Parameters.AddWithValue("@MaNV", maNV);
                object value = command.ExecuteScalar();
                result = value != null ? Convert.ToDouble(value) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy lương trên ngày: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            return result;
        }

        public int TinhSoNgayNghi(string maNV, int thang, int nam)
        {
            int ngayDiLam = 0;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT COUNT(*) 
              FROM BangChamCong 
              WHERE MaNhanVien = @ma 
                AND MONTH(ThoiGianChamCong) = @thang 
                AND YEAR(ThoiGianChamCong) = @nam
                AND DAY(ThoiGianChamCong) <= @homNay",
                    myDatabase.Connection);

                cmd.Parameters.AddWithValue("@ma", maNV);
                cmd.Parameters.AddWithValue("@thang", thang);
                cmd.Parameters.AddWithValue("@nam", nam);
                cmd.Parameters.AddWithValue("@homNay", DateTime.Now.Day); // Giới hạn tới ngày hiện tại

                ngayDiLam = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính ngày nghỉ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            // Tổng số ngày từ đầu tháng đến hôm nay
            int ngayHienTai = DateTime.Now.Day;

            int ngayNghi = ngayHienTai - ngayDiLam;
            return Math.Max(ngayNghi, 0);
        }


        public bool DaChamCongHomNay(string maNhanVien)
        {
            bool result = false;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    @"SELECT COUNT(*) FROM BangChamCong 
                      WHERE MaNhanVien = @MaNV 
                      AND CONVERT(date, ThoiGianChamCong) = CONVERT(date, SYSDATETIME())",
                    this.myDatabase.Connection);


                command.Parameters.AddWithValue("@MaNV", maNhanVien);

                int count = (int)command.ExecuteScalar();
                result = count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra chấm công hôm nay: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return result;
        }

        public bool XoaChamCongHomNay(string maNhanVien)
        {
            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    @"DELETE FROM BangChamCong 
              WHERE MaNhanVien = @MaNV 
              AND CAST(ThoiGianChamCong AS DATE) = CAST(GETDATE() AS DATE)",
                    this.myDatabase.Connection);

                command.Parameters.AddWithValue("@MaNV", maNhanVien);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chấm công: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
        }



    }
}

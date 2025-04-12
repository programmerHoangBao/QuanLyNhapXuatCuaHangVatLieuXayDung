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
                    "INSERT INTO BANG_CHAM_CONG (MaNV, ThoiGianChamCong) VALUES (@MaNV, @ThoiGian)",
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
                    "SELECT COUNT(*) FROM BANG_CHAM_CONG WHERE MaNV = @MaNV AND MONTH(ThoiGianChamCong) = @Thang AND YEAR(ThoiGianChamCong) = @Nam",
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
                    "SELECT COUNT(*) FROM BANG_CHAM_CONG WHERE MaNV = @MaNV AND YEAR(ThoiGianChamCong) = @Nam",
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

        private int GetSoNgayCong(string maNV)
        {
            int result = 0;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM BANG_CHAM_CONG WHERE MaNV = @MaNV",
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

        private double LayLuongTrenNgay(string maNV)
        {
            double result = 0;

            try
            {
                this.myDatabase.OpenConnection();

                SqlCommand command = new SqlCommand(
                    "SELECT LuongTrenNgay FROM NHAN_VIEN WHERE MaNV = @MaNV",
                    this.myDatabase.Connection);

                command.Parameters.AddWithValue("@MaNV", maNV);
                object value = command.ExecuteScalar();
                result = value != null ? Convert.ToDouble(value) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy lương trên ngày: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return result;
        }
    }
}

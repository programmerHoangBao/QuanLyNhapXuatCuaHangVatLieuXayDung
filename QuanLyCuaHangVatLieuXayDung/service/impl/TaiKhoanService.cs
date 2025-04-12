using QuanLyCuaHangVatLieuXayDung.config;
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
    internal class TaiKhoanService : ITaiKhoanService
    {
        private MyDatabase myDatabase = new MyDatabase();
        public bool DeleteTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            bool result = false;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", taiKhoan.MaTaiKhoan);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    if (new FileUtility().DeleteFile(taiKhoan.QR))
                    {
                        result = true;
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to delete the QR code image.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return result;
        }

        public List<TaiKhoan> findAllTaiKhoan()
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            string query = "SELECT * FROM TaiKhoan";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                TaiKhoan tk;
                while (reader.Read())
                {
                    tk = new TaiKhoan();
                    tk.MaTaiKhoan = reader["MaTaiKhoan"].ToString();
                    tk.TenDangNhap = reader["TenDangNhap"].ToString();
                    tk.MatKhau = reader["MatKhau"].ToString();
                    tk.TenCuaHang = reader["TenCuaHang"].ToString();
                    tk.SoDienThoai = reader["SoDienThoai"].ToString();
                    tk.DiaChi = reader["DiaChi"].ToString();
                    tk.Email = reader["Email"].ToString();
                    tk.NganHang = reader["NganHang"].ToString();
                    tk.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    tk.QR = reader["QR"].ToString();
                    taiKhoans.Add(tk);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return taiKhoans;
        }

        public TaiKhoan findByMaTaiKhoan(string maTaiKhoan)
        {
            TaiKhoan taiKhoan = null;
            string query = "SELECT * FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoan();
                    taiKhoan.MaTaiKhoan = reader["MaTaiKhoan"].ToString();
                    taiKhoan.TenDangNhap = reader["TenDangNhap"].ToString();
                    taiKhoan.MatKhau = reader["MatKhau"].ToString();
                    taiKhoan.TenCuaHang = reader["TenCuaHang"].ToString();
                    taiKhoan.SoDienThoai = reader["SoDienThoai"].ToString();
                    taiKhoan.DiaChi = reader["DiaChi"].ToString();
                    taiKhoan.Email = reader["Email"].ToString();
                    taiKhoan.NganHang = reader["NganHang"].ToString();
                    taiKhoan.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    taiKhoan.QR = reader["QR"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return taiKhoan;
        }

        public bool insertTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = @"INSERT INTO TaiKhoan 
                      (MaTaiKhoan, TenDangNhap, MatKhau, TenCuaHang, SoDienThoai, DiaChi, Email, NganHang, SoTaiKhoan, QR)
                      VALUES 
                      (@MaTaiKhoan, @TenDangNhap, @MatKhau, @TenCuaHang, @SoDienThoai, @DiaChi, @Email, @NganHang, @SoTaiKhoan, @QR)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", taiKhoan.MaTaiKhoan);
                cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                cmd.Parameters.AddWithValue("@TenCuaHang", taiKhoan.TenCuaHang);
                cmd.Parameters.AddWithValue("@SoDienThoai", taiKhoan.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", taiKhoan.DiaChi);
                cmd.Parameters.AddWithValue("@Email", taiKhoan.Email);
                cmd.Parameters.AddWithValue("@NganHang", taiKhoan.NganHang);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", taiKhoan.SoTaiKhoan);
                cmd.Parameters.AddWithValue("@QR", taiKhoan.QR);
                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }

        public TaiKhoan login(string username, string password)
        {
            string query = @"SELECT * FROM TaiKhoan 
                      WHERE TenDangNhap = @username AND MatKhau = @password";
            TaiKhoan taiKhoan = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // Có thể mã hóa password ở đây nếu cần

                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoan();
                    taiKhoan.MaTaiKhoan = reader["MaTaiKhoan"].ToString();
                    taiKhoan.TenDangNhap = reader["TenDangNhap"].ToString();
                    taiKhoan.MatKhau = reader["MatKhau"].ToString();
                    taiKhoan.TenCuaHang = reader["TenCuaHang"].ToString();
                    taiKhoan.SoDienThoai = reader["SoDienThoai"].ToString();
                    taiKhoan.DiaChi = reader["DiaChi"].ToString();
                    taiKhoan.Email = reader["Email"].ToString();
                    taiKhoan.NganHang = reader["NganHang"].ToString();
                    taiKhoan.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    taiKhoan.QR = reader["QR"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }

            return taiKhoan;
        }

        public List<TaiKhoan> searchByKey(string key)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            string query = @"SELECT * FROM TaiKhoan 
                      WHERE MaTaiKhoan LIKE @key 
                         OR TenDangNhap LIKE @key 
                         OR SoDienThoai LIKE @key";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                TaiKhoan taiKhoan;
                while (reader.Read())
                {
                    taiKhoan = new TaiKhoan();
                    taiKhoan.MaTaiKhoan = reader["MaTaiKhoan"].ToString();
                    taiKhoan.TenDangNhap = reader["TenDangNhap"].ToString();
                    taiKhoan.MatKhau = reader["MatKhau"].ToString();
                    taiKhoan.TenCuaHang = reader["TenCuaHang"].ToString();
                    taiKhoan.SoDienThoai = reader["SoDienThoai"].ToString();
                    taiKhoan.DiaChi = reader["DiaChi"].ToString();
                    taiKhoan.Email = reader["Email"].ToString();
                    taiKhoan.NganHang = reader["NganHang"].ToString();
                    taiKhoan.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    taiKhoan.QR = reader["QR"].ToString();
                    taiKhoans.Add(taiKhoan);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return taiKhoans;
        }

        public bool updateTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = @"UPDATE TaiKhoan
                      SET TenDangNhap = @TenDangNhap,
                          MatKhau = @MatKhau,
                          TenCuaHang = @TenCuaHang,
                          SoDienThoai = @SoDienThoai,
                          DiaChi = @DiaChi,
                          Email = @Email,
                          NganHang = @NganHang,
                          SoTaiKhoan = @SoTaiKhoan,
                          QR = @QR
                      WHERE MaTaiKhoan = @MaTaiKhoan";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", taiKhoan.MaTaiKhoan);
                cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                cmd.Parameters.AddWithValue("@TenCuaHang", taiKhoan.TenCuaHang);
                cmd.Parameters.AddWithValue("@SoDienThoai", taiKhoan.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", taiKhoan.DiaChi);
                cmd.Parameters.AddWithValue("@Email", taiKhoan.Email);
                cmd.Parameters.AddWithValue("@NganHang", taiKhoan.NganHang);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", taiKhoan.SoTaiKhoan);
                cmd.Parameters.AddWithValue("@QR", taiKhoan.QR);
                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }
    }
}

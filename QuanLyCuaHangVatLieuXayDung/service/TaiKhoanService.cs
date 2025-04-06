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

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal class TaiKhoanService
    {
        private MyDatabase myDatabase = new MyDatabase();
        public List<TaiKhoan> findAllTaiKhoan()
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            string query = "SELECT * FROM TaiKhoan";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TaiKhoan tk = new TaiKhoan();
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
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                while (reader.Read())
                {
                    TaiKhoan taiKhoan = new TaiKhoan();
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
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return taiKhoans;
        }
        public bool insertTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = @"INSERT INTO TaiKhoan 
                     (MaTaiKhoan, TenDangNhap, MatKhau, TenCuaHang, SoDienThoai, DiaChi, Email, NganHang, SoTaiKhoan, QR)
                     VALUES 
                     (@MaTaiKhoan, @TenDangNhap, @MatKhau, @TenCuaHang, @SoDienThoai, @DiaChi, @Email, @NganHang, @SoTaiKhoan, @QR)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
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

                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();

                if (result > 0)
                {
                    string directory = new FormApp().TAIKHOAN_DATA;
                    new FileUntility().SaveImages(taiKhoan.QR, directory);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
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

                this.myDatabase.OpenConnection();

                // Lưu QR mới sau khi xóa cái cũ
                string directory = new FormApp().TAIKHOAN_DATA;
                string oldQR = this.findByMaTaiKhoan(taiKhoan.MaTaiKhoan)?.QR;
                if (oldQR != null) new FileUntility().DeleteFile(oldQR);

                int result = cmd.ExecuteNonQuery();

                this.myDatabase.CloseConnection();

                if (result > 0)
                {
                    new FileUntility().SaveImages(taiKhoan.QR, directory);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public bool deleteTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", taiKhoan.MaTaiKhoan);

                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();

                if (result > 0)
                {
                    // Xoá hình ảnh QR nếu có
                    new FileUntility().DeleteFile(taiKhoan.QR);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return taiKhoan;
        }









    }
}

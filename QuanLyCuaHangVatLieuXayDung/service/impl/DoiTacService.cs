using QuanLyCuaHangVatLieuXayDung.utilities;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangVatLieuXayDung.config;
using System.Diagnostics.Eventing.Reader;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class DoiTacService : IDoiTacService
    {
        private MyDatabase myDatabase = new MyDatabase();
        public bool deleteDoiTac(DoiTac doiTac)
        {
            string query = "DELETE FROM DoiTac WHERE MaDoiTac = @MaDoiTac";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            bool result = false;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaDoiTac", doiTac.MaDoiTac);
                affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    result = true;
                    if (!string.IsNullOrEmpty(doiTac.QR))
                    {
                        if (new FileUtility().DeleteFile(doiTac.QR))
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Failed to delete the file.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        transaction.Commit();
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

        public List<KhachHang> findAllKhachHang()
        {
            string query = @"SELECT * FROM DoiTac WHERE LoaiDoiTac = 1";
            List<KhachHang> khachHangs = new List<KhachHang>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                KhachHang khachHang;
                while (reader.Read())
                {
                    khachHang = new KhachHang();
                    khachHang.MaDoiTac = reader["MaDoiTac"].ToString();
                    khachHang.Ten = reader["Ten"].ToString();
                    khachHang.SoDienThoai = reader["SoDienThoai"].ToString();
                    khachHang.DiaChi = reader["DiaChi"].ToString();
                    khachHang.Email = reader["Email"].ToString();
                    khachHang.NganHang = reader["NganHang"].ToString();
                    khachHang.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    khachHang.QR = reader["QR"].ToString();
                    khachHangs.Add(khachHang);
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
            return khachHangs;
        }

        public DoiTac findByMaDoiTac(string maDoiTac)
        {
            if (string.IsNullOrEmpty(maDoiTac))
            {
                return null;
            }
            string query = @"SELECT * FROM DoiTac WHERE MaDoiTac = @MaDoiTac";
            DoiTac doiTac = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["LoaiDoiTac"].ToString() == "1")
                    {
                        doiTac = new KhachHang();
                    }
                    else
                    {
                        doiTac = new NhaCungCap();
                    }
                    doiTac.MaDoiTac = reader["MaDoiTac"].ToString();
                    doiTac.Ten = reader["Ten"].ToString();
                    doiTac.SoDienThoai = reader["SoDienThoai"].ToString();
                    doiTac.DiaChi = reader["DiaChi"].ToString();
                    doiTac.Email = reader["Email"].ToString();
                    doiTac.NganHang = reader["NganHang"].ToString();
                    doiTac.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    doiTac.QR = reader["QR"].ToString();
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
            return doiTac;
        }

        public List<NhaCungCap> findAllNhaCungCap()
        {
            string query = @"SELECT * FROM DoiTac WHERE LoaiDoiTac = 2";
            List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                NhaCungCap nhaCungCap;
                while (reader.Read()) 
                {
                    nhaCungCap = new NhaCungCap();
                    nhaCungCap.MaDoiTac = reader["MaDoiTac"].ToString();
                    nhaCungCap.Ten = reader["Ten"].ToString();
                    nhaCungCap.SoDienThoai = reader["SoDienThoai"].ToString();
                    nhaCungCap.DiaChi = reader["DiaChi"].ToString();
                    nhaCungCap.Email = reader["Email"].ToString();
                    nhaCungCap.NganHang = reader["NganHang"].ToString();
                    nhaCungCap.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    nhaCungCap.QR = reader["QR"].ToString();
                    nhaCungCaps.Add(nhaCungCap);
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
            return nhaCungCaps;
        }

        public bool insertDoiTac(DoiTac doiTac)
        {
            string query = @"INSERT INTO DoiTac 
                               (MaDoiTac, Ten, SoDienThoai, DiaChi, Email, LoaiDoiTac, NganHang, SoTaiKhoan, QR)
                               VALUES (@MaDoiTac, @Ten, @SoDienThoai, @DiaChi, @Email, @LoaiDoiTac, @NganHang, @SoTaiKhoan, @QR)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaDoiTac", doiTac.MaDoiTac);
                cmd.Parameters.AddWithValue("@Ten", doiTac.Ten);
                cmd.Parameters.AddWithValue("@SoDienThoai", doiTac.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", doiTac.DiaChi);
                cmd.Parameters.AddWithValue("@Email", (object)doiTac.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoaiDoiTac", doiTac.loaiDoiTac_toByte());
                cmd.Parameters.AddWithValue("@NganHang", (object)doiTac.NganHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", (object)doiTac.SoTaiKhoan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@QR", (object)doiTac.QR ?? DBNull.Value);
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

        public List<DoiTac> searchByKey(string key)
        {
            string query = @"SELECT *
                                FROM DoiTac
                                WHERE MaDoiTac LIKE @key
                                                OR Ten LIKE @key
                                                OR SoDienThoai LIKE @key";
            List<DoiTac> doiTacs = new List<DoiTac>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                DoiTac doiTac;
                while (reader.Read())
                {
                    if (reader["LoaiDoiTac"].ToString() == "1")
                    {
                        doiTac = new KhachHang();
                    }
                    else
                    {
                        doiTac = new NhaCungCap();
                    }
                    doiTac.MaDoiTac = reader["MaDoiTac"].ToString();
                    doiTac.Ten = reader["Ten"].ToString();
                    doiTac.SoDienThoai = reader["SoDienThoai"].ToString();
                    doiTac.DiaChi = reader["DiaChi"].ToString();
                    doiTac.Email = reader["Email"].ToString();
                    doiTac.NganHang = reader["NganHang"].ToString();
                    doiTac.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    doiTac.QR = reader["QR"].ToString();
                    doiTacs.Add(doiTac);
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
            return doiTacs;
        }

        public bool updateDoiTac(DoiTac doiTac)
        {
            string query = @"UPDATE DoiTac
                                SET Ten = @Ten,
                                    SoDienThoai = @SoDienThoai,
                                    DiaChi = @DiaChi,
                                    Email = @Email,
                                    NganHang = @NganHang,
                                    SoTaiKhoan = @SoTaiKhoan,
                                    LoaiDoiTac = @LoaiDoiTac,
                                    QR = @QR
                                WHERE MaDoiTac = @MaDoiTac";
            SqlTransaction transaction = null;
            int affectedRows = 0;   
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaDoiTac", doiTac.MaDoiTac);
                cmd.Parameters.AddWithValue("@Ten", doiTac.Ten);
                cmd.Parameters.AddWithValue("@SoDienThoai", doiTac.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", doiTac.DiaChi);
                cmd.Parameters.AddWithValue("@Email", (object)doiTac.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoaiDoiTac", doiTac.loaiDoiTac_toByte());
                cmd.Parameters.AddWithValue("@NganHang", (object)doiTac.NganHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", (object)doiTac.SoTaiKhoan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@QR", (object)doiTac.QR ?? DBNull.Value);
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

        public List<KhachHang> searchKhachHangByKey(string key)
        {
            string query = @"SELECT *
                                FROM DoiTac
                                WHERE LoaiDoiTac = 1 
                                                AND (MaDoiTac LIKE @key
                                                    OR Ten LIKE @key
                                                    OR SoDienThoai LIKE @key)";
            List<KhachHang> khachHangs = new List<KhachHang>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                KhachHang khachHang;
                while (reader.Read())
                {
                    khachHang = new KhachHang();
                    khachHang.MaDoiTac = reader["MaDoiTac"].ToString();
                    khachHang.Ten = reader["Ten"].ToString();
                    khachHang.SoDienThoai = reader["SoDienThoai"].ToString();
                    khachHang.DiaChi = reader["DiaChi"].ToString();
                    khachHang.Email = reader["Email"].ToString();
                    khachHang.NganHang = reader["NganHang"].ToString();
                    khachHang.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    khachHang.QR = reader["QR"].ToString();
                    khachHangs.Add(khachHang);
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
            return khachHangs;
        }

        public List<NhaCungCap> searchNhaCungCapByKey(string key)
        {
            string query = @"SELECT *
                                FROM DoiTac
                                WHERE LoaiDoiTac = 2
                                                AND (MaDoiTac LIKE @key
                                                    OR Ten LIKE @key
                                                    OR SoDienThoai LIKE @key)";
            List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                NhaCungCap nhaCungCap;
                while (reader.Read())
                {
                    nhaCungCap = new NhaCungCap();
                    nhaCungCap.MaDoiTac = reader["MaDoiTac"].ToString();
                    nhaCungCap.Ten = reader["Ten"].ToString();
                    nhaCungCap.SoDienThoai = reader["SoDienThoai"].ToString();
                    nhaCungCap.DiaChi = reader["DiaChi"].ToString();
                    nhaCungCap.Email = reader["Email"].ToString();
                    nhaCungCap.NganHang = reader["NganHang"].ToString();
                    nhaCungCap.SoTaiKhoan = reader["SoTaiKhoan"].ToString();
                    nhaCungCap.QR = reader["QR"].ToString();
                    nhaCungCaps.Add(nhaCungCap);
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
            return nhaCungCaps;
        }
    }
}

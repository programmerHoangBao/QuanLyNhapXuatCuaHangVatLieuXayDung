using QuanLyCuaHangVatLieuXayDung.config;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal class DoiTacService : IDoiTacService
    {
        private MyDatabase myDatabase = new MyDatabase();
        public bool deleteDoiTac(DoiTac doiTac)
        {
            string query = "DELETE FROM DoiTac WHERE MaDoiTac = @MaDoiTac";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", doiTac.MaDoiTac);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return khachHangs;
        }

        public DoiTac findByMaDoiTac(string maDoiTac)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return doiTac;
        }

        public List<NhaCungCap> findNhaCungCap()
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
                }
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nhaCungCaps;
        }

        public bool insertDoiTac(DoiTac doiTac)
        {
            string query = @"INSERT INTO DoiTac 
                               (MaDoiTac, Ten, SoDienThoai, DiaChi, Email, LoaiDoiTac, NganHang, SoTaiKhoan, QR)
                               VALUES (@MaDoiTac, @Ten, @SoDienThoai, @DiaChi, @Email, @LoaiDoiTac, @NganHang, @SoTaiKhoan, @QR)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", doiTac.MaDoiTac);
                cmd.Parameters.AddWithValue("@Ten", doiTac.Ten);
                cmd.Parameters.AddWithValue("@SoDienThoai", doiTac.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", doiTac.DiaChi);
                cmd.Parameters.AddWithValue("@Email", doiTac.Email);
                cmd.Parameters.AddWithValue("@LoaiDoiTac", doiTac.loaiDoiTac_toByte());
                cmd.Parameters.AddWithValue("@NganHang", doiTac.NganHang);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", doiTac.SoTaiKhoan);
                cmd.Parameters.AddWithValue("@QR", doiTac.QR);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public List<DoiTac> searchByKey(string key)
        {
            string query = @"SELECT *
                                FROM DoiTac
                                WHERE MaDoiTac LIKE @key
                                                OR Ten @key
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", doiTac.MaDoiTac);
                cmd.Parameters.AddWithValue("@Ten", doiTac.Ten);
                cmd.Parameters.AddWithValue("@SoDienThoai", doiTac.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", doiTac.DiaChi);
                cmd.Parameters.AddWithValue("@Email", doiTac.Email);
                cmd.Parameters.AddWithValue("@LoaiDoiTac", doiTac.loaiDoiTac_toByte());
                cmd.Parameters.AddWithValue("@NganHang", doiTac.NganHang);
                cmd.Parameters.AddWithValue("@SoTaiKhoan", doiTac.SoTaiKhoan);
                cmd.Parameters.AddWithValue("@QR", doiTac.QR);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}

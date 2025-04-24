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
    internal class PhieuGhiNoService : IPhieuGhiNoService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IDoiTacService doiTacService = new DoiTacService();

        public List<PhieuGhiNo> findAll()
        {
            string query = "SELECT * FROM PhieuGhiNo";
            List<PhieuGhiNo> phieuGhiNos = new List<PhieuGhiNo>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuGhiNo phieu = null;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (reader["LoaiPhieu"].ToString() == "2")
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        // Gán thông tin đối tác và hóa đơn
                        string maDoiTac = reader["MaDoiTac"].ToString();
                        if (!string.IsNullOrEmpty(maDoiTac))
                        {
                            if (phieu is PhieuNoKhachHang khachHang)
                            {
                                khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                            }
                            else if (phieu is PhieuNoCuaHang cuaHang)
                            {
                                cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                            }
                        }

                        phieuGhiNos.Add(phieu);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuGhiNos;
        }

        public PhieuGhiNo findByMaPhieu(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                return null;
            }

            string query = "SELECT * FROM PhieuGhiNo WHERE MaPhieu = @MaPhieu";
            PhieuGhiNo phieu = null;
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (reader["LoaiPhieu"].ToString() == "2")
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        string maDoiTac = reader["MaDoiTac"].ToString();
                        if (!string.IsNullOrEmpty(maDoiTac))
                        {
                            if (phieu is PhieuNoKhachHang khachHang)
                            {
                                khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                            }
                            else if (phieu is PhieuNoCuaHang cuaHang)
                            {
                                cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                            }
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieu;
        }

        public bool insertPhieuGhiNo(PhieuGhiNo phieuGhiNo)
        {
            if (phieuGhiNo == null || string.IsNullOrEmpty(phieuGhiNo.MaPhieu))
            {
                MessageBox.Show("Dữ liệu phiếu ghi nợ không hợp lệ.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string query = @"INSERT INTO PhieuGhiNo (MaPhieu, MaDoiTac, MaHoaDon, ThoiGianLap, ThoiGianTra, 
                                                    TienNo, LoaiPhieu, TrangThai, TenDoiTac, SoDienThoai, DiaChi)
                            VALUES (@MaPhieu, @MaDoiTac, @MaHoaDon, @ThoiGianLap, @ThoiGianTra, 
                                    @TienNo, @LoaiPhieu, @TrangThai, @TenDoiTac, @SoDienThoai, @DiaChi)";
            SqlTransaction transaction = null;
            bool result = false;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);

                cmd.Parameters.AddWithValue("@MaPhieu", phieuGhiNo.MaPhieu);
                cmd.Parameters.AddWithValue("@ThoiGianLap", phieuGhiNo.ThoiGianLap);
                cmd.Parameters.AddWithValue("@ThoiGianTra", phieuGhiNo.ThoiGianTra);
                cmd.Parameters.AddWithValue("@TienNo", phieuGhiNo.TienNo);
                cmd.Parameters.AddWithValue("@TrangThai", phieuGhiNo.TrangThai);
                cmd.Parameters.AddWithValue("@LoaiPhieu", phieuGhiNo.loaiPhieu_toByte());

                if (phieuGhiNo is PhieuNoKhachHang khachHang && khachHang.KhachHang != null)
                {
                    cmd.Parameters.AddWithValue("@MaDoiTac", khachHang.KhachHang.MaDoiTac);
                    cmd.Parameters.AddWithValue("@TenDoiTac", khachHang.KhachHang.Ten);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.KhachHang.SoDienThoai);
                    cmd.Parameters.AddWithValue("@DiaChi", khachHang.KhachHang.DiaChi);
                    cmd.Parameters.AddWithValue("@MaHoaDon", khachHang.HoaDonXuat?.MaHoaDon ?? (object)DBNull.Value);
                }
                else if (phieuGhiNo is PhieuNoCuaHang cuaHang && cuaHang.NhaCungCap != null)
                {
                    cmd.Parameters.AddWithValue("@MaDoiTac", cuaHang.NhaCungCap.MaDoiTac);
                    cmd.Parameters.AddWithValue("@TenDoiTac", cuaHang.NhaCungCap.Ten);
                    cmd.Parameters.AddWithValue("@SoDienThoai", cuaHang.NhaCungCap.SoDienThoai);
                    cmd.Parameters.AddWithValue("@DiaChi", cuaHang.NhaCungCap.DiaChi);
                    cmd.Parameters.AddWithValue("@MaHoaDon", cuaHang.HoaDonNhap?.MaHoaDon ?? (object)DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaDoiTac", (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenDoiTac", string.Empty);
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.Empty);
                    cmd.Parameters.AddWithValue("@DiaChi", string.Empty);
                    cmd.Parameters.AddWithValue("@MaHoaDon", (object)DBNull.Value);
                }

                int affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
                result = affectedRows > 0;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return result;
        }

        public bool deletePhieuGhiNo(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                return false;
            }

            string query = "DELETE FROM PhieuGhiNo WHERE MaPhieu = @MaPhieu";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }

        public List<PhieuGhiNo> searchByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return new List<PhieuGhiNo>();
            }

            string query = @"SELECT * FROM PhieuGhiNo 
                           WHERE MaPhieu LIKE @Key OR TenDoiTac LIKE @Key OR SoDienThoai LIKE @Key";
            List<PhieuGhiNo> phieuGhiNos = new List<PhieuGhiNo>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@Key", "%" + key.Trim() + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuGhiNo phieu = null;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (reader["LoaiPhieu"].ToString() == "2")
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        string maDoiTac = reader["MaDoiTac"].ToString();
                        if (!string.IsNullOrEmpty(maDoiTac))
                        {
                            if (phieu is PhieuNoKhachHang khachHang)
                            {
                                khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                            }
                            else if (phieu is PhieuNoCuaHang cuaHang)
                            {
                                cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                            }
                        }

                        phieuGhiNos.Add(phieu);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuGhiNos;
        }

        public List<PhieuGhiNo> findByLoaiPhieu(byte loaiPhieu)
        {
            string query = "SELECT * FROM PhieuGhiNo WHERE LoaiPhieu = @LoaiPhieu";
            List<PhieuGhiNo> phieuGhiNos = new List<PhieuGhiNo>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@LoaiPhieu", loaiPhieu);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuGhiNo phieu = null;
                while (reader.Read())
                {
                    if (loaiPhieu == 1)
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (loaiPhieu == 2)
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        string maDoiTac = reader["MaDoiTac"].ToString();
                        if (!string.IsNullOrEmpty(maDoiTac))
                        {
                            if (phieu is PhieuNoKhachHang khachHang)
                            {
                                khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                            }
                            else if (phieu is PhieuNoCuaHang cuaHang)
                            {
                                cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                            }
                        }

                        phieuGhiNos.Add(phieu);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuGhiNos;
        }

        public List<PhieuGhiNo> findByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PhieuGhiNo>();
            }

            string query = "SELECT * FROM PhieuGhiNo WHERE ThoiGianLap BETWEEN @StartDate AND @EndDate";
            List<PhieuGhiNo> phieuGhiNos = new List<PhieuGhiNo>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuGhiNo phieu = null;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (reader["LoaiPhieu"].ToString() == "2")
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        string maDoiTac = reader["MaDoiTac"].ToString();
                        if (!string.IsNullOrEmpty(maDoiTac))
                        {
                            if (phieu is PhieuNoKhachHang khachHang)
                            {
                                khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                            }
                            else if (phieu is PhieuNoCuaHang cuaHang)
                            {
                                cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                            }
                        }

                        phieuGhiNos.Add(phieu);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuGhiNos;
        }

        public List<PhieuGhiNo> findByDoiTac(string maDoiTac)
        {
            if (string.IsNullOrWhiteSpace(maDoiTac))
            {
                return new List<PhieuGhiNo>();
            }

            string query = "SELECT * FROM PhieuGhiNo WHERE MaDoiTac = @MaDoiTac";
            List<PhieuGhiNo> phieuGhiNos = new List<PhieuGhiNo>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuGhiNo phieu = null;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (reader["LoaiPhieu"].ToString() == "2")
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        if (phieu is PhieuNoKhachHang khachHang)
                        {
                            khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                        }
                        else if (phieu is PhieuNoCuaHang cuaHang)
                        {
                            cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                        }

                        phieuGhiNos.Add(phieu);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuGhiNos;
        }

        public List<PhieuGhiNo> findByTrangThai(bool trangThai)
        {
            string query = "SELECT * FROM PhieuGhiNo WHERE TrangThai = @TrangThai";
            List<PhieuGhiNo> phieuGhiNos = new List<PhieuGhiNo>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuGhiNo phieu = null;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieu = new PhieuNoKhachHang();
                    }
                    else if (reader["LoaiPhieu"].ToString() == "2")
                    {
                        phieu = new PhieuNoCuaHang();
                    }

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString());
                        phieu.TienNo = double.Parse(reader["TienNo"].ToString());
                        phieu.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                        string maDoiTac = reader["MaDoiTac"].ToString();
                        if (!string.IsNullOrEmpty(maDoiTac))
                        {
                            if (phieu is PhieuNoKhachHang khachHang)
                            {
                                khachHang.KhachHang = this.doiTacService.findByMaDoiTac(maDoiTac) as KhachHang;
                            }
                            else if (phieu is PhieuNoCuaHang cuaHang)
                            {
                                cuaHang.NhaCungCap = this.doiTacService.findByMaDoiTac(maDoiTac) as NhaCungCap;
                            }
                        }

                        phieuGhiNos.Add(phieu);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuGhiNos;
        }

        public bool updateTrangThai(string maPhieu, bool trangThai)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                return false;
            }

            string query = "UPDATE PhieuGhiNo SET TrangThai = @TrangThai WHERE MaPhieu = @MaPhieu";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }
    }
}

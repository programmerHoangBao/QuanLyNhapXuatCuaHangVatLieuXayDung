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
    internal class PhieuTraHangService : IPhieuTraHangService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IChiTietService chiTietService = new ChiTietService();
        private IHoaDonService hoaDonService = new HoaDonService();
        public bool deletePhieuTraHang(string maPhieu)
        {
            string query = "DELETE FROM PhieuTraHang WHERE MaPhieu = @MaPhieu";
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

        public List<PhieuTraHang> findAll()
        {
            string query = "SELECT * FROM PhieuTraHang";
            List<PhieuTraHang> phieuTraHangs = new List<PhieuTraHang>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieuTraHang;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieuTraHang = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieuTraHang = new PhieuTraHangChoNhaCungCap();
                    }
                    phieuTraHang.MaPhieu = reader["MaPhieu"].ToString();
                    phieuTraHang.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieuTraHang.HoaDon = this.hoaDonService.findByMaHoaDon(reader["MaHoaDon"].ToString());
                    phieuTraHang.LyDo = reader["LyDo"].ToString();
                    phieuTraHang.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieuTraHang.ChiTiets = this.chiTietService.getChiTietTraHangByPhieu(phieuTraHang.MaPhieu);
                    phieuTraHangs.Add(phieuTraHang);
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
            return phieuTraHangs;
        }

        public List<PhieuTraHang> findByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE ThoiGianLap BETWEEN @StartDate AND @EndDate";
            List<PhieuTraHang> phieuTraHangs = new List<PhieuTraHang>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieuTraHang;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieuTraHang = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieuTraHang = new PhieuTraHangChoNhaCungCap();
                    }
                    phieuTraHang.MaPhieu = reader["MaPhieu"].ToString();
                    phieuTraHang.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieuTraHang.HoaDon = this.hoaDonService.findByMaHoaDon(reader["MaHoaDon"].ToString());
                    phieuTraHang.LyDo = reader["LyDo"].ToString();
                    phieuTraHang.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieuTraHang.ChiTiets = this.chiTietService.getChiTietTraHangByPhieu(phieuTraHang.MaPhieu);
                    phieuTraHangs.Add(phieuTraHang);
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
            return phieuTraHangs;
        }

        public List<PhieuTraHang> findByLoaiPhieu(byte loaiPhieu)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE LoaiPhieu = @LoaiPhieu";
            List<PhieuTraHang> phieuTraHangs = new List<PhieuTraHang>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@LoaiPhieu", loaiPhieu);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieuTraHang;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieuTraHang = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieuTraHang = new PhieuTraHangChoNhaCungCap();
                    }
                    phieuTraHang.MaPhieu = reader["MaPhieu"].ToString();
                    phieuTraHang.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieuTraHang.HoaDon = this.hoaDonService.findByMaHoaDon(reader["MaHoaDon"].ToString());
                    phieuTraHang.LyDo = reader["LyDo"].ToString();
                    phieuTraHang.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieuTraHang.ChiTiets = this.chiTietService.getChiTietTraHangByPhieu(phieuTraHang.MaPhieu);
                    phieuTraHangs.Add(phieuTraHang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuTraHangs;
        }

        public PhieuTraHang findByMaPhieu(string maPhieu)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE MaPhieu = @MaPhieu";
            PhieuTraHang phieuTraHang = null;
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
                        phieuTraHang = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieuTraHang = new PhieuTraHangChoNhaCungCap();
                    }
                    phieuTraHang.MaPhieu = reader["MaPhieu"].ToString();
                    phieuTraHang.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieuTraHang.HoaDon = this.hoaDonService.findByMaHoaDon(reader["MaHoaDon"].ToString());
                    phieuTraHang.LyDo = reader["LyDo"].ToString();
                    phieuTraHang.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieuTraHang.ChiTiets = this.chiTietService.getChiTietTraHangByPhieu(phieuTraHang.MaPhieu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuTraHang;
        }

        public bool insertPhieuTraHang(PhieuTraHang phieu)
        {
            string query = "INSERT INTO PhieuTraHang (MaPhieu, ThoiGianLap, MaHoaDon, LyDo, TongTien, LoaiPhieu) " +
                "VALUES (@MaPhieu, @ThoiGianLap, @MaHoaDon, @LyDo, @TongTien, @LoaiPhieu)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd.Parameters.AddWithValue("@ThoiGianLap", phieu.ThoiGianLap);
                cmd.Parameters.AddWithValue("@MaHoaDon", (object)phieu.HoaDon?.MaHoaDon ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LyDo", (object)phieu.LyDo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                cmd.Parameters.AddWithValue("@LoaiPhieu", phieu.loaiPhieu_toByte());
                affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
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
                foreach (ChiTiet chiTiet in phieu.ChiTiets)
                {
                    chiTietService.insertChiTietTraHang(phieu.MaPhieu, chiTiet);
                }
            }
            return affectedRows > 0;
        }

        public List<PhieuTraHang> searchByKey(string key)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE MaPhieu LIKE @Key OR LyDo LIKE @Key";
            List<PhieuTraHang> phieuTraHangs = new List<PhieuTraHang>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@Key", "%" + key + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieuTraHang;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieuTraHang = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieuTraHang = new PhieuTraHangChoNhaCungCap();
                    }
                    phieuTraHang.MaPhieu = reader["MaPhieu"].ToString();
                    phieuTraHang.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieuTraHang.HoaDon = this.hoaDonService.findByMaHoaDon(reader["MaHoaDon"].ToString());
                    phieuTraHang.LyDo = reader["LyDo"].ToString();
                    phieuTraHang.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieuTraHang.ChiTiets = this.chiTietService.getChiTietTraHangByPhieu(phieuTraHang.MaPhieu);
                    phieuTraHangs.Add(phieuTraHang);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuTraHangs;
        }

        public List<PhieuTraHang> searchByKeyByLoaiPhieuTraHang(string key, byte loaiPhieuTraHang)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE (MaPhieu LIKE @Key OR LyDo LIKE @Key) AND LoaiPhieu = @LoaiPhieu";
            List<PhieuTraHang> phieuTraHangs = new List<PhieuTraHang>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@Key", "%" + key + "%");
                cmd.Parameters.AddWithValue("@LoaiPhieu", loaiPhieuTraHang);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieuTraHang;
                while (reader.Read())
                {
                    if (reader["LoaiPhieu"].ToString() == "1")
                    {
                        phieuTraHang = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieuTraHang = new PhieuTraHangChoNhaCungCap();
                    }
                    phieuTraHang.MaPhieu = reader["MaPhieu"].ToString();
                    phieuTraHang.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieuTraHang.HoaDon = this.hoaDonService.findByMaHoaDon(reader["MaHoaDon"].ToString());
                    phieuTraHang.LyDo = reader["LyDo"].ToString();
                    phieuTraHang.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieuTraHang.ChiTiets = this.chiTietService.getChiTietTraHangByPhieu(phieuTraHang.MaPhieu);
                    phieuTraHangs.Add(phieuTraHang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return phieuTraHangs;
        }
    }
}

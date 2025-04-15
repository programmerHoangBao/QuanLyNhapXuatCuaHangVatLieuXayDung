using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class PhieuTraHangService : IPhieuTraHangService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IChiTietService chiTietTraHangService = new ChiTietService();

        public bool insertPhieuTraHang(PhieuTraHang phieu)
        {
            string query = @"INSERT INTO PhieuTraHang (MaPhieu, ThoiGianLap, MaHoaDon, LyDo, LoaiPhieu, TongTien)
                             VALUES (@MaPhieu, @ThoiGianLap, @MaHoaDon, @LyDo, @LoaiPhieu, @TongTien)";
            SqlTransaction transaction = null;
            int affectedRows = 0;

            try
            {
                myDatabase.OpenConnection();
                transaction = myDatabase.Connection.BeginTransaction();

                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd.Parameters.AddWithValue("@ThoiGianLap", phieu.ThoiGianLap);
                cmd.Parameters.AddWithValue("@MaHoaDon", phieu.MaHoaDon);
                cmd.Parameters.AddWithValue("@LyDo", phieu.LyDo);
                cmd.Parameters.AddWithValue("@LoaiPhieu", phieu.loaiPhieu_toByte());
                cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);

                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            if (affectedRows > 0)
            {
                foreach (ChiTiet ct in phieu.ChiTiets)
                {
                    if (!chiTietTraHangService.insertChiTietTraHang(phieu.MaPhieu, ct))
                    {
                        deletePhieuTraHang(phieu.MaPhieu);
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public bool deletePhieuTraHang(string maPhieu)
        {
            SqlTransaction transaction = null;
            int affectedRows = 0;

            try
            {
                myDatabase.OpenConnection();
                transaction = myDatabase.Connection.BeginTransaction();

                string query = "DELETE FROM PhieuTraHang WHERE MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                affectedRows = cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi khi xóa phiếu trả hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return affectedRows > 0;
        }

        public bool updatePhieuTraHang(PhieuTraHang phieu)
        {
            if (!deletePhieuTraHang(phieu.MaPhieu))
            {
                MessageBox.Show("Không thể xóa phiếu cũ trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return insertPhieuTraHang(phieu);
        }
        public List<PhieuTraHang> findAll()
        {
            string query = "SELECT * FROM PhieuTraHang";
            List<PhieuTraHang> list = new List<PhieuTraHang>();

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieu = null;
                byte loaiPhieu;
                while (reader.Read())
                {
                    
                    loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                        phieu = new PhieuTraHangTuKhachHang();
                    else if (loaiPhieu == 2)
                        phieu = new PhieuTraHangChoNhaCungCap();

                    if (phieu != null)
                    {
                        phieu.MaPhieu = reader["MaPhieu"].ToString();
                        phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        phieu.MaHoaDon = reader["MaHoaDon"].ToString();
                        phieu.LyDo = reader["LyDo"].ToString();
                        phieu.TongTien = double.Parse(reader["TongTien"].ToString());
                        phieu.ChiTiets = chiTietTraHangService.getChiTietTraHangByPhieu(phieu.MaPhieu);

                        list.Add(phieu);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        public List<PhieuTraHang> searchByKey(string key)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE MaPhieu LIKE @Key OR LyDo LIKE @Key";
            List<PhieuTraHang> list = new List<PhieuTraHang>();

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@Key", "%" + key + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuTraHang phieu = createPhieuFromReader(reader);
                    list.Add(phieu);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        public List<PhieuTraHang> findByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE ThoiGianLap BETWEEN @StartDate AND @EndDate";
            List<PhieuTraHang> list = new List<PhieuTraHang>();

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuTraHang phieu = createPhieuFromReader(reader);
                    list.Add(phieu);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        public List<PhieuTraHang> findByLoaiPhieu(byte loaiPhieu)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE LoaiPhieu = @LoaiPhieu";
            List<PhieuTraHang> list = new List<PhieuTraHang>();

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@LoaiPhieu", loaiPhieu);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuTraHang phieu = createPhieuFromReader(reader);
                    list.Add(phieu);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        public PhieuTraHang findByMaPhieu(string maPhieu)
        {
            string query = "SELECT * FROM PhieuTraHang WHERE MaPhieu = @MaPhieu";
            PhieuTraHang phieu = null;

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    phieu = createPhieuFromReader(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return phieu;
        }

        private PhieuTraHang createPhieuFromReader(SqlDataReader reader)
        {
            PhieuTraHang phieu = null;
            byte loai = byte.Parse(reader["LoaiPhieu"].ToString());
            if (loai == 1)
                phieu = new PhieuTraHangTuKhachHang();
            else if (loai == 2)
                phieu = new PhieuTraHangChoNhaCungCap();

            if (phieu != null)
            {
                phieu.MaPhieu = reader["MaPhieu"].ToString();
                phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                phieu.MaHoaDon = reader["MaHoaDon"].ToString();
                phieu.LyDo = reader["LyDo"].ToString();
                phieu.TongTien = double.Parse(reader["TongTien"].ToString());
                phieu.ChiTiets = chiTietTraHangService.getChiTietTraHangByPhieu(phieu.MaPhieu);
            }

            return phieu;
        }
    }
}

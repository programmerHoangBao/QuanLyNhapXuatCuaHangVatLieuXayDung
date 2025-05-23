﻿using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class ChiPhiPhatSinhService : IChiPhiPhatSinhService
    {
        private MyDatabase myDatabase = new MyDatabase();

        private ChiPhiPhatSinh MapReaderToChiPhi(SqlDataReader reader)
        {
            return new ChiPhiPhatSinh
            {
                MaChiPhi = reader["MaChiPhi"].ToString(),
                LoaiChiPhi = Convert.ToByte(reader["LoaiChiPhi"]),
                ThoiGianLap = Convert.ToDateTime(reader["ThoiGianLap"]),
                MoTa = reader["MoTa"].ToString(),
                ChiPhi = Convert.ToDouble(reader["ChiPhi"])
            };
        }

        public List<ChiPhiPhatSinh> FindAll()
        {
            string query = "SELECT * FROM ChiPhiPhatSinh";
            List<ChiPhiPhatSinh> danhSach = new List<ChiPhiPhatSinh>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(MapReaderToChiPhi(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return danhSach;
        }

        public ChiPhiPhatSinh FindByMaChiPhi(string maChiPhi)
        {
            string query = "SELECT * FROM ChiPhiPhatSinh WHERE MaChiPhi = @MaChiPhi";
            ChiPhiPhatSinh chiPhi = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaChiPhi", maChiPhi);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    chiPhi = MapReaderToChiPhi(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return chiPhi;
        }

        public bool InsertChiPhi(ChiPhiPhatSinh chiPhi)
        {
            string query = @"INSERT INTO ChiPhiPhatSinh 
                             (MaChiPhi, LoaiChiPhi, ThoiGianLap, MoTa, ChiPhi)
                             VALUES (@MaChiPhi, @LoaiChiPhi, @ThoiGianLap, @MoTa, @ChiPhi)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();

                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaChiPhi", chiPhi.MaChiPhi);
                cmd.Parameters.AddWithValue("@LoaiChiPhi", chiPhi.LoaiChiPhi);
                cmd.Parameters.AddWithValue("@ThoiGianLap", chiPhi.ThoiGianLap);
                cmd.Parameters.AddWithValue("@MoTa", chiPhi.MoTa);
                cmd.Parameters.AddWithValue("@ChiPhi", chiPhi.ChiPhi);

                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }

        public bool UpdateChiPhi(ChiPhiPhatSinh chiPhi)
        {
            string query = @"UPDATE ChiPhiPhatSinh 
                             SET LoaiChiPhi = @LoaiChiPhi,
                                 ThoiGianLap = @ThoiGianLap,
                                 MoTa = @MoTa,
                                 ChiPhi = @ChiPhi
                             WHERE MaChiPhi = @MaChiPhi";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();

                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaChiPhi", chiPhi.MaChiPhi);
                cmd.Parameters.AddWithValue("@LoaiChiPhi", chiPhi.LoaiChiPhi);
                cmd.Parameters.AddWithValue("@ThoiGianLap", chiPhi.ThoiGianLap);
                cmd.Parameters.AddWithValue("@MoTa", chiPhi.MoTa);
                cmd.Parameters.AddWithValue("@ChiPhi", chiPhi.ChiPhi);

                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }

        public bool DeleteChiPhi(string maChiPhi)
        {
            string query = "DELETE FROM ChiPhiPhatSinh WHERE MaChiPhi = @MaChiPhi";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();

                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaChiPhi", maChiPhi);

                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return affectedRows > 0;
        }

        public List<ChiPhiPhatSinh> SearchByKeyword(string keyword)
        {
            string query = @"SELECT * FROM ChiPhiPhatSinh 
                             WHERE MaChiPhi LIKE @keyword 
                                OR LoaiChiPhi LIKE @keyword 
                                OR MoTa LIKE @keyword";
            List<ChiPhiPhatSinh> danhSach = new List<ChiPhiPhatSinh>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(MapReaderToChiPhi(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.myDatabase.CloseConnection();
            }
            return danhSach;
        }

        public List<ChiPhiPhatSinh> FindAllChiPhiSortDateDesc()
        {
            string query = "SELECT * FROM ChiPhiPhatSinh ORDER BY ThoiGianLap DESC";
            List<ChiPhiPhatSinh> chiPhiPhatSinhs = new List<ChiPhiPhatSinh>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chiPhiPhatSinhs.Add(MapReaderToChiPhi(reader));
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
            return chiPhiPhatSinhs;
        }
    }
}
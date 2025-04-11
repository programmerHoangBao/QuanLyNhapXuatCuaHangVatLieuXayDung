using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    namespace QuanLyCuaHangVatLieuXayDung.service
    {
        internal class ChiPhiPhatSinhService : IChiPhiPhatSinhService
        {
            private MyDatabase myDatabase = new MyDatabase();

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
                        ChiPhiPhatSinh chiPhi = new ChiPhiPhatSinh
                        {
                            MaChiPhi = reader["MaChiPhi"].ToString(),
                            LoaiChiPhi = Convert.ToByte(reader["LoaiChiPhi"]),
                            ThoiGianLap = Convert.ToDateTime(reader["ThoiGianLap"]),
                            MoTa = reader["MoTa"].ToString(),
                            ChiPhi = Convert.ToDouble(reader["ChiPhi"])
                        };
                        danhSach.Add(chiPhi);
                    }
                    this.myDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                        chiPhi = new ChiPhiPhatSinh
                        {
                            MaChiPhi = reader["MaChiPhi"].ToString(),
                            LoaiChiPhi = Convert.ToByte(reader["LoaiChiPhi"]),
                            ThoiGianLap = Convert.ToDateTime(reader["ThoiGianLap"]),
                            MoTa = reader["MoTa"].ToString(),
                            ChiPhi = Convert.ToDouble(reader["ChiPhi"])
                        };
                    }
                    this.myDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return chiPhi;
            }

            public bool InsertChiPhi(ChiPhiPhatSinh chiPhi)
            {
                string query = @"INSERT INTO ChiPhiPhatSinh 
                            (MaChiPhi, LoaiChiPhi, ThoiGianLap, MoTa, ChiPhi)
                            VALUES (@MaChiPhi, @LoaiChiPhi, @ThoiGianLap, @MoTa, @ChiPhi)";
                try
                {
                    SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                    cmd.Parameters.AddWithValue("@MaChiPhi", chiPhi.MaChiPhi);
                    cmd.Parameters.AddWithValue("@LoaiChiPhi", chiPhi.LoaiChiPhi);
                    cmd.Parameters.AddWithValue("@ThoiGianLap", chiPhi.ThoiGianLap);
                    cmd.Parameters.AddWithValue("@MoTa", chiPhi.MoTa);
                    cmd.Parameters.AddWithValue("@ChiPhi", chiPhi.ChiPhi);
                    this.myDatabase.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    this.myDatabase.CloseConnection();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }

            public bool UpdateChiPhi(ChiPhiPhatSinh chiPhi)
            {
                string query = @"UPDATE ChiPhiPhatSinh 
                            SET LoaiChiPhi = @LoaiChiPhi,
                                ThoiGianLap = @ThoiGianLap,
                                MoTa = @MoTa,
                                ChiPhi = @ChiPhi
                            WHERE MaChiPhi = @MaChiPhi";
                try
                {
                    SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                    cmd.Parameters.AddWithValue("@MaChiPhi", chiPhi.MaChiPhi);
                    cmd.Parameters.AddWithValue("@LoaiChiPhi", chiPhi.LoaiChiPhi);
                    cmd.Parameters.AddWithValue("@ThoiGianLap", chiPhi.ThoiGianLap);
                    cmd.Parameters.AddWithValue("@MoTa", chiPhi.MoTa);
                    cmd.Parameters.AddWithValue("@ChiPhi", chiPhi.ChiPhi);
                    this.myDatabase.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    this.myDatabase.CloseConnection();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }

            public bool DeleteChiPhi(string maChiPhi)
            {
                string query = "DELETE FROM ChiPhiPhatSinh WHERE MaChiPhi = @MaChiPhi";
                try
                {
                    SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                    cmd.Parameters.AddWithValue("@MaChiPhi", maChiPhi);
                    this.myDatabase.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    this.myDatabase.CloseConnection();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }

            public List<ChiPhiPhatSinh> SearchByKeyword(string keyword)
            {
                string query = @"SELECT * FROM ChiPhiPhatSinh 
                             WHERE MaChiPhi LIKE @keyword OR MoTa LIKE @keyword";
                List<ChiPhiPhatSinh> danhSach = new List<ChiPhiPhatSinh>();
                try
                {
                    SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    this.myDatabase.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ChiPhiPhatSinh chiPhi = new ChiPhiPhatSinh
                        {
                            MaChiPhi = reader["MaChiPhi"].ToString(),
                            LoaiChiPhi = Convert.ToByte(reader["LoaiChiPhi"]),
                            ThoiGianLap = Convert.ToDateTime(reader["ThoiGianLap"]),
                            MoTa = reader["MoTa"].ToString(),
                            ChiPhi = Convert.ToDouble(reader["ChiPhi"])
                        };
                        danhSach.Add(chiPhi);
                    }
                    this.myDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return danhSach;
            }
        }
    }
}

using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    //Khác phục các hoạt động liên quan đến ChiTietPhieuTraHang thì thực hiện code trong ChiTietService
    // Chinh sưa lại các method cho PhieuTraHangService cần thiết kết lại code transaction cho phù hợp có thể tham khảo VatLieuServicce
    internal class PhieuTraHangService : IPhieuTraHangService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IVatLieuService vatLieuService = new VatLieuService();

        public bool insertphieuTraHang(PhieuTraHang phieu)
        {
            string query = "INSERT INTO PhieuTraHang (MaPhieu, ThoiGianLap, LyDo, TongTien, LoaiPhieu) " +
                           "VALUES (@MaPhieu, @ThoiGianLap, @LyDo, @TongTien, @LoaiPhieu)";
            string chiTietQuery = "INSERT INTO ChiTietPhieuTraHang (MaPhieu, MaVatLieu, SoLuong) " +
                                  "VALUES (@MaPhieu, @MaVatLieu, @SoLuong)";
            try
            {
                myDatabase.OpenConnection();

                using (SqlTransaction transaction = myDatabase.Connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                        cmd.Parameters.AddWithValue("@ThoiGianLap", phieu.ThoiGianLap);
                        cmd.Parameters.AddWithValue("@LyDo", phieu.LyDo);
                        cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                        cmd.Parameters.AddWithValue("@LoaiPhieu", phieu.loaiPhieu_toByte());
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var ct in phieu.ChiTiets)
                    {
                        using (SqlCommand chiTietCmd = new SqlCommand(chiTietQuery, myDatabase.Connection, transaction))
                        {
                            chiTietCmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                            chiTietCmd.Parameters.AddWithValue("@MaVatLieu", ct.VatLieu.MaVatLieu);
                            chiTietCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                            chiTietCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu trả hàng: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return false;
        }

        public bool deletephieuTraHang(string maPhieu)
        {
            try
            {
                string deleteChiTiet = "DELETE FROM ChiTietPhieuTraHang WHERE MaPhieu = @MaPhieu";
                string deletePhieu = "DELETE FROM PhieuTraHang WHERE MaPhieu = @MaPhieu";

                myDatabase.OpenConnection();

                using (SqlTransaction transaction = myDatabase.Connection.BeginTransaction())
                {
                    SqlCommand cmd1 = new SqlCommand(deleteChiTiet, myDatabase.Connection, transaction);
                    cmd1.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(deletePhieu, myDatabase.Connection, transaction);
                    cmd2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    int result = cmd2.ExecuteNonQuery();

                    transaction.Commit();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu trả hàng: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return false;
        }

        public List<PhieuTraHang> findallphieuTraHang()
        {
            List<PhieuTraHang> list = new List<PhieuTraHang>();
            string query = "SELECT * FROM PhieuTraHang";

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieu;
                while (reader.Read())
                {
                    byte loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                        phieu = new PhieuTraHangTuKhachHang();
                    else
                        phieu = new PhieuTraHangChoNhaCungCap();

                    phieu.MaPhieu = reader["MaPhieu"].ToString();
                    phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieu.LyDo = reader["LyDo"].ToString();
                    phieu.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieu.ChiTiets = loaddanhSachVatLieu(phieu.MaPhieu);

                    list.Add(phieu);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        public PhieuTraHang findbyMaPhieu(string maPhieu)
        {
            PhieuTraHang phieu = null;
            string query = "SELECT * FROM PhieuTraHang WHERE MaPhieu = @MaPhieu";

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    byte loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                        phieu = new PhieuTraHangTuKhachHang();
                    else
                        phieu = new PhieuTraHangChoNhaCungCap();

                    phieu.MaPhieu = reader["MaPhieu"].ToString();
                    phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieu.LyDo = reader["LyDo"].ToString();
                    phieu.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieu.ChiTiets = loaddanhSachVatLieu(phieu.MaPhieu);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return phieu;
        }

        public bool updatephieuTraHang(PhieuTraHang phieu)
        {
            try
            {
                myDatabase.OpenConnection();
                SqlTransaction transaction = myDatabase.Connection.BeginTransaction();

                SqlCommand cmd1 = new SqlCommand("DELETE FROM ChiTietPhieuTraHang WHERE MaPhieu = @MaPhieu", myDatabase.Connection, transaction);
                cmd1.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM PhieuTraHang WHERE MaPhieu = @MaPhieu", myDatabase.Connection, transaction);
                cmd2.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd2.ExecuteNonQuery();

                SqlCommand insertCmd = new SqlCommand("INSERT INTO PhieuTraHang (MaPhieu, ThoiGianLap, LyDo, TongTien, LoaiPhieu) VALUES (@MaPhieu, @ThoiGianLap, @LyDo, @TongTien, @LoaiPhieu)", myDatabase.Connection, transaction);
                insertCmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                insertCmd.Parameters.AddWithValue("@ThoiGianLap", phieu.ThoiGianLap);
                insertCmd.Parameters.AddWithValue("@LyDo", phieu.LyDo);
                insertCmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                insertCmd.Parameters.AddWithValue("@LoaiPhieu", phieu.loaiPhieu_toByte());
                insertCmd.ExecuteNonQuery();

                foreach (var ct in phieu.ChiTiets)
                {
                    SqlCommand chiTietCmd = new SqlCommand("INSERT INTO ChiTietPhieuTraHang (MaPhieu, MaVatLieu, SoLuong) VALUES (@MaPhieu, @MaVatLieu, @SoLuong)", myDatabase.Connection, transaction);
                    chiTietCmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                    chiTietCmd.Parameters.AddWithValue("@MaVatLieu", ct.VatLieu.MaVatLieu);
                    chiTietCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                    chiTietCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return false;
        }

        public List<PhieuTraHang> findphieuTraHangByDay(DateTime tuNgay, DateTime denNgay)
        {
            List<PhieuTraHang> list = new List<PhieuTraHang>();
            string query = "SELECT * FROM PhieuTraHang WHERE ThoiGianLap >= @TuNgay AND ThoiGianLap < @NgayHomSau";

            try
            {
                myDatabase.OpenConnection();
                DateTime ngayHomSau = denNgay.Date.AddDays(1);

                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@NgayHomSau", ngayHomSau);

                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieu;
                while (reader.Read())
                {
                    byte loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                        phieu = new PhieuTraHangTuKhachHang();
                    else
                        phieu = new PhieuTraHangChoNhaCungCap();

                    phieu.MaPhieu = reader["MaPhieu"].ToString();
                    phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieu.LyDo = reader["LyDo"].ToString();
                    phieu.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieu.ChiTiets = loaddanhSachVatLieu(phieu.MaPhieu);

                    list.Add(phieu);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        public List<PhieuTraHang> searchByKey(string keyword)
        {
            List<PhieuTraHang> list = new List<PhieuTraHang>();
            string query = @"SELECT * FROM PhieuTraHang 
                             WHERE MaPhieu LIKE @keyword 
                                OR LyDo LIKE @keyword 
                                OR CONVERT(VARCHAR(10), ThoiGianLap, 120) = @ngayKeyword";

            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                if (DateTime.TryParse(keyword, out DateTime ngayParsed))
                    cmd.Parameters.AddWithValue("@ngayKeyword", ngayParsed.ToString("yyyy-MM-dd"));
                else
                    cmd.Parameters.AddWithValue("@ngayKeyword", "0000-00-00");

                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieu;
                while (reader.Read())
                {
                    byte loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                        phieu = new PhieuTraHangTuKhachHang();
                    else
                        phieu = new PhieuTraHangChoNhaCungCap();

                    phieu.MaPhieu = reader["MaPhieu"].ToString();
                    phieu.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                    phieu.LyDo = reader["LyDo"].ToString();
                    phieu.TongTien = double.Parse(reader["TongTien"].ToString());
                    phieu.ChiTiets = loaddanhSachVatLieu(phieu.MaPhieu);

                    list.Add(phieu);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return list;
        }

        private List<ChiTiet> loaddanhSachVatLieu(string maPhieu)
        {
            List<ChiTiet> list = new List<ChiTiet>();
            string query = "SELECT MaVatLieu, SoLuong FROM ChiTietTraHang WHERE MaPhieu = @MaPhieu";

            try
            {
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VatLieu vatLieu = vatLieuService.findByMaVatLieu(reader["MaVatLieu"].ToString());
                    float soLuong = float.Parse(reader["SoLuong"].ToString());
                    list.Add(new ChiTiet(vatLieu, soLuong));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return list;
        }
    }
}

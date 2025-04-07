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
        private IVatLieuService vatLieuService = new VatLieuService();

        public bool insertphieuTraHang(PhieuTraHang phieu)
        {
            string query = "INSERT INTO PhieuTraHang (MaPhieu, ThoiGianLap, LyDo, TongTien, LoaiPhieu) VALUES (@MaPhieu, @ThoiGianLap, @LyDo, @TongTien, @LoaiPhieu)";
            string chiTietQuery = "INSERT INTO ChiTietPhieuTraHang (MaPhieu, MaVatLieu, SoLuong) VALUES (@MaPhieu, @MaVatLieu, @SoLuong)";
            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd.Parameters.AddWithValue("@ThoiGianLap", phieu.ThoiGianLap);
                cmd.Parameters.AddWithValue("@LyDo", phieu.LyDo);
                cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                //int loaiPhieu = (phieu is PhieuTraHangTuKhachHang) ? 1 : 2;
                byte loaiPhieu = phieu.loaiPhieu_toByte();
                cmd.Parameters.AddWithValue("@LoaiPhieu", loaiPhieu);
                cmd.ExecuteNonQuery();

                foreach (var (vatLieu, soLuong) in phieu.ChiTiets)
                {
                    SqlCommand chiTietCmd = new SqlCommand(chiTietQuery, myDatabase.Connection);
                    chiTietCmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                    chiTietCmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                    chiTietCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    chiTietCmd.ExecuteNonQuery();
                }
                // fix
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                // ktra xem cmd1 thuc hien duoc k.
                myDatabase.OpenConnection();

                SqlCommand cmd1 = new SqlCommand(deleteChiTiet, myDatabase.Connection);
                cmd1.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(deletePhieu, myDatabase.Connection);
                cmd2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                int result = cmd2.ExecuteNonQuery();

                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                byte loaiPhieu;
                while (reader.Read())
                {
                    //int loaiPhieu = Convert.ToInt32(reader["LoaiPhieu"]);
                    //if (loaiPhieu == 1)
                    //{
                    //    phieu = new PhieuTraHangTuKhachHang();
                    //}
                    //else
                    //{
                    //    phieu = new PhieuTraHangChoNhaCungCap();
                    //}
                    loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                    {
                        phieu = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieu = new PhieuTraHangChoNhaCungCap();
                    }
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
                    {
                        phieu = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieu = new PhieuTraHangChoNhaCungCap();
                    }

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
            if (!deletephieuTraHang(phieu.MaPhieu)) 
                return false;
            return insertphieuTraHang(phieu);
        }

        public List<PhieuTraHang> findphieuTraHangByDay(DateTime tuNgay, DateTime denNgay)
        {
            List<PhieuTraHang> list = new List<PhieuTraHang>();
            // fix, so sanh kieu du lieu cua ngay thang chua dung
            string query = "SELECT * FROM PhieuTraHang WHERE ThoiGianLap BETWEEN @TuNgay AND @DenNgay";
            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                SqlDataReader reader = cmd.ExecuteReader();
                PhieuTraHang phieu;
                byte loaiPhieu;
                while (reader.Read())
                {
                    loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                    if (loaiPhieu == 1)
                    {
                        phieu = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieu = new PhieuTraHangChoNhaCungCap();
                    }

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
            // thêm theo ngay, thang nam
            List<PhieuTraHang> list = new List<PhieuTraHang>();
            string query = "SELECT * FROM PhieuTraHang WHERE MaPhieu LIKE @keyword OR LyDo LIKE @keyword";
            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                byte loaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString());
                PhieuTraHang phieu;
                while (reader.Read())
                {
                    if (loaiPhieu == 1)
                    {
                        phieu = new PhieuTraHangTuKhachHang();
                    }
                    else
                    {
                        phieu = new PhieuTraHangChoNhaCungCap();
                    }

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

        private List<(VatLieu, float)> loaddanhSachVatLieu(string maPhieu)
        {
            List<(VatLieu, float)> list = new List<(VatLieu, float)>();
            string query = "SELECT MaVatLieu, SoLuong FROM ChiTietPhieuTraHang WHERE MaPhieu = @MaPhieu";
            try
            {
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();
                VatLieu vatLieu;
                float soLuong;
                while (reader.Read())
                {
                    vatLieu = vatLieuService.findByMaVatLieu(reader["MaVatLieu"].ToString());
                    soLuong = float.Parse(reader["SoLuong"].ToString());
                    list.Add((vatLieu, soLuong));
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

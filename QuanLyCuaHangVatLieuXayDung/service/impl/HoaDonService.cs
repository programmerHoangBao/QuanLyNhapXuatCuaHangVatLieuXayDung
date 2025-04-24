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
    internal class HoaDonService : IHoaDonService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IDoiTacService doiTacService = new DoiTacService();
        private IChiTietService chiTietService = new ChiTietService();
        public bool deleteHoaDon(string maHoaDon)
        {
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
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

        public List<HoaDon> findAll()
        {
            string query = "SELECT * FROM HoaDon";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                HoaDon hoaDon = null;
                while (reader.Read())
                {
                    if (reader["LoaiHoaDon"].ToString() == "1")
                    {
                        hoaDon = new HoaDonXuat();
                    }
                    else if (reader["LoaiHoaDon"].ToString() == "2")
                    {
                        hoaDon = new HoaDonNhap();
                    }

                    if (hoaDon != null)
                    {
                        hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                        hoaDon.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        hoaDon.DoiTac = this.doiTacService.findByMaDoiTac(reader["MaDoiTac"].ToString());
                        hoaDon.DiaChi = reader["DiaChi"].ToString();
                        hoaDon.TienGiam = double.Parse(reader["TienGiam"].ToString());
                        hoaDon.PhuongThucThanhToan = byte.Parse(reader["PhuongThucThanhToan"].ToString());
                        hoaDon.TienThanhToan = double.Parse(reader["TienThanhToan"].ToString());
                        hoaDons.Add(hoaDon);
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
                if (hoaDons.Count > 0)
                {
                    foreach (HoaDon hoaDon in hoaDons)
                    {
                        hoaDon.ChiTiets = this.chiTietService.GetChiTietHoaDon(hoaDon.MaHoaDon);
                    }
                }
            }
            return hoaDons;
        }

        public List<HoaDon> findByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM HoaDon WHERE ThoiGianLap BETWEEN @StartDate AND @EndDate";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = cmd.ExecuteReader();
                HoaDon hoaDon = null;
                while (reader.Read())
                {
                    if (reader["LoaiHoaDon"].ToString() == "1")
                    {
                        hoaDon = new HoaDonXuat();
                    }
                    else if (reader["LoaiHoaDon"].ToString() == "2")
                    {
                        hoaDon = new HoaDonNhap();
                    }
                    if (hoaDon != null)
                    {
                        hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                        hoaDon.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        hoaDon.DoiTac = this.doiTacService.findByMaDoiTac(reader["MaDoiTac"].ToString());
                        hoaDon.DiaChi = reader["DiaChi"].ToString();
                        hoaDon.TienGiam = double.Parse(reader["TienGiam"].ToString());
                        hoaDon.PhuongThucThanhToan = byte.Parse(reader["PhuongThucThanhToan"].ToString());
                        hoaDon.TienThanhToan = double.Parse(reader["TienThanhToan"].ToString());
                        hoaDons.Add(hoaDon);
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
                if (hoaDons.Count > 0)
                {
                    foreach (HoaDon hoaDon in hoaDons)
                    {
                        hoaDon.ChiTiets = this.chiTietService.GetChiTietHoaDon(hoaDon.MaHoaDon);
                    }
                }
            }
            return hoaDons;
        }

        public List<HoaDon> findByDoiTac(string maDoiTac)
        {
            string query = "SELECT * FROM HoaDon WHERE MaDoiTac = @MaDoiTac";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                SqlDataReader reader = cmd.ExecuteReader();
                HoaDon hoaDon = null;
                while (reader.Read())
                {
                    if (reader["LoaiHoaDon"].ToString() == "1")
                    {
                        hoaDon = new HoaDonXuat();
                    }
                    else if (reader["LoaiHoaDon"].ToString() == "2")
                    {
                        hoaDon = new HoaDonNhap();
                    }
                    if (hoaDon != null)
                    {
                        hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                        hoaDon.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        hoaDon.DoiTac = this.doiTacService.findByMaDoiTac(reader["MaDoiTac"].ToString());
                        hoaDon.DiaChi = reader["DiaChi"].ToString();
                        hoaDon.TienGiam = double.Parse(reader["TienGiam"].ToString());
                        hoaDon.PhuongThucThanhToan = byte.Parse(reader["PhuongThucThanhToan"].ToString());
                        hoaDon.TienThanhToan = double.Parse(reader["TienThanhToan"].ToString());
                        hoaDons.Add(hoaDon);
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
                if (hoaDons.Count > 0)
                {
                    foreach (HoaDon hoaDon in hoaDons)
                    {
                        hoaDon.ChiTiets = this.chiTietService.GetChiTietHoaDon(hoaDon.MaHoaDon);
                    }
                }
            }
            return hoaDons;
        }

        public List<HoaDon> findByLoaiHoaDon(byte loaiHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE LoaiHoaDon = @LoaiHoaDon";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@LoaiHoaDon", loaiHoaDon);
                SqlDataReader reader = cmd.ExecuteReader();
                HoaDon hoaDon = null;
                while (reader.Read())
                {
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat();
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap();
                    }

                    if (hoaDon != null)
                    {
                        hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                        hoaDon.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        hoaDon.DoiTac = this.doiTacService.findByMaDoiTac(reader["MaDoiTac"].ToString());
                        hoaDon.DiaChi = reader["DiaChi"].ToString();
                        hoaDon.TienGiam = double.Parse(reader["TienGiam"].ToString());
                        hoaDon.PhuongThucThanhToan = byte.Parse(reader["PhuongThucThanhToan"].ToString());
                        hoaDon.TienThanhToan = double.Parse(reader["TienThanhToan"].ToString());
                        hoaDons.Add(hoaDon);
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
                if (hoaDons.Count > 0)
                {
                    foreach (HoaDon hoaDon in hoaDons)
                    {
                        hoaDon.ChiTiets = this.chiTietService.GetChiTietHoaDon(hoaDon.MaHoaDon);
                    }
                }
            }
            return hoaDons;
        }
        public HoaDon findByMaHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            HoaDon hoaDon = null;
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["LoaiHoaDon"].ToString() == "1")
                    {
                        hoaDon = new HoaDonXuat();
                    }
                    else if (reader["LoaiHoaDon"].ToString() == "2")
                    {
                        hoaDon = new HoaDonNhap();
                    }
                    if (hoaDon != null)
                    {
                        hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                        hoaDon.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        hoaDon.DoiTac = this.doiTacService.findByMaDoiTac(reader["MaDoiTac"].ToString());
                        hoaDon.DiaChi = reader["DiaChi"].ToString();
                        hoaDon.TienGiam = double.Parse(reader["TienGiam"].ToString());
                        hoaDon.PhuongThucThanhToan = byte.Parse(reader["PhuongThucThanhToan"].ToString());
                        hoaDon.TienThanhToan = double.Parse(reader["TienThanhToan"].ToString());
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
                if (hoaDon != null)
                {
                    hoaDon.ChiTiets = this.chiTietService.GetChiTietHoaDon(hoaDon.MaHoaDon);
                }
            }
            return hoaDon;
        }

        public bool insertHoaDon(HoaDon hoaDon)
        {
            string query = @"INSERT INTO HoaDon (MaHoaDon, MaDoiTac, TenDoiTac, SoDienThoai, DiaChi,
                                                 TienGiam, PhuongThucThanhToan, LoaiHoaDon, TienThanhToan)
                             VALUES (@MaHoaDon, @MaDoiTac, @TenDoiTac, @SoDienThoai, @DiaChi,
                                     @TienGiam, @PhuongThucThanhToan, @LoaiHoaDon, @TienThanhToan)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            bool result = true;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                cmd.Parameters.AddWithValue("@MaDoiTac", hoaDon.DoiTac.MaDoiTac);
                cmd.Parameters.AddWithValue("@TenDoiTac", hoaDon.DoiTac.Ten);
                cmd.Parameters.AddWithValue("@SoDienThoai", hoaDon.DoiTac.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", hoaDon.DiaChi);
                cmd.Parameters.AddWithValue("@TienGiam", hoaDon.TienGiam);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan);
                cmd.Parameters.AddWithValue("@LoaiHoaDon", hoaDon.loaiHoaDon_toByte());
                cmd.Parameters.AddWithValue("@TienThanhToan", hoaDon.TienThanhToan);
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
                if (affectedRows > 0)
                {
                    foreach (ChiTiet chiTiet in hoaDon.ChiTiets)
                    {
                        if (!this.chiTietService.insertChiTietHoaDon(hoaDon.MaHoaDon, chiTiet))
                        {
                            result = false;
                            this.deleteHoaDon(hoaDon.MaHoaDon);
                            break;
                        }
                    }
                }
                this.myDatabase.CloseConnection();
            }
            return result;
        }

        public List<HoaDon> searchByKey(string key)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon LIKE @Key OR TenDoiTac LIKE @Key";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@Key", "%" + key + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                HoaDon hoaDon = null;
                while (reader.Read())
                {
                    if (reader["LoaiHoaDon"].ToString() == "1")
                    {
                        hoaDon = new HoaDonXuat();
                    }
                    else if (reader["LoaiHoaDon"].ToString() == "2")
                    {
                        hoaDon = new HoaDonNhap();
                    }
                    if (hoaDon != null)
                    {
                        hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                        hoaDon.ThoiGianLap = DateTime.Parse(reader["ThoiGianLap"].ToString());
                        hoaDon.DoiTac = this.doiTacService.findByMaDoiTac(reader["MaDoiTac"].ToString());
                        hoaDon.DiaChi = reader["DiaChi"].ToString();
                        hoaDon.TienGiam = double.Parse(reader["TienGiam"].ToString());
                        hoaDon.PhuongThucThanhToan = byte.Parse(reader["PhuongThucThanhToan"].ToString());
                        hoaDon.TienThanhToan = double.Parse(reader["TienThanhToan"].ToString());
                        hoaDons.Add(hoaDon);
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
                if (hoaDons.Count > 0)
                {
                    foreach (HoaDon hoaDon in hoaDons)
                    {
                        hoaDon.ChiTiets = this.chiTietService.GetChiTietHoaDon(hoaDon.MaHoaDon);
                    }
                }
            }
            return hoaDons;
        }
        public ChiTiet chiTietVatLieuConLaiCuaHoaDon(string maHoaDon, VatLieu vatLieu)
        {
            ChiTiet chiTiet = new ChiTiet();
            chiTiet.VatLieu = vatLieu;
            chiTiet.SoLuong = 0;

            // Lấy danh sách chi tiết hóa đơn
            List<ChiTiet> chiTiets = this.chiTietService.GetChiTietHoaDon(maHoaDon);
            // Lấy danh sách chi tiết trả hàng
            List<ChiTiet> chiTietTraHang = this.chiTietService.GetChiTietTraHang(maHoaDon);

            // Tính tổng số lượng đã trả hàng cho vật liệu
            float soLuongDaTra = 0;
            foreach (ChiTiet ct in chiTietTraHang)
            {
                if (ct.VatLieu.MaVatLieu == vatLieu.MaVatLieu)
                {
                    soLuongDaTra += ct.SoLuong; // Tổng số lượng đã trả hàng
                }
            }

            // Tính số lượng còn lại sau khi trừ đi số lượng trả hàng
            foreach (ChiTiet ct in chiTiets)
            {
                if (ct.VatLieu.MaVatLieu == vatLieu.MaVatLieu)
                {
                    chiTiet.SoLuong = ct.SoLuong - soLuongDaTra; // Số lượng còn lại
                    break;
                }
            }

            return chiTiet;
        }

    }
}

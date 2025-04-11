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

        public List<HoaDon> findAll()
        {
            string query = "SELECT * FROM HoaDon";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon;
                    byte loaiHoaDon = reader.GetByte(reader.GetOrdinal("LoaiHoaDon"));
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            KhachHang = new KhachHang { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            NhaCungCap = new NhaCungCap { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    // Lấy chi tiết hóa đơn
                    hoaDons.Add(hoaDon);
                }
                this.myDatabase.CloseConnection();
                if (hoaDons.Count > 0)
                {
                    for (int i = 0; i < hoaDons.Count; i++) {
                        hoaDons[i].ChiTiets = getChiTietHoaDon(hoaDons[i].MaHoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoaDons;
        }

        public HoaDon findByMaHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            HoaDon hoaDon = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    byte loaiHoaDon = reader.GetByte(reader.GetOrdinal("LoaiHoaDon"));
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            KhachHang = new KhachHang { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            NhaCungCap = new NhaCungCap { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                }
                this.myDatabase.CloseConnection();
                if (hoaDon != null)
                {
                    hoaDon.ChiTiets = getChiTietHoaDon(hoaDon.MaHoaDon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoaDon;
        }

        public List<(VatLieu vatLieu, float soLuong)> getChiTietHoaDon(string maHoaDon)
        {
            string query = "SELECT MaVatLieu, SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            List<(VatLieu vatLieu, float soLuong)> chiTiets = new List<(VatLieu, float)>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VatLieu vatLieu = new VatLieu { MaVatLieu = reader["MaVatLieu"].ToString() }; // Giả định có lớp VatLieu
                    float soLuong = (float)reader.GetDouble(reader.GetOrdinal("SoLuong"));
                    chiTiets.Add((vatLieu, soLuong));
                }
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return chiTiets;
        }

        public bool insertHoaDon(HoaDon hoaDon)
        {
            string queryHoaDon = @"INSERT INTO HoaDon (MaHoaDon, ThoiGianLap, MaDoiTac, TenDoiTac, SoDienThoai, DiaChi, TienGiam, PhuongThucThanhToan, LoaiHoaDon, TongTien)
                           VALUES (@MaHoaDon, @ThoiGianLap, @MaDoiTac, @TenDoiTac, @SoDienThoai, @DiaChi, @TienGiam, @PhuongThucThanhToan, @LoaiHoaDon, @TongTien)";
            string queryChiTiet = @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaVatLieu, SoLuong, TenVatLieu, GiaNhap, GiaXuat, DonVi, NgayNhap, NhaCungCap, HinhAnh)
                            VALUES (@MaHoaDon, @MaVatLieu, @SoLuong, @TenVatLieu, @GiaNhap, @GiaXuat, @DonVi, @NgayNhap, @NhaCungCap, @HinhAnh)";
            try
            {
                this.myDatabase.OpenConnection();
                using (SqlTransaction transaction = this.myDatabase.Connection.BeginTransaction())
                {
                    // Thêm hóa đơn
                    SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, this.myDatabase.Connection, transaction);
                    cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                    cmdHoaDon.Parameters.AddWithValue("@ThoiGianLap", hoaDon.ThoiGianLap);

                    if (hoaDon is HoaDonNhap hoaDonNhap)
                    {
                        cmdHoaDon.Parameters.AddWithValue("@MaDoiTac", hoaDonNhap.NhaCungCap.MaDoiTac);
                        cmdHoaDon.Parameters.AddWithValue("@TenDoiTac", hoaDonNhap.NhaCungCap.Ten);
                        cmdHoaDon.Parameters.AddWithValue("@SoDienThoai", hoaDonNhap.NhaCungCap.SoDienThoai);
                    }
                    else if (hoaDon is HoaDonXuat hoaDonXuat)
                    {
                        cmdHoaDon.Parameters.AddWithValue("@MaDoiTac", hoaDonXuat.KhachHang.MaDoiTac);
                        cmdHoaDon.Parameters.AddWithValue("@TenDoiTac", hoaDonXuat.KhachHang.Ten);
                        cmdHoaDon.Parameters.AddWithValue("@SoDienThoai", hoaDonXuat.KhachHang.SoDienThoai);
                    }
                    else
                    {
                        throw new Exception("Loại hóa đơn không hợp lệ.");
                    }

                    cmdHoaDon.Parameters.AddWithValue("@DiaChi", hoaDon.DiaChi);
                    cmdHoaDon.Parameters.AddWithValue("@TienGiam", hoaDon.TienGiam);
                    cmdHoaDon.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan);
                    cmdHoaDon.Parameters.AddWithValue("@LoaiHoaDon", hoaDon.loaiHoaDon_toByte());
                    cmdHoaDon.Parameters.AddWithValue("@TongTien", hoaDon.TienThanhToan);
                    int resultHoaDon = cmdHoaDon.ExecuteNonQuery();

                    // Thêm chi tiết hóa đơn
                    foreach (var chiTiet in hoaDon.ChiTiets)
                    {
                        SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, this.myDatabase.Connection, transaction);
                        cmdChiTiet.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                        cmdChiTiet.Parameters.AddWithValue("@MaVatLieu", chiTiet.vatLieu.MaVatLieu);
                        cmdChiTiet.Parameters.AddWithValue("@SoLuong", chiTiet.soLuong);
                        cmdChiTiet.Parameters.AddWithValue("@TenVatLieu", chiTiet.vatLieu.Ten);
                        cmdChiTiet.Parameters.AddWithValue("@GiaNhap", chiTiet.vatLieu.GiaNhap);
                        cmdChiTiet.Parameters.AddWithValue("@GiaXuat", chiTiet.vatLieu.GiaXuat);
                        cmdChiTiet.Parameters.AddWithValue("@DonVi", chiTiet.vatLieu.DonVi);
                        cmdChiTiet.Parameters.AddWithValue("@NgayNhap", chiTiet.vatLieu.NgayNhap);

                        var nhaCungCap = chiTiet.vatLieu.NhaCungCap?.Ten ?? string.Empty;
                        cmdChiTiet.Parameters.AddWithValue("@NhaCungCap", nhaCungCap);

                        string anhDaiDien = chiTiet.vatLieu.HinhAnhPaths?.FirstOrDefault();
                        cmdChiTiet.Parameters.AddWithValue("@HinhAnh", (object)anhDaiDien ?? DBNull.Value);

                        cmdChiTiet.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    this.myDatabase.CloseConnection();
                    return resultHoaDon > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool updateHoaDon(HoaDon hoaDon)
        {
            string query = @"UPDATE HoaDon SET ThoiGianLap = @ThoiGianLap, MaDoiTac = @MaDoiTac, TenDoiTac = @TenDoiTac, 
                            SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, TienGiam = @TienGiam, 
                            PhuongThucThanhToan = @PhuongThucThanhToan, LoaiHoaDon = @LoaiHoaDon, TongTien = @TongTien 
                            WHERE MaHoaDon = @MaHoaDon";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                cmd.Parameters.AddWithValue("@ThoiGianLap", hoaDon.ThoiGianLap);
                cmd.Parameters.AddWithValue("@MaDoiTac", hoaDon is HoaDonNhap nh ? nh.NhaCungCap.MaDoiTac : (hoaDon as HoaDonXuat).KhachHang.MaDoiTac);
                cmd.Parameters.AddWithValue("@TenDoiTac", hoaDon is HoaDonNhap nh2 ? nh2.NhaCungCap.Ten : (hoaDon as HoaDonXuat).KhachHang.Ten);
                cmd.Parameters.AddWithValue("@SoDienThoai", hoaDon is HoaDonNhap nh3 ? nh3.NhaCungCap.SoDienThoai : (hoaDon as HoaDonXuat).KhachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", hoaDon.DiaChi);
                cmd.Parameters.AddWithValue("@TienGiam", hoaDon.TienGiam);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan);
                cmd.Parameters.AddWithValue("@LoaiHoaDon", hoaDon.loaiHoaDon_toByte());
                cmd.Parameters.AddWithValue("@TongTien", hoaDon.TienThanhToan);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool deleteHoaDon(string maHoaDon)
        {
            string queryChiTiet = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            string queryHoaDon = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            try
            {
                this.myDatabase.OpenConnection();
                using (SqlTransaction transaction = this.myDatabase.Connection.BeginTransaction())
                {
                    SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, this.myDatabase.Connection, transaction);
                    cmdChiTiet.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdChiTiet.ExecuteNonQuery();
                    SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, this.myDatabase.Connection, transaction);
                    cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    int result = cmdHoaDon.ExecuteNonQuery();
                    transaction.Commit();
                    this.myDatabase.CloseConnection();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<HoaDon> searchByKey(string key)
        {
            string query = @"SELECT * FROM HoaDon WHERE MaHoaDon LIKE @key OR TenDoiTac LIKE @key OR SoDienThoai LIKE @key";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon;
                    byte loaiHoaDon = reader.GetByte(reader.GetOrdinal("LoaiHoaDon"));
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            KhachHang = new KhachHang { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            NhaCungCap = new NhaCungCap { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    hoaDons.Add(hoaDon);
                }
                this.myDatabase.CloseConnection();
                if (hoaDons.Count > 0)
                {
                    for (int i = 0; i < hoaDons.Count; i++)
                    {
                        hoaDons[i].ChiTiets = getChiTietHoaDon(hoaDons[i].MaHoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoaDons;
        }

        public List<HoaDon> findByLoaiHoaDon(byte loaiHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE LoaiHoaDon = @LoaiHoaDon";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@LoaiHoaDon", loaiHoaDon);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon;
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            KhachHang = new KhachHang { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            NhaCungCap = new NhaCungCap { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    hoaDons.Add(hoaDon);
                }
                this.myDatabase.CloseConnection();
                if (hoaDons.Count > 0)
                {
                    for (int i = 0; i < hoaDons.Count; i++)
                    {
                        hoaDons[i].ChiTiets = getChiTietHoaDon(hoaDons[i].MaHoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoaDons;
        }

        public List<HoaDon> findByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM HoaDon WHERE ThoiGianLap BETWEEN @StartDate AND @EndDate";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon;
                    byte loaiHoaDon = reader.GetByte(reader.GetOrdinal("LoaiHoaDon"));
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            KhachHang = new KhachHang { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            NhaCungCap = new NhaCungCap { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    hoaDons.Add(hoaDon);
                }
                this.myDatabase.CloseConnection();
                if (hoaDons.Count > 0)
                {
                    for (int i = 0; i < hoaDons.Count; i++)
                    {
                        hoaDons[i].ChiTiets = getChiTietHoaDon(hoaDons[i].MaHoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoaDons;
        }

        public List<HoaDon> findByDoiTac(string maDoiTac)
        {
            string query = "SELECT * FROM HoaDon WHERE MaDoiTac = @MaDoiTac";
            List<HoaDon> hoaDons = new List<HoaDon>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon;
                    byte loaiHoaDon = reader.GetByte(reader.GetOrdinal("LoaiHoaDon"));
                    if (loaiHoaDon == 1)
                    {
                        hoaDon = new HoaDonXuat
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            KhachHang = new KhachHang { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    else
                    {
                        hoaDon = new HoaDonNhap
                        {
                            MaHoaDon = reader["MaHoaDon"].ToString(),
                            ThoiGianLap = reader.GetDateTime(reader.GetOrdinal("ThoiGianLap")),
                            DiaChi = reader["DiaChi"].ToString(),
                            TienGiam = (double)reader.GetDecimal(reader.GetOrdinal("TienGiam")),
                            PhuongThucThanhToan = reader.GetByte(reader.GetOrdinal("PhuongThucThanhToan")),
                            TienThanhToan = (double)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            NhaCungCap = new NhaCungCap { MaDoiTac = reader["MaDoiTac"]?.ToString() }
                        };
                    }
                    hoaDons.Add(hoaDon);
                }
                this.myDatabase.CloseConnection();
                if (hoaDons.Count > 0)
                {
                    for (int i = 0; i < hoaDons.Count; i++)
                    {
                        hoaDons[i].ChiTiets = getChiTietHoaDon(hoaDons[i].MaHoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoaDons;
        }
    }
}

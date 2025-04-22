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
    internal class ChiTietService : IChiTietService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IVatLieuService vatLieuService = new VatLieuService();
        public List<ChiTiet> GetChiTietHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            List<ChiTiet> chiTiets = new List<ChiTiet>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                SqlDataReader reader = cmd.ExecuteReader();
                ChiTiet chiTiet;
                while (reader.Read())
                {
                    chiTiet = new ChiTiet();
                    chiTiet.VatLieu = this.vatLieuService.findByMaVatLieu(reader["MaVatLieu"].ToString());
                    chiTiet.SoLuong = float.Parse(reader["SoLuong"].ToString());
                    chiTiets.Add(chiTiet);
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
            return chiTiets;
        }

        public bool insertChiTietHoaDon(string maHoaDon, ChiTiet chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaVatLieu, SoLuong, TenVatLieu, GiaNhap, GiaXuat, DonVi, NgayNhap, NhaCungCap, DirHinhAnh) "
                            + "VALUES (@MaHoaDon, @MaVatLieu, @SoLuong, @TenVatLieu, @GiaNhap, @GiaXuat, @DonVi, @NgayNhap, @NhaCungCap, @DirHinhAnh)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@MaVatLieu", chiTiet.VatLieu.MaVatLieu);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@TenVatLieu", chiTiet.VatLieu.Ten);
                cmd.Parameters.AddWithValue("@GiaNhap", chiTiet.VatLieu.GiaNhap);
                cmd.Parameters.AddWithValue("@GiaXuat", chiTiet.VatLieu.GiaXuat);
                cmd.Parameters.AddWithValue("@DonVi", chiTiet.VatLieu.DonVi);
                cmd.Parameters.AddWithValue("@NgayNhap", chiTiet.VatLieu.NgayNhap);
                cmd.Parameters.AddWithValue("@NhaCungCap",
                chiTiet.VatLieu.NhaCungCap != null ? (object)chiTiet.VatLieu.NhaCungCap.MaDoiTac : DBNull.Value);
                cmd.Parameters.AddWithValue("@DirHinhAnh", chiTiet.VatLieu.DirHinhAnh);
                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch(Exception ex)
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

        public List<ChiTiet> getChiTietTraHangByPhieu(string maPhieu)
        {
            List<ChiTiet> chiTiets = new List<ChiTiet>();
            string query = "SELECT * FROM ChiTietTraHang WHERE MaPhieuTraHang = @MaPhieu";
            try
            {
                myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();
                ChiTiet ct;
                while (reader.Read())
                {
                    ct = new ChiTiet
                    {
                        VatLieu = vatLieuService.findByMaVatLieu(reader["MaVatLieu"].ToString()),
                        SoLuong = float.Parse(reader["SoLuong"].ToString())
                    };
                    chiTiets.Add(ct);
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

            return chiTiets;
        }

        public bool insertChiTietTraHang(string maPhieu, ChiTiet chiTiet)
        {
            SqlTransaction transaction = null;
            string query = @"INSERT INTO ChiTietTraHang 
                     (MaPhieuTraHang, MaVatLieu, SoLuong, TenVatLieu, GiaNhap, GiaXuat, DonVi, NgayNhap, NhaCungCap, DirHinhAnh) 
                     VALUES (@MaPhieu, @MaVatLieu, @SoLuong, @TenVatLieu, @GiaNhap, @GiaXuat, @DonVi, @NgayNhap, @NhaCungCap, @DirHinhAnh)";

            int affectedRows = 0;

            try
            {
                myDatabase.OpenConnection();
                transaction = myDatabase.Connection.BeginTransaction();

                SqlCommand cmd = new SqlCommand(query, myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmd.Parameters.AddWithValue("@MaVatLieu", chiTiet.VatLieu.MaVatLieu);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@TenVatLieu", chiTiet.VatLieu.Ten);
                cmd.Parameters.AddWithValue("@GiaNhap", chiTiet.VatLieu.GiaNhap);
                cmd.Parameters.AddWithValue("@GiaXuat", chiTiet.VatLieu.GiaXuat);
                cmd.Parameters.AddWithValue("@DonVi", chiTiet.VatLieu.DonVi);
                cmd.Parameters.AddWithValue("@NgayNhap", chiTiet.VatLieu.NgayNhap);
                cmd.Parameters.AddWithValue("@NhaCungCap", chiTiet.VatLieu.NhaCungCap);
                cmd.Parameters.AddWithValue("@DirHinhAnh", chiTiet.VatLieu.DirHinhAnh);

                affectedRows = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }

            return affectedRows > 0;
        }

    }
}

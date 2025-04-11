using QuanLyCuaHangVatLieuXayDung.utilities;
using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service.impl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangVatLieuXayDung.config;
using System.IO;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel.Design;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class VatLieuService : IVatLieuService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private IDoiTacService doiTacService = new DoiTacService();
        public bool deleteVatLieu(VatLieu vatLieu)
        {
            string query = "DELETE FROM VatLieu WHERE MaVatLieu=@MaVatLieu";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            bool result = false;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    if (new FileUtility().DeleteFolder(vatLieu.DirHinhAnh))
                    {
                        transaction.Commit();
                        result = true;
                    }
                    else
                    {
                        transaction.Rollback();
                        result = false;
                        MessageBox.Show("Error: Unable to delete image folder", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
        public List<VatLieu> findAll()
        {
            string query = "SELECT * FROM VatLieu";
            List<VatLieu> vatLieus = new List<VatLieu>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                VatLieu vatLieu;
                while (reader.Read())
                {
                    vatLieu = new VatLieu();
                    vatLieu.MaVatLieu = reader["MaVatLieu"].ToString();
                    vatLieu.Ten = reader["ten"].ToString();
                    vatLieu.DonVi = reader["DonVi"].ToString();
                    vatLieu.GiaNhap = double.Parse(reader["GiaNhap"].ToString());
                    vatLieu.GiaXuat = double.Parse(reader["GiaXuat"].ToString());
                    vatLieu.NgayNhap = DateTime.Parse(reader["NgayNhap"].ToString());
                    vatLieu.DirHinhAnh = reader["DirHinhAnh"].ToString();
                    vatLieu.SoLuong = float.Parse(reader["SoLuong"].ToString());
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                    vatLieus.Add(vatLieu);
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
            return vatLieus;
        }

        public VatLieu findByMaVatLieu(string maVatLieu)
        {
            string query = "SELECT * FROM VatLieu WHERE MaVatLieu=@MaVatLieu";
            VatLieu vatLieu = null;
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", maVatLieu);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    vatLieu = new VatLieu();
                    vatLieu.MaVatLieu = reader["MaVatLieu"].ToString();
                    vatLieu.Ten = reader["ten"].ToString();
                    vatLieu.DonVi = reader["DonVi"].ToString();
                    vatLieu.GiaNhap = double.Parse(reader["GiaNhap"].ToString());
                    vatLieu.GiaXuat = double.Parse(reader["GiaXuat"].ToString());
                    vatLieu.NgayNhap = DateTime.Parse(reader["NgayNhap"].ToString());
                    vatLieu.DirHinhAnh = reader["DirHinhAnh"].ToString();
                    vatLieu.SoLuong = float.Parse(reader["SoLuong"].ToString());
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
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
            return vatLieu;
        }

        public bool insertVatLieu(VatLieu vatLieu)
        {
            string query = @"INSERT INTO VatLieu (MaVatLieu, ten, DonVi, GiaNhap, GiaXuat, NgayNhap, DirHinhAnh, NhaCungCap, SoLuong) 
                            VALUES (@MaVatLieu, @ten, @DonVi, @GiaNhap, @GiaXuat, @NgayNhap, @DirHinhAnh, @NhaCungCap, @Soluong)";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            bool result = false;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                cmd.Parameters.AddWithValue("@ten", vatLieu.Ten);
                cmd.Parameters.AddWithValue("@DonVi", vatLieu.DonVi);
                cmd.Parameters.AddWithValue("@GiaNhap", vatLieu.GiaNhap);
                cmd.Parameters.AddWithValue("@GiaXuat", vatLieu.GiaXuat);
                cmd.Parameters.AddWithValue("@NgayNhap", vatLieu.NgayNhap);
                cmd.Parameters.AddWithValue("@DirHinhAnh", vatLieu.DirHinhAnh);
                cmd.Parameters.AddWithValue("@NhaCungCap", vatLieu.NhaCungCap.MaDoiTac);
                cmd.Parameters.AddWithValue("@Soluong", vatLieu.SoLuong);
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
         
        public List<VatLieu> searchByKey(string key)
        {
            string query = "SELECT * FROM VatLieu WHERE MaVatLieu LIKE @key OR ten LIKE @key";
            List<VatLieu> vatLieus = new List<VatLieu>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                VatLieu vatLieu;
                while (reader.Read())
                {
                    vatLieu = new VatLieu();
                    vatLieu.MaVatLieu = reader["MaVatLieu"].ToString();
                    vatLieu.Ten = reader["ten"].ToString();
                    vatLieu.DonVi = reader["DonVi"].ToString();
                    vatLieu.GiaNhap = double.Parse(reader["GiaNhap"].ToString());
                    vatLieu.GiaXuat = double.Parse(reader["GiaXuat"].ToString());
                    vatLieu.NgayNhap = DateTime.Parse(reader["NgayNhap"].ToString());
                    vatLieu.DirHinhAnh = reader["DirHinhAnh"].ToString();
                    vatLieu.SoLuong = float.Parse(reader["SoLuong"].ToString());
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                    vatLieus.Add(vatLieu);
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
            return vatLieus;
        }

        public bool updateVatLieu(VatLieu vatLieu)
        {
            string query = @"UPDATE VatLieu SET ten=@ten, DonVi=@DonVi, GiaNhap=@GiaNhap, GiaXuat=@GiaXuat, "
                                + "NgayNhap=@NgayNhap, NhaCungCap=@NhaCungCap, DirHinhAnh=@DirHinhAnh, SoLuong = @SoLuong "
                                + "WHERE MaVatLieu=@MaVatLieu";
            SqlTransaction transaction = null;
            int affectedRows = 0;
            try
            {
                this.myDatabase.OpenConnection();
                transaction = this.myDatabase.Connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection, transaction);
                cmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                cmd.Parameters.AddWithValue("@ten", vatLieu.Ten);
                cmd.Parameters.AddWithValue("@DonVi", vatLieu.DonVi);
                cmd.Parameters.AddWithValue("@GiaNhap", vatLieu.GiaNhap);   
                cmd.Parameters.AddWithValue("@GiaXuat", vatLieu.GiaXuat);
                cmd.Parameters.AddWithValue("@NgayNhap", vatLieu.NgayNhap);
                cmd.Parameters.AddWithValue("@NhaCungCap", vatLieu.NhaCungCap.MaDoiTac);
                cmd.Parameters.AddWithValue("@DirHinhAnh", vatLieu.DirHinhAnh);
                cmd.Parameters.AddWithValue("@SoLuong", vatLieu.SoLuong);  
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

        public List<VatLieu> findVatLieuByNhaCungCap(string maNhaCungCap)
        {
            string query = "SELECT * FROM VatLieu WHERE NhaCungCap=@NhaCungCap";
            List<VatLieu> vatLieus = new List<VatLieu>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@NhaCungCap", maNhaCungCap);
                SqlDataReader reader = cmd.ExecuteReader();
                VatLieu vatLieu;
                while (reader.Read())
                {
                    vatLieu = new VatLieu();
                    vatLieu.MaVatLieu = reader["MaVatLieu"].ToString();
                    vatLieu.Ten = reader["ten"].ToString();
                    vatLieu.DonVi = reader["DonVi"].ToString();
                    vatLieu.GiaNhap = double.Parse(reader["GiaNhap"].ToString());
                    vatLieu.GiaXuat = double.Parse(reader["GiaXuat"].ToString());
                    vatLieu.NgayNhap = DateTime.Parse(reader["NgayNhap"].ToString());
                    vatLieu.DirHinhAnh = reader["DirHinhAnh"].ToString();
                    vatLieu.SoLuong = float.Parse(reader["SoLuong"].ToString());
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                    vatLieus.Add(vatLieu);
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
            return vatLieus;
        }

        public List<VatLieu> findAllSortedByClosestDate()
        {
            string query = "SELECT * FROM VatLieu ORDER BY NgayNhap DESC";
            List<VatLieu> vatLieus = new List<VatLieu>();
            try
            {
                this.myDatabase.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                VatLieu vatLieu;
                while (reader.Read())
                {
                    vatLieu = new VatLieu();
                    vatLieu.MaVatLieu = reader["MaVatLieu"].ToString();
                    vatLieu.Ten = reader["ten"].ToString();
                    vatLieu.DonVi = reader["DonVi"].ToString();
                    vatLieu.GiaNhap = double.Parse(reader["GiaNhap"].ToString());
                    vatLieu.GiaXuat = double.Parse(reader["GiaXuat"].ToString());
                    vatLieu.NgayNhap = DateTime.Parse(reader["NgayNhap"].ToString());
                    vatLieu.DirHinhAnh = reader["DirHinhAnh"].ToString();
                    vatLieu.SoLuong = float.Parse(reader["SoLuong"].ToString());
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                    vatLieus.Add(vatLieu);
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
            return vatLieus;
        }
    }
}

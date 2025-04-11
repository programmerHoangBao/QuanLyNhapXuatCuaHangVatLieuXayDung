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

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class VatLieuService : IVatLieuService
    {
        private MyDatabase myDatabase = new MyDatabase();
        private FileUtility fileUntility = new FileUtility();
        private IDoiTacService doiTacService = new DoiTacService();
        private IKhoService khoService = new KhoService();
        public bool deleteVatLieu(VatLieu vatLieu)
        {
            string query = "DELETE FROM VatLieu WHERE MaVatLieu=@MaVatLieu";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                if (result > 0)
                {
                    this.fileUntility.DeleteFolder(vatLieu.DirHinhAnh);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public List<(Kho kho, float soLuong)> getTonKho(string maVatLieu)
        {
            List<(Kho kho, float soLuong)> tonKhos = new List<(Kho kho, float soLuong)>();
            string query = "SELECT TonKho.MaKho, TonKho.SoLuong FROM TonKho WHERE TonKho.MaVatLieu=@MaVatLieu";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", maVatLieu);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                Kho kho;
                while (reader.Read())
                {
                    kho = this.khoService.findByMaKho(reader["MaKho"].ToString());
                    float soLuong = float.Parse(reader["SoLuong"].ToString());
                    tonKhos.Add((kho, soLuong));
                }
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tonKhos;
        }
        public List<VatLieu> findAll()
        {
            string query = "SELECT * FROM VatLieu";
            List<VatLieu> vatLieus = new List<VatLieu>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
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
                    vatLieu.DirHinhAnh = reader["HinhAnh"].ToString();
                    vatLieu.HinhAnhPaths = this.fileUntility.GetImagePathsFromFolder(vatLieu.DirHinhAnh); /*Lấy ra danh sách đường dẫn hình ảnh*/
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                    vatLieus.Add(vatLieu);
                }
                this.myDatabase.CloseConnection();
                for (int i = 0; i < vatLieus.Count; i++)
                {
                    vatLieus[i].TonKhos = this.getTonKho(vatLieus[i].MaVatLieu); /*Lấy ra danh sách kho và số lượng tồn kho*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return vatLieus;
        }

        public VatLieu findByMaVatLieu(string maVatLieu)
        {
            string query = "SELECT * FROM VatLieu WHERE MaVatLieu=@MaVatLieu";
            VatLieu vatLieu = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", maVatLieu);
                this.myDatabase.OpenConnection();
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
                    vatLieu.DirHinhAnh = reader["HinhAnh"].ToString();
                    vatLieu.HinhAnhPaths = this.fileUntility.GetImagePathsFromFolder(vatLieu.DirHinhAnh); /*Lấy ra danh sách đường dẫn hình ảnh*/
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                }
                this.myDatabase.CloseConnection();
                if (vatLieu != null)
                {
                    vatLieu.TonKhos = this.getTonKho(vatLieu.MaVatLieu); /*Lấy ra danh sách kho và số lượng tồn kho*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return vatLieu;
        }

        public bool insertVatLieu(VatLieu vatLieu)
        {
            string query_VatLieu = @"INSERT INTO VatLieu (MaVatLieu, ten, DonVi, GiaNhap, GiaXuat, NgayNhap, HinhAnh, NhaCungCap) 
                            VALUES (@MaVatLieu, @ten, @DonVi, @GiaNhap, @GiaXuat, @NgayNhap, @HinhAnh, @NhaCungCap)";
            string query_TonKho = @"INSERT INTO TonKho (MaVatLieu, MaKho, SoLuong) 
                            VALUES (@MaVatLieu, @MaKho, @SoLuong)";
            try
            {
                SqlCommand cmd = new SqlCommand(query_VatLieu, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                cmd.Parameters.AddWithValue("@ten", vatLieu.Ten);
                cmd.Parameters.AddWithValue("@DonVi", vatLieu.DonVi);
                cmd.Parameters.AddWithValue("@GiaNhap", vatLieu.GiaNhap);
                cmd.Parameters.AddWithValue("@GiaXuat", vatLieu.GiaXuat);
                cmd.Parameters.AddWithValue("@NgayNhap", vatLieu.NgayNhap);
                vatLieu.DirHinhAnh = new FormApp().VATLIEU_DATA + "\\" + vatLieu.MaVatLieu + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"); /*Tạo thư mục lưu hình ảnh theo mã vật liệu và thời gian hiện tại*/
                foreach (string hinhAnhPath in vatLieu.HinhAnhPaths)
                {
                    this.fileUntility.SaveImages(hinhAnhPath, vatLieu.DirHinhAnh); /*Lưu hình ảnh vào thư mục*/
                }
                cmd.Parameters.AddWithValue("@HinhAnh", vatLieu.DirHinhAnh);
                cmd.Parameters.AddWithValue("@NhaCungCap", vatLieu.NhaCungCap.MaDoiTac);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    foreach (var tonKho in vatLieu.TonKhos)
                    {
                        SqlCommand cmdTonKho = new SqlCommand(query_TonKho, this.myDatabase.Connection);
                        cmdTonKho.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                        cmdTonKho.Parameters.AddWithValue("@MaKho", tonKho.kho.MaKho);
                        cmdTonKho.Parameters.AddWithValue("@SoLuong", tonKho.soLuong);
                        result = cmdTonKho.ExecuteNonQuery();
                    }
                    this.myDatabase.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
                    vatLieu.DirHinhAnh = reader["HinhAnh"].ToString();
                    vatLieu.HinhAnhPaths = this.fileUntility.GetImagePathsFromFolder(vatLieu.DirHinhAnh); /*Lấy ra danh sách đường dẫn hình ảnh*/
                    vatLieu.NhaCungCap = (NhaCungCap)this.doiTacService.findByMaDoiTac(reader["NhaCungCap"].ToString());
                    vatLieus.Add(vatLieu);
                }
                this.myDatabase.CloseConnection();
                if (vatLieus.Count > 0)
                {
                    for (int i = 0; i < vatLieus.Count; i++)
                    {
                        vatLieus[i].TonKhos = this.getTonKho(vatLieus[i].MaVatLieu); /*Lấy ra danh sách kho và số lượng tồn kho*/
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return vatLieus;
        }

        public bool updateVatLieu(VatLieu vatLieu)
        {
            string query = @"UPDATE VatLieu SET ten=@ten, DonVi=@DonVi, GiaNhap=@GiaNhap, GiaXuat=@GiaXuat, NgayNhap=@NgayNhap, NhaCungCap=@NhaCungCap WHERE MaVatLieu=@MaVatLieu";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", vatLieu.MaVatLieu);
                cmd.Parameters.AddWithValue("@ten", vatLieu.Ten);
                cmd.Parameters.AddWithValue("@DonVi", vatLieu.DonVi);
                cmd.Parameters.AddWithValue("@GiaNhap", vatLieu.GiaNhap);   
                cmd.Parameters.AddWithValue("@GiaXuat", vatLieu.GiaXuat);
                cmd.Parameters.AddWithValue("@NgayNhap", vatLieu.NgayNhap);
                cmd.Parameters.AddWithValue("@NhaCungCap", vatLieu.NhaCungCap.MaDoiTac);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                if (result > 0)
                {
                    foreach (var (kho, soLuong) in vatLieu.TonKhos)
                    {
                        this.updateTonKho(vatLieu.MaVatLieu, kho.MaKho, soLuong);
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool updateTonKho(string maVatLieu, string maKho, float soLuong)
        {
            string query = "UPDATE TonKho SET MaKho=@MaKho, SoLuong=@SoLuong WHERE MaVatLieu=@MaVatLieu";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", maVatLieu);
                cmd.Parameters.AddWithValue("@MaKho", maKho);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                this.myDatabase.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                this.myDatabase.CloseConnection();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public float totalSoLuong(string maVatLieu)
        {
            string query = "SELECT SUM(SoLuong) FROM TonKho WHERE MaVatLieu=@MaVatLieu";
            float total = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@MaVatLieu", maVatLieu);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    total = float.Parse(reader[0].ToString());
                }
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return total;
        }
    }
}

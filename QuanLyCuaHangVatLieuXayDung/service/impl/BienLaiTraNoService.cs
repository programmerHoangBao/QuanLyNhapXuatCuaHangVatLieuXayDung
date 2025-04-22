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
    internal class BienLaiTraNoService : IBienLaiTraNoService
    {
        private readonly MyDatabase myDatabase = new MyDatabase();
        private readonly IDoiTacService doiTacService = new DoiTacService();

        public List<BienLaiTraNo> FindAll()
        {
            string query = @"SELECT bl.MaBienLai, bl.ThoiGianTra, bl.TienTra, bl.MaPhieuGhiNo, 
                            pn.TenDoiTac, pn.SoDienThoai, pn.DiaChi, pn.LoaiPhieu
                            FROM BienLaiTraNo bl
                            JOIN PhieuGhiNo pn ON bl.MaPhieuGhiNo = pn.MaPhieu";
            List<BienLaiTraNo> bienLaiTraNos = new List<BienLaiTraNo>();
            try
            {
                myDatabase.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BienLaiTraNo bienLai = new BienLaiTraNo
                        {
                            MaBienLai = reader["MaBienLai"].ToString(),
                            ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString()),
                            TienTra = double.Parse(reader["TienTra"].ToString()),
                            MaPhieuGhiNo = reader["MaPhieuGhiNo"].ToString(),
                            TenDoiTac = reader["TenDoiTac"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            LoaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString())
                        };
                        bienLaiTraNos.Add(bienLai);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return bienLaiTraNos;
        }

        public BienLaiTraNo FindByMaBienLai(string maBienLai)
        {
            if (string.IsNullOrWhiteSpace(maBienLai))
            {
                return null;
            }

            string query = @"SELECT bl.MaBienLai, bl.ThoiGianTra, bl.TienTra, bl.MaPhieuGhiNo, 
                            pn.TenDoiTac, pn.SoDienThoai, pn.DiaChi, pn.LoaiPhieu
                            FROM BienLaiTraNo bl
                            JOIN PhieuGhiNo pn ON bl.MaPhieuGhiNo = pn.MaPhieu
                            WHERE bl.MaBienLai = @MaBienLai";
            BienLaiTraNo bienLai = null;
            try
            {
                myDatabase.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@MaBienLai", maBienLai);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bienLai = new BienLaiTraNo
                        {
                            MaBienLai = reader["MaBienLai"].ToString(),
                            ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString()),
                            TienTra = double.Parse(reader["TienTra"].ToString()),
                            MaPhieuGhiNo = reader["MaPhieuGhiNo"].ToString(),
                            TenDoiTac = reader["TenDoiTac"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            LoaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString())
                        };
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return bienLai;
        }

        public List<BienLaiTraNo> SearchByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return new List<BienLaiTraNo>();
            }

            string query = @"SELECT bl.MaBienLai, bl.ThoiGianTra, bl.TienTra, bl.MaPhieuGhiNo, 
                            pn.TenDoiTac, pn.SoDienThoai, pn.DiaChi, pn.LoaiPhieu
                            FROM BienLaiTraNo bl
                            JOIN PhieuGhiNo pn ON bl.MaPhieuGhiNo = pn.MaPhieu
                            WHERE bl.MaBienLai LIKE @Key 
                               OR bl.MaPhieuGhiNo LIKE @Key 
                               OR pn.TenDoiTac LIKE @Key 
                               OR pn.SoDienThoai LIKE @Key";
            List<BienLaiTraNo> bienLaiTraNos = new List<BienLaiTraNo>();
            try
            {
                myDatabase.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@Key", "%" + key.Trim() + "%");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BienLaiTraNo bienLai = new BienLaiTraNo
                        {
                            MaBienLai = reader["MaBienLai"].ToString(),
                            ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString()),
                            TienTra = double.Parse(reader["TienTra"].ToString()),
                            MaPhieuGhiNo = reader["MaPhieuGhiNo"].ToString(),
                            TenDoiTac = reader["TenDoiTac"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            LoaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString())
                        };
                        bienLaiTraNos.Add(bienLai);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm biên lai trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return bienLaiTraNos;
        }

        public List<BienLaiTraNo> FindByLoaiPhieu(byte loaiPhieu)
        {
            string query = @"SELECT bl.MaBienLai, bl.ThoiGianTra, bl.TienTra, bl.MaPhieuGhiNo, 
                            pn.TenDoiTac, pn.SoDienThoai, pn.DiaChi, pn.LoaiPhieu
                            FROM BienLaiTraNo bl
                            JOIN PhieuGhiNo pn ON bl.MaPhieuGhiNo = pn.MaPhieu
                            WHERE pn.LoaiPhieu = @LoaiPhieu";
            List<BienLaiTraNo> bienLaiTraNos = new List<BienLaiTraNo>();
            try
            {
                myDatabase.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, myDatabase.Connection))
                {
                    cmd.Parameters.AddWithValue("@LoaiPhieu", loaiPhieu);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BienLaiTraNo bienLai = new BienLaiTraNo
                        {
                            MaBienLai = reader["MaBienLai"].ToString(),
                            ThoiGianTra = DateTime.Parse(reader["ThoiGianTra"].ToString()),
                            TienTra = double.Parse(reader["TienTra"].ToString()),
                            MaPhieuGhiNo = reader["MaPhieuGhiNo"].ToString(),
                            TenDoiTac = reader["TenDoiTac"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            LoaiPhieu = byte.Parse(reader["LoaiPhieu"].ToString())
                        };
                        bienLaiTraNos.Add(bienLai);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc biên lai trả nợ theo loại phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDatabase.CloseConnection();
            }
            return bienLaiTraNos;
        }
    }
}

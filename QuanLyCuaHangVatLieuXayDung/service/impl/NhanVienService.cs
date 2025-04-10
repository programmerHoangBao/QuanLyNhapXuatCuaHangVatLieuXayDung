using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class NhanVienService : INhanVienService
    {
        private MyDatabase myDatabase = new MyDatabase();

        // Thêm nhân viên (có transaction)
        public bool insertnhanVien(NhanVien nv)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO NHAN_VIEN (MaNV, Ten, SoDienThoai, DiaChi, VaiTro, Email, LuongTrenNgay) " +
                        "VALUES (@MaNV, @Ten, @SDT, @DiaChi, @VaiTro, @Email, @Luong)", conn, transaction);

                    command.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
                    command.Parameters.AddWithValue("@Ten", nv.Ten);
                    command.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
                    command.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                    command.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
                    command.Parameters.AddWithValue("@Email", nv.Email);
                    command.Parameters.AddWithValue("@Luong", nv.LuongTrenNgay);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // Cập nhật nhân viên (có transaction)
        public bool updatenhanVien(NhanVien nv)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand(
                        "UPDATE NHAN_VIEN SET Ten = @Ten, SoDienThoai = @SDT, DiaChi = @DiaChi, VaiTro = @VaiTro, " +
                        "Email = @Email, LuongTrenNgay = @Luong WHERE MaNV = @MaNV", conn, transaction);

                    command.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
                    command.Parameters.AddWithValue("@Ten", nv.Ten);
                    command.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
                    command.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                    command.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
                    command.Parameters.AddWithValue("@Email", nv.Email);
                    command.Parameters.AddWithValue("@Luong", nv.LuongTrenNgay);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // Xóa nhân viên (có transaction)
        public bool deletenhanVien(string maNV)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM NHAN_VIEN WHERE MaNV = @MaNV", conn, transaction);
                    command.Parameters.AddWithValue("@MaNV", maNV);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // Lấy danh sách nhân viên (không cần transaction)
        public DataTable getallNhanVien()
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM NHAN_VIEN", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        // Chấm công (có transaction)
        public bool ChamCong(string maNV)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO BANG_CHAM_CONG (MaNV, ThoiGianChamCong) VALUES (@MaNV, @ThoiGian)", conn, transaction);
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    command.Parameters.AddWithValue("@ThoiGian", DateTime.Now);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // Tính tổng lương nhân viên
        public double TinhTongLuong(string maNV)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM BANG_CHAM_CONG WHERE MaNV = @MaNV", conn);
                command.Parameters.AddWithValue("@MaNV", maNV);

                conn.Open();
                int soNgayCong = (int)command.ExecuteScalar();
                double luongTrenNgay = LayLuongTrenNgay(maNV);
                return soNgayCong * luongTrenNgay;
            }
        }

        // Tính lương theo tháng
        public double TinhLuongTheoThang(string maNV, int thang, int nam)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM BANG_CHAM_CONG WHERE MaNV = @MaNV AND MONTH(ThoiGianChamCong) = @Thang AND YEAR(ThoiGianChamCong) = @Nam", conn);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@Thang", thang);
                command.Parameters.AddWithValue("@Nam", nam);

                conn.Open();
                int soNgayCong = (int)command.ExecuteScalar();
                double luongTrenNgay = LayLuongTrenNgay(maNV);
                return soNgayCong * luongTrenNgay;
            }
        }

        // Tính lương theo năm
        public double TinhLuongTheoNam(string maNV, int nam)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM BANG_CHAM_CONG WHERE MaNV = @MaNV AND YEAR(ThoiGianChamCong) = @Nam", conn);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@Nam", nam);

                conn.Open();
                int soNgayCong = (int)command.ExecuteScalar();
                double luongTrenNgay = LayLuongTrenNgay(maNV);
                return soNgayCong * luongTrenNgay;
            }
        }

        private double LayLuongTrenNgay(string maNV)
        {
            using (SqlConnection conn = myDatabase.Connection)
            {
                SqlCommand command = new SqlCommand("SELECT LuongTrenNgay FROM NHAN_VIEN WHERE MaNV = @MaNV", conn);
                command.Parameters.AddWithValue("@MaNV", maNV);

                conn.Open();
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToDouble(result) : 0;
            }
        }
    }
}

using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

internal class NhanVienService : INhanVienService
{
    private MyDatabase myDatabase = new MyDatabase();

    public bool insertnhanVien(NhanVien nv)
    {
        string query = "INSERT INTO NhanVien (MaNhanVien, Ten, SoDienThoai, DiaChi, VaiTro, Email, LuongTrenNgay) " +
                       "VALUES (@MaNV, @Ten, @SDT, @DiaChi, @VaiTro, @Email, @Luong)";
        SqlTransaction transaction = null;
        int rowsAffected = 0;

        try
        {
            this.myDatabase.OpenConnection();
            transaction = myDatabase.Connection.BeginTransaction();

            SqlCommand command = new SqlCommand(query, this.myDatabase.Connection, transaction);
            command.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
            command.Parameters.AddWithValue("@Ten", nv.Ten);
            command.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
            command.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            command.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
            command.Parameters.AddWithValue("@Email", nv.Email);
            command.Parameters.AddWithValue("@Luong", nv.LuongTrenNgay);

            rowsAffected = command.ExecuteNonQuery();
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

        return rowsAffected > 0;
    }

    public bool updatenhanVien(NhanVien nv)
    {
        string query = "UPDATE NhanVien SET Ten = @Ten, SoDienThoai = @SDT, DiaChi = @DiaChi, VaiTro = @VaiTro, " +
                       "Email = @Email, LuongTrenNgay = @Luong WHERE MaNhanVien = @MaNV";
        SqlTransaction transaction = null;
        int rowsAffected = 0;

        try
        {
            this.myDatabase.OpenConnection();
            transaction = myDatabase.Connection.BeginTransaction();

            SqlCommand command = new SqlCommand(query, this.myDatabase.Connection, transaction);
            command.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
            command.Parameters.AddWithValue("@Ten", nv.Ten);
            command.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
            command.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            command.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
            command.Parameters.AddWithValue("@Email", nv.Email);
            command.Parameters.AddWithValue("@Luong", nv.LuongTrenNgay);

            rowsAffected = command.ExecuteNonQuery();
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

        return rowsAffected > 0;
    }

    public bool deletenhanVien(string maNV)
    {
        string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNV";
        SqlTransaction transaction = null;
        int rowsAffected = 0;

        try
        {
            myDatabase.OpenConnection();
            transaction = myDatabase.Connection.BeginTransaction();

            SqlCommand command = new SqlCommand(query, myDatabase.Connection, transaction);
            command.Parameters.AddWithValue("@MaNV", maNV);

            rowsAffected = command.ExecuteNonQuery();
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

        return rowsAffected > 0;
    }

    public List<NhanVien> findAllNhanVien()
    {
        string query = "SELECT * FROM NhanVien";
        List<NhanVien> nhanViens = new List<NhanVien>();
        try
        {
            this.myDatabase.OpenConnection();
            SqlCommand command = new SqlCommand(query, this.myDatabase.Connection);
            SqlDataReader reader = command.ExecuteReader();
            NhanVien nhanVien;
            while (reader.Read())
            {
                nhanVien = new NhanVien();
                nhanVien.MaNhanVien = reader["MaNhanVien"].ToString();
                nhanVien.Ten = reader["Ten"].ToString();
                nhanVien.SoDienThoai = reader["SoDienThoai"].ToString();
                nhanVien.DiaChi = reader["DiaChi"].ToString();
                nhanVien.VaiTro = reader["VaiTro"].ToString();
                nhanVien.Email = reader["Email"].ToString();
                nhanVien.LuongTrenNgay = double.Parse(reader["LuongTrenNgay"].ToString());
                nhanViens.Add(nhanVien);
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

        return nhanViens;
    }

    public NhanVien FindByMaNhanVien(string maNhanVien)
    {
        string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
        NhanVien nhanVien = null;
        try
        {
            this.myDatabase.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
            cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                nhanVien = new NhanVien();
                nhanVien.MaNhanVien = reader["MaNhanVien"].ToString();
                nhanVien.Ten = reader["Ten"].ToString();
                nhanVien.SoDienThoai = reader["SoDienThoai"].ToString();
                nhanVien.DiaChi = reader["DiaChi"].ToString();
                nhanVien.VaiTro = reader["VaiTro"].ToString();
                nhanVien.Email = reader["Email"].ToString();
                nhanVien.LuongTrenNgay = double.Parse(reader["LuongTrenNgay"].ToString());
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

        return nhanVien;
    }

}

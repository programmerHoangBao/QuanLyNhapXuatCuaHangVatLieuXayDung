using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.service;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

internal class NhanVienService : INhanVienService
{
    private MyDatabase myDatabase = new MyDatabase();

    public bool insertnhanVien(NhanVien nv)
    {
        string query = "INSERT INTO NHAN_VIEN (MaNV, Ten, SoDienThoai, DiaChi, VaiTro, Email, LuongTrenNgay) " +
                       "VALUES (@MaNV, @Ten, @SDT, @DiaChi, @VaiTro, @Email, @Luong)";
        SqlTransaction transaction = null;
        bool result = false;

        try
        {
            myDatabase.OpenConnection();
            transaction = myDatabase.Connection.BeginTransaction();

            SqlCommand command = new SqlCommand(query, myDatabase.Connection, transaction);
            command.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
            command.Parameters.AddWithValue("@Ten", nv.Ten);
            command.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
            command.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            command.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
            command.Parameters.AddWithValue("@Email", nv.Email);
            command.Parameters.AddWithValue("@Luong", nv.LuongTrenNgay);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                transaction.Commit();
                result = true;
            }
            else
            {
                transaction.Rollback();
            }
        }
        catch (Exception ex)
        {
            transaction?.Rollback();
            MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            myDatabase.CloseConnection();
        }

        return result;
    }

    public bool updatenhanVien(NhanVien nv)
    {
        string query = "UPDATE NHAN_VIEN SET Ten = @Ten, SoDienThoai = @SDT, DiaChi = @DiaChi, VaiTro = @VaiTro, " +
                       "Email = @Email, LuongTrenNgay = @Luong WHERE MaNV = @MaNV";
        SqlTransaction transaction = null;
        bool result = false;

        try
        {
            myDatabase.OpenConnection();
            transaction = myDatabase.Connection.BeginTransaction();

            SqlCommand command = new SqlCommand(query, myDatabase.Connection, transaction);
            command.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
            command.Parameters.AddWithValue("@Ten", nv.Ten);
            command.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
            command.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            command.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
            command.Parameters.AddWithValue("@Email", nv.Email);
            command.Parameters.AddWithValue("@Luong", nv.LuongTrenNgay);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                transaction.Commit();
                result = true;
            }
            else
            {
                transaction.Rollback();
            }
        }
        catch (Exception ex)
        {
            transaction?.Rollback();
            MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            myDatabase.CloseConnection();
        }

        return result;
    }

    public bool deletenhanVien(string maNV)
    {
        string query = "DELETE FROM NHAN_VIEN WHERE MaNV = @MaNV";
        SqlTransaction transaction = null;
        bool result = false;

        try
        {
            myDatabase.OpenConnection();
            transaction = myDatabase.Connection.BeginTransaction();

            SqlCommand command = new SqlCommand(query, myDatabase.Connection, transaction);
            command.Parameters.AddWithValue("@MaNV", maNV);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                transaction.Commit();
                result = true;
            }
            else
            {
                transaction.Rollback();
            }
        }
        catch (Exception ex)
        {
            transaction?.Rollback();
            MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            myDatabase.CloseConnection();
        }

        return result;
    }

    public DataTable getallNhanVien()
    {
        DataTable table = new DataTable();

        try
        {
            myDatabase.OpenConnection();

            SqlCommand command = new SqlCommand("SELECT * FROM NHAN_VIEN", myDatabase.Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            myDatabase.CloseConnection();
        }

        return table;
    }
}

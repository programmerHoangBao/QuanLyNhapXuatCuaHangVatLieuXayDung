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

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal class KhoService : IKhoService
    {
        private MyDatabase myDatabase = new MyDatabase();
        public bool deleteKho(Kho kho)
        {
            string query = @"DELETE FROM kho WHERE MaKho = @maKho";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@maKho", kho.MaKho);
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

        public List<Kho> findAllKho()
        {
            string query = @"SELECT * FROM Kho";
            List<Kho> listKho = new List<Kho>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                Kho kho;
                while (reader.Read())
                {
                    kho = new Kho();
                    kho.MaKho = reader["MaKho"].ToString();
                    kho.Ten = reader["Ten"].ToString();
                    kho.DiaChi = reader["DiaChi"].ToString();
                    listKho.Add(kho);
                }
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listKho;
        }

        public Kho findByMaKho(string maKho)
        {
            string query = @"SELECT * FROM kho WHERE MaKho = @maKho";
            Kho kho = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@maKho", maKho);
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    kho = new Kho();
                    kho.MaKho = reader["MaKho"].ToString();
                    kho.Ten = reader["Ten"].ToString();
                    kho.DiaChi = reader["DiaChi"].ToString();
                }
                this.myDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kho;
        }

        public bool insertKho(Kho kho)
        {
            string query = @"INSERT INTO kho(MaKho, Ten, DiaChi) VALUES(@maKho, @ten, @diaChi)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@maKho", kho.MaKho);
                cmd.Parameters.AddWithValue("@ten", kho.Ten);
                cmd.Parameters.AddWithValue("@diaChi", kho.DiaChi);
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

        public List<Kho> searchByKey(string key)
        {
            string query = @"SELECT * FROM kho WHERE MaKho LIKE @key OR Ten LIKE @key OR DiaChi LIKE @key";
            List<Kho> listKho = new List<Kho>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                this.myDatabase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                Kho kho;
                while (reader.Read())
                {
                    kho = new Kho();
                    kho.MaKho = reader["MaKho"].ToString();
                    kho.Ten = reader["Ten"].ToString();
                    kho.DiaChi = reader["DiaChi"].ToString();
                    listKho.Add(kho);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listKho;
        }

        public bool updateKho(Kho kho)
        {
            string query = @"UPDATE kho SET Ten = @ten, DiaChi = @diaChi WHERE MaKho = @maKho";
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.myDatabase.Connection);
                cmd.Parameters.AddWithValue("@maKho", kho.MaKho);
                cmd.Parameters.AddWithValue("@ten", kho.Ten);
                cmd.Parameters.AddWithValue("@diaChi", kho.DiaChi);
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
    }
}

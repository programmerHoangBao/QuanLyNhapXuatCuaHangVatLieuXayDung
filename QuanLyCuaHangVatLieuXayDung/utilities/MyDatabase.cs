using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QuanLyCuaHangVatLieuXayDung.utilities
{
    internal class MyDatabase
    {
        private SqlConnection connection;
        private string connectionString;

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public SqlConnection Connection { get => connection; set => connection = value; }

        public MyDatabase()
        {
            this.connectionString = @"Data Source=DESKTOP-QJ10S5N\BAO_SERVER;Initial Catalog=CuaHangXayDung;Integrated Security=True";
            this.connection = new SqlConnection(this.connectionString);
        }   

        public void OpenConnection()
        {
            this.connection.Open();
        }
        public void CloseConnection()
        {
            this.connection.Close();
        }

    }
}

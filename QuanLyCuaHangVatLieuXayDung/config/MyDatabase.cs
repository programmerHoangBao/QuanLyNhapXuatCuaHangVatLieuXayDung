using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QuanLyCuaHangVatLieuXayDung.config
{
    internal class MyDatabase
    {
        private SqlConnection connection;
        private string connectionString;

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public SqlConnection Connection { get => connection; set => connection = value; }

        public MyDatabase()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string configPath = Path.Combine(projectDirectory, "QuanLyCuaHangVatLieuXayDung\\config");

            var config = new ConfigurationBuilder()
            .SetBasePath(configPath)
            .AddJsonFile("appsettings.json")
            .Build();

            this.connectionString = config.GetConnectionString("DefaultConnection");
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

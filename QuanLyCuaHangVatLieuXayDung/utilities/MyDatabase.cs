using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuanLyCuaHangVatLieuXayDung.config;

namespace QuanLyCuaHangVatLieuXayDung.utilities
{
    internal class MyDatabase
    {
        private SqlConnection connection;
        public SqlConnection Connection { get => connection; set => connection = value; }

        public MyDatabase()
        {
            this.connection = new SqlConnection(new FormApp().GetConnectionString());
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

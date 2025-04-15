using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuanLyCuaHangVatLieuXayDung.config
{
    internal class FormApp
    {
        public string CUAHANGXAYDUNG_DATA { get; private set; }
        public string VATLIEU_DATA { get; private set; }
        public string DOITAC_DATA { get; private set; }
        public string TAIKHOAN_DATA { get; private set; }
        public string DATA_SOURCE { get; private set; }
        public string DATABASE { get; private set; }
        public string USER_ID { get; private set; }
        public string PASSWORD { get; private set; }

        public FormApp()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string configFilePath = Path.Combine(projectDirectory, "config", "config.json");
            var config = new ConfigurationBuilder()
                .AddJsonFile(configFilePath, optional: false, reloadOnChange: true)
                .Build();

            var folderPaths = config.GetSection("FolderPaths");
            this.CUAHANGXAYDUNG_DATA = folderPaths["CUAHANGXAYDUNG_DATA"];
            this.VATLIEU_DATA = folderPaths["VATLIEU_DATA"];
            this.DOITAC_DATA = folderPaths["DOITAC_DATA"];
            this.TAIKHOAN_DATA = folderPaths["TAIKHOAN_DATA"];

            var databaseConfig = config.GetSection("DatabaseConfig");
            this.DATA_SOURCE = databaseConfig["DATA_SOURCE"];
            this.DATABASE = databaseConfig["DATABASE"];
            this.USER_ID = databaseConfig["USER_ID"];
            this.PASSWORD = databaseConfig["PASSWORD"];
        }

        /// <summary>
        /// The SetUp method creates required directories based on predefined paths.
        /// It checks whether each directory exists and creates it if it does not.
        /// </summary>
        /// <remarks>
        /// The following directories are processed:
        /// - CUAHANGXAYDUNG_DATA: Directory for construction store data.
        /// - VATLIEU_DATA: Directory for material data.
        /// - DOITAC_DATA: Directory for partner data.
        /// - TAIKHOAN_DATA: Directory for account data.
        /// If a directory already exists or the path is invalid, a debug message is logged.
        /// </remarks>
        /// <exception cref="Exception">Throws an exception if an error occurs during directory creation.</exception>
        public void SetUp()
        {
            try
            {
                // List of required directory paths
                string[] folders = { CUAHANGXAYDUNG_DATA, VATLIEU_DATA, DOITAC_DATA, TAIKHOAN_DATA};

                foreach (string folder in folders)
                {
                    if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                        Debug.WriteLine($"✅ Directory '{folder}' was successfully created.");
                    }
                    else
                    {
                        Debug.WriteLine($"ℹ️ Directory '{folder}' already exists or the path is invalid.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ An error occurred while creating directories: {ex.Message}");
            }
        }

        /// <summary>
        /// The GetConnectionString method generates and returns the SQL Server connection string 
        /// based on the configured properties.
        /// </summary>
        /// <returns>
        /// A connection string in the format:
        /// "Data Source=&lt;ServerName&gt;;Initial Catalog=&lt;DatabaseName&gt;;User ID=&lt;UserName&gt;;Password=&lt;Password&gt;"
        /// </returns>
        /// <remarks>
        /// The following properties must be set before calling this method:
        /// - DATA_SOURCE: Name or address of the SQL Server.
        /// - DATABASE: Name of the target database.
        /// - USER_ID: SQL Server login username.
        /// - PASSWORD: Corresponding password for the USER_ID.
        /// </remarks>
        public string GetConnectionString()
        {
            string connectionString = $"Data Source={this.DATA_SOURCE};Initial Catalog={this.DATABASE};User ID={this.USER_ID};Password={this.PASSWORD}";
            //Debug.WriteLine($"ℹ️ Generated connection string: {connectionString}");
            return connectionString;
        }

    }
}

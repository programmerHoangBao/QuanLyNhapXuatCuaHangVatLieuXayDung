using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "config", "config.json");
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
        /// Phương thức SetUp tạo các thư mục cần thiết dựa trên các đường dẫn đã được định nghĩa.
        /// Nó kiểm tra xem thư mục đã tồn tại hay chưa và tạo mới nếu cần.
        /// </summary>
        /// <remarks>
        /// Các thư mục được tạo dựa trên danh sách đường dẫn sau:
        /// - CUAHANGXAYDUNG_DATA: Thư mục chứa dữ liệu cửa hàng xây dựng.
        /// - VATLIEU_DATA: Thư mục chứa dữ liệu vật liệu.
        /// - DOITAC_DATA: Thư mục chứa dữ liệu đối tác.
        /// - TAIKHOAN_DATA: Thư mục chứa dữ liệu tài khoản.
        /// Nếu thư mục đã tồn tại, phương thức sẽ ghi thông báo ra màn hình.
        /// </remarks>
        /// <exception cref="Exception">Bắt lỗi nếu xảy ra trong quá trình tạo thư mục.</exception>
        public void SetUp()
        {
            try
            {
                // Danh sách các đường dẫn cần tạo
                string[] folders = { CUAHANGXAYDUNG_DATA, VATLIEU_DATA, DOITAC_DATA, TAIKHOAN_DATA };

                foreach (string folder in folders)
                {
                    if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                        Console.WriteLine($"Thư mục '{folder}' đã được tạo thành công.");
                    }
                    else
                    {
                        Console.WriteLine($"Thư mục '{folder}' đã tồn tại hoặc đường dẫn không hợp lệ.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi khi tạo thư mục: {ex.Message}");
            }
        }

        /// <summary>
        /// Phương thức GetConnectionString tạo và trả về chuỗi kết nối (connection string) 
        /// để kết nối với cơ sở dữ liệu SQL Server.
        /// </summary>
        /// <returns>
        /// Chuỗi kết nối dạng:
        /// "Data Source=<ServerName>;Initial Catalog=<DatabaseName>;User ID=<UserName>;Password=<Password>"
        /// </returns>
        /// <remarks>
        /// Các thuộc tính cần thiết để tạo chuỗi kết nối:
        /// - DATA_SOURCE: Tên máy chủ hoặc địa chỉ máy chủ SQL Server.
        /// - DATABASE: Tên cơ sở dữ liệu.
        /// - USER_ID: Tên người dùng để đăng nhập SQL Server.
        /// - PASSWORD: Mật khẩu liên quan đến USER_ID.
        /// Đảm bảo các thuộc tính được gán giá trị trước khi gọi hàm.
        /// </remarks>

        public string GetConnectionString()
        {
            return $"Data Source={this.DATA_SOURCE};Initial Catalog={this.DATABASE};User ID={this.USER_ID};Password={this.PASSWORD}";
        }
    }
}

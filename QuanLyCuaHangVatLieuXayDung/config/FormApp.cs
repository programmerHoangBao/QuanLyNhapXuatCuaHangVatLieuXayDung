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

        public FormApp()
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory()) // Thư mục chứa file config
                            .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                            .Build();

            var folderPaths = config.GetSection("FolderPaths");
            this.CUAHANGXAYDUNG_DATA = folderPaths["CUAHANGXAYDUNG_DATA"];
            this.VATLIEU_DATA = folderPaths["VATLIEU_DATA"];
            this.DOITAC_DATA = folderPaths["DOITAC_DATA"];
            this.TAIKHOAN_DATA = folderPaths["TAIKHOAN_DATA"];

        }
        /// <summary>
        /// Phương thức SetUp tạo các thư mục cần thiết dựa trên các đường dẫn đã được định nghĩa.
        /// Nó kiểm tra xem thư mục đã tồn tại hay chưa và tạo mới nếu cần.
        /// </summary>
        /// <remarks>
        /// Các thư mục được tạo dựa trên danh sách đường dẫn sau:
        /// - CUAHANGXAYDUNG_DATA
        /// - VATLIEU_DATA
        /// - DOITAC_DATA
        /// - TAIKHOAN_DATA
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
    }
}

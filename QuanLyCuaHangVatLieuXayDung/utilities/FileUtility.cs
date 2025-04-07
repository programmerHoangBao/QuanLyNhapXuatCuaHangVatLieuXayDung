using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.utilities
{
    internal class FileUtility
    {
        public List<string> GetImagePathsFromFolder(string folderPath)
        {
            List<string> imagePaths = new List<string>();
            string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            if (!Directory.Exists(folderPath))
            {
                return imagePaths;
            }

            foreach (string file in Directory.GetFiles(folderPath))
            {
                if (Array.Exists(supportedExtensions, ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
                {
                    imagePaths.Add(file);
                }
            }
            return imagePaths;
        }
        public bool CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                return true;
            }
            return false;
        }
        public void SaveImages(string hinhAnhPath, string targetFolder)
        {
            try
            {
                // Kiểm tra nếu thư mục đích chưa tồn tại, thì tạo mới
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                    Console.WriteLine($"Thư mục '{targetFolder}' đã được tạo.");
                }
                try
                {
                    // Kiểm tra tệp có tồn tại không
                    if (File.Exists(hinhAnhPath))
                    {
                        // Lấy tên file từ đường dẫn nguồn
                        string fileName = Path.GetFileName(hinhAnhPath);

                        // Đường dẫn đầy đủ của file trong thư mục đích
                        string destinationPath = Path.Combine(targetFolder, fileName);

                        // Sao chép file vào thư mục đích
                        File.Copy(hinhAnhPath, destinationPath, overwrite: true);
                        Console.WriteLine($"Đã sao chép hình ảnh từ '{hinhAnhPath}' đến '{destinationPath}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Không tìm thấy hình ảnh: '{hinhAnhPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Không thể sao chép hình ảnh từ '{hinhAnhPath}': {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi khi lưu hình ảnh: {ex.Message}");
            }
        }
        public bool DeleteFolder(string folderPath)
        {
            try
            {
                // Kiểm tra nếu thư mục tồn tại
                if (Directory.Exists(folderPath))
                {
                    // Xóa thư mục và toàn bộ nội dung bên trong
                    Directory.Delete(folderPath, recursive: true);
                    Console.WriteLine($"Thư mục '{folderPath}' đã được xóa thành công.");
                    return true; // Trả về true nếu xóa thành công
                }
                else
                {
                    Console.WriteLine($"Thư mục '{folderPath}' không tồn tại.");
                    return false; // Trả về false nếu thư mục không tồn tại
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi khi xóa thư mục '{folderPath}': {ex.Message}");
                return false; // Trả về false nếu gặp lỗi
            }
        }
        public  bool DeleteFile(string filePath)
        {
            try
            {
                // Kiểm tra nếu file tồn tại
                if (File.Exists(filePath))
                {
                    // Xóa file
                    File.Delete(filePath);
                    Console.WriteLine($"File '{filePath}' đã được xóa thành công.");
                    return true; // Trả về true nếu xóa thành công
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' không tồn tại.");
                    return false; // Trả về false nếu file không tồn tại
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi khi xóa file '{filePath}': {ex.Message}");
                return false; // Trả về false nếu xảy ra lỗi
            }

        }
    }
}

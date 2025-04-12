using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.model
{
    internal class VatLieu
    {
        private string maVatLieu;
        private string ten;
        private double giaNhap;
        private double giaXuat;
        private string donVi;
        private DateTime ngayNhap;
        private NhaCungCap nhaCungCap;
        private string dirHinhAnh;
        private float soLuong;
        
        public VatLieu()
        {
        }

        public VatLieu(string maVatLieu, string ten, double giaNhap, double giaXuat, string donVi, DateTime ngayNhap, string dirHinhAnh, NhaCungCap nhaCungCap, float soLuong)
        {
            MaVatLieu = maVatLieu;
            Ten = ten;
            GiaNhap = giaNhap;
            GiaXuat = giaXuat;
            DonVi = donVi;
            NgayNhap = ngayNhap;
            DirHinhAnh = dirHinhAnh;
            NhaCungCap = nhaCungCap;
            SoLuong = soLuong;
        }

        public string MaVatLieu { get => maVatLieu; set => maVatLieu = value; }
        public string Ten { get => ten; set => ten = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
        public double GiaXuat { get => giaXuat; set => giaXuat = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string DirHinhAnh { get => dirHinhAnh; set => dirHinhAnh = value; }
        internal NhaCungCap NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        public float SoLuong { get => soLuong; set => soLuong = value; }

        /// <summary>
        /// Gets a list of image file paths in the specified folder.
        /// </summary>
        /// <returns>
        /// A list of full file paths for image files (e.g., .jpg, .jpeg, .png, .bmp, .gif) found in the folder.
        /// If the folder does not exist or an error occurs, returns an empty list.
        /// </returns>
        public List<string> GetDanhSachHinhAnhVatLieus()
        {
            List<string> imageFiles = new List<string>();

            try
            {
                if (Directory.Exists(this.DirHinhAnh))
                {
                    string[] supportedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

                    imageFiles = Directory
                        .GetFiles(this.DirHinhAnh)
                        .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()))
                        .ToList();
                }
                else
                {
                    Debug.WriteLine($"⚠️ Folder '{this.DirHinhAnh}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error reading image files from '{this.DirHinhAnh}': {ex.Message}");
            }

            return imageFiles;
        }

    }
}
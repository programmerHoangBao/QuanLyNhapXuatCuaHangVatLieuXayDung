using QuanLyCuaHangVatLieuXayDung.model;
using QuanLyCuaHangVatLieuXayDung.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_TaiKhoan : Form
    {
        public Form_TaiKhoan()
        {
            InitializeComponent();
        }
        private TaiKhoan GetTaiKhoan()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string dirTempFalse = Path.Combine(projectDirectory, "temp", "taikhoan", "false", "taikhoan.json");
            List<TaiKhoan> taiKhoans = new FileUtility().ReadObjectsFromJsonFile<TaiKhoan>(dirTempFalse);
            if (taiKhoans.Count > 0 )
            {
                return taiKhoans[0];
            }
            else
            {
                return null;
            }
        }
    }
}
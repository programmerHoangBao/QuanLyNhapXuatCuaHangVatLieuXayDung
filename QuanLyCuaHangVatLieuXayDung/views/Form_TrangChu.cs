using QuanLyCuaHangVatLieuXayDung.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public partial class Form_TrangChu : Form
    {
        MyDatabase myDatabase = new MyDatabase();
        public Form_TrangChu()
        {
            InitializeComponent();
        }

        private void Form_TrangChu_Load(object sender, EventArgs e)
        {
            MessageBox.Show(CheckDatabaseConnection().ToString());
            MessageBox.Show(this.myDatabase.ConnectionString);
        }

        bool CheckDatabaseConnection()
        {
            try
            {
                this.myDatabase.OpenConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}"); // Hiển thị lỗi nếu xảy ra
                return false; // Không thể kết nối
            }
        }
    }
}

using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface ITaiKhoanService
    {
        // Lấy danh sách tất cả tài khoản
        List<TaiKhoan> findAllTaiKhoan();

        // Lấy tài khoản theo mã tài khoản
        TaiKhoan findByMaTaiKhoan(string maTaiKhoan);

        // Tìm kiếm tài khoản theo username hoặc số điện thoại
        List<TaiKhoan> searchByKey(string key);

        // Thêm tài khoản
        bool insertTaiKhoan(TaiKhoan taiKhoan);

        // Cập nhật tài khoản
        bool updateTaiKhoan(TaiKhoan taiKhoan);

        // Xóa tài khoản
        bool deleteTaiKhoan(TaiKhoan taiKhoan);

        // Kiểm tra đăng nhập
        TaiKhoan login(string username, string password);
    }
}

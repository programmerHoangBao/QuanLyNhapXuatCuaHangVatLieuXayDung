using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal interface IDoiTacService
    {
        /// <summary>
        /// Lấy danh sách tất cả các đối tác là khách hàng.
        /// </summary>
        /// <returns>List<KhachHang>.</returns>
        List<KhachHang> findAllKhachHang();

        /// <summary>
        /// Lấy danh sách tất cả các đối tác là nhà cung cấp.
        /// </summary>
        /// <returns>List<NhaCungCap>.</returns>
        List<NhaCungCap> findNhaCungCap();

        /// <summary>
        /// Lấy đối tượng DoiTac theo mã đối tác.
        /// </summary>
        ///<param name="maDoiTac" Mã đối tác.</param>
        /// <returns>DoiTac.</returns>

        DoiTac findByMaDoiTac(string maDoiTac);
        /// <summary>
        /// Thêm đối tác vào database.
        /// trả về true nếu thêm thành công, false nếu không thành công.
        /// </summary>
        ///<param name="doiTac"model DoiTac.</param>
        /// <returns>bool.</returns>
        bool insertDoiTac(DoiTac doiTac);

        /// <summary>
        /// cập nhật đối tác vào database.
        /// trả về true nếu cập nhật thành công, false nếu không thành công.
        /// </summary>
        ///<param name="doiTac"model DoiTac.</param>
        /// <returns>bool.</returns>
        bool updateDoiTac(DoiTac doiTac);

        /// <summary>
        /// xóa đối tác.
        /// trả về true nếu xóa thành công, false nếu không thành công.
        /// </summary>
        ///<param name="doiTac"model DoiTac.</param>
        /// <returns>bool.</returns>
        bool deleteDoiTac(DoiTac doiTac);

        /// <summary>
        /// Tìm kiếm qua thông tin mã, tên, số điện thoại của đối tác.
        /// trả về true nếu xóa thành công, false nếu không thành công.
        /// </summary>
        ///<param name="string" Thông tin tìm kiếm.</param>
        /// <returns>List<DoiTac>.</returns>
        List<DoiTac> searchByKey(string key);
    }
}

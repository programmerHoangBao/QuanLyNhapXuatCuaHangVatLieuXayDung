using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IPhieuGhiNoService
    {
        List<PhieuGhiNo> findAll();

        PhieuGhiNo findByMaPhieu(string maPhieu);

        bool insertPhieuGhiNo(PhieuGhiNo phieuGhiNo);

        bool deletePhieuGhiNo(string maPhieu);

        /// <returns>Danh sách phiếu ghi nợ khớp với từ khóa</returns>
        List<PhieuGhiNo> searchByKey(string key);
        List<PhieuGhiNo> findByLoaiPhieu(byte loaiPhieu);

        List<PhieuGhiNo> findByDateRange(DateTime startDate, DateTime endDate);

        List<PhieuGhiNo> findByDoiTac(string maDoiTac);

        List<PhieuGhiNo> findByTrangThai(bool trangThai);

        bool updateTrangThai(string maPhieu, bool trangThai);
    }
}

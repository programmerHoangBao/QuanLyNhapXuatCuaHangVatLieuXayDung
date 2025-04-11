using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IVatLieuService
    {
        List<VatLieu> findAll();
        List<VatLieu> findVatLieuByNhaCungCap(string maNhaCungCap);
        List<VatLieu> findAllSortedByClosestDate();
        VatLieu findByMaVatLieu(string maVatLieu);

        bool insertVatLieu(VatLieu vatLieu);
        bool updateVatLieu(VatLieu vatLieu);
        bool deleteVatLieu(VatLieu vatLieu);
        List<VatLieu> searchByKey(string key);
    }
}

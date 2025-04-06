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
        VatLieu findByMaVatLieu(string maVatLieu);
        List<(Kho kho, float soLuong)> getTonKho(string maVatLieu);
        bool insertVatLieu(VatLieu vatLieu);
        bool updateVatLieu(VatLieu vatLieu);
        bool updateTonKho(string maVatLieu, string maKho, float soLuong);
        bool deleteVatLieu(VatLieu vatLieu);
        List<VatLieu> searchByKey(string key);
    }
}

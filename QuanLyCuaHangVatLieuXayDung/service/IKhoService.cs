using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IKhoService
    {
        List<Kho> findAllKho();
        Kho findByMaKho(string maKho);
        bool insertKho(Kho kho);
        bool updateKho(Kho kho);
        bool deleteKho(Kho kho);
        List<Kho> searchByKey(string key);
    }
}

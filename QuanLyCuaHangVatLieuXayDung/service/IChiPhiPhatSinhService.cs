using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service.impl
{
    internal interface IChiPhiPhatSinhService
    {
        List<ChiPhiPhatSinh> FindAll();
        ChiPhiPhatSinh FindByMaChiPhi(string maChiPhi);
        bool InsertChiPhi(ChiPhiPhatSinh chiPhi);
        bool UpdateChiPhi(ChiPhiPhatSinh chiPhi);
        bool DeleteChiPhi(string maChiPhi);
        List<ChiPhiPhatSinh> SearchByKeyword(string keyword);
        List<ChiPhiPhatSinh> FindAllChiPhiSortDateDesc();
    }



}

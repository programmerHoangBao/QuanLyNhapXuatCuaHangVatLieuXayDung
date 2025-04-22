using QuanLyCuaHangVatLieuXayDung.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangVatLieuXayDung.service
{
    internal interface IBienLaiTraNoService
    {
        List<BienLaiTraNo> FindAll();
        BienLaiTraNo FindByMaBienLai(string maBienLai);
        List<BienLaiTraNo> SearchByKey(string key);
        List<BienLaiTraNo> FindByLoaiPhieu(byte loaiPhieu);
    }
}

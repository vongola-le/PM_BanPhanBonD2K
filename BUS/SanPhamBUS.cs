using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO _SPDAO = new SanPhamDAO();
        public List<SanPhamDTO> LayDSSP()
        {
            return _SPDAO.layDSSP();
        }
        public bool ThemSP(SanPhamDTO newSP)
        {
            return _SPDAO.ThemSP(newSP);
        }
        public bool xoaSP(SanPhamDTO newSP)
        {
            return _SPDAO.xoaSP(newSP);
        }
        public bool suaSP(SanPhamDTO newSP)
        {
            return _SPDAO.suaSP(newSP);
        }
        public List<SanPhamDTO> LayDSMaSP(SanPhamDTO newSP)
        {
            return _SPDAO.layDSMaSP(newSP);
        }
        public List<SanPhamDTO> LayDSTenSP(SanPhamDTO newSP)
        {
            return _SPDAO.layDSTenSP(newSP);
        }
        public List<SanPhamDTO> LayMaSP()
        {
            return _SPDAO.layMaSP();
        }
        public bool CapNhatSoLuong(SanPhamDTO newSP)
        {
            return _SPDAO.CapNhatSoLuong(newSP);
        }    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO _hdDAO = new HoaDonDAO();
        public List<HoaDonDTO> LoadDS()
        {
            return _hdDAO.LoadDS();
        }
        public List<HoaDonDTO> LoadDSHD(string maHoaDon)
        {
            return _hdDAO.LoadDSHD(maHoaDon);
        }
        public List<HoaDonDTO> LoadDSNgayLapHD(DateTime ngaylapHD)
        {
            return _hdDAO.LoadDSNgayLapHD(ngaylapHD);
        }
        public List<HoaDonDTO> LoadDSNhanVien(string maNhanVien)
        {
            return _hdDAO.LoadDSNhanVien(maNhanVien);

        }
        public bool Add(HoaDonDTO newAdd)
        {
            if (_hdDAO.Add(newAdd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetNewID()
        {
            return _hdDAO.GetNewID();
        }

      
       
    }
}

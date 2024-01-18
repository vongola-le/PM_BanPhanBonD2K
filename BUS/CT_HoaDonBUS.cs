using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CT_HoaDonBUS
    {
        CT_HoaDonDAO _cthdDAO= new CT_HoaDonDAO();

       
        public List<CT_HoaDonDTO> LoadDSSP()
        {
            return _cthdDAO.LoadDSSP();
        }
        public List<CT_HoaDonDTO> LoadDSCTHD(string maHoaDon)
        {
            return _cthdDAO.LoadDSCTHD(maHoaDon);
        }
        public bool Add(CT_HoaDonDTO newAdd)
        {
            return _cthdDAO.Add(newAdd);
        }
        public bool Change(CT_HoaDonDTO newChange)
        {
            return  _cthdDAO.Change(newChange);
        }
    }
}

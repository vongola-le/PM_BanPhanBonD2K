using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAO nhanvienDAO = new NhanVienDAO();

        public List<NhanVienDTO> LayDSNhanVien()
        {
            return nhanvienDAO.LayDSNhanVien();
        }
        //timkiem ten
        public List<NhanVienDTO> timnv_ten(string tennv)
        {
            return nhanvienDAO.timnv_ten(tennv);
        }
        //timkiem ma
        public List<NhanVienDTO> timnv_ma(string manv)
        {
            return nhanvienDAO.timnv_ma(manv);
        }
        //them
        public bool Add(NhanVienDTO newNhanVien)
        {
            return nhanvienDAO.Add(newNhanVien);
        }
        //xoa
        public bool Delete(NhanVienDTO delNhanVien)
        {
            return nhanvienDAO.Delete(delNhanVien);
        }
        //sua
        public bool Update(NhanVienDTO upNhanVien)
        {
            return nhanvienDAO.Update(upNhanVien);
        }
        public string GetMaNVByUser(string username)
        {
            return nhanvienDAO.GetMaNVByUser(username);
        }
    }
}

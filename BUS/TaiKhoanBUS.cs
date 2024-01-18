using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAO taikhoanDAO = new TaiKhoanDAO();

        public List<TaiKhoanDTO> LayDS_TK()
        {
            return taikhoanDAO.LayDS_TK();
        }
        //them
        public bool Add(TaiKhoanDTO newtaikhoan)
        {
            return taikhoanDAO.AddTK(newtaikhoan);
        }
        //xoa
        public bool Delete(TaiKhoanDTO deltaikhoan)
        {
            return taikhoanDAO.DeleteTK(deltaikhoan);
        }
        //update
        public bool Update(TaiKhoanDTO uptaikhoan)
        {
            return taikhoanDAO.UpdateTK(uptaikhoan);
        }

        public List<TaiKhoanDTO> KtTaiKhoan(string user,string pass)
        {
            return taikhoanDAO.KtTaiKhoan(user,pass);
        }
    }
}

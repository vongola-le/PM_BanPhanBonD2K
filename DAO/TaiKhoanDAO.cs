using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAO
{
    public class TaiKhoanDAO
    {
        //D2KEntities d2kentities = new D2KEntities();
        D2KEntities d2kentities = new D2KEntities();

        public List<TaiKhoanDTO> LayDS_TK()
        {
            var list = d2kentities.TaiKhoans.ToList();

            return list.Where(t => t.Trangthai == false).Select(u => new TaiKhoanDTO
            {
                User = u.Username,
                Password = u.Pass,
                Quyen = u.Quyen,
                MaNV = u.MaNV,
                TenNV = layten(u.MaNV)
            }).ToList();
        }
        //lay ten nhan vien
        private string layten(string manv)
        {
            var lst = d2kentities.NhanViens.Where(u => u.Trangthai == false && u.MaNV == manv);
            foreach(var item in lst)
            {
                return item.TenNV.ToString();
            }
            return "";
        }
        //add tai khoan
        public bool AddTK(TaiKhoanDTO addtaiKhoan)
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    Username = addtaiKhoan.User,
                    Pass = addtaiKhoan.Password,
                    Quyen = addtaiKhoan.Quyen,
                    MaNV = addtaiKhoan.MaNV,
                    Trangthai = addtaiKhoan.TrangThai
                };
                d2kentities.TaiKhoans.Add(taiKhoan);
                d2kentities.SaveChanges();
                return true;
            }
            catch (Exception e) 
            { 
                return false;
            }
        }
        //delete tk
        public bool DeleteTK(TaiKhoanDTO deltaikhoan)
        {
            try
            {
                TaiKhoan taiKhoan = d2kentities.TaiKhoans.SingleOrDefault(u =>u.Username == deltaikhoan.User);
                taiKhoan.Trangthai = deltaikhoan.TrangThai;
                d2kentities.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }
        //update 
        public bool UpdateTK(TaiKhoanDTO uptaikhoan)
        {
            try
            {
                TaiKhoan taiKhoan = d2kentities.TaiKhoans.SingleOrDefault(u => u.Username == uptaikhoan.User);
                taiKhoan.Pass = uptaikhoan.Password;
                taiKhoan.Quyen = uptaikhoan.Quyen;
                d2kentities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //kt tk 
        public List<TaiKhoanDTO> KtTaiKhoan(string user , string pass)
        {
            var list = d2kentities.TaiKhoans.ToList();

            return list.Where(t => t.Trangthai == false).Where(t => t.Username == user).Where(m => m.Pass == pass).
                Select(u => new TaiKhoanDTO
            {
                User = u.Username,
                Password = u.Pass,
                Quyen = u.Quyen,
                MaNV = u.NhanVien.MaNV,
                TenNV = u.NhanVien.TenNV
            }).ToList();
        }
    }
}

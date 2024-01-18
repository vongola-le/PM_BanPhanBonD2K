using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanVienDAO
    {
        //D2KEntities d2kentities = new D2KEntities();

        D2KEntities d2kentities =  new D2KEntities();
        //lay ds
        public List<NhanVienDTO> LayDSNhanVien()
        {
            var list = d2kentities.NhanViens.ToList();

            return list.Where(u => u.Trangthai == false).Select(u => new NhanVienDTO 
            { 
                MaNV = u.MaNV,
                TenNV= u.TenNV,
                GioiTinh= u.GioiTinh,
                NSinh = u.NgaySinh.Value,
                DiaChi = u.DiaChi_NV,
                SDT = u.Phone_NV
            }).ToList();
        }
        //tim nv theo ten
        public List<NhanVienDTO> timnv_ten(string tennv)
        {
            var list = d2kentities.NhanViens.ToList();

            return list.Where(u => u.Trangthai == false).Where(t=>t.TenNV == tennv).Select(u => new NhanVienDTO
            {
                MaNV = u.MaNV,
                TenNV = u.TenNV,
                GioiTinh = u.GioiTinh,
                NSinh = u.NgaySinh.Value,
                DiaChi = u.DiaChi_NV,
                SDT = u.Phone_NV
            }).ToList();
        }
        //tim nv theo ma
        public List<NhanVienDTO> timnv_ma(string manv)
        {
            var list = d2kentities.NhanViens.ToList();

            return list.Where(u => u.Trangthai == false).Where(t => t.MaNV == manv).Select(u => new NhanVienDTO
            {
                MaNV = u.MaNV,
                TenNV = u.TenNV,
                GioiTinh = u.GioiTinh,
                NSinh = u.NgaySinh.Value,
                DiaChi = u.DiaChi_NV,
                SDT = u.Phone_NV
            }).ToList();
        }
        //them
        public bool Add(NhanVienDTO newNhanVien)
        {
            try
            {
                NhanVien nhanvien = new NhanVien
                {
                    MaNV = newNhanVien.MaNV,
                    TenNV = newNhanVien.TenNV,
                    GioiTinh = newNhanVien.GioiTinh,
                    NgaySinh = newNhanVien.NSinh,
                    DiaChi_NV = newNhanVien.DiaChi,
                    Phone_NV = newNhanVien.SDT,
                    Trangthai = newNhanVien.TrangThai
                };

                d2kentities.NhanViens.Add(nhanvien);
                d2kentities.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //xoa
        public bool Delete(NhanVienDTO delNhanVien)
        {
            try
            {
                NhanVien nhanvien = d2kentities.NhanViens.SingleOrDefault(u => u.MaNV == delNhanVien.MaNV);
                nhanvien.Trangthai = delNhanVien.TrangThai;
                d2kentities.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //sua
        public bool Update(NhanVienDTO upNhanVien)
        {
            try
            {
                NhanVien nhanvien = d2kentities.NhanViens.SingleOrDefault(u => u.MaNV == upNhanVien.MaNV);
                nhanvien.TenNV = upNhanVien.TenNV;
                nhanvien.GioiTinh = upNhanVien.GioiTinh;
                nhanvien.NgaySinh = upNhanVien.NSinh;
                nhanvien.DiaChi_NV = upNhanVien.DiaChi;
                nhanvien.Phone_NV = upNhanVien.SDT;
                d2kentities.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public string GetMaNVByUser(string username)
        {
            var tkEF = d2kentities.TaiKhoans.FirstOrDefault(tk => tk.Username == username);
            if (tkEF != null)
            {
                return tkEF.MaNV;
            }
            return null;
        }
    }
}

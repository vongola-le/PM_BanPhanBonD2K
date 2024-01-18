using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SanPhamDAO
    {
        D2KEntities _SP = new D2KEntities();

        public List<SanPhamDTO> layDSSP()
        {
            var lst = _SP.SanPhams.ToList();

            return lst.Where(v => v.Trangthai == true).Select(u => new SanPhamDTO
            {
                MaSP = u.MaSP,
                TenSP = u.TenSP,
                MoTa = u.MoTa_SP.ToString(),
                DVTinh = u.DonViTinh.ToString(),
                SoLuong = Convert.ToInt32(u.SoLuong),
                DonGia = Convert.ToInt32(u.DonGia),
                HinhAnh = u.HinhAnh
            }).ToList();
        }
        public bool ThemSP(SanPhamDTO newSP)
        {
            try
            {

                SanPham spAdd = new SanPham
                {
                    MaSP = newSP.MaSP,
                    TenSP = newSP.TenSP,
                    MoTa_SP = newSP.MoTa,
                    DonViTinh = newSP.DVTinh,
                    SoLuong = newSP.SoLuong,
                    DonGia = newSP.DonGia,
                    HinhAnh = newSP.HinhAnh,
                    Trangthai = true
                };
                _SP.SanPhams.Add(spAdd);
                _SP.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool xoaSP(SanPhamDTO newSP)
        {
            try
            {

                SanPham spDel = _SP.SanPhams.SingleOrDefault(u => u.MaSP == newSP.MaSP);
                spDel.Trangthai = false;
                _SP.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool suaSP(SanPhamDTO newSP)
        {
            try
            {
                SanPham spUpd = _SP.SanPhams.SingleOrDefault(u => u.MaSP == newSP.MaSP);
                spUpd.TenSP = newSP.TenSP;
                spUpd.MoTa_SP = newSP.MoTa;
                spUpd.DonViTinh = newSP.DVTinh;
                spUpd.SoLuong = newSP.SoLuong;
                spUpd.DonGia = newSP.DonGia;
                spUpd.HinhAnh= newSP.HinhAnh;
                _SP.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<SanPhamDTO> layDSMaSP(SanPhamDTO newSP)
        {


            SanPham spUpd = _SP.SanPhams.SingleOrDefault(u => u.MaSP == newSP.MaSP);

            var lst = _SP.SanPhams.ToList();

            return lst.Where(v => v.Trangthai == false && v.MaSP == newSP.MaSP).Select(u => new SanPhamDTO
            {
                MaSP = u.MaSP,
                TenSP = u.TenSP,
                MoTa = u.MoTa_SP.ToString(),
                DVTinh = u.DonViTinh.ToString(),
                SoLuong = Convert.ToInt32(u.SoLuong),
                DonGia = Convert.ToInt32(u.DonGia),

            }).ToList();
        }
        public List<SanPhamDTO> layDSTenSP(SanPhamDTO newSP)
        {


            SanPham spUpd = _SP.SanPhams.SingleOrDefault(u => u.TenSP == newSP.TenSP);

            var lst = _SP.SanPhams.ToList();

            return lst.Where(v => v.Trangthai == true && v.TenSP == newSP.TenSP).Select(u => new SanPhamDTO
            {
                MaSP = u.MaSP,
                TenSP = u.TenSP,
                MoTa = u.MoTa_SP.ToString(),
                DVTinh = u.DonViTinh.ToString(),
                SoLuong = Convert.ToInt32(u.SoLuong),
                DonGia = Convert.ToInt32(u.DonGia)

            }).ToList();
        }
        public List<SanPhamDTO> layMaSP()
        {
            var lst = _SP.SanPhams.ToList();

            return lst.Select(u => new SanPhamDTO
            {
                MaSP = u.MaSP,
            }).ToList();
        }


      
        public bool CapNhatSoLuong(SanPhamDTO newSP)
        {
            try
            {
                SanPham spUpd = _SP.SanPhams.SingleOrDefault(u => u.MaSP == newSP.MaSP);
                spUpd.SoLuong -= newSP.SoLuong;
                _SP.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

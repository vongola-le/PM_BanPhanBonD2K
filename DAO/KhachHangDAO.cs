using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KhachHangDAO
    {
        D2KEntities _KH = new D2KEntities();

        public List<KhachHangDTO> layDSKH()
        {
            var lst = _KH.KhachHangs.ToList();

            return lst.Where(v => v.Trangthai == true).Select(u => new KhachHangDTO
            {
                MaKH = u.MaKH,
                TenKH = u.TenKH,
                GioiTinh = u.GioiTinh,
                DiaChi_KH = u.DiaChi_KH,
                Phone_KH = u.Phone_KH,

            }).ToList();
        }
        public bool ThemKH(KhachHangDTO newKH)
        {
            try
            {

                KhachHang khAdd = new KhachHang
                {
                    MaKH = newKH.MaKH,
                    TenKH = newKH.TenKH,
                    GioiTinh = newKH.GioiTinh,
                    DiaChi_KH = newKH.DiaChi_KH,
                    Phone_KH = newKH.Phone_KH,
                    Trangthai = true
                };

                _KH.KhachHangs.Add(khAdd);
                _KH.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool xoaKH(KhachHangDTO newKH)
        {
            try
            {

                KhachHang khDel = _KH.KhachHangs.SingleOrDefault(u => u.MaKH == newKH.MaKH);
                khDel.Trangthai = newKH.Trangthai;
                _KH.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool suaKH(KhachHangDTO newKH)
        {
            try
            {
                KhachHang spUpd = _KH.KhachHangs.SingleOrDefault(u => u.MaKH == newKH.MaKH);
                spUpd.MaKH = newKH.MaKH;
                spUpd.TenKH = newKH.TenKH;
                spUpd.Phone_KH = newKH.Phone_KH;
                spUpd.GioiTinh = newKH.GioiTinh;
                spUpd.DiaChi_KH = newKH.DiaChi_KH;
                _KH.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<KhachHangDTO> layDSMaKH(KhachHangDTO newSP)
        {


            KhachHang spUpd = _KH.KhachHangs.SingleOrDefault(u => u.MaKH == newSP.MaKH);

            var lst = _KH.KhachHangs.ToList();

            return lst.Where(v => v.Trangthai == false && v.MaKH == newSP.MaKH).Select(u => new KhachHangDTO
            {

                MaKH = u.MaKH,
                TenKH = u.TenKH,
                GioiTinh = u.GioiTinh,
                DiaChi_KH = u.DiaChi_KH,
                Phone_KH = u.Phone_KH,

            }).ToList();
        }
        public List<KhachHangDTO> layDSTenKH(KhachHangDTO newSP)
        {


            KhachHang spUpd = _KH.KhachHangs.SingleOrDefault(u => u.TenKH == newSP.TenKH);

            var lst = _KH.KhachHangs.ToList();

            return lst.Where(v => v.Trangthai == false && v.TenKH == newSP.TenKH).Select(u => new KhachHangDTO
            {

                MaKH = u.MaKH,
                TenKH = u.TenKH,
                GioiTinh = u.GioiTinh,
                DiaChi_KH = u.DiaChi_KH,
                Phone_KH = u.Phone_KH,

            }).ToList();
        }
        public List<KhachHangDTO> layMaKH()
        {
            var lst = _KH.KhachHangs.ToList();

            return lst.Select(u => new KhachHangDTO
            {
                MaKH = u.MaKH,
            }).ToList();
        }
        public string GetMaKHByPhone(KhachHangDTO phone)
        {
            var khEF = _KH.KhachHangs.FirstOrDefault(kh => kh.Phone_KH == phone.Phone_KH);
            if (khEF != null)
            {
                return khEF.MaKH;
            }
            return null;
        }
      
        public string GetLatestCustomerId()
        {
           
                var latestCustomer = _KH.KhachHangs.OrderByDescending(kh => kh.MaKH).FirstOrDefault();
                if (latestCustomer != null)
                {
                    return latestCustomer.MaKH;
                }
                else
                {
                    // no customers exist in the database yet
                    return "KH001";
                }
          
        }
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace DAO
{
    public class CT_HoaDonDAO
    {
        D2KEntities _qldaEntities = new D2KEntities();
        public List<CT_HoaDonDTO> LoadDSSP()
        {
            var lst = _qldaEntities.SanPhams.ToList();

            return lst.Where(v => v.Trangthai == true).Select(u => new CT_HoaDonDTO
            {
                TenSP = u.TenSP,
                MaSP = u.MaSP.ToString(),
                SoLuong = u.SoLuong.Value,
                DonGia = Convert.ToInt32(u.DonGia.Value),
            }).ToList();
        }
        public List<CT_HoaDonDTO> LoadDSCTHD(string maHoaDon)
        {

            var lst = _qldaEntities.CT_HoaDon.ToList();
            return lst.Where(v => v.Trangthai == true && v.MaHD == maHoaDon).Select(u => new CT_HoaDonDTO
            {
                MaHD = u.MaHD,
                MaSP = u.MaSP,
                TenSP = u.SanPham.TenSP,
                SoLuong = u.SoLuong.Value,
                DonGia = Convert.ToInt32(u.DonGia),
                GiamGia = u.GiamGia.Value,
                ThanhTien = u.ThanhTien.Value
            }).ToList();
        }
        public bool Add(CT_HoaDonDTO newAdd)
        {
            try
            {
                CT_HoaDon newEF = new CT_HoaDon()
                {
                    MaHD = newAdd.MaHD.ToString(),
                    MaSP = newAdd.MaSP.ToString(),
                    SoLuong = newAdd.SoLuong,
                    DonGia = newAdd.DonGia,
                    GiamGia = newAdd.GiamGia,
                    ThanhTien = newAdd.ThanhTien,
                    Trangthai = true
                };
                _qldaEntities.CT_HoaDon.Add(newEF);
                _qldaEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Change(CT_HoaDonDTO newChange)
        {
            try
            {
                var updEF = _qldaEntities.CT_HoaDon.SingleOrDefault(u => u.MaHD.ToString() == newChange.MaHD && u.MaSP == newChange.MaSP);

                if (updEF != null)
                {
                    updEF.MaSP = newChange.MaSP;
                    updEF.SoLuong = newChange.SoLuong;
                    updEF.DonGia = newChange.DonGia;
                    updEF.GiamGia = newChange.GiamGia;
                    updEF.ThanhTien = newChange.ThanhTien;

                    _qldaEntities.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HoaDonDAO
    {
        D2KEntities _qlchEntities = new D2KEntities();  

        public List<HoaDonDTO> LoadDS()
        {
            var lst = _qlchEntities.HoaDons.ToList();
            return lst.Where(v => v.Trangthai == true).Select(u => new HoaDonDTO
            {
                MaHD = u.MaHD.ToString(),
                MaKH= u.MaKH.ToString(),    
                NgayLayHD = u.NgayLayHD.Value,
                MaNV = u.MaNV.ToString(),
                ThanhTien = u.ThanhTien.Value,
                Trangthai = true
            }).ToList();

        }
        public List<HoaDonDTO> LoadDSHD(string maHoaDon)
        {
            var lst = _qlchEntities.HoaDons.ToList();
            // Phương thức Contains() được sử dụng để kiểm tra xem mã hóa đơn có chứa chuỗi tìm kiếm hay không
            return lst.Where(hd => hd.MaHD.ToString().Contains(maHoaDon)).Select(u => new HoaDonDTO
            {
                MaHD = u.MaHD.ToString(),
                NgayLayHD = u.NgayLayHD.Value,
                MaNV = u.MaNV.ToString(),
                ThanhTien = u.ThanhTien.Value,
                Trangthai = true
            }).ToList();

        }
        public List<HoaDonDTO> LoadDSNgayLapHD(DateTime ngaylapHD)
        {
            var lst = _qlchEntities.HoaDons.ToList();
            return lst.Where(hd => hd.NgayLayHD.Value.Date == ngaylapHD.Date).Select(u => new HoaDonDTO
            {
                MaHD = u.MaHD.ToString(),
                NgayLayHD = u.NgayLayHD.Value,
                MaNV = u.MaNV.ToString(),
                ThanhTien = u.ThanhTien.Value,
                Trangthai = u.Trangthai.Value
            }).ToList();
        }
        public List<HoaDonDTO> LoadDSNhanVien(string maNhanVien)
        {
            var lst = _qlchEntities.HoaDons.ToList();
            // Phương thức Contains() được sử dụng để kiểm tra xem mã nhân viên có chứa chuỗi tìm kiếm hay không
            return lst.Where(hd => hd.MaNV.ToString().Contains(maNhanVien)).Select(u => new HoaDonDTO
            {
                MaHD = u.MaHD.ToString(),
                NgayLayHD = u.NgayLayHD.Value,
                MaNV = u.MaNV.ToString(),
                ThanhTien = u.ThanhTien.Value,
                Trangthai = true
            }).ToList();

        }
        public string GetNewID()
        {
            // Phương thức Any() được sử dụng để kiểm tra xem bảng HoaDons trong database có bất kỳ bản ghi nào hay không
            string maxID = _qlchEntities.HoaDons.Any() ? _qlchEntities.HoaDons.Max(hd => hd.MaHD) : null;
            if (maxID == null)
            {
                // Không có bản ghi nào trong bảng HoaDons
                return "HD001"; // hoặc trả về một chuỗi mặc định khác
            }
            else
            {
                int idNumber = int.Parse(maxID.Substring(2));
                return "HD" + (idNumber + 1).ToString("D3");
            }
        }
        public bool Add(HoaDonDTO newAdd)
        {
            try
            {
                var khachHang = _qlchEntities.KhachHangs.FirstOrDefault(v => v.Phone_KH == newAdd.MaKH);
                HoaDon newEF = new HoaDon
                {
                    MaHD = newAdd.MaHD?.ToString(),
                    NgayLayHD = newAdd.NgayLayHD,
                    MaNV = newAdd.MaNV.ToString(),
                    MaKH = newAdd.MaKH.ToString(),
                    ThanhTien = newAdd.ThanhTien,
                    Trangthai = true
                };
                _qlchEntities.HoaDons.Add(newEF);
                _qlchEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}


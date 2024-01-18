using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_HoaDonDTO
    {
        public string MaHD { get; set; }
        public string TenSP { get; set; }
        public string MaSP { get; set; }
        public int  SoLuong { get; set; }
        public int DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public bool Trangthai { get; set; }
        public decimal ThanhTien { get; set; }

    }
}

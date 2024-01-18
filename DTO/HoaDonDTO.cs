using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public DateTime NgayLayHD { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public bool Trangthai { get; set; }
        public decimal ThanhTien { get; set; }

    }
}

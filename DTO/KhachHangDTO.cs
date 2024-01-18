using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi_KH { get; set; }
        public string Phone_KH { get; set; }
        public bool Trangthai { get; set; }
    }
}

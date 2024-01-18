using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public string DVTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public bool TrangThai { get; set; }
        public byte[] HinhAnh { get; set; }
    }
}

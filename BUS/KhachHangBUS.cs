using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO _KHDAO = new KhachHangDAO();
        public List<KhachHangDTO> LayDSKH()
        {
            return _KHDAO.layDSKH();
        }
        public bool ThemKH(KhachHangDTO newKH)
        {
            return _KHDAO.ThemKH(newKH);
        }
        public bool xoaKH(KhachHangDTO newKH)
        {
            return _KHDAO.xoaKH(newKH);
        }
        public bool suaKH(KhachHangDTO newKH)
        {
            return _KHDAO.suaKH(newKH);
        }
        public List<KhachHangDTO> LayDSMaKH(KhachHangDTO newSP)
        {
            return _KHDAO.layDSMaKH(newSP);
        }
        public List<KhachHangDTO> LayDSTenKH(KhachHangDTO newSP)
        {
            return _KHDAO.layDSTenKH(newSP);
        }
        public List<KhachHangDTO> LayMaKH()
        {
            return _KHDAO.layMaKH();
        }
        public string GetMaKHByPhone(KhachHangDTO phone)
        {
            return _KHDAO.GetMaKHByPhone(phone);
        }
        public string GetNextCustomerId()
        {
            if (_KHDAO.GetLatestCustomerId() == null) return "KH001";
            var latestCustomerId = _KHDAO.GetLatestCustomerId();
            var nextIdNumber = int.Parse(latestCustomerId.Substring(2)) + 1;
            var nextIdString = nextIdNumber.ToString("D3");
            return "KH" + nextIdString;


        }
    }
}

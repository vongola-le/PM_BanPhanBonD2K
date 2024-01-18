using BUS;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class frm_XemBaoCao : Form
    {
        HoaDonBUS _hdBUS = new HoaDonBUS();
        SanPhamBUS _spBUS = new SanPhamBUS();
        string user = frm_DangNhap._tennv;
        public frm_XemBaoCao()
        {
            InitializeComponent();
        }

        private void frm_XemBaoCao_Load(object sender, EventArgs e)
        {

            this.rpvBaoCao.RefreshReport();
        }
        public void LoadDSHD(DateTime ngay)
        {
            //DateTime ngayLap = dtpNgayLap.Value;
            //string ngayLapString = ngayLap.ToString("dd/MM/yyyy");
            // Lấy danh sách sản phẩm
            List<HoaDonDTO> lst = _hdBUS.LoadDSNgayLapHD(ngay);
            // Chọn report cho ReportViewer
            this.rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLyCuaHang.rptHoaDon.rdlc";
            //  Đổ dữ liệu
            this.rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSHD", lst));
            // Truyền giá trị cho parameter
            this.rpvBaoCao.LocalReport.SetParameters(new ReportParameter("paNgayLap", ngay.ToString("dd/MM/yyyy")));
            // Hiện báo cáo
            this.rpvBaoCao.RefreshReport();
        }
        public void LoadDSSP()
        {
            // Lấy danh sách sản phẩm
            List<SanPhamDTO> lst = _spBUS.LayDSSP();
            //
            this.rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLyCuaHang.rptTatCaSanPham.rdlc";
            //
            this.rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DSSP", lst));
            //
            this.rpvBaoCao.RefreshReport();
        }
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if(radHoaDon.Checked==true)
            {
                LoadDSHD(dtpNgayLap.Value);
            }
            else if(radSanPham.Checked==true) { LoadDSSP(); }
         
        }
    }
}

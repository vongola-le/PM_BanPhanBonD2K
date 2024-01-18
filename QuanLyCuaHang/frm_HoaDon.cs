using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class frm_HoaDon : Form
    {
        HoaDonBUS _hdBUS = new HoaDonBUS();
      
        public frm_HoaDon()
        {
            InitializeComponent();
            dgvHD.AutoGenerateColumns = false;
            dgvHD.ReadOnly = true;
            LoadDS();
        }
        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            LoadDS();
        }
        public void LoadDS()
        {
            dgvHD.DataSource = _hdBUS.LoadDS();
            
        }
        private void dgvHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dgvHD.RowCount; i++)
            {
                dgvHD.Rows[i].Cells["TENTRANGTHAI"].Value = (bool)dgvHD.Rows[i].Cells["TRANGTHAI"].Value ? "Đã hoàn thành" : "Chưa hoàn thành";

            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            if (radMaHD.Checked == true)
            {
                string maHoaDon = txtMaHD.Text.Trim();

                List<HoaDonDTO> lst = _hdBUS.LoadDSHD(maHoaDon);

                dgvHD.DataSource = lst;
            }
        }

        private void dtpNgayLapHD_ValueChanged(object sender, EventArgs e)
        {
            if (radNgayLapHD.Checked == true)
            {
                DateTime ngaylapHD = dtpNgayLapHD.Value.Date;
                List<HoaDonDTO> lst = _hdBUS.LoadDSNgayLapHD(ngaylapHD);
                dgvHD.DataSource = lst;
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (radMaNV.Checked == true)
            {
                string maNhanVien = txtMaNV.Text.Trim();

                List<HoaDonDTO> lst = _hdBUS.LoadDSNhanVien(maNhanVien);

                dgvHD.DataSource = lst;

            }
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            //Tạo một đối tượng frm_CTHD
            frm_CTHoaDon frm_CTHD = new frm_CTHoaDon();
            // Sử dụng thuộc tính Owner của Form chi tiết hóa đơn để truy cập đến Form hóa đơn và gọi phương thức LoadDS()
            frm_CTHD.Owner = this;
            // Hiển thị form Chi tiết hóa đơn
            frm_CTHD.ShowDialog();
        }
    }
}

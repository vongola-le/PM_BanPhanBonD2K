using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using BUS;
using System.Xml.Linq;
using System.Windows.Controls;

namespace QuanLyCuaHang
{
    public partial class frm_NhanVien : Form
    {
        NhanVienBUS nhanvienBUS = new NhanVienBUS();
        public frm_NhanVien()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dgvNhanVien.AutoGenerateColumns = false;
            rbNam.Checked = true;
            LoadForm();
        }

        void LoadForm()
        {
            dgvNhanVien.DataSource = nhanvienBUS.LayDSNhanVien();
        }
        private void resettext()
        {
            txtMa.ResetText();
            txtSDT.ResetText();
            txtDiaChi.ResetText();
            txtTen.ResetText();
            txtS_Ma.ResetText();
            txtS_Ten.ResetText();
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nam")
            {
                rbNam.Checked = true;
            }
            else { rbNu.Checked = true; }
            dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString());
            txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        //nut xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVienDTO delNhanVien = new NhanVienDTO()
            {
                MaNV = txtMa.Text,
                TrangThai = true
            };

            if (nhanvienBUS.Delete(delNhanVien))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            LoadForm();
            resettext();
        }
        //nut sua
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVienDTO upNhanVien = new NhanVienDTO()
            {
                MaNV = txtMa.Text,
                TenNV = txtTen.Text,
                GioiTinh = rbNam.Checked ? "Nam" : "Nữ",
                NSinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text
            };

            if (nhanvienBUS.Update(upNhanVien))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            LoadForm();
            resettext();
        }
        //nut lam moi
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadForm();
            resettext();
        }
        //nut them
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVienDTO newnhanvien = new NhanVienDTO()
            {
                MaNV = txtMa.Text,
                TenNV = txtTen.Text,
                GioiTinh = rbNam.Checked ? "Nam" : "Nữ",
                NSinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                TrangThai = false
            };

            if (nhanvienBUS.Add(newnhanvien))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            LoadForm();
            resettext();
        }

        private void button1_Click(object sender, EventArgs e)
        {   if (rbTen.Checked)
            {
                dgvNhanVien.DataSource = nhanvienBUS.timnv_ten(txtS_Ten.Text);
            }
            else
            {
                dgvNhanVien.DataSource = nhanvienBUS.timnv_ma(txtS_Ma.Text);
            }
            resettext();
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}

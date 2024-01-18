using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;


namespace QuanLyCuaHang
{
    public partial class frm_TaiKhoan : Form
    {
        TaiKhoanBUS taikhoanBUS = new TaiKhoanBUS();
        public frm_TaiKhoan()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dgvTaiKhoan.AutoGenerateColumns = false;
            LoadForm();
            LoadcbbTenNV();
            cbbQuyen.SelectedIndex = 0;
        }
        void LoadForm()
        {
            dgvTaiKhoan.DataSource = taikhoanBUS.LayDS_TK();
        }
        private void resettext()
        {
            txtUser.ResetText();
            txtPass.ResetText();
            cbbQuyen.SelectedIndex = 0;
            cbbTeNV.SelectedIndex = 0;
        }
        // load comboBox TenNV
        private void LoadcbbTenNV()
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            cbbTeNV.DataSource = nhanVienBUS.LayDSNhanVien();
            cbbTeNV.ValueMember = "MaNV";
            cbbTeNV.DisplayMember = "TenNV";
        }
        //load tt
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUser.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPass.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["Pass"].Value.ToString();
            cbbTeNV.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbbQuyen.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        //them
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(cbbQuyen.Text) || cbbTeNV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoanDTO newtaikhoan = new TaiKhoanDTO()
            {
                User = txtUser.Text,
                Password = Utils.GetMD5(txtPass.Text),
                Quyen = cbbQuyen.Text,
                MaNV = cbbTeNV.SelectedValue.ToString(),//sua
                TrangThai = false
            };

            if (taikhoanBUS.Add(newtaikhoan))
            {
                MessageBox.Show("Thêm thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadForm();
            resettext();
        }
        //xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(cbbQuyen.Text) || cbbTeNV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TaiKhoanDTO deltaikhoan = new TaiKhoanDTO()
            {
                User = txtUser.Text,
                TrangThai = true
            };
            if (taikhoanBUS.Delete(deltaikhoan))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa thât bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadForm();
            resettext();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(cbbQuyen.Text) || cbbTeNV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TaiKhoanDTO uptaikhoan = new TaiKhoanDTO
            {
                User = txtUser.Text,
                Password = Utils.GetMD5(txtPass.Text), 
                Quyen = cbbQuyen.Text,
            };
            if (taikhoanBUS.Update(uptaikhoan))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thát bại");
            }
            LoadForm();
            resettext();
        }
        //lam mơi
        private void button5_Click(object sender, EventArgs e)
        {
            LoadForm();
            resettext();
        }
    }
}

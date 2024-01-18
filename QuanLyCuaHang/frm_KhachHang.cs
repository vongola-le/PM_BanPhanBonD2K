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
using System.Text.RegularExpressions;

namespace QuanLyCuaHang
{
    public partial class frm_KhachHang : Form
    {
        KhachHangBUS _KHBUS = new KhachHangBUS();
        List<string> lstMaKH = new List<string>();

        List<string> lstLayMa = new List<string>();
        int demo()
        {
            dgvKhachHang.DataSource = _KHBUS.LayMaKH();
            lstLayMa.Clear();
            for (int i = 0; i <= dgvKhachHang.Rows.Count; i++)
            {
                string z = i.ToString();
                lstLayMa.Add(z);
            }
            int index = Convert.ToInt32(lstLayMa.Last<string>());

            int u = index;
            LoadKhachHang();
            return u;
        }
        void resetText()
        {
            int x = demo();
            x = x + 1;
            string s = x.ToString();
            string wN = "KH00" + s;
            lbMaKH.Text = wN;
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            rbtNam.Checked = true;
        }
        public frm_KhachHang()
        {
            InitializeComponent();
            dgvKhachHang.AutoGenerateColumns = false;
            LoadKhachHang();
            rbtNam.Checked = true;
            int x = demo();
            x = x + 1;
            string s = x.ToString();
            string wN = "KH00" + s;
            lbMaKH.Text = wN;
        }
        void LoadKhachHang()
        {
            dgvKhachHang.DataSource = _KHBUS.LayDSKH();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            KhachHangBUS _SPreload = new KhachHangBUS();
            dgvKhachHang.DataSource = _SPreload.LayDSKH();
            this.frm_KhachHang_Load(sender, e);
            resetText();
            int x = demo();
            x = x + 1;
            string s = x.ToString();
            string wN = "KH00" + s;
            lbMaKH.Text = wN;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbtNam.Checked && !rbtNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(sdt, @"^(\d{10}|\d{11})$"))
            {
                MessageBox.Show("Số điện thoại khách hàng không hợp lệ. Vui lòng nhập số điện thoại hợp lệ gồm 10 hoặc 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            KhachHangDTO kh = new KhachHangDTO
            {
                MaKH = lbMaKH.Text,
                TenKH = txtTenKH.Text,
                DiaChi_KH = txtDiaChi.Text,
                Phone_KH = txtSDT.Text,
                GioiTinh = rbtNam.Checked ? "Nam" : "Nữ",
                Trangthai = true,
            };
            if (_KHBUS.ThemKH(kh))
            {
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            LoadKhachHang();
            resetText();
            this.btnLamMoi_Click(sender, e);
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbtNam.Checked && !rbtNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string wN = "Bạn có Chắc Chắn Muốn XÓA Khách Hàng Này Không";
            DialogResult result = MessageBox.Show(wN, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                KhachHangDTO kh = new KhachHangDTO
                {
                    MaKH = lbMaKH.Text,

                    Trangthai = true
                };
                if (_KHBUS.xoaKH(kh))
                {
                    MessageBox.Show("Xóa Thành Công");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
            }
            else
            {

            }
            LoadKhachHang();
            resetText();
            this.btnLamMoi_Click(sender , e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rbMaKH.Checked)
            {
                KhachHangDTO sp = new KhachHangDTO
                {
                    MaKH = txtLookMaKH.Text
                };
                dgvKhachHang.DataSource = _KHBUS.LayDSMaKH(sp);
            }
            if (rbTenKH.Checked)
            {
                KhachHangDTO sp = new KhachHangDTO
                {
                    TenKH = txtLookMaKH.Text
                };
                dgvKhachHang.DataSource = _KHBUS.LayDSTenKH(sp);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbtNam.Checked && !rbtNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            KhachHangDTO kh = new KhachHangDTO
            {
                MaKH = lbMaKH.Text,
                TenKH = txtTenKH.Text,
                DiaChi_KH = txtDiaChi.Text,
                Phone_KH = txtSDT.Text,
                GioiTinh = rbtNam.Checked ? "Nam" : "Nữ",
                Trangthai = false
            };

            if (_KHBUS.suaKH(kh))
            {
                MessageBox.Show("Sửa Thành Công");
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
            LoadKhachHang();
            resetText();
            this.btnLamMoi_Click(sender, e);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString();
            if ((dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString()) == "Nam")
            {
                rbtNam.Checked = true;
            }
            else
            {
                rbtNu.Checked = true;
            }
        }
    }
}

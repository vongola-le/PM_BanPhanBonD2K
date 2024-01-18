using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class frm_TrangChu : Form
    {
        private string ROLE;
        public string role { get { return ROLE; } set { ROLE = value; } }
        public frm_TrangChu()
        {
            InitializeComponent();
            hideSubMenu();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public void hideSubMenu()
        {
            panelSubMenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
                PhanQuyen();
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        public void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnChucNang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu);
        }
        public void PhanQuyen()
        {
            if (role != "Admin")
            {
                btnQLNV.Visible = false;
                btnQLTK.Visible = false;
            }
            else
            {
                btnQLNV.Visible = true;
                btnQLTK.Visible = true;
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (result == DialogResult.OK)
            {
                frm_DangNhap loginForm = new frm_DangNhap();

                // Hiển thị màn hình đăng nhập
                loginForm.Show();

                // Đóng màn hình hiện tại
                this.Close();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng chương trình ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void btnQLHD_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_HoaDon());

            hideSubMenu();
        }
        private void btnQLNV_Click(object sender, EventArgs e)
        {
            
                openChildFormInPanel(new frm_NhanVien());

                hideSubMenu();
           
        }
        private void btnQLSP_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_SanPham());

            hideSubMenu();
        }
        private void btnQLTK_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_TaiKhoan());

            hideSubMenu();
        }
        private void btnQLKH_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_KhachHang());
            hideSubMenu();
        }
        private void frm_TrangChu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                this.Capture = false;

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {

            openChildFormInPanel(new frm_XemBaoCao());
            hideSubMenu();
        }
        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = frm_DangNhap._manv.ToString();
            txtUsername.Text = frm_DangNhap._tennv.ToString();
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            // Lặp qua các control trong panel1
            foreach (Control control in panelBody.Controls)
            {
                // Nếu control là một form con
                if (control is Form)
                {
                    // Ẩn form con
                    control.Hide();
                }
            }
        }


    }
}

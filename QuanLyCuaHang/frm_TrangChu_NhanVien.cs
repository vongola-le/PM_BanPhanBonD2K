using QuanLyCuaHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2K
{
    public partial class frm_TrangChu_NhanVien : Form
    {
        public frm_TrangChu_NhanVien()
        {
            InitializeComponent();
            hideSubMenu();

        }

        // Ẩn menu
        private void hideSubMenu()
        {
            panelSubMenu.Visible = false;
        }

        // Hiện menu
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnChucNang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu);
        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_DangNhap());

        }
        private void btnQLSP_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_SanPham());
         
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frm_HoaDon());

            hideSubMenu();
        }




        private void frm_TrangChu_NhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}

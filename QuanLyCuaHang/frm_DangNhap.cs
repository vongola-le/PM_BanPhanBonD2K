using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaitFormExample;

namespace QuanLyCuaHang
{
    public partial class frm_DangNhap : Form
    {
        WaitFormFunc waitForm = new WaitFormFunc();
        public static string _manv;
        public static string _tennv;
        public frm_DangNhap()
        {
            InitializeComponent();
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {

        }
        private void TrangChu_MouseDown(object sender, MouseEventArgs e)
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoanBUS taikhoanBUS = new TaiKhoanBUS();
            List<TaiKhoanDTO> lst = new List<TaiKhoanDTO>();
            lst = taikhoanBUS.KtTaiKhoan(txtUser.Text, Utils.GetMD5(txtPass.Text));
            if (lst.Count > 0)
            {
                string quyen = lst[0].Quyen.ToString();
                string manv = lst[0].MaNV.ToString();
                string tennv = lst[0].TenNV.ToString();
                _manv = manv;
                _tennv = tennv;
                waitForm.Show(this);
                Thread.Sleep(5000);
                frm_TrangChu f = new frm_TrangChu();
                f.role = quyen;
                this.Hide();
                f.Show();
                waitForm.Close();
                /*if(quyen == "Admin")
                {
                    this.Hide();
                    frm_TrangChu f=new frm_TrangChu();
                    f.Show();
                }
                else
                {
                    //this.Hide();
                    //frm_TrangChu f = new frm_TrangChu();
                    //f.Show();
                }*/
            }
            else
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Chính Xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

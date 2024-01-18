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
using System.IO;
using System.Data.Entity;

namespace QuanLyCuaHang
{
    public partial class frm_SanPham : Form
    {
        SanPhamBUS _SPBUS = new SanPhamBUS();

        List<string> lstLayMa = new List<string>();
        int demo()
        {
            dgvSanPham.DataSource = _SPBUS.LayMaSP();
            lstLayMa.Clear();
            for (int i = 0; i <= dgvSanPham.Rows.Count; i++)
            {
                string z = i.ToString();
                lstLayMa.Add(z);
            }
            int index = Convert.ToInt32(lstLayMa.Last<string>());

            int u = index;
            LoadSanPham();
            return u;
        }
        public frm_SanPham()
        {
            InitializeComponent();
            dgvSanPham.AutoGenerateColumns = false;
            LoadSanPham();

            int x = demo() ;
            x = x + 1;
            string s = x.ToString();
            string wN = "SP00" + s;
            lbMaSP.Text = wN;
        }
        void LoadSanPham()
        {
            dgvSanPham.DataSource = _SPBUS.LayDSSP();
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            int x = demo();
            x = x + 1;
            string s = x.ToString();
            string wN = "SP00" + s;
            lbMaSP.Text = wN;
        }
     
        void resetText()
        {
            int x = demo();
            string s = x.ToString();
            string wN = "SP00"+s;
            lbMaSP.Text = wN;
            txtTenSp.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            txtDVTinh.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            pbSanPham.Image = null;
            txtLookMasp.Text = string.Empty;
            txtLookTenSP.Text = string.Empty;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbMaSP.Text = dgvSanPham.Rows[e.RowIndex].Cells["clMaSp"].Value.ToString();
            string DG = dgvSanPham.Rows[e.RowIndex].Cells["clDonGia"].Value.ToString();
            string MT = dgvSanPham.Rows[e.RowIndex].Cells["clMoTa"].Value.ToString();
            txtTenSp.Text = dgvSanPham.Rows[e.RowIndex].Cells["clTenSP"].Value.ToString();
            txtSoLuong.Text = dgvSanPham.Rows[e.RowIndex].Cells["clSoLuong"].Value.ToString();
            txtDonGia.Text = DG;
            txtDVTinh.Text = dgvSanPham.Rows[e.RowIndex].Cells["clDonVi"].Value.ToString();
            byte[] imageData = (byte[])dgvSanPham.Rows[e.RowIndex].Cells["clHinhAnh"].Value;
            if (imageData != null)
            {
                MemoryStream ms = new MemoryStream(imageData);
                Image image = Image.FromStream(ms);
                pbSanPham.Image = image;
            }
            else
            {
                pbSanPham.Image = null;
            }
           
            if (string.IsNullOrEmpty(MT))
            {
                string temp = "Chưa có Mô Tả Cho Sản Phẩm";
                txtMoTa.Text = temp;
            }
            else
            {
                txtMoTa.Text = MT;
            }
            
           
           
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SanPhamBUS _SPreload = new SanPhamBUS();
            dgvSanPham.DataSource = _SPreload.LayDSSP();
            this.frm_SanPham_Load(sender, e);
            resetText();
            int x = demo();
            x = x + 1;
            string s = x.ToString();
            string wN = "SP00" + s;
            lbMaSP.Text = wN;
            pbSanPham.Image = Properties.Resources.icons8_no_image_50;
                 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int sl, dg;
            if (!int.TryParse(txtSoLuong.Text, out sl))
            {
                MessageBox.Show("Vui lòng nhập đúng sô lượng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDonGia.Text, out dg))
            {
                MessageBox.Show("Vui lòng nhập đúng sô lượng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenSp.Text))
            {
                string wN = "Vui lòng Nhập Tên Sản Phẩm";
                MessageBox.Show(wN, "Thông Báo");
                return;
            }
            else if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                string wN = "Vui lòng Đơn GiáSản Phẩm";
                MessageBox.Show(wN ,"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtDVTinh.Text))
            {
                string wN = "Vui lòng Đơn Vị Tính Của Sản Phẩm";
                MessageBox.Show(wN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dg <= 0)
            {
                string wN = "Đơn Giá Không Hợp Lệ, Vui Lòng Nhập Lại Đơn Giá";
                MessageBox.Show(wN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (sl <= 0)
            {
                string wN = "Số Lượng Không Hợp Lệ, Vui Lòng Nhập Lại Số Lượng";
                MessageBox.Show(wN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (pbSanPham.Image == null)
            {
                string wN = "Vui lòng chọn hình ảnh cho sản phẩm";
                MessageBox.Show(wN , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Chuyển đổi hình ảnh thành mảng byte
            byte[] imageData = null;
            using (MemoryStream ms = new MemoryStream())
            {
                pbSanPham.Image.Save(ms, pbSanPham.Image.RawFormat);
                imageData = ms.ToArray();
            }

            SanPhamDTO sp = new SanPhamDTO
            {
                MaSP = lbMaSP.Text.ToString(),
                TenSP = txtTenSp.Text,
                DonGia = dg,
                SoLuong = sl,
                DVTinh = txtDVTinh.Text,
                MoTa = string.IsNullOrEmpty(txtMoTa.Text) ? "Chưa có mô tả cho sản phẩm" : txtMoTa.Text,
                TrangThai = true,
                HinhAnh = imageData
               /* HinhAnh = imageData */// Lưu trữ mảng byte của hình ảnh
            };

            if (_SPBUS.ThemSP(sp))
            {
                MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Xóa các giá trị đã nhập trên giao diện người dùng và tải lại danh sách sản phẩm
            resetText();
            btnLamMoi_Click(sender, e);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rbMaSP.Checked)
            {
                SanPhamDTO sp = new SanPhamDTO
                {
                    MaSP = (txtLookMasp.Text)
                };
                dgvSanPham.DataSource = _SPBUS.LayDSMaSP(sp);
            }
            if (rbTenSP.Checked)
            {
                SanPhamDTO sp = new SanPhamDTO
                {
                    TenSP = txtLookTenSP.Text
                };
                dgvSanPham.DataSource = _SPBUS.LayDSTenSP(sp);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string wN = "Bạn có Chắc Chắn Muốn XÓA Sản Phẩm Này Không";
            DialogResult result = MessageBox.Show(wN, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SanPhamDTO sp = new SanPhamDTO
                {
                    MaSP = lbMaSP.Text,
                    //TenSP = txtTenSp.Text,
                    //DonGia = Convert.ToInt32(txtDonGia.Text),
                    //DVTinh = txtDVTinh.Text,
                    //MoTa = txtMoTa.Text,
                    //KhuyenMai = 0,
                    TrangThai = false
                };
                if (_SPBUS.xoaSP(sp))
                {
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadSanPham();
                resetText();
                this.btnLamMoi_Click(sender, e);
            }
            else
            {
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            // để mở hộp thoại chọn tệp tin ảnh từ bất kỳ ổ đĩa nào trên hệ thống
            ofdMinhHoa.InitialDirectory = ".";
            ofdMinhHoa.Filter = "Image file (*.jpg,*.jpeg,*.jpe,*.jfif,*.png)| *.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            ofdMinhHoa.FilterIndex = 2;
            ofdMinhHoa.RestoreDirectory = true;

            if (ofdMinhHoa.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofdMinhHoa.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            pbSanPham.Image = Image.FromStream(myStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EROOR: ***********" + ex.Message);
                }
                myStream.Close();
                myStream.Dispose();
                System.GC.Collect();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int sl, dg;
            if (!int.TryParse(txtSoLuong.Text, out sl))
            {
                MessageBox.Show("Vui lòng nhập đúng sô lượng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDonGia.Text, out dg))
            {
                MessageBox.Show("Vui lòng nhập đúng sô lượng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTenSp.Text))
            {
                string wN = "Vui lòng Nhập Tên Sản Phẩm";
                MessageBox.Show(wN , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                string wN = "Vui lòng Đơn Giá Sản Phẩm";
                MessageBox.Show(wN , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtDVTinh.Text))
            {
                string wN = "Vui lòng Đơn Vị Tính Của Sản Phẩm";
                MessageBox.Show(wN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dg <= 0)
            {
                string wN = "Đơn Giá Không Hợp Lệ, Vui Lòng Nhập Lại Đơn Giá";
                MessageBox.Show(wN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (sl <= 0)
            {
                string wN = "Số Lượng Không Hợp Lệ, Vui Lòng Nhập Lại Số Lượng";
                MessageBox.Show(wN , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //Chuyển đổi hình ảnh thành mảng byte
                byte[] imageData = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    pbSanPham.Image.Save(ms, pbSanPham.Image.RawFormat);
                    imageData = ms.ToArray();
                }
                SanPhamDTO sp = new SanPhamDTO
                {
                    MaSP = lbMaSP.Text,
                    TenSP = txtTenSp.Text,
                    SoLuong = sl,
                    DonGia = Convert.ToInt32(txtDonGia.Text),
                    DVTinh = txtDVTinh.Text,
                    MoTa = txtMoTa.Text,
                    TrangThai = true,
                    HinhAnh = imageData
                };
                if (_SPBUS.suaSP(sp))
                {
                    MessageBox.Show("Sửa Thành Công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadSanPham();
            resetText();
            this.btnLamMoi_Click(sender, e);
        }
    }
}

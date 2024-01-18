using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using DAO;
using log4net;
using System.Text.RegularExpressions;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;

namespace QuanLyCuaHang
{

    public partial class frm_CTHoaDon : Form
    {

        CT_HoaDonBUS _cthdBUS = new CT_HoaDonBUS();
        HoaDonBUS _hdBUS = new HoaDonBUS();
        KhachHangBUS _khBUS = new KhachHangBUS();
        SanPhamBUS _spBUS = new SanPhamBUS();
        NhanVienBUS _nvBUS = new NhanVienBUS();
        private string _maHoaDon;
        int SoLuongSP_trongKHO = 0;
        int vitri_dgvCTHD = 0;
        private bool daHienThongBao = false;
        public frm_CTHoaDon()
        {

            InitializeComponent();
            dgvCT_HoaDon.AutoGenerateColumns = false;
            LoadMaSP();
            _maHoaDon = _hdBUS.GetNewID();
            ReadOnlyAndEnable();
            // Ẩn nút "Lưu"
            btnLuuKH.Visible = false;

            // Hiển thị nút "Thêm mới"
            btnThemKH.Visible = true;
        }
        public void LoadNV()
        {
            txtMaNV.Text = frm_DangNhap._manv;
            txtTenNV.Text = frm_DangNhap._tennv;
        }
        public void LoadMaHD()
        {
            txtMaHD.Text = _maHoaDon.ToString();
        }
        public void LoadMaSP()
        {
            AutoCompleteStringCollection au = new AutoCompleteStringCollection();

            List<CT_HoaDonDTO> ds = _cthdBUS.LoadDSSP();

            foreach (var item in ds)
            {
                string ten = item.TenSP;
                au.Add(ten);
            }

            cbbMaSP.AutoCompleteCustomSource = au;
            cbbMaSP.DataSource = ds;
            cbbMaSP.DisplayMember = "MASP";
            cbbMaSP.ValueMember = "MASP";


        }
        public void LoadDSCTHD()
        {
            dgvCT_HoaDon.DataSource = _cthdBUS.LoadDSCTHD(txtMaHD.Text);

        }
        public void ReadOnlyAndEnable()
        {
            txtMaHD.ReadOnly = true;
            txtMaHD.Enabled = false;
            txtMaNV.ReadOnly = true;
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtTenNV.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtThanhTien.Enabled = false;
            txtTongTien.ReadOnly = true;
            txtTongTien.Enabled = false;
            txtTenSP.ReadOnly = true;
            txtTenSP.Enabled = false;
            txtDonGia.ReadOnly = true;
            txtDonGia.Enabled = false;
            txtThanhTien.ReadOnly = true;
            txtThanhTien.Enabled = false;
        }
        public void GiamGia()
        {
            string[] items = { "0%", "5%", "10%", "50%", "100%" };
            cbbGiamGia.Items.AddRange(items);
        }
        public void HideControl()
        {
            btnDong.Enabled = false;
            btnLuu.Enabled = false;
            btnLuuKH.Enabled = false;
            btnIn.Enabled = false;
            btnThemCTHD.Enabled = false;
            btnThemKH.Enabled = false;
        }
        private void frm_CTHoaDon_Load(object sender, EventArgs e)
        {
            GiamGia();
            LoadMaSP();
            LoadMaHD();
            LoadNV();

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // tạo biến sdt để lấy sdt từ textbox
            string sdt = txtSDT.Text.Trim();
            
            // Kiểm tra
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại khách hàng");
                return;
            }
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                errorProvider1.SetError(txtTenKH, "Vui lòng nhập tên khách hàng");
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
                return;
            }
            if (string.IsNullOrEmpty(nudSoLuong.Text))
            {
                errorProvider1.SetError(nudSoLuong, "Vui lòng chọn số lượng");
                return;
            }
            if (string.IsNullOrEmpty(cbbGiamGia.Text))
            {
                errorProvider1.SetError(cbbGiamGia, "Vui lòng chọn số lượng");
                return;
            }
            if (!Regex.IsMatch(sdt, @"^(\d{10}|\d{11})$"))
            {
                MessageBox.Show("Số điện thoại khách hàng không hợp lệ. Vui lòng nhập số điện thoại hợp lệ gồm 10 hoặc 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            errorProvider1.Clear();
            
            // sau đí tạo ra đối tượng KhachHangDTO mới từ SĐT lấy từ biến sdt
            KhachHangDTO _khSDT = new KhachHangDTO { Phone_KH = sdt };
            string maKH = _khBUS.GetMaKHByPhone(_khSDT);
            if (maKH == null)
            {
                MessageBox.Show("Khách hàng không tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Tạo mới một đối tượng hóa đơn
            HoaDonDTO newEF = new HoaDonDTO
            {
                // Gán các giá trị cho đối tượng hóa đơn
                // Ví dụ:
                MaHD = txtMaHD.Text,
                NgayLayHD = DateTime.Now,
                MaNV = txtMaNV.Text,
                MaKH = maKH,
                ThanhTien = Convert.ToDecimal(txtThanhTien.Text)
            };
            // Thêm đối tượng hóa đơn vào cơ sở dữ liệu
            if (_hdBUS.Add(newEF))
            {
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Thêm các item vào dgvCT_HoaDon
            for (int i = 0; i < dgvCT_HoaDon.RowCount - 1; i++)
            {
                CT_HoaDonDTO _newEF = new CT_HoaDonDTO
                {
                    MaHD = txtMaHD.Text.ToString(),
                    MaSP = dgvCT_HoaDon.Rows[i].Cells["MASP"].Value.ToString(),
                    SoLuong = Convert.ToInt32(dgvCT_HoaDon.Rows[i].Cells["SOLUONG"].Value.ToString()),
                    DonGia = Convert.ToInt32(dgvCT_HoaDon.Rows[i].Cells["DONGIA"].Value.ToString()),
                    GiamGia = decimal.Parse(dgvCT_HoaDon.Rows[i].Cells["GIAM"].Value.ToString()),
                    ThanhTien = decimal.Parse(dgvCT_HoaDon.Rows[i].Cells["THANHTIEN"].Value.ToString())
                };
                SanPhamDTO sp = new SanPhamDTO
                {
                    MaSP = dgvCT_HoaDon.Rows[i].Cells["MASP"].Value.ToString(),
                    SoLuong = Convert.ToInt32(dgvCT_HoaDon.Rows[i].Cells["SOLUONG"].Value.ToString()),
                };
                _spBUS.CapNhatSoLuong(sp);
            }

        }
        private void btnDong_Click(object sender, EventArgs e)
        {

            //gọi phương thức LoadDS() thông qua thuộc tính owner bên frm_HoaDon
            frm_HoaDon parentForm = (frm_HoaDon)this.Owner;
            parentForm.LoadDS();
            this.Close();
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            // Reset các TextBox
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";

            // Hiện nút "Lưu"
            btnLuuKH.Visible = true;

            // Ẩn nút "Thêm mới"
            btnThemKH.Visible = false;
        }
        private void btnLuuKH_Click(object sender, EventArgs e)
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

            if (!Regex.IsMatch(sdt, @"^(\d{10}|\d{11})$"))
            {
                MessageBox.Show("Số điện thoại khách hàng không hợp lệ. Vui lòng nhập số điện thoại hợp lệ gồm 10 hoặc 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string makh = _khBUS.GetNextCustomerId();
            KhachHangDTO newKH = new KhachHangDTO()
            {
                MaKH = makh,
                Phone_KH = sdt,
                TenKH = tenKH,
                GioiTinh = "Nam",
                DiaChi_KH = diaChi,
            };

            if (_khBUS.ThemKH(newKH))
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn nút "Lưu"
                btnLuuKH.Visible = false;
                // Hiện nút "Thêm khách hàng"
                btnThemKH.Visible = true;
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Open(@"C:\Users\delam\OneDrive\Máy tính\0306211014\DoAn_Winform\Print_HoaDon.xlsx");
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];
            COMExcel.Range exRange;
            int hang = 0, cot = 0;

            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B1"].Value = "Cửa hàng Phân Bón D2K";
            exRange.Range["A2:B2"].Value = "Bình Chánh - TP.HCM";
            exRange.Range["A3:B3"].Value = "Điện thoại: 0769893323";
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";

            // Biểu diễn thông tin chung của hóa đơn bán
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].Value = txtMaHD.Text;

            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].Value = txtTenKH.Text;

            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].Value = txtDiaChi.Text;

            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].Value = txtSDT.Text;

            //Lấy thông tin các mặt hàng
            //Tạo dòng tiêu đề bảng
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";

            List<string> columnsToPrint = new List<string> { "TENSP", "SOLUONG", "DONGIA", "GIAM", "THANHTIEN" };

            int count = 0;
            for (int row = 0; row < dgvCT_HoaDon.Rows.Count; row++)
            {
                if (!dgvCT_HoaDon.Rows[row].IsNewRow && !string.IsNullOrEmpty(dgvCT_HoaDon.Rows[row].Cells[0].Value?.ToString()))
                {
                    count++;
                    exSheet.Cells[row + 12, 1] = count;
                }

                // Điền thông tin hàng từ cột thứ 2, dòng 12
                int colIndex = 2;
                foreach (string columnName in columnsToPrint)
                {
                    int col = dgvCT_HoaDon.Columns[columnName].Index; // Lấy chỉ số cột của tên cột
                    object cellValue = dgvCT_HoaDon.Rows[row].Cells[col].Value;
                    if (cellValue != null)
                    {
                        exSheet.Cells[row + 12, colIndex] = cellValue.ToString();
                    }
                    else
                    {
                        exSheet.Cells[row + 12, colIndex] = "";
                    }
                    colIndex++; // Tăng chỉ số cột trong file Excel
                }
            }
            // Tạo hàng và cột theo chỉ định
            exRange = exSheet.Cells[cot + 1][hang + 14]; //Ô A1 
            // Tổng tiền
            exRange.Range["D1"].Value = "Tổng tiền: ";
            exRange.Range["E1:F1"].Value = decimal.Parse(txtTongTien.Text) + " VNĐ";
            // Tiền bằng chữ
            string tongTienChu = "Bằng chữ: " + Convert.ToDecimal(txtTongTien.Text).ToString("N0", CultureInfo.CurrentCulture.NumberFormat) + " đồng";
            exRange.Range["A2:F2"].Value = tongTienChu;
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            // Ngày lập hóa đơn
            DateTime d = Convert.ToDateTime(dtpNgayLapHD.Value);
            exRange.Range["A1:C1"].Value = "TP.HCM, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            // Nhân viên hóa đơn
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A4:C4"].Value = "Lê Hoàng Đệ";

            exApp.Visible = true;
        }
        // Thêm sản phẩm vào dgv CTHD
        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị nhập vào từ người dùng
            if (string.IsNullOrWhiteSpace(cbbMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(nudSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng sản phẩm không hợp lệ. Vui lòng nhập số lượng lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(cbbGiamGia.Text.TrimEnd('%'), out decimal giamGia) || giamGia < 0)
            {
                MessageBox.Show("Giảm giá sản phẩm không hợp lệ. Vui lòng nhập giảm giá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CT_HoaDonDTO newEF = new CT_HoaDonDTO
            {
                MaSP = cbbMaSP.Text.ToString(),
                TenSP = txtTenSP.Text.ToString(),
                SoLuong = Convert.ToInt32(nudSoLuong.Text),
                DonGia = Convert.ToInt32(decimal.Parse(txtDonGia.Text)),
                GiamGia = Convert.ToDecimal(cbbGiamGia.Text.TrimEnd('%')),
                ThanhTien = Convert.ToInt32(decimal.Parse(txtThanhTien.Text)),
                Trangthai = true

            };
            // Tạo một dòng mới trong DataGridView và gán giá trị cho các ô của dòng đó.
            DataGridViewRow row = new DataGridViewRow();
            // Tạo các ô cho dòng mới và liên kết chúng với DataGridView hiện tại.
            row.CreateCells(dgvCT_HoaDon);
            //Gán giá trị của trường MaSP của đối tượng newEF cho các ô tương tự.
            row.Cells[0].Value = newEF.MaSP;
            row.Cells[1].Value = newEF.TenSP;
            row.Cells[2].Value = newEF.SoLuong;
            row.Cells[3].Value = newEF.DonGia;
            row.Cells[4].Value = newEF.GiamGia;
            row.Cells[5].Value = newEF.ThanhTien;
            for (int i = 0; i < dgvCT_HoaDon.RowCount - 1; i++)
            {
                if (dgvCT_HoaDon.Rows[i].Cells[0].Value.ToString() == newEF.MaSP.ToString())
                {
                    MessageBox.Show("Sản phẩm này đã tồn tại trong hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dgvCT_HoaDon.Rows.Add(row);
            cbbGiamGia.Enabled = false;
            int tongtien = Convert.ToInt32(txtTongTien.Text);
            int thanhtien = Convert.ToInt32(newEF.ThanhTien);
            tongtien += thanhtien;
            txtTongTien.Text = tongtien.ToString();

            // Xóa các giá trị nhập vào của sản phẩm
            cbbMaSP.Text = "";
            txtTenSP.Text = "";
            nudSoLuong.Value = 1;
            txtDonGia.Text = "";
            txtThanhTien.Text = "0";
            cbbMaSP.Focus();
        }
        private void btnSuadgv_Click(object sender, EventArgs e)
        {
            CT_HoaDonDTO newEF = new CT_HoaDonDTO
            {
                MaSP = cbbMaSP.Text.ToString(),
                TenSP = txtTenSP.Text.ToString(),
                SoLuong = Convert.ToInt32(nudSoLuong.Text),
                DonGia = Convert.ToInt32(decimal.Parse(txtDonGia.Text)),
                GiamGia = Convert.ToDecimal(cbbGiamGia.Text.TrimEnd('%')),
                ThanhTien = Convert.ToInt32(decimal.Parse(txtThanhTien.Text)),
                Trangthai = true

            };
            int vitri = -1;
            for(int i=0;i<dgvCT_HoaDon.RowCount-1;i++)
            {
                if(newEF.MaSP == dgvCT_HoaDon.Rows[i].Cells[0].Value)
                {
                    vitri = i;
                    break;
                }
            }    
            if(vitri != -1)
            {
                dgvCT_HoaDon.Rows[vitri].Cells[0].Value = newEF.MaSP;
                dgvCT_HoaDon.Rows[vitri].Cells[1].Value = newEF.TenSP;
                dgvCT_HoaDon.Rows[vitri].Cells[2].Value = newEF.SoLuong;
                dgvCT_HoaDon.Rows[vitri].Cells[3].Value = newEF.DonGia;
                dgvCT_HoaDon.Rows[vitri].Cells[4].Value = newEF.GiamGia;
                dgvCT_HoaDon.Rows[vitri].Cells[5].Value = newEF.ThanhTien;
                MessageBox.Show("Sửa thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information );   
            }    
        }
        // Gợi ý sản phẩm thông qua MaSP
        private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CT_HoaDonDTO> ds = _cthdBUS.LoadDSSP();

            foreach (var item in ds)
            {
                if (cbbMaSP.SelectedValue.ToString() == item.MaSP.ToString())
                {
                    txtTenSP.Text = item.TenSP.ToString();
                    txtDonGia.Text = item.DonGia.ToString();
                    SoLuongSP_trongKHO = int.Parse(item.SoLuong.ToString());
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvCT_HoaDon.Rows.Count-1 > vitri_dgvCTHD)
            {
                dgvCT_HoaDon.Rows.RemoveAt(vitri_dgvCTHD);
            }
        }

        // Chọn item trong cbbGiamGia để tính thành tiền 
        private void cbbGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int giaban = Convert.ToInt32(decimal.Parse(txtDonGia.Text));
            int soluong = int.Parse(nudSoLuong.Value.ToString());
            decimal chietkhau = 0;
            if (cbbGiamGia.SelectedIndex == 1)
            {
                chietkhau = 0.05m;
            }
            else if (cbbGiamGia.SelectedIndex == 2)
            {
                chietkhau = 0.1m;
            }
            else if (cbbGiamGia.SelectedIndex == 3)
            {
                chietkhau = 0.5m;
            }
            else if (cbbGiamGia.SelectedIndex == 4)
            {
                chietkhau = 1m;
            }
            int thanhtien = Convert.ToInt32((giaban * soluong) * (1 - chietkhau));
            txtThanhTien.Text = thanhtien.ToString();
        }

        // Gợi ý SĐT thông qua PHONE in KHACHHANG 
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            // khởi tạo đối tượng ds
            List<KhachHangDTO> ds = _khBUS.LayDSKH();

            // duyệt phần tử có trong ds
            foreach (var item in ds)
            {
                if (txtSDT.Text == item.Phone_KH.ToString())
                {
                    txtTenKH.Text = item.TenKH.ToString();
                    txtDiaChi.Text = item.DiaChi_KH.ToString();
                }

            }
        }
        private void dgvCT_HoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            vitri_dgvCTHD = e.RowIndex;
            if (i == -1) return;

            if (dgvCT_HoaDon.Rows[i].Cells["MASP"] != null && dgvCT_HoaDon.Rows[i].Cells["MASP"].Value != null)
            {
                cbbMaSP.Text = dgvCT_HoaDon.Rows[i].Cells["MASP"].Value.ToString();
            }
            else
            {

                MessageBox.Show("Vui lòng chọn đúng dòng dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtTenSP.Text = dgvCT_HoaDon.Rows[i].Cells["TENSP"].Value.ToString();
            nudSoLuong.Value = decimal.Parse(dgvCT_HoaDon.Rows[i].Cells["SOLUONG"].Value.ToString());
            txtDonGia.Text = dgvCT_HoaDon.Rows[i].Cells["DONGIA"].Value.ToString();
            cbbGiamGia.Text = dgvCT_HoaDon.Rows[i].Cells["GIAM"].Value.ToString();
            txtThanhTien.Text = dgvCT_HoaDon.Rows[i].Cells["THANHTIEN"].Value.ToString();
        }
      
        private void TinhTongTien()
        {
            int soluong = int.Parse(nudSoLuong.Value.ToString());
            int dongia = int.Parse(txtDonGia.Text);
            decimal giamgia = 0;
            if (cbbGiamGia.SelectedIndex != -1)
            {
                giamgia = int.Parse(cbbGiamGia.Text.TrimEnd('%'));
            }
            decimal thanhtien = (soluong * dongia);
            decimal tiengiam = thanhtien * (giamgia / 100);
            int thanhtiencuoicung = Convert.ToInt32(thanhtien - tiengiam);
            txtThanhTien.Text = thanhtiencuoicung.ToString();
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            int soluong = int.Parse(nudSoLuong.Value.ToString());
            if (SoLuongSP_trongKHO == 0)
            {
                MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (soluong > SoLuongSP_trongKHO)
            {
                if (!daHienThongBao) // kiểm tra cờ thông báo
                {

                    DialogResult dlgThoat;
                    dlgThoat = MessageBox.Show($"Số lượng sản phẩm trong kho còn {SoLuongSP_trongKHO}, bạn có muốn bán hết ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgThoat == DialogResult.Yes)
                    {
                        daHienThongBao = true;

                        nudSoLuong.Value = SoLuongSP_trongKHO;
                    }
                    else
                    {
                        daHienThongBao = true;
                        nudSoLuong.Value = 0;

                    }

                }
                TinhTongTien();
            }
            else
            {
                TinhTongTien();
            }
        }
    }
}

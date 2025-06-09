using BLL_QLKS;
using DAL_QLKS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLKS
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachNhanVien();
        }

        public void LoadDanhSachNhanVien()
        {
            BUSKhachHang bus = new BUSKhachHang();
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = bus.GetKhachHangList(); // Sử dụng phương thức mới
            

            dgvKhachHang.Columns["KhachHangID"].HeaderText = "Mã Khách hàng";
            dgvKhachHang.Columns["KhachHangID"].Width = 150;
            dgvKhachHang.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns["CCCD"].HeaderText = "CCCD";
            dgvKhachHang.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvKhachHang.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvKhachHang.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvKhachHang.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ClearForm()
        {
            txtMaKhachHang.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtGhiChu.Clear();
            txtDiaChi.Clear();
            txtPhone.Clear();
            txtCCCD.Clear();
            dtpNgayTao.Value = DateTime.Now;
            rdoHoatDong.Checked = true; 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }
    }
}

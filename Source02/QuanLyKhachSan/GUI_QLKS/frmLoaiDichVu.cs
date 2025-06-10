using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QLKS;
using BUS_QLKS;
using DAL_QLKS;

namespace GUI_QLKS
{
    public partial class frmLoaiDichVu : Form
    {
        BUSDatDichVu busLoaiDichVu = new BUSDatDichVu();
        public frmLoaiDichVu()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaNV.Clear();
            txtTenNhanVien.Clear();
            txtDiaChi.Clear();
            rdoHoatDong.Checked = true;
        }
        private void LoadDanhSachLoaiDichVu()
        {
            dgvLoaiDichVu.DataSource = null;
            dgvLoaiDichVu.DataSource = busLoaiDichVu.GetDichVuList();

            dgvLoaiDichVu.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvLoaiDichVu.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvLoaiDichVu.Columns["Email"].HeaderText = "Email";
            dgvLoaiDichVu.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvLoaiDichVu.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvLoaiDichVu.Columns["VaiTro"].HeaderText = "Vai Trò";
            dgvLoaiDichVu.Columns["TinhTrangText"].HeaderText = "Trạng Thái";
            dgvLoaiDichVu.Columns["TinhTrang"].Visible = false;
            dgvLoaiDichVu.Columns["MatKhau"].Visible = false;

            dgvLoaiDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void frmLoaiDichVu_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}

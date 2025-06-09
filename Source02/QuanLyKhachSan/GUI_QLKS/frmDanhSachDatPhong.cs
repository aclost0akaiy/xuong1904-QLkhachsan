using BLL_QLKS;
using BUS_QLKS;
using DAL_QLKS;
using DTO_QLKS;
using DTO_QuanLyKhachSan;
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
    public partial class frmDanhSachDatPhong : Form
    {
        public frmDanhSachDatPhong()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;            
        }

        private void LoadDanhSachDatPhong(string maKhachHang = "")
        {
            try
            {
                BUSDatPhong busDatPhong = new BUSDatPhong();
                List<DatPhong> lstDatPhong = busDatPhong.GetDatPhongList();
                dgvDatPhong.DataSource = lstDatPhong;
                dgvDatPhong.Columns["HoaDonThueID"].HeaderText = "Mã Đặt Phòng";
                dgvDatPhong.Columns["KhachHangID"].HeaderText = "Khách Hàng";
                dgvDatPhong.Columns["PhongID"].HeaderText = "Phòng";
                dgvDatPhong.Columns["NgayDen"].HeaderText = "Ngày Đến";
                dgvDatPhong.Columns["NgayDi"].HeaderText = "Ngày Đi";
                dgvDatPhong.Columns["MaNV"].HeaderText = "Nhân Viên";
                dgvDatPhong.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dgvDatPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đặt phòng: " + ex.Message,
                              "Lỗi",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }


        private void frmDanhSachDatPhong_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDatPhong();
        }

        private void btnThem_Click(object sender, EventArgs e)
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

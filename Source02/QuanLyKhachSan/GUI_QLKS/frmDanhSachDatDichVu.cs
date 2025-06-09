using BLL_QLKS;
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
    public partial class frmDanhSachDatDichVu : Form
    {
        public frmDanhSachDatDichVu()
        {
            InitializeComponent();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDanhSachDatDichVu_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDichVu();
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void LoadDanhSachDichVu()
        {
            try
            {
                BUSDatDichVu busDatDichVu = new BUSDatDichVu();
                List<DichVu> lstDatPhong = busDatDichVu.GetDichVuList();
                dgvDatDichVu.DataSource = lstDatPhong;
                dgvDatDichVu.Columns["DichVuID"].HeaderText = "Mã Đặt Dịch Vụ";
                dgvDatDichVu.Columns["HoaDonThueID"].HeaderText = "Mã Dặt Phòng";
                dgvDatDichVu.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvDatDichVu.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                dgvDatDichVu.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dgvDatDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đặt phòng: " + ex.Message,
                              "Lỗi",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}

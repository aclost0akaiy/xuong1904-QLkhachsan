using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLKS;
using DAL_QLKS;

namespace GUI_QLKS
{
    public partial class frmLoaiPhong : Form
    {
        BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachLoaiPhong();
        }
        private void LoadDanhSachLoaiPhong()
        {
            dgvLoaiPhong.DataSource = null;
            dgvLoaiPhong.DataSource = busLoaiPhong.GetDSLoaiPhong();

            dgvLoaiPhong.Columns["MaLoaiPhong"].HeaderText = "Mã Loại Phòng";
            dgvLoaiPhong.Columns["MaLoaiPhong"].Width = 120;
            dgvLoaiPhong.Columns["TenLoaiPhong"].HeaderText = "Tên Loại Phòng";
            dgvLoaiPhong.Columns["SoGiuong"].HeaderText = "Số Giường";
            dgvLoaiPhong.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvLoaiPhong.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvLoaiPhong.Columns["TrangThai"].Visible = false;
            dgvLoaiPhong.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvLoaiPhong.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}

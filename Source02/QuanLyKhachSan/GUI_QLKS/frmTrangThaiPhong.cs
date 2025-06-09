using BUS_QLKS;
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
    public partial class frmTrangThaiPhong : Form
    {
        BusLoaiTrangThai busLoaiTrangThai = new BusLoaiTrangThai();
        public frmTrangThaiPhong()
        {
            InitializeComponent();
        }

        private void frmTrangThaiPhong_Load(object sender, EventArgs e)
        {
            LoadTrangThaiPhong();
            ClearForm();
        }

        private void LoadTrangThaiPhong()
        {
            dgvTrangThaiPhong.DataSource = null;
            dgvTrangThaiPhong.DataSource = busLoaiTrangThai.GetLoaiTrangThaiPhongList();

            dgvTrangThaiPhong.Columns["LoaiTrangThaiID"].HeaderText = "Mã Trạng Thái";
            dgvTrangThaiPhong.Columns["TenTrangThai"].HeaderText = "Tên Trạng Thái";

            dgvTrangThaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaTrangThai.Clear();
            txtTenTrangThai.Clear();
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

using BLL_QLKS;
using DAL_QLKS;
using DTO_QLKS;
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
        BUSKhachHang busKhachHang = new BUSKhachHang();
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
            dgvKhachHang.DataSource = bus.GetKhachHangListForDisplay(); // Sử dụng phương thức mới


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
            dgvKhachHang.CellDoubleClick += dgvKhachHang_CellDoubleClick;
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
            cboGioiTinh.SelectedIndex = 0; // Đặt mặc định là "Nam"
            rdoHoatDong.Checked = true; // Đặt mặc định là "Hoạt động"
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang khachHang = new KhachHang
            {
                KhachHangID = txtMaKhachHang.Text,
                HoTen = txtTenKhachHang.Text,
                DiaChi = txtDiaChi.Text,
                GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                SoDienThoai = txtPhone.Text,
                CCCD = txtCCCD.Text,
                NgayTao = dtpNgayTao.Value,
                TrangThai = rdoHoatDong.Checked,
                GhiChu = txtGhiChu.Text
            };

            string result = busKhachHang.InsertKhachHang(khachHang);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang khachHang = new KhachHang
            {
                KhachHangID = txtMaKhachHang.Text,
                HoTen = txtTenKhachHang.Text,
                DiaChi = txtDiaChi.Text,
                GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                SoDienThoai = txtPhone.Text,
                CCCD = txtCCCD.Text,
                NgayTao = dtpNgayTao.Value,
                TrangThai = rdoHoatDong.Checked,
                GhiChu = txtGhiChu.Text
            };

            string result = busKhachHang.UpdateKhachHang(khachHang);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string result = busKhachHang.DeleteKhachHang(txtMaKhachHang.Text);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachNhanVien();
            MessageBox.Show("Đã làm mới form thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKhachHang.Text = row.Cells["KhachHangID"].Value?.ToString();
                txtTenKhachHang.Text = row.Cells["HoTen"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                cboGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
                dtpNgayTao.Value = row.Cells["NgayTao"].Value != null ? Convert.ToDateTime(row.Cells["NgayTao"].Value) : DateTime.Now;
                bool trangThai = row.Cells["TrangThai"].Value?.ToString() == "Đang hoạt động";
                rdoHoatDong.Checked = trangThai;
                rdoKhongHoatDong.Checked = !trangThai;
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

                txtMaKhachHang.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}

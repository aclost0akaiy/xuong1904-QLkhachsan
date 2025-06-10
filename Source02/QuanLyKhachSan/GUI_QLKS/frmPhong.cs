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
using DTO_QLKS;

namespace GUI_QLKS
{
    public partial class frmPhong : Form
    {
        BUSPhong busPhong = new BUSPhong();
        public frmPhong()
        {
            InitializeComponent();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab != null)
            {
                if (guna2TabControl1.SelectedTab.Name == "tabLoaiPhong")
                {
                    TabPage tab = guna2TabControl1.SelectedTab;
                    frmLoaiPhong frm = new frmLoaiPhong();
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;

                    tab.Controls.Add(frm);
                    frm.Show();
                    return;
                }
                if (guna2TabControl1.SelectedTab.Name == "tabTrangThaiPhong")
                {
                    TabPage tab = guna2TabControl1.SelectedTab;
                    frmTrangThaiPhong frm = new frmTrangThaiPhong();
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;

                    tab.Controls.Add(frm);
                    frm.Show();
                    return;
                }
            }
        }

        private void frmPhong2_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
            ClearForm();
            CBSoGiuong.Items.Clear();
            CBSoGiuong.Items.AddRange(new object[] { 1, 2, 3, 4 });
            CBSoGiuong.SelectedIndex = 0;
        }

        private void LoadDanhSachPhong()
        {
            dgvPhong.DataSource = null;
            dgvPhong.DataSource = busPhong.GetDSPhong();

            dgvPhong.Columns["PhongID"].HeaderText = "Mã Phòng";
            dgvPhong.Columns["PhongID"].Width = 100;
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvPhong.Columns["MaLoaiPhong"].HeaderText = "Mã Loại Phòng";
            dgvPhong.Columns["GiaPhong"].HeaderText = "Giá Phòng";
            dgvPhong.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";
            dgvPhong.Columns["SoGiuong"].HeaderText = "Số Giường";
            dgvPhong.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvPhong.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPhong.Columns["TinhTrang"].Visible = false;
            dgvPhong.Columns["TinhTrangText"].HeaderText = "Trạng Thái";
            dgvPhong.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearForm()
        {
            txtMaPhong.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtDiaChi.Clear();
            txtGiaPhong.Clear();
            CBSoGiuong.SelectedIndex = 0;
            NgayTao.Value = DateTime.Now;
            txtGhiChu.Clear();
            rdoHoatDong.Checked = true;
        }



        private void dgvPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["PhongID"].Value?.ToString() ?? "";
                txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["MaLoaiPhong"].Value?.ToString() ?? ""; // Sử dụng txtDiaChi cho MaLoaiPhong
                txtGiaPhong.Text = row.Cells["GiaPhong"].Value?.ToString() ?? "";
                CBSoGiuong.SelectedItem = row.Cells["SoGiuong"].Value;
                NgayTao.Value = row.Cells["NgayTao"].Value != null ? (DateTime)row.Cells["NgayTao"].Value : DateTime.Now;
                bool tinhTrang = row.Cells["TinhTrang"].Value != null && (bool)row.Cells["TinhTrang"].Value;
                rdoHoatDong.Checked = tinhTrang;
                rdoKhongHoatDong.Checked = !tinhTrang;
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                txtMaPhong.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenPhong.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtGiaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaPhong.Text, out decimal giaPhong) || giaPhong <= 0)
            {
                MessageBox.Show("Giá phòng phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Phong phong = new Phong
            {
                TenPhong = txtTenPhong.Text.Trim(),
                MaLoaiPhong = txtDiaChi.Text.Trim(),
                GiaPhong = giaPhong,
                SoGiuong = (int)CBSoGiuong.SelectedItem,
                NgayTao = NgayTao.Value,
                TinhTrang = rdoHoatDong.Checked,
                GhiChu = txtGhiChu.Text.Trim()
            };

            string result = busPhong.InsertPhong(phong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadDanhSachPhong();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaPhong.Text, out decimal giaPhong) || giaPhong <= 0)
            {
                MessageBox.Show("Giá phòng phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Phong phong = new Phong
            {
                PhongID = txtMaPhong.Text.Trim(),
                TenPhong = txtTenPhong.Text.Trim(),
                MaLoaiPhong = txtDiaChi.Text.Trim(),
                GiaPhong = giaPhong,
                SoGiuong = (int)CBSoGiuong.SelectedItem,
                NgayTao = NgayTao.Value,
                TinhTrang = rdoHoatDong.Checked,
                GhiChu = txtGhiChu.Text.Trim()
            };

            string result = busPhong.UpdatePhong(phong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadDanhSachPhong();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string result = busPhong.DeletePhong(txtMaPhong.Text);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachPhong();
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
            LoadDanhSachPhong();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachPhong();
                return;
            }

            List<Phong> filteredList = busPhong.GetDSPhong()
                .Where(p => p.PhongID.Contains(keyword) || p.TenPhong.Contains(keyword) ||
                           p.MaLoaiPhong.Contains(keyword) || (p.GhiChu?.Contains(keyword) ?? false))
                .ToList();
            dgvPhong.DataSource = null;
            dgvPhong.DataSource = filteredList;
        }
    }
}

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
using DTO_QLKS;

namespace GUI_QLKS
{
    public partial class frmDichVu : Form
    {
        BUSDichVu busDichVu = new BUSDichVu();
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab != null)
            {
                if (guna2TabControl1.SelectedTab.Name == "tabLoaiDV")
                {
                    TabPage tab = guna2TabControl1.SelectedTab;
                    frmLoaiDichVu frm = new frmLoaiDichVu();
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;

                    tab.Controls.Clear();
                    tab.Controls.Add(frm);
                    frm.Show();
                    return;
                }
            }
        }

        private void LoadDanhSachDichVu()
        {
            BUSDichVu bus = new BUSDichVu();
            dgvTrangThaiPhong.DataSource = null;
            dgvTrangThaiPhong.DataSource = bus.GetDSDichVu();

            dgvTrangThaiPhong.Columns["DichVuID"].HeaderText = "Mã Dịch Vụ";
            dgvTrangThaiPhong.Columns["DichVuID"].Width = 150;
            dgvTrangThaiPhong.Columns["HoaDonThueID"].HeaderText = "Mã Hóa Đơn Thuê";
            dgvTrangThaiPhong.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvTrangThaiPhong.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTrangThaiPhong.Columns["TrangThai"].Visible = false;
            dgvTrangThaiPhong.Columns["TrangThaiText"].HeaderText = "Trạng thái";
            dgvTrangThaiPhong.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvTrangThaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaDichVu.Clear();
            txtMaHoaDon.Clear();
            NgayTao.Value = DateTime.Now; 
            txtGhiChu.Clear();
            txtMaDichVu.Enabled = true;
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDichVu();
        }

        private void dgvTrangThaiPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTrangThaiPhong.Rows[e.RowIndex];
                txtMaDichVu.Text = row.Cells["DichVuID"].Value?.ToString() ?? "";
                txtMaHoaDon.Text = row.Cells["HoaDonThueID"].Value?.ToString() ?? "";
                NgayTao.Value = row.Cells["NgayTao"].Value == null ? DateTime.Now : (DateTime)row.Cells["NgayTao"].Value;
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaDichVu.Enabled = false;
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text) || string.IsNullOrWhiteSpace(txtGhiChu.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DichVu dv = new DichVu
                {
                    HoaDonThueID = txtMaHoaDon.Text.Trim(),
                    NgayTao = NgayTao.Value,
                    TrangThai = true, 
                    GhiChu = txtGhiChu.Text.Trim()
                };

                string result = busDichVu.InsertDichVu(dv);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachDichVu();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDichVu.Text))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DichVu dv = new DichVu
                {
                    DichVuID = txtMaDichVu.Text.Trim(),
                    HoaDonThueID = txtMaHoaDon.Text.Trim(),
                    NgayTao = NgayTao.Value,
                    TrangThai = true, 
                    GhiChu = txtGhiChu.Text.Trim()
                };

                DichVu dvCurrent = busDichVu.GetDichVuById(dv.DichVuID);
                if (dvCurrent != null)
                    dv.TrangThai = dvCurrent.TrangThai;

                string result = busDichVu.UpdateDichVu(dv);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachDichVu();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachDichVu();
                return;
            }

            List<DichVu> filteredList = busDichVu.GetDSDichVu()
                .Where(dv => dv.DichVuID.Contains(keyword) || (dv.HoaDonThueID?.Contains(keyword) ?? false) || (dv.GhiChu?.Contains(keyword) ?? false))
                .ToList();
            dgvTrangThaiPhong.DataSource = null;
            dgvTrangThaiPhong.DataSource = filteredList;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string dichVuID = txtMaDichVu.Text.Trim();
            if (string.IsNullOrEmpty(dichVuID))
            {
                if (dgvTrangThaiPhong.SelectedRows.Count > 0)
                {
                    dichVuID = dgvTrangThaiPhong.SelectedRows[0].Cells["DichVuID"].Value?.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dịch vụ để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa dịch vụ {dichVuID}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string kq = busDichVu.DeleteDichVu(dichVuID);
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa dịch vụ {dichVuID} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachDichVu();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDichVu();
        }
    }
}

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

                    tab.Controls.Add(frm);
                    frm.Show();
                    return;
                }
            }
        }

        private void LoadDanhSachDichVu()
        {
            dgvTrangThaiPhong.DataSource = null;
            dgvTrangThaiPhong.DataSource = busDichVu.GetDSDichVu();
            dgvTrangThaiPhong.Columns["DichVuID"].HeaderText = "Mã Dịch Vụ";
            dgvTrangThaiPhong.Columns["HoaDonThueID"].HeaderText = "Mã Hóa Đơn Thuê";
            dgvTrangThaiPhong.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvTrangThaiPhong.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvTrangThaiPhong.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvTrangThaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaDichVu.Clear();
            txtMaHoaDon.Clear();
            NgayTao.Value = DateTime.Now;
            txtGhiChu.Clear();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDichVu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                DichVu dv = new DichVu
                {
                    HoaDonThueID = txtMaHoaDon.Text.Trim(),
                    NgayTao = NgayTao.Value,
                    TrangThai = true, // Assuming default is active, adjust if needed
                    GhiChu = txtGhiChu.Text.Trim()
                };
                // Thêm dịch vụ
                string result = busDichVu.InsertDichVu(dv);
                if (result.Contains("thành công"))
                {
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                DichVu dv = new DichVu
                {
                    DichVuID = txtMaDichVu.Text.Trim(),
                    HoaDonThueID = txtMaHoaDon.Text.Trim(),
                    NgayTao = NgayTao.Value,
                    TrangThai = true, // Assuming default is active, adjust if needed
                    GhiChu = txtGhiChu.Text.Trim()
                };
                // Cập nhật dịch vụ
                string result = busDichVu.UpdateDichVu(dv);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string dichVuID = txtMaDichVu.Text.Trim();
            if (string.IsNullOrEmpty(dichVuID))
            {
                if (dgvTrangThaiPhong.SelectedRows.Count > 0)
                {
                    dichVuID = dgvTrangThaiPhong.SelectedRows[0].Cells["DichVuID"].Value.ToString();
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDichVu();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvTrangThaiPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTrangThaiPhong.Rows[e.RowIndex];
            txtMaDichVu.Text = row.Cells["DichVuID"].Value?.ToString() ?? "";
            txtMaHoaDon.Text = row.Cells["HoaDonThueID"].Value?.ToString() ?? "";
            NgayTao.Value = row.Cells["NgayTao"].Value == null ? DateTime.Now : (DateTime)row.Cells["NgayTao"].Value;
            txtGhiChu.Text = row.Cells["GhiChu"].Value == null ? "" : row.Cells["GhiChu"].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaDichVu.Enabled = false; // Disable editing ID
        }
    }
}

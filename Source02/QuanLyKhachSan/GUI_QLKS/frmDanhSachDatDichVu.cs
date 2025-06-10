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
        BUSDatDichVu busDatDichVu = new BUSDatDichVu();
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
            btnXoa.Enabled = false;
            txtTimKiem.Text = "";
        }

        private void LoadDanhSachDichVu()
        {
            try
            {
                dgvDatDichVu.DataSource = null;
                var dichVuList = busDatDichVu.GetDichVuList();
                dgvDatDichVu.DataSource = dichVuList;

                // Cấu hình tiêu đề và định dạng cột
                if (dgvDatDichVu.Columns.Contains("DichVuID"))
                {
                    dgvDatDichVu.Columns["DichVuID"].HeaderText = "Mã Dịch Vụ";
                    dgvDatDichVu.Columns["DichVuID"].Width = 150;
                }
                if (dgvDatDichVu.Columns.Contains("HoaDonThueID"))
                {
                    dgvDatDichVu.Columns["HoaDonThueID"].HeaderText = "Mã Hóa Đơn Thuê";
                    dgvDatDichVu.Columns["HoaDonThueID"].Width = 150;
                }
                if (dgvDatDichVu.Columns.Contains("NgayTao"))
                {
                    dgvDatDichVu.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                    dgvDatDichVu.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvDatDichVu.Columns.Contains("TrangThaiText"))
                {
                    dgvDatDichVu.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
                }
                if (dgvDatDichVu.Columns.Contains("GhiChu"))
                {
                    dgvDatDichVu.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvDatDichVu.Columns["GhiChu"].Width = 200;
                }

                // Ẩn cột TrangThai gốc vì đã có TrangThaiText
                if (dgvDatDichVu.Columns.Contains("TrangThai"))
                {
                    dgvDatDichVu.Columns["TrangThai"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo mới một đối tượng DichVu
                DichVu dichVu = new DichVu
                {
                    DichVuID = busDatDichVu.InsertDichVu(new DichVu()).Length > 0 ? "" : busDatDichVu.InsertDichVu(new DichVu()), // Lấy mã tự động
                    HoaDonThueID = "", // Có thể yêu cầu người dùng nhập hoặc để trống để xử lý sau
                    NgayTao = DateTime.Now,
                    TrangThai = true,
                    GhiChu = ""
                };

                string result = busDatDichVu.InsertDichVu(dichVu);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDichVu();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDatDichVu.SelectedRows.Count > 0)
            {
                try
                {
                    string dichVuID = dgvDatDichVu.SelectedRows[0].Cells["DichVuID"].Value.ToString();
                    string result = busDatDichVu.DeleteDichVu(dichVuID);
                    if (string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachDichVu();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachDichVu();
            ClearForm();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadDanhSachDichVu();
                }
                else
                {
                    string sql = "SELECT * FROM DichVu WHERE DichVuID LIKE @0 OR HoaDonThueID LIKE @0 OR GhiChu LIKE @0";
                    List<object> param = new List<object> { "%" + keyword + "%" };
                    dgvDatDichVu.DataSource = null;
                    var dichVuList = new DALDatDichVu().SelectBySql(sql, param);
                    dgvDatDichVu.DataSource = dichVuList;

                    // Cấu hình lại tiêu đề và định dạng cột
                    if (dgvDatDichVu.Columns.Contains("DichVuID"))
                    {
                        dgvDatDichVu.Columns["DichVuID"].HeaderText = "Mã Dịch Vụ";
                        dgvDatDichVu.Columns["DichVuID"].Width = 150;
                    }
                    if (dgvDatDichVu.Columns.Contains("HoaDonThueID"))
                    {
                        dgvDatDichVu.Columns["HoaDonThueID"].HeaderText = "Mã Hóa Đơn Thuê";
                        dgvDatDichVu.Columns["HoaDonThueID"].Width = 150;
                    }
                    if (dgvDatDichVu.Columns.Contains("NgayTao"))
                    {
                        dgvDatDichVu.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                        dgvDatDichVu.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvDatDichVu.Columns.Contains("TrangThaiText"))
                    {
                        dgvDatDichVu.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
                    }
                    if (dgvDatDichVu.Columns.Contains("GhiChu"))
                    {
                        dgvDatDichVu.Columns["GhiChu"].HeaderText = "Ghi Chú";
                        dgvDatDichVu.Columns["GhiChu"].Width = 200;
                    }
                    if (dgvDatDichVu.Columns.Contains("TrangThai"))
                    {
                        dgvDatDichVu.Columns["TrangThai"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

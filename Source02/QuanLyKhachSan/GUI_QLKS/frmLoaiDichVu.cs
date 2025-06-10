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
using DTO_QLKS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GUI_QLKS
{
    public partial class frmLoaiDichVu : Form
    {
        BUSLoaiDichVu busLoaiDichVu = new BUSLoaiDichVu();
        public frmLoaiDichVu()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaLoaiDichVu.Clear();
            txtTenDichVu.Clear();
            txtGiaDichVu.Clear();
            CBDonVi.SelectedIndex = -1;
            rdoHoatDong.Checked = true;
        }
        private void LoadData()
        {
           
            try
            {
                dgvLoaiDichVu.DataSource = null;
                var dsLoaiDichVu = busLoaiDichVu.GetDSLoaiDichVu();
                dgvLoaiDichVu.DataSource = dsLoaiDichVu;

                // Kiểm tra và gán giá trị cho cột
                if (dgvLoaiDichVu.Columns.Contains("MaLoaiDichVu"))
                {
                    dgvLoaiDichVu.Columns["MaLoaiDichVu"].HeaderText = "Mã Loại Dịch Vụ";
                    dgvLoaiDichVu.Columns["MaLoaiDichVu"].Width = 150;
                }
                if (dgvLoaiDichVu.Columns.Contains("TenLoaiDichVu"))
                {
                    dgvLoaiDichVu.Columns["TenLoaiDichVu"].HeaderText = "Tên Loại Dịch Vụ";
                    dgvLoaiDichVu.Columns["TenLoaiDichVu"].Width = 200;
                }
                if (dgvLoaiDichVu.Columns.Contains("Gia"))
                {
                    dgvLoaiDichVu.Columns["Gia"].HeaderText = "Giá";
                    dgvLoaiDichVu.Columns["Gia"].DefaultCellStyle.Format = "N0"; // Định dạng số không thập phân
                }
                if (dgvLoaiDichVu.Columns.Contains("DonVi"))
                {
                    dgvLoaiDichVu.Columns["DonVi"].HeaderText = "Đơn Vị";
                }
                if (dgvLoaiDichVu.Columns.Contains("NgayTao"))
                {
                    dgvLoaiDichVu.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                    dgvLoaiDichVu.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dgvLoaiDichVu.Columns.Contains("TinhTrangText"))
                {
                    dgvLoaiDichVu.Columns["TinhTrangText"].HeaderText = "Tình Trạng";
                }

                // Ẩn cột TinhTrang gốc vì đã có TinhTrangText
                if (dgvLoaiDichVu.Columns.Contains("TinhTrang"))
                {
                    dgvLoaiDichVu.Columns["TinhTrang"].Visible = false;
                }

                // Ẩn cột GhiChu nếu tồn tại (không có trong DTO)
                if (dgvLoaiDichVu.Columns.Contains("GhiChu"))
                {
                    dgvLoaiDichVu.Columns["GhiChu"].Visible = false;
                }

                dgvLoaiDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLoaiDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}

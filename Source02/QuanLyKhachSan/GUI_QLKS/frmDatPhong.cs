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
using DAL_QLKS;
using DTO_QLKS;
using DTO_QuanLyKhachSan;

namespace GUI_QLKS
{
    public partial class frmDatPhong : Form
    {
        private BUSDatPhong busDatPhong = new BUSDatPhong();
        private List<DatPhong> bookingList = new List<DatPhong>();
        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab != null)
            {
                if (guna2TabControl1.SelectedTab.Name == "tabQuanLyDatPhong")
                {
                    TabPage tab = guna2TabControl1.SelectedTab;
                    frmDanhSachDatPhong frm = new frmDanhSachDatPhong();
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;

                    tab.Controls.Add(frm);
                    frm.Show();
                    return;
                }
                if (guna2TabControl1.SelectedTab.Name == "tabDatDichVu")
                {
                    TabPage tab = guna2TabControl1.SelectedTab;
                    frmDanhSachDatDichVu frm = new frmDanhSachDatDichVu();
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;

                    tab.Controls.Add(frm);
                    frm.Show();
                    return;
                }
            }
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadRoomList();
            ClearInputFields();
            guna2Button2.Text = "Đặt Phòng"; // Ensure button text is set
            guna2Button1.Text = "Hủy"; // Ensure button text is set
            guna2Button3.Text = "Thêm Dịch Vụ";
        }

        private void LoadComboBoxData()
        {
            guna2ComboBox1.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            guna2ComboBox1.SelectedIndex = 0;

            guna2ComboBox2.Items.AddRange(new object[] { "Phòng Đơn", "Phòng Đôi", "Phòng VIP" });
            guna2ComboBox2.SelectedIndex = 0;
        }

        private void LoadRoomList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PhongID", typeof(string));
            dt.Columns.Add("TenPhong", typeof(string));
            dt.Columns.Add("LoaiPhong", typeof(string));
            dt.Columns.Add("TrangThai", typeof(string));

            // Sample data
            dt.Rows.Add("P001", "Phòng 101", "Phòng Đơn", "Trống");
            dt.Rows.Add("P002", "Phòng 102", "Phòng Đôi", "Trống");
            dt.Rows.Add("P003", "Phòng 201", "Phòng VIP", "Trống");

            dgrDanhSachPhong.DataSource = dt;
        }

        private void ClearInputFields()
        {
            txtHoTen.Text = "";
            guna2TextBox2.Text = ""; // Số Điện Thoại
            guna2TextBox4.Text = ""; // Địa Chỉ
            guna2TextBox1.Text = ""; // Thẻ Căn Cước/CCCD
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2DateTimePicker2.Value = DateTime.Now.AddDays(1);
            dgrPhongDaChon.DataSource = null;
            guna2DataGridView1.DataSource = null;
        }

        private void butDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) ||
                    string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dgrPhongDaChon.DataSource == null || ((DataTable)dgrPhongDaChon.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (guna2DateTimePicker1.Value >= guna2DateTimePicker2.Value)
                {
                    MessageBox.Show("Ngày nhận phải trước ngày trả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng KhachHang từ dữ liệu form
                KhachHang khachHang = new KhachHang
                {
                    KhachHangID = busDatPhong.GenerateKhachHangID(), // Gọi từ BUS
                    HoTen = txtHoTen.Text,
                    DiaChi = guna2TextBox4.Text,
                    GioiTinh = guna2ComboBox1.SelectedItem.ToString(),
                    SoDienThoai = guna2TextBox2.Text,
                    CCCD = guna2TextBox1.Text,
                    NgayTao = DateTime.Now,
                    TrangThai = true,
                    GhiChu = "Khách hàng mới từ đặt phòng"
                };

                // Lưu thông tin khách hàng qua BUS
                string resultKhachHang = busDatPhong.InsertKhachHang(khachHang);
                if (!string.IsNullOrEmpty(resultKhachHang))
                {
                    MessageBox.Show(resultKhachHang, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo và lưu thông tin đặt phòng
                DatPhong datPhong = new DatPhong
                {
                    KhachHangID = khachHang.KhachHangID,
                    PhongID = ((DataTable)dgrPhongDaChon.DataSource).Rows[0]["PhongID"].ToString(),
                    NgayDen = guna2DateTimePicker1.Value,
                    NgayDi = guna2DateTimePicker2.Value,
                    MaNV = "NV001",
                    GhiChu = "Đặt phòng qua giao diện"
                };

                string resultDatPhong = busDatPhong.InsertDatPhong(datPhong);
                if (string.IsNullOrEmpty(resultDatPhong))
                {
                    MessageBox.Show("Đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    LoadRoomList();
                }
                else
                {
                    MessageBox.Show(resultDatPhong, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm dịch vụ chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgrDanhSachPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSachPhong.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgrDanhSachPhong.SelectedRows[0];
                DataTable dt = (dgrPhongDaChon.DataSource as DataTable) ?? new DataTable();
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("PhongID", typeof(string));
                    dt.Columns.Add("TenPhong", typeof(string));
                    dt.Columns.Add("LoaiPhong", typeof(string));
                }
                dt.Rows.Add(selectedRow.Cells["PhongID"].Value, selectedRow.Cells["TenPhong"].Value, selectedRow.Cells["LoaiPhong"].Value);
                dgrPhongDaChon.DataSource = dt;
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            MessageBox.Show("Đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadRoomList();
        }
    }
}

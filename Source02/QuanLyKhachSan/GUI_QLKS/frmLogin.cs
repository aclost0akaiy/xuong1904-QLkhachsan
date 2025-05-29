using BUS_QLKS;
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
    public partial class frmLogin : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;
            NhanVien nv = busNhanVien.DangNhap("nam.nguyen@hotel.com", "abc123");
            //NhanVien nv = BUSNhanVien.DangNhap("hung.pham@gmail.vn", "hashed_hung789");
            //NhanVien nv = BUSNhanVien.DangNhap(username, password);
            if (nv == null)
            {
                MessageBox.Show(this, "Tài khoản hoặc mật khẩu không chính xác");
            }
            else
            {
                if (nv.TinhTrang == false)
                {
                    MessageBox.Show(this, "Tài khoản đang tạm khóa, vui lòng viên hệ QTV!!!");
                    return;
                }

                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
        }

        private void btnTThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

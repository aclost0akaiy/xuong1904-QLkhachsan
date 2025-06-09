using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLKS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        private void openChildForm(Form formChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            pnMain.Controls.Add(formChild);
            pnMain.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();


        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTrangChu());
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDatPhong());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachHang());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            openChildForm(new frmPhong());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDichVu());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

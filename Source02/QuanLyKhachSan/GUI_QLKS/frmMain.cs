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

        private void btn_show_Click(object sender, EventArgs e)
        {
            //guna2PictureBox1.Visible = true;
            btn_show.Visible = false;
            btn_hide.Visible = true;
            guna2Panel1.Visible = false;
            guna2Panel1.Width = 237;
            guna2Transition1.ShowSync(guna2Panel1);

        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            //guna2PictureBox1.Visible = false;
            guna2Panel1.Visible = false;
            btn_hide.Visible = false;
            btn_show.Visible = true;
            guna2Panel1.Width = 47;
            guna2Transition1.ShowSync(guna2Panel1);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

            openChildForm(new frmNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachHang());
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            openChildForm(new frmPhong());
        }

        private void btnQLDatPhong_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLDatPhong());
        }
    }
}

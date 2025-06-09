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
    public partial class frmDatPhong : Form
    {
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
    }
}

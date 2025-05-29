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
    public partial class frmDichVu : frmBase
    {
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

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            lbChucNangText.Text = "Dịch Vụ";
        }
    }
}

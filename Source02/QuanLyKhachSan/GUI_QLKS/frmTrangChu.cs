using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_QLKS
{
    public partial class frmTrangChu : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public frmTrangChu()
        {
            InitializeComponent();


            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            timer.Interval = 55; // tốc độ hoạt ảnh
            timer.Tick += (s, e) =>
            {
                progressBar1.Value += 2;
                if (progressBar1.Value >= 100)
                {
                    progressBar1.Value = 0;
                }
            };
            timer.Start();

            Task.Delay(3400).ContinueWith(t =>
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.Invoke(new Action(() =>
                    {
                        timer.Stop(); // dừng khi chuyển form
                        frmLogin login = new frmLogin();
                        login.Show();

                        this.Hide();
                    }));
                }
            });
        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}

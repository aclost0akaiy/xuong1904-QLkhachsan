namespace GUI_QLKS
{
    partial class frmPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            tabPhong = new TabPage();
            tabLoaiPhong = new TabPage();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            guna2TabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2TabControl1);
            panel2.Size = new Size(1342, 736);
            // 
            // panel1
            // 
            panel1.Size = new Size(1342, 69);
            // 
            // guna2TabControl1
            // 
            guna2TabControl1.Controls.Add(tabPhong);
            guna2TabControl1.Controls.Add(tabLoaiPhong);
            guna2TabControl1.Dock = DockStyle.Fill;
            guna2TabControl1.ItemSize = new Size(180, 40);
            guna2TabControl1.Location = new Point(0, 0);
            guna2TabControl1.Name = "guna2TabControl1";
            guna2TabControl1.SelectedIndex = 0;
            guna2TabControl1.Size = new Size(1342, 736);
            guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonHoverState.ForeColor = Color.White;
            guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White;
            guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            guna2TabControl1.TabButtonSize = new Size(180, 40);
            guna2TabControl1.TabIndex = 0;
            guna2TabControl1.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            guna2TabControl1.SelectedIndexChanged += guna2TabControl1_SelectedIndexChanged;
            // 
            // tabPhong
            // 
            tabPhong.Location = new Point(4, 44);
            tabPhong.Name = "tabPhong";
            tabPhong.Padding = new Padding(3);
            tabPhong.Size = new Size(1334, 688);
            tabPhong.TabIndex = 0;
            tabPhong.Text = "Phòng";
            tabPhong.UseVisualStyleBackColor = true;
            // 
            // tabLoaiPhong
            // 
            tabLoaiPhong.Location = new Point(4, 44);
            tabLoaiPhong.Name = "tabLoaiPhong";
            tabLoaiPhong.Padding = new Padding(3);
            tabLoaiPhong.Size = new Size(1334, 688);
            tabLoaiPhong.TabIndex = 1;
            tabLoaiPhong.Text = "Loại Phòng";
            // 
            // frmPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 805);
            Name = "frmPhong";
            Text = "frmPhong";
            Load += frmPhong_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            guna2TabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private TabPage tabPhong;
        private TabPage tabLoaiPhong;
    }
}
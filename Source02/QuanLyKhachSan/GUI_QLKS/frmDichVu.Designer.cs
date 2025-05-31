namespace GUI_QLKS
{
    partial class frmDichVu
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
            panel1 = new Panel();
            lbChucNangText = new Label();
            guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            tabDichVu = new TabPage();
            tabLoaiDV = new TabPage();
            panel1.SuspendLayout();
            guna2TabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(60, 63, 81);
            panel1.Controls.Add(lbChucNangText);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1360, 69);
            panel1.TabIndex = 1;
            // 
            // lbChucNangText
            // 
            lbChucNangText.AutoSize = true;
            lbChucNangText.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbChucNangText.ForeColor = Color.White;
            lbChucNangText.Location = new Point(634, 21);
            lbChucNangText.Name = "lbChucNangText";
            lbChucNangText.Size = new Size(190, 27);
            lbChucNangText.TabIndex = 0;
            lbChucNangText.Text = "Quản Lý Dịch Vụ";
            // 
            // guna2TabControl1
            // 
            guna2TabControl1.Controls.Add(tabDichVu);
            guna2TabControl1.Controls.Add(tabLoaiDV);
            guna2TabControl1.Dock = DockStyle.Fill;
            guna2TabControl1.ItemSize = new Size(180, 40);
            guna2TabControl1.Location = new Point(0, 69);
            guna2TabControl1.Name = "guna2TabControl1";
            guna2TabControl1.SelectedIndex = 0;
            guna2TabControl1.Size = new Size(1360, 858);
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
            guna2TabControl1.TabIndex = 2;
            guna2TabControl1.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            guna2TabControl1.SelectedIndexChanged += guna2TabControl1_SelectedIndexChanged;
            // 
            // tabDichVu
            // 
            tabDichVu.Location = new Point(4, 44);
            tabDichVu.Name = "tabDichVu";
            tabDichVu.Padding = new Padding(3);
            tabDichVu.Size = new Size(1352, 810);
            tabDichVu.TabIndex = 0;
            tabDichVu.Text = "Dịch Vụ";
            tabDichVu.UseVisualStyleBackColor = true;
            // 
            // tabLoaiDV
            // 
            tabLoaiDV.Location = new Point(4, 44);
            tabLoaiDV.Name = "tabLoaiDV";
            tabLoaiDV.Padding = new Padding(3);
            tabLoaiDV.Size = new Size(1334, 688);
            tabLoaiDV.TabIndex = 1;
            tabLoaiDV.Text = "Loại Dịch Vụ";
            tabLoaiDV.UseVisualStyleBackColor = true;
            // 
            // frmDichVu1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 927);
            Controls.Add(guna2TabControl1);
            Controls.Add(panel1);
            Name = "frmDichVu1";
            Text = "frmDichVu1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            guna2TabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public Panel panel1;
        public Label lbChucNangText;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private TabPage tabDichVu;
        private TabPage tabLoaiDV;
    }
}
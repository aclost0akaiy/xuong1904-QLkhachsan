namespace GUI_QLKS
{
    partial class frmDanhSachDatPhong
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachDatPhong));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            btnXoa = new Guna.UI2.WinForms.Guna2Button();
            panel2 = new Panel();
            dgvDatPhong = new Guna.UI2.WinForms.Guna2DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatPhong).BeginInit();
            SuspendLayout();
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.BorderRadius = 5;
            txtTimKiem.CustomizableEdges = customizableEdges1;
            txtTimKiem.DefaultText = "";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.IconLeftSize = new Size(40, 40);
            txtTimKiem.IconRight = (Image)resources.GetObject("txtTimKiem.IconRight");
            txtTimKiem.Location = new Point(406, 15);
            txtTimKiem.Margin = new Padding(3, 5, 3, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PasswordChar = '\0';
            txtTimKiem.PlaceholderText = "Tìm Kiếm";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTimKiem.Size = new Size(362, 51);
            txtTimKiem.TabIndex = 140;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BorderRadius = 10;
            btnLamMoi.CustomizableEdges = customizableEdges3;
            btnLamMoi.DisabledState.BorderColor = Color.DarkGray;
            btnLamMoi.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLamMoi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLamMoi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLamMoi.Font = new Font("Segoe UI", 9F);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1152, 13);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLamMoi.Size = new Size(160, 51);
            btnLamMoi.TabIndex = 139;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThem
            // 
            btnThem.BorderRadius = 10;
            btnThem.CustomizableEdges = customizableEdges5;
            btnThem.DisabledState.BorderColor = Color.DarkGray;
            btnThem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThem.Font = new Font("Segoe UI", 9F);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(820, 13);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThem.Size = new Size(160, 51);
            btnThem.TabIndex = 136;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.BorderRadius = 10;
            btnXoa.CustomizableEdges = customizableEdges7;
            btnXoa.DisabledState.BorderColor = Color.DarkGray;
            btnXoa.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXoa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXoa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXoa.Font = new Font("Segoe UI", 9F);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(986, 13);
            btnXoa.Name = "btnXoa";
            btnXoa.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnXoa.Size = new Size(160, 51);
            btnXoa.TabIndex = 137;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(btnXoa);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1324, 74);
            panel2.TabIndex = 142;
            // 
            // dgvDatPhong
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvDatPhong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDatPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDatPhong.ColumnHeadersHeight = 50;
            dgvDatPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDatPhong.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDatPhong.Dock = DockStyle.Fill;
            dgvDatPhong.GridColor = Color.FromArgb(231, 229, 255);
            dgvDatPhong.Location = new Point(0, 74);
            dgvDatPhong.Name = "dgvDatPhong";
            dgvDatPhong.RowHeadersVisible = false;
            dgvDatPhong.RowHeadersWidth = 51;
            dgvDatPhong.Size = new Size(1324, 782);
            dgvDatPhong.TabIndex = 143;
            dgvDatPhong.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvDatPhong.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvDatPhong.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvDatPhong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvDatPhong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvDatPhong.ThemeStyle.BackColor = Color.White;
            dgvDatPhong.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvDatPhong.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvDatPhong.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDatPhong.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvDatPhong.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvDatPhong.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDatPhong.ThemeStyle.HeaderStyle.Height = 50;
            dgvDatPhong.ThemeStyle.ReadOnly = false;
            dgvDatPhong.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvDatPhong.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDatPhong.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvDatPhong.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvDatPhong.ThemeStyle.RowsStyle.Height = 29;
            dgvDatPhong.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvDatPhong.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // frmDanhSachDatPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 856);
            Controls.Add(dgvDatPhong);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDanhSachDatPhong";
            Text = "frmDanhSachDatPhong";
            Load += frmDanhSachDatPhong_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatPhong).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDatPhong;
    }
}
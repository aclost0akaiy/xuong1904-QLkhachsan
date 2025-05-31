namespace GUI_QLKS
{
    partial class frmKhachHang
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
            panel1.SuspendLayout();
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
            lbChucNangText.Location = new Point(577, 22);
            lbChucNangText.Name = "lbChucNangText";
            lbChucNangText.Size = new Size(244, 27);
            lbChucNangText.TabIndex = 0;
            lbChucNangText.Text = "Quản Lý Khách Hàng";
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 927);
            Controls.Add(panel1);
            Name = "frmKhachHang";
            Text = "frmKhachHang";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Panel panel1;
        public Label lbChucNangText;
    }
}
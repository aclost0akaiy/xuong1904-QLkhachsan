namespace GUI_QLKS
{
    partial class frmLoaiPhong
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            guna2CustomRadioButton1 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(385, 95);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Loại Phòng";
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(200, 138);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(225, 56);
            guna2Button1.TabIndex = 1;
            guna2Button1.Text = "guna2Button1";
            // 
            // guna2CircleButton1
            // 
            guna2CircleButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton1.Font = new Font("Segoe UI", 9F);
            guna2CircleButton1.ForeColor = Color.White;
            guna2CircleButton1.Location = new Point(211, 254);
            guna2CircleButton1.Name = "guna2CircleButton1";
            guna2CircleButton1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton1.Size = new Size(185, 185);
            guna2CircleButton1.TabIndex = 2;
            guna2CircleButton1.Text = "guna2CircleButton1";
            // 
            // guna2CustomRadioButton1
            // 
            guna2CustomRadioButton1.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2CustomRadioButton1.CheckedState.BorderThickness = 0;
            guna2CustomRadioButton1.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            guna2CustomRadioButton1.CheckedState.InnerColor = Color.White;
            guna2CustomRadioButton1.Location = new Point(534, 282);
            guna2CustomRadioButton1.Name = "guna2CustomRadioButton1";
            guna2CustomRadioButton1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2CustomRadioButton1.Size = new Size(25, 25);
            guna2CustomRadioButton1.TabIndex = 3;
            guna2CustomRadioButton1.Text = "guna2CustomRadioButton1";
            guna2CustomRadioButton1.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            guna2CustomRadioButton1.UncheckedState.BorderThickness = 2;
            guna2CustomRadioButton1.UncheckedState.FillColor = Color.Transparent;
            guna2CustomRadioButton1.UncheckedState.InnerColor = Color.Transparent;
            // 
            // frmLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1316, 641);
            Controls.Add(guna2CustomRadioButton1);
            Controls.Add(guna2CircleButton1);
            Controls.Add(guna2Button1);
            Controls.Add(label1);
            Name = "frmLoaiPhong";
            Text = "frmLoaiPhong";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton guna2CustomRadioButton1;
    }
}
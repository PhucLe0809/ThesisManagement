namespace ThesisManagementProject
{
    partial class UCNotificationLine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNotificationLine));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            gButtonDelete = new Guna.UI2.WinForms.Guna2Button();
            gButtonStar = new Guna.UI2.WinForms.Guna2Button();
            lblFrom = new Label();
            lblTemp = new Label();
            lblNotification = new Label();
            lblTi = new Label();
            lblTime = new Label();
            gTextBoxType = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // gElipse
            // 
            gElipse.TargetControl = this;
            // 
            // gButtonDelete
            // 
            gButtonDelete.BackColor = Color.Transparent;
            gButtonDelete.BorderRadius = 5;
            gButtonDelete.CustomizableEdges = customizableEdges3;
            gButtonDelete.DisabledState.BorderColor = Color.DarkGray;
            gButtonDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonDelete.FillColor = Color.Transparent;
            gButtonDelete.Font = new Font("Segoe UI", 9F);
            gButtonDelete.ForeColor = Color.White;
            gButtonDelete.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonDelete.Image = (Image)resources.GetObject("gButtonDelete.Image");
            gButtonDelete.ImageSize = new Size(25, 25);
            gButtonDelete.Location = new Point(1175, 15);
            gButtonDelete.Name = "gButtonDelete";
            gButtonDelete.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gButtonDelete.Size = new Size(40, 40);
            gButtonDelete.TabIndex = 13;
            gButtonDelete.Click += gButtonDelete_Click;
            // 
            // gButtonStar
            // 
            gButtonStar.BackColor = Color.Transparent;
            gButtonStar.BorderRadius = 5;
            gButtonStar.CustomizableEdges = customizableEdges5;
            gButtonStar.DisabledState.BorderColor = Color.DarkGray;
            gButtonStar.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonStar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonStar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonStar.FillColor = Color.Transparent;
            gButtonStar.Font = new Font("Segoe UI", 9F);
            gButtonStar.ForeColor = Color.White;
            gButtonStar.Image = (Image)resources.GetObject("gButtonStar.Image");
            gButtonStar.ImageSize = new Size(25, 25);
            gButtonStar.Location = new Point(7, 15);
            gButtonStar.Name = "gButtonStar";
            gButtonStar.PressedColor = SystemColors.ButtonFace;
            gButtonStar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gButtonStar.Size = new Size(40, 40);
            gButtonStar.TabIndex = 12;
            gButtonStar.Click += gButtonStar_Click;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.BackColor = Color.Transparent;
            lblFrom.Font = new Font("Century Gothic", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFrom.Location = new Point(234, 39);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(92, 18);
            lblFrom.TabIndex = 41;
            lblFrom.Text = "Anonymous";
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.BackColor = Color.Transparent;
            lblTemp.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTemp.ForeColor = Color.FromArgb(74, 97, 94);
            lblTemp.Location = new Point(178, 38);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(53, 20);
            lblTemp.TabIndex = 40;
            lblTemp.Text = "From :";
            // 
            // lblNotification
            // 
            lblNotification.AutoSize = true;
            lblNotification.BackColor = Color.Transparent;
            lblNotification.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotification.Location = new Point(63, 11);
            lblNotification.Name = "lblNotification";
            lblNotification.Size = new Size(100, 23);
            lblNotification.TabIndex = 39;
            lblNotification.Text = "Notification";
            // 
            // lblTi
            // 
            lblTi.AutoSize = true;
            lblTi.BackColor = Color.Transparent;
            lblTi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTi.ForeColor = Color.FromArgb(74, 97, 94);
            lblTi.Location = new Point(884, 38);
            lblTi.Name = "lblTi";
            lblTi.Size = new Size(50, 20);
            lblTi.TabIndex = 43;
            lblTi.Text = "Time :";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.Black;
            lblTime.Location = new Point(933, 38);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(147, 20);
            lblTime.TabIndex = 42;
            lblTime.Text = "12/04/2024 21:34:55";
            // 
            // gTextBoxType
            // 
            gTextBoxType.BackColor = Color.Transparent;
            gTextBoxType.BorderRadius = 9;
            gTextBoxType.BorderThickness = 0;
            gTextBoxType.CustomizableEdges = customizableEdges1;
            gTextBoxType.DefaultText = "Comment";
            gTextBoxType.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxType.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxType.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxType.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxType.FillColor = Color.Gray;
            gTextBoxType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxType.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gTextBoxType.ForeColor = Color.White;
            gTextBoxType.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxType.Location = new Point(63, 38);
            gTextBoxType.Margin = new Padding(3, 4, 3, 4);
            gTextBoxType.Name = "gTextBoxType";
            gTextBoxType.PasswordChar = '\0';
            gTextBoxType.PlaceholderText = "";
            gTextBoxType.ReadOnly = true;
            gTextBoxType.SelectedText = "";
            gTextBoxType.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gTextBoxType.Size = new Size(100, 21);
            gTextBoxType.TabIndex = 44;
            gTextBoxType.TextAlign = HorizontalAlignment.Center;
            // 
            // UCNotificationLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gTextBoxType);
            Controls.Add(lblTi);
            Controls.Add(lblTime);
            Controls.Add(lblFrom);
            Controls.Add(lblTemp);
            Controls.Add(lblNotification);
            Controls.Add(gButtonDelete);
            Controls.Add(gButtonStar);
            DoubleBuffered = true;
            Name = "UCNotificationLine";
            Size = new Size(1230, 70);
            Click += UCNotificationLine_Click;
            MouseEnter += UCNotificationLine_MouseEnter;
            MouseLeave += UCNotificationLine_MouseLeave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse gElipse;
        private Guna.UI2.WinForms.Guna2Button gButtonDelete;
        private Guna.UI2.WinForms.Guna2Button gButtonStar;
        private Label lblFrom;
        private Label lblTemp;
        private Label lblNotification;
        private Label lblTi;
        private Label lblTime;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxType;
    }
}

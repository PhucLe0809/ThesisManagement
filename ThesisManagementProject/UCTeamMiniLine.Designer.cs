namespace ThesisManagementProject
{
    partial class UCTeamMiniLine
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTeamMiniLine));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gButtonAdd = new Guna.UI2.WinForms.Guna2Button();
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gTextBoxTeamMemebrs = new Guna.UI2.WinForms.Guna2TextBox();
            lblTeamCode = new Label();
            lblUserName = new Label();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gShadowPanelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // gButtonAdd
            // 
            gButtonAdd.BorderRadius = 5;
            gButtonAdd.CustomizableEdges = customizableEdges1;
            gButtonAdd.DisabledState.BorderColor = Color.White;
            gButtonAdd.DisabledState.CustomBorderColor = Color.White;
            gButtonAdd.DisabledState.FillColor = Color.White;
            gButtonAdd.DisabledState.ForeColor = Color.White;
            gButtonAdd.FillColor = Color.Transparent;
            gButtonAdd.Font = new Font("Segoe UI", 9F);
            gButtonAdd.ForeColor = Color.White;
            gButtonAdd.HoverState.FillColor = SystemColors.ButtonFace;
            gButtonAdd.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonAdd.Image = (Image)resources.GetObject("gButtonAdd.Image");
            gButtonAdd.ImageSize = new Size(22, 22);
            gButtonAdd.Location = new Point(463, 10);
            gButtonAdd.Name = "gButtonAdd";
            gButtonAdd.PressedColor = SystemColors.ButtonFace;
            gButtonAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gButtonAdd.Size = new Size(35, 35);
            gButtonAdd.TabIndex = 14;
            // 
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.Controls.Add(gTextBoxTeamMemebrs);
            gShadowPanelBack.Controls.Add(lblTeamCode);
            gShadowPanelBack.Controls.Add(lblUserName);
            gShadowPanelBack.Controls.Add(gCirclePictureBoxAvatar);
            gShadowPanelBack.Controls.Add(gButtonAdd);
            gShadowPanelBack.FillColor = SystemColors.ButtonFace;
            gShadowPanelBack.Location = new Point(0, 0);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 5;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 4;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(520, 60);
            gShadowPanelBack.TabIndex = 29;
            // 
            // gTextBoxTeamMemebrs
            // 
            gTextBoxTeamMemebrs.BackColor = SystemColors.ButtonFace;
            gTextBoxTeamMemebrs.BorderRadius = 10;
            gTextBoxTeamMemebrs.BorderThickness = 0;
            gTextBoxTeamMemebrs.CustomizableEdges = customizableEdges3;
            gTextBoxTeamMemebrs.DefaultText = "5 members";
            gTextBoxTeamMemebrs.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxTeamMemebrs.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxTeamMemebrs.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxTeamMemebrs.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxTeamMemebrs.FillColor = Color.FromArgb(94, 148, 255);
            gTextBoxTeamMemebrs.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxTeamMemebrs.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gTextBoxTeamMemebrs.ForeColor = Color.White;
            gTextBoxTeamMemebrs.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxTeamMemebrs.Location = new Point(287, 15);
            gTextBoxTeamMemebrs.Margin = new Padding(4);
            gTextBoxTeamMemebrs.Name = "gTextBoxTeamMemebrs";
            gTextBoxTeamMemebrs.PasswordChar = '\0';
            gTextBoxTeamMemebrs.PlaceholderForeColor = Color.Gray;
            gTextBoxTeamMemebrs.PlaceholderText = "";
            gTextBoxTeamMemebrs.ReadOnly = true;
            gTextBoxTeamMemebrs.SelectedText = "";
            gTextBoxTeamMemebrs.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gTextBoxTeamMemebrs.Size = new Size(125, 25);
            gTextBoxTeamMemebrs.TabIndex = 57;
            gTextBoxTeamMemebrs.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTeamCode
            // 
            lblTeamCode.AutoSize = true;
            lblTeamCode.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTeamCode.ForeColor = Color.FromArgb(74, 97, 94);
            lblTeamCode.Location = new Point(77, 30);
            lblTeamCode.Name = "lblTeamCode";
            lblTeamCode.Size = new Size(70, 17);
            lblTeamCode.TabIndex = 56;
            lblTeamCode.Text = "team code";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(75, 6);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(98, 23);
            lblUserName.TabIndex = 55;
            lblUserName.Text = "Team name";
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.Image = Properties.Resources.PicItemMember;
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(17, 8);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges5;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(40, 40);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            gCirclePictureBoxAvatar.TabIndex = 54;
            gCirclePictureBoxAvatar.TabStop = false;
            // 
            // UCTeamMiniLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gShadowPanelBack);
            Name = "UCTeamMiniLine";
            Size = new Size(520, 60);
            gShadowPanelBack.ResumeLayout(false);
            gShadowPanelBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button gButtonAdd;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
        private Label lblTeamCode;
        private Label lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxTeamMemebrs;
    }
}

namespace ThesisManagementProject
{
    partial class UCThesisDetailsTeam
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCThesisDetailsTeam));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gTextBoxTeamMemebrs = new Guna.UI2.WinForms.Guna2TextBox();
            lblTeamName = new Label();
            gButtonGoto = new Guna.UI2.WinForms.Guna2Button();
            gTextBoxTeamCode = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.Image = Properties.Resources.PicAvatarDemoUser;
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(24, 11);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(75, 75);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            gCirclePictureBoxAvatar.TabIndex = 55;
            gCirclePictureBoxAvatar.TabStop = false;
            gCirclePictureBoxAvatar.Click += gCirclePictureBoxAvatar_Click;
            // 
            // gTextBoxTeamMemebrs
            // 
            gTextBoxTeamMemebrs.BackColor = Color.White;
            gTextBoxTeamMemebrs.BorderRadius = 10;
            gTextBoxTeamMemebrs.BorderThickness = 0;
            gTextBoxTeamMemebrs.CustomizableEdges = customizableEdges2;
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
            gTextBoxTeamMemebrs.Location = new Point(113, 52);
            gTextBoxTeamMemebrs.Margin = new Padding(4);
            gTextBoxTeamMemebrs.Name = "gTextBoxTeamMemebrs";
            gTextBoxTeamMemebrs.PasswordChar = '\0';
            gTextBoxTeamMemebrs.PlaceholderForeColor = Color.Gray;
            gTextBoxTeamMemebrs.PlaceholderText = "";
            gTextBoxTeamMemebrs.ReadOnly = true;
            gTextBoxTeamMemebrs.SelectedText = "";
            gTextBoxTeamMemebrs.ShadowDecoration.CustomizableEdges = customizableEdges3;
            gTextBoxTeamMemebrs.Size = new Size(115, 25);
            gTextBoxTeamMemebrs.TabIndex = 60;
            gTextBoxTeamMemebrs.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTeamName.Location = new Point(108, 22);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(120, 26);
            lblTeamName.TabIndex = 58;
            lblTeamName.Text = "Team name";
            // 
            // gButtonGoto
            // 
            gButtonGoto.BorderRadius = 5;
            gButtonGoto.CustomizableEdges = customizableEdges4;
            gButtonGoto.DisabledState.BorderColor = Color.White;
            gButtonGoto.DisabledState.CustomBorderColor = Color.White;
            gButtonGoto.DisabledState.FillColor = Color.White;
            gButtonGoto.DisabledState.ForeColor = Color.White;
            gButtonGoto.FillColor = Color.Transparent;
            gButtonGoto.Font = new Font("Segoe UI", 9F);
            gButtonGoto.ForeColor = Color.White;
            gButtonGoto.HoverState.FillColor = Color.White;
            gButtonGoto.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonGoto.Image = (Image)resources.GetObject("gButtonGoto.Image");
            gButtonGoto.ImageOffset = new Point(1, 0);
            gButtonGoto.ImageSize = new Size(32, 32);
            gButtonGoto.Location = new Point(425, 31);
            gButtonGoto.Name = "gButtonGoto";
            gButtonGoto.PressedColor = Color.White;
            gButtonGoto.ShadowDecoration.CustomizableEdges = customizableEdges5;
            gButtonGoto.Size = new Size(35, 35);
            gButtonGoto.TabIndex = 61;
            // 
            // gTextBoxTeamCode
            // 
            gTextBoxTeamCode.BackColor = Color.Transparent;
            gTextBoxTeamCode.BorderColor = Color.Silver;
            gTextBoxTeamCode.BorderRadius = 5;
            gTextBoxTeamCode.CustomizableEdges = customizableEdges6;
            gTextBoxTeamCode.DefaultText = "245500001";
            gTextBoxTeamCode.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxTeamCode.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxTeamCode.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxTeamCode.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxTeamCode.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxTeamCode.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gTextBoxTeamCode.ForeColor = Color.FromArgb(74, 97, 94);
            gTextBoxTeamCode.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxTeamCode.Location = new Point(299, 31);
            gTextBoxTeamCode.Margin = new Padding(3, 4, 3, 4);
            gTextBoxTeamCode.Name = "gTextBoxTeamCode";
            gTextBoxTeamCode.PasswordChar = '\0';
            gTextBoxTeamCode.PlaceholderForeColor = Color.Gray;
            gTextBoxTeamCode.PlaceholderText = "";
            gTextBoxTeamCode.ReadOnly = true;
            gTextBoxTeamCode.SelectedText = "";
            gTextBoxTeamCode.ShadowDecoration.CustomizableEdges = customizableEdges7;
            gTextBoxTeamCode.Size = new Size(120, 35);
            gTextBoxTeamCode.TabIndex = 63;
            gTextBoxTeamCode.TextAlign = HorizontalAlignment.Center;
            // 
            // UCThesisDetailsTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gTextBoxTeamCode);
            Controls.Add(gButtonGoto);
            Controls.Add(gTextBoxTeamMemebrs);
            Controls.Add(lblTeamName);
            Controls.Add(gCirclePictureBoxAvatar);
            Name = "UCThesisDetailsTeam";
            Size = new Size(480, 100);
            Click += UCThesisDetailsTeam_Click;
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxTeamMemebrs;
        private Label lblTeamName;
        private Guna.UI2.WinForms.Guna2Button gButtonGoto;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxTeamCode;
    }
}

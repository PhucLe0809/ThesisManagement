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
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gTextBoxTeamMemebrs = new Guna.UI2.WinForms.Guna2TextBox();
            lblTeamCode = new Label();
            lblTeamName = new Label();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.Image = Properties.Resources.PicAvatarDemoUser;
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(25, 15);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(70, 70);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            gCirclePictureBoxAvatar.TabIndex = 55;
            gCirclePictureBoxAvatar.TabStop = false;
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
            gTextBoxTeamMemebrs.Location = new Point(320, 39);
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
            // lblTeamCode
            // 
            lblTeamCode.AutoSize = true;
            lblTeamCode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTeamCode.ForeColor = Color.FromArgb(74, 97, 94);
            lblTeamCode.Location = new Point(111, 51);
            lblTeamCode.Name = "lblTeamCode";
            lblTeamCode.Size = new Size(80, 20);
            lblTeamCode.TabIndex = 59;
            lblTeamCode.Text = "team code";
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTeamName.Location = new Point(111, 22);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(120, 26);
            lblTeamName.TabIndex = 58;
            lblTeamName.Text = "Team name";
            // 
            // UCThesisShowTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gTextBoxTeamMemebrs);
            Controls.Add(lblTeamCode);
            Controls.Add(lblTeamName);
            Controls.Add(gCirclePictureBoxAvatar);
            Name = "UCThesisShowTeam";
            Size = new Size(480, 100);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxTeamMemebrs;
        private Label lblTeamCode;
        private Label lblTeamName;
    }
}

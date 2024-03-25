namespace ThesisManagementProject
{
    partial class UCDisplayWelcome
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gButtonLogin = new Guna.UI2.WinForms.Guna2Button();
            gProgressBarToLine = new Guna.UI2.WinForms.Guna2ProgressBar();
            lblThesisManagement = new Label();
            lblWelcome = new Label();
            gPictureBoxLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            gGradientButtonLecture = new Guna.UI2.WinForms.Guna2GradientButton();
            gGradientButtonRegister = new Guna.UI2.WinForms.Guna2GradientButton();
            gGradientButtonStudent = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)gPictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // gButtonLogin
            // 
            gButtonLogin.BorderRadius = 10;
            gButtonLogin.CustomizableEdges = customizableEdges1;
            gButtonLogin.DisabledState.BorderColor = Color.DarkGray;
            gButtonLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonLogin.FillColor = Color.FromArgb(2, 0, 214);
            gButtonLogin.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gButtonLogin.ForeColor = Color.White;
            gButtonLogin.Location = new Point(1202, 403);
            gButtonLogin.Name = "gButtonLogin";
            gButtonLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gButtonLogin.Size = new Size(133, 45);
            gButtonLogin.TabIndex = 12;
            gButtonLogin.Text = "Login";
            gButtonLogin.Click += gButtonLogin_Click;
            // 
            // gProgressBarToLine
            // 
            gProgressBarToLine.BorderRadius = 5;
            gProgressBarToLine.CustomizableEdges = customizableEdges3;
            gProgressBarToLine.Location = new Point(700, 364);
            gProgressBarToLine.Name = "gProgressBarToLine";
            gProgressBarToLine.ProgressColor = Color.FromArgb(94, 148, 255);
            gProgressBarToLine.ProgressColor2 = Color.FromArgb(255, 77, 165);
            gProgressBarToLine.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gProgressBarToLine.Size = new Size(635, 10);
            gProgressBarToLine.TabIndex = 16;
            gProgressBarToLine.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            gProgressBarToLine.Value = 100;
            // 
            // lblThesisManagement
            // 
            lblThesisManagement.AutoSize = true;
            lblThesisManagement.BackColor = Color.White;
            lblThesisManagement.Font = new Font("Trebuchet MS", 40.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThesisManagement.Location = new Point(685, 278);
            lblThesisManagement.Name = "lblThesisManagement";
            lblThesisManagement.Size = new Size(652, 84);
            lblThesisManagement.TabIndex = 15;
            lblThesisManagement.Text = "Thesis Management";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Trebuchet MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(697, 241);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(176, 38);
            lblWelcome.TabIndex = 14;
            lblWelcome.Text = "Welcome to";
            // 
            // gPictureBoxLogo
            // 
            gPictureBoxLogo.CustomizableEdges = customizableEdges5;
            gPictureBoxLogo.Image = Properties.Resources.LogoThesisManagement;
            gPictureBoxLogo.ImageRotate = 0F;
            gPictureBoxLogo.Location = new Point(230, 104);
            gPictureBoxLogo.Name = "gPictureBoxLogo";
            gPictureBoxLogo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gPictureBoxLogo.Size = new Size(410, 410);
            gPictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            gPictureBoxLogo.TabIndex = 13;
            gPictureBoxLogo.TabStop = false;
            // 
            // gGradientButtonLecture
            // 
            gGradientButtonLecture.BorderColor = SystemColors.ButtonFace;
            gGradientButtonLecture.BorderRadius = 10;
            gGradientButtonLecture.BorderThickness = 1;
            gGradientButtonLecture.CustomizableEdges = customizableEdges7;
            gGradientButtonLecture.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonLecture.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonLecture.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonLecture.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonLecture.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonLecture.FillColor = Color.White;
            gGradientButtonLecture.FillColor2 = Color.White;
            gGradientButtonLecture.Font = new Font("Trebuchet MS", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonLecture.ForeColor = Color.FromArgb(74, 97, 94);
            gGradientButtonLecture.HoverState.BorderColor = Color.White;
            gGradientButtonLecture.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButtonLecture.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButtonLecture.HoverState.ForeColor = Color.White;
            gGradientButtonLecture.Location = new Point(700, 403);
            gGradientButtonLecture.Name = "gGradientButtonLecture";
            gGradientButtonLecture.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gGradientButtonLecture.Size = new Size(133, 45);
            gGradientButtonLecture.TabIndex = 17;
            gGradientButtonLecture.Text = "Lecture";
            gGradientButtonLecture.Click += gGradientButtonLecture_Click;
            // 
            // gGradientButtonRegister
            // 
            gGradientButtonRegister.BorderColor = SystemColors.ButtonFace;
            gGradientButtonRegister.BorderRadius = 10;
            gGradientButtonRegister.BorderThickness = 1;
            gGradientButtonRegister.CustomizableEdges = customizableEdges9;
            gGradientButtonRegister.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonRegister.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonRegister.FillColor = Color.White;
            gGradientButtonRegister.FillColor2 = Color.White;
            gGradientButtonRegister.Font = new Font("Trebuchet MS", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonRegister.ForeColor = Color.FromArgb(74, 97, 94);
            gGradientButtonRegister.HoverState.BorderColor = Color.White;
            gGradientButtonRegister.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButtonRegister.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButtonRegister.HoverState.ForeColor = Color.White;
            gGradientButtonRegister.Location = new Point(1063, 403);
            gGradientButtonRegister.Name = "gGradientButtonRegister";
            gGradientButtonRegister.ShadowDecoration.CustomizableEdges = customizableEdges10;
            gGradientButtonRegister.Size = new Size(133, 45);
            gGradientButtonRegister.TabIndex = 18;
            gGradientButtonRegister.Text = "Register";
            gGradientButtonRegister.Click += gGradientButtonRegister_Click;
            // 
            // gGradientButtonStudent
            // 
            gGradientButtonStudent.BorderColor = SystemColors.ButtonFace;
            gGradientButtonStudent.BorderRadius = 10;
            gGradientButtonStudent.BorderThickness = 1;
            gGradientButtonStudent.CustomizableEdges = customizableEdges11;
            gGradientButtonStudent.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonStudent.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonStudent.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonStudent.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonStudent.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonStudent.FillColor = Color.White;
            gGradientButtonStudent.FillColor2 = Color.White;
            gGradientButtonStudent.Font = new Font("Trebuchet MS", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonStudent.ForeColor = Color.FromArgb(74, 97, 94);
            gGradientButtonStudent.HoverState.BorderColor = Color.White;
            gGradientButtonStudent.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButtonStudent.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButtonStudent.HoverState.ForeColor = Color.White;
            gGradientButtonStudent.Location = new Point(839, 403);
            gGradientButtonStudent.Name = "gGradientButtonStudent";
            gGradientButtonStudent.ShadowDecoration.CustomizableEdges = customizableEdges12;
            gGradientButtonStudent.Size = new Size(133, 45);
            gGradientButtonStudent.TabIndex = 19;
            gGradientButtonStudent.Text = "Student";
            // 
            // UCDisplayWelcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gGradientButtonStudent);
            Controls.Add(gGradientButtonRegister);
            Controls.Add(gGradientButtonLecture);
            Controls.Add(gProgressBarToLine);
            Controls.Add(lblThesisManagement);
            Controls.Add(lblWelcome);
            Controls.Add(gPictureBoxLogo);
            Controls.Add(gButtonLogin);
            Name = "UCDisplayWelcome";
            Size = new Size(1575, 853);
            ((System.ComponentModel.ISupportInitialize)gPictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button gButtonLogin;
        private Guna.UI2.WinForms.Guna2ProgressBar gProgressBarToLine;
        private Label lblThesisManagement;
        private Label lblWelcome;
        private Guna.UI2.WinForms.Guna2PictureBox gPictureBoxLogo;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonLecture;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonRegister;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonStudent;
    }
}

namespace ThesisManagementProject
{
    partial class UCPeopleMiniLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPeopleMiniLine));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblGender = new Label();
            lblUserName = new Label();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gButtonAdd = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            gShadowPanelBack.SuspendLayout();
            SuspendLayout();
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = Color.White;
            lblGender.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.FromArgb(74, 97, 94);
            lblGender.Location = new Point(85, 31);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(50, 17);
            lblGender.TabIndex = 27;
            lblGender.Text = "gender";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = Color.White;
            lblUserName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(83, 7);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(92, 23);
            lblUserName.TabIndex = 26;
            lblUserName.Text = "User name";
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.BackColor = Color.White;
            gCirclePictureBoxAvatar.Image = (Image)resources.GetObject("gCirclePictureBoxAvatar.Image");
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(21, 5);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(45, 45);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            gCirclePictureBoxAvatar.TabIndex = 25;
            gCirclePictureBoxAvatar.TabStop = false;
            gCirclePictureBoxAvatar.Click += gCirclePictureBoxAvatar_Click;
            // 
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.Controls.Add(gButtonAdd);
            gShadowPanelBack.FillColor = Color.White;
            gShadowPanelBack.Location = new Point(0, 0);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 5;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 4;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(320, 60);
            gShadowPanelBack.TabIndex = 28;
            gShadowPanelBack.Click += gShadowPanelBack_Click;
            // 
            // gButtonAdd
            // 
            gButtonAdd.BorderRadius = 5;
            gButtonAdd.CustomizableEdges = customizableEdges2;
            gButtonAdd.DisabledState.BorderColor = Color.White;
            gButtonAdd.DisabledState.CustomBorderColor = Color.White;
            gButtonAdd.DisabledState.FillColor = Color.White;
            gButtonAdd.DisabledState.ForeColor = Color.White;
            gButtonAdd.FillColor = Color.Transparent;
            gButtonAdd.Font = new Font("Segoe UI", 9F);
            gButtonAdd.ForeColor = Color.White;
            gButtonAdd.HoverState.FillColor = Color.White;
            gButtonAdd.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonAdd.Image = (Image)resources.GetObject("gButtonAdd.Image");
            gButtonAdd.ImageSize = new Size(22, 22);
            gButtonAdd.Location = new Point(264, 11);
            gButtonAdd.Name = "gButtonAdd";
            gButtonAdd.ShadowDecoration.CustomizableEdges = customizableEdges3;
            gButtonAdd.Size = new Size(35, 35);
            gButtonAdd.TabIndex = 14;
            gButtonAdd.Click += gButtonAdd_Click;
            // 
            // UCStudentMiniLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblGender);
            Controls.Add(lblUserName);
            Controls.Add(gCirclePictureBoxAvatar);
            Controls.Add(gShadowPanelBack);
            Name = "UCStudentMiniLine";
            Size = new Size(320, 60);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            gShadowPanelBack.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGender;
        private Label lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
        private Guna.UI2.WinForms.Guna2Button gButtonAdd;
    }
}

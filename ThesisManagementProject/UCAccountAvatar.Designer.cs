namespace ThesisManagementProject
{
    partial class UCAccountAvatar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAccountAvatar));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gShadowPanelShowAvatar = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gGradientButtonEdit = new Guna.UI2.WinForms.Guna2GradientButton();
            lblViewHandle = new Label();
            lblViewRole = new Label();
            gShadowPanelShowAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // gShadowPanelShowAvatar
            // 
            gShadowPanelShowAvatar.BackColor = Color.Transparent;
            gShadowPanelShowAvatar.Controls.Add(gCirclePictureBoxAvatar);
            gShadowPanelShowAvatar.Controls.Add(gGradientButtonEdit);
            gShadowPanelShowAvatar.Controls.Add(lblViewHandle);
            gShadowPanelShowAvatar.Controls.Add(lblViewRole);
            gShadowPanelShowAvatar.FillColor = Color.White;
            gShadowPanelShowAvatar.Location = new Point(0, 0);
            gShadowPanelShowAvatar.Name = "gShadowPanelShowAvatar";
            gShadowPanelShowAvatar.Radius = 20;
            gShadowPanelShowAvatar.ShadowColor = Color.Black;
            gShadowPanelShowAvatar.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelShowAvatar.Size = new Size(338, 329);
            gShadowPanelShowAvatar.TabIndex = 14;
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureAvatarAccount;
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(64, 25);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(210, 210);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            gCirclePictureBoxAvatar.TabIndex = 0;
            gCirclePictureBoxAvatar.TabStop = false;
            // 
            // gGradientButtonEdit
            // 
            gGradientButtonEdit.BorderRadius = 3;
            gGradientButtonEdit.CustomizableEdges = customizableEdges2;
            gGradientButtonEdit.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonEdit.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonEdit.FillColor = Color.Transparent;
            gGradientButtonEdit.FillColor2 = Color.Transparent;
            gGradientButtonEdit.Font = new Font("Segoe UI", 9F);
            gGradientButtonEdit.ForeColor = Color.White;
            gGradientButtonEdit.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButtonEdit.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButtonEdit.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gGradientButtonEdit.Image = (Image)resources.GetObject("gGradientButtonEdit.Image");
            gGradientButtonEdit.ImageSize = new Size(25, 25);
            gGradientButtonEdit.Location = new Point(239, 266);
            gGradientButtonEdit.Name = "gGradientButtonEdit";
            gGradientButtonEdit.ShadowDecoration.CustomizableEdges = customizableEdges3;
            gGradientButtonEdit.Size = new Size(35, 35);
            gGradientButtonEdit.TabIndex = 9;
            // 
            // lblViewHandle
            // 
            lblViewHandle.AutoSize = true;
            lblViewHandle.Font = new Font("Trebuchet MS", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblViewHandle.Location = new Point(44, 244);
            lblViewHandle.Name = "lblViewHandle";
            lblViewHandle.Size = new Size(135, 36);
            lblViewHandle.TabIndex = 7;
            lblViewHandle.Text = "DavidLee";
            // 
            // lblViewRole
            // 
            lblViewRole.AutoSize = true;
            lblViewRole.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblViewRole.ForeColor = Color.RoyalBlue;
            lblViewRole.Location = new Point(47, 281);
            lblViewRole.Name = "lblViewRole";
            lblViewRole.Size = new Size(72, 20);
            lblViewRole.TabIndex = 8;
            lblViewRole.Text = "Lecture";
            // 
            // UCAvatarAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(gShadowPanelShowAvatar);
            Name = "UCAvatarAccount";
            Size = new Size(338, 329);
            gShadowPanelShowAvatar.ResumeLayout(false);
            gShadowPanelShowAvatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelShowAvatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonEdit;
        private Label lblViewHandle;
        private Label lblViewRole;
    }
}

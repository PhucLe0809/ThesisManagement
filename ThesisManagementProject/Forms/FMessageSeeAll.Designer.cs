namespace ThesisManagementProject
{
    partial class FMessageSeeAll
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMessageSeeAll));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gShadowPanelGeneral = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gTextBoxMessage = new Guna.UI2.WinForms.Guna2TextBox();
            gShadowPanelGenerate = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblCopyMessage = new Label();
            gButtonCopy = new Guna.UI2.WinForms.Guna2Button();
            lblTimeAgo = new Label();
            lblHandle = new Label();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gShadowPanelGeneral.SuspendLayout();
            gShadowPanelGenerate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // gShadowPanelGeneral
            // 
            gShadowPanelGeneral.BackColor = Color.Transparent;
            gShadowPanelGeneral.Controls.Add(gTextBoxMessage);
            gShadowPanelGeneral.FillColor = Color.White;
            gShadowPanelGeneral.Location = new Point(29, 133);
            gShadowPanelGeneral.Name = "gShadowPanelGeneral";
            gShadowPanelGeneral.Radius = 7;
            gShadowPanelGeneral.ShadowColor = Color.Black;
            gShadowPanelGeneral.ShadowDepth = 120;
            gShadowPanelGeneral.ShadowShift = 7;
            gShadowPanelGeneral.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelGeneral.Size = new Size(773, 295);
            gShadowPanelGeneral.TabIndex = 4;
            // 
            // gTextBoxMessage
            // 
            gTextBoxMessage.BackColor = Color.Transparent;
            gTextBoxMessage.BorderRadius = 10;
            gTextBoxMessage.CustomizableEdges = customizableEdges6;
            gTextBoxMessage.DefaultText = "";
            gTextBoxMessage.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxMessage.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxMessage.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxMessage.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxMessage.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gTextBoxMessage.ForeColor = Color.Gray;
            gTextBoxMessage.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxMessage.Location = new Point(29, 26);
            gTextBoxMessage.Margin = new Padding(3, 4, 3, 4);
            gTextBoxMessage.Multiline = true;
            gTextBoxMessage.Name = "gTextBoxMessage";
            gTextBoxMessage.PasswordChar = '\0';
            gTextBoxMessage.PlaceholderText = "message";
            gTextBoxMessage.ReadOnly = true;
            gTextBoxMessage.SelectedText = "";
            gTextBoxMessage.ShadowDecoration.CustomizableEdges = customizableEdges7;
            gTextBoxMessage.Size = new Size(708, 241);
            gTextBoxMessage.TabIndex = 21;
            gTextBoxMessage.TextOffset = new Point(5, 0);
            // 
            // gShadowPanelGenerate
            // 
            gShadowPanelGenerate.BackColor = Color.Transparent;
            gShadowPanelGenerate.Controls.Add(lblCopyMessage);
            gShadowPanelGenerate.Controls.Add(gButtonCopy);
            gShadowPanelGenerate.Controls.Add(lblTimeAgo);
            gShadowPanelGenerate.Controls.Add(lblHandle);
            gShadowPanelGenerate.Controls.Add(gCirclePictureBoxAvatar);
            gShadowPanelGenerate.FillColor = Color.White;
            gShadowPanelGenerate.Location = new Point(29, 22);
            gShadowPanelGenerate.Name = "gShadowPanelGenerate";
            gShadowPanelGenerate.Radius = 7;
            gShadowPanelGenerate.ShadowColor = Color.Black;
            gShadowPanelGenerate.ShadowShift = 6;
            gShadowPanelGenerate.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelGenerate.Size = new Size(773, 98);
            gShadowPanelGenerate.TabIndex = 5;
            // 
            // lblCopyMessage
            // 
            lblCopyMessage.AutoSize = true;
            lblCopyMessage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCopyMessage.ForeColor = Color.FromArgb(74, 97, 94);
            lblCopyMessage.Location = new Point(598, 39);
            lblCopyMessage.Name = "lblCopyMessage";
            lblCopyMessage.Size = new Size(104, 20);
            lblCopyMessage.TabIndex = 33;
            lblCopyMessage.Text = "copy message";
            // 
            // gButtonCopy
            // 
            gButtonCopy.BorderRadius = 2;
            gButtonCopy.CustomizableEdges = customizableEdges8;
            gButtonCopy.DisabledState.BorderColor = Color.DarkGray;
            gButtonCopy.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonCopy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonCopy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonCopy.FillColor = Color.Transparent;
            gButtonCopy.Font = new Font("Segoe UI", 9F);
            gButtonCopy.ForeColor = Color.White;
            gButtonCopy.HoverState.FillColor = Color.White;
            gButtonCopy.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonCopy.Image = (Image)resources.GetObject("gButtonCopy.Image");
            gButtonCopy.ImageOffset = new Point(1, 0);
            gButtonCopy.ImageSize = new Size(22, 22);
            gButtonCopy.Location = new Point(707, 35);
            gButtonCopy.Name = "gButtonCopy";
            gButtonCopy.ShadowDecoration.CustomizableEdges = customizableEdges9;
            gButtonCopy.Size = new Size(30, 30);
            gButtonCopy.TabIndex = 32;
            // 
            // lblTimeAgo
            // 
            lblTimeAgo.AutoSize = true;
            lblTimeAgo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeAgo.ForeColor = Color.DimGray;
            lblTimeAgo.Location = new Point(112, 45);
            lblTimeAgo.Name = "lblTimeAgo";
            lblTimeAgo.Size = new Size(73, 20);
            lblTimeAgo.TabIndex = 21;
            lblTimeAgo.Text = "date time";
            // 
            // lblHandle
            // 
            lblHandle.AutoSize = true;
            lblHandle.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHandle.Location = new Point(109, 18);
            lblHandle.Name = "lblHandle";
            lblHandle.Size = new Size(102, 25);
            lblHandle.TabIndex = 20;
            lblHandle.Text = "User name";
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.Image = (Image)resources.GetObject("gCirclePictureBoxAvatar.Image");
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(29, 12);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(65, 65);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            gCirclePictureBoxAvatar.TabIndex = 19;
            gCirclePictureBoxAvatar.TabStop = false;
            // 
            // FMessageSeeAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(832, 453);
            Controls.Add(gShadowPanelGenerate);
            Controls.Add(gShadowPanelGeneral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FMessageSeeAll";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Message See all";
            gShadowPanelGeneral.ResumeLayout(false);
            gShadowPanelGenerate.ResumeLayout(false);
            gShadowPanelGenerate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelGeneral;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelGenerate;
        private Label lblTimeAgo;
        private Label lblHandle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxMessage;
        private Guna.UI2.WinForms.Guna2Button gButtonCopy;
        private Label lblCopyMessage;
    }
}
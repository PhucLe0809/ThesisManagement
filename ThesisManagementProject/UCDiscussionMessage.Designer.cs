namespace ThesisManagementProject
{
    partial class UCDiscussionMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDiscussionMessage));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gPanel = new Guna.UI2.WinForms.Guna2Panel();
            gTextBoxMessage = new Guna.UI2.WinForms.Guna2TextBox();
            gGradientButtonSeeAll = new Guna.UI2.WinForms.Guna2GradientButton();
            lblTimeAgo = new Label();
            lblHandle = new Label();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            gPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.Image = (Image)resources.GetObject("gCirclePictureBoxAvatar.Image");
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(15, 13);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(60, 60);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            gCirclePictureBoxAvatar.TabIndex = 0;
            gCirclePictureBoxAvatar.TabStop = false;
            // 
            // gPanel
            // 
            gPanel.BorderColor = Color.FromArgb(74, 97, 94);
            gPanel.BorderRadius = 10;
            gPanel.BorderThickness = 1;
            gPanel.Controls.Add(gTextBoxMessage);
            gPanel.Controls.Add(gGradientButtonSeeAll);
            gPanel.Controls.Add(lblTimeAgo);
            gPanel.Controls.Add(lblHandle);
            gPanel.Controls.Add(gCirclePictureBoxAvatar);
            gPanel.CustomizableEdges = customizableEdges6;
            gPanel.FillColor = Color.White;
            gPanel.Location = new Point(0, 0);
            gPanel.Name = "gPanel";
            gPanel.ShadowDecoration.CustomizableEdges = customizableEdges7;
            gPanel.Size = new Size(635, 90);
            gPanel.TabIndex = 1;
            // 
            // gTextBoxMessage
            // 
            gTextBoxMessage.BackColor = Color.Transparent;
            gTextBoxMessage.BorderRadius = 10;
            gTextBoxMessage.BorderThickness = 0;
            gTextBoxMessage.CustomizableEdges = customizableEdges2;
            gTextBoxMessage.DefaultText = "";
            gTextBoxMessage.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxMessage.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxMessage.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxMessage.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxMessage.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxMessage.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gTextBoxMessage.ForeColor = Color.Gray;
            gTextBoxMessage.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxMessage.Location = new Point(84, 41);
            gTextBoxMessage.Margin = new Padding(3, 4, 3, 4);
            gTextBoxMessage.Multiline = true;
            gTextBoxMessage.Name = "gTextBoxMessage";
            gTextBoxMessage.PasswordChar = '\0';
            gTextBoxMessage.PlaceholderForeColor = Color.Gray;
            gTextBoxMessage.PlaceholderText = "message";
            gTextBoxMessage.ReadOnly = true;
            gTextBoxMessage.SelectedText = "";
            gTextBoxMessage.ShadowDecoration.CustomizableEdges = customizableEdges3;
            gTextBoxMessage.Size = new Size(460, 35);
            gTextBoxMessage.TabIndex = 20;
            gTextBoxMessage.TextOffset = new Point(-5, -10);
            // 
            // gGradientButtonSeeAll
            // 
            gGradientButtonSeeAll.BackColor = Color.Transparent;
            gGradientButtonSeeAll.BorderRadius = 5;
            gGradientButtonSeeAll.CustomizableEdges = customizableEdges4;
            gGradientButtonSeeAll.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonSeeAll.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonSeeAll.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonSeeAll.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonSeeAll.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonSeeAll.FillColor = Color.White;
            gGradientButtonSeeAll.FillColor2 = Color.White;
            gGradientButtonSeeAll.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonSeeAll.ForeColor = Color.Black;
            gGradientButtonSeeAll.HoverState.FillColor = SystemColors.ControlLight;
            gGradientButtonSeeAll.HoverState.FillColor2 = SystemColors.ControlLight;
            gGradientButtonSeeAll.HoverState.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonSeeAll.HoverState.ForeColor = Color.Black;
            gGradientButtonSeeAll.Location = new Point(554, 39);
            gGradientButtonSeeAll.Name = "gGradientButtonSeeAll";
            gGradientButtonSeeAll.ShadowDecoration.CustomizableEdges = customizableEdges5;
            gGradientButtonSeeAll.Size = new Size(67, 25);
            gGradientButtonSeeAll.TabIndex = 19;
            gGradientButtonSeeAll.Text = "See all";
            gGradientButtonSeeAll.Click += gGradientButtonSeeAll_Click;
            // 
            // lblTimeAgo
            // 
            lblTimeAgo.AutoSize = true;
            lblTimeAgo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeAgo.ForeColor = Color.DimGray;
            lblTimeAgo.Location = new Point(561, 12);
            lblTimeAgo.Name = "lblTimeAgo";
            lblTimeAgo.Size = new Size(55, 20);
            lblTimeAgo.TabIndex = 18;
            lblTimeAgo.Text = "1h ago";
            // 
            // lblHandle
            // 
            lblHandle.AutoSize = true;
            lblHandle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHandle.Location = new Point(86, 17);
            lblHandle.Name = "lblHandle";
            lblHandle.Size = new Size(92, 23);
            lblHandle.TabIndex = 15;
            lblHandle.Text = "User name";
            // 
            // UCDiscussionMessage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(gPanel);
            Name = "UCDiscussionMessage";
            Size = new Size(635, 90);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            gPanel.ResumeLayout(false);
            gPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
        private Guna.UI2.WinForms.Guna2Panel gPanel;
        private Label lblHandle;
        private Label lblTimeAgo;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonSeeAll;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxMessage;
    }
}

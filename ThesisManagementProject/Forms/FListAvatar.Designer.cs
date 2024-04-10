namespace ThesisManagementProject.Forms
{
    partial class FListAvatar
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FListAvatar));
            flpAvatarList = new FlowLayoutPanel();
            gShadowPanelAvatar = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            gShadowPanelAvatar.SuspendLayout();
            SuspendLayout();
            // 
            // flpAvatarList
            // 
            flpAvatarList.AutoScroll = true;
            flpAvatarList.Location = new Point(40, 47);
            flpAvatarList.Name = "flpAvatarList";
            flpAvatarList.Size = new Size(1180, 110);
            flpAvatarList.TabIndex = 32;
            // 
            // gShadowPanelAvatar
            // 
            gShadowPanelAvatar.BackColor = Color.Transparent;
            gShadowPanelAvatar.Controls.Add(flpAvatarList);
            gShadowPanelAvatar.FillColor = Color.White;
            gShadowPanelAvatar.Location = new Point(0, 0);
            gShadowPanelAvatar.Name = "gShadowPanelAvatar";
            gShadowPanelAvatar.Radius = 7;
            gShadowPanelAvatar.ShadowColor = Color.Black;
            gShadowPanelAvatar.ShadowDepth = 200;
            gShadowPanelAvatar.ShadowShift = 10;
            gShadowPanelAvatar.Size = new Size(1260, 205);
            gShadowPanelAvatar.TabIndex = 33;
            // 
            // gElipse
            // 
            gElipse.BorderRadius = 10;
            gElipse.TargetControl = this;
            // 
            // FListAvatar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1260, 205);
            Controls.Add(gShadowPanelAvatar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FListAvatar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FListAvatar";
            gShadowPanelAvatar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpAvatarList;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelAvatar;
        private Guna.UI2.WinForms.Guna2Elipse gElipse;
    }
}
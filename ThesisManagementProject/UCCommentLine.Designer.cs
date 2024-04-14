namespace ThesisManagementProject
{
    partial class UCCommentLine
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
            gCirclePictureBoxCreator = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gShadowPanelTeam = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblCreator = new Label();
            rtbContent = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxCreator).BeginInit();
            gShadowPanelTeam.SuspendLayout();
            SuspendLayout();
            // 
            // gCirclePictureBoxCreator
            // 
            gCirclePictureBoxCreator.Image = Properties.Resources.PictureAvatarAccount;
            gCirclePictureBoxCreator.ImageRotate = 0F;
            gCirclePictureBoxCreator.Location = new Point(12, 14);
            gCirclePictureBoxCreator.Name = "gCirclePictureBoxCreator";
            gCirclePictureBoxCreator.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxCreator.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxCreator.Size = new Size(40, 40);
            gCirclePictureBoxCreator.SizeMode = PictureBoxSizeMode.Zoom;
            gCirclePictureBoxCreator.TabIndex = 62;
            gCirclePictureBoxCreator.TabStop = false;
            gCirclePictureBoxCreator.Click += gCirclePictureBoxCreator_Click;
            // 
            // gShadowPanelTeam
            // 
            gShadowPanelTeam.BackColor = Color.Transparent;
            gShadowPanelTeam.Controls.Add(lblCreator);
            gShadowPanelTeam.Controls.Add(rtbContent);
            gShadowPanelTeam.FillColor = Color.FromArgb(242, 245, 244);
            gShadowPanelTeam.Location = new Point(58, 9);
            gShadowPanelTeam.Name = "gShadowPanelTeam";
            gShadowPanelTeam.Radius = 7;
            gShadowPanelTeam.ShadowColor = Color.Black;
            gShadowPanelTeam.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelTeam.Size = new Size(550, 90);
            gShadowPanelTeam.TabIndex = 64;
            // 
            // lblCreator
            // 
            lblCreator.AutoSize = true;
            lblCreator.BackColor = Color.Transparent;
            lblCreator.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreator.ForeColor = Color.Black;
            lblCreator.Location = new Point(12, 9);
            lblCreator.Name = "lblCreator";
            lblCreator.Size = new Size(77, 20);
            lblCreator.TabIndex = 64;
            lblCreator.Text = "David Lee";
            // 
            // rtbContent
            // 
            rtbContent.BackColor = Color.FromArgb(242, 245, 244);
            rtbContent.BorderStyle = BorderStyle.None;
            rtbContent.Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbContent.Location = new Point(15, 29);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(500, 40);
            rtbContent.TabIndex = 65;
            rtbContent.Text = "comment iiii";
            // 
            // UCCommentLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gShadowPanelTeam);
            Controls.Add(gCirclePictureBoxCreator);
            DoubleBuffered = true;
            Name = "UCCommentLine";
            Size = new Size(640, 108);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxCreator).EndInit();
            gShadowPanelTeam.ResumeLayout(false);
            gShadowPanelTeam.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxCreator;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelTeam;
        private Label lblCreator;
        private RichTextBox rtbContent;
    }
}

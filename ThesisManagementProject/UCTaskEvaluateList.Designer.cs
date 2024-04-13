namespace ThesisManagementProject
{
    partial class UCTaskEvaluateList
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
            flpMembers = new FlowLayoutPanel();
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gShadowPanelBack.SuspendLayout();
            SuspendLayout();
            // 
            // flpMembers
            // 
            flpMembers.AutoScroll = true;
            flpMembers.BackColor = SystemColors.ButtonFace;
            flpMembers.Location = new Point(8, 9);
            flpMembers.Name = "flpMembers";
            flpMembers.Size = new Size(643, 454);
            flpMembers.TabIndex = 56;
            // 
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.Controls.Add(flpMembers);
            gShadowPanelBack.FillColor = SystemColors.ButtonFace;
            gShadowPanelBack.Location = new Point(10, 10);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 7;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 0;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(660, 470);
            gShadowPanelBack.TabIndex = 57;
            // 
            // UCTaskEvaluate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gShadowPanelBack);
            Name = "UCTaskEvaluate";
            Size = new Size(680, 490);
            gShadowPanelBack.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpMembers;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
    }
}

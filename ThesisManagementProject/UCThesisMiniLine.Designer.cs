namespace ThesisManagementProject
{
    partial class UCThesisMiniLine
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
            lblThesisTopic = new Label();
            gCircleButtonLevel = new Guna.UI2.WinForms.Guna2CircleButton();
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            SuspendLayout();
            // 
            // lblThesisTopic
            // 
            lblThesisTopic.AutoSize = true;
            lblThesisTopic.BackColor = Color.White;
            lblThesisTopic.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThesisTopic.Location = new Point(13, 11);
            lblThesisTopic.Name = "lblThesisTopic";
            lblThesisTopic.Size = new Size(99, 23);
            lblThesisTopic.TabIndex = 14;
            lblThesisTopic.Text = "Thesis topic";
            // 
            // gCircleButtonLevel
            // 
            gCircleButtonLevel.BackColor = Color.White;
            gCircleButtonLevel.DisabledState.BorderColor = Color.DarkGray;
            gCircleButtonLevel.DisabledState.CustomBorderColor = Color.DarkGray;
            gCircleButtonLevel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gCircleButtonLevel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gCircleButtonLevel.FillColor = Color.Silver;
            gCircleButtonLevel.Font = new Font("Segoe UI", 9F);
            gCircleButtonLevel.ForeColor = Color.White;
            gCircleButtonLevel.Location = new Point(213, 10);
            gCircleButtonLevel.Name = "gCircleButtonLevel";
            gCircleButtonLevel.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCircleButtonLevel.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCircleButtonLevel.Size = new Size(25, 25);
            gCircleButtonLevel.TabIndex = 15;
            // 
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.FillColor = Color.White;
            gShadowPanelBack.Location = new Point(0, 0);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 4;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 3;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(255, 50);
            gShadowPanelBack.TabIndex = 16;
            // 
            // UCThesisMiniLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(gCircleButtonLevel);
            Controls.Add(lblThesisTopic);
            Controls.Add(gShadowPanelBack);
            Name = "UCThesisMiniLine";
            Size = new Size(255, 50);
            Click += UCThesisMiniLine_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblThesisTopic;
        private Guna.UI2.WinForms.Guna2CircleButton gCircleButtonLevel;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
    }
}

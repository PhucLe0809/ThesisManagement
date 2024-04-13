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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblThesisTopic = new Label();
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gTextBoxStatus = new Guna.UI2.WinForms.Guna2TextBox();
            gShadowPanelBack.SuspendLayout();
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
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.Controls.Add(gTextBoxStatus);
            gShadowPanelBack.FillColor = Color.White;
            gShadowPanelBack.Location = new Point(0, 0);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 4;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 3;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(345, 50);
            gShadowPanelBack.TabIndex = 16;
            gShadowPanelBack.Click += UCThesisMiniLine_Click;
            // 
            // gTextBoxStatus
            // 
            gTextBoxStatus.BackColor = Color.Transparent;
            gTextBoxStatus.BorderRadius = 10;
            gTextBoxStatus.BorderThickness = 0;
            gTextBoxStatus.CustomizableEdges = customizableEdges1;
            gTextBoxStatus.DefaultText = "Published";
            gTextBoxStatus.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxStatus.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxStatus.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxStatus.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxStatus.FillColor = Color.Gray;
            gTextBoxStatus.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gTextBoxStatus.ForeColor = Color.White;
            gTextBoxStatus.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxStatus.Location = new Point(218, 10);
            gTextBoxStatus.Margin = new Padding(3, 4, 3, 4);
            gTextBoxStatus.Name = "gTextBoxStatus";
            gTextBoxStatus.PasswordChar = '\0';
            gTextBoxStatus.PlaceholderText = "";
            gTextBoxStatus.ReadOnly = true;
            gTextBoxStatus.SelectedText = "";
            gTextBoxStatus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gTextBoxStatus.Size = new Size(110, 25);
            gTextBoxStatus.TabIndex = 60;
            gTextBoxStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // UCThesisMiniLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(lblThesisTopic);
            Controls.Add(gShadowPanelBack);
            Name = "UCThesisMiniLine";
            Size = new Size(350, 50);
            Click += UCThesisMiniLine_Click;
            gShadowPanelBack.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblThesisTopic;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxStatus;
    }
}

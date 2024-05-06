namespace ThesisManagementProject.Forms
{
    partial class FGiveUp
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGiveUp));
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
            gShadowPanelReason = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gTextBoxReason = new Guna.UI2.WinForms.Guna2TextBox();
            lblReason = new Label();
            gButtonConfirm = new Guna.UI2.WinForms.Guna2GradientButton();
            gButtonCancel = new Guna.UI2.WinForms.Guna2Button();
            gShadowPanelInformations = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTeam = new Label();
            gPanelTeam = new Guna.UI2.WinForms.Guna2Panel();
            lblRepresent = new Label();
            gPanelRepresent = new Guna.UI2.WinForms.Guna2Panel();
            gPanelThesis = new Guna.UI2.WinForms.Guna2Panel();
            erpReason = new ErrorProvider(components);
            gShadowPanelReason.SuspendLayout();
            gShadowPanelInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)erpReason).BeginInit();
            SuspendLayout();
            // 
            // gShadowPanelReason
            // 
            gShadowPanelReason.BackColor = Color.Transparent;
            gShadowPanelReason.Controls.Add(gTextBoxReason);
            gShadowPanelReason.Controls.Add(lblReason);
            gShadowPanelReason.FillColor = Color.White;
            gShadowPanelReason.Location = new Point(29, 345);
            gShadowPanelReason.Name = "gShadowPanelReason";
            gShadowPanelReason.Radius = 7;
            gShadowPanelReason.ShadowColor = Color.Black;
            gShadowPanelReason.Size = new Size(743, 264);
            gShadowPanelReason.TabIndex = 43;
            // 
            // gTextBoxReason
            // 
            gTextBoxReason.AutoScroll = true;
            gTextBoxReason.BorderColor = Color.FromArgb(74, 97, 94);
            gTextBoxReason.BorderRadius = 5;
            gTextBoxReason.CustomizableEdges = customizableEdges1;
            gTextBoxReason.DefaultText = "";
            gTextBoxReason.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxReason.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxReason.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxReason.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxReason.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxReason.Font = new Font("Segoe UI", 9F);
            gTextBoxReason.ForeColor = Color.Black;
            gTextBoxReason.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxReason.IconLeft = (Image)resources.GetObject("gTextBoxReason.IconLeft");
            gTextBoxReason.IconLeftOffset = new Point(5, 0);
            gTextBoxReason.IconLeftSize = new Size(22, 22);
            gTextBoxReason.Location = new Point(34, 57);
            gTextBoxReason.Margin = new Padding(3, 4, 3, 4);
            gTextBoxReason.Multiline = true;
            gTextBoxReason.Name = "gTextBoxReason";
            gTextBoxReason.PasswordChar = '\0';
            gTextBoxReason.PlaceholderForeColor = Color.Gray;
            gTextBoxReason.PlaceholderText = "Your reason";
            gTextBoxReason.SelectedText = "";
            gTextBoxReason.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gTextBoxReason.Size = new Size(667, 172);
            gTextBoxReason.TabIndex = 70;
            gTextBoxReason.TextOffset = new Point(5, 0);
            gTextBoxReason.TextChanged += gTextBoxReason_TextChanged;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.BackColor = Color.Transparent;
            lblReason.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReason.ForeColor = Color.Black;
            lblReason.Location = new Point(34, 25);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(97, 28);
            lblReason.TabIndex = 5;
            lblReason.Text = "REASON";
            // 
            // gButtonConfirm
            // 
            gButtonConfirm.BackColor = Color.Transparent;
            gButtonConfirm.BorderRadius = 7;
            gButtonConfirm.CustomizableEdges = customizableEdges3;
            gButtonConfirm.DisabledState.BorderColor = Color.DarkGray;
            gButtonConfirm.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonConfirm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonConfirm.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gButtonConfirm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonConfirm.FillColor = Color.FromArgb(2, 0, 214);
            gButtonConfirm.FillColor2 = Color.FromArgb(94, 148, 255);
            gButtonConfirm.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gButtonConfirm.ForeColor = Color.White;
            gButtonConfirm.Location = new Point(672, 624);
            gButtonConfirm.Name = "gButtonConfirm";
            gButtonConfirm.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gButtonConfirm.Size = new Size(100, 35);
            gButtonConfirm.TabIndex = 44;
            gButtonConfirm.Text = "Confirm";
            gButtonConfirm.Click += gButtonConfirm_Click;
            // 
            // gButtonCancel
            // 
            gButtonCancel.BackColor = Color.Transparent;
            gButtonCancel.BorderRadius = 7;
            gButtonCancel.CustomizableEdges = customizableEdges5;
            gButtonCancel.DisabledState.BorderColor = Color.DarkGray;
            gButtonCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonCancel.FillColor = Color.Silver;
            gButtonCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gButtonCancel.ForeColor = Color.White;
            gButtonCancel.Location = new Point(543, 624);
            gButtonCancel.Name = "gButtonCancel";
            gButtonCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gButtonCancel.Size = new Size(100, 35);
            gButtonCancel.TabIndex = 45;
            gButtonCancel.Text = "Cancel";
            gButtonCancel.Click += gButtonCancel_Click;
            // 
            // gShadowPanelInformations
            // 
            gShadowPanelInformations.BackColor = Color.Transparent;
            gShadowPanelInformations.Controls.Add(lblTeam);
            gShadowPanelInformations.Controls.Add(gPanelTeam);
            gShadowPanelInformations.Controls.Add(lblRepresent);
            gShadowPanelInformations.Controls.Add(gPanelRepresent);
            gShadowPanelInformations.Controls.Add(gPanelThesis);
            gShadowPanelInformations.FillColor = Color.White;
            gShadowPanelInformations.Location = new Point(29, 24);
            gShadowPanelInformations.Name = "gShadowPanelInformations";
            gShadowPanelInformations.Radius = 7;
            gShadowPanelInformations.ShadowColor = Color.Black;
            gShadowPanelInformations.Size = new Size(743, 315);
            gShadowPanelInformations.TabIndex = 71;
            // 
            // lblTeam
            // 
            lblTeam.AutoSize = true;
            lblTeam.BackColor = Color.Transparent;
            lblTeam.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTeam.ForeColor = Color.Black;
            lblTeam.Location = new Point(439, 142);
            lblTeam.Name = "lblTeam";
            lblTeam.Size = new Size(71, 28);
            lblTeam.TabIndex = 74;
            lblTeam.Text = "TEAM";
            // 
            // gPanelTeam
            // 
            gPanelTeam.CustomizableEdges = customizableEdges7;
            gPanelTeam.Location = new Point(439, 174);
            gPanelTeam.Name = "gPanelTeam";
            gPanelTeam.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gPanelTeam.Size = new Size(275, 60);
            gPanelTeam.TabIndex = 75;
            // 
            // lblRepresent
            // 
            lblRepresent.AutoSize = true;
            lblRepresent.BackColor = Color.Transparent;
            lblRepresent.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRepresent.ForeColor = Color.Black;
            lblRepresent.Location = new Point(439, 32);
            lblRepresent.Name = "lblRepresent";
            lblRepresent.Size = new Size(134, 28);
            lblRepresent.TabIndex = 5;
            lblRepresent.Text = "REPRESENT";
            // 
            // gPanelRepresent
            // 
            gPanelRepresent.CustomizableEdges = customizableEdges9;
            gPanelRepresent.Location = new Point(439, 64);
            gPanelRepresent.Name = "gPanelRepresent";
            gPanelRepresent.ShadowDecoration.CustomizableEdges = customizableEdges10;
            gPanelRepresent.Size = new Size(275, 60);
            gPanelRepresent.TabIndex = 73;
            // 
            // gPanelThesis
            // 
            gPanelThesis.CustomizableEdges = customizableEdges11;
            gPanelThesis.Location = new Point(25, 25);
            gPanelThesis.Name = "gPanelThesis";
            gPanelThesis.ShadowDecoration.CustomizableEdges = customizableEdges12;
            gPanelThesis.Size = new Size(399, 266);
            gPanelThesis.TabIndex = 72;
            // 
            // erpReason
            // 
            erpReason.ContainerControl = this;
            erpReason.Icon = (Icon)resources.GetObject("erpReason.Icon");
            // 
            // FGiveUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(802, 690);
            Controls.Add(gShadowPanelInformations);
            Controls.Add(gButtonConfirm);
            Controls.Add(gButtonCancel);
            Controls.Add(gShadowPanelReason);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FGiveUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Give Up";
            gShadowPanelReason.ResumeLayout(false);
            gShadowPanelReason.PerformLayout();
            gShadowPanelInformations.ResumeLayout(false);
            gShadowPanelInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)erpReason).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelReason;
        private Label lblReason;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxReason;
        private Guna.UI2.WinForms.Guna2GradientButton gButtonConfirm;
        private Guna.UI2.WinForms.Guna2Button gButtonCancel;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelInformations;
        private Guna.UI2.WinForms.Guna2Panel gPanelThesis;
        private Guna.UI2.WinForms.Guna2Panel gPanelRepresent;
        private Label lblRepresent;
        private Label lblTeam;
        private Guna.UI2.WinForms.Guna2Panel gPanelTeam;
        private ErrorProvider erpReason;
    }
}
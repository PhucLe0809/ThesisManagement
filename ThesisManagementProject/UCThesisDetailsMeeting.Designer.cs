namespace ThesisManagementProject
{
    partial class UCThesisDetailsMeeting
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
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            flpMeetingList = new FlowLayoutPanel();
            gGradientButtonAddMeeting = new Guna.UI2.WinForms.Guna2GradientButton();
            gSeparatorUnderHeader = new Guna.UI2.WinForms.Guna2Separator();
            lblMeetingList = new Label();
            gShadowPanelBack.SuspendLayout();
            SuspendLayout();
            // 
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.Controls.Add(flpMeetingList);
            gShadowPanelBack.FillColor = SystemColors.ButtonFace;
            gShadowPanelBack.Location = new Point(16, 74);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 7;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 0;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(685, 545);
            gShadowPanelBack.TabIndex = 49;
            // 
            // flpMeetingList
            // 
            flpMeetingList.AutoScroll = true;
            flpMeetingList.Location = new Point(12, 12);
            flpMeetingList.Name = "flpMeetingList";
            flpMeetingList.Size = new Size(660, 518);
            flpMeetingList.TabIndex = 13;
            // 
            // gGradientButtonAddMeeting
            // 
            gGradientButtonAddMeeting.BackColor = Color.Transparent;
            gGradientButtonAddMeeting.BorderRadius = 10;
            gGradientButtonAddMeeting.CustomizableEdges = customizableEdges1;
            gGradientButtonAddMeeting.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonAddMeeting.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonAddMeeting.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonAddMeeting.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonAddMeeting.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonAddMeeting.FillColor = SystemColors.ButtonFace;
            gGradientButtonAddMeeting.FillColor2 = SystemColors.ButtonFace;
            gGradientButtonAddMeeting.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonAddMeeting.ForeColor = Color.Black;
            gGradientButtonAddMeeting.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButtonAddMeeting.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButtonAddMeeting.HoverState.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonAddMeeting.HoverState.ForeColor = Color.White;
            gGradientButtonAddMeeting.Location = new Point(559, 10);
            gGradientButtonAddMeeting.Name = "gGradientButtonAddMeeting";
            gGradientButtonAddMeeting.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gGradientButtonAddMeeting.Size = new Size(130, 40);
            gGradientButtonAddMeeting.TabIndex = 53;
            gGradientButtonAddMeeting.Text = "Add Meeting";
            gGradientButtonAddMeeting.Click += gGradientButtonAddMeeting_Click;
            // 
            // gSeparatorUnderHeader
            // 
            gSeparatorUnderHeader.Location = new Point(31, 56);
            gSeparatorUnderHeader.Name = "gSeparatorUnderHeader";
            gSeparatorUnderHeader.Size = new Size(670, 12);
            gSeparatorUnderHeader.TabIndex = 51;
            // 
            // lblMeetingList
            // 
            lblMeetingList.AutoSize = true;
            lblMeetingList.BackColor = Color.Transparent;
            lblMeetingList.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMeetingList.Location = new Point(31, 19);
            lblMeetingList.Name = "lblMeetingList";
            lblMeetingList.Size = new Size(157, 28);
            lblMeetingList.TabIndex = 50;
            lblMeetingList.Text = "MEETING LIST";
            // 
            // UCThesisDetailsMeeting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gShadowPanelBack);
            Controls.Add(gGradientButtonAddMeeting);
            Controls.Add(gSeparatorUnderHeader);
            Controls.Add(lblMeetingList);
            Name = "UCThesisDetailsMeeting";
            Size = new Size(715, 635);
            gShadowPanelBack.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
        private FlowLayoutPanel flpMeetingList;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonAddMeeting;
        private Guna.UI2.WinForms.Guna2Separator gSeparatorUnderHeader;
        private Label lblMeetingList;
    }
}

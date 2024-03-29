namespace ThesisManagementProject
{
    partial class UCThesisDetailsCreatedTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCThesisDetailsCreatedTeam));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flpTeamRegistered = new FlowLayoutPanel();
            gSeparatorTopic = new Guna.UI2.WinForms.Guna2Separator();
            lblRegisteredList = new Label();
            gShadowPanelSearch = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gTextBoxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            gShadowPanelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // flpTeamRegistered
            // 
            flpTeamRegistered.AutoScroll = true;
            flpTeamRegistered.Location = new Point(25, 142);
            flpTeamRegistered.Name = "flpTeamRegistered";
            flpTeamRegistered.Size = new Size(555, 395);
            flpTeamRegistered.TabIndex = 55;
            // 
            // gSeparatorTopic
            // 
            gSeparatorTopic.Location = new Point(25, 61);
            gSeparatorTopic.Name = "gSeparatorTopic";
            gSeparatorTopic.Size = new Size(555, 12);
            gSeparatorTopic.TabIndex = 54;
            // 
            // lblRegisteredList
            // 
            lblRegisteredList.AutoSize = true;
            lblRegisteredList.BackColor = Color.Transparent;
            lblRegisteredList.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegisteredList.Location = new Point(25, 30);
            lblRegisteredList.Name = "lblRegisteredList";
            lblRegisteredList.Size = new Size(193, 28);
            lblRegisteredList.TabIndex = 53;
            lblRegisteredList.Text = "REGISTERED LIST";
            // 
            // gShadowPanelSearch
            // 
            gShadowPanelSearch.BackColor = Color.Transparent;
            gShadowPanelSearch.Controls.Add(gTextBoxSearch);
            gShadowPanelSearch.FillColor = Color.White;
            gShadowPanelSearch.Location = new Point(25, 79);
            gShadowPanelSearch.Name = "gShadowPanelSearch";
            gShadowPanelSearch.Radius = 7;
            gShadowPanelSearch.ShadowColor = Color.Black;
            gShadowPanelSearch.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelSearch.Size = new Size(368, 55);
            gShadowPanelSearch.TabIndex = 56;
            // 
            // gTextBoxSearch
            // 
            gTextBoxSearch.BorderColor = Color.FromArgb(74, 97, 94);
            gTextBoxSearch.BorderRadius = 8;
            gTextBoxSearch.CustomizableEdges = customizableEdges1;
            gTextBoxSearch.DefaultText = "";
            gTextBoxSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxSearch.Font = new Font("Segoe UI", 9F);
            gTextBoxSearch.ForeColor = Color.Black;
            gTextBoxSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxSearch.IconLeft = (Image)resources.GetObject("gTextBoxSearch.IconLeft");
            gTextBoxSearch.IconLeftOffset = new Point(5, 0);
            gTextBoxSearch.Location = new Point(15, 6);
            gTextBoxSearch.Margin = new Padding(3, 4, 3, 4);
            gTextBoxSearch.Name = "gTextBoxSearch";
            gTextBoxSearch.PasswordChar = '\0';
            gTextBoxSearch.PlaceholderForeColor = Color.Gray;
            gTextBoxSearch.PlaceholderText = "Search user email";
            gTextBoxSearch.SelectedText = "";
            gTextBoxSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gTextBoxSearch.Size = new Size(338, 40);
            gTextBoxSearch.TabIndex = 9;
            gTextBoxSearch.TextOffset = new Point(5, 0);
            // 
            // UCThesisDetailsCreatedTeam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gShadowPanelSearch);
            Controls.Add(flpTeamRegistered);
            Controls.Add(gSeparatorTopic);
            Controls.Add(lblRegisteredList);
            Name = "UCThesisDetailsCreatedTeam";
            Size = new Size(608, 635);
            Load += UCThesisDetailsCreatedTeam_Load;
            gShadowPanelSearch.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpTeamRegistered;
        private Guna.UI2.WinForms.Guna2Separator gSeparatorTopic;
        private Label lblRegisteredList;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelSearch;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxSearch;
    }
}

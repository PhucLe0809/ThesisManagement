namespace ThesisManagementProject
{
    partial class UCThesisDetailsTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCThesisDetailsTasks));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gShadowPanelBack = new Guna.UI2.WinForms.Guna2ShadowPanel();
            flpTaskList = new FlowLayoutPanel();
            gSeparatorUnderHeader = new Guna.UI2.WinForms.Guna2Separator();
            lblTaskList = new Label();
            gTextBoxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            gGradientButtonAddTask = new Guna.UI2.WinForms.Guna2GradientButton();
            lblSearch = new Label();
            gShadowPanelBack.SuspendLayout();
            SuspendLayout();
            // 
            // gShadowPanelBack
            // 
            gShadowPanelBack.BackColor = Color.Transparent;
            gShadowPanelBack.Controls.Add(flpTaskList);
            gShadowPanelBack.FillColor = SystemColors.ButtonFace;
            gShadowPanelBack.Location = new Point(16, 124);
            gShadowPanelBack.Name = "gShadowPanelBack";
            gShadowPanelBack.Radius = 7;
            gShadowPanelBack.ShadowColor = Color.Black;
            gShadowPanelBack.ShadowShift = 0;
            gShadowPanelBack.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelBack.Size = new Size(575, 495);
            gShadowPanelBack.TabIndex = 43;
            // 
            // flpTaskList
            // 
            flpTaskList.AutoScroll = true;
            flpTaskList.Location = new Point(12, 12);
            flpTaskList.Name = "flpTaskList";
            flpTaskList.Size = new Size(550, 458);
            flpTaskList.TabIndex = 13;
            // 
            // gSeparatorUnderHeader
            // 
            gSeparatorUnderHeader.Location = new Point(31, 56);
            gSeparatorUnderHeader.Name = "gSeparatorUnderHeader";
            gSeparatorUnderHeader.Size = new Size(550, 12);
            gSeparatorUnderHeader.TabIndex = 45;
            // 
            // lblTaskList
            // 
            lblTaskList.AutoSize = true;
            lblTaskList.BackColor = Color.Transparent;
            lblTaskList.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaskList.Location = new Point(31, 19);
            lblTaskList.Name = "lblTaskList";
            lblTaskList.Size = new Size(117, 28);
            lblTaskList.TabIndex = 44;
            lblTaskList.Text = "TASK LIST";
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
            gTextBoxSearch.Location = new Point(114, 74);
            gTextBoxSearch.Margin = new Padding(3, 4, 3, 4);
            gTextBoxSearch.Name = "gTextBoxSearch";
            gTextBoxSearch.PasswordChar = '\0';
            gTextBoxSearch.PlaceholderForeColor = Color.Gray;
            gTextBoxSearch.PlaceholderText = "Search task title";
            gTextBoxSearch.SelectedText = "";
            gTextBoxSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gTextBoxSearch.Size = new Size(332, 40);
            gTextBoxSearch.TabIndex = 46;
            gTextBoxSearch.TextOffset = new Point(5, 0);
            gTextBoxSearch.TextChanged += gTextBoxSearch_TextChanged;
            // 
            // gGradientButtonAddTask
            // 
            gGradientButtonAddTask.BackColor = Color.Transparent;
            gGradientButtonAddTask.BorderRadius = 10;
            gGradientButtonAddTask.CustomizableEdges = customizableEdges3;
            gGradientButtonAddTask.DisabledState.BorderColor = Color.DarkGray;
            gGradientButtonAddTask.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButtonAddTask.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButtonAddTask.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButtonAddTask.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButtonAddTask.FillColor = SystemColors.ButtonFace;
            gGradientButtonAddTask.FillColor2 = SystemColors.ButtonFace;
            gGradientButtonAddTask.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonAddTask.ForeColor = Color.Black;
            gGradientButtonAddTask.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButtonAddTask.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButtonAddTask.HoverState.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButtonAddTask.HoverState.ForeColor = Color.White;
            gGradientButtonAddTask.Location = new Point(461, 74);
            gGradientButtonAddTask.Name = "gGradientButtonAddTask";
            gGradientButtonAddTask.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gGradientButtonAddTask.Size = new Size(117, 40);
            gGradientButtonAddTask.TabIndex = 47;
            gGradientButtonAddTask.Text = "Add Task";
            gGradientButtonAddTask.Click += gGradientButtonAddTask_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(32, 81);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(76, 26);
            lblSearch.TabIndex = 48;
            lblSearch.Text = "Search";
            // 
            // UCThesisDetailsTasks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblSearch);
            Controls.Add(gGradientButtonAddTask);
            Controls.Add(gTextBoxSearch);
            Controls.Add(gSeparatorUnderHeader);
            Controls.Add(lblTaskList);
            Controls.Add(gShadowPanelBack);
            DoubleBuffered = true;
            Name = "UCThesisDetailsTasks";
            Size = new Size(608, 635);
            gShadowPanelBack.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelBack;
        private Guna.UI2.WinForms.Guna2Separator gSeparatorUnderHeader;
        private Label lblTaskList;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxSearch;
        private Guna.UI2.WinForms.Guna2GradientButton gGradientButtonAddTask;
        private FlowLayoutPanel flpTaskList;
        private Label lblSearch;
    }
}

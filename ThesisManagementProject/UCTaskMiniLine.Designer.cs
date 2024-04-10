namespace ThesisManagementProject
{
    partial class UCTaskMiniLine
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTaskMiniLine));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gShadowPanelTeam = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gProgressBarToLine = new Guna.UI2.WinForms.Guna2ProgressBar();
            gButtonStar = new Guna.UI2.WinForms.Guna2Button();
            lblCreator = new Label();
            lblCre = new Label();
            gButtonDelete = new Guna.UI2.WinForms.Guna2Button();
            lblTaskTitle = new Label();
            gShadowPanelTeam.SuspendLayout();
            SuspendLayout();
            // 
            // gShadowPanelTeam
            // 
            gShadowPanelTeam.BackColor = Color.Transparent;
            gShadowPanelTeam.Controls.Add(gProgressBarToLine);
            gShadowPanelTeam.Controls.Add(gButtonStar);
            gShadowPanelTeam.Controls.Add(lblCreator);
            gShadowPanelTeam.Controls.Add(lblCre);
            gShadowPanelTeam.Controls.Add(gButtonDelete);
            gShadowPanelTeam.Controls.Add(lblTaskTitle);
            gShadowPanelTeam.FillColor = Color.White;
            gShadowPanelTeam.Location = new Point(0, 0);
            gShadowPanelTeam.Name = "gShadowPanelTeam";
            gShadowPanelTeam.Radius = 5;
            gShadowPanelTeam.ShadowColor = Color.Black;
            gShadowPanelTeam.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelTeam.Size = new Size(515, 70);
            gShadowPanelTeam.TabIndex = 43;
            gShadowPanelTeam.Click += gShadowPanelTeam_Click;
            // 
            // gProgressBarToLine
            // 
            gProgressBarToLine.BorderRadius = 6;
            gProgressBarToLine.CustomizableEdges = customizableEdges1;
            gProgressBarToLine.Location = new Point(258, 38);
            gProgressBarToLine.Name = "gProgressBarToLine";
            gProgressBarToLine.ProgressColor = Color.FromArgb(94, 148, 255);
            gProgressBarToLine.ProgressColor2 = Color.FromArgb(255, 77, 165);
            gProgressBarToLine.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gProgressBarToLine.Size = new Size(170, 15);
            gProgressBarToLine.TabIndex = 58;
            gProgressBarToLine.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            gProgressBarToLine.Value = 75;
            // 
            // gButtonStar
            // 
            gButtonStar.BorderRadius = 5;
            gButtonStar.CustomizableEdges = customizableEdges3;
            gButtonStar.DisabledState.BorderColor = Color.DarkGray;
            gButtonStar.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonStar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonStar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonStar.FillColor = Color.White;
            gButtonStar.Font = new Font("Segoe UI", 9F);
            gButtonStar.ForeColor = Color.White;
            gButtonStar.HoverState.FillColor = Color.White;
            gButtonStar.Image = (Image)resources.GetObject("gButtonStar.Image");
            gButtonStar.ImageSize = new Size(25, 25);
            gButtonStar.Location = new Point(12, 10);
            gButtonStar.Name = "gButtonStar";
            gButtonStar.PressedColor = Color.White;
            gButtonStar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gButtonStar.Size = new Size(40, 40);
            gButtonStar.TabIndex = 57;
            gButtonStar.Click += gButtonStar_Click;
            // 
            // lblCreator
            // 
            lblCreator.AutoSize = true;
            lblCreator.BackColor = Color.Transparent;
            lblCreator.Font = new Font("Century Gothic", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCreator.Location = new Point(122, 35);
            lblCreator.Name = "lblCreator";
            lblCreator.Size = new Size(92, 18);
            lblCreator.TabIndex = 40;
            lblCreator.Text = "Anonymous";
            // 
            // lblCre
            // 
            lblCre.AutoSize = true;
            lblCre.BackColor = Color.Transparent;
            lblCre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCre.ForeColor = Color.FromArgb(74, 97, 94);
            lblCre.Location = new Point(54, 34);
            lblCre.Name = "lblCre";
            lblCre.Size = new Size(68, 20);
            lblCre.TabIndex = 39;
            lblCre.Text = "Creator :";
            // 
            // gButtonDelete
            // 
            gButtonDelete.BackColor = Color.Transparent;
            gButtonDelete.BorderRadius = 5;
            gButtonDelete.CustomizableEdges = customizableEdges5;
            gButtonDelete.DisabledState.BorderColor = Color.DarkGray;
            gButtonDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonDelete.FillColor = Color.Transparent;
            gButtonDelete.Font = new Font("Segoe UI", 9F);
            gButtonDelete.ForeColor = Color.White;
            gButtonDelete.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonDelete.Image = (Image)resources.GetObject("gButtonDelete.Image");
            gButtonDelete.ImageSize = new Size(25, 25);
            gButtonDelete.Location = new Point(452, 12);
            gButtonDelete.Name = "gButtonDelete";
            gButtonDelete.PressedColor = Color.White;
            gButtonDelete.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gButtonDelete.Size = new Size(40, 40);
            gButtonDelete.TabIndex = 22;
            gButtonDelete.Click += gButtonDelete_Click;
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.BackColor = Color.White;
            lblTaskTitle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaskTitle.Location = new Point(54, 9);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(76, 23);
            lblTaskTitle.TabIndex = 19;
            lblTaskTitle.Text = "Task title";
            // 
            // UCTaskMiniLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(gShadowPanelTeam);
            DoubleBuffered = true;
            Name = "UCTaskMiniLine";
            Size = new Size(520, 70);
            gShadowPanelTeam.ResumeLayout(false);
            gShadowPanelTeam.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelTeam;
        private Label lblTaskTitle;
        private Guna.UI2.WinForms.Guna2Button gButtonDelete;
        private Label lblCreator;
        private Label lblCre;
        private Guna.UI2.WinForms.Guna2Button gButtonStar;
        private Guna.UI2.WinForms.Guna2ProgressBar gProgressBarToLine;
    }
}

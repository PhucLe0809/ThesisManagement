namespace ThesisManagementProject
{
    partial class UCTaskCreate
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTaskCreate));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblDescription = new Label();
            gTextBoxDescription = new Guna.UI2.WinForms.Guna2TextBox();
            lblTaskTitle = new Label();
            gTextBoxTitle = new Guna.UI2.WinForms.Guna2TextBox();
            gButtonCreate = new Guna.UI2.WinForms.Guna2GradientButton();
            gButtonCancel = new Guna.UI2.WinForms.Guna2Button();
            erpTitle = new ErrorProvider(components);
            erpDescription = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)erpTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)erpDescription).BeginInit();
            SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(16, 150);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(151, 28);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "DESCRIPTION";
            // 
            // gTextBoxDescription
            // 
            gTextBoxDescription.AutoScroll = true;
            gTextBoxDescription.BorderColor = Color.FromArgb(74, 97, 94);
            gTextBoxDescription.BorderRadius = 5;
            gTextBoxDescription.CustomizableEdges = customizableEdges1;
            gTextBoxDescription.DefaultText = "";
            gTextBoxDescription.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxDescription.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxDescription.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxDescription.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxDescription.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxDescription.Font = new Font("Segoe UI", 9F);
            gTextBoxDescription.ForeColor = Color.Black;
            gTextBoxDescription.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxDescription.IconLeft = (Image)resources.GetObject("gTextBoxDescription.IconLeft");
            gTextBoxDescription.IconLeftOffset = new Point(5, 0);
            gTextBoxDescription.IconLeftSize = new Size(22, 22);
            gTextBoxDescription.Location = new Point(16, 182);
            gTextBoxDescription.Margin = new Padding(3, 4, 3, 4);
            gTextBoxDescription.Multiline = true;
            gTextBoxDescription.Name = "gTextBoxDescription";
            gTextBoxDescription.PasswordChar = '\0';
            gTextBoxDescription.PlaceholderForeColor = Color.Gray;
            gTextBoxDescription.PlaceholderText = "Task description";
            gTextBoxDescription.SelectedText = "";
            gTextBoxDescription.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gTextBoxDescription.Size = new Size(615, 163);
            gTextBoxDescription.TabIndex = 11;
            gTextBoxDescription.TextOffset = new Point(5, 0);
            gTextBoxDescription.TextChanged += gTextBoxDescription_TextChanged;
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.BackColor = Color.Transparent;
            lblTaskTitle.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaskTitle.Location = new Point(16, 15);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(132, 28);
            lblTaskTitle.TabIndex = 12;
            lblTaskTitle.Text = "TASK TITLE";
            // 
            // gTextBoxTitle
            // 
            gTextBoxTitle.AutoScroll = true;
            gTextBoxTitle.BorderColor = Color.FromArgb(74, 97, 94);
            gTextBoxTitle.BorderRadius = 5;
            gTextBoxTitle.CustomizableEdges = customizableEdges3;
            gTextBoxTitle.DefaultText = "";
            gTextBoxTitle.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxTitle.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxTitle.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxTitle.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxTitle.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxTitle.Font = new Font("Segoe UI", 9F);
            gTextBoxTitle.ForeColor = Color.Black;
            gTextBoxTitle.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxTitle.IconLeft = (Image)resources.GetObject("gTextBoxTitle.IconLeft");
            gTextBoxTitle.IconLeftOffset = new Point(5, 0);
            gTextBoxTitle.Location = new Point(16, 47);
            gTextBoxTitle.Margin = new Padding(3, 4, 3, 4);
            gTextBoxTitle.Multiline = true;
            gTextBoxTitle.Name = "gTextBoxTitle";
            gTextBoxTitle.PasswordChar = '\0';
            gTextBoxTitle.PlaceholderForeColor = Color.Gray;
            gTextBoxTitle.PlaceholderText = "Task title";
            gTextBoxTitle.SelectedText = "";
            gTextBoxTitle.ShadowDecoration.CustomizableEdges = customizableEdges4;
            gTextBoxTitle.Size = new Size(615, 90);
            gTextBoxTitle.TabIndex = 9;
            gTextBoxTitle.TextOffset = new Point(5, 0);
            gTextBoxTitle.TextChanged += gTextBoxTitle_TextChanged;
            // 
            // gButtonCreate
            // 
            gButtonCreate.BackColor = Color.Transparent;
            gButtonCreate.BorderRadius = 7;
            gButtonCreate.CustomizableEdges = customizableEdges5;
            gButtonCreate.DisabledState.BorderColor = Color.DarkGray;
            gButtonCreate.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonCreate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonCreate.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gButtonCreate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonCreate.FillColor = Color.FromArgb(2, 0, 214);
            gButtonCreate.FillColor2 = Color.FromArgb(94, 148, 255);
            gButtonCreate.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gButtonCreate.ForeColor = Color.White;
            gButtonCreate.Location = new Point(506, 373);
            gButtonCreate.Name = "gButtonCreate";
            gButtonCreate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            gButtonCreate.Size = new Size(100, 35);
            gButtonCreate.TabIndex = 69;
            gButtonCreate.Text = "Create";
            gButtonCreate.Click += gButtonCreate_Click;
            // 
            // gButtonCancel
            // 
            gButtonCancel.BackColor = Color.Transparent;
            gButtonCancel.BorderRadius = 7;
            gButtonCancel.CustomizableEdges = customizableEdges7;
            gButtonCancel.DisabledState.BorderColor = Color.DarkGray;
            gButtonCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonCancel.FillColor = Color.Silver;
            gButtonCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gButtonCancel.ForeColor = Color.White;
            gButtonCancel.Location = new Point(377, 373);
            gButtonCancel.Name = "gButtonCancel";
            gButtonCancel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gButtonCancel.Size = new Size(100, 35);
            gButtonCancel.TabIndex = 70;
            gButtonCancel.Text = "Cancel";
            // 
            // erpTitle
            // 
            erpTitle.ContainerControl = this;
            erpTitle.Icon = (Icon)resources.GetObject("erpTitle.Icon");
            // 
            // erpDescription
            // 
            erpDescription.ContainerControl = this;
            erpDescription.Icon = (Icon)resources.GetObject("erpDescription.Icon");
            // 
            // UCTaskCreate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(gButtonCreate);
            Controls.Add(gButtonCancel);
            Controls.Add(lblDescription);
            Controls.Add(gTextBoxDescription);
            Controls.Add(lblTaskTitle);
            Controls.Add(gTextBoxTitle);
            DoubleBuffered = true;
            Name = "UCTaskCreate";
            Size = new Size(660, 458);
            ((System.ComponentModel.ISupportInitialize)erpTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)erpDescription).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDescription;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxDescription;
        private Label lblTaskTitle;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxTitle;
        private Guna.UI2.WinForms.Guna2GradientButton gButtonCreate;
        private Guna.UI2.WinForms.Guna2Button gButtonCancel;
        private ErrorProvider erpTitle;
        private ErrorProvider erpDescription;
    }
}

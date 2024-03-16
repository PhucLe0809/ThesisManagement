namespace ThesisManagementProject
{
    partial class UCTopicMiniLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTopicMiniLine));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gGradientButton = new Guna.UI2.WinForms.Guna2GradientButton();
            SuspendLayout();
            // 
            // gGradientButton
            // 
            gGradientButton.BackColor = Color.Transparent;
            gGradientButton.BorderRadius = 5;
            gGradientButton.CustomizableEdges = customizableEdges1;
            gGradientButton.DisabledState.BorderColor = Color.DarkGray;
            gGradientButton.DisabledState.CustomBorderColor = Color.DarkGray;
            gGradientButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gGradientButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            gGradientButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gGradientButton.FillColor = Color.White;
            gGradientButton.FillColor2 = Color.White;
            gGradientButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButton.ForeColor = Color.DimGray;
            gGradientButton.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            gGradientButton.HoverState.FillColor2 = Color.FromArgb(255, 77, 165);
            gGradientButton.HoverState.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gGradientButton.HoverState.ForeColor = Color.White;
            gGradientButton.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gGradientButton.Image = (Image)resources.GetObject("gGradientButton.Image");
            gGradientButton.ImageAlign = HorizontalAlignment.Left;
            gGradientButton.Location = new Point(0, 0);
            gGradientButton.Name = "gGradientButton";
            gGradientButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gGradientButton.Size = new Size(300, 30);
            gGradientButton.TabIndex = 0;
            gGradientButton.Text = "Thesis topic";
            gGradientButton.TextAlign = HorizontalAlignment.Left;
            gGradientButton.TextOffset = new Point(10, 0);
            gGradientButton.Click += gGradientButton_Click;
            // 
            // UCTopicMiniLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gGradientButton);
            Name = "UCTopicMiniLine";
            Size = new Size(300, 30);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton gGradientButton;
    }
}

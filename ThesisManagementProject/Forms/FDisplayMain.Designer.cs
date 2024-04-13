namespace ThesisManagementProject
{
    partial class FDisplayMain
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDisplayMain));
            gPanelDisplay = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // gPanelDisplay
            // 
            gPanelDisplay.CustomizableEdges = customizableEdges1;
            gPanelDisplay.Location = new Point(0, 0);
            gPanelDisplay.Name = "gPanelDisplay";
            gPanelDisplay.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gPanelDisplay.Size = new Size(1681, 853);
            gPanelDisplay.TabIndex = 0;
            // 
            // FDisplayMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1682, 853);
            Controls.Add(gPanelDisplay);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FDisplayMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thesis Management";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gPanelDisplay;
    }
}
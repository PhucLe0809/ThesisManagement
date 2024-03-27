namespace ThesisManagementProject
{
    partial class FThesisEdit
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FThesisEdit));
            gPanelEdit = new Guna.UI2.WinForms.Guna2Panel();
            gElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            SuspendLayout();
            // 
            // gPanelEdit
            // 
            gPanelEdit.CustomizableEdges = customizableEdges1;
            gPanelEdit.Location = new Point(0, 0);
            gPanelEdit.Name = "gPanelEdit";
            gPanelEdit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gPanelEdit.Size = new Size(1180, 750);
            gPanelEdit.TabIndex = 0;
            // 
            // FThesisEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1181, 752);
            Controls.Add(gPanelEdit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FThesisEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thesis Edit";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gPanelEdit;
        private Guna.UI2.WinForms.Guna2Elipse gElipse;
    }
}
namespace ThesisManagementProject.Forms
{
    partial class FMeetingDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMeetingDetails));
            flpBackground = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpBackground
            // 
            flpBackground.AutoScroll = true;
            flpBackground.Location = new Point(12, 12);
            flpBackground.Name = "flpBackground";
            flpBackground.Size = new Size(670, 530);
            flpBackground.TabIndex = 14;
            // 
            // FMeetingDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(692, 553);
            Controls.Add(flpBackground);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FMeetingDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meeting Details";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpBackground;
    }
}
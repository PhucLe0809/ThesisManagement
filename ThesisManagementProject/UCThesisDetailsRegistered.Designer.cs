namespace ThesisManagementProject
{
    partial class UCThesisDetailsRegistered
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
            lblRegisteredList = new Label();
            gSeparatorTopic = new Guna.UI2.WinForms.Guna2Separator();
            flpTeamRegistered = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblRegisteredList
            // 
            lblRegisteredList.AutoSize = true;
            lblRegisteredList.BackColor = Color.Transparent;
            lblRegisteredList.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegisteredList.Location = new Point(25, 30);
            lblRegisteredList.Name = "lblRegisteredList";
            lblRegisteredList.Size = new Size(193, 28);
            lblRegisteredList.TabIndex = 9;
            lblRegisteredList.Text = "REGISTERED LIST";
            // 
            // gSeparatorTopic
            // 
            gSeparatorTopic.Location = new Point(25, 61);
            gSeparatorTopic.Name = "gSeparatorTopic";
            gSeparatorTopic.Size = new Size(555, 12);
            gSeparatorTopic.TabIndex = 51;
            // 
            // flpTeamRegistered
            // 
            flpTeamRegistered.AutoScroll = true;
            flpTeamRegistered.Location = new Point(25, 79);
            flpTeamRegistered.Name = "flpTeamRegistered";
            flpTeamRegistered.Size = new Size(555, 395);
            flpTeamRegistered.TabIndex = 52;
            // 
            // UCThesisSolveRegistered
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpTeamRegistered);
            Controls.Add(gSeparatorTopic);
            Controls.Add(lblRegisteredList);
            Name = "UCThesisSolveRegistered";
            Size = new Size(608, 635);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegisteredList;
        private Guna.UI2.WinForms.Guna2Separator gSeparatorTopic;
        private FlowLayoutPanel flpTeamRegistered;
    }
}

namespace ThesisManagementProject
{
    partial class UCStudentItemAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCStudentItemAdd));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gCirclePictureBoxDelete = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblGender = new Label();
            lblUserName = new Label();
            gCirclePictureBoxAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxDelete).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // gCirclePictureBoxDelete
            // 
            gCirclePictureBoxDelete.BackColor = Color.Transparent;
            gCirclePictureBoxDelete.FillColor = SystemColors.ButtonFace;
            gCirclePictureBoxDelete.Image = (Image)resources.GetObject("gCirclePictureBoxDelete.Image");
            gCirclePictureBoxDelete.ImageRotate = 0F;
            gCirclePictureBoxDelete.Location = new Point(214, 19);
            gCirclePictureBoxDelete.Name = "gCirclePictureBoxDelete";
            gCirclePictureBoxDelete.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxDelete.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxDelete.Size = new Size(20, 20);
            gCirclePictureBoxDelete.SizeMode = PictureBoxSizeMode.StretchImage;
            gCirclePictureBoxDelete.TabIndex = 27;
            gCirclePictureBoxDelete.TabStop = false;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(gCirclePictureBoxDelete);
            guna2ShadowPanel1.FillColor = SystemColors.ButtonFace;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowShift = 3;
            guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            guna2ShadowPanel1.Size = new Size(250, 60);
            guna2ShadowPanel1.TabIndex = 28;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = SystemColors.ButtonFace;
            lblGender.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.FromArgb(74, 97, 94);
            lblGender.Location = new Point(67, 32);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(50, 17);
            lblGender.TabIndex = 31;
            lblGender.Text = "gender";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = SystemColors.ButtonFace;
            lblUserName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(65, 8);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(92, 23);
            lblUserName.TabIndex = 30;
            lblUserName.Text = "User name";
            // 
            // gCirclePictureBoxAvatar
            // 
            gCirclePictureBoxAvatar.BackColor = SystemColors.ButtonFace;
            gCirclePictureBoxAvatar.Image = (Image)resources.GetObject("gCirclePictureBoxAvatar.Image");
            gCirclePictureBoxAvatar.ImageRotate = 0F;
            gCirclePictureBoxAvatar.Location = new Point(9, 6);
            gCirclePictureBoxAvatar.Name = "gCirclePictureBoxAvatar";
            gCirclePictureBoxAvatar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gCirclePictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxAvatar.Size = new Size(45, 45);
            gCirclePictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            gCirclePictureBoxAvatar.TabIndex = 29;
            gCirclePictureBoxAvatar.TabStop = false;
            // 
            // UCStudentItemAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblGender);
            Controls.Add(lblUserName);
            Controls.Add(gCirclePictureBoxAvatar);
            Controls.Add(guna2ShadowPanel1);
            Name = "UCStudentItemAdd";
            Size = new Size(250, 60);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxDelete).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxDelete;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Label lblGender;
        private Label lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxAvatar;
    }
}

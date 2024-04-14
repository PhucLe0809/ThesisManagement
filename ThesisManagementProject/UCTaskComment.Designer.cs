namespace ThesisManagementProject
{
    partial class UCTaskComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTaskComment));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gSeparatorUnder = new Guna.UI2.WinForms.Guna2Separator();
            gCirclePictureBoxCommentator = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            gSeparatorComment = new Guna.UI2.WinForms.Guna2Separator();
            gButtonSend = new Guna.UI2.WinForms.Guna2Button();
            gTextBoxComment = new Guna.UI2.WinForms.Guna2TextBox();
            flpComment = new FlowLayoutPanel();
            ptbEmoji = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxCommentator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbEmoji).BeginInit();
            SuspendLayout();
            // 
            // gSeparatorUnder
            // 
            gSeparatorUnder.Location = new Point(5, 379);
            gSeparatorUnder.Name = "gSeparatorUnder";
            gSeparatorUnder.Size = new Size(670, 12);
            gSeparatorUnder.TabIndex = 69;
            // 
            // gCirclePictureBoxCommentator
            // 
            gCirclePictureBoxCommentator.Image = Properties.Resources.PictureAvatarAccount;
            gCirclePictureBoxCommentator.ImageRotate = 0F;
            gCirclePictureBoxCommentator.Location = new Point(5, 402);
            gCirclePictureBoxCommentator.Name = "gCirclePictureBoxCommentator";
            gCirclePictureBoxCommentator.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCirclePictureBoxCommentator.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCirclePictureBoxCommentator.Size = new Size(40, 40);
            gCirclePictureBoxCommentator.SizeMode = PictureBoxSizeMode.Zoom;
            gCirclePictureBoxCommentator.TabIndex = 68;
            gCirclePictureBoxCommentator.TabStop = false;
            // 
            // gSeparatorComment
            // 
            gSeparatorComment.Location = new Point(5, 8);
            gSeparatorComment.Name = "gSeparatorComment";
            gSeparatorComment.Size = new Size(670, 12);
            gSeparatorComment.TabIndex = 67;
            // 
            // gButtonSend
            // 
            gButtonSend.BorderRadius = 5;
            gButtonSend.CustomizableEdges = customizableEdges2;
            gButtonSend.DisabledState.BorderColor = Color.DarkGray;
            gButtonSend.DisabledState.CustomBorderColor = Color.DarkGray;
            gButtonSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gButtonSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gButtonSend.FillColor = Color.Transparent;
            gButtonSend.Font = new Font("Segoe UI", 9F);
            gButtonSend.ForeColor = Color.White;
            gButtonSend.HoverState.FillColor = Color.White;
            gButtonSend.HoverState.Image = (Image)resources.GetObject("resource.Image");
            gButtonSend.Image = (Image)resources.GetObject("gButtonSend.Image");
            gButtonSend.ImageSize = new Size(30, 30);
            gButtonSend.Location = new Point(636, 440);
            gButtonSend.Name = "gButtonSend";
            gButtonSend.PressedColor = Color.White;
            gButtonSend.ShadowDecoration.CustomizableEdges = customizableEdges3;
            gButtonSend.Size = new Size(30, 30);
            gButtonSend.TabIndex = 65;
            gButtonSend.Click += gButtonSend_Click;
            // 
            // gTextBoxComment
            // 
            gTextBoxComment.BorderRadius = 10;
            gTextBoxComment.CustomizableEdges = customizableEdges4;
            gTextBoxComment.DefaultText = "";
            gTextBoxComment.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gTextBoxComment.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gTextBoxComment.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxComment.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gTextBoxComment.FillColor = Color.FromArgb(242, 245, 244);
            gTextBoxComment.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxComment.Font = new Font("Segoe UI", 9F);
            gTextBoxComment.ForeColor = Color.Black;
            gTextBoxComment.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gTextBoxComment.Location = new Point(51, 398);
            gTextBoxComment.Margin = new Padding(3, 4, 3, 4);
            gTextBoxComment.Multiline = true;
            gTextBoxComment.Name = "gTextBoxComment";
            gTextBoxComment.PasswordChar = '\0';
            gTextBoxComment.PlaceholderForeColor = Color.Gray;
            gTextBoxComment.PlaceholderText = "Comment here";
            gTextBoxComment.SelectedText = "";
            gTextBoxComment.ShadowDecoration.CustomizableEdges = customizableEdges5;
            gTextBoxComment.Size = new Size(579, 80);
            gTextBoxComment.TabIndex = 64;
            gTextBoxComment.KeyDown += gTextBoxComment_KeyDown;
            gTextBoxComment.KeyPress += gTextBoxComment_KeyPress;
            // 
            // flpComment
            // 
            flpComment.AutoScroll = true;
            flpComment.BackColor = Color.Transparent;
            flpComment.Location = new Point(5, 25);
            flpComment.Name = "flpComment";
            flpComment.Size = new Size(670, 348);
            flpComment.TabIndex = 63;
            // 
            // ptbEmoji
            // 
            ptbEmoji.Image = (Image)resources.GetObject("ptbEmoji.Image");
            ptbEmoji.Location = new Point(636, 404);
            ptbEmoji.Name = "ptbEmoji";
            ptbEmoji.Size = new Size(32, 32);
            ptbEmoji.SizeMode = PictureBoxSizeMode.Zoom;
            ptbEmoji.TabIndex = 70;
            ptbEmoji.TabStop = false;
            // 
            // UCTaskComment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ptbEmoji);
            Controls.Add(gSeparatorUnder);
            Controls.Add(gCirclePictureBoxCommentator);
            Controls.Add(gSeparatorComment);
            Controls.Add(gButtonSend);
            Controls.Add(gTextBoxComment);
            Controls.Add(flpComment);
            DoubleBuffered = true;
            Name = "UCTaskComment";
            Size = new Size(680, 490);
            ((System.ComponentModel.ISupportInitialize)gCirclePictureBoxCommentator).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbEmoji).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Separator gSeparatorUnder;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gCirclePictureBoxCommentator;
        private Guna.UI2.WinForms.Guna2Separator gSeparatorComment;
        private Guna.UI2.WinForms.Guna2Button gButtonSend;
        private Guna.UI2.WinForms.Guna2TextBox gTextBoxComment;
        private FlowLayoutPanel flpComment;
        private PictureBox ptbEmoji;
    }
}

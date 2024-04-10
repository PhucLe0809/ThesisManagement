using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisManagementProject.Forms
{
    public partial class FListAvatar : Form
    {
        private Image pictureAvatar;
        public FListAvatar()
        {
            InitializeComponent();
            InitAvatarList();
        }
        public Image PictureAvatar { get => pictureAvatar; }

        private void InitAvatarList()
        {
            flpAvatarList.Controls.Clear();
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarNine));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarTwo));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarSeven));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarSix));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarTen));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarFour));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarThree));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarFive));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarOne));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarEight));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarDemoUser));
        }
        private PictureBox CreateAvatarPictureBox(Image image)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(100, 100);
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.White;
            pictureBox.Click += PictureBoxAvatar_Clicked;

            return pictureBox;
        }
        private void PictureBoxAvatar_Clicked(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            this.pictureAvatar = pictureBox.Image;
            this.Close();
        }
    }
}

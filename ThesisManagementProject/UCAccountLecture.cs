using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Properties;

namespace ThesisManagementProject
{
    public partial class UCAccountLecture : UserControl
    {
        public UCAccountLecture()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                flpTheses.Controls.Add(new UCThesisMiniLine());
            }
        }

        private void gGradientButtonEdit_Click(object sender, EventArgs e)
        {
            gPanelEditInfor.Enabled = true;
        }

        private void gCirclePictureBoxAvatar_MouseEnter(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureCameraHover;
        }

        private void gCirclePictureBoxAvatar_MouseLeave(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureAvatarAccount;
        }
    }
}

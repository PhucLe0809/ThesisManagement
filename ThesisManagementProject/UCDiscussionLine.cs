using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisManagementProject
{
    public partial class UCDiscussionLine : UserControl
    {
        public UCDiscussionLine()
        {
            InitializeComponent();
        }

        private void SetItemColor(Color color)
        {
            gShadowPanelBack.FillColor = color;
            gCirclePictureBoxAvatar.BackColor = color;
            gButtonCopy.BackColor = color;
            gTextBoxNewMessage.BackColor = color;
            lblDecussionTopic.BackColor = color;
            lblThesisCode.BackColor = color;
            lblTimeAgo.BackColor = color;
        }

        private void gShadowPanelBack_MouseEnter(object sender, EventArgs e)
        {
            SetItemColor(Color.Gainsboro);
        }

        private void gShadowPanelBack_MouseLeave(object sender, EventArgs e)
        {
            SetItemColor(Color.White);
        }
    }
}

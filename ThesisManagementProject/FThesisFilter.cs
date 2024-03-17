using Guna.UI2.WinForms;
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
    public partial class FThesisFilter : Form
    {

        int cntPending = 0;
        int cntAccepted = 0;
        int cntCompleted = 0;
        int cntTopic = 0;
        int cntCreation = 0;

        public FThesisFilter()
        {
            InitializeComponent();
        }

        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gGradientButtonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTextBoxEnable(List<Control> list, bool flag)
        {
            foreach (Control control in list)
            {
                control.Enabled = flag;
            }
        }

        private void ScanTextBoxOffOn(List<Control> list, ref int cnt, Guna2Button button, List<PictureBox> pictures)
        {
            cnt++;

            if (cnt % 2 != 0)
            {
                SetTextBoxEnable(list, true);

                button.Image = Properties.Resources.PicItemOff;
                foreach (PictureBox picture in pictures)
                {
                    picture.BackColor = Color.White;
                }
            }
            else
            {
                SetTextBoxEnable(list, false);

                button.Image = Properties.Resources.PicItemOn;
                foreach (PictureBox picture in pictures)
                {
                    picture.BackColor = SystemColors.ControlLight;
                }
            }
        }

        private void gButtonPendingAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { gTextBoxPendingFrom, gTextBoxPendingTo },
                ref cntPending, gButtonPendingAll, new List<PictureBox> { });
        }

        private void gButtonAcceptedAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { gTextBoxAcceptedFrom, gTextBoxAcceptedTo },
                ref cntAccepted, gButtonAcceptedAll, new List<PictureBox> { });
        }

        private void gButtonCompletedAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { gTextBoxCompletedFrom, gTextBoxCompletedTo },
                ref cntCompleted, gButtonCompletedAll, new List<PictureBox> { });
        }

        private void gButtonTopicSelectAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { pnlTopic },
                ref cntTopic, gButtonTopicSelectAll, new List<PictureBox> { gPictureBoxFaculty, gPictureBoxLevel});
        }

        private void gButtonCreationSelectAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { pnlCreation },
                ref cntCreation, gButtonCreationSelectAll, new List<PictureBox> { });
        }
    }
}

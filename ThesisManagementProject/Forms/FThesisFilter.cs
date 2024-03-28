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

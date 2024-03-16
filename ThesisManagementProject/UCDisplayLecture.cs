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
    public partial class UCDisplayLecture : UserControl
    {
        UCWelcome uCWelcome = new UCWelcome();
        UCTopic uCTopic = new UCTopic();
        UCDashboardLecture uCDashboards = new UCDashboardLecture();
        UCStudents uCStudents = new UCStudents();
        UCDiscussion uCDiscussion = new UCDiscussion();
        UCAccountLecture uCAccount = new UCAccountLecture();

        public UCDisplayLecture()
        {
            InitializeComponent();

            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCWelcome);
        }

        public Guna2Button GButtonLogOut
        {
            get { return this.gButtonLogOut; }
        }

        private void DirectButtonStandardColor(Guna2Button button)
        {
            button.FillColor = Color.Transparent;
            button.ForeColor = Color.White;
            button.Font = new System.Drawing.Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void DirectButtonSettingColor(Guna2Button button)
        {
            button.FillColor = Color.White;
            button.ForeColor = Color.Black;
            button.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, FontStyle.Bold);
        }

        private void AllDirectButtonStandardColor()
        {
            DirectButtonStandardColor(gButtonTopic);
            DirectButtonStandardColor(gButtonDashboards);
            DirectButtonStandardColor(gButtonDiscussions);
            DirectButtonStandardColor(gButtonAccount);
            DirectButtonStandardColor(gButtonStudents);

            gButtonTopic.CustomImages.Image = Properties.Resources.PictureThesis;
            gButtonDashboards.CustomImages.Image = Properties.Resources.PictureTask;
            gButtonDiscussions.CustomImages.Image = Properties.Resources.PictureDiscussion;
            gButtonAccount.CustomImages.Image = Properties.Resources.PictureAccount;
            gButtonStudents.CustomImages.Image = Properties.Resources.PictureStudent;
        }

        private void gPanelBackAvatar_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCWelcome);
        }

        private void gButtonTopic_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            DirectButtonSettingColor(gButtonTopic);
            gButtonTopic.CustomImages.Image = Properties.Resources.PictureThesisGradient;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCTopic);
        }

        private void gButtonDashboard_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            DirectButtonSettingColor(gButtonDashboards);
            gButtonDashboards.CustomImages.Image = Properties.Resources.PictureTaskGradient;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCDashboards);
        }

        private void gButtonStudents_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            DirectButtonSettingColor(gButtonStudents);
            gButtonStudents.CustomImages.Image = Properties.Resources.PictureStudentGradient;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCStudents);
        }

        private void gButtonDiscuss_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            DirectButtonSettingColor(gButtonDiscussions);
            gButtonDiscussions.CustomImages.Image = Properties.Resources.PictureDiscussionGradient;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCDiscussion);
        }

        private void gButtonAccount_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            DirectButtonSettingColor(gButtonAccount);
            gButtonAccount.CustomImages.Image = Properties.Resources.PictureAccountGradient;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(uCAccount);
        }
    }
}

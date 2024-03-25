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
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCDisplayStudent : UserControl
    {
        private People people = new People();

        UCDashboardLecture uCDashboardLecture = new UCDashboardLecture();
        UCStudents uCStudents = new UCStudents();
        UCDiscussion uCDiscussion = new UCDiscussion();
        UCAccount uCAccountLecture = new UCAccount();

        public UCDisplayStudent()
        {
            InitializeComponent();

            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome());
        }
        public UCDisplayStudent(People people)
        {
            InitializeComponent();

            SetInformation(people);
        }

        #region PROPERTIES

        public Guna2Button GButtonLogOut
        {
            get { return this.gButtonLogOut; }
        }

        #endregion

        #region FUNCTIONS FORM

        public void SetInformation(People people)
        {
            this.people = people;
            UserControlLoad();
        }
        private void UserControlLoad()
        {
            gCirclePictureBoxAvatar.Image = MyProcess.NameToImage(people.AvatarName);
            lblHandle.Text = people.Handle;
            lblRole.Text = people.Role.ToString();

            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome(people));
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
            DirectButtonStandardColor(gButtonDashboards);
            DirectButtonStandardColor(gButtonDiscussions);
            DirectButtonStandardColor(gButtonAccount);
            DirectButtonStandardColor(gButtonStudents);

            gButtonDashboards.CustomImages.Image = Properties.Resources.PictureTask;
            gButtonDiscussions.CustomImages.Image = Properties.Resources.PictureDiscussion;
            gButtonAccount.CustomImages.Image = Properties.Resources.PictureAccount;
            gButtonStudents.CustomImages.Image = Properties.Resources.PictureStudent;
        }
        private void SetButtonClick(Guna2Button button, Image image, UserControl userControl)
        {
            AllDirectButtonStandardColor();
            DirectButtonSettingColor(button);
            button.CustomImages.Image = image;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(userControl);
        }

        #endregion

        #region CONTROL CLICK

        private void gPanelBackAvatar_Click(object sender, EventArgs e)
        {
            AllDirectButtonStandardColor();
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome(this.people));
        }
        private void gButtonDashboard_Click(object sender, EventArgs e)
        {
            SetButtonClick(gButtonDashboards, Properties.Resources.PictureTaskGradient, uCDashboardLecture);
        }
        private void gButtonStudents_Click(object sender, EventArgs e)
        {
            SetButtonClick(gButtonStudents, Properties.Resources.PictureStudentGradient, uCStudents);
        }
        private void gButtonDiscuss_Click(object sender, EventArgs e)
        {
            SetButtonClick(gButtonDiscussions, Properties.Resources.PictureDiscussionGradient, uCDiscussion);
        }
        private void gButtonAccount_Click(object sender, EventArgs e)
        {
            uCAccountLecture.SetInformation(people);
            SetButtonClick(gButtonAccount, Properties.Resources.PictureAccountGradient, uCAccountLecture);
        }

        #endregion

    }
}

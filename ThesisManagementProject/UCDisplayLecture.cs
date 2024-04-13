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
    public partial class UCDisplayLecture : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();

        private UCDashboard uCDashboard = new UCDashboard();
        private UCNotification uCNotification = new UCNotification();
        private UCAccount uCAccount = new UCAccount();

        private List<Guna2Button> listButton = new List<Guna2Button>();
        private List<Image> listImage = new List<Image>();

        public UCDisplayLecture()
        {
            InitializeComponent();

            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome());
            this.listButton = new List<Guna2Button> { gButtonDashboards, gButtonNotification, gButtonAccount };
            this.listImage = new List<Image> { Properties.Resources.PictureTask, Properties.Resources.PictureNotification, Properties.Resources.PictureAccount };
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
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(people.AvatarName);
            lblHandle.Text = people.Handle;
            lblRole.Text = people.Role.ToString();

            myProcess.AllButtonStandardColor(this.listButton, this.listImage);

            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome(people));
        }
        private void SetButtonClick(Guna2Button button, Image image, UserControl userControl)
        {
            myProcess.AllButtonStandardColor(this.listButton, this.listImage);
            myProcess.ButtonSettingColor(button);
            button.CustomImages.Image = image;
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(userControl);
        }

        #endregion

        #region CONTROLS CLICK

        private void gPanelBackAvatar_Click(object sender, EventArgs e)
        {
            myProcess.AllButtonStandardColor(this.listButton, this.listImage);
            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome(this.people));
        }
        private void gButtonDashboard_Click(object sender, EventArgs e)
        {
            uCDashboard.SetInformation(this.people);
            SetButtonClick(gButtonDashboards, Properties.Resources.PictureTaskGradient, uCDashboard);
        }
        private void gButtonNotification_Click(object sender, EventArgs e)
        {
            uCNotification.SetInformation(people);
            SetButtonClick(gButtonNotification, Properties.Resources.PictureNotificationGradient, uCNotification);
        }
        private void gButtonAccount_Click(object sender, EventArgs e)
        {
            uCAccount.SetInformation(people);
            SetButtonClick(gButtonAccount, Properties.Resources.PictureAccountGradient, uCAccount);
        }

        #endregion

    }
}

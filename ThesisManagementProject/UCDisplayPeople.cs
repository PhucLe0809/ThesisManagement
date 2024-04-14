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
    public partial class UCDisplayPeople : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();

        private UCDashboard uCDashboard = new UCDashboard();
        private UCDashboard uCMyTheses = new UCDashboard();
        private UCNotification uCNotification = new UCNotification();
        private UCAccount uCAccount = new UCAccount();

        private List<Guna2Button> listButton = new List<Guna2Button>();
        private List<Image> listImage = new List<Image>();

        public UCDisplayPeople()
        {
            InitializeComponent();

            pnlAddUserControl.Controls.Clear();
            pnlAddUserControl.Controls.Add(new UCWelcome());
            uCMyTheses.FlagStuMyTheses = true;
            this.listButton = new List<Guna2Button> { gButtonDashboards, gButtonMyTheses, gButtonNotification, gButtonAccount };
            this.listImage = new List<Image> { Properties.Resources.PictureTask, Properties.Resources.PictureThesis,
                                                Properties.Resources.PictureNotification, Properties.Resources.PictureAccount };
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
            SetButtonBar();

            uCNotification.NotificationJump += NotificationType_Jump;
        }
        private void SetButtonBar()
        {
            if (people.Role == ERole.Lecture)
            {
                gButtonMyTheses.Hide();
                gButtonNotification.Location = new Point(22, 234);
                gButtonAccount.Location = new Point(22, 296);
            }
            else
            {
                gButtonMyTheses.Show();
                gButtonNotification.Location = new Point(22, 296);
                gButtonAccount.Location = new Point(22, 358);
            }
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
        private void gButtonMyTheses_Click(object sender, EventArgs e)
        {
            uCMyTheses.SetInformation(this.people);
            SetButtonClick(gButtonMyTheses, Properties.Resources.PictureThesisGradient, uCMyTheses);
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

        #region METHOD NOTIFICATION JUMP

        private void NotificationType_Jump(object sender, EventArgs e)
        {
            Notification notification = sender as Notification;
            if (notification != null)
            {
                if (people.Role == ERole.Lecture)
                {
                    gButtonDashboards.PerformClick();
                    uCDashboard.NotificationJump(notification);
                }
                else
                {
                    gButtonMyTheses.PerformClick();
                    uCMyTheses.NotificationJump(notification);
                }
            }
        }

        #endregion

    }
}

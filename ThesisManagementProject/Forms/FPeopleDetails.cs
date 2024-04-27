using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class FPeopleDetails : Form
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();

        private UCStatisticalStudent uCStatisticalStudent = new UCStatisticalStudent();
        private UCStatisticalLecture uCstatisticalLecture = new UCStatisticalLecture();

        public FPeopleDetails(People people)
        {
            InitializeComponent();
            SetInformation(people);
        }
        public void SetInformation(People people)
        {
            this.people = people;
            InitUserControl();
        }

        #region FUNTIONS

        private void InitUserControl()
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(people.AvatarName);
            lblViewHandle.Text = people.Handle;
            lblViewRole.Text = people.Role.ToString();

            Action setupRole = (this.people.Role == ERole.Lecture) ? new Action(SetupLectureRole) : new Action(SetupStudentRole);
            setupRole();

            gTextBoxFullname.Text = people.FullName;
            gTextBoxCitizencode.Text = people.CitizenCode;
            gTextBoxBirthday.Text = people.Birthday.ToString("dd/MM/yyyy");   
            gTextBoxGender.Text = people.Gender.ToString();
            gTextBoxEmail.Text = people.Email;
            gTextBoxPhonenumber.Text = people.PhoneNumber;

            gTextBoxIDAccount.Text = people.IdAccount.ToString();
            gTextBoxUniversity.Text = people.University;
            gTextBoxFaculty.Text = people.Faculty;
            gTextBoxWorkcode.Text = people.WorkCode;
        }
        public void SetupLectureRole()
        {
            this.pnlShowStatistical.Controls.Clear();
            this.uCstatisticalLecture.SetInformation(this.people);
            this.pnlShowStatistical.Controls.Add(uCstatisticalLecture);

            this.gShadowPanelContribution.Controls.Clear();
            Guna2PictureBox gPictureBoxState = myProcess.CreatePictureBox(Properties.Resources.GifPrivate, new Size(300, 300));
            this.gShadowPanelContribution.Controls.Add(gPictureBoxState);

        }
        public void SetupStudentRole()
        {
            this.pnlShowStatistical.Controls.Clear();
            this.uCStatisticalStudent.SetInformation(this.people);
            this.pnlShowStatistical.Controls.Add(uCStatisticalStudent);

            this.gCircleProgressBar.Value = Convert.ToInt32(this.uCStatisticalStudent.AvgContribute);
        }

        #endregion
    }
}

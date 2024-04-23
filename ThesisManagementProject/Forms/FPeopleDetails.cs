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
        private List<Thesis> listThesis = new List<Thesis>();

        private ThesisDAO thesisDAO = new ThesisDAO();
        private ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
        private TasksDAO tasksDAO = new TasksDAO();

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
        private void InitUserControl()
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(people.AvatarName);
            lblViewHandle.Text = people.Handle;
            lblViewRole.Text = people.Role.ToString();

            Action setupRole = (this.people.Role == ERole.Lecture) ? new Action(SetupLectureRole) : new Action(SetupStudentRole);
            setupRole();

            lblNumThesis.Text = this.listThesis.Count().ToString();

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
            Guna2PictureBox gPictureBoxState1 = myProcess.CreatePictureBox(Properties.Resources.GifPrivate, new Size(162, 162));
            gPictureBoxState1.Location = new Point(55, 23);

            this.gPanelTotalProcess.Controls.Remove(this.gCircleProgressBar);
            this.gPanelTotalProcess.Controls.Add(gPictureBoxState1);
            this.lblTotalProgress.Text = "Private Information!";
            this.lblTotalProgress.ForeColor = Color.FromArgb(0, 192, 192);

            int containerWidth = this.gPanelTotalProcess.Width;
            int labelWidth = this.lblTotalProgress.Width;
            int horizontalPosition = (containerWidth - labelWidth) / 2;
            this.lblTotalProgress.Location = new Point(horizontalPosition, this.lblTotalProgress.Location.Y);

            this.gShadowPanelShowInfor.Controls.Clear();

            Guna2PictureBox gPictureBoxState2 = myProcess.CreatePictureBox(Properties.Resources.GifPrivate, new Size(250, 250)); ;
            gPictureBoxState2.Location = new Point(292, 62);

            this.gShadowPanelShowInfor.Controls.Add(gPictureBoxState2);
        }
        public void SetupStudentRole()
        {
            this.listThesis = thesisDAO.SelectListModeMyCompletedTheses(people.IdAccount);

            double avgContribute = 0;

            List<Tasks> listTasks;
            string idTeam;
            foreach(Thesis thesis in this.listThesis)
            {
                idTeam = thesisStatusDAO.SelectTeamByIdThesis(thesis.IdThesis);
                listTasks = tasksDAO.SelectListByTeam(idTeam);

                double score = myProcess.CalEvaluations(listTasks, 1, evaluation => evaluation.Scores)[0];
                double contibutute = myProcess.CalEvaluations(listTasks, 1, evaluation => evaluation.Contribute)[0];

                avgContribute += contibutute;

                this.gLineDataset.DataPoints.Add(thesis.IdThesis, score);
            }
            
            this.gChart.Datasets.Add(this.gLineDataset);
            this.gChart.Update();

            this.gCircleProgressBar.Value = (int)avgContribute;
        }
    }
}

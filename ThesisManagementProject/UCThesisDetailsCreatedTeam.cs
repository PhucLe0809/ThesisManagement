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
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCThesisDetailsCreatedTeam : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        public event EventHandler RegisteredPerform;

        private People people = new People();
        private Thesis thesis = new Thesis();
        private List<People> listPeople = new List<People>();
        private List<People> members = new List<People>();

        private PeopleDAO peopleDAO = new PeopleDAO();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private Image pictureAvatar;
        private bool flagCheck = false;

        #region CONTRUCTERS

        public UCThesisDetailsCreatedTeam()
        {
            InitializeComponent();
            InitUserControl();
        }
        public UCThesisDetailsCreatedTeam(People people, Thesis thesis)
        {
            InitializeComponent();
            this.people = people;
            this.thesis = thesis;
            InitUserControl();
            AddMember(this.people);
        }

        #endregion

        #region PROPERTIES

        public Guna2GradientButton GPerform
        {
            get { return this.gGradientButtonPerform; }
        }

        #endregion

        #region FUNCTIONS

        private void InitUserControl()
        {
            pictureAvatar = Properties.Resources.PicAvatarDemoUser;
            if(CheckCanRegister())
            {
                gGradientButtonRegister.Enabled = true;
                flpSearch.Location = new Point(11, 14);
                flpSearch.Hide();
                gGradientButtonPerform.Hide();
            }
            else
            {
                gGradientButtonRegister.Enabled = false;
            }
        }
        private void AddMember(People people)
        {
            if (members.Count < this.thesis.MaxMembers)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine(people);
                line.SetBackGroundColor(Color.White);
                line.SetSize(new Size(310, 60));
                if (people.IdAccount == this.people.IdAccount)
                {
                    line.SetDeleteMode(false);
                }
                else
                {
                    line.SetButtonDelete();
                    line.ButtonDeleteClicked += (sender, e) => ButtonDelete_Clicked(sender, e, line);
                }
                flpTeam.Controls.Add(line);
                members.Add(people);
            }
            else
            {
                MessageBox.Show("The number of members cannot be exceeded " + this.thesis.MaxMembers,
                                                    "OK", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void LoadPeopleList()
        {
            flpSearch.Controls.Clear();
            int maxLine = 4;
            foreach (People people in members)
            {
                People foundPeople = listPeople.Find(p => p.IdAccount == people.IdAccount);
                if (foundPeople != null)
                {
                    listPeople.Remove(foundPeople);
                }
            }
            int size = Math.Min(maxLine, listPeople.Count);
            for (int i = 0; i < size; i++)
            {
                People people = listPeople[i];
                UCPeopleMiniLine uCPeopleMiniLine = new UCPeopleMiniLine(people);
                uCPeopleMiniLine.SetSize(new Size(310, 60));
                uCPeopleMiniLine.ButtonAddClicked += (sender, e) => ButtonAdd_Clicked(sender, e, people);
                flpSearch.Controls.Add(uCPeopleMiniLine);
            }
            flpSearch.Show();
            flpSearch.BringToFront();
        }
        public bool CheckEmpty(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
        #endregion

        #region PEOPLE MINI LINE

        private void ButtonAdd_Clicked(object sender, EventArgs e, People people)
        {
            AddMember(people);
            gTextBoxSearch.Text = string.Empty;
        }
        private void ButtonDelete_Clicked(object sender, EventArgs e, UCPeopleMiniLine people)
        {
            if (people.GetPeople.IdAccount != this.people.IdAccount)
            {
                members.Remove(people.GetPeople);
                flpTeam.Controls.Remove(people);
            }
            else
            {
                MessageBox.Show("Cannot delete yourself", "OK", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region FUNCTIONS SEARCH

        private void gTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = sender as Guna2TextBox;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                this.listPeople = peopleDAO.SelectListByUserName(textBox.Text, people.Role);
                flpTeam.Hide();
                LoadPeopleList();
            }
            else
            {
                flpSearch.Controls.Clear();
                flpSearch.Hide();
                flpTeam.Show();
                flpTeam.BringToFront();
                listPeople = new List<People>();
            }
        }

        #endregion

        #region EVENT gGradientButtonRegister
        bool CheckCanRegister()
        {
            List<Thesis> listThesesNotCompleted = thesisDAO.SelectListModeNotCompleted(this.people.IdAccount);
            return listThesesNotCompleted.Count < 3;
        }
        private void gGradientButtonApply_Click(object sender, EventArgs e)
        {
            if (CheckEmpty(gTextBoxTeamName.Text))
            {
                this.thesis.Status = EThesisStatus.Registered;

                thesisDAO.UpdateStatus(this.thesis, EThesisStatus.Registered);
                Team team = new Team(gTextBoxTeamName.Text, myProcess.ImageToName(pictureAvatar), members);
                thesisStatusDAO.Insert(this.thesis, team);
                teamDAO.Insert(team);

                string content = Notification.GetContentTypeRegistered(team.TeamName, thesis.Topic);
                notificationDAO.Insert(new Notification(thesis.IdInstructor, people.IdAccount, thesis.IdThesis, thesis.IdThesis, content, DateTime.Now, false, false));

                string message = Notification.GetContentRegisteredMembers(people.FullName, team.TeamName, thesis.Topic);
                notificationDAO.InsertFollowListPeople(people.IdAccount, thesis.IdThesis, thesis.IdThesis, message, team.Members);

                MessageBox.Show("Registered successfuly", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.gGradientButtonRegister.Enabled = false;
                gGradientButtonPerform.PerformClick();
            } 
            else
            {
                gTextBoxTeamName_TextChanged(gTextBoxTeamName, new EventArgs());
            }
        }

        #endregion

        #region EVENT gCirclePictureBoxAvatar

        private void gCirclePictureBoxAvatar_MouseEnter(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureCameraHover;
        }

        private void gCirclePictureBoxAvatar_MouseLeave(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = this.pictureAvatar;
        }

        private void gCirclePictureBoxAvatar_Click(object sender, EventArgs e)
        {
            FListAvatar fListAvatar = new FListAvatar();
            fListAvatar.FormClosed += FListAvatar_FormClosed;
            fListAvatar.ShowDialog();
        }
        private void FListAvatar_FormClosed(object sender, FormClosedEventArgs e)
        {
            FListAvatar fListAvatar = (FListAvatar)sender;
            this.pictureAvatar = fListAvatar.PictureAvatar;
            gCirclePictureBoxAvatar.Image = this.pictureAvatar;
        }

        #endregion

        #region EVENT gTextBoxTeamName

        private void gTextBoxTeamName_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            myProcess.RunCheckDataValid(CheckEmpty(textBox.Text) || flagCheck, erpTeamName, gTextBoxTeamName, "Name can not empty");
        }

        #endregion

        #region EVENT gGradientButtonPerform

        private void gGradientButtonPerform_Click(object sender, EventArgs e)
        {
            OnRegisterClicked(EventArgs.Empty);
        }
        public virtual void OnRegisterClicked(EventArgs e)
        {
            RegisteredPerform?.Invoke(this, e);
        }

        #endregion

    }
}

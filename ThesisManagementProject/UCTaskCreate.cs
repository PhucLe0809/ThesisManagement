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
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCTaskCreate : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        public event EventHandler TasksCreateClicked;

        private People creator = new People();
        private People instructor = new People();
        private Tasks tasks = new Tasks();
        private Team team = new Team();
        private Thesis thesis = new Thesis();

        private TasksDAO tasksDAO = new TasksDAO();
        private EvaluationDAO evaluationDAO = new EvaluationDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private bool flagCheck = false;

        public UCTaskCreate()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public Guna2Button GButtonCancel
        {
            get { return this.gButtonCancel; }
        }
        public Tasks GetTasks
        {
            get { return this.tasks; }
        }

        #endregion

        #region FUNCTIONS

        public void SetUpUserControl(People creator, People instructor, Team team, Thesis thesis)
        {
            this.creator = creator;
            this.instructor = instructor;
            this.team = team;
            this.thesis = thesis;
            InitUserControl();
        }
        private void InitUserControl()
        {
            gTextBoxTitle.Text = string.Empty;
            gTextBoxDescription.Text = string.Empty;
        }
        private bool CheckInformationValid()
        {
            myProcess.RunCheckDataValid(tasks.CheckTitle() || flagCheck, erpTitle, gTextBoxTitle, "Title cannot be empty");
            myProcess.RunCheckDataValid(tasks.CheckDescription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");

            return tasks.CheckTitle() && tasks.CheckDescription();
        }

        #endregion

        #region EVENT gButtonCreate

        private void gButtonCreate_Click(object sender, EventArgs e)
        {
            this.flagCheck = false;
            if (CheckInformationValid())
            {
                this.tasks = new Tasks(gTextBoxTitle.Text, gTextBoxDescription.Text,
                                        this.creator.IdAccount, this.team.IdTeam, false, 0, DateTime.Now);
                tasksDAO.Insert(tasks);
                evaluationDAO.InsertFollowTeam(tasks.IdTask, team);

                List<People> peoples = team.Members.ToList();
                peoples.Add(this.instructor);
                string content = Notification.GetContentTypeTask(creator.FullName, tasks.Title, thesis.Topic);
                notificationDAO.InsertFollowListPeople(creator.IdAccount, thesis.IdThesis, tasks.IdTask, content, peoples);

                this.flagCheck = true;
                InitUserControl();
                OnTasksCreateClicked(EventArgs.Empty);
            }
        }
        private void OnTasksCreateClicked(EventArgs e)
        { 
            TasksCreateClicked?.Invoke(this, e);
        }

        #endregion

        #region EVENT TEXTCHANGED

        private void gTextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            this.tasks.Title = gTextBoxTitle.Text;
            myProcess.RunCheckDataValid(tasks.CheckTitle() || flagCheck, erpTitle, gTextBoxTitle, "Title cannot be empty");
        }
        private void gTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            this.tasks.Description = gTextBoxDescription.Text;
            myProcess.RunCheckDataValid(tasks.CheckDescription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
        }

        #endregion

    }
}

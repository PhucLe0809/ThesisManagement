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
    public partial class UCTaskMiniLine : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        public event EventHandler TasksDeleteClicked;

        private People creator = new People();
        private People instructor = new People();
        private Thesis thesis = new Thesis();
        private Tasks tasks = new Tasks();
        private Team team = new Team();
        private People host = new People();

        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private TasksDAO tasksDAO = new TasksDAO();

        private bool isProcessing = false;

        public UCTaskMiniLine(People host, People instructor, Thesis thesis, Tasks tasks, bool isProcessing)
        {
            InitializeComponent();
            this.host = host;
            this.instructor = instructor;
            this.thesis = thesis;
            this.tasks = tasks;
            this.isProcessing = isProcessing;
            InitUserControl();
        }
        public Tasks GetTask
        {
            get { return this.tasks; }
        }
        private void InitUserControl()
        {
            creator = peopleDAO.SelectOnlyByID(tasks.IdCreator);
            team = teamDAO.SelectOnly(tasks.IdTeam);

            lblTaskTitle.Text = myProcess.FormatStringLength(tasks.Title, 60);
            lblCreator.Text = creator.FullName;
            gProgressBarToLine.Value = tasks.Progress;
            myProcess.SetItemFavorite(gButtonStar, tasks.IsFavorite);

            if (!isProcessing || (host.Role == ERole.Student && tasks.IdCreator != host.IdAccount))
            {
                gButtonDelete.Hide();
                lblTaskTitle.Text = myProcess.FormatStringLength(tasks.Title, 53);
            }
        }
        private void TaskDetailsShow(Notification notification, bool flag)
        {
            FTaskDetails fTaskDetails = new FTaskDetails(host, instructor, thesis, tasks, creator, team, isProcessing);
            if (flag) fTaskDetails.PerformNotificationClick(notification);
            fTaskDetails.FormClosed += FTaskDetails_FormClosed;
            fTaskDetails.ShowDialog();
        }
        public void PerformNotificationClick(Notification notification)
        {
            TaskDetailsShow(notification, true);
        }
        private void gShadowPanelTeam_Click(object sender, EventArgs e)
        {
            TaskDetailsShow(new Notification(), false);
        }
        private void FTaskDetails_FormClosed(object? sender, FormClosedEventArgs e)
        {
            FTaskDetails fTaskDetails = sender as FTaskDetails;

            if (fTaskDetails != null)
            {
                if (fTaskDetails.Edited)
                {
                    this.tasks = tasksDAO.SelectOnly(tasks.IdTask);
                    InitUserControl();
                }
            }
        }
        private void gButtonStar_Click(object sender, EventArgs e)
        {
            tasks.IsFavorite = !tasks.IsFavorite;

            myProcess.SetItemFavorite(gButtonStar, tasks.IsFavorite);
            tasksDAO.UpdateIsFavorite(tasks);
        }
        private void gButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete " + tasks.IdTask,
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                tasksDAO.Delete(tasks);
                OnTasksDeleteClicked(EventArgs.Empty);
            }
        }
        private void OnTasksDeleteClicked(EventArgs e)
        {
            TasksDeleteClicked?.Invoke(this, e);
        }
    }
}

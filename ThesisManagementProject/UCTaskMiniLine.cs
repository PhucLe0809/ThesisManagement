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
using ThesisManagementProject.Database;
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
        private Team team = new Team();
        private Tasks tasks = new Tasks();
        private People people = new People();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private TasksDAO tasksDAO = new TasksDAO();
        private bool isProcessing = false;

        public UCTaskMiniLine(People people, Tasks tasks, bool isProcessing)
        {
            InitializeComponent();
            this.people = people;
            this.tasks = tasks;
            this.isProcessing = isProcessing;
            InitUserControl();
        }
        private void InitUserControl()
        {
            creator = peopleDAO.SelectOnlyByID(tasks.IdCreator);
            team = teamDAO.SelectOnly(tasks.IdTeam);

            lblTaskTitle.Text = myProcess.FormatStringLength(tasks.Title, 45);
            lblCreator.Text = creator.FullName;
            gProgressBarToLine.Value = tasks.Progress;
            myProcess.SetItemFavorite(gButtonStar, tasks.IsFavorite);

            if (!isProcessing || (people.Role == ERole.Student && tasks.IdCreator != people.IdAccount))
            {
                gButtonDelete.Hide();
                lblTaskTitle.Text = myProcess.FormatStringLength(tasks.Title, 53);
            }
        }
        private void gShadowPanelTeam_Click(object sender, EventArgs e)
        {
            FTaskDetails fTaskDetails = new FTaskDetails(people, tasks, creator, team, isProcessing);
            fTaskDetails.FormClosed += FTaskDetails_FormClosed;
            fTaskDetails.ShowDialog();
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
            tasksDAO.SQLExecuteByCommand(string.Format("Update " + MyDatabase.DBTask + " Set isfavorite = {0} Where idtask = '{1}'",
                                    (tasks.IsFavorite) ? (1) : (0), tasks.IdTask));
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
        public virtual void OnTasksDeleteClicked(EventArgs e)
        {
            TasksDeleteClicked?.Invoke(this, e);
        }
    }
}

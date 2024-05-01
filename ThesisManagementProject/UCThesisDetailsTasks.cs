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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCThesisDetailsTasks : UserControl
    {
        private People people = new People();
        private People instructor = new People();
        private Team team = new Team();
        private Thesis thesis = new Thesis();
        private List<Tasks> listTask = new List<Tasks>();

        private TasksDAO taskDAO = new TasksDAO();
        private UCTaskCreate uCTaskCreate = new UCTaskCreate();
        private bool isProcessing = true;

        public UCThesisDetailsTasks()
        {
            InitializeComponent();
        }

        #region FUNCTIONS

        public void SetUpUserControl(People people, People instructor, Team team, Thesis thesis, bool isProcessing)
        {
            this.people = people;
            this.instructor = instructor;
            this.team = team;
            this.thesis = thesis;
            this.isProcessing = isProcessing;
            InitUserControl();
        }
        private void InitUserControl()
        {
            flpTaskList.Location = new Point(12, 12);
            uCTaskCreate.SetUpUserControl(people, instructor, team, thesis);
            uCTaskCreate.Location = new Point(12, 12);
            uCTaskCreate.GButtonCancel.Click += GButtonCancel_Click;
            uCTaskCreate.TasksCreateClicked += UCTaskCreate_TasksCreateClicked;
            gShadowPanelBack.Controls.Add(uCTaskCreate);
            uCTaskCreate.Hide();

            if (!isProcessing)
            {
                gGradientButtonAddTask.Hide();
            }
            else
            {
                gGradientButtonAddTask.Show();
            }

            UpdateTaskList();
            LoadTaskList();
        }
        private void UCTaskCreate_TasksCreateClicked(object sender, EventArgs e)
        {
            Tasks tasks = taskDAO.SelectOnly(uCTaskCreate.GetTasks.IdTask);

            this.listTask.Add(tasks);
            UCTaskMiniLine line = new UCTaskMiniLine(people, instructor, thesis, tasks, isProcessing);
            line.TasksDeleteClicked += GButtonDelete_Click;
            flpTaskList.Controls.Add(line);
            flpTaskList.Controls.SetChildIndex(line, 0);
        }
        private void UpdateTaskList()
        {
            this.listTask.Clear();
            this.listTask = taskDAO.SelectListByTeam(this.team.IdTeam);
        }
        private void LoadTaskList()
        {
            flpTaskList.Controls.Clear();
            foreach (Tasks tasks in listTask)
            {
                UCTaskMiniLine line = new UCTaskMiniLine(people, instructor, thesis, tasks, isProcessing);
                line.TasksDeleteClicked += GButtonDelete_Click;
                flpTaskList.Controls.Add(line);
            }
        }
        private void GButtonDelete_Click(object sender, EventArgs e)
        {
            UCTaskMiniLine line = sender as UCTaskMiniLine;

            if (line != null)
            {
                foreach (Control control in flpTaskList.Controls)
                {
                    if (control.GetType() == typeof(UCTaskMiniLine))
                    {
                        UCTaskMiniLine taskLine = (UCTaskMiniLine)control;
                        if (taskLine == line)
                        {
                            flpTaskList.Controls.Remove(control);
                            this.listTask.Remove(line.GetTask);
                            control.Dispose();
                            break;
                        }
                    }
                }
            }
        }
        public void PerformNotificationClick(Notification notification)
        {
            Tasks tasks = new Tasks();
            switch (notification.Type)
            {
                case ENotificationType.Task:
                    tasks = taskDAO.SelectOnly(notification.IdObject);
                    break;
                case ENotificationType.Comment:
                    tasks = taskDAO.SelectFromComment(notification.IdObject);
                    break;
                case ENotificationType.Evaluation:
                    tasks = taskDAO.SelectFromEvaluation(notification.IdObject);
                    break;
            }

            foreach (UCTaskMiniLine line in flpTaskList.Controls)
            {
                if (line != null)
                {
                    if (line.GetTask.IdTask == tasks.IdTask)
                    {
                        line.PerformNotificationClick(notification);
                        return;
                    }
                }
            }            
        }

        #endregion

        #region EVENT UserControl ADDTASK and TASKCREATE

        private void gGradientButtonAddTask_Click(object sender, EventArgs e)
        {
            flpTaskList.Hide();
            uCTaskCreate.Show();
        }
        private void GButtonCancel_Click(object? sender, EventArgs e)
        {
            uCTaskCreate.Hide();
            flpTaskList.Show();
        }

        #endregion

        #region EVENT TEXTBOX SEARCH

        private void gTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.listTask = taskDAO.SearchTaskTitle(this.team.IdTeam, gTextBoxSearch.Text);
            LoadTaskList();
        }

        #endregion

    }
}

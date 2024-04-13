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
        private TasksDAO taskDAO = new TasksDAO();
        private List<Tasks> listTask = new List<Tasks>();
        private UCTaskCreate uCTaskCreate = new UCTaskCreate();
        private bool isProcessing = true;

        public UCThesisDetailsTasks()
        {
            InitializeComponent();
        }

        #region FUNCTIONS

        public void SetUpUserControl(People people, People instructor, Team team, bool isProcessing)
        {
            this.people = people;
            this.instructor = instructor;
            this.team = team;
            this.isProcessing = isProcessing;
            InitUserControl();
        }
        private void InitUserControl()
        {
            flpTaskList.Location = new Point(12, 12);
            uCTaskCreate.SetUpUserControl(people, team);
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
        private void UCTaskCreate_TasksCreateClicked(object? sender, EventArgs e)
        {
            Tasks tasks = taskDAO.SelectOnly(uCTaskCreate.GetTasks.IdTask);

            this.listTask.Add(tasks);
            UCTaskMiniLine line = new UCTaskMiniLine(people, instructor, tasks, isProcessing);
            line.TasksDeleteClicked += GButtonDelete_Click;
            flpTaskList.Controls.Add(line);
            flpTaskList.Controls.SetChildIndex(line, 0);
        }
        private void UpdateTaskList()
        {
            this.listTask.Clear();
            this.listTask = taskDAO.SelectListByTeam(this.team.IDTeam);
        }
        private void LoadTaskList()
        {
            flpTaskList.Controls.Clear();
            foreach (Tasks tasks in listTask)
            {
                UCTaskMiniLine line = new UCTaskMiniLine(people, instructor, tasks, isProcessing);
                line.TasksDeleteClicked += GButtonDelete_Click;
                flpTaskList.Controls.Add(line);
            }
        }
        public void GButtonDelete_Click(object sender, EventArgs e)
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
            this.listTask = taskDAO.SearchTaskTitle(this.team.IDTeam, gTextBoxSearch.Text);
            LoadTaskList();
        }

        #endregion

    }
}

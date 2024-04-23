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
using ThesisManagementProject.Properties;

namespace ThesisManagementProject
{
    public partial class FTeamDetails : Form
    {
        private MyProcess myProcess = new MyProcess();
        private Team team = new Team();
        private Thesis thesis = new Thesis();
        private List<Tasks> listTasks;

        private TasksDAO tasksDAO = new TasksDAO();

        public FTeamDetails(Team team, Thesis thesis)
        {
            InitializeComponent();
            SetInformation(team, thesis);
        }

        #region FUNCTIONS

        private void SetInformation(Team team, Thesis thesis)
        {
            this.team = team;
            this.thesis = thesis;
            this.listTasks = tasksDAO.SelectListByTeam(this.team.IDTeam);
            InitUserControl();
        }
        private void InitUserControl()
        {
            SetTeam(this.team);

            if (this.thesis.IdThesis == string.Empty)
            {
                gShadowPanelThesis.Controls.Clear();
                gShadowPanelThesis.Controls.Add(myProcess.CreatePictureBox(Properties.Resources.PictureEmptyState, new Size(399, 266)));
            }
            else
            {
                gShadowPanelThesis.Controls.Clear();
                UCThesisMiniBoard uCThesisMiniBoard = new UCThesisMiniBoard(thesis);
                gShadowPanelThesis.Controls.Add(uCThesisMiniBoard);
            }
            UpdateChart();
        }
        public void SetTeam(Team team)
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(team.AvatarName);
            lblViewHandle.Text = myProcess.FormatStringLength(team.TeamName, 20);
            gTextBoxTeamCode.Text = team.IDTeam;
            gTextBoxCreated.Text = team.Created.ToString("dd/MM/yyyy");
            gTextBoxTeamMemebrs.Text = team.Members.Count.ToString() + " members";

            flpMembers.Controls.Clear();
            foreach (People people in team.Members)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine(people);
                line.SetBackGroundColor(SystemColors.ButtonFace);
                line.SetSize(new Size(340, 60));
                line.GButtonAdd.Hide();
                flpMembers.Controls.Add(line);
            }
        }

        #endregion

        #region CHART
        public void UpdateChart()
        {
            this.gSplineAreaDataset.DataPoints.Clear();
            for (int i = 0; i < this.listTasks.Count; i++)
            {
                string name = "Task " + i.ToString();
                this.gSplineAreaDataset.DataPoints.Add(name, this.listTasks[i].Progress);
            }
            this.gChart.Datasets.Clear();
            this.gChart.Datasets.Add(gSplineAreaDataset);
            this.gChart.Update();
        }
        #endregion
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCThesisDetailsStatistical : UserControl
    {
        private Team team = new Team();
        private List<Tasks> listTasks = new List<Tasks>();
        private List<double> evaluationOfMembers;
        private List<double> scoreOfMembers;

        private TasksDAO tasksDAO = new TasksDAO();
        private EvaluationDAO evaluationDAO = new EvaluationDAO();
        private MyProcess myProcess = new MyProcess();

        public UCThesisDetailsStatistical()
        {
            InitializeComponent();
        }
        public void SetUpUserControl(Team team)
        {
            this.team = team;
            this.team.Members.OrderBy(member => member.IdAccount);
            this.listTasks = tasksDAO.SelectListByTeam(this.team.IDTeam);
            UpdateMembers();
            UpdateChart();
            this.gProgressBar.Value = myProcess.CalStatisticalThesis(this.listTasks);
            this.lblTotalProgress.Text = this.gProgressBar.Value.ToString() + "%";
        }

        #region MEMBER STATISTICAL
        public void UpdateMembers()
        {
            this.evaluationOfMembers = myProcess.CalEvaluations(this.listTasks, this.team.Members.Count(), evaluation => evaluation.Contribute);
            this.scoreOfMembers = myProcess.CalEvaluations(this.listTasks, this.team.Members.Count(), evaluation => evaluation.Scores);
            flpMemberStatistical.Controls.Clear();
            for (int i = 0; i < this.team.Members.Count; i++)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine(this.team.Members[i]);
                line.SetBackGroundColor(SystemColors.ButtonFace);
                line.SetSize(new Size(580, 63));
                line.SetDeleteMode(false);
                line.SetStisticalMode((int)this.evaluationOfMembers[i], this.scoreOfMembers[i]);
                flpMemberStatistical.Controls.Add(line);
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

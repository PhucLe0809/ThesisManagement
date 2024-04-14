using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.DAOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ThesisManagementProject
{
    public partial class UCTaskEvaluateList : UserControl
    {
        public event EventHandler ClickEvaluate;
        private Thesis thesis = new Thesis();
        private Tasks tasks = new Tasks();
        private Team team = new Team();
        private UCPeopleMiniLine peopleLine = new UCPeopleMiniLine();
        private EvaluationDAO evaluationDAO = new EvaluationDAO();

        public UCTaskEvaluateList()
        {
            InitializeComponent();
        }
        public UCPeopleMiniLine GetPeopleLine
        {
            get { return this.peopleLine; }
        }
        public void SetUpUserControl(Thesis thesis, Tasks tasks, Team team, People people)
        {
            this.thesis = thesis;
            this.tasks = tasks;
            this.team = team;
            flpMembers.Controls.Clear();
            if (people.Role == ERole.Lecture) LoadListRoleLecture();
            else AddPeopleMiniLine(people);
        }
        private void LoadListRoleLecture()
        {
            foreach (People people in team.Members)
            {
                AddPeopleMiniLine(people);
            }
        }
        private void AddPeopleMiniLine(People student)
        {
            UCPeopleMiniLine line = new UCPeopleMiniLine(student);
            line.SetSize(new Size(610, 60));
            line.SetDeleteMode(false);

            Evaluation evaluation = evaluationDAO.SelectOnly(tasks.IdTask, student.IdAccount);
            line.SetEvaluateMode(evaluation, true);
            line.ClickEvaluate += Line_ClickEvaluate;
            flpMembers.Controls.Add(line);
        }
        private void Line_ClickEvaluate(object sender, EventArgs e)
        {
            UCPeopleMiniLine line = sender as UCPeopleMiniLine;
            if (line != null)
            {
                this.peopleLine = line;
            }
            OnClickEvaluate(EventArgs.Empty);
        }
        private void OnClickEvaluate(EventArgs e)
        {
            ClickEvaluate?.Invoke(this, e);
        }
    }
}

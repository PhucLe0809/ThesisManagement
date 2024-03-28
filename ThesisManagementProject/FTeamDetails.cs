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
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class FTeamDetails : Form
    {
        private MyProcess myProcess = new MyProcess();
        private Team team = new Team();
        private Thesis thesis = new Thesis();

        public FTeamDetails()
        {
            InitializeComponent();
        }
        public FTeamDetails(Team team)
        {
            InitializeComponent();

            SetInformation(team, new Thesis());
        }

        private void SetInformation(Team team, Thesis thesis)
        {
            this.team = team;
            this.thesis = thesis;
            InitUserControl();
        }
        private void InitUserControl()
        {
            SetTeam(this.team);
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
                line.SetButtonAddImageNull();
                flpMembers.Controls.Add(line);
            }
        }
    }
}

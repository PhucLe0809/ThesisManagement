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
    public partial class UCTeamMiniLine : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        public event EventHandler ThesisAddAccepted;
        private Team team = new Team();
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();

        public UCTeamMiniLine(Team team)
        {
            InitializeComponent();
            SetInformation(team);
        }

        #region PROPERTIES

        public Team GetTeam
        {
            get { return this.team; }
        }

        #endregion

        #region FUNCTIONS 

        public void SetInformation(Team team)
        {
            this.team = team;
            this.thesis = thesisDAO.SelectFollowTeam(team.IDTeam);
            InitUserControl();
        }
        private void InitUserControl()
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(team.AvatarName);
            lblTeamName.Text = myProcess.FormatStringLength(team.TeamName, 30);
            lblTeamCode.Text = team.IDTeam;
            gTextBoxTeamMemebrs.Text = team.Members.Count.ToString() + " members";
        }
        public void SetSize(Size size)
        {
            this.Size = size;
            gShadowPanelBack.Size = new Size(size.Width - 5, size.Height);
        }
        public void SetSimpleLine()
        {
            gTextBoxTeamMemebrs.Hide();
            gButtonAdd.Hide();
        }
        public void SetBackColor(Color color)
        {
            this.BackColor = color;
            gShadowPanelBack.BackColor = color;

            if (this.BackColor != Color.White) ExecuteBackGroundColor(Color.White);
            else ExecuteBackGroundColor(SystemColors.ButtonFace);
        }
        private void ExecuteBackGroundColor(Color color)
        {
            gShadowPanelBack.FillColor = color;
            gCirclePictureBoxAvatar.BackColor = color;
            lblTeamName.BackColor = color;
            lblTeamCode.BackColor = color;
        }

        #endregion

        #region EVENT CONTROLS

        private void gShadowPanelBack_Click(object sender, EventArgs e)
        {
            FTeamDetails fTeamDetails = new FTeamDetails(team, thesis);
            fTeamDetails.ShowDialog();
        }
        private void gButtonAdd_Click(object sender, EventArgs e)
        {
            ThesisAddAcceptedClicked(EventArgs.Empty);
        }
        public virtual void ThesisAddAcceptedClicked(EventArgs e)
        {
            ThesisAddAccepted?.Invoke(this, e);
        }

        #endregion

    }
}

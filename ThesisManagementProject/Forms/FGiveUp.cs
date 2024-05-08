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

namespace ThesisManagementProject.Forms
{
    public partial class FGiveUp : Form
    {
        public event EventHandler ConfirmedGivingUp;
        private MyProcess myProcess = new MyProcess();

        private Thesis thesis = new Thesis();
        private People represent = new People();
        private Team team = new Team();
        private GiveUp giveUp = new GiveUp();

        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
        private GiveUpDAO giveUpDAO = new GiveUpDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private bool flagCheck = false;

        public FGiveUp()
        {
            InitializeComponent();
        }
        public FGiveUp(Thesis thesis, People represent, Team team)
        {
            InitializeComponent();

            this.thesis = thesis;
            this.represent = represent;
            this.team = team;
            this.giveUp = new GiveUp(thesis.IdThesis, represent.IdAccount, team.IdTeam, string.Empty, DateTime.Now);
            this.flagCheck = false;
            SetUpUserControl();
        }
        public void SetUpUserControl()
        {
            SetThesis();
            SetRepresent();
            SetTeam();
        }
        private void SetThesis()
        {
            UCThesisMiniBoard uCThesisMiniBoard = new UCThesisMiniBoard(thesis);
            uCThesisMiniBoard.SetColorViewState(SystemColors.ButtonFace);
            gPanelThesis.Controls.Clear();
            gPanelThesis.Controls.Add(uCThesisMiniBoard);
        }
        private void SetRepresent()
        {
            UCPeopleMiniLine uCPeopleMiniLine = new UCPeopleMiniLine(represent);
            uCPeopleMiniLine.SetSize(new Size(275, 60));
            uCPeopleMiniLine.SetBackGroundColor(SystemColors.ButtonFace);
            uCPeopleMiniLine.GButtonAdd.Hide();
            gPanelRepresent.Controls.Clear();
            gPanelRepresent.Controls.Add(uCPeopleMiniLine);
        }
        private void SetTeam()
        {
            UCTeamMiniLine uCTeamMiniLine = new UCTeamMiniLine(team);
            uCTeamMiniLine.SetSize(new Size(275, 60));
            gPanelTeam.Controls.Clear();
            gPanelTeam.Controls.Add(uCTeamMiniLine);
        }
        public void SetReadOnly(GiveUp giveUp)
        {
            this.represent = peopleDAO.SelectOnlyByID(giveUp.IdRepresent);
            this.giveUp = giveUp;
            SetReasonReadOnly();
            SetRepresent();
        }
        private void SetReasonReadOnly()
        {
            gTextBoxReason.Text = giveUp.Reason;
            gTextBoxReason.FillColor = SystemColors.ButtonFace;
            gTextBoxReason.BorderThickness = 0;
            gTextBoxReason.ReadOnly = true;
            gButtonCancel.Location = new Point(672, 624);
            gButtonCancel.Show();
            gButtonConfirm.Hide();
            gButtonCancel.Focus();
        }
        private bool CheckInformationValid()
        {
            myProcess.RunCheckDataValid(giveUp.CheckReason() || flagCheck, erpReason, gTextBoxReason, "Reason cannot be empty");

            return giveUp.CheckReason();
        }
        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gButtonConfirm_Click(object sender, EventArgs e)
        {
            this.flagCheck = false;
            if (CheckInformationValid())
            {
                DialogResult result = MessageBox.Show("The " + team.TeamName + " team definitely refused to complete the " + thesis.Topic + " thesis",
                                                        "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    thesisDAO.UpdateStatus(this.thesis, EThesisStatus.GiveUp);
                    thesisStatusDAO.UpdateThesisStatus(this.team.IdTeam, this.thesis.IdThesis, EThesisStatus.GiveUp);
                    giveUpDAO.Insert(this.giveUp);

                    string content = Notification.GetContentTypeGiveUp(team.TeamName, thesis.Topic);
                    var peoples = new List<People>();
                    peoples.AddRange(team.Members);
                    peoples.Add(peopleDAO.SelectOnlyByID(thesis.IdInstructor));
                    notificationDAO.InsertFollowListPeople(represent.IdAccount, thesis.IdThesis, thesis.IdThesis, content, peoples);

                    ConfirmedGivingUp?.Invoke(this, e);
                    this.Close();
                }
            }
        }
        private void gTextBoxReason_TextChanged(object sender, EventArgs e)
        {
            giveUp.Reason = gTextBoxReason.Text;
            myProcess.RunCheckDataValid(giveUp.CheckReason() || flagCheck, erpReason, gTextBoxReason, "Reason cannot be empty");
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCThesisDetails : UserControl
    {
        private MyProcess myProcess = new MyProcess();

        private Thesis thesis = new Thesis();
        private People people = new People();
        private Team team = new Team();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
        private bool flagWaiting = false;
        private List<Team> listTeam = new List<Team>();

        private UCThesisLine thesisLine = new UCThesisLine();
        private UCThesisDetailsTeam showTeam = new UCThesisDetailsTeam();
        private UCThesisDetailsRegistered uCThesisDetailsRegistered = new UCThesisDetailsRegistered();
        private UCThesisDetailsCreatedTeam uCThesisDetailsCreatedTeam;
        private UCThesisDetailsTasks uCThesisDetailsTasks = new UCThesisDetailsTasks();

        public UCThesisDetails()
        {
            InitializeComponent();

        }

        #region PROPERTIES

        public bool FlagWaiting
        {
            set { this.flagWaiting = value; }
        }
        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        #endregion

        #region FUNCTIONS

        public void SetInformation(UCThesisLine thesisLine, Thesis thesis, People people)
        {
            this.thesis = thesis;
            this.people = people;
            this.thesisLine = thesisLine;
            InitUserControl();
        }
        private void InitUserControl()
        {
            gShadowPanelTeam.Controls.Add(showTeam);
            ResetUserControl();
            SetControlsReadOnly(true);
            SetWaiting();
            SetButtonEditOrDetails();
        }
        private void ResetUserControl()
        {
            ResetThesisInfor();
            SetThesisDetailsMode();
        }
        private void ResetThesisInfor()
        {
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);

            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gTextBoxTopic.Text = thesis.Topic;
            gTextBoxField.Text = thesis.Field.ToString();
            gTextBoxLevel.Text = thesis.Level.ToString();
            gTextBoxMembers.Text = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
        }
        private void SetControlsReadOnly(bool flagReadOnly)
        {
            int thickness = flagReadOnly ? 0 : 1;
            Color colors = flagReadOnly ? SystemColors.ButtonFace : Color.White;
            myProcess.SetTextBoxReadOnly(gTextBoxTopic, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxDescription, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxField, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxLevel, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxMembers, thickness, colors, flagReadOnly);
        }
        private void SetWaiting()
        {
            if (this.flagWaiting == false) return;

            HideAllButtonMode();
            gPictureBoxState.Image = Properties.Resources.GiftWaiting;
            gTextBoxState.Text = "Please wait !";
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(gPictureBoxState);
            gPanelDataView.Controls.Add(gTextBoxState);
        }
        private void SetThesisDetailsMode()
        {
            bool flagShow = thesis.Status == EThesisStatus.Processing || thesis.Status == EThesisStatus.Completed;

            SetTeamMode(flagShow);
            SetViewButtonMode(flagShow);

            if (people.Role == ERole.Student && !flagShow)
            {
                SetStudentRegister();
            }
        }
        private void SetTeamMode(bool flagShow)
        {
            if (flagShow)
            {
                this.team = teamDAO.SelectFollowThesis(this.thesis);
                if (team != null)
                {
                    showTeam.SetInformation(team, thesis);
                    showTeam.Location = new Point(5, 5);
                    SetTeamHere(true);
                }
            }
            else
            {
                SetTeamHere(false);
            }
        }
        private void SetViewButtonMode(bool flagShow)
        {
            if (flagShow)
            {
                gGradientButtonRegistered.Hide();
                gGradientButtonTasks.Show();
                gGradientButtonStatistical.Show();
                gGradientButtonTasks.PerformClick();
            }
            else
            {
                gGradientButtonTasks.Hide();
                gGradientButtonStatistical.Hide();
                gGradientButtonRegistered.Show();
                gGradientButtonRegistered.PerformClick();
            }
        }
        private void SetButtonEditOrDetails()
        {
            if (people.Role == ERole.Student || thesis.Status == EThesisStatus.Completed)
            {
                gButtonEdit.Hide();
            }
            else
            {
                gButtonEdit.Show();
            }
        }
        private void SetTeamHere(bool flag)
        {
            if (flag)
            {
                ptbEmptyState.Hide();
                lblThere.Hide();
                showTeam.Show();
            }
            else
            {
                showTeam.Hide();
                ptbEmptyState.Show();
                lblThere.Show();
            }

        }
        private void SetStudentRegister()
        {
            HideAllButtonMode();

            uCThesisDetailsCreatedTeam = new UCThesisDetailsCreatedTeam(this.people, this.thesis);
            uCThesisDetailsCreatedTeam.GPerform.Click += GPerformState_Click;
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsCreatedTeam);
        }
        private void HideAllButtonMode()
        {
            gGradientButtonTasks.Hide();
            gGradientButtonStatistical.Hide();
            gGradientButtonRegistered.Hide();
        }
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonRegistered, Color.White, Color.White);
            myProcess.ButtonStandardColor(gGradientButtonTasks, Color.White, Color.White);
        }

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisView = new FThesisEdit(peopleDAO.SelectOnlyByID(thesis.IdCreator), thesis);
            fThesisView.ShowDialog();
            ResetThesisInfor();
            this.thesisLine.SetInformation(this.thesis);
        }

        #endregion

        #region EVENT gButtonDetails

        private void gButtonDetails_Click(object sender, EventArgs e)
        {
            FThesisView fThesisView = new FThesisView(thesis);
            fThesisView.ShowDialog();
        }

        #endregion

        #region EVENT gGradientButtonTasks

        private void gGradientButtonTasks_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonTasks);
            uCThesisDetailsTasks.SetUpUserControl(people, team, thesis.Status == EThesisStatus.Processing);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsTasks);
        }

        #endregion

        #region EVENT gGradientButtonRegistered

        private void gGradientButtonRegistered_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonRegistered);
            gPanelDataView.Controls.Clear();

            this.listTeam = teamDAO.SelectList(this.thesis.IdThesis);

            uCThesisDetailsRegistered.Clear();
            foreach (Team team in listTeam)
            {
                UCTeamMiniLine line = new UCTeamMiniLine(team);
                line.ThesisAddAccepted += ThesisAddAccepted_Clicked;
                uCThesisDetailsRegistered.AddTeam(line);
            }

            gPanelDataView.Controls.Add(uCThesisDetailsRegistered);
        }
        private void ThesisAddAccepted_Clicked(object sender, EventArgs e)
        {
            UCTeamMiniLine line = sender as UCTeamMiniLine;

            if (line != null)
            {
                Team team = line.GetTeam;
                DialogResult result = MessageBox.Show("Are you sure you want to accept team " + team.TeamName,
                                                        "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    this.thesis.Status = EThesisStatus.Processing;
                    teamDAO.Delete(this.listTeam, this.thesis.IdThesis);
                    thesisStatusDAO.Insert(this.thesis, team);
                    thesisDAO.UpdateStatus(this.thesis, EThesisStatus.Processing);

                    SetThesisDetailsMode();
                    gTextBoxStatus.Text = thesis.Status.ToString();
                    gTextBoxStatus.FillColor = thesis.GetStatusColor();
                }
            }
        }

        #endregion

        #region EVENTHANDER GPerformState

        private void GPerformState_Click(object? sender, EventArgs e)
        {
            gPanelDataView.Controls.Clear();
            gPictureBoxState.Image = Properties.Resources.GifCompleted;
            gTextBoxState.Text = "You have successfully registered !";
            gPanelDataView.Controls.Add(gPictureBoxState);
            gPanelDataView.Controls.Add(gTextBoxState);
        }

        #endregion

    }
}

using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCThesisDetails : UserControl
    {
        private MyProcess myProcess = new MyProcess();

        private Thesis thesis = new Thesis();
        private People host = new People();
        private Team team = new Team();
        private People instructor = new People();
        private Notification notification = new Notification();
        private List<Team> listTeam = new List<Team>();

        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private UCThesisDetailsTeam showTeam = new UCThesisDetailsTeam();
        private UCThesisDetailsRegistered uCThesisDetailsRegistered = new UCThesisDetailsRegistered();
        private UCThesisDetailsCreatedTeam uCThesisDetailsCreatedTeam = new UCThesisDetailsCreatedTeam();
        private UCThesisDetailsTasks uCThesisDetailsTasks = new UCThesisDetailsTasks();
        private UCThesisDetailsStatistical uCThesisDetailsStatistical = new UCThesisDetailsStatistical();

        private bool flagEdited = false;
        private bool flagDeleted = false;
        private bool flagWaiting = false;

        public UCThesisDetails()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public bool FlagWaiting
        {
            set { this.flagWaiting = value; }
        }
        public bool ThesisEdited
        {
            get { return this.flagEdited; }
        }
        public bool ThesisDeleted
        {
            get { return this.flagDeleted; }
        }
        public Thesis GetThesis
        {
            get { return this.thesis; }
        }
        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        #endregion

        #region FUNCTIONS

        public void SetInformation(Thesis thesis, People host)
        {
            this.thesis = thesis;
            this.host = host;
            this.instructor = peopleDAO.SelectOnlyByID(thesis.IdInstructor);
            InitUserControl();
        }
        private void InitUserControl()
        {
            this.flagEdited = false;
            this.flagDeleted = false;
            gShadowPanelTeam.Controls.Add(showTeam);

            ResetUserControl();
            SetControlsReadOnly(true);
            SetWaiting();
            SetButtonComplete();
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
            myProcess.SetTextBoxState(gTextBoxTopic, flagReadOnly);
            myProcess.SetTextBoxState(gTextBoxDescription, flagReadOnly);
            myProcess.SetTextBoxState(gTextBoxField, flagReadOnly);
            myProcess.SetTextBoxState(gTextBoxLevel, flagReadOnly);
            myProcess.SetTextBoxState(gTextBoxMembers, flagReadOnly);
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
            if (host.Role == ERole.Student && !flagShow)
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
        private void SetButtonComplete()
        {
            if (host.Role == ERole.Lecture && thesis.Status == EThesisStatus.Processing)
            {
                gGradientButtonComplete.Show();
                gGradientButtonComplete.Click += gGradientButtonComplete_Click;
            }
            else if (host.Role == ERole.Student && thesis.Status == EThesisStatus.Processing)
            {
                gGradientButtonComplete.Click += gGradientButtonNotComplete_Click;
                gGradientButtonComplete.Text = "Not completed";
                gGradientButtonComplete.Show();
            }
            else
            {
                gGradientButtonComplete.Hide();
            }
        }
        private void SetButtonEditOrDetails()
        {
            if (host.Role == ERole.Student || thesis.Status == EThesisStatus.Completed)
            {
                gButtonEdit.Hide();
            }
            else
            {
                gButtonEdit.Show();
                if (host.Role == ERole.Lecture && thesis.Status == EThesisStatus.Processing) gButtonEdit.Location = new Point(303, 14);
                else gButtonEdit.Location = new Point(420, 14);
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

            uCThesisDetailsCreatedTeam = new UCThesisDetailsCreatedTeam(this.host, this.thesis);
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
            myProcess.ButtonStandardColor(gGradientButtonStatistical, Color.White, Color.White);
        }
        public void PerformNotificationClick(Notification notification)
        {
            this.notification = notification;
            if (this.notification.Type != ENotificationType.Thesis)
            {
                gGradientButtonTasks.PerformClick();
                uCThesisDetailsTasks.PerformNotificationClick(notification);
            }
        }
        private void SetStateCompleted()
        {
            this.thesis.Status = EThesisStatus.Completed;
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gButtonEdit.Hide();
            SetButtonComplete();

            HideAllButtonMode();
            gPictureBoxState.Image = Properties.Resources.GifCompleted;
            gTextBoxState.Text = "Congratulations on completion !";
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(gPictureBoxState);
            gPanelDataView.Controls.Add(gTextBoxState);
        }
        private void SetStateNotCompleted()
        {
            this.thesis.Status = EThesisStatus.NotCompleted;
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gButtonEdit.Hide();

            HideAllButtonMode();
            gPictureBoxState.Image = Properties.Resources.GifCompleted;
            gTextBoxState.Text = "Not completed !";
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(gPictureBoxState);
            gPanelDataView.Controls.Add(gTextBoxState);
        }

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisView = new FThesisEdit(peopleDAO.SelectOnlyByID(thesis.IdCreator), thesis);
            fThesisView.ShowDialog();
            ResetThesisInfor();
            this.flagEdited = true;
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);
        }

        #endregion

        #region EVENT gButtonDetails

        private void gButtonDetails_Click(object sender, EventArgs e)
        {
            FThesisView fThesisView = new FThesisView(thesis);
            fThesisView.ShowDialog();
        }

        #endregion

        #region EVENT gGradientButtonComplete

        private void gGradientButtonComplete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You have definitely completed the " + thesis.Topic + " thesis",
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {          
                thesisDAO.UpdateStatus(this.thesis, EThesisStatus.Completed);
                thesisStatusDAO.UpdateThesisStatus(this.team.IDTeam, this.thesis.IdThesis, EThesisStatus.Completed);

                this.flagEdited = true;
                SetStateCompleted();
            }
        }
        private void gGradientButtonNotComplete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You have definitely not completed the " + thesis.Topic + " thesis",
                                         "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                thesisDAO.UpdateStatus(this.thesis, EThesisStatus.NotCompleted);
                thesisStatusDAO.UpdateThesisStatus(this.team.IDTeam, this.thesis.IdThesis, EThesisStatus.Completed);

                this.flagEdited = true;
                SetStateNotCompleted();
            }
        }

        #endregion

        #region EVENT gGradientButtonTasks

        private void gGradientButtonTasks_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonTasks);
            uCThesisDetailsTasks.SetUpUserControl(host, instructor, team, thesis, thesis.Status == EThesisStatus.Processing);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsTasks);
        }

        #endregion

        #region EVENT gGradientButtonStatistical

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonStatistical);
            uCThesisDetailsStatistical.SetUpUserControl(this.team);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsStatistical);
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
                    this.flagEdited = true;
                    this.thesis.Status = EThesisStatus.Processing;
                    teamDAO.DeleteListTeam(this.listTeam);
                    teamDAO.Insert(team);
                    thesisStatusDAO.DeleteListTeam(this.listTeam, this.thesis.IdThesis);
                    thesisStatusDAO.Insert(this.thesis, team);
                    thesisDAO.UpdateStatus(this.thesis, EThesisStatus.Processing);

                    string content = Notification.GetContentTypeAccepted(host.FullName, thesis.Topic);
                    notificationDAO.InsertFollowListPeople(host.IdAccount, thesis.IdThesis, thesis.IdThesis, content, team.Members);

                    SetThesisDetailsMode();
                    SetButtonComplete();
                    SetButtonEditOrDetails();
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
            this.flagDeleted = true;
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
        }

        #endregion

    }
}

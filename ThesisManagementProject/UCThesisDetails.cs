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
        private GiveUpDAO giveUpDAO = new GiveUpDAO();
        private ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private UCThesisDetailsTeam showTeam = new UCThesisDetailsTeam();
        private UCThesisDetailsRegistered uCThesisDetailsRegistered = new UCThesisDetailsRegistered();
        private UCThesisDetailsCreatedTeam uCThesisDetailsCreatedTeam = new UCThesisDetailsCreatedTeam();
        private UCThesisDetailsStatistical uCThesisDetailsStatistical = new UCThesisDetailsStatistical();

        private bool flagEdited = false;
        private bool flagDeleted = false;
        private bool flagStuMyTheses = false;

        public UCThesisDetails()
        {
            InitializeComponent();
        }

        #region PROPERTIES

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

        public void SetInformation(Thesis thesis, People host, bool flagStuMyTheses)
        {
            this.thesis = thesis;
            this.host = host;
            this.flagStuMyTheses = flagStuMyTheses;
            this.instructor = peopleDAO.SelectOnlyByID(thesis.IdInstructor);
            InitUserControl();
        }
        private void InitUserControl()
        {
            this.flagEdited = false;
            this.flagDeleted = false;
            gShadowPanelTeam.Controls.Add(showTeam);

            ResetThesisInfor();
            SetControlsReadOnly(true);
            SetInitialSate();
            SetButtonComplete();
            SetButtonEditOrDetails();
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
        private void SetInitialSate()
        {
            SetTeamHere(false);
            gGradientButtonReasonDetails.Hide();

            if (thesis.Status == EThesisStatus.Processing || thesis.Status == EThesisStatus.Completed)
            {
                SetTeamMode(true);
                SetViewButtonMode(true);
                return;
            }
            if (thesis.Status == EThesisStatus.GiveUp)
            {
                SetTeamMode(true);
                SetGiveUpMode(true);
                return;
            }
            if (thesis.Status == EThesisStatus.Registered || thesis.Status == EThesisStatus.Published)
            {
                SetViewButtonMode(false);
                if (host.Role == ERole.Lecture)
                {
                    gGradientButtonRegistered.PerformClick();
                }
                else
                {
                    if (this.flagStuMyTheses)
                    {
                        SetWaitingMode(true);
                    }
                    else
                    {
                        SetStudentRegister(true);
                    }
                }
            }
        }
        private void SetUpDataViewState()
        {
            HideAllButtonMode();
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(gPictureBoxState);
            gPanelDataView.Controls.Add(gTextBoxState);
            gPanelDataView.Controls.Add(gGradientButtonReasonDetails);
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
                gGradientButtonMeeting.Show();
                gGradientButtonStatistical.Show();
                gGradientButtonTasks.PerformClick();
            }
            else
            {
                gGradientButtonTasks.Hide();
                gGradientButtonMeeting.Hide();
                gGradientButtonStatistical.Hide();
                gGradientButtonRegistered.Show();
                gGradientButtonRegistered.PerformClick();
            }
        }
        private void SetWaitingMode(bool flag)
        {
            if (flag == false) return;

            gPictureBoxState.Image = Properties.Resources.GiftWaiting;
            gTextBoxState.Text = "Please wait !";
            gTextBoxState.ForeColor = Color.FromArgb(0, 192, 192);
            SetUpDataViewState();
        }
        private void SetGiveUpMode(bool flag)
        {
            if (flag == false) return;

            gPictureBoxState.Image = Properties.Resources.PictureEmptyState;
            gTextBoxState.Text = "  The thesis cannot continue !";
            gTextBoxState.ForeColor = Color.Gray;
            gGradientButtonReasonDetails.Show();
            SetUpDataViewState();
        }
        private void SetSuccessfullyRegistered()
        {
            gPictureBoxState.Image = Properties.Resources.GifCompleted;
            gTextBoxState.Text = "You have successfully registered !";
            gTextBoxState.ForeColor = Color.FromArgb(0, 192, 192);
            SetUpDataViewState();
        }
        private void SetButtonComplete()
        {
            gGradientButtonComplete.Hide();
            gGradientButtonGiveUp.Hide();

            if (host.Role == ERole.Lecture && thesis.Status == EThesisStatus.Processing)
            {
                gGradientButtonComplete.Show();
                gGradientButtonGiveUp.Show();
                return;
            }
            if (host.Role == ERole.Student && thesis.Status == EThesisStatus.Processing)
            {
                gGradientButtonGiveUp.Show();
                return;
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
        private void SetStudentRegister(bool flag)
        {
            if (flag == false) return;

            HideAllButtonMode();
            uCThesisDetailsCreatedTeam = new UCThesisDetailsCreatedTeam(this.host, this.thesis);
            uCThesisDetailsCreatedTeam.GPerform.Click += GPerformState_Click;
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsCreatedTeam);
        }
        private void SetNewState(EThesisStatus status, Image image, string notification)
        {
            this.thesis.Status = status;
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gButtonEdit.Hide();
            SetButtonComplete();

            HideAllButtonMode();
            gPictureBoxState.Image = image;
            gTextBoxState.Text = notification;
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(gPictureBoxState);
            gPanelDataView.Controls.Add(gTextBoxState);

            if (status == EThesisStatus.GiveUp)
            {
                gTextBoxState.ForeColor = Color.Gray;
            }
            else
            {
                gTextBoxState.ForeColor = Color.FromArgb(0, 192, 192);
            }
        }
        private void HideAllButtonMode()
        {
            gGradientButtonTasks.Hide();
            gGradientButtonStatistical.Hide();
            gGradientButtonMeeting.Hide();
            gGradientButtonRegistered.Hide();
        }
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonRegistered, Color.White, Color.White);
            myProcess.ButtonStandardColor(gGradientButtonTasks, Color.White, Color.White);
            myProcess.ButtonStandardColor(gGradientButtonStatistical, Color.White, Color.White);
            myProcess.ButtonStandardColor(gGradientButtonMeeting, Color.White, Color.White);
        }
        public void PerformNotificationClick(Notification notification)
        {
            this.notification = notification;
            if (this.notification.Type == ENotificationType.Meeting)
            {
                gGradientButtonMeeting.PerformClick();
                return;
            }

            if (this.notification.Type != ENotificationType.Thesis)
            {
                gGradientButtonTasks.PerformClick();
                UCThesisDetailsTasks uCThesisDetailsTasks = new UCThesisDetailsTasks();
                uCThesisDetailsTasks.SetUpUserControl(host, instructor, team, thesis, thesis.Status == EThesisStatus.Processing);
                uCThesisDetailsTasks.PerformNotificationClick(notification);
            }
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
                thesisStatusDAO.UpdateThesisStatus(this.team.IdTeam, this.thesis.IdThesis, EThesisStatus.Completed);

                this.flagEdited = true;
                SetNewState(EThesisStatus.Completed, Properties.Resources.GiftCompleted, "Congratulations on completion !");
            }
        }

        #endregion

        #region EVENT gGradientButtonGiveUp

        private void gGradientButtonGiveUp_Click(object sender, EventArgs e)
        {
            FGiveUp fGiveUp = new FGiveUp(this.thesis, this.host, this.team);
            fGiveUp.ConfirmedGivingUp += FGiveUp_ConfirnedGivingUp;
            fGiveUp.ShowDialog();
        }
        private void FGiveUp_ConfirnedGivingUp(object? sender, EventArgs e)
        {
            this.flagEdited = true;
            SetNewState(EThesisStatus.GiveUp, Properties.Resources.PictureEmptyState, "The thesis cannot continue !");
        }

        #endregion

        #region EVENT gGradientButtonReasonDetails

        private void gGradientButtonReasonDetails_Click(object sender, EventArgs e)
        {
            FGiveUp fGiveUp = new FGiveUp(this.thesis, this.host, this.team);
            GiveUp giveUp = giveUpDAO.SelectFollowThesis(thesis.IdThesis);
            fGiveUp.SetReadOnly(giveUp);
            fGiveUp.ShowDialog();
        }

        #endregion

        #region EVENT gGradientButtonTasks

        private void gGradientButtonTasks_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonTasks);
            UCThesisDetailsTasks uCThesisDetailsTasks = new UCThesisDetailsTasks();
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

        #region EVENT gGradientButtonMeeting

        private void gGradientButtonMeeting_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonMeeting);
            UCThesisDetailsMeeting uCThesisDetailsMeeting = new UCThesisDetailsMeeting();
            uCThesisDetailsMeeting.SetUpUserControl(host, thesis, team);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsMeeting);
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

                    SetInitialSate();
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
            SetSuccessfullyRegistered();
            this.flagDeleted = true;
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
        }

        #endregion

    }
}

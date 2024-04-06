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
        private DBConnection dBConnection = new DBConnection();

        private Thesis thesis = new Thesis();
        private People people = new People();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private bool flagWaiting = false;
        private List<Team> listTeam = new List<Team>();

        private UCThesisDetailsRegistered uCThesisDetailsRegistered = new UCThesisDetailsRegistered();
        private UCThesisDetailsCreatedTeam uCThesisDetailsCreatedTeam;
        private UCThesisDetailsGeneral uCThesisDetailsGeneral = new UCThesisDetailsGeneral();

        #region CONTRUCTOR

        public UCThesisDetails()
        {
            InitializeComponent();

        }
        public UCThesisDetails(Thesis thesis, People people)
        {
            InitializeComponent();

            SetInformation(thesis, people);


        }

        #endregion

        #region PROPERTIES

        public bool FlagWaiting
        {
            set { this.flagWaiting = value; }
        }

        #endregion

        #region FUNCTIONS

        public void SetInformation(Thesis thesis, People people)
        {
            this.thesis = thesis;
            this.people = people;
            InitUserControl();
        }
        private void InitUserControl()
        {
            ResetThesis();
            SetControlsReadOnly(true);
            SetWaiting();
            SetButtonEditOrDetails();
        }
        private void ResetThesis()
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

            SetThesisDetailsMode();
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
            gShadowPanelTeam.Controls.Clear();

            if (flagShow)
            {
                string command = string.Format("SELECT * FROM {0} WHERE idthesis = '{1}' and status = '{2}'",
                                                MyDatabase.DBThesisStatus, thesis.IdThesis, thesis.Status.ToString());
                DataTable table = dBConnection.Select(command);
                Team team = teamDAO.SelectOnly(table.Rows[0]["idteam"].ToString());
                if (team != null)
                {
                    UCThesisDetailsTeam showTeam = new UCThesisDetailsTeam(team, thesis);
                    showTeam.Location = new Point(5, 5);
                    gShadowPanelTeam.Controls.Add(showTeam);
                }
            }
        }
        private void SetViewButtonMode(bool flagShow)
        {
            if (flagShow)
            {
                gGradientButtonRegistered.Hide();
                gGradientButtonGeneral.Show();
                gGradientButtonGeneral.PerformClick();
            }
            else
            {
                gGradientButtonGeneral.Hide();
                gGradientButtonRegistered.Show();
                gGradientButtonRegistered.PerformClick();
            }
        }
        private void SetButtonEditOrDetails()
        {
            if (people.Role == ERole.Lecture)
            {
                gButtonDetails.Hide();
                gButtonEdit.Show();
            }
            if (people.Role == ERole.Student)
            {
                gButtonDetails.Show();
                gButtonEdit.Hide();
                gButtonDetails.Location = new Point(360, 14);
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
            gButtonEdit.Hide();
            gButtonDetails.Hide();
            gGradientButtonGeneral.Hide();
            gGradientButtonRegistered.Hide();
        }
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonRegistered, Color.White, Color.White);
            myProcess.ButtonStandardColor(gGradientButtonGeneral, Color.White, Color.White);
        }

        #endregion

        #region PROPERTIES

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }
        public Guna2GradientButton GButtonApply { get => gGradientButtonRegistered; }

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisView = new FThesisEdit(peopleDAO.SelectOnlyByID(thesis.IdCreator), thesis);
            fThesisView.ShowDialog();
            ResetThesis();
        }

        #endregion

        #region EVENT gButtonDetails

        private void gButtonDetails_Click(object sender, EventArgs e)
        {
            FThesisView fThesisView = new FThesisView(thesis);
            fThesisView.ShowDialog();
        }

        #endregion

        #region EVENT gButtonAdd

        private void GButtonAdd_Click(object sender, EventArgs e)
        {
            UCPeopleMiniLine line = sender as UCPeopleMiniLine;

            if (line != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to accept " + line.GetPeople.Handle,
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    thesisDAO.SQLExecuteByCommand(string.Format("UPDATE {0} SET status = '{1}' where idteam = '{2}' and idthesis = '{3}'",
                        MyDatabase.DBThesisStatus, EThesisStatus.Processing.ToString(), line.GetPeople.IdAccount, thesis.IdThesis));
                }
            }

        }

        #endregion

        #region EVENT gGradientButtonRegistered

        private void gGradientButtonRegistered_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonRegistered);
            gPanelDataView.Controls.Clear();

            string command = string.Format("SELECT * FROM {0} WHERE idthesis = '{1}'", MyDatabase.DBThesisStatus, thesis.IdThesis);
            this.listTeam = teamDAO.SelectList(command);

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
                    string command = string.Empty;
                    this.thesis.Status = EThesisStatus.Processing;

                    foreach (Team teamLine in listTeam)
                    {
                        command = string.Format("DELETE FROM {0} WHERE idteam = '{1}' AND idthesis = '{2}'",
                                            MyDatabase.DBThesisStatus, teamLine.IDTeam, thesis.IdThesis);
                        dBConnection.ExecuteQuery(command, "Delete", false);
                    }

                    command = string.Format("INSERT INTO {0} VALUES ('{1}', '{2}', '{3}')",
                                            MyDatabase.DBThesisStatus, team.IDTeam, thesis.IdThesis, thesis.Status.ToString());
                    dBConnection.ExecuteQuery(command, "Insert", false);

                    command = string.Format("UPDATE {0} SET status = '{1}' WHERE idthesis = '{2}'",
                                            MyDatabase.DBThesis, thesis.Status.ToString(), thesis.IdThesis);
                    dBConnection.ExecuteQuery(command, "Accept", false);

                    SetThesisDetailsMode();
                    gTextBoxStatus.Text = thesis.Status.ToString();
                    gTextBoxStatus.FillColor = thesis.GetStatusColor();
                }
            }
        }

        #endregion

        #region EVENT gGradientButtonGeneral

        private void gGradientButtonGeneral_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonGeneral);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetailsGeneral);
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

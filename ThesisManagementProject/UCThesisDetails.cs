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
        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();

        private UCThesisDetailsRegistered uCThesisDetailsRegistered = new UCThesisDetailsRegistered();
        private UCThesisDetailsGeneral uCThesisDetailsGeneral = new UCThesisDetailsGeneral();

        public UCThesisDetails()
        {
            InitializeComponent();

        }
        public UCThesisDetails(Thesis thesis)
        {
            InitializeComponent();

            SetInformation(thesis);
        }

        #region FUNCTIONS

        public void SetInformation(Thesis thesis)
        {
            this.thesis = thesis;
            InitUserControl();
        }
        private void InitUserControl()
        {
            ResetThesis();
            SetControlsReadOnly(true);
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
            Color colorComboBox = flagReadOnly ? Color.Silver : Color.White;
            myProcess.SetTextBoxReadOnly(gTextBoxTopic, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxDescription, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxField, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxLevel, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxMembers, thickness, colors, flagReadOnly);
        }
        private void SetThesisDetailsMode()
        {
            bool flagShow = thesis.Status == EThesisStatus.Processing || thesis.Status == EThesisStatus.Completed;
            SetTeamMode(flagShow);
            SetViewButtonMode(flagShow);
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

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisView = new FThesisEdit(peopleDAO.SelectOnlyByID(thesis.IdCreator), thesis);
            fThesisView.ShowDialog();
            ResetThesis();
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
            List<Team> listTeam = teamDAO.SelectList(command);

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

                    command = string.Format("UPDATE {0} SET status = '{1}' WHERE idthesis = '{2}'",
                                            MyDatabase.DBThesis, thesis.Status.ToString(), thesis.IdThesis);
                    dBConnection.ExecuteQuery(command, "Accept", false);

                    command = string.Format("UPDATE {0} SET status = '{1}' WHERE idthesis = '{2}' and idteam = '{3}'",
                                            MyDatabase.DBThesisStatus, thesis.Status.ToString(), thesis.IdThesis, team.IDTeam);
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

    }
}

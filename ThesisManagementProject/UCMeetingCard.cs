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
using ThesisManagementProject.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCMeetingCard : UserControl
    {
        public event EventHandler MeetingCardDeleted;
        private MyProcess myProcess = new MyProcess();

        private People host = new People();
        private People creator = new People();
        private Meeting meeting = new Meeting();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private MeetingDAO meetingDAO = new MeetingDAO();

        public UCMeetingCard()
        {
            InitializeComponent();
        }
        public UCMeetingCard(Meeting meeting, People host)
        {
            InitializeComponent();

            this.meeting = meeting;
            this.host = host;
            SetInformation();
        }
        public Meeting GetMeeting
        {
            get { return this.meeting; }
        }
        private void SetInformation()
        {
            DateTime start = meeting.Start;
            gTextBoxWeekdays.Text = start.ToString("dddd").ToUpper();
            gTextBoxDay.Text = start.ToString("dd");
            gTextBoxMonth.Text = start.ToString("MMMM").ToUpper();
            lblTitle.Text = myProcess.FormatStringLength(meeting.Title, 30);
            gTextBoxLocation.Text = meeting.Location;
            lblTimeStart.Text = meeting.Start.ToString("dd/MM/yyyy HH:mm:ss tt");
            lblTimeEnd.Text = meeting.TheEnd.ToString("dd/MM/yyyy HH:mm:ss tt");

            this.creator = peopleDAO.SelectOnlyByID(meeting.IdCreator);
            lblCre.Text = "Created by " + creator.FullName + " at " + meeting.Created.ToString("dd/MM/yyyy HH:mm:ss tt");

            if (meeting.IdCreator == host.IdAccount) gButtonDelete.Show();
            else gButtonDelete.Hide();
        }
        private void ShowMeetingInformation()
        {
            FMeetingDetails fMeetingDetails = new FMeetingDetails(this.meeting, this.host);
            fMeetingDetails.MeetingUpdated += FMeetingDetails_MeetingUpdated;
            fMeetingDetails.ShowDialog();
        }
        private void FMeetingDetails_MeetingUpdated(object? sender, EventArgs e)
        {
            this.meeting = meetingDAO.SelectOnly(this.meeting.IdMeeting);
            SetInformation();
        }
        private void gShadowPanelTeam_Click(object sender, EventArgs e)
        {
            ShowMeetingInformation();
        }
        private void lblSeeMore_Click(object sender, EventArgs e)
        {
            ShowMeetingInformation();
        }
        private void gButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this meeting",
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                MeetingCardDeleted?.Invoke(this, e);
            }
        }
    }
}

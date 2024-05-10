using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Forms;
using ThesisManagementProject.Process;
using ThesisManagementProject.Models;
using ThesisManagementProject.DAOs;

namespace ThesisManagementProject
{
    public partial class UCMeetingCreate : UserControl
    {
        public event EventHandler MeetingCreated;
        private MyProcess myProcess = new MyProcess();

        private People host = new People();
        private People instructor = new People();
        private Thesis thesis = new Thesis();
        private Team team = new Team();
        private Meeting meeting = new Meeting();

        private PeopleDAO peopleDAO = new PeopleDAO();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private MeetingDAO meetingDAO = new MeetingDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private bool flagCheck = true;
        private EOperation eOperation = new EOperation();

        public UCMeetingCreate()
        {
            InitializeComponent();
            gDateTimePickerStart.Format = DateTimePickerFormat.Custom;
            gDateTimePickerStart.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
            gDateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            gDateTimePickerEnd.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
        }

        #region PROPERTIES

        public Guna2Button GButtonCancel
        {
            get { return this.gButtonCancel; }
        }
        public Meeting GetMeeting
        {
            get { return this.meeting; }
        }

        #endregion

        #region FUNCTIONS

        public void SetUpUserControl(People host, Thesis thesis, Team team)
        {
            this.host = host;
            this.thesis = thesis;
            this.team = team;
            this.instructor = peopleDAO.SelectOnlyByID(thesis.IdInstructor);
            this.eOperation = EOperation.Create;
            SetUpMode();
        }
        public void SetInformation(Meeting meeting, People host, EOperation eOperation)
        {
            this.meeting = meeting;
            this.host = host;
            this.eOperation = eOperation;
            this.thesis = thesisDAO.SelectOnly(meeting.IdThesis);
            this.instructor = peopleDAO.SelectOnlyByID(thesis.IdInstructor);
            SetUpMode();
        }
        public void SetBackColor(Color color)
        {
            this.BackColor = color;
        }
        private void SetUpMode()
        {
            switch (this.eOperation)
            {
                case EOperation.Create:
                    SetCreateMode();
                    break;
                case EOperation.View:
                    InitInformation();
                    lblCre.Show();
                    SetViewMode();
                    break;
                case EOperation.Edit:
                    InitInformation();
                    SetEditMode();
                    break;
            }
        }
        private void InitInformation()
        {
            gTextBoxTitle.Text = meeting.Title;
            gTextBoxDescription.Text = meeting.Description;
            gDateTimePickerStart.Value = meeting.Start;
            gDateTimePickerEnd.Value = meeting.TheEnd;
            gTextBoxLocation.Text = meeting.Location;
            gTextBoxLink.Text = meeting.Link;
        }
        private void SetViewMode()
        {
            myProcess.SetTextBoxState(gTextBoxTitle, true);
            myProcess.SetTextBoxState(gTextBoxDescription, true);
            myProcess.SetTextBoxState(gTextBoxLocation, true);
            myProcess.SetTextBoxState(gTextBoxLink, true);
            gDateTimePickerStart.Enabled = false;
            gDateTimePickerEnd.Enabled = false;

            People creator = peopleDAO.SelectOnlyByID(meeting.IdCreator);
            lblCre.Text = "Created by " + creator.FullName + " at " + meeting.Created.ToString("dd/MM/yyyy HH:mm:ss tt");
            gButtonCancel.Location = new Point(531, 447);
            gButtonCancel.Text = "Close";
            gButtonCancel.Show();
            gButtonCreate.Hide();
            lblCre.Show();
            gButtonCancel.Focus();
        }
        private void SetEditMode()
        {
            this.flagCheck = true;
            myProcess.SetTextBoxState(gTextBoxTitle, false);
            myProcess.SetTextBoxState(gTextBoxDescription, false);
            myProcess.SetTextBoxState(gTextBoxLocation, false);
            myProcess.SetTextBoxState(gTextBoxLink, false);
            gDateTimePickerStart.Enabled = true;
            gDateTimePickerEnd.Enabled = true;
            gButtonCreate.Text = "Save";
            gButtonCancel.Show();
            gButtonCancel.Text = "Cancel";
            gButtonCreate.Show();
            lblCre.Hide();
        }
        public void SetCreateMode()
        {
            this.flagCheck = true;
            gTextBoxTitle.Clear();
            gTextBoxDescription.Clear();
            gTextBoxLocation.Clear();
            gTextBoxLink.Clear();
            gDateTimePickerStart.Value = DateTime.Now;
            gDateTimePickerEnd.Value = DateTime.Now;
            lblCre.Hide();
        }
        private bool CheckInformationValid()
        {
            myProcess.RunCheckDataValid(meeting.CheckTitle() || flagCheck, erpTitle, gTextBoxTitle, "Title cannot be empty");
            myProcess.RunCheckDataValid(meeting.CheckDescription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
            myProcess.RunCheckDataValid(meeting.CheckStart() || flagCheck, erpStart, gDateTimePickerStart, "Invalid start time");
            myProcess.RunCheckDataValid(meeting.CheckTheEnd() || flagCheck, erpEnd, gDateTimePickerEnd, "Invalid end time");
            myProcess.RunCheckDataValid(meeting.CheckLocation() || flagCheck, erpLocation, gTextBoxLocation, "Location cannot be empty");

            return meeting.CheckTitle() && meeting.CheckDescription() && meeting.CheckStart() && meeting.CheckTheEnd() && meeting.CheckLocation();
        }

        #endregion

        #region EVENT CREATE or EDIT

        private void SolveForCreate()
        {
            this.meeting = new Meeting(thesis.IdThesis, gTextBoxTitle.Text, gTextBoxDescription.Text, gDateTimePickerStart.Value, gDateTimePickerEnd.Value,
                                        gTextBoxLocation.Text, gTextBoxLink.Text, host.IdAccount);
            this.flagCheck = false;
            if (CheckInformationValid())
            {
                meetingDAO.Insert(this.meeting);

                string content = Notification.GetContentTypeMeeting(meeting.Title, host.FullName);
                var peoples = new List<People> { instructor };
                peoples.AddRange(team.Members);
                notificationDAO.InsertFollowListPeople(host.IdAccount, this.meeting.IdThesis, this.meeting.IdMeeting, content, peoples);

                MeetingCreated?.Invoke(this.meeting, EventArgs.Empty);
                gButtonCancel.PerformClick();
            }
        }
        private void SolveForEdit()
        {
            this.meeting = new Meeting(this.meeting.IdMeeting, meeting.IdThesis, gTextBoxTitle.Text, gTextBoxDescription.Text, gDateTimePickerStart.Value, gDateTimePickerEnd.Value,
                                        gTextBoxLocation.Text, gTextBoxLink.Text, host.IdAccount, DateTime.Now);
            this.flagCheck = false;
            if (CheckInformationValid())
            {
                meetingDAO.Update(this.meeting);

                string content = Notification.GetContentTypeMeetingUpdated(meeting.Title);
                var peoples = new List<People> { instructor };
                peoples.AddRange(team.Members);
                notificationDAO.InsertFollowListPeople(host.IdAccount, this.meeting.IdThesis, this.meeting.IdMeeting, content, peoples);

                MeetingCreated?.Invoke(this.meeting, EventArgs.Empty);
                gButtonCancel.PerformClick();
            }
        }
        private void gButtonCreate_Click(object sender, EventArgs e)
        {
            if (this.eOperation == EOperation.Create) SolveForCreate();
            else SolveForEdit();
        }

        #endregion

        #region EVENT TEXTCHANGED and VALUECHANGED

        private void gTextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            this.meeting.Title = gTextBoxTitle.Text;
            myProcess.RunCheckDataValid(meeting.CheckTitle() || flagCheck, erpTitle, gTextBoxTitle, "Title cannot be empty");
        }
        private void gTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            this.meeting.Description = gTextBoxDescription.Text;
            myProcess.RunCheckDataValid(meeting.CheckDescription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");

        }
        private void gTextBoxLocation_TextChanged(object sender, EventArgs e)
        {
            this.meeting.Location = gTextBoxLocation.Text;
            myProcess.RunCheckDataValid(meeting.CheckLocation() || flagCheck, erpLocation, gTextBoxLocation, "Location cannot be empty");
        }
        private void gDateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            this.meeting.Start = gDateTimePickerStart.Value;
            myProcess.RunCheckDataValid(meeting.CheckStart() || flagCheck, erpStart, gDateTimePickerStart, "Invalid start time");
        }
        private void gDateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            this.meeting.TheEnd = gDateTimePickerEnd.Value;
            myProcess.RunCheckDataValid(meeting.CheckTheEnd() || flagCheck, erpEnd, gDateTimePickerEnd, "Invalid end time");
        }

        #endregion

    }
}

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

namespace ThesisManagementProject
{
    public partial class UCThesisDetailsMeeting : UserControl
    {
        private People host = new People();
        private Thesis thesis = new Thesis();
        private Team team = new Team();
        private MeetingDAO meetingDAO = new MeetingDAO();
        private UCMeetingCreate uCMeetingCreate = new UCMeetingCreate();

        private List<Meeting> meetings = new List<Meeting>();

        public UCThesisDetailsMeeting()
        {
            InitializeComponent();
            InitUserControl();
        }
        private void InitUserControl()
        {
            flpMeetingList.Location = new Point(12, 12);
            uCMeetingCreate.Location = new Point(12, 12);
            uCMeetingCreate.GButtonCancel.Click += GButtonCancel_Click;
            gShadowPanelBack.Controls.Add(uCMeetingCreate);
            flpMeetingList.Show();
            uCMeetingCreate.Hide();
        }
        public void SetUpUserControl(People host, Thesis thesis, Team team)
        {
            this.host = host;
            this.thesis = thesis;
            this.team = team;
            this.meetings.Clear();
            this.meetings.AddRange(meetingDAO.SelectByThesis(thesis.IdThesis));
            uCMeetingCreate.SetUpUserControl(host, thesis, team);
            uCMeetingCreate.MeetingCreated += UCMeetingCreate_MeetingCreated;

            foreach (var meeting in meetings)
            {
                UCMeetingCard uCMeetingCard = new UCMeetingCard(meeting, host);
                uCMeetingCard.MeetingCardDeleted += UCMeetingCard_MeetingCardDeleted;
                flpMeetingList.Controls.Add(uCMeetingCard);
            }
        }
        private void UCMeetingCreate_MeetingCreated(object? sender, EventArgs e)
        {
            Meeting meeting = meetingDAO.SelectOnly(uCMeetingCreate.GetMeeting.IdMeeting);

            if (meeting != null)
            {
                this.meetings.Add(meeting);
                UCMeetingCard card = new UCMeetingCard(meeting, host);
                card.MeetingCardDeleted += UCMeetingCard_MeetingCardDeleted;
                flpMeetingList.Controls.Add(card);
                flpMeetingList.Controls.SetChildIndex(card, 0);
            }
        }
        private void UCMeetingCard_MeetingCardDeleted(object? sender, EventArgs e)
        {
            UCMeetingCard card = sender as UCMeetingCard;

            if (card != null)
            {
                meetingDAO.Delete(card.GetMeeting);

                foreach (Control control in flpMeetingList.Controls)
                {
                    if (control.GetType() == typeof(UCMeetingCard))
                    {
                        UCMeetingCard meetingCard = (UCMeetingCard)control;
                        if (meetingCard == card)
                        {
                            flpMeetingList.Controls.Remove(control);
                            this.meetings.Remove(card.GetMeeting);
                            control.Dispose();
                            break;
                        }
                    }
                }
            }
        }
        private void GButtonCancel_Click(object? sender, EventArgs e)
        {
            flpMeetingList.Show();
            uCMeetingCreate.Hide();
        }
        private void gGradientButtonAddMeeting_Click(object sender, EventArgs e)
        {
            flpMeetingList.Hide();
            uCMeetingCreate.SetCreateMode();
            uCMeetingCreate.Show();
        }
    }
}

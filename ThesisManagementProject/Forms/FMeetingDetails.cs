using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Process;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Forms
{
    public partial class FMeetingDetails : Form
    {
        public event EventHandler MeetingUpdated;
        private Meeting meeting = new Meeting();

        public FMeetingDetails()
        {
            InitializeComponent();
        }
        public FMeetingDetails(Meeting meeting, People host)
        {
            InitializeComponent();

            this.meeting = meeting;
            UCMeetingCreate uCMeetingCreate = new UCMeetingCreate();
            if (meeting.IdCreator == host.IdAccount)
            {
                uCMeetingCreate.SetInformation(meeting, host, EOperation.Edit);
                this.BackColor = SystemColors.ButtonFace;
                uCMeetingCreate.SetBackColor(SystemColors.ButtonFace);
            }
            else
            {
                uCMeetingCreate.SetInformation(meeting, host, EOperation.View);
                this.BackColor = Color.White;
                uCMeetingCreate.SetBackColor(Color.White);
            }

            uCMeetingCreate.GButtonCancel.Click += GButtonCancel_Click;
            uCMeetingCreate.MeetingCreated += UCMeetingCreate_MeetingCreated;
            flpBackground.Controls.Add(uCMeetingCreate);
        }
        private void UCMeetingCreate_MeetingCreated(object? sender, EventArgs e)
        {
            MeetingUpdated?.Invoke(this.meeting, e);
        }
        private void GButtonCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}

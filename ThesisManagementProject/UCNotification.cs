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
    public partial class UCNotification : UserControl
    {
        private People host = new People();
        private List<Notification> notificationList = new List<Notification>();
        private NotificationDAO notificationDAO = new NotificationDAO();

        public UCNotification()
        {
            InitializeComponent();
        }
        public void SetInformation(People host)
        {
            this.host = host;
            InitUserControl();
        }
        private void InitUserControl()
        {
            this.notificationList = notificationDAO.SelectList(host);
            LoadNotificationList();
        }
        private void LoadNotificationList()
        {
            flpNotificationList.Controls.Clear();
            foreach (Notification notification in notificationList)
            {
                UCNotificationLine line = new UCNotificationLine(notification);
                line.NotificationDeleteClicked += NotificationDelete_Clicked;
                flpNotificationList.Controls.Add(line);
            }
        }
        public void NotificationDelete_Clicked(object sender, EventArgs e)
        {
            UCNotificationLine line = sender as UCNotificationLine;

            if (line != null)
            {
                foreach (Control control in flpNotificationList.Controls)
                {
                    if (control.GetType() == typeof(UCNotificationLine))
                    {
                        UCNotificationLine notificationLine = (UCNotificationLine)control;
                        if (notificationLine == line)
                        {
                            flpNotificationList.Controls.Remove(control);
                            control.Dispose();
                            break;
                        }
                    }
                }
            }
        }
    }
}

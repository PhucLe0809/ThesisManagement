﻿using System;
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
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCNotificationLine : UserControl
    {
        private MyProcess myProcess = new MyProcess();

        private Notification notification = new Notification();
        private People people = new People();
        private PeopleDAO peopleDAO = new PeopleDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();
        private Color lineColor = Color.White;

        public UCNotificationLine(Notification notification)
        {
            InitializeComponent();
            this.notification = notification;
            InitUserControl();
        }
        private void InitUserControl()
        {
            lblNotification.Text = myProcess.FormatStringLength(notification.Content.ToString(), 130);
            this.people = peopleDAO.SelectOnlyByID(notification.IdSender);
            lblFrom.Text = people.FullName;
            lblTime.Text = notification.Created.ToString("dd/MM/yyyy hh:mm:ss tt");
            gTextBoxType.Text = notification.Type.ToString();
            gTextBoxType.FillColor = notification.GetTypeColor();
            myProcess.SetItemFavorite(gButtonStar, notification.IsFavorite);
            if (notification.IsSaw)
            {
                this.lineColor = Color.FromArgb(222, 224, 224);
                this.BackColor = lineColor;
            }
        }
        private void SetColor(Color color)
        {
            this.BackColor = color;
        }
        private void UCNotificationLine_MouseEnter(object sender, EventArgs e)
        {
            SetColor(Color.Gainsboro);
        }
        private void UCNotificationLine_MouseLeave(object sender, EventArgs e)
        {
            SetColor(this.lineColor);
        }
        private void UCNotificationLine_Click(object sender, EventArgs e)
        {
            this.lineColor = Color.FromArgb(222, 224, 224);
            this.BackColor = lineColor;
            if (notification.IsSaw != true)
            {
                notification.IsSaw = true;
                notificationDAO.UpdateIsSaw(notification.IdNotification, true);
            }
        }
    }
}

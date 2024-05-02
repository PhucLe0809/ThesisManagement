using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject.DAOs
{
    internal class NotificationDAO : DBConnection
    {
        private MyProcess myProcess = new MyProcess();

        public NotificationDAO() { }

        #region SELECT NOTIFICATION

        public List<Notification> SelectList(People people)
        {
            using (var dbContext = new AppDbContext())
            {
                var list = FormatList(dbContext.Notification.Where(n => n.IdHost == people.IdAccount).ToList());

                if (list != null) return list.OrderByDescending(n => n.Created).ToList();
                return new List<Notification>();
            }
        }

        #endregion

        #region NOTIFICATION DAO EXECUTION

        public void Insert(Notification notification)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Notification.Add(notification);
                dbContext.SaveChanges();
            }
        }
        public void InsertFollowListPeople(string idSender, string idThesis, string idObject, string content, List<People> peoples)
        {
            foreach (People people in peoples)
            {
                if (people.IdAccount != idSender)
                {
                    Insert(new Notification(people.IdAccount, idSender, idThesis, idObject, content, DateTime.Now, false, false));
                }
            }
        }
        public void Delete(Notification notification)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingNotification = dbContext.Notification.FirstOrDefault(n => n.IdNotification == notification.IdNotification);

                if (existingNotification != null)
                {
                    dbContext.Notification.Remove(existingNotification);
                    dbContext.SaveChanges();
                }
            }
        }
        public void UpdateProperty(string idNotification, Action<Notification> updateAction)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingNotification = dbContext.Notification.FirstOrDefault(n => n.IdNotification == idNotification);

                if (existingNotification != null)
                {
                    updateAction(existingNotification);
                    dbContext.SaveChanges();
                }
            }
        }


        #endregion

        #region Get Notification From Database

        private Notification Format(Notification notification)
        {
            if (notification == null) return new Notification();

            ENotificationType type = myProcess.GetEnumFromDisplayName<ENotificationType>(notification.Type);

            notification.OnType = type;
            return notification;
        }
        private List<Notification> FormatList(List<Notification> notifications)
        {
            for (int i = 0; i < notifications.Count; i++) notifications[i] = Format(notifications[i]);
            return notifications;
        }

        #endregion

    }
}

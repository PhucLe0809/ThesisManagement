using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
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

        private List<Notification> SelectList(string command)
        {
            DataTable dataTable = Select(command);

            List<Notification> list = new List<Notification>();
            foreach (DataRow row in dataTable.Rows)
            {
                Notification notification = GetFromDataRow(row);
                list.Add(notification);
            }

            return list;
        }
        public List<Notification> SelectList(People people)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idhost = '{1}' ORDER BY created DESC", 
                                            MyDatabase.DBNotification, people.IdAccount);
            return SelectList(command);
        }

        #endregion

        #region NOTIFICATION DAO EXECUTION

        public void Insert(Notification notification)
        {
            ExecuteQueryNotification(notification, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9})",
                "Create", false);
        }
        public void InsertFollowListPeople(string idSender, string idObject, string content, List<People> peoples)
        {
            foreach (People people in peoples)
            {
                if (people.IdAccount != idSender)
                {
                    Insert(new Notification(people.IdAccount, idSender, idObject, content, DateTime.Now, false, false));
                }
            }
        }
        public void Delete(Notification notification)
        {
            ExecuteQueryNotification(notification, "DELETE FROM {0} WHERE idnotification = '{1}'",
                "Delete", false);
        }
        public void UpdateIsSaw(string idNotification, bool flag)
        {
            string command = string.Format("UPDATE {0} SET issaw = {1} WHERE idnotification = '{2}'",
                                                MyDatabase.DBNotification, flag ? 1 : 0, idNotification);
            SQLExecuteByCommand(command);
        }
        public void UpdateIsFavorite(string idNotification, bool flag)
        {
            string command = string.Format("UPDATE {0} SET isfavorite = {1} WHERE idnotification = '{2}'",
                                                MyDatabase.DBNotification, flag ? 1 : 0, idNotification);
            SQLExecuteByCommand(command);
        }

        #endregion

        #region Get Notification From Data Row

        public Notification GetFromDataRow(DataRow row)
        {
            string idNotification = row["idnotification"].ToString();
            string idHost = row["idhost"].ToString();
            string idSender = row["idsender"].ToString();
            string idObject = row["idobject"].ToString();
            string content = row["content"].ToString();
            ENotificationType type = myProcess.GetEnumFromDisplayName<ENotificationType>(row["type"].ToString());
            DateTime created = DateTime.Parse(row["created"].ToString());
            bool isFavorite = row["isfavorite"].ToString() == "True" ? true : false;
            bool isSaw = row["issaw"].ToString() == "True" ? true : false;

            Notification notification = new Notification(idNotification, idHost, idSender, idObject, content, type, created, isFavorite, isSaw);
            return notification;
        }

        #endregion
    
    }
}

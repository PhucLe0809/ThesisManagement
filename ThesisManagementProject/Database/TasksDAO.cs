using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Database
{
    internal class TasksDAO
    {
        DBConnection DBConnection = new DBConnection();

        public TasksDAO() { }
        public void SQLExecuteByCommand(string command)
        {
            DBConnection.SQLExecuteByCommand(command);
        }

        #region SELECT TASKS

        public List<Tasks> SelectList(string command)
        {
            DataTable dataTable = DBConnection.Select(command);

            List<Tasks> list = new List<Tasks>();
            foreach (DataRow row in dataTable.Rows)
            {
                Tasks tasks = SelectOnly(row["idtask"].ToString());
                list.Add(tasks);
            }

            return list;
        }
        public Tasks SelectOnly(string idTask)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select(string.Format("SELECT * FROM {0} WHERE idtask = '{1}'", MyDatabase.DBTask, idTask));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Tasks();
        }

        #endregion

        #region TASK DAO EXECUTION

        public void Insert(Tasks tasks)
        {
            DBConnection.ExecuteQueryTask(tasks, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, '{8}')",
                "Create", true);
        }
        public void Delete(Tasks tasks)
        {
            DBConnection.ExecuteQueryTask(tasks, "DELETE FROM {0} WHERE idtask = '{1}'",
                "Delete", false);
        }
        public void Update(Tasks tasks)
        {
            DBConnection.ExecuteQueryTask(tasks, "UPDATE {0} SET " +
                "idtask = '{1}', title = '{2}', description = '{3}', idcreator = '{4}', idteam = '{5}', " +
                "isfavorite = {6}, progress = {7}, created = '{8}' WHERE idtask = '{1}'",
                "Update", false);
        }

        #endregion

        #region Get Tasks From Data Row

        public Tasks GetFromDataRow(DataRow row)
        {
            string idTask = row["idtask"].ToString();
            string title = row["title"].ToString();
            string description = row["description"].ToString();
            string idSender = row["idcreator"].ToString();
            string idReceiver = row["idteam"].ToString();
            bool isFavorite = row["isfavorite"].ToString() == "True" ? true : false;
            int progress = int.Parse(row["progress"].ToString());
            DateTime created = DateTime.Parse(row["created"].ToString());

            Tasks tasks = new Tasks(idTask, title, description, idSender, idReceiver, isFavorite, progress, created);
            return tasks;
        }

        #endregion

    }
}

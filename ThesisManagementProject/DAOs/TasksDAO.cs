using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.DAOs
{
    internal class TasksDAO : DBConnection
    {
        public TasksDAO() { }

        #region SELECT TASKS

        private List<Tasks> SelectList(string command)
        {
            DataTable dataTable = Select(command);

            List<Tasks> list = new List<Tasks>();
            foreach (DataRow row in dataTable.Rows)
            {
                Tasks tasks = GetFromDataRow(row);
                list.Add(tasks);
            }

            return list;
        }
        public List<Tasks> SelectListByTeam(string idTeam)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idteam = '{1}' ORDER BY created DESC",
                                            MyDatabase.DBTask, idTeam);
            return SelectList(command);
        }
        public Tasks SelectOnly(string idTask)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idtask = '{1}'", MyDatabase.DBTask, idTask));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Tasks();
        }
        public Tasks SelectFromComment(string idComment)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idcomment = '{1}'", MyDatabase.DBComment, idComment));

            if (dt.Rows.Count > 0) return SelectOnly(dt.Rows[0]["idtask"].ToString());
            return new Tasks();
        }
        public Tasks SelectFromEvaluation(string idEvaluation)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idevaluation = '{1}'", MyDatabase.DBEvaluation, idEvaluation));

            if (dt.Rows.Count > 0) return SelectOnly(dt.Rows[0]["idtask"].ToString());
            return new Tasks();
        }

        #endregion

        #region TASK DAO EXECUTION

        public void Insert(Tasks tasks)
        {
            ExecuteQueryTask(tasks, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, '{8}')",
                "Create", true);
        }
        public void Delete(Tasks tasks)
        {
            EvaluationDAO evaluationDAO = new EvaluationDAO();
            evaluationDAO.DeleteFollowTask(tasks);
            ExecuteQueryTask(tasks, "DELETE FROM {0} WHERE idtask = '{1}'",
                "Delete", false);
        }
        public void Update(Tasks tasks)
        {
            ExecuteQueryTask(tasks, "UPDATE {0} SET " +
                "idtask = '{1}', title = '{2}', description = '{3}', idcreator = '{4}', idteam = '{5}', " +
                "isfavorite = {6}, progress = {7}, created = '{8}' WHERE idtask = '{1}'",
                "Update", false);
        }
        public void UpdateIsFavorite(Tasks tasks)
        {
            SQLExecuteByCommand(string.Format("UPDATE " + MyDatabase.DBTask + " SET isfavorite = {0} WHERE idtask = '{1}'",
                                    tasks.IsFavorite ? 1 : 0, tasks.IdTask));
        }
        public List<Tasks> SearchTaskTitle(string idTeam, string title)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idteam = '{1}' and title LIKE '{2}%' ORDER BY created DESC",
                                MyDatabase.DBTask, idTeam, title);
            return SelectList(command);

        }

        #endregion

        #region Get Tasks From Database

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

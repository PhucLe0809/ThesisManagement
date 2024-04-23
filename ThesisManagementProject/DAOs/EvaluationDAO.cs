using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.DAOs
{
    internal class EvaluationDAO : DBConnection
    {
        public EvaluationDAO() { }

        #region SELECT EVALUATION

        public List<Evaluation> SelectList(string command)
        {
            DataTable dataTable = Select(command);

            List<Evaluation> list = new List<Evaluation>();
            foreach (DataRow row in dataTable.Rows)
            {
                Evaluation evaluation = GetFromDataRow(row);
                list.Add(evaluation);
            }

            return list;
        }
        public List<Evaluation> SelectListByTask(string idTask)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idtask = '{1}'",
                                            MyDatabase.DBEvaluation, idTask);
            return SelectList(command);
        }
        public List<Evaluation> SelectListByTaskAndPeople(string idTask, string idPeople)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idtask = '{1}' AND idpeople = '{2}'",
                                            MyDatabase.DBEvaluation, idTask, idPeople);
            return SelectList(command);
        }
        public List<Evaluation> SelectListByPeople(string idPeople)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idpeople = '{1}'",
                                            MyDatabase.DBEvaluation, idPeople);
            return SelectList(command);
        }
        public Evaluation SelectOnly(string idTask, string idPeople)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idtask = '{1}' and idpeople = '{2}'", 
                                            MyDatabase.DBEvaluation, idTask, idPeople));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Evaluation();
        }

        #endregion

        #region EVALUATION DAO EXECUTION

        public void Insert(Evaluation evaluation)
        {
            ExecuteQueryEvaluation(evaluation, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', {5}, {6}, '{7}', {8})",
                "Create", false);
        }
        public void Delete(Evaluation evaluation)
        {
            ExecuteQueryEvaluation(evaluation, "DELETE FROM {0} WHERE idevaluation = '{1}'",
                "Delete", false);
        }
        public void DeleteFollowTask(Tasks tasks)
        {
            SQLExecuteByCommand(string.Format("DELETE FROM {0} WHERE idtask = '{1}'", MyDatabase.DBEvaluation, tasks.IdTask));
        }
        public void Update(Evaluation evaluation)
        {
            ExecuteQueryEvaluation(evaluation, "UPDATE {0} SET " +
                "idevaluation = '{1}', idtask = '{2}', idpeople = '{3}', content = '{4}', contribute = {5}, " +
                "scores = {6}, created = '{7}', isevaluated = {8} WHERE idevaluation = '{1}'",
                "Evaluate", true);
        }
        public void InsertFollowTeam(string idTask, Team team)
        {
            foreach (People people in team.Members)
            {
                Evaluation evaluation = new Evaluation(idTask, people.IdAccount, string.Empty, 0, 0.0F, DateTime.Now, false);
                Insert(evaluation);
            }
        }

        #endregion

        #region Get Evaluation From Data Row

        public Evaluation GetFromDataRow(DataRow row)
        {
            string idEvaluation = row["idevaluation"].ToString();
            string idTask = row["idtask"].ToString();
            string idPeople = row["idpeople"].ToString();
            string content = row["content"].ToString();
            int contribute = int.Parse(row["contribute"].ToString());
            float scores = float.Parse(row["scores"].ToString());
            DateTime created = DateTime.Parse(row["created"].ToString());
            bool isEvaluated = row["isevaluated"].ToString() == "True" ? true : false;

            Evaluation evaluation = new Evaluation(idEvaluation, idTask, idPeople, content, contribute, scores, created, isEvaluated);
            return evaluation;
        }

        #endregion

    }
}

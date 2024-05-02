using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.DAOs
{
    internal class EvaluationDAO : DBConnection
    {
        public EvaluationDAO() { }

        #region SELECT EVALUATION

        public List<Evaluation> SelectList(Func<Evaluation, bool> predicate)
        {
            using (var dbContext = new AppDbContext())
            {
                var list = dbContext.Evaluation.Where(predicate).ToList();
                return list;
            }
        }

<<<<<<< HEAD
            return list;
        }
        public List<Evaluation> SelectListByTask(string idTask)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idtask = '{1}'",
                                            MyDatabase.DBEvaluation, idTask);
            return SelectList(command);
        }
        public List<Evaluation> SelectListByPeople(string idPeople)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idpeople = '{1}'",
                                            MyDatabase.DBEvaluation, idPeople);
            return SelectList(command);
        }
=======
>>>>>>> 55340cd96e9166acefe353d2e04589f4cdb921f3
        public Evaluation SelectOnly(string idTask, string idPeople)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingEvaluation = dbContext.Evaluation.FirstOrDefault(e => e.IdTask == idTask && e.IdPeople == idPeople);

                if (existingEvaluation != null) return existingEvaluation;
                return new Evaluation();
            }
        }

        #endregion

        #region EVALUATION DAO EXECUTION

        public void Insert(Evaluation evaluation)
        {
<<<<<<< HEAD
            ExecuteQueryEvaluation(evaluation, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', {5}, {6}, '{7}', {8})",
                "Create", false);
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
=======
            using (var dbContext = new AppDbContext())
            {
                dbContext.Evaluation.Add(evaluation);
                dbContext.SaveChanges();
            }
>>>>>>> 55340cd96e9166acefe353d2e04589f4cdb921f3
        }
        public void InsertFollowTeam(string idTask, Team team)
        {
            foreach (People people in team.Members)
            {
                Evaluation evaluation = new Evaluation(idTask, people.IdAccount, string.Empty, 0, 0.0F, DateTime.Now, false);
                Insert(evaluation);
            }
        }
        public void DeleteFollowTask(Tasks tasks)
        {
            using (var dbContext = new AppDbContext())
            {
                var list = dbContext.Evaluation.Where(e => e.IdTask == tasks.IdTask);

                if (list != null)
                {
                    foreach (var evaluation in list) dbContext.Evaluation.Remove(evaluation);
                    dbContext.SaveChanges();
                }
            }
        }
        public void Update(Evaluation evaluation)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingEvaluation = dbContext.Evaluation.FirstOrDefault(t => t.IdEvaluation == evaluation.IdEvaluation);

                if (existingEvaluation != null)
                {
                    existingEvaluation.Content = evaluation.Content;
                    existingEvaluation.Contribute = evaluation.Contribute;
                    existingEvaluation.Scores = evaluation.Scores;
                    existingEvaluation.Created = evaluation.Created;
                    existingEvaluation.IsEvaluated = evaluation.IsEvaluated;

                    dbContext.SaveChanges();

                    MessageBox.Show("You have successfully evaluated!", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

    }
}

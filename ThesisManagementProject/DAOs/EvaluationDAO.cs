using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public Evaluation SelectOnly(string idTask, string idPeople)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingEvaluation = dbContext.Evaluation.FirstOrDefault(e => e.IdTask == idTask && e.IdPeople == idPeople);

                if (existingEvaluation != null) return existingEvaluation;
                return new Evaluation();
            }
        }
        public Evaluation  SelectOnlyByID(string idEvaluation)
        {
            using (var dbContext = new AppDbContext())
            {
                var evaluation = dbContext.Evaluation.FirstOrDefault(e => e.IdEvaluation == idEvaluation);
                if (evaluation != null)
                {
                    return evaluation;
                }
                else
                {
                    return new Evaluation();
                }
            }
        }
        #endregion

        #region EVALUATION DAO EXECUTION

        public void Insert(Evaluation evaluation)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Evaluation.Add(evaluation);
                dbContext.SaveChanges();
            }
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

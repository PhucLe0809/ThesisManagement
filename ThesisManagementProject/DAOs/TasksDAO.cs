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
    internal class TasksDAO : DBConnection
    {
        public TasksDAO() { }

        #region SELECT TASKS

        public List<Tasks> SelectListByTeam(string idTeam)
        {
            using (var dbContext = new AppDbContext())
            {
                var listTasks = dbContext.Task.Where(t => t.IdTeam == idTeam).OrderByDescending(t => t.Created).ToList();

                if (listTasks != null)
                {
                    return listTasks;
                }
                return new List<Tasks>();
            }
        }
        public Tasks SelectOnly(string idTask)
        {
            using (var dbContext = new AppDbContext())
            {
                var task = dbContext.Task.FirstOrDefault(t => t.IdTask == idTask);
                if (task != null)
                {
                    return task;
                }
                return new Tasks();
            }
        }
        public Tasks SelectFromComment(string idComment)
        {
            CommentDAO commentDAO = new CommentDAO();
            Comment comment = commentDAO.SelectOnlyByID(idComment);
            using (var dbContext = new AppDbContext())
            {
                var task = dbContext.Task.FirstOrDefault(t => t.IdTask.Equals(comment.IdTask));
                if (task != null)
                {
                    return task;
                }
                return new Tasks();
            }
        }
        public Tasks SelectFromEvaluation(string idEvaluation)
        {
            EvaluationDAO evaluationDao = new EvaluationDAO();
            Evaluation evaluation = evaluationDao.SelectOnlyByID(idEvaluation);
            using (var dbContext = new AppDbContext())
            {
                var task = dbContext.Task.FirstOrDefault(t => t.IdTask.Equals(evaluation.IdTask));
                if (task != null)
                {
                    return task;
                }
                return new Tasks();
            }
        }

        #endregion

        #region TASK DAO EXECUTION

        public void Insert(Tasks tasks)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Task.Add(tasks);
                dbContext.SaveChanges();
            }
        }
        public void Delete(Tasks tasks)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Task.Remove(tasks);
                dbContext.SaveChanges();
            }
        }
        public void Update(Tasks tasks)
        {
            using (var dbContext = new AppDbContext())
            {
                var exixtingTask = dbContext.Task.FirstOrDefault(t => t.IdTask == tasks.IdTask);

                if (exixtingTask != null)
                {
                    exixtingTask.Title = tasks.Title;
                    exixtingTask.Description = tasks.Description;
                    exixtingTask.IdCreator = tasks.IdCreator;   
                    exixtingTask.IdTeam = tasks.IdTeam; 
                    exixtingTask.IsFavorite = tasks.IsFavorite;
                    exixtingTask.Progress = tasks.Progress;
                    exixtingTask.Created = tasks.Created;

                    dbContext.SaveChanges();
                }
            }
        }
        public void UpdateIsFavorite(Tasks tasks)
        {
            using (var dbContext = new AppDbContext())
            {
                var exixtingTask = dbContext.Task.FirstOrDefault(t => t.IdTask == tasks.IdTask);

                if (exixtingTask != null)
                {
                    exixtingTask.IsFavorite = tasks.IsFavorite;

                    dbContext.SaveChanges();
                }
            }
        }
        public List<Tasks> SearchTaskTitle(string idTeam, string title)
        {
            using (var dbContext = new AppDbContext())
            {
                var listTasks = dbContext.Task
                    .Where(t => t.IdTeam == idTeam && t.Title.StartsWith(title))
                    .OrderByDescending(t => t.Created)
                    .ToList();

                return listTasks;
            }
        }

        #endregion

    }
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Database
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        public DBConnection() { }

        #region with DATATABLE

        public DataTable Select(string command)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format(command);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable listObject = new DataTable();
                adapter.Fill(listObject);
                return listObject;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return new DataTable();
        }

        #endregion
        
        #region with EXECUTE QUERY

        protected void ExecuteQuery(string sqlStr, string typeExecution, bool flag)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0 && flag)
                {
                    MessageBox.Show(typeExecution + " successfully", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(typeExecution + " failed" + ex, "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void ExecuteQueryThesis(Thesis thesis, string command, string typeExecution, bool flag)
        {
            string sqlStr = string.Format(command, MyDatabase.DBThesis,
                thesis.IdThesis, thesis.Topic, thesis.Field.ToString(), thesis.Level.ToString(),
                thesis.MaxMembers, thesis.Description, thesis.PublishDate.ToString(), thesis.Technology, thesis.Functions, thesis.Requirements,
                thesis.IdCreator, thesis.IsFavorite ? 1 : 0, thesis.Status, thesis.IdInstructor);

            ExecuteQuery(sqlStr, typeExecution, flag);
        }
        protected void ExecuteQueryPeople(People people, string command, string typeExecution, bool flag)
        {
            string sqlStr = string.Format(command, MyDatabase.DBAccount,
                people.IdAccount, people.FullName, people.CitizenCode, people.Birthday.ToString("yyyy-MM-dd"), people.Gender.ToString(),
                people.Email, people.PhoneNumber, people.Handle, people.Role.ToString(), people.University, people.Faculty,
                people.WorkCode, people.Password, people.AvatarName);

            ExecuteQuery(sqlStr, typeExecution, flag);
        }
        protected void ExecuteQueryTask(Tasks tasks, string command, string typeExecution, bool flag)
        {
            string sqlStr = string.Format(command, MyDatabase.DBTask,
                tasks.IdTask, tasks.Title, tasks.Description, tasks.IdCreator, tasks.IdTeam, tasks.IsFavorite ? 1 : 0,
                tasks.Progress, tasks.CreatedDate.ToString("yyyy-MM-dd hh:mm:ss"));

            ExecuteQuery(sqlStr, typeExecution, flag);
        }
        protected void ExecuteQueryComment(Comment comment, string command, string typeExecution, bool flag)
        {
            string sqlStr = string.Format(command, MyDatabase.DBComment, 
                comment.IdComment, comment.IdTask, comment.IdCreator, comment.Content, comment.Emoji, comment.Created.ToString("yyyy-MM-dd hh:mm:ss"));

            ExecuteQuery(sqlStr, typeExecution, flag);
        }
        protected void ExecuteQueryEvaluation(Evaluation evaluation, string command, string typeExecution, bool flag)
        {
            string sqlStr = string.Format(command, MyDatabase.DBEvaluation,
                evaluation.IdEvaluation, evaluation.IdTask, evaluation.IdPeople, evaluation.Content, evaluation.Contribute,
                evaluation.Scores, evaluation.Created.ToString("yyyy-MM-dd hh:mm:ss"), evaluation.IsEvaluated ? 1 : 0);

            ExecuteQuery(sqlStr, typeExecution, flag);
        }
        protected void ExecuteQueryNotification(Notification notifi, string command, string typeExecution, bool flag)
        {
            string sqlStr = string.Format(command, MyDatabase.DBNotification,
                notifi.IdNotification, notifi.IdHost, notifi.IdSender, notifi.IdObject, notifi.Content, notifi.Type.ToString(),
                notifi.Created.ToString("yyyy-MM-dd hh:mm:ss"), notifi.IsFavorite ? 1 : 0, notifi.IsSaw ? 1 : 0);

            ExecuteQuery(sqlStr, typeExecution, flag);
        }

        #endregion

        #region SQL Execute by Command

        protected void SQLExecuteByCommand(string command)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format(command);

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL command failed" + ex, "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region SQL Check Exist

        protected bool SQLCheckNonExist(string command)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format(command);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable listObject = new DataTable();
                adapter.Fill(listObject);
                return listObject.Rows.Count == 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

    }
}

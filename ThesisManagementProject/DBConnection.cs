using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ThesisManagementProject
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        public DBConnection() { }

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

        public void QueryThesis(Thesis thesis, string command, string typeExecution)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format(command,
                    thesis.IdThesis, thesis.Topic, thesis.Field.ToString(), thesis.Level.ToString(),
                    thesis.MaxMembers, thesis.Description, thesis.Reference, thesis.PublishDate.ToString(), thesis.Technology, thesis.Functions, thesis.Requirements, 
                    thesis.IdCreator, (thesis.IsFavorite)?(1):(0), thesis.NumPending, thesis.NumAccepted, thesis.NumCompleted);

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
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

        public void SQLByCommand(string command)
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
    }
}

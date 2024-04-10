using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Database
{
    internal class CommentDAO
    {
        DBConnection DBConnection = new DBConnection();

        public CommentDAO() { }
        public void SQLExecuteByCommand(string command)
        {
            DBConnection.SQLExecuteByCommand(command);
        }

        #region SELECT COMMENT

        public List<Comment> SelectList(string command)
        {
            DataTable dataTable = DBConnection.Select(command);

            List<Comment> list = new List<Comment>();
            foreach (DataRow row in dataTable.Rows)
            {
                Comment comment = SelectOnly(row["idcomment"].ToString());
                list.Add(comment);
            }

            return list;
        }
        public Comment SelectOnly(string idComment)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select(string.Format("SELECT * FROM {0} WHERE idcomment = '{1}'", MyDatabase.DBComment, idComment));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Comment();
        }

        #endregion

        #region COMMENT DAO EXECUTION

        public void Insert(Comment comment)
        {
            DBConnection.ExecuteQueryComment(comment, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                "Create", false);
        }
        public void Delete(Comment comment)
        {
            DBConnection.ExecuteQueryComment(comment, "DELETE FROM {0} WHERE idcomment = '{1}'",
                "Delete", false);
        }
        public void Update(Comment comment)
        {
            DBConnection.ExecuteQueryComment(comment, "UPDATE {0} SET " +
                "idcomment = '{1}', idtask = '{2}', idcreator = '{3}', content = '{4}', emoji = '{5}', created = '{6}' " +
                "WHERE idcomment = '{1}'",
                "Update", false);
        }

        #endregion

        #region Get Comment From Data Row

        public Comment GetFromDataRow(DataRow row)
        {
            string idComment = row["idcomment"].ToString();
            string idTask = row["idtask"].ToString();
            string idCreator = row["idcreator"].ToString();
            string content = row["content"].ToString();
            string emoji = row["emoji"].ToString();
            DateTime created = DateTime.Parse(row["created"].ToString());

            Comment comment = new Comment(idComment, idTask, idCreator, content, emoji, created);
            return comment;
        }

        #endregion

    }
}

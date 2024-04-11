using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Database
{
    internal class CommentDAO : DBConnection
    {

        public CommentDAO() { }

        #region SELECT COMMENT

        public List<Comment> SelectList(string command)
        {
            DataTable dataTable = Select(command);

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
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idcomment = '{1}'", MyDatabase.DBComment, idComment));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Comment();
        }

        #endregion

        #region COMMENT DAO EXECUTION

        public void Insert(Comment comment)
        {
            ExecuteQueryComment(comment, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                "Create", false);
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

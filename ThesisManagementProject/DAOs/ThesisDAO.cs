using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.DAOs
{
    internal class ThesisDAO : DBConnection
    {
        private MyProcess myProcess = new MyProcess();

        public ThesisDAO() { }

        #region SELECT THESIS

        public List<Thesis> SelectList(string command)
        {
            DataTable dataTable = Select(command);

            List<Thesis> list = new List<Thesis>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(GetFromDataRow(row));
            }

            return list;
        }
        public Thesis SelectOnly(string idThesis)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idthesis = '{1}'", MyDatabase.DBThesis, idThesis));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Thesis();
        }
        public Thesis SelectFollowTeam(string idTeam)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idteam = '{1}'", MyDatabase.DBThesisStatus, idTeam));

            if (dt.Rows.Count > 0) return SelectOnly(dt.Rows[0]["idthesis"].ToString());
            return new Thesis();
        }

        #endregion

        #region SELECT THESIS FOLLOW ROLE

        public List<Thesis> SelectListRoleLecture(string idAccount)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idinstructor = '{1}'", MyDatabase.DBThesis, idAccount);
            return SelectList(command);
        }
        public List<Thesis> SelectListRoleStudent(string idAccount)
        {
            string command = string.Format("SELECT * FROM {0} WHERE status IN ('Published', 'Registered') " +
                                           "AND NOT EXISTS(SELECT 1 FROM {1} WHERE {1}.idthesis = {0}.idthesis " +
                                           "AND idteam IN (SELECT idteam FROM {2} WHERE idaccount = '{3}'))",
                                           MyDatabase.DBThesis, MyDatabase.DBThesisStatus, MyDatabase.DBTeam, idAccount);
            return SelectList(command);
        }
        public List<Thesis> SelectListModeMyTheses(string idAccount)
        {
            string command = string.Format("SELECT {0}.* FROM {0} INNER JOIN {1} ON {0}.idthesis = {1}.idthesis " +
                                           "WHERE {1}.idteam IN (SELECT idteam FROM {2} WHERE idaccount = '{3}')",
                                            MyDatabase.DBThesis, MyDatabase.DBThesisStatus, MyDatabase.DBTeam, idAccount);
            return SelectList(command);
        }

        #endregion

        #region SEARCH THESIS

        public List<Thesis> SearchRoleLecture(string idAccount, string topic)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idinstructor = '{1}' and topic LIKE '{2}%'",
                                MyDatabase.DBThesis, idAccount, topic);
            return SelectList(command);

        }
        public List<Thesis> SearchRoleStudent(string topic)
        {
            string command = string.Format("SELECT * FROM {0} WHERE status IN ('{1}', '{2}') and topic LIKE '{3}%'",
                                    MyDatabase.DBThesis, EThesisStatus.Published.ToString(), EThesisStatus.Registered.ToString(), topic);
            return SelectList(command);

        }

        #endregion

        #region THESIS DAO EXECUTION

        public void Insert(Thesis thesis)
        {
            ExecuteQueryThesis(thesis, "INSERT INTO {0} " +
                "VALUES ('{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', {12}, '{13}', '{14}')",
                "Create", true);
        }
        public void Delete(Thesis thesis)
        {
            ExecuteQueryThesis(thesis, "DELETE FROM {0} WHERE idthesis = '{1}'",
                "Delete", false);
        }
        public void Update(Thesis thesis)
        {
            ExecuteQueryThesis(thesis, "UPDATE {0} SET " +
                "idthesis = '{1}', topic = '{2}', field = '{3}', tslevel = '{4}', maxmembers = {5}, " +
                "description = '{6}', publishdate = '{7}', technology = '{8}', functions = '{9}', requirements = '{10}', " +
                "idcreator = '{11}', isfavorite = {12}, status = '{13}', idinstructor = '{14}' WHERE idthesis = '{1}'",
                "Update", false);
        }
        public void UpdateStatus(Thesis thesis, EThesisStatus status)
        {
            string command = string.Format("UPDATE {0} SET status = '{1}' WHERE idthesis = '{2}'",
                                                MyDatabase.DBThesis, status.ToString(), thesis.IdThesis);
            SQLExecuteByCommand(command);
        }
        public void UpdateFavorite(Thesis thesis)
        {
            string command = string.Format("UPDATE {0} SET isfavorite = {1} WHERE idthesis = '{2}'",
                                                MyDatabase.DBThesis, thesis.IsFavorite ? 1 : 0, thesis.IdThesis);
            SQLExecuteByCommand(command);
        }

        #endregion

        #region Get Thesis From Data Row

        public Thesis GetFromDataRow(DataRow row)
        {
            string idThesis = row["idthesis"].ToString();
            string topic = row["topic"].ToString();
            EField field = myProcess.GetEnumFromDisplayName<EField>(row["field"].ToString());
            ELevel level = myProcess.GetEnumFromDisplayName<ELevel>(row["tslevel"].ToString());
            int maxMembers = int.Parse(row["maxmembers"].ToString());
            string description = row["description"].ToString();
            DateTime publishDate = DateTime.Parse(row["publishdate"].ToString());
            string technology = row["technology"].ToString();
            string functions = row["functions"].ToString();
            string requirements = row["requirements"].ToString();
            string idCreator = row["idcreator"].ToString();
            bool isFavorite = row["isfavorite"].ToString() == "True" ? true : false;
            EThesisStatus status = myProcess.GetEnumFromDisplayName<EThesisStatus>(row["status"].ToString());
            string idInstructor = row["idinstructor"].ToString();

            Thesis thesis = new Thesis(idThesis, topic, field, level, maxMembers, description, publishDate, technology,
                                        functions, requirements, idCreator, isFavorite, status, idInstructor);
            return thesis;
        }

        #endregion

    }
}

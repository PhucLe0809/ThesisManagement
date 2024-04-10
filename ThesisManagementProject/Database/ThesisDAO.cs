using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Database
{
    internal class ThesisDAO
    {
        private MyProcess myProcess = new MyProcess();
        DBConnection DBConnection = new DBConnection();

        public ThesisDAO() { }

        public void SQLExecuteByCommand(string command)
        {
            DBConnection.SQLExecuteByCommand(command);
        }

        #region SELECT THESIS

        public List<Thesis> SelectList(string command)
        {
            DataTable dataTable = DBConnection.Select(command);

            List<Thesis> list = new List<Thesis>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(GetFromDataRow(row));
            }

            return list;
        }
        public Thesis SelectOnly(string idThesis)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select(string.Format("SELECT * FROM {0} WHERE idthesis = '{1}'", MyDatabase.DBThesis, idThesis));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Thesis();
        }

        #endregion

        #region THESIS DAO EXECUTION

        public void Insert(Thesis thesis)
        {
            DBConnection.ExecuteQueryThesis(thesis, "INSERT INTO {0} " +
                "VALUES ('{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', {12}, '{13}', '{14}')",
                "Create", true);
        }
        public void Delete(Thesis thesis)
        {
            DBConnection.ExecuteQueryThesis(thesis, "DELETE FROM {0} WHERE idthesis = '{1}'",
                "Delete", false);
        }
        public void Update(Thesis thesis)
        {
            DBConnection.ExecuteQueryThesis(thesis, "UPDATE {0} SET " +
                "idthesis = '{1}', topic = '{2}', field = '{3}', tslevel = '{4}', maxmembers = {5}, " +
                "description = '{6}', publishdate = '{7}', technology = '{8}', functions = '{9}', requirements = '{10}', " +
                "idcreator = '{11}', isfavorite = {12}, status = '{13}', idinstructor = '{14}' WHERE idthesis = '{1}'",
                "Update", false);
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

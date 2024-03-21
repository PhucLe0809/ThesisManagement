using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ThesisManagementProject
{
    public enum EThesisStatus
    {
        Pending,
        Accepted,
        Completed
    }

    internal class ThesisDAO
    {
        DBConnection DBConnection = new DBConnection();

        public ThesisDAO() { }

        public void SQLByCommand(string command)
        {
            DBConnection.SQLByCommand(command);
        }
        public List<Thesis> Select()
        {
            DataTable dataTable = DBConnection.Select("SELECT * FROM " + MyDatabase.DBThesis);

            List<Thesis> list = new List<Thesis>();
            foreach (DataRow row in dataTable.Rows) 
            {
                list.Add(MyProcess.GetThesisFromDataRow(row));
            }

            return list;
        }

        public void Insert(Thesis thesis)
        {
            DBConnection.QueryThesis(thesis, "INSERT INTO " + MyDatabase.DBThesis + 
                " VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', {12}, {13}, {14}, {15})",
                "Create");
        }
        public void Delete(Thesis thesis)
        {
            DBConnection.QueryThesis(thesis, "DELETE FROM " + MyDatabase.DBThesis + " WHERE idthesis = '{0}'",
                "Delete");
        }
        public void Update(Thesis thesis)
        {
            DBConnection.QueryThesis(thesis, "UPDATE " + MyDatabase.DBThesis +
                " SET " + 
                "idthesis = '{0}', topic = '{1}', field = '{2}', tslevel = '{3}', maxmembers = {4}, " +
                "description = '{5}', reference = '{6}', publishdate = '{7}', technology = '{8}', functions = '{9}', requirements = '{10}', " +
                "idcreator = '{11}', isfavorite = {12}, pending = {13}, accepted = {14}, completed = {15} WHERE idthesis = '{0}'",
                "Update");
        }

        public List<Student> SelectByStatus(string status, string idthesis)
        {
            DataTable dataTable = DBConnection.Select("select * from " +
                "(select idaccount as idstudent from ThesisStatus where sta = '" + status + "' and idthesis = '" + idthesis + "') as Q " +
                "inner join (select * from Account where role = 'Student') as R on q.idstudent = r.idaccount");

            List<Student> list = new List<Student>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(MyProcess.GetStudentFromDataRow(row));
            }

            return list;

        }
        public void PendingToAccepted(string command)
        {
            DBConnection.SQLByCommand(command);
        }
    }
}

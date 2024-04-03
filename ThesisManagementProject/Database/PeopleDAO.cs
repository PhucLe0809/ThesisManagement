using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Database
{
    internal class PeopleDAO
    {
        private MyProcess myProcess = new MyProcess();
        DBConnection DBConnection = new DBConnection();

        public PeopleDAO() { }

        public void SQLExecuteByCommand(string command)
        {
            DBConnection.SQLExecuteByCommand(command);
        }

        #region SELECT PEOPLE

        public List<People> SelectList()
        {
            DataTable dataTable = DBConnection.Select(string.Format("SELECT * FROM {0}", MyDatabase.DBAccount));

            List<People> list = new List<People>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(GetFromDataRow(row));
            }

            return list;
        }
        public List<People> SelectList(string command)
        {
            DataTable dataTable = DBConnection.Select(command);

            List<People> list = new List<People>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(GetFromDataRow(row));
            }

            return list;
        }
        public List<People> SelectListByStatus(string status, string idthesis)
        {
            DataTable dataTable = DBConnection.Select("select * from " +
                "(select idaccount as idstudent from ThesisStatus where sta = '" + status + "' and idthesis = '" + idthesis + "') as Q " +
                "inner join (select * from Account where role = 'Student') as R on q.idstudent = r.idaccount");

            List<People> list = new List<People>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(GetFromDataRow(row));
            }

            return list;

        }
        public People SelectOnlyByID(string id)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select(string.Format("SELECT * FROM {0} WHERE idaccount = '{1}'", MyDatabase.DBAccount, id));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return null;
        }
        public People SelectOnlyByEmailAndPassword(string email, string password)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select(string.Format("SELECT * FROM {0} WHERE email = '{1}' and password = '{2}'",
                                        MyDatabase.DBAccount, email, password));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return null;
        }

        #endregion

        #region Get From Data Row

        public People GetFromDataRow(DataRow row)
        {
            string idaccount = row["idaccount"].ToString();
            string fullname = row["fullname"].ToString();
            string citizenCode = row["citizencode"].ToString();
            DateTime birthday = DateTime.Parse(row["birthday"].ToString());
            EGender gender = myProcess.GetEnumFromDisplayName<EGender>(row["gender"].ToString());
            string email = row["email"].ToString();
            string phoneNumber = row["phonenumber"].ToString();
            string handle = row["handle"].ToString();
            ERole role = myProcess.GetEnumFromDisplayName<ERole>(row["role"].ToString());
            string workCode = row["workcode"].ToString();
            string password = row["password"].ToString();
            string avatarName = row["avatarname"].ToString();

            People people = new People(idaccount, fullname, citizenCode, birthday, gender,
                                        email, phoneNumber, handle, role, workCode, password, avatarName);

            return people;
        }

        #endregion

    }
}

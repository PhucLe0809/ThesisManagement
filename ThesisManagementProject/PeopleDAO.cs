using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject
{
    internal class PeopleDAO
    {
        DBConnection DBConnection = new DBConnection();

        public PeopleDAO() { }

        public void SQLByCommand(string command)
        {
            DBConnection.SQLByCommand(command);
        }
        public List<People> Select()
        {
            DataTable dataTable = DBConnection.Select("SELECT * FROM " + MyDatabase.DBPeople);

            List<People> list = new List<People>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(MyProcess.GetStudentFromDataRow(row));
            }

            return list;
        }
    }
}

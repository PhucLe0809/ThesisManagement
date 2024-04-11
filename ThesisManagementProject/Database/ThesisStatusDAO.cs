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
    internal class ThesisStatusDAO : DBConnection
    {
        public ThesisStatusDAO() { }

        public void Insert(Thesis thesis, Team team)
        {
            string command = string.Format("INSERT INTO {0} VALUES('{1}', '{2}', '{3}')",
                                            MyDatabase.DBThesisStatus, team.IDTeam, thesis.IdThesis, thesis.Status.ToString());
            SQLExecuteByCommand(command);
        }
        public void UpdateThesisStatus(string idPeople, string idThesis)
        {
            string command = string.Format("UPDATE {0} SET status = '{1}' where idteam = '{2}' and idthesis = '{3}'",
                        MyDatabase.DBThesisStatus, EThesisStatus.Processing.ToString(), idPeople, idThesis);
            SQLExecuteByCommand(command);

        }
    }
}

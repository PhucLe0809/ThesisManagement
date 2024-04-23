using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.DAOs
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
        public void DeleteListTeam(List<Team> listTeam, string idThesis)
        {
            foreach (Team teamLine in listTeam)
            {
                string command = string.Format("DELETE FROM {0} WHERE idteam = '{1}' AND idthesis = '{2}'",
                                    MyDatabase.DBThesisStatus, teamLine.IDTeam, idThesis);
                ExecuteQuery(command, "Delete", false);
            }
        }
        public int CountTeamFollowState(Thesis thesis)
        {
            string command = string.Format("SELECT count(*) as NumTeams FROM {0} WHERE idthesis = '{1}' and status = '{2}'",
                                            MyDatabase.DBThesisStatus, thesis.IdThesis, thesis.Status.ToString());
            DataTable table = Select(command);
            int num = 0;
            int.TryParse(table.Rows[0]["NumTeams"].ToString(), out num);
            return num;
        }
        public string SelectTeamByIdThesis(string idThesis)
        {
            string command = $"SELECT idteam " +
                             $"FROM {MyDatabase.DBThesisStatus} " +
                             $"WHERE idthesis = '{idThesis}'";
            DataTable table = Select(command);
            return table.Rows[0]["idteam"].ToString();

        }
        public void UpdateThesisStatus(string idPeople, string idThesis)
        {
            string command = string.Format("UPDATE {0} SET status = '{1}' where idteam = '{2}' and idthesis = '{3}'",
                        MyDatabase.DBThesisStatus, EThesisStatus.Processing.ToString(), idPeople, idThesis);
            SQLExecuteByCommand(command);
        }
    }
}

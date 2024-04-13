using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.DAOs
{
    internal class TeamDAO : DBConnection
    {
        public TeamDAO() { }

        #region SELECT TEAM

        public List<Team> SelectList(string idThesis)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idthesis = '{1}'", MyDatabase.DBThesisStatus, idThesis);

            DataTable dataTable = Select(command);

            List<Team> list = new List<Team>();
            foreach (DataRow row in dataTable.Rows)
            {
                Team team = SelectOnly(row["idteam"].ToString());
                list.Add(team);
            }

            return list;
        }
        public Team SelectOnly(string idTeam)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idteam = '{1}'", MyDatabase.DBTeam, idTeam));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Team();
        }
        public Team SelectFollowThesis(Thesis thesis)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idthesis = '{1}' and status = '{2}'",
                                            MyDatabase.DBThesisStatus, thesis.IdThesis, thesis.Status.ToString());

            DataTable table = Select(command);
            return SelectOnly(table.Rows[0]["idteam"].ToString());
        }

        #endregion

        #region TEAM DAO EXECUTION

        public void Insert(Team team)
        {
            foreach (People member in team.Members)
            {
                string command = string.Format("INSERT INTO {0} VALUES('{1}', '{2}', '{3}', '{4}', '{5}')",
                                            MyDatabase.DBTeam, team.IDTeam, member.IdAccount, team.TeamName, team.Created, team.AvatarName);
                SQLExecuteByCommand(command);
            }
        }
        public void Delete(List<Team> listTeam, string idThesis)
        {
            string command;
            foreach (Team teamLine in listTeam)
            {
                command = string.Format("DELETE FROM {0} WHERE idteam = '{1}' AND idthesis = '{2}'",
                                    MyDatabase.DBThesisStatus, teamLine.IDTeam, idThesis);
                ExecuteQuery(command, "Delete", false);
            }
        }

        #endregion

        #region Get Members by ID Team

        private List<People> GetMembersByIDTeam(string idTeam)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idteam = '{1}'", MyDatabase.DBTeam, idTeam);
            DataTable dataTable = Select(command);

            PeopleDAO peopleDAO = new PeopleDAO();
            List<People> list = new List<People>();
            foreach (DataRow row in dataTable.Rows)
            {
                People people = peopleDAO.SelectOnlyByID(row["idaccount"].ToString());
                list.Add(people);
            }

            return list;
        }

        #endregion

        #region Get Team From Data Row

        public Team GetFromDataRow(DataRow row)
        {
            string idTeam = row["idteam"].ToString();
            string teamName = row["name"].ToString();
            DateTime created = DateTime.Parse(row["created"].ToString());
            string avatarName = row["avatarname"].ToString();
            List<People> members = GetMembersByIDTeam(idTeam);

            Team team = new Team(idTeam, teamName, avatarName, created, members);
            return team;
        }

        #endregion

    }
}

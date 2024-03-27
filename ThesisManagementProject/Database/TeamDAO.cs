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
    internal class TeamDAO
    {
        DBConnection DBConnection = new DBConnection();

        public TeamDAO() { }

        #region SELECT TEAM

        public List<Team> SelectList(string command)
        {
            DataTable dataTable = DBConnection.Select(command);

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
            DBConnection db = new DBConnection();
            DataTable dt = db.Select(string.Format("SELECT * FROM {0} WHERE idteam = '{1}'", MyDatabase.DBTeam, idTeam));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Team();
        }

        #endregion

        #region Get Members by ID Team

        private List<People> GetMembersByIDTeam(string idTeam)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idteam = '{1}'", MyDatabase.DBTeam, idTeam);
            DataTable dataTable = DBConnection.Select(command);

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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Entity;
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
            using (var dbContext = new AppDbContext())
            {
                var team = dbContext.Team.FirstOrDefault(t => t.IdTeam == idTeam);
                if (team != null)
                { 
                    return team; 
                }
                return new Team();
            }
        }
        public Team SelectFollowThesis(Thesis thesis)
        {
            ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
            ThesisStatus thesisStatus = thesisStatusDAO.SelectFollowThesis(thesis);
            return SelectOnly(thesisStatus.IdTeam);
        }
        public List<Team> SelectFollowPeople(People people)
        {
            using (var dbContext = new AppDbContext())
            {
                var listTeam = dbContext.Team.Where(t => t.Members.Contains(people)).ToList();
                if (listTeam != null) return listTeam;
                return new List<Team>();
            }
        }

        #endregion

        #region TEAM DAO EXECUTION

        public void Insert(Team team)
        {
            using (var dbContext = new AppDbContext()) 
            {
                dbContext.Team.Add(team);
                dbContext.SaveChanges();
            }
        }
        public void Delete(Team team)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Team.Remove(team);
                dbContext.SaveChanges();
            }
        }
        public void DeleteListTeam(List<Team> teams)
        {
            foreach (Team team in teams) Delete(team);
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

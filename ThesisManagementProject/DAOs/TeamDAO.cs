using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.DAOs
{
    internal class TeamDAO
    {
        public TeamDAO() { }

        #region SELECT TEAM

        public List<Team> SelectList(string idThesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var listThesisStatus = dbContext.ThesisStatus.Where(t => t.IdThesis == idThesis).ToList();
                
                if (listThesisStatus != null)
                {
                    List<Team> teams = new List<Team>();
                    for (int i = 0; i < listThesisStatus.Count; i++)
                    {
                        teams.Add(SelectOnly(listThesisStatus[i].IdTeam));
                    }
                    return teams;
                }
                return new List<Team>();
            }
        }
        public Team SelectOnly(string idTeam)
        {
            using (var dbContext = new AppDbContext())
            {
                var members = dbContext.Member.Where(m => m.IdTeam == idTeam).ToList();

                if (members != null)
                {
                    PeopleDAO peopleDAO = new PeopleDAO();
                    List<People> peoples = new List<People>();
                    foreach (var person in members)
                    {
                        peoples.Add(peopleDAO.SelectOnlyByID(person.IdAccount));
                    }

                    return new Team(idTeam, members[0].Name, members[0].AvatarName, members[0].Created, peoples);
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
                var listTeam = dbContext.Member.Where(t => t.IdAccount == people.IdAccount).ToList();
                if (listTeam != null)
                {
                    List<Team> teams = new List<Team>();
                    foreach (var team in listTeam)
                    {
                        teams.Add(SelectOnly(team.IdTeam)); 
                    }
                    return teams;
                }
                return new List<Team>();
            }
        }

        #endregion

        #region TEAM DAO EXECUTION

        public void Insert(Team team)
        {
            using (var dbContext = new AppDbContext())
            {
                foreach (var member in team.Members)
                {
                    Member person = new Member(team.IdTeam, member.IdAccount, team.Name, team.Created, team.AvatarName);
                    dbContext.Member.Add(person);
                }
                dbContext.SaveChanges();
            }
        }
        public void Delete(Team team)
        {
            using (var dbContext = new AppDbContext())
            {
                foreach (var member in team.Members)
                {
                    Member person = new Member(team.IdTeam, member.IdAccount, team.Name, team.Created, team.AvatarName);
                    dbContext.Member.Remove(person);
                }
                dbContext.SaveChanges();
            }
        }
        public void DeleteListTeam(List<Team> teams)
        {
            foreach (Team team in teams) Delete(team);
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThesisManagementProject.Database;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject.DAOs
{
    internal class ThesisStatusDAO : DBConnection
    {
        public ThesisStatusDAO() { }

        public string SelectTeamByIdThesis(string idThesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesisStatus = dbContext.ThesisStatus.FirstOrDefault(t => t.IdThesis == idThesis);

                if (existingThesisStatus != null)
                {
                    return existingThesisStatus.IdTeam;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public void Insert(Thesis thesis, Team team)
        {
<<<<<<< HEAD
            string command = string.Format("INSERT INTO {0} VALUES('{1}', '{2}', '{3}')",
                                            MyDatabase.DBThesisStatus, team.IdTeam, thesis.IdThesis, thesis.Status.ToString());
            SQLExecuteByCommand(command);
=======
            using (var dbContext = new AppDbContext())
            {
                ThesisStatus thesisStatus = new ThesisStatus(team.IdTeam, thesis.IdThesis, thesis.OnStatus);
                dbContext.ThesisStatus.Add(thesisStatus);
                dbContext.SaveChanges();
            }
        }
        private void Delete(string idTeam, string idThesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesisStatus = dbContext.ThesisStatus.FirstOrDefault(t => t.IdTeam == idTeam && t.IdThesis == idThesis);

                if (existingThesisStatus != null)
                {
                    dbContext.ThesisStatus.Remove(existingThesisStatus);
                    dbContext.SaveChanges();
                }
            }
>>>>>>> 55340cd96e9166acefe353d2e04589f4cdb921f3
        }
        public void DeleteListTeam(List<Team> listTeam, string idThesis)
        {
            foreach (Team teamLine in listTeam)
            {
<<<<<<< HEAD
                string command = string.Format("DELETE FROM {0} WHERE idteam = '{1}' AND idthesis = '{2}'",
                                    MyDatabase.DBThesisStatus, teamLine.IdTeam, idThesis);
                ExecuteQuery(command, "Delete", false);
=======
                Delete(teamLine.IdTeam, idThesis);
            }
        }
        public void UpdateThesisStatus(string idTeam, string idThesis, EThesisStatus status)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesisStatus = dbContext.ThesisStatus.FirstOrDefault(t => t.IdTeam == idTeam && t.IdThesis == idThesis);

                if (existingThesisStatus != null)
                {
                    existingThesisStatus.OnStatus = status;
                    dbContext.SaveChanges();
                }
>>>>>>> 55340cd96e9166acefe353d2e04589f4cdb921f3
            }
        }
        public int CountTeamFollowState(Thesis thesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var list = dbContext.ThesisStatus.Where(t => t.IdThesis == thesis.IdThesis && t.Status == thesis.Status).ToList();
                return list.Count;
            }
        }
        public string SelectThesisByIdTeam(string idTeam)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesisStatus = dbContext.ThesisStatus.FirstOrDefault(t => t.IdTeam == idTeam);

                if (existingThesisStatus != null)
                {
                    return existingThesisStatus.IdThesis;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}

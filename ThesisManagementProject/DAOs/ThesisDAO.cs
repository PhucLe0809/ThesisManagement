using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ThesisManagementProject.Database;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject.DAOs
{
    internal class ThesisDAO : DBConnection
    {
        private MyProcess myProcess = new MyProcess();

        public ThesisDAO() { }

        #region SELECT THESIS

        public List<Thesis> SelectList(string command)
        {
            using (var dbContext = new AppDbContext())
            {
                return FormatList(dbContext.Thesis.ToList());
            }
        }
        public Thesis SelectOnly(string idThesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var thesis = dbContext.Thesis.FirstOrDefault(t => t.IdThesis == idThesis);

                if (thesis != null) return Format(thesis);
                return new Thesis();
            }
        }
        public Thesis SelectFollowTeam(string idTeam)
        {
            using (var dbContext = new AppDbContext())
            {
                ThesisStatusDAO thesisStatusDAO = new ThesisStatusDAO();
                string idThesis = thesisStatusDAO.SelectThesisByIdTeam(idTeam);
                return SelectOnly(idThesis);
            }
        }
        public List<Dictionary<Thesis, int>> GetMaxSubscribers()
        {
            string command = "SELECT idthesis, SUM(SL) AS total_SL " +
                             "FROM ThesisStatus " +
                             "JOIN (SELECT idteam, COUNT(idaccount) AS SL FROM Team GROUP BY idteam) AS Team " +
                             "ON ThesisStatus.idteam = Team.idteam " +
                             "WHERE ThesisStatus.status IN ('Registered', 'Processing', 'Completed') " +
                             "GROUP BY idthesis " +
                             "ORDER BY total_SL DESC";
            DataTable dataTable = Select(command);

            List<Dictionary<Thesis, int>> resultList = new List<Dictionary<Thesis, int>>();

            foreach (DataRow row in dataTable.Rows)
            {
                string idThesis = row["idthesis"].ToString();
                Thesis thesis = SelectOnly(idThesis);
                int total = Convert.ToInt32(row["total_SL"]);
                Dictionary<Thesis, int> resultDict = new Dictionary<Thesis, int>
                {
                    { thesis, total }
                };
                resultList.Add(resultDict);
            }
            return resultList;
        }

        #endregion

        #region SELECT THESIS FOLLOW ROLE

        public List<Thesis> SelectListRoleLecture(string idAccount)
        {
            using (var dbContext = new AppDbContext())
            {
                var theses = dbContext.Thesis.Where(t => t.IdInstructor == idAccount).ToList();
                return FormatList(theses);
            }
        }
        public List<Thesis> SelectListRoleStudent(string idAccount)
        {
            string command = string.Format("SELECT * FROM {0} WHERE status IN ('Published', 'Registered') " +
                                           "AND NOT EXISTS(SELECT 1 FROM {1} WHERE {1}.idthesis = {0}.idthesis " +
                                           "AND idteam IN (SELECT idteam FROM {2} WHERE idaccount = '{3}'))",
                                           MyDatabase.DBThesis, MyDatabase.DBThesisStatus, MyDatabase.DBTeam, idAccount);
            return SelectList(command);
        }
        public List<Thesis> SelectListModeMyTheses(string idAccount)
        {
            string command = string.Format("SELECT {0}.* FROM {0} INNER JOIN {1} ON {0}.idthesis = {1}.idthesis " +
                                           "WHERE {1}.idteam IN (SELECT idteam FROM {2} WHERE idaccount = '{3}')",
                                            MyDatabase.DBThesis, MyDatabase.DBThesisStatus, MyDatabase.DBTeam, idAccount);
            return SelectList(command);
        }
        public List<Thesis> SelectListModeMyCompletedTheses(string idAccount)
        {
            string command = $"SELECT {MyDatabase.DBThesis}.* " +
                             $"FROM {MyDatabase.DBThesis} INNER JOIN {MyDatabase.DBThesisStatus} " +
                             $"ON {MyDatabase.DBThesis}.idthesis = {MyDatabase.DBThesisStatus}.idthesis " +
                             $"WHERE {MyDatabase.DBThesisStatus}.idteam IN (SELECT idteam FROM {MyDatabase.DBTeam} WHERE idaccount = '{idAccount}') " +
                             $"and {MyDatabase.DBThesis}.status = 'Completed'";
            return SelectList(command);
        }

        #endregion

        #region SEARCH THESIS

        public List<Thesis> SearchRoleLecture(string idAccount, string topic)
        {
            using (var dbContext = new AppDbContext())
            {
                return FormatList(dbContext.Thesis.Where(t => t.IdInstructor == idAccount && t.Topic.StartsWith(topic)).ToList());
            }
        }
        public List<Thesis> SearchRoleStudent(string topic)
        {
            using (var dbContext = new AppDbContext())
            {
                var statuses = new List<EThesisStatus> { EThesisStatus.Published, EThesisStatus.Registered };
                return FormatList(dbContext.Thesis.Where(t => statuses.Contains(t.OnStatus) && t.Topic.StartsWith(topic)).ToList());
            }
        }

        #endregion

        #region THESIS DAO EXECUTION

        public void Insert(Thesis thesis)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Thesis.Add(thesis);
                dbContext.SaveChanges();
            }
        }
        public void Delete(Thesis thesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesis = dbContext.Thesis.FirstOrDefault(t => t.IdThesis == thesis.IdThesis);

                if (existingThesis != null)
                {
                    dbContext.Thesis.Remove(existingThesis);
                    dbContext.SaveChanges();
                }
            }
        }

        public void Update(Thesis thesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesis = dbContext.Thesis.FirstOrDefault(t => t.IdThesis == thesis.IdThesis);

                if (existingThesis != null)
                {
                    existingThesis.Topic = thesis.Topic;
                    existingThesis.OnField = thesis.OnField;
                    existingThesis.OnLevel = thesis.OnLevel;
                    existingThesis.MaxMembers = thesis.MaxMembers;
                    existingThesis.Description = thesis.Description;
                    existingThesis.PublishDate = thesis.PublishDate;
                    existingThesis.Technology = thesis.Technology;
                    existingThesis.Functions = thesis.Functions;
                    existingThesis.Requirements = thesis.Requirements;
                    existingThesis.IdCreator = thesis.IdCreator;
                    existingThesis.IsFavorite = thesis.IsFavorite;
                    existingThesis.OnStatus = thesis.OnStatus;
                    existingThesis.IdInstructor = thesis.IdInstructor;

                    dbContext.SaveChanges();
                }
            }
        }
        public void UpdateStatus(Thesis thesis, EThesisStatus status)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesis = dbContext.Thesis.FirstOrDefault(t => t.IdThesis == thesis.IdThesis);

                if (existingThesis != null)
                {
                    existingThesis.OnStatus = status;
                    dbContext.SaveChanges();
                }
            }
        }
        public void UpdateFavorite(Thesis thesis)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingThesis = dbContext.Thesis.FirstOrDefault(t => t.IdThesis == thesis.IdThesis);

                if (existingThesis != null)
                {
                    existingThesis.IsFavorite = thesis.IsFavorite;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion

        #region Get Thesis From Database

        private Thesis Format(Thesis thesis)
        {
            if (thesis == null) return new Thesis();

            EField field = myProcess.GetEnumFromDisplayName<EField>(thesis.Field);
            ELevel level = myProcess.GetEnumFromDisplayName<ELevel>(thesis.Level);
            EThesisStatus status = myProcess.GetEnumFromDisplayName<EThesisStatus>(thesis.Status);

            thesis.OnField = field;
            thesis.OnLevel = level;
            thesis.OnStatus = status;
            return thesis;
        }
        private List<Thesis> FormatList(List<Thesis> theses)
        {
            for (int i = 0; i < theses.Count; i++) theses[i] = Format(theses[i]);
            return theses;
        }

        #endregion 
    }
}

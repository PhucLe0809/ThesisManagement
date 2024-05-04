using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.DAOs
{
    internal class ThesisDAO
    {
        private MyProcess myProcess = new MyProcess();

        public ThesisDAO() { }

        #region SELECT THESIS

        public List<Thesis> SelectList()
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
            using (var dbContext = new AppDbContext())
            {
                var query = from status in dbContext.ThesisStatus
                            join team in dbContext.Member
                            on status.IdTeam equals team.IdTeam into teamGroup
                            from teamGrp in teamGroup.DefaultIfEmpty()
                            where new[] { "Registered", "Processing", "Completed" }.Contains(status.Status)
                            group teamGrp by status.IdThesis into grp
                            orderby grp.Sum(x => x != null ? 1 : 0) descending
                            select new { ThesisId = grp.Key, TotalSubscribers = grp.Sum(x => x != null ? 1 : 0) };

                var resultDictList = new List<Dictionary<Thesis, int>>();

                var theses = dbContext.Thesis.ToList();

                foreach (var item in query)
                {
                    Thesis thesis = theses.FirstOrDefault(t => t.IdThesis == item.ThesisId);
                    if (thesis != null)
                    {
                        Dictionary<Thesis, int> resultDict = new Dictionary<Thesis, int>
                        {
                            { thesis, item.TotalSubscribers }
                        };
                        resultDictList.Add(resultDict);
                    }
                }
                return resultDictList;
            }
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
            using (var dbContext = new AppDbContext())
            {
                var query = from thesis in dbContext.Thesis
                            where new[] { "Published", "Registered" }.Contains(thesis.Status)
                               && !dbContext.ThesisStatus.Any(ts =>
                                    ts.IdThesis == thesis.IdThesis &&
                                    dbContext.Member.Any(t =>
                                        t.IdAccount == idAccount &&
                                        ts.IdTeam == t.IdTeam))
                            select thesis;

                var listTheses = query.ToList();
                return FormatList(listTheses);
            }
        }
        public List<Thesis> SelectListModeMyTheses(string idAccount)
        {
            using (var dbContext = new AppDbContext())
            {
                var query = from thesis in dbContext.Thesis
                            join status in dbContext.ThesisStatus
                            on thesis.IdThesis equals status.IdThesis
                            where dbContext.Member.Any(t =>
                                      t.IdAccount == idAccount &&
                                      status.IdTeam == t.IdTeam)
                            select thesis;

                var listTheses = query.ToList();
                return FormatList(listTheses);
            }
        }
        public List<Thesis> SelectListModeMyThesesByStatus(string idAccount, EThesisStatus eThesisStatus)
        {
            using (var dbContext = new AppDbContext())
            {
                var query = from thesis in dbContext.Thesis
                            join status in dbContext.ThesisStatus
                            on thesis.IdThesis equals status.IdThesis
                            where dbContext.Member.Any(t =>
                                      t.IdAccount == idAccount &&
                                      status.IdTeam == t.IdTeam) &&
                                  thesis.Status == eThesisStatus.ToString()
                            select thesis;

                var listTheses = query.ToList();
                return FormatList(listTheses);
            }
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
        public List<Thesis> FilterByProperty(Func<Thesis, bool> predicate)
        {
            using (var dbContext = new AppDbContext())
            {
                return FormatList(dbContext.Thesis.Where(predicate).ToList());
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

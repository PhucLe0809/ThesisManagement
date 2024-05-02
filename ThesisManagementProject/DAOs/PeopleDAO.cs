using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.DAOs
{
    internal class PeopleDAO : DBConnection
    {
        private MyProcess myProcess = new MyProcess();

        public PeopleDAO() { }

        #region SELECT PEOPLE

        public People SelectOnlyByID(string idPeople)
        {
            using (var dbContext = new AppDbContext())
            {
                var people = dbContext.Account.FirstOrDefault(p => p.IdAccount == idPeople);
                if (people != null) return Format(people);
                return new People();
            }
        }
        public People SelectOnlyByEmailAndPassword(string email, string password)
        {
            using (var dbContext = new AppDbContext())
            {
                var people = dbContext.Account.FirstOrDefault(p => p.Email == email && p.Password == password);
                if (people != null) return Format(people);
                return null;
            }
        }
        public List<People> SelectListByUserName(string username, ERole role)
        {
            using (var dbContext = new AppDbContext())
            {
                return FormatList(dbContext.Account.Where(p => p.OnRole == role && p.Handle.StartsWith(username)).ToList());
            }
        }

        #endregion

        #region SELECT LIST ID PEOPLE

        public List<string> SelectListID(ERole role)
        {
            using (var dbContext = new AppDbContext())
            {
                var listPeople = dbContext.Account.Where(p => p.Role == role.ToString()).ToList();
                
                if (listPeople != null) return listPeople.Select(p => p.IdAccount).ToList();
                return new List<string>();

            }
        }

        #endregion

        #region PEOPLE DAO EXECUTION

        public void Insert(People people)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Account.Add(people);
                dbContext.SaveChanges();
            }
        }
        public void Update(People people)
        {
            using (var dbContext = new AppDbContext())
            {
                var existingPeople = dbContext.Account.FirstOrDefault(p => p.IdAccount == people.IdAccount);

                if (existingPeople != null)
                {
                    existingPeople.FullName = people.FullName;
                    existingPeople.CitizenCode = people.CitizenCode;
                    existingPeople.Birthday = people.Birthday;
                    existingPeople.Gender = people.Gender;
                    existingPeople.Email = people.Email;
                    existingPeople.PhoneNumber = people.PhoneNumber;
                    existingPeople.Handle = people.Handle;
                    existingPeople.Role = people.Role;
                    existingPeople.University = people.University;
                    existingPeople.Faculty = people.Faculty;
                    existingPeople.WorkCode = people.WorkCode;
                    existingPeople.Password = people.Password;
                    existingPeople.AvatarName = people.AvatarName;

                    dbContext.SaveChanges();
                }
            }
        }
        public bool CheckExist(Func<People, bool> condition)
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Account.Any(condition);
            }
        }

        #endregion

        #region Get People From Database

        private People Format(People people)
        {
            if (people == null) return new People();

            EGender gender = myProcess.GetEnumFromDisplayName<EGender>(people.Gender);
            ERole role = myProcess.GetEnumFromDisplayName<ERole>(people.Role);

            people.OnGender = gender;
            people.OnRole = role;
            return people;
        }
        private List<People> FormatList(List<People> peoples)
        {
            for (int i = 0; i < peoples.Count; i++) peoples[i] = Format(peoples[i]);
            return peoples;
        }

        #endregion

    }
}

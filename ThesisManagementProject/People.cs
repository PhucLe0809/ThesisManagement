using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject
{
    #region PEOPLE ENUM
    
    public enum EGender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }
    public enum ERole
    {
        [Display(Name = "Student")]
        Student,
        [Display(Name = "Lecture")]
        Lecture
    }

    #endregion

    public class People
    {
        #region PEOPLE ATTRIBUTES

        protected string idAccount;
        protected string fullName;
        protected string citizenCode;
        protected DateTime birthday;
        protected EGender gender;
        protected string email;
        protected string phoneNumber;
        protected string handle;
        protected ERole role;
        protected string university;
        protected string faculty;
        protected string workCode;
        protected string password;
        protected int numPending;
        protected int numAccepted;
        protected int numCompleted;
        protected int numTeams;

        #endregion

        #region PEOPLE CONTRUCTOR

        public People()
        {
            this.fullName = string.Empty;
            this.citizenCode = string.Empty;
            this.birthday = DateTime.Now;
            this.gender = EGender.Male;
            this.email = string.Empty;
            this.phoneNumber = string.Empty;
            this.handle = string.Empty;
            this.role = ERole.Student;
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = string.Empty;
            this.password = string.Empty;
            this.idAccount = "xxx";
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
            this.numTeams = 0;
        }
        public People(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber, 
                        string handle, ERole role, string workCode, string password, EClassify eClassify)
        {
            this.idAccount = MyProcess.GenIDClassify(eClassify);
            this.fullName = fullName;
            this.citizenCode = citizenCode;
            this.birthday = birthday;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.handle = handle;
            this.role = role;
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = workCode;
            this.password = password;
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
            this.numTeams = 0;
        }
        public People(string idAccount, string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, EClassify eClassify)
        {
            this.idAccount = idAccount;
            this.fullName = fullName;
            this.citizenCode = citizenCode;
            this.birthday = birthday;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.handle = handle;
            this.role = role;
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = workCode;
            this.password = password;
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
            this.numTeams = 0;
        }

        #endregion

        #region PEOPLE PROPERTIES

        public string IdAccount 
        {
            get { return this.idAccount; }
        }
        public string FullName
        {
            get { return this.fullName; }
        }
        public string CitizenCode
        {
            get { return this.citizenCode; }
        }
        public DateTime Birthday
        {
            get { return this.birthday; }
        }
        public EGender Gender
        {
            get { return this.gender; }
        }
        public string Email
        {
            get { return this.email; }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
        }
        public string Handle
        {
            get { return this.handle; }
        }
        public ERole Role
        {
            get { return this.role; }
        }
        public string University
        {
            get { return this.university; }
        }
        public string Faculty
        {
            get { return this.faculty; }
        }
        public string WorkCode
        {
            get { return this.workCode; }
        }
        public string Password
        {
            get { return this.password; }
        }
        public int NumPending
        {
            get { return this.numPending; }
        }
        public int NumAccepted
        {
            get { return this.numAccepted; }
        }
        public int NumCompleted
        {
            get { return this.numCompleted; }
        }
        public int NumTeams
        {
            get { return this.numTeams; }
        }

        #endregion

    }
}

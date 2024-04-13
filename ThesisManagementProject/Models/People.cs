using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Database;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
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
        private MyProcess myProcess = new MyProcess();
        private PeopleDAO peopleDAO = new PeopleDAO();

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
        protected string confirmPassword;
        protected string avatarName;
        protected int numPending;
        protected int numAccepted;
        protected int numCompleted;
        protected int numTeams;

        #endregion

        #region PEOPLE CONTRUCTOR

        public People()
        {
            idAccount = string.Empty;
            fullName = string.Empty;
            citizenCode = string.Empty;
            birthday = DateTime.Now;
            gender = EGender.Male;
            email = string.Empty;
            phoneNumber = string.Empty;
            handle = string.Empty;
            role = ERole.Student;
            university = "HCM City University of Technology and Education";
            faculty = "Faculty of Information Technology";
            workCode = string.Empty;
            password = string.Empty;
            confirmPassword = string.Empty;
            avatarName = "PicAvatarDemoUser";
            numPending = 0;
            numAccepted = 0;
            numCompleted = 0;
            numTeams = 0;
        }
        public People(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, EClassify eClassify)
        {
            this.idAccount = myProcess.GenIDClassify(eClassify);
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
            this.confirmPassword = password;
            this.avatarName = "PicAvatarDemoUser";
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
            this.numTeams = 0;
        }
        public People(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, string confirmPassword, string avatarName, EClassify eClassify)
        {
            this.idAccount = myProcess.GenIDClassify(eClassify);
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
            this.confirmPassword = confirmPassword;
            this.avatarName = avatarName;
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
            this.numTeams = 0;
        }
        public People(string idAccount, string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, string avatarName)
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
            this.avatarName = avatarName;
            this.numPending = 0;
            this.numAccepted = 0;
            this.numCompleted = 0;
            this.numTeams = 0;
        }

        #endregion

        #region PEOPLE PROPERTIES

        public string IdAccount
        {
            get { return idAccount; }
            set { idAccount = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set {  fullName = value; }
        }
        public string CitizenCode
        {
            get { return citizenCode; }
            set { citizenCode = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public EGender Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Handle
        {
            get { return handle; }
            set { handle = value; }
        }
        public ERole Role
        {
            get { return role; }
            set { role = value; }
        }
        public string University
        {
            get { return university; }
            set { university = value; }
        }
        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }
        public string WorkCode
        {
            get { return workCode; }
            set { workCode = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }
        public string AvatarName
        {
            get { return this.avatarName; }
            set { this.avatarName = value; }
        }
        public int NumPending
        {
            get { return numPending; }
        }
        public int NumAccepted
        {
            get { return numAccepted; }
        }
        public int NumCompleted
        {
            get { return numCompleted; }
        }
        public int NumTeams
        {
            get { return numTeams; }
        }

        #endregion

        #region CHECK INFORMATIONS

        public bool CheckFullName()
        {
            return this.fullName != string.Empty;
        }
        public bool CheckCitizenCode()
        {
            return this.citizenCode != string.Empty
                    && peopleDAO.CheckNonExist("citizencode", this.citizenCode);
        }
        public bool CheckBirthday()
        {
            TimeSpan difference = DateTime.Now - this.birthday;
            int age = (int)(difference.TotalDays / 365.25);
            return age >= 18;
        }
        public bool CheckGender()
        {
            return this.gender == EGender.Male || this.gender == EGender.Female;
        }
        public bool CheckEmail()
        {
            return this.email != string.Empty
                    && peopleDAO.CheckNonExist("email", this.email);
        }
        public bool CheckPhoneNumber()
        {
            return this.phoneNumber != string.Empty && this.phoneNumber.All(char.IsDigit)
                    && peopleDAO.CheckNonExist("phonenumber", this.phoneNumber);
        }
        public bool CheckHandle()
        {
            return this.handle != string.Empty
                    && peopleDAO.CheckNonExist("handle", this.handle);
        }
        public bool CheckRole()
        {
            return this.role == ERole.Lecture || this.role == ERole.Student;
        }
        public bool CheckWorkCode()
        {
            return this.workCode != string.Empty
                    && peopleDAO.CheckNonExist("workcode", this.workCode);
        }
        public bool CheckPassWord()
        {
            return this.password != string.Empty && this.password == this.confirmPassword;
        }

        #endregion

    }
}

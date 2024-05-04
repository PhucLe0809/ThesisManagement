using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.DAOs;

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
        protected string gender;
        protected EGender pegender;
        protected string email;
        protected string phoneNumber;
        protected string handle;
        protected string role;
        protected ERole perole;
        protected string university;
        protected string faculty;
        protected string workCode;
        protected string password;
        protected string confirmPassword;
        protected string avatarName;

        #endregion

        #region PEOPLE CONTRUCTOR

        public People()
        {
            this.idAccount = string.Empty;
            this.fullName = string.Empty;
            this.citizenCode = string.Empty;
            this.birthday = DateTime.Now;
            this.pegender = EGender.Male;
            this.gender = this.pegender.ToString();
            this.email = string.Empty;
            this.phoneNumber = string.Empty;
            this.handle = string.Empty;
            this.perole = ERole.Student;
            this.role = this.perole.ToString();
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = string.Empty;
            this.password = string.Empty;
            this.confirmPassword = string.Empty;
            this.avatarName = "PicAvatarDemoUser";
        }
        public People(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, EClassify eClassify)
        {
            this.idAccount = myProcess.GenIDClassify(eClassify);
            this.fullName = fullName;
            this.citizenCode = citizenCode;
            this.birthday = birthday;
            this.pegender = gender;
            this.gender = gender.ToString();
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.handle = handle;
            this.perole = role;
            this.role = role.ToString();
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = workCode;
            this.password = password;
            this.confirmPassword = password;
            this.avatarName = "PicAvatarDemoUser";
        }
        public People(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, string confirmPassword, string avatarName, EClassify eClassify)
        {
            this.idAccount = myProcess.GenIDClassify(eClassify);
            this.fullName = fullName;
            this.citizenCode = citizenCode;
            this.birthday = birthday;
            this.pegender = gender;
            this.gender = gender.ToString();
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.handle = handle;
            this.perole = role;
            this.role = role.ToString();
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = workCode;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.avatarName = avatarName;
        }
        public People(string idAccount, string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password, string avatarName)
        {
            this.idAccount = idAccount;
            this.fullName = fullName;
            this.citizenCode = citizenCode;
            this.birthday = birthday;
            this.pegender = gender;
            this.gender = gender.ToString();
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.handle = handle;
            this.perole = role;
            this.role = role.ToString();
            this.university = "HCM City University of Technology and Education";
            this.faculty = "Faculty of Information Technology";
            this.workCode = workCode;
            this.password = password;
            this.avatarName = avatarName;
        }

        #endregion

        #region PEOPLE PROPERTIES

        [Key]
        public string IdAccount
        {
            get { return idAccount; }
            set { idAccount = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
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
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                pegender = myProcess.GetEnumFromDisplayName<EGender>(gender);
            }
        }
        [NotMapped]
        public EGender OnGender
        {
            get { return pegender; }
            set 
            {
                pegender = value;
                gender = pegender.ToString();
            }
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
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                perole = myProcess.GetEnumFromDisplayName<ERole>(role);
            }
        }
        [NotMapped]
        public ERole OnRole
        {
            get { return perole; }
            set 
            { 
                perole = value;
                role = perole.ToString();
            }
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
        [NotMapped]
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

        #endregion

        #region CHECK INFORMATIONS

        public bool CheckFullName()
        {
            return this.fullName != string.Empty;
        }
        public bool CheckCitizenCode()
        {
            return this.citizenCode != string.Empty
                    && !peopleDAO.CheckExist(t => t.CitizenCode == this.citizenCode);
        }
        public bool CheckBirthday()
        {
            TimeSpan difference = DateTime.Now - this.birthday;
            int age = (int)(difference.TotalDays / 365.25);
            return age >= 18;
        }
        public bool CheckGender()
        {
            return this.pegender == EGender.Male || this.pegender == EGender.Female;
        }
        public bool CheckEmail()
        {
            return this.email != string.Empty
                    && !peopleDAO.CheckExist(t => t.Email == this.email);
        }
        public bool CheckPhoneNumber()
        {
            return this.phoneNumber != string.Empty && this.phoneNumber.All(char.IsDigit)
                    && !peopleDAO.CheckExist(t => t.PhoneNumber == this.phoneNumber);
        }
        public bool CheckHandle()
        {
            return this.handle != string.Empty
                    && !peopleDAO.CheckExist(t => t.Handle == this.handle);
        }
        public bool CheckRole()
        {
            return this.perole == ERole.Lecture || this.perole == ERole.Student;
        }
        public bool CheckWorkCode()
        {
            return this.workCode != string.Empty
                    && !peopleDAO.CheckExist(t => t.WorkCode == this.workCode);
        }
        public bool CheckPassWord()
        {
            return this.password != string.Empty && this.password == this.confirmPassword;
        }

        #endregion

        #region FUNCTIONS

        public People Clone()
        {
            return new People(idAccount, fullName, citizenCode, birthday, pegender, email, phoneNumber, handle, perole, workCode, password, avatarName);
        }

        #endregion

    }
}

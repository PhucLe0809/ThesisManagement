using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Student : People
    {
        public Student() : base() { }

        #region STUDENT CONTRUCTORS

        public Student(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password)
            : base(fullName, citizenCode, birthday, gender, email, phoneNumber, handle, role, workCode, password, EClassify.Student) { }

        public Student(string idAccount, string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password)
            : base(idAccount, fullName, citizenCode, birthday, gender, email, phoneNumber, handle, role, workCode, password, "PicAvatarDemoUser") { }

        #endregion

    }
}

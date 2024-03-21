using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject
{
    public class Student : People
    {
        private int numLectures;

        public Student() : base()
        {
            this.numLectures = 0;
        }

        public Student(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password)
            : base(fullName, citizenCode, birthday, gender, email, phoneNumber, handle, role, workCode, password, EClassify.Student)
        {
            this.numLectures = 0;
        }
        public Student(string idAccount, string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password)
            : base(idAccount, fullName, citizenCode, birthday, gender, email, phoneNumber, handle, role, workCode, password, EClassify.Student)
        {
            this.numLectures = 0;
        }

        public int NumLectures
        {
            get { return this.numLectures; }
        }
    }
}

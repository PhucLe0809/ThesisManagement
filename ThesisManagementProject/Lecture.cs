using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject
{
    public class Lecture : People
    {
        private int numStudents;

        public Lecture() : base() 
        {
            this.numStudents = 0;
        }

        public Lecture(string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password)
            : base(fullName, citizenCode, birthday, gender, email, phoneNumber, handle, role, workCode, password, EClassify.Lecture)
        {
            this.numStudents = 0;
        }
        public Lecture(string idAccount, string fullName, string citizenCode, DateTime birthday, EGender gender, string email, string phoneNumber,
                        string handle, ERole role, string workCode, string password)
            : base(idAccount, fullName, citizenCode, birthday, gender, email, phoneNumber, handle, role, workCode, password, EClassify.Lecture)
        {
            this.numStudents = 0;
        }

        public int NumStudents
        {
            get { return this.numStudents; }
        }

    }
}

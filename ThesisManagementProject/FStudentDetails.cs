using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisManagementProject
{
    public partial class FStudentDetails : Form
    {
        private Student student = new Student();

        public FStudentDetails()
        {
            InitializeComponent();
        }

        public void UpdateStudent(Student student)
        {
            this.student = student;
            UserControlLoad();
        }

        private void UserControlLoad()
        {
            lblViewHandle.Text = student.Handle;
            lblViewRole.Text = student.Role.ToString();
            lblNumTopic.Text = "0";
            lblNumThesis.Text = "0";
            lblNumDiscussion.Text = "0";
            lblNumTeam.Text = "0";

            gTextBoxFullname.Text = student.FullName;
            gTextBoxCitizencode.Text = student.CitizenCode;
            gTextBoxBirthday.Text = student.Birthday.ToString();   
            gTextBoxGender.Text = student.Gender.ToString();
            gTextBoxEmail.Text = student.Email;
            gTextBoxPhonenumber.Text = student.PhoneNumber;

            gTextBoxIDAccount.Text = student.IdAccount.ToString();
            gTextBoxUniversity.Text = student.University;
            gTextBoxFaculty.Text = student.Faculty;
            gTextBoxWorkcode.Text = student.WorkCode;
        }
    }
}

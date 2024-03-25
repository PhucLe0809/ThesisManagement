using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Models;

namespace ThesisManagementProject
{
    public partial class FStudentDetails : Form
    {
        private People people = new People();

        public FStudentDetails()
        {
            InitializeComponent();
        }

        public void UpdateStudent(People people)
        {
            this.people = people;
            UserControlLoad();
        }

        private void UserControlLoad()
        {
            lblViewHandle.Text = people.Handle;
            lblViewRole.Text = people.Role.ToString();
            lblNumTopic.Text = "0";
            lblNumThesis.Text = "0";
            lblNumDiscussion.Text = "0";
            lblNumTeam.Text = "0";

            gTextBoxFullname.Text = people.FullName;
            gTextBoxCitizencode.Text = people.CitizenCode;
            gTextBoxBirthday.Text = people.Birthday.ToString();   
            gTextBoxGender.Text = people.Gender.ToString();
            gTextBoxEmail.Text = people.Email;
            gTextBoxPhonenumber.Text = people.PhoneNumber;

            gTextBoxIDAccount.Text = people.IdAccount.ToString();
            gTextBoxUniversity.Text = people.University;
            gTextBoxFaculty.Text = people.Faculty;
            gTextBoxWorkcode.Text = people.WorkCode;
        }
    }
}

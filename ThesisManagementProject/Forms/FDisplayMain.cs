using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class FDisplayMain : Form
    {
        private MyProcess myProcess = new MyProcess();
        private PeopleDAO peopleDAO = new PeopleDAO();
        UCDisplayLecture uCDisplayLecture = new UCDisplayLecture();
        UCDisplayStudent uCDisplayStudent = new UCDisplayStudent();
        UCDisplayWelcome uCDisplayWelcome = new UCDisplayWelcome();
        UCDisplayLogin uCDisplayLogin = new UCDisplayLogin();
        UCDisplayRegister uCDisplayRegister = new UCDisplayRegister();

        public FDisplayMain()
        {
            InitializeComponent();

            #region Record CLICK events

            gPanelDisplay.Controls.Add(uCDisplayWelcome);

            uCDisplayWelcome.GGradientButtonLecture.Click += DWelcomeButtonLecture_Click;
            uCDisplayWelcome.GGradientButtonStudent.Click += DWelcomeButtonStudent_Click;
            uCDisplayWelcome.GGradientButtonRegister.Click += DWelcomeButtonRegister_Click;
            uCDisplayWelcome.GButtonLogin.Click += DWelcomeButtonToLogin_Click;

            uCDisplayLecture.GButtonLogOut.Click += DLectureButtonLogOut_Click;

            uCDisplayStudent.GButtonLogOut.Click += DStudentButtonLogOut_Click;

            uCDisplayLogin.GButtonLogin.Click += DLoginButtonLogin_Click;
            uCDisplayLogin.GButtonBack.Click += DLoginButtonBack_Click;

            uCDisplayRegister.GButtonBack.Click += DRegisterBack_Click;
            uCDisplayRegister.GButtonLoadLogin.Click += DRegisterLoadLogin_Click;

            #endregion

            #region Record KEYDOWN events

            uCDisplayLogin.GTextBoxEmail.KeyDown += DLoginTextBoxEmail_KeyDown;
            uCDisplayLogin.GTextBoxPassword.KeyDown += DLoginTextBoxPassword_KeyDown;

            #endregion
        }

        #region FUNCTIONS

        private void SetDisplay(UserControl userControl)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(userControl);
        }

        #endregion

        #region EVENT CLICK

        private void DWelcomeButtonLecture_Click(object sender, EventArgs e)
        {
            People people = peopleDAO.SelectOnlyByID("242200001");
            uCDisplayLecture.SetInformation(people);
            SetDisplay(uCDisplayLecture);
        }
        private void DWelcomeButtonStudent_Click(object sender, EventArgs e)
        {
            People people = peopleDAO.SelectOnlyByID("243300002");
            uCDisplayStudent.SetInformation(people);
            SetDisplay(uCDisplayStudent);
        }
        private void DWelcomeButtonRegister_Click(object sender, EventArgs e)
        {
            uCDisplayRegister.InitDataControls();
            SetDisplay(uCDisplayRegister);
        }
        private void DWelcomeButtonToLogin_Click(object sender, EventArgs e)
        {
            uCDisplayLogin.InitDataControls();
            SetDisplay(uCDisplayLogin);
        }
        private void DLectureButtonLogOut_Click(object sender, EventArgs e)
        {
            SetDisplay(uCDisplayWelcome);
        }
        private void DStudentButtonLogOut_Click(object sender, EventArgs e)
        {
            SetDisplay(uCDisplayWelcome);
        }
        private void DLoginButtonLogin_Click(object sender, EventArgs e)
        {
            PeopleDAO peopleDAO = new PeopleDAO();
            string email = uCDisplayLogin.GTextBoxEmail.Text;
            string password = uCDisplayLogin.GTextBoxPassword.Text;
            string reminder = "email or password is incorrect !";

            People people = peopleDAO.SelectOnlyByEmailAndPassword(email, password);
            if (people == null)
            {
                uCDisplayLogin.GTextBoxReminder.Text = reminder;
            }
            else
            {
                uCDisplayLogin.GTextBoxReminder.Text = string.Empty;
                if (people.Role == ERole.Lecture)
                {
                    uCDisplayLecture.SetInformation(people);
                    SetDisplay(uCDisplayLecture);
                }
                else
                {
                    uCDisplayStudent.SetInformation(people);
                    SetDisplay(uCDisplayStudent);
                }
            }
        }
        private void DLoginButtonBack_Click(object sender, EventArgs e)
        {
            SetDisplay(uCDisplayWelcome);
        }
        private void DRegisterLoadLogin_Click(Object sender, EventArgs e)
        {
            uCDisplayLogin.InitDataControls();
            SetDisplay(uCDisplayLogin);
        }
        private void DRegisterBack_Click(object sender, EventArgs e)
        {
            uCDisplayRegister.FlagCheck = true;
            uCDisplayRegister.RunCheckInformation();
            SetDisplay(uCDisplayWelcome);
        }

        #endregion

        #region EVENT KEYDOWN

        private void DLoginTextBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DLoginButtonLogin_Click(sender, e);
            }
        }
        private void DLoginTextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DLoginButtonLogin_Click(sender, e);
            }
        }

        #endregion

    }
}

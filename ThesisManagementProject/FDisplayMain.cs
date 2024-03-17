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
    public partial class FDisplayMain : Form
    {
        UCDisplayLecture uCDisplayLecture = new UCDisplayLecture();
        UCDisplayWelcome uCDisplayWelcome = new UCDisplayWelcome();
        UCDisplayLogin uCDisplayLogin = new UCDisplayLogin();
        UCDisplayRegister uCDisplayRegister = new UCDisplayRegister();

        public FDisplayMain()
        {
            InitializeComponent();

            gPanelDisplay.Controls.Add(uCDisplayWelcome);

            uCDisplayWelcome.GGradientButtonLecture.Click += DWelcomeButtonLecture_Click;
            uCDisplayWelcome.GGradientButtonRegister.Click += DWelcomeButtonRegister_Click;
            uCDisplayWelcome.GButtonLogin.Click += DWelcomeButtonToLogin_Click;

            uCDisplayLecture.GButtonLogOut.Click += DLectureButtonLogOut_Click;

            uCDisplayLogin.GButtonLogin.Click += DLoginButtonLogin_Click;
            uCDisplayLogin.GButtonBack.Click += DLoginButtonBack_Click;

            uCDisplayRegister.GButtonBack.Click += DRegisterBack_Click;
        }

        private void DWelcomeButtonLecture_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayLecture);
        }

        private void DWelcomeButtonRegister_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayRegister);
        }

        private void DWelcomeButtonToLogin_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayLogin);
        }

        private void DLectureButtonLogOut_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayWelcome);
        }

        private void DLoginButtonLogin_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayLecture);
        }

        private void DLoginButtonBack_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayWelcome);
        }

        private void DRegisterBack_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayWelcome);
        }
    }
}

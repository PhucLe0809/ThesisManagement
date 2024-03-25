using Guna.UI2.WinForms;
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
    public partial class UCDisplayLogin : UserControl
    {
        public UCDisplayLogin()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public Guna2Button GButtonLogin
        {
            get { return this.gButtonLogin; }
        }
        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }
        public Guna2TextBox GTextBoxEmail
        {
            get { return this.gTextBoxEmail; }
        }
        public Guna2TextBox GTextBoxPassword
        {
            get { return this.gTextBoxPassword; }
        }
        public Guna2TextBox GTextBoxReminder
        {
            get { return this.gTextBoxReminder; }
        }

        #endregion

        #region FUNCTIONS

        public void InitDataControls()
        {
            gTextBoxEmail.Text = string.Empty;
            gTextBoxPassword.Text = string.Empty;
            gTextBoxReminder.Text = string.Empty;
        }

        #endregion

    }
}

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

        public Guna2Button GButtonLogin
        {
            get { return this.gButtonLogin; }
        }

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        private void gButtonLogin_Click(object sender, EventArgs e)
        {

        }

        private void gButtonBack_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class UCDisplayWelcome : UserControl
    {
        public UCDisplayWelcome()
        {
            InitializeComponent();
        }

        public Guna2GradientButton GGradientButtonLecture
        {
            get { return this.gGradientButtonLecture; }
        }

        private void gButtonLogin_Click(object sender, EventArgs e)
        {
            FDisplayLogin fDisplayLogin = new FDisplayLogin();
            fDisplayLogin.ShowDialog();
        }
    }
}

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
    public partial class UCIndividualLine : UserControl
    {
        public UCIndividualLine()
        {
            InitializeComponent();
        }
        public void SetFavorites()
        {
            gButtonStar.Image = Properties.Resources.PicInLineGradientStar;
        }

        private void lblDetails_Click(object sender, EventArgs e)
        {
            FStudentDetails fAccountDetails = new FStudentDetails();
            fAccountDetails.Show();
        }

        private void UCIndividualLine_Click(object sender, EventArgs e)
        {
            FStudentDetails fAccountDetails = new FStudentDetails();
            fAccountDetails.ShowDialog();
        }

        private void UCIndividualLine_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
        }

        private void UCIndividualLine_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}

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

        private void SetColor(Color color)
        {
            this.BackColor = color;
            gTextBoxStudentCode.FillColor = color;
            gTextBoxNumTopics.FillColor = color;
            gTextBoxNumTheses.FillColor = color;
            gTextBoxNumTeams.FillColor = color;
        }

        private void lblDetails_Click(object sender, EventArgs e)
        {
            FPeopleDetails fAccountDetails = new FPeopleDetails();
            fAccountDetails.Show();
        }

        private void UCIndividualLine_Click(object sender, EventArgs e)
        {
            FPeopleDetails fAccountDetails = new FPeopleDetails();
            fAccountDetails.ShowDialog();
        }

        private void UCIndividualLine_MouseEnter(object sender, EventArgs e)
        {
            SetColor(Color.Gainsboro);
        }

        private void UCIndividualLine_MouseLeave(object sender, EventArgs e)
        {
            SetColor(Color.White);
        }
    }
}

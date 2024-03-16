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
    public partial class UCStudentMiniLine : UserControl
    {
        public UCStudentMiniLine()
        {
            InitializeComponent();
        }

        public void SetButtonAddImageNull()
        {
            gButtonAdd.Image = null;
            gButtonAdd.HoverState.Image = null;
            gButtonAdd.Enabled = false;
        }

        private void gCirclePictureBoxAvatar_Click(object sender, EventArgs e)
        {
            FStudentDetails fStudentDetails = new FStudentDetails();
            fStudentDetails.ShowDialog();
        }

        private void gShadowPanelBack_Click(object sender, EventArgs e)
        {
            FStudentDetails fStudentDetails = new FStudentDetails();
            fStudentDetails.ShowDialog();
        }
    }
}

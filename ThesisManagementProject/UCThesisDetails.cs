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
    public partial class UCThesisDetails : UserControl
    {
        public UCThesisDetails()
        {
            InitializeComponent();


            for (int i = 0; i < 10; i++)
            {
                UCStudentMiniLine line = new UCStudentMiniLine();
                flpPending.Controls.Add(line);
            }

            for (int i = 0; i < 10; i++)
            {
                UCStudentMiniLine line = new UCStudentMiniLine();
                line.SetButtonAddImageNull();
                flpAccepted.Controls.Add(line);
            }

            for (int i = 0; i < 10; i++)
            {
                UCStudentMiniLine line = new UCStudentMiniLine();
                line.SetButtonAddImageNull();
                flpCompleted.Controls.Add(line);
            }
        }

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        private void gShadowPanelTopic_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisDetails = new FThesisEdit();
            fThesisDetails.ShowDialog();
        }

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisDetails = new FThesisEdit();
            fThesisDetails.ShowDialog();
        }
    }
}

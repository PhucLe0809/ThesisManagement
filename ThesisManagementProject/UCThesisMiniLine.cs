using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCThesisMiniLine : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private Thesis thesis = new Thesis();

        public UCThesisMiniLine(Thesis thesis)
        {
            InitializeComponent();
            this.thesis = thesis;
            InitUserControl();
        }
        private void InitUserControl()
        {
            lblThesisTopic.Text = myProcess.FormatStringLength(thesis.Topic, 20);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
        }
        private void UCThesisMiniLine_Click(object sender, EventArgs e)
        {
            FThesisView fThesisView = new FThesisView(this.thesis);
            fThesisView.ShowDialog();
        }
    }
}

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
    public partial class UCThesisMiniBoard : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private Thesis thesis = new Thesis();

        public UCThesisMiniBoard()
        {
            InitializeComponent();
        }
        public UCThesisMiniBoard(Thesis thesis)
        {
            InitializeComponent();

            this.thesis = thesis;
            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gTextBoxTopic.Text = thesis.Topic;
            gTextBoxField.Text = thesis.Field.ToString();
        }
        private void SetThesisView()
        {
            FThesisView fThesisView = new FThesisView(thesis);
            fThesisView.ShowDialog();
        }
        private void gButtonDetails_Click(object sender, EventArgs e)
        {
            SetThesisView();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Forms
{
    public partial class FThesisView : Form
    {
        private MyProcess myProcess = new MyProcess();

        public FThesisView()
        {
            InitializeComponent();
        }
        public FThesisView(Thesis thesis)
        {
            InitializeComponent();

            SetInformation(thesis);
        }

        private void SetInformation(Thesis thesis)
        {
            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gTextBoxTopic.Text = thesis.Topic;
            gTextBoxField.Text = thesis.Field.ToString();
            gTextBoxLevel.Text = thesis.Level.ToString();
            gTextBoxMembers.Text = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
            gTextBoxTechnology.Text = thesis.Technology;
            gTextBoxFunctions.Text = thesis.Functions;
            gTextBoxRequirements.Text = thesis.Requirements;
        }
    }
}

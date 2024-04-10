using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Forms
{
    public partial class FThesisView : Form
    {
        private MyProcess myProcess = new MyProcess();
        private DBConnection dBConnection = new DBConnection();
        private PeopleDAO peopleDAO = new PeopleDAO();

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

            AddPeopleLine(peopleDAO.SelectOnlyByID(thesis.IdCreator), flpCreator);
            AddPeopleLine(peopleDAO.SelectOnlyByID(thesis.IdInstructor), flpInstructor);

            string command = string.Format("SELECT * FROM {0} WHERE idthesis = '{1}' and status = '{2}'",
                                            MyDatabase.DBThesisStatus, thesis.IdThesis, thesis.Status.ToString());
            DataTable table = dBConnection.Select(command);
            gTextBoxTeamRegistered.FillColor = gTextBoxStatus.FillColor;
            gTextBoxTeamRegistered.Text = table.Rows.Count.ToString() + " teams";

            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
        }
        private void AddPeopleLine(People people, FlowLayoutPanel flowLayoutPanel)
        {
            UCPeopleMiniLine uCPeople = new UCPeopleMiniLine();
            uCPeople.GButtonAdd.Hide();
            uCPeople.SetBackGroundColor(SystemColors.ButtonFace);
            uCPeople.SetInformation(people);
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(uCPeople);
        }
    }
}

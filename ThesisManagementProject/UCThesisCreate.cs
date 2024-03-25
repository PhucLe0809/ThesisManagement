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
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCThesisCreate : UserControl
    {
        private People people = new People();
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private bool flagToCheck = false;

        public UCThesisCreate()
        {
            InitializeComponent();

        }
        public UCThesisCreate(People people)
        {
            InitializeComponent();

            SetInformation(people);
        }

        #region FUNCTIONS

        private void SetInformation(People people)
        {
            this.people = people;
            InitUserControl();
        }
        private void InitUserControl()
        {
            gTextBoxTopic.Text = string.Empty;
            gComboBoxField.StartIndex = 0;
            gComboBoxLevel.StartIndex = 0;
            gComboBoxMembers.StartIndex = 0;
            gTextBoxDescription.Text = string.Empty;
            gTextBoxTechnology.Text = string.Empty;
            gTextBoxFunctions.Text = string.Empty;
            gTextBoxRequirements.Text = string.Empty;
        }
        private bool CheckInformationValid()
        {
            MyProcess.RunCheckDataValid(thesis.CheckTopic() || flagToCheck, erpTopic, gTextBoxTopic, "Topic cannot be empty");
            MyProcess.RunCheckDataValid(thesis.CheckDesription() || flagToCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
            MyProcess.RunCheckDataValid(thesis.CheckTechnology() || flagToCheck, erpTechnology, gTextBoxTechnology, "Technologies cannot be empty");
            MyProcess.RunCheckDataValid(thesis.CheckFunctions() || flagToCheck, erpFunctions, gTextBoxFunctions, "Functions cannot be empty");
            MyProcess.RunCheckDataValid(thesis.CheckRequirements() || flagToCheck, erpRequirements, gTextBoxRequirements, "Requirements cannot be empty");

            return thesis.CheckTopic() && thesis.CheckDesription()
                    && thesis.CheckTechnology() && thesis.CheckFunctions() && thesis.CheckRequirements();
        }

        #endregion

        #region EVENT FORM     

        private void UCThesisCreate_Load(object sender, EventArgs e)
        {
            MyProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            MyProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));
        }

        #endregion

        #region EVENT gGradientButtonCreate

        private void gGradientButtonCreate_Click(object sender, EventArgs e)
        {
            this.thesis = new Thesis(gTextBoxTopic.Text,
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                MyProcess.ConvertStringToInt32(gComboBoxMembers.SelectedItem.ToString()), gTextBoxDescription.Text,
                DateTime.Now, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text, this.people.IdAccount);

            this.flagToCheck = false;
            if (CheckInformationValid())
            {
                thesisDAO.Insert(thesis);
                this.flagToCheck = true;
                InitUserControl();
            }
        }

        #endregion

        #region EVENT TextChanged

        private void gTextBoxTopic_TextChanged(object sender, EventArgs e)
        {
            thesis.Topic = gTextBoxTopic.Text;
            MyProcess.RunCheckDataValid(thesis.CheckTopic() || flagToCheck, erpTopic, gTextBoxTopic, "Topic cannot be empty");
        }
        private void gTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            thesis.Description = gTextBoxDescription.Text;
            MyProcess.RunCheckDataValid(thesis.CheckDesription() || flagToCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
        }
        private void gTextBoxTechnology_TextChanged(object sender, EventArgs e)
        {
            thesis.Technology = gTextBoxTechnology.Text;
            MyProcess.RunCheckDataValid(thesis.CheckTechnology() || flagToCheck, erpTechnology, gTextBoxTechnology, "Technologies cannot be empty");
        }
        private void gTextBoxFunctions_TextChanged(object sender, EventArgs e)
        {
            thesis.Functions = gTextBoxFunctions.Text;
            MyProcess.RunCheckDataValid(thesis.CheckFunctions() || flagToCheck, erpFunctions, gTextBoxFunctions, "Functions cannot be empty");
        }
        private void gTextBoxRequirements_TextChanged(object sender, EventArgs e)
        {
            thesis.Requirements = gTextBoxRequirements.Text;
            MyProcess.RunCheckDataValid(thesis.CheckRequirements() || flagToCheck, erpRequirements, gTextBoxRequirements, "Requirements cannot be empty");
        }

        #endregion
    
    }
}

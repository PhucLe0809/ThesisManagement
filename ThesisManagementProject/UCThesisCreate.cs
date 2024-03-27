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
        private MyProcess myProcess = new MyProcess();

        private People people = new People();
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private bool flagToCheck = false;
        private bool flagCreate = false;
        private bool flagEdit = false;

        public UCThesisCreate()
        {
            InitializeComponent();
            flagCreate = true;
        }

        #region CONTRUCTORS

        public UCThesisCreate(People people)
        {
            InitializeComponent();
            SetInformation(people);
        }
        public UCThesisCreate(People people, Thesis thesis)
        {
            InitializeComponent();
            SetEditState(people, thesis);
        }

        #endregion

        #region PROPERTIES

        public Guna2Button GButtonCancel
        {
            get { return gButtonCancel; }
        }

        #endregion

        #region FUNCTIONS

        public void SetInformation(People people)
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

            flagCreate = true;
            flagEdit = false;
            gButtonCreateOrEdit.Text = "Create";
        }
        public void SetEditState(People people, Thesis thesis)
        {
            this.people = people;
            this.thesis = thesis;
            InitEditState();
        }
        private void InitEditState()
        {
            myProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            myProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));

            gTextBoxTopic.Text = thesis.Topic;
            gComboBoxField.SelectedItem = thesis.Field;
            gComboBoxLevel.SelectedItem = thesis.Level;
            gComboBoxMembers.SelectedItem = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
            gTextBoxTechnology.Text = thesis.Technology;
            gTextBoxFunctions.Text = thesis.Functions;
            gTextBoxRequirements.Text = thesis.Requirements;

            flagCreate = false;
            flagEdit = true;
            gButtonCreateOrEdit.Text = "Save";
        }
        private bool CheckInformationValid()
        {
            myProcess.RunCheckDataValid(thesis.CheckTopic() || flagToCheck, erpTopic, gTextBoxTopic, "Topic cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckDesription() || flagToCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckTechnology() || flagToCheck, erpTechnology, gTextBoxTechnology, "Technologies cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckFunctions() || flagToCheck, erpFunctions, gTextBoxFunctions, "Functions cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckRequirements() || flagToCheck, erpRequirements, gTextBoxRequirements, "Requirements cannot be empty");

            return thesis.CheckTopic() && thesis.CheckDesription()
                    && thesis.CheckTechnology() && thesis.CheckFunctions() && thesis.CheckRequirements();
        }

        #endregion

        #region EVENT FORM     

        private void UCThesisCreate_Load(object sender, EventArgs e)
        {
            myProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            myProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));
        }

        #endregion

        #region EVENT CREATE for CREATE

        private void SolveForCreate()
        {
            this.thesis = new Thesis(gTextBoxTopic.Text,
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                myProcess.ConvertStringToInt32(gComboBoxMembers.SelectedItem.ToString()), gTextBoxDescription.Text,
                DateTime.Now, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text, this.people.IdAccount);

            this.flagToCheck = false;
            if (CheckInformationValid())
            {
                thesisDAO.Insert(thesis);
                this.flagToCheck = true;
                InitUserControl();
            }
        }
        private void SolveForEdit()
        {
            this.thesis = new Thesis(this.thesis.IdThesis, gTextBoxTopic.Text,
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                myProcess.ConvertStringToInt32(gComboBoxMembers.SelectedItem.ToString()), gTextBoxDescription.Text,
                DateTime.Now, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text,
                this.thesis.IdCreator, this.thesis.IsFavorite, this.thesis.Status);

            this.flagToCheck = false;
            if (CheckInformationValid())
            {
                thesisDAO.Update(thesis);
                this.flagToCheck = true;
                this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);
                gButtonCancel.PerformClick();
            }            
        }
        private void gButtonCreateOrEdit_Click(object sender, EventArgs e)
        {
            if (flagCreate)
            {
                SolveForCreate();
            }
            else
            {
                if (flagEdit) SolveForEdit();
            }
        }

        #endregion

        #region EVENT TextChanged

        private void gTextBoxTopic_TextChanged(object sender, EventArgs e)
        {
            thesis.Topic = gTextBoxTopic.Text;
            myProcess.RunCheckDataValid(thesis.CheckTopic() || flagToCheck, erpTopic, gTextBoxTopic, "Topic cannot be empty");
        }
        private void gTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            thesis.Description = gTextBoxDescription.Text;
            myProcess.RunCheckDataValid(thesis.CheckDesription() || flagToCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
        }
        private void gTextBoxTechnology_TextChanged(object sender, EventArgs e)
        {
            thesis.Technology = gTextBoxTechnology.Text;
            myProcess.RunCheckDataValid(thesis.CheckTechnology() || flagToCheck, erpTechnology, gTextBoxTechnology, "Technologies cannot be empty");
        }
        private void gTextBoxFunctions_TextChanged(object sender, EventArgs e)
        {
            thesis.Functions = gTextBoxFunctions.Text;
            myProcess.RunCheckDataValid(thesis.CheckFunctions() || flagToCheck, erpFunctions, gTextBoxFunctions, "Functions cannot be empty");
        }
        private void gTextBoxRequirements_TextChanged(object sender, EventArgs e)
        {
            thesis.Requirements = gTextBoxRequirements.Text;
            myProcess.RunCheckDataValid(thesis.CheckRequirements() || flagToCheck, erpRequirements, gTextBoxRequirements, "Requirements cannot be empty");
        }

        #endregion

    }
}

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
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCThesisCreate : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private DBConnection dBConnection = new DBConnection();

        private People people = new People();
        private Thesis thesis = new Thesis();

        private PeopleDAO peopleDAO = new PeopleDAO();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private UCPeopleMiniLine uCPeopleMiniLine = new UCPeopleMiniLine();
        private bool flagCheck = false;
        private bool flagCreate = false;
        private bool flagEdit = false;
        private bool flagInitEdit = false;

        public UCThesisCreate()
        {
            InitializeComponent();
            flagCreate = true;
        }

        #region PROPERTIES

        public Guna2Button GButtonCancel
        {
            get { return gButtonCancel; }
        }

        #endregion

        #region FUNCTIONS

        public void SetCreateState(People people)
        {
            this.people = people;
            InitCreateState();
        }
        public void SetEditState(People people, Thesis thesis)
        {
            this.people = people;
            this.thesis = thesis;
            InitEditState();
        }
        private void InitUserControl()
        {
            myProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            myProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));
            uCPeopleMiniLine.GButtonAdd.Hide();
            uCPeopleMiniLine.SetSize(new Size(397, 60));
            
            cmbIDInstructor.Items.Clear();
            List<string> list = peopleDAO.SelectListID(ERole.Lecture);
            foreach (var item in list)
            {
                cmbIDInstructor.Items.Add(item);
            }
        }
        private void InitCreateState()
        {
            flagInitEdit = false;
            gTextBoxTechnology.Text = string.Empty;
            InitUserControl();
            gTextBoxTopic.Text = string.Empty;
            gComboBoxField.StartIndex = 0;
            gComboBoxLevel.StartIndex = 0;
            gComboBoxMembers.StartIndex = 0;
            gTextBoxDescription.Text = string.Empty;
            gTextBoxFunctions.Text = string.Empty;
            gTextBoxRequirements.Text = string.Empty;
            cmbIDInstructor.Text = string.Empty;
            flagCreate = true;
            flagEdit = false;
            gButtonCreateOrEdit.Text = "Create";
            cmbIDInstructor.Enabled = true;

            if (people.Role == ERole.Lecture)
            {
                cmbIDInstructor.SelectedItem = people.IdAccount;
                cmbIDInstructor.Enabled = false;
            }
            cmbIDInstructor_SelectedIndexChanged(cmbIDInstructor, new EventArgs());
        }
        private void InitEditState()
        {
            flagInitEdit = true;
            InitUserControl();
            gTextBoxTopic.Text = thesis.Topic;
            gComboBoxField.SelectedItem = thesis.Field;
            gComboBoxLevel.SelectedItem = thesis.Level;
            gComboBoxMembers.SelectedItem = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
            gTextBoxFunctions.Text = thesis.Functions;
            gTextBoxRequirements.Text = thesis.Requirements;
            flagCreate = false;
            flagEdit = true;
            gButtonCreateOrEdit.Text = "Save";
            cmbIDInstructor.SelectedItem = thesis.IdInstructor;
            cmbIDInstructor.Enabled = false;
            cmbIDInstructor_SelectedIndexChanged(cmbIDInstructor, new EventArgs());
        }
        private void SetComboBoxTechnology()
        {
            if (gComboBoxField.SelectedItem == null) return;
            string command = string.Format("SELECT * FROM {0} WHERE field = '{1}'",
                                    MyDatabase.DBTechnology, gComboBoxField.Text);
            DataTable table = dBConnection.Select(command);

            gComboBoxTechnology.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                gComboBoxTechnology.Items.Add(row["tech"].ToString());
            }
            gComboBoxTechnology.StartIndex = 0;
        }
        private bool CheckInformationValid()
        {
            myProcess.RunCheckDataValid(thesis.CheckTopic() || flagCheck, erpTopic, gTextBoxTopic, "Topic cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckDesription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckTechnology() || flagCheck, erpTechnology, gTextBoxTechnology, "Technologies cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckFunctions() || flagCheck, erpFunctions, gTextBoxFunctions, "Functions cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckRequirements() || flagCheck, erpRequirements, gTextBoxRequirements, "Requirements cannot be empty");
            myProcess.RunCheckDataValid(thesis.CheckInstructor() || flagCheck, erpInstructor, cmbIDInstructor, "Instructor cannot be empty");

            return thesis.CheckTopic() && thesis.CheckDesription() && thesis.CheckTechnology()
                    && thesis.CheckFunctions() && thesis.CheckRequirements() && thesis.CheckInstructor();
        }

        #endregion

        #region EVENT CREATE for CREATE

        private void SolveForCreate()
        {
            this.thesis = new Thesis(gTextBoxTopic.Text,
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                myProcess.ConvertStringToInt32(gComboBoxMembers.SelectedItem.ToString()), gTextBoxDescription.Text, DateTime.Now,
                gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text, this.people.IdAccount,
                cmbIDInstructor.SelectedIndex != -1 ? cmbIDInstructor.SelectedItem.ToString() : string.Empty);

            this.flagCheck = false;
            if (CheckInformationValid())
            {
                thesisDAO.Insert(thesis);
                if (thesis.IdCreator != thesis.IdInstructor)
                {
                    string content = Notification.GetContentTypeThesis(people.FullName, thesis.Topic);
                    notificationDAO.Insert(new Notification(thesis.IdInstructor, thesis.IdCreator, thesis.IdThesis, thesis.IdThesis, content, DateTime.Now, false, false));
                }
                this.flagCheck = true;
                InitCreateState();
            }
        }
        private void SolveForEdit()
        {
            this.thesis = new Thesis(this.thesis.IdThesis, gTextBoxTopic.Text,
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                myProcess.ConvertStringToInt32(gComboBoxMembers.SelectedItem.ToString()), gTextBoxDescription.Text,
                DateTime.Now, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text,
                this.thesis.IdCreator, this.thesis.IsFavorite, this.thesis.Status, this.thesis.IdInstructor);

            this.flagCheck = false;
            if (CheckInformationValid())
            {
                thesisDAO.Update(thesis);
                this.flagCheck = true;
                this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);
                gButtonCancel.PerformClick();
            }
        }
        private void gButtonCreateOrEdit_Click(object sender, EventArgs e)
        {
            if (flagCreate) SolveForCreate();
            if (flagEdit) SolveForEdit();
        }

        #endregion

        #region EVENT TextChanged

        private void gTextBoxTopic_TextChanged(object sender, EventArgs e)
        {
            thesis.Topic = gTextBoxTopic.Text;
            myProcess.RunCheckDataValid(thesis.CheckTopic() || flagCheck, erpTopic, gTextBoxTopic, "Topic cannot be empty");
        }
        private void gTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            thesis.Description = gTextBoxDescription.Text;
            myProcess.RunCheckDataValid(thesis.CheckDesription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
        }
        private void gTextBoxTechnology_TextChanged(object sender, EventArgs e)
        {
            thesis.Technology = gTextBoxTechnology.Text;
            myProcess.RunCheckDataValid(thesis.CheckTechnology() || flagCheck, erpTechnology, gTextBoxTechnology, "Technologies cannot be empty");
        }
        private void gTextBoxFunctions_TextChanged(object sender, EventArgs e)
        {
            thesis.Functions = gTextBoxFunctions.Text;
            myProcess.RunCheckDataValid(thesis.CheckFunctions() || flagCheck, erpFunctions, gTextBoxFunctions, "Functions cannot be empty");
        }
        private void gTextBoxRequirements_TextChanged(object sender, EventArgs e)
        {
            thesis.Requirements = gTextBoxRequirements.Text;
            myProcess.RunCheckDataValid(thesis.CheckRequirements() || flagCheck, erpRequirements, gTextBoxRequirements, "Requirements cannot be empty");
        }

        #endregion

        #region EVENT cmbIDInstructor

        private void cmbIDInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIDInstructor.SelectedItem != null)
            {
                string idInstructor = cmbIDInstructor.SelectedItem.ToString();
                People people = peopleDAO.SelectOnlyByID(idInstructor);
                uCPeopleMiniLine.SetInformation(people);
                flpInstructor.Controls.Clear();
                flpInstructor.Controls.Add(uCPeopleMiniLine);
            }
            else
            {
                Label label = myProcess.CreateLabel("There aren't any people selected !");
                flpInstructor.Controls.Clear();
                flpInstructor.Controls.Add(label);
            }
        }

        #endregion

        #region EVENT gComboBoxField

        private void gComboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboBoxTechnology();
        }

        #endregion

        #region EVENT gComboBoxTechnology

        private void gComboBoxTechnology_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagInitEdit)
            {
                gTextBoxTechnology.Text = thesis.Technology;
                flagInitEdit = false;
                return;
            }
            if (gComboBoxTechnology.SelectedIndex != -1)
            {
                gTextBoxTechnology.Text += gComboBoxTechnology.SelectedItem + ", ";
            }
        }

        #endregion

        #region EVENT gButtonTechnologyClear

        private void gButtonTechnologyClear_Click(object sender, EventArgs e)
        {
            gTextBoxTechnology.Clear();
        }

        #endregion

    }
}

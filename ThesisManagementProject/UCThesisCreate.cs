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
            gTextBoxMembers.Text = @"1";
            gTextBoxDescription.Text = string.Empty;
            gTextBoxTechnology.Text = string.Empty;
            gTextBoxFunctions.Text = string.Empty;
            gTextBoxRequirements.Text = string.Empty;
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
                MyProcess.ConvertStringToInt32(gTextBoxMembers.Text), gTextBoxDescription.Text, 
                DateTime.Now, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text, this.people.IdAccount);
            
            thesisDAO.Insert(thesis);
            InitUserControl();
        }

        #endregion

    }
}

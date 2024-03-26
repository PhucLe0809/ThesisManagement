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

namespace ThesisManagementProject
{
    public partial class FThesisEdit : Form
    {
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();

        public FThesisEdit()
        {
            InitializeComponent();
        }

        private void UserControlLoad()
        {
            MyProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            MyProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));

            gTextBoxTopic.Text = thesis.Topic;
            gComboBoxField.SelectedItem = thesis.Field;
            gComboBoxLevel.SelectedItem = thesis.Level;
            gTextBoxMembers.Text = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
            gDateTimePickerPublish.Value = thesis.PublishDate;
            gTextBoxTechnology.Text = thesis.Technology;
            gTextBoxFunctions.Text = thesis.Functions;
            gTextBoxRequirements.Text = thesis.Requirements;
        }

        public void UpdateThesis(Thesis thesis)
        {
            this.thesis = thesis;
            UserControlLoad();
        }

        private void gGradientButtonSave_Click(object sender, EventArgs e)
        {
            this.thesis = new Thesis(this.thesis.IdThesis, gTextBoxTopic.Text,
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                MyProcess.ConvertStringToInt32(gTextBoxMembers.Text), gTextBoxDescription.Text,
                gDateTimePickerPublish.Value, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text,
                this.thesis.IdCreator, this.thesis.IsFavorite, this.thesis.Status);
            
            thesisDAO.Update(thesis);

            this.Close();
        }

        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

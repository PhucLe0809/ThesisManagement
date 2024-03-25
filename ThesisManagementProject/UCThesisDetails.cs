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
    public partial class UCThesisDetails : UserControl
    {
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private bool flagEventEdit = true;

        public UCThesisDetails()
        {
            InitializeComponent();

        }
        public UCThesisDetails(Thesis thesis)
        {
            InitializeComponent();

            SetInformation(thesis);

        }

        #region FUNCTIONS

        public void SetInformation(Thesis thesis)
        {
            this.thesis = thesis;
            InitUserControl();

        }
        private void SetTextBoxReadOnly(Guna2TextBox textBox, int thickness, Color colors, bool flag)
        {
            textBox.ReadOnly = flag;
            textBox.BorderThickness = thickness;
            textBox.FillColor = colors;
        }
        private void SetComboBoxReadOnly(Guna2ComboBox comboBox, int thickness, Color colors, bool flag)
        {
            comboBox.Enabled = !flag;
            comboBox.BorderThickness = thickness;
            comboBox.FillColor = colors;
        }
        private void SetControlsReadOnly(bool flagReadOnly)
        {
            int thickness = flagReadOnly ? 0 : 1;
            Color colors = flagReadOnly ? SystemColors.ButtonFace : Color.White;
            Color colorComboBox = flagReadOnly ? Color.Silver : Color.White;
            SetTextBoxReadOnly(gTextBoxTopic, thickness, colors, flagReadOnly);
            SetTextBoxReadOnly(gTextBoxDescription, thickness, colors, flagReadOnly);
            SetTextBoxReadOnly(gTextBoxTechnology, thickness, colors, flagReadOnly);
            SetTextBoxReadOnly(gTextBoxFunctions, thickness, colors, flagReadOnly);
            SetTextBoxReadOnly(gTextBoxRequirements, thickness, colors, flagReadOnly);

            SetComboBoxReadOnly(gComboBoxField, thickness, colorComboBox, flagReadOnly);
            gPictureBoxFaculty.BackColor = colorComboBox;
            SetComboBoxReadOnly(gComboBoxLevel, thickness, colorComboBox, flagReadOnly);
            gPictureBoxLevel.BackColor = colorComboBox;
            SetComboBoxReadOnly(gComboBoxMembers, thickness, colorComboBox, flagReadOnly);
        }
        private void InitUserControl()
        {
            gGradientButtonThesisReset_Click(new object(), new EventArgs());
            SetControlsReadOnly(true);
        }
        private void AddPeopleToFLP(FlowLayoutPanel flpanel, List<People> list, bool flag)
        {
            flpanel.Controls.Clear();
            foreach (People people in list)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine(people);
                if (flag) line.SetButtonAddImageNull();
                line.ThesisMiniLineClicked += GButtonAdd_Click;
                flpanel.Controls.Add(line);
            }
        }

        #endregion

        #region PROPERTIES

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        #endregion

        #region EVENT FORM

        private void UCThesisDetails_Load(object sender, EventArgs e)
        {
            MyProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            MyProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));
        }

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            this.flagEventEdit = !this.flagEventEdit;
            SetControlsReadOnly(flagEventEdit);
        }

        #endregion

        #region EVENT gButtonAdd

        private void GButtonAdd_Click(object sender, EventArgs e)
        {
            UCPeopleMiniLine line = sender as UCPeopleMiniLine;

            if (line != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to accept " + line.GetPeople.Handle,
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    thesisDAO.SQLExecuteByCommand(string.Format("update {0} set sta = '{1}' where idaccount = '{2}' and idthesis = '{3}'",
                        MyDatabase.DBThesisStatus, EThesisStatus.Accepted.ToString(), line.GetPeople.IdAccount, thesis.IdThesis));
                }
            }

        }

        #endregion

        #region EVENT gGradientButtonThesisReset

        private void gGradientButtonThesisReset_Click(object sender, EventArgs e)
        {
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);

            MyProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            gTextBoxTopic.Text = thesis.Topic;
            gComboBoxField.SelectedItem = thesis.Field.ToString();
            gComboBoxLevel.SelectedItem = thesis.Level.ToString();
            gComboBoxMembers.SelectedItem = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
            gTextBoxTechnology.Text = thesis.Technology;
            gTextBoxFunctions.Text = thesis.Functions;
            gTextBoxRequirements.Text = thesis.Requirements;
        }

        #endregion

    }
}

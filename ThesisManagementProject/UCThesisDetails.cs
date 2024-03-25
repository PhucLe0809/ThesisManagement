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

namespace ThesisManagementProject
{
    public partial class UCThesisDetails : UserControl
    {
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();

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
        private void SetTextBoxReadOnly(Guna2TextBox textBox)
        {
            textBox.ReadOnly = true;
            textBox.BorderThickness = 0;
            textBox.FillColor = SystemColors.ButtonFace;
        }
        private void SetComboBoxReadOnly(Guna2ComboBox comboBox)
        {
            comboBox.DroppedDown = false;
            comboBox.BorderThickness = 0;
            comboBox.FillColor = SystemColors.ButtonFace;
        }
        private void InitUserControl()
        {
            AddPeopleToFLP(flpPending, thesisDAO.SelectByStatus(EThesisStatus.Pending.ToString(), thesis.IdThesis), false);
            AddPeopleToFLP(flpAccepted, thesisDAO.SelectByStatus(EThesisStatus.Accepted.ToString(), thesis.IdThesis), true);
            AddPeopleToFLP(flpCompleted, thesisDAO.SelectByStatus(EThesisStatus.Completed.ToString(), thesis.IdThesis), true);

            gGradientButtonThesisReset_Click(new object(), new EventArgs());

            SetTextBoxReadOnly(gTextBoxTopic);
            SetTextBoxReadOnly(gTextBoxMembers);
            SetTextBoxReadOnly(gTextBoxDescription);
            SetTextBoxReadOnly(gTextBoxTechnology);
            SetTextBoxReadOnly(gTextBoxFunctions);
            SetTextBoxReadOnly(gTextBoxRequirements);
            SetComboBoxReadOnly(gComboBoxField);
            gPictureBoxFaculty.FillColor = SystemColors.ButtonFace;
            SetComboBoxReadOnly(gComboBoxLevel);
            gPictureBoxLevel.FillColor = SystemColors.ButtonFace;
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
            FThesisEdit fThesisDetails = new FThesisEdit();
            fThesisDetails.UpdateThesis(thesis);
            fThesisDetails.ShowDialog();
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

                    AddPeopleToFLP(flpPending, thesisDAO.SelectByStatus(EThesisStatus.Pending.ToString(), thesis.IdThesis), false);
                    AddPeopleToFLP(flpAccepted, thesisDAO.SelectByStatus(EThesisStatus.Accepted.ToString(), thesis.IdThesis), true);
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
            gTextBoxMembers.Text = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
            gTextBoxTechnology.Text = thesis.Technology;
            gTextBoxFunctions.Text = thesis.Functions;
            gTextBoxRequirements.Text = thesis.Requirements;
        }

        #endregion

    }
}

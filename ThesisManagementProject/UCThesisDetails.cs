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
        private MyProcess myProcess = new MyProcess();
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();

        private UCThesisSolveRegistered uCThesisSolveRegistered = new UCThesisSolveRegistered();

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
        private void InitUserControl()
        {
            ResetThesis();   
            SetControlsReadOnly(true);
            gGradientButtonRegistered_Click(new object(), new EventArgs());
        }
        private void ResetThesis()
        {
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);

            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            gTextBoxTopic.Text = thesis.Topic;
            gComboBoxField.SelectedItem = thesis.Field;
            gComboBoxLevel.SelectedItem = thesis.Level;
            gComboBoxMembers.SelectedItem = thesis.MaxMembers.ToString();
            gTextBoxDescription.Text = thesis.Description;
        }
        private void SetControlsReadOnly(bool flagReadOnly)
        {
            int thickness = flagReadOnly ? 0 : 1;
            Color colors = flagReadOnly ? SystemColors.ButtonFace : Color.White;
            Color colorComboBox = flagReadOnly ? Color.Silver : Color.White;
            myProcess.SetTextBoxReadOnly(gTextBoxTopic, thickness, colors, flagReadOnly);
            myProcess.SetTextBoxReadOnly(gTextBoxDescription, thickness, colors, flagReadOnly);

            myProcess.SetComboBoxReadOnly(gComboBoxField, thickness, colorComboBox, flagReadOnly);
            gPictureBoxFaculty.BackColor = colorComboBox;
            myProcess.SetComboBoxReadOnly(gComboBoxLevel, thickness, colorComboBox, flagReadOnly);
            gPictureBoxLevel.BackColor = colorComboBox;
            myProcess.SetComboBoxReadOnly(gComboBoxMembers, thickness, colorComboBox, flagReadOnly);
        }
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonRegistered);
        }
        private void AddPeopleToFLP(FlowLayoutPanel flpanel, List<People> list, bool flag)
        {
            flpanel.Controls.Clear();
            foreach (People people in list)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine(people);
                if (flag) line.SetButtonAddImageNull();
                // line.ThesisMiniLineClicked += GButtonAdd_Click;
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
            myProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            myProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));
        }

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisView = new FThesisEdit(peopleDAO.SelectOnlyByID(thesis.IdCreator), thesis);
            fThesisView.ShowDialog();
            ResetThesis();
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
<<<<<<< HEAD
                    thesisDAO.SQLExecuteByCommand(string.Format("UPDATE {0} SET status = '{1}' where idteam = '{2}' and idthesis = '{3}'",
=======
                    thesisDAO.SQLExecuteByCommand(string.Format("update {0} set sta = '{1}' where idaccount = '{2}' and idthesis = '{3}'",
>>>>>>> fc16c9125eadc08d3b2f0e878131e290d403669f
                        MyDatabase.DBThesisStatus, EThesisStatus.Processing.ToString(), line.GetPeople.IdAccount, thesis.IdThesis));
                }
            }

        }

        #endregion

        #region EVENT gGradientButtonRegistered
        
        private void gGradientButtonRegistered_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonRegistered);
            gPanelDataView.Controls.Clear();

            uCThesisSolveRegistered.Clear();
            for (int i = 0; i < 10; i++)
            {
                uCThesisSolveRegistered.AddRegistered(new UCTeamMiniLine());
            }

            gPanelDataView.Controls.Add(uCThesisSolveRegistered);
        }

        #endregion

    }
}

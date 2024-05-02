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

namespace ThesisManagementProject
{
    public partial class FThesisFilter : Form
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();
        private List<Thesis> listThesis = new List<Thesis>();

        private PeopleDAO peopleDAO = new PeopleDAO();
        private ThesisDAO thesisDAO = new ThesisDAO();

        private UCPeopleMiniLine uCCreatorLine = new UCPeopleMiniLine();
        private UCPeopleMiniLine uCInstructorLine = new UCPeopleMiniLine();

        private bool flagAllTopic = true;
        private bool flagAllStatus = true;
        private bool flagAllFavorite = true;
        private bool flagFavorite = false;

        public FThesisFilter()
        {
            InitializeComponent();
            InitUserControl();
        }

        #region PROPERTIES

        public Guna2Button GButtonFilter
        {
            get { return this.gButtonFilter; }
        }
        public Guna2GradientButton GButtonSave
        {
            get { return this.gGradientButtonSave; }
        }
        public List<Thesis> ListThesis
        {
            get { return this.listThesis; }
            set { this.listThesis = value; }
        }

        #endregion

        #region FUNCTIONS

        public void SetUpFilter(People people)
        {
            this.people = people;
            InitUserControl();
        }
        private void InitUserControl()
        {
            myProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            myProcess.AddEnumsToComboBox(gComboBoxStatus, typeof(EThesisStatus));
            flagAllTopic = false;
            gButtonTopicSelectAll.PerformClick();
            flagAllStatus = false;
            gButtonStatusSelectAll.PerformClick();
            flagAllFavorite = false;
            gButtonFavoriteSelectAll.PerformClick();
            uCCreatorLine.GButtonAdd.Hide();
            uCCreatorLine.SetSize(new Size(270, 60));
            uCInstructorLine.GButtonAdd.Hide();
            uCInstructorLine.SetSize(new Size(270, 60));
            gButtonFilter.Hide();

            List<string> list = new List<string>();

            cmbIDInstructor.Items.Clear();
            list.AddRange(peopleDAO.SelectListID(ERole.Lecture));
            foreach (var item in list) cmbIDInstructor.Items.Add(item);

            cmbIDCreator.Items.Clear();
            list.AddRange(peopleDAO.SelectListID(ERole.Student));
            foreach (var item in list) cmbIDCreator.Items.Add(item);

            cmbIDCreator.Text = string.Empty;
            cmbIDInstructor.Text = string.Empty;

            if (people.OnRole == ERole.Lecture)
            {
                cmbIDInstructor.SelectedItem = people.IdAccount;
                cmbIDInstructor.Enabled = false;
            }
            cmbIDCreator_SelectedIndexChanged(cmbIDCreator, new EventArgs());
            cmbIDInstructor_SelectedIndexChanged(cmbIDInstructor, new EventArgs());
        }
        private void SetTextBoxEnable(List<Control> list, bool flag)
        {
            foreach (Control control in list)
            {
                control.Enabled = flag;
            }
        }
        private void ScanTextBoxOffOn(List<Control> list, ref bool flag, Guna2Button button, List<PictureBox> pictures)
        {
            flag = !flag;

            if (!flag)
            {
                SetTextBoxEnable(list, true);

                button.Image = Properties.Resources.PicItemOff;
                foreach (PictureBox picture in pictures)
                {
                    picture.BackColor = Color.White;
                }
            }
            else
            {
                SetTextBoxEnable(list, false);

                button.Image = Properties.Resources.PicItemOn;
                foreach (PictureBox picture in pictures)
                {
                    picture.BackColor = SystemColors.ControlLight;
                }
            }
        }

        #endregion

        #region EVENT FORM

        private void gButtonTopicStar_Click(object sender, EventArgs e)
        {
            flagFavorite = !flagFavorite;
            if (flagFavorite)
            {
                gButtonTopicStar.Image = Properties.Resources.PicInLineGradientStar;
            }
            else
            {
                gButtonTopicStar.Image = Properties.Resources.PicInLineStar;
            }
        }
        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gGradientButtonSave_Click(object sender, EventArgs e)
        {
            string command = string.Format("SELECT * FROM {0} ", MyDatabase.DBThesis);
            int condition = 0;

            if (!flagAllTopic)
            {
                condition++;
                command += " WHERE ";
                command += string.Format(" field = '{0}' ", gComboBoxField.SelectedItem.ToString());
                command += "and";
                command += string.Format(" maxmembers BETWEEN {0} and {1} ", gTextBoxMembersFrom.Text, gTextBoxMembersTo.Text);
            }
            if (!flagAllStatus)
            {
                condition++;
                if (condition == 1) command += " WHERE "; else command += "and";
                command += string.Format(" status = '{0}' ", gComboBoxStatus.SelectedItem.ToString());
            }
            if (!flagAllFavorite)
            {
                condition++;
                if (condition == 1) command += " WHERE "; else command += "and";
                command += string.Format(" isfavorite = {0}", flagFavorite ? 1 : 0);
            }
            if (cmbIDCreator.SelectedIndex != -1)
            {
                condition++;
                if (condition == 1) command += " WHERE "; else command += "and";
                command += string.Format(" idcreator = '{0}'", cmbIDCreator.SelectedItem);
            }
            if (cmbIDInstructor.SelectedIndex != -1)
            {
                condition++;
                if (condition == 1) command += " WHERE "; else command += "and";
                command += string.Format(" idinstructor = '{0}'", cmbIDInstructor.SelectedItem);
            }
            this.listThesis = thesisDAO.SelectList(command);
            this.Close();
            gButtonFilter.PerformClick();
        }

        #endregion

        #region EVENT SELECT ALL CLICK

        private void gButtonTopicSelectAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { pnlTopic }, ref flagAllTopic,
                                gButtonTopicSelectAll, new List<PictureBox> { gPictureBoxFaculty });
        }
        private void gButtonStatusSelectAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { pnlStatus }, ref flagAllStatus,
                                gButtonStatusSelectAll, new List<PictureBox>());
        }

        private void gButtonFavoriteSelectAll_Click(object sender, EventArgs e)
        {
            ScanTextBoxOffOn(new List<Control> { pnlFavorite }, ref flagAllFavorite,
                                gButtonFavoriteSelectAll, new List<PictureBox>());
        }

        #endregion

        #region EVENT cmbIDInstructor

        private void GetUCPeopleLineByID(ComboBox comboBox, FlowLayoutPanel flowLayoutPanel, UCPeopleMiniLine uCPeopleMiniLine)
        {
            if (comboBox.SelectedItem != null)
            {
                string idInstructor = comboBox.SelectedItem.ToString();
                People people = peopleDAO.SelectOnlyByID(idInstructor);
                uCPeopleMiniLine.SetInformation(people);
                flowLayoutPanel.Controls.Clear();
                flowLayoutPanel.Controls.Add(uCPeopleMiniLine);
            }
            else
            {
                Label label = myProcess.CreateLabel("There aren't any people selected !");
                flowLayoutPanel.Controls.Clear();
                flowLayoutPanel.Controls.Add(label);
            }
        }
        private void cmbIDCreator_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUCPeopleLineByID(cmbIDCreator, flpCreator, uCCreatorLine);
        }
        private void cmbIDInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUCPeopleLineByID(cmbIDInstructor, flpInstructor, uCInstructorLine);
        }

        #endregion

        #region EVENT gButtonResetFilter

        private void gButtonResetFilter_Click(object sender, EventArgs e)
        {
            InitUserControl();
        }

        #endregion

    }
}

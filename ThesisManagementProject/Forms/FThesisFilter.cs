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

using ThesisManagementProject.Entity;
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
        private void MergeList(ref List<Thesis> one, ref List<Thesis> two, Func<Thesis, object> propertySelector)
        {
            var temp = one.Join(two, propertySelector, propertySelector, (t1, t2) => t1).ToList();
            one.Clear();
            one.AddRange(temp);
        }
        private void gGradientButtonSave_Click(object sender, EventArgs e)
        {
            this.listThesis.Clear();
            this.listThesis.AddRange(thesisDAO.SelectList());

            var dbContext = new AppDbContext();
            if (!flagAllTopic)
            {
                string field = gComboBoxField.SelectedItem.ToString();
                int minimum = int.Parse(gTextBoxMembersFrom.Text);
                int maximum = int.Parse(gTextBoxMembersTo.Text);

                var one = thesisDAO.FilterByProperty(t => t.Field == field);
                MergeList(ref this.listThesis, ref one, t => t.IdThesis);
                var two = thesisDAO.FilterByProperty(t => t.MaxMembers >= minimum && t.MaxMembers <= maximum);
                MergeList(ref this.listThesis, ref two, t => t.IdThesis);
            }
            if (!flagAllStatus)
            {
                string status = gComboBoxStatus.SelectedItem.ToString();

                var list = thesisDAO.FilterByProperty(t => t.Status == status);
                MergeList(ref this.listThesis, ref list, t => t.IdThesis);
            }
            if (!flagAllFavorite)
            {
                var list = thesisDAO.FilterByProperty(t => t.IsFavorite == flagFavorite);
                MergeList(ref this.listThesis, ref list, t => t.IdThesis);
            }
            if (cmbIDCreator.SelectedIndex != -1)
            {
                string idCreator = cmbIDCreator.SelectedItem.ToString();

                var list = thesisDAO.FilterByProperty(t => t.IdCreator == idCreator);
                MergeList(ref this.listThesis, ref list, t => t.IdThesis);
            }
            if (cmbIDInstructor.SelectedIndex != -1)
            {
                string idInstructor = cmbIDInstructor.SelectedItem.ToString();

                var list = thesisDAO.FilterByProperty(t => t.IdInstructor == idInstructor);
                MergeList(ref this.listThesis, ref list, t => t.IdThesis);
            }
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

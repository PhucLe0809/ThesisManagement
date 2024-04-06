using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCDashboard : UserControl
    {

        private UCThesisList uCThesisList = new UCThesisList();
        private UCThesisCreate uCThesisCreate = new UCThesisCreate();
        private UCThesisDetails uCThesisDetails = new UCThesisDetails();

        private ThesisDAO thesisDAO = new ThesisDAO();
        private People people = new People();
        private FThesisFilter fThesisFilter = new FThesisFilter();
        private List<Thesis> currentList = new List<Thesis>();
        private List<Thesis> listThesis = new List<Thesis>();
        private bool flagStuMyTheses = false;

        public UCDashboard()
        {
            InitializeComponent();

            #region Record EVENT User control

            uCThesisDetails.GButtonBack.Click += ThesisDetailsBack_Clicked;

            uCThesisList.GButtonFavorite.Click += ByFavorite_Clicked;
            uCThesisList.GButtonTopic.Click += ByTopic_Clicked;
            uCThesisList.GButtonFilter.Click += ByFilter_Clicked;
            uCThesisList.GButtonReset.Click += ResetThesisList_Clicked;
            uCThesisList.GTextBoxSearch.TextChanged += SearchThesisTopic_TextChanged;

            uCThesisCreate.GButtonCancel.Click += gGradientButtonViewThesis_Click;

            #endregion

        }

        #region PROPERTIES

        public bool FlagStuMyTheses
        {
            set { this.flagStuMyTheses = value; }
        }

        #endregion

        #region FUNCTIONS

        public void SetInformation(People people)
        {
            this.people = people;
            gGradientButtonViewThesis.PerformClick();
            fThesisFilter.SetUpFilter(people);
            fThesisFilter.ListThesis = this.currentList;
            fThesisFilter.GButtonFilter.Click += GFilter_Click;
        }
        private void UpdateThesisList()
        {
            if (flagStuMyTheses)
            {
                UpdateThesisListStuMyTheses();
            }
            else
            {
                if (people.Role == ERole.Lecture) UpdateThesisListLecture();
                else UpdateThesisListStudent();
            }
        }
        private void UpdateThesisListLecture()
        {
            string command = string.Format("SELECT * FROM {0} WHERE idinstructor = '{1}'", MyDatabase.DBThesis, people.IdAccount);
            this.currentList = thesisDAO.SelectList(command);
            this.listThesis = currentList;
        }
        private void UpdateThesisListStudent()
        {
            string command = string.Format("SELECT * FROM {0} WHERE status IN ('Published', 'Registered') " +
                                           "AND NOT EXISTS(SELECT 1 FROM {1} WHERE {1}.idthesis = {0}.idthesis " +
                                           "AND idteam IN (SELECT idteam FROM {2} WHERE idaccount = '{3}'))",
                                           MyDatabase.DBThesis, MyDatabase.DBThesisStatus, MyDatabase.DBTeam, this.people.IdAccount);
            this.currentList = thesisDAO.SelectList(command);
            this.listThesis = currentList;
        }
        private void UpdateThesisListStuMyTheses()
        {
            string command = string.Format("SELECT {0}.* FROM {0} INNER JOIN {1} ON {0}.idthesis = {1}.idthesis " +
                                           "WHERE {1}.idteam IN (SELECT idteam FROM {2} WHERE idaccount = '{3}')",
                                            MyDatabase.DBThesis, MyDatabase.DBThesisStatus, MyDatabase.DBTeam, this.people.IdAccount);
            this.currentList = thesisDAO.SelectList(command);
            this.listThesis = currentList;
        }
        private void ButtonStandardColor(Guna2GradientButton button)
        {
            button.FillColor = SystemColors.ControlLight;
            button.FillColor2 = SystemColors.ButtonFace;
            button.ForeColor = Color.Black;
            button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }
        private void ButtonSettingColor(Guna2GradientButton button)
        {
            button.FillColor = Color.FromArgb(94, 148, 255);
            button.FillColor2 = Color.FromArgb(255, 77, 165);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }
        private void AllButtonStandardColor()
        {
            ButtonStandardColor(gGradientButtonViewThesis);
            ButtonStandardColor(gGradientButtonStatistical);
            ButtonStandardColor(gGradientButtonCreateThesis);
        }
        private void AddUserControl(Guna2GradientButton button, UserControl userControl)
        {
            AllButtonStandardColor();
            ButtonSettingColor(button);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(userControl);
        }
        private void LoadThesisList()
        {
            uCThesisList.Clear();

            for (int i = 0; i < listThesis.Count; i++)
            {
                UCThesisLine thesisLine = new UCThesisLine();
                thesisLine.SetInformation(listThesis[i]);
                thesisLine.ThesisLineClicked += ThesisLine_Clicked;
                thesisLine.ThesisEditClicked += ThesisListPreviousState;
                thesisLine.ThesisDeleteClicked += ThesisListPreviousState;
                if (people.Role == ERole.Student) thesisLine.HideToolBar();
                uCThesisList.AddThesis(thesisLine);
            }
            uCThesisList.SetNumThesis(listThesis.Count);
        }

        #endregion

        #region EVENT gGradientButtonViewThesis

        private void gGradientButtonViewThesis_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonViewThesis);
            UpdateThesisList();

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisList);
            ByStatus_Clicked(sender, e);
            fThesisFilter.SetUpFilter(people);
        }

        #endregion

        #region EVENT gGradientButtonStatistical

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AddUserControl(gGradientButtonStatistical, new UCStudentStatistical());
        }

        #endregion

        #region EVENT gGradientButtonCreateThesis

        private void gGradientButtonCreateThesis_Click(object sender, EventArgs e)
        {
            uCThesisCreate.SetCreateState(people);
            AddUserControl(gGradientButtonCreateThesis, uCThesisCreate);
        }

        #endregion

        #region EVENT ThesisListPreviousState

        private void ThesisListPreviousState(object sender, EventArgs e)
        {
            UpdateThesisList();
            GFilter_Click(sender, e);
        }

        #endregion

        #region THESIS DETAILS

        private void ThesisDetailsBack_Clicked(object sender, EventArgs e)
        {
            ThesisListPreviousState(sender, e);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisList);
        }

        #endregion

        #region THESIS LINE 

        private void ThesisLine_Clicked(object sender, EventArgs e)
        {
            UCThesisLine thesisLine = sender as UCThesisLine;

            if (thesisLine != null)
            {
                gPanelDataView.Controls.Clear();
                Thesis thesis = thesisDAO.SelectOnly(thesisLine.ID);
                uCThesisDetails.FlagWaiting = this.flagStuMyTheses && (thesis.Status == EThesisStatus.Registered || thesis.Status == EThesisStatus.Published);
                uCThesisDetails.SetInformation(thesis, people);
                gPanelDataView.Controls.Add(uCThesisDetails);
            }
        }

        #endregion

        #region THESIS LIST

        private void ByFavorite_Clicked(object sender, EventArgs e)
        {
            listThesis.Sort((a, b) => a.IsFavorite == true ? -1 : b.IsFavorite == true ? 1 : 0);
            LoadThesisList();
        }
        private void ByTopic_Clicked(object sender, EventArgs e)
        {
            listThesis = listThesis.OrderBy(thesis => thesis.Topic).ToList();
            LoadThesisList();
        }
        private void ByFilter_Clicked(object sender, EventArgs e)
        {
            this.fThesisFilter = new FThesisFilter();

            fThesisFilter.SetUpFilter(people);
            fThesisFilter.ListThesis = this.currentList;
            fThesisFilter.GButtonFilter.Click += GFilter_Click;
            this.fThesisFilter.ShowDialog();
        }
        private void ByStatus_Clicked(object sender, EventArgs e)
        {
            listThesis.Sort((a, b) => a.GetPriority().CompareTo(b.GetPriority()));
            LoadThesisList();
        }
        private void ByThesisCode_Clicked(object sender, EventArgs e)
        {
            listThesis = listThesis.OrderBy(thesis => thesis.IdThesis).ToList();
            LoadThesisList();
        }
        private void GFilter_Click(object sender, EventArgs e)
        {
            List<Thesis> listFilter = fThesisFilter.ListThesis;
            this.listThesis = currentList.Where(t => listFilter.Any(t2 => t2.IdThesis == t.IdThesis)).ToList();
            LoadThesisList();
        }
        private void ResetThesisList_Clicked(object sender, EventArgs e)
        {
            fThesisFilter.GButtonSave.PerformClick();
        }

        #endregion

        #region FUNCTIONS SEARCH

        private List<Thesis> GetThesisListByTopic(Guna2TextBox textBox)
        {
            string command = string.Empty;
            if (people.Role == ERole.Lecture)
            {
                command = string.Format("SELECT * FROM {0} WHERE idinstructor = '{1}' and topic LIKE '{2}%'",
                                    MyDatabase.DBThesis, people.IdAccount, textBox.Text);
            }
            else
            {
                command = string.Format("SELECT * FROM {0} WHERE status IN ('{1}', '{2}') and topic LIKE '{3}%'",
                                    MyDatabase.DBThesis, EThesisStatus.Published.ToString(), EThesisStatus.Registered.ToString(), textBox.Text);
            }
            return thesisDAO.SelectList(command);
        }
        private void SearchThesisTopic_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = sender as Guna2TextBox;

            if (textBox != null)
            {
                List<Thesis> listFilter = GetThesisListByTopic(textBox);
                List<Thesis> temp = this.listThesis;
                this.listThesis = listThesis.Where(t => listFilter.Any(t2 => t2.IdThesis == t.IdThesis)).ToList();
                LoadThesisList();
                this.listThesis = temp;
            }
        }

        #endregion

    }
}

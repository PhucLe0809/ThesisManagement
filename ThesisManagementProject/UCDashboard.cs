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
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCDashboard : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private Thesis thesisClicked = new Thesis();
        private People people = new People();
        private List<Thesis> currentList = new List<Thesis>();
        private List<Thesis> listThesis = new List<Thesis>();

        private ThesisDAO thesisDAO = new ThesisDAO();

        private UCThesisList uCThesisList = new UCThesisList();
        private UCThesisCreate uCThesisCreate = new UCThesisCreate();
        private UCThesisDetails uCThesisDetails = new UCThesisDetails();
        private UCThesisLine thesisLineClicked = new UCThesisLine();
        private FThesisFilter fThesisFilter = new FThesisFilter();

        private bool flagStuMyTheses = false;

        public UCDashboard()
        {
            InitializeComponent();

            #region Record EVENT User control

            uCThesisDetails.GButtonBack.Click += ThesisDetailsBack_Clicked;

            uCThesisList.GButtonCreateThesis.Click += gGradientButtonCreateThesis_Click;
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
        private void UpdateUCThesisLine(bool flag, Thesis newThesis)
        {
            if (flag)
            {
                this.thesisLineClicked.SetInformation(newThesis);
            }
        }
        private void UpdateThesisListLecture()
        {
            this.currentList = thesisDAO.SelectListRoleLecture(this.people.IdAccount);
            this.listThesis = currentList;
        }
        private void UpdateThesisListStudent()
        {
            this.currentList = thesisDAO.SelectListRoleStudent(this.people.IdAccount);
            this.listThesis = currentList;
        }
        private void UpdateThesisListStuMyTheses()
        {
            this.currentList = thesisDAO.SelectListModeMyTheses(this.people.IdAccount);
            this.listThesis = currentList;
        }
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonViewThesis);
            myProcess.ButtonStandardColor(gGradientButtonStatistical);
        }
        private void AddUserControl(Guna2GradientButton button, UserControl userControl)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(button);
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
                if (people.Role == ERole.Student) thesisLine.HideToolBar();
                uCThesisList.AddThesis(thesisLine);
            }
            uCThesisList.SetNumThesis(listThesis.Count, true);
        }

        #endregion

        #region EVENT gGradientButtonViewThesis

        private void gGradientButtonViewThesis_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonViewThesis);
            UpdateThesisList();

            gPanelDataView.Controls.Clear();
            uCThesisList.SetFilter(false);
            gPanelDataView.Controls.Add(uCThesisList);
            ByStatus_Clicked(sender, e);
            fThesisFilter.SetUpFilter(people);
        }

        #endregion

        #region EVENT gGradientButtonStatistical

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AddUserControl(gGradientButtonStatistical, new UCDashboardStatistical());
        }

        #endregion

        #region EVENT gGradientButtonCreateThesis

        private void gGradientButtonCreateThesis_Click(object sender, EventArgs e)
        {
            uCThesisCreate.SetCreateState(people);
            AddUserControl(new Guna2GradientButton(), uCThesisCreate);
        }

        #endregion

        #region THESIS DETAILS

        private void ThesisDetailsBack_Clicked(object sender, EventArgs e)
        {
            UpdateUCThesisLine(uCThesisDetails.ThesisEdited, uCThesisDetails.GetThesis);
            if (uCThesisDetails.ThesisDeleted) uCThesisList.ThesisDelete_Clicked(this.thesisLineClicked, e);
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
                this.thesisClicked = thesisDAO.SelectOnly(thesisLine.ID);
                this.thesisLineClicked = thesisLine;
                uCThesisDetails.FlagWaiting = this.flagStuMyTheses && (thesisClicked.Status == EThesisStatus.Registered || thesisClicked.Status == EThesisStatus.Published);
                uCThesisDetails.SetInformation(this.thesisClicked, people);
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
            uCThesisList.SetFilter(true);
            List<Thesis> listFilter = fThesisFilter.ListThesis;
            this.listThesis = currentList.Where(t => listFilter.Any(t2 => t2.IdThesis == t.IdThesis)).ToList();
            LoadThesisList();
        }
        private void ResetThesisList_Clicked(object sender, EventArgs e)
        {
            gGradientButtonViewThesis_Click(sender, e);
        }

        #endregion

        #region FUNCTIONS SEARCH

        private List<Thesis> GetThesisListByTopic(Guna2TextBox textBox)
        {
            if (people.Role == ERole.Lecture)
            {

                return thesisDAO.SearchRoleLecture(this.people.IdAccount, textBox.Text);
            }
            else
            {
                return thesisDAO.SearchRoleStudent(textBox.Text);
            }
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

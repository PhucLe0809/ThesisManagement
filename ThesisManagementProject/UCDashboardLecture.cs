﻿using Guna.UI2.WinForms;
using System;
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
    public partial class UCDashboardLecture : UserControl
    {

        private UCThesisList uCThesisList = new UCThesisList();
        private UCThesisCreate uCThesisCreate = new UCThesisCreate();
        private UCThesisDetails uCThesisDetails = new UCThesisDetails();

        private ThesisDAO thesisDAO = new ThesisDAO();
        private People people = new People();
        private List<Thesis> listThesis = new List<Thesis>();


        public UCDashboardLecture()
        {
            InitializeComponent();

            #region Record EVENT User control

            uCThesisDetails.GButtonBack.Click += gGradientButtonViewThesis_Click;

            uCThesisList.GButtonFavorite.Click += ByFavorite_Clicked;
            uCThesisList.GButtonTopic.Click += ByTopic_Clicked;
            uCThesisList.GButtonStatus.Click += ByStatus_Clicked;
            uCThesisList.GButtonThesisCode.Click += ByThesisCode_Clicked;
            uCThesisList.GTextBoxSearch.TextChanged += SearchThesisTopic_TextChanged;
            uCThesisList.GButtonFieldFilter.Click += FieldFilter_Clicked;
            uCThesisList.GComboBoxField.SelectedIndexChanged += Field_SelectedIndexChanged;

            uCThesisCreate.GButtonCancel.Click += gGradientButtonViewThesis_Click;

            #endregion

        }

        #region FUNCTIONS

        public void SetInformation(People people)
        {
            this.people = people;
            gGradientButtonViewThesis.PerformClick();
        }
        private void ThesisListPreviousState()
        {
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisList);
        }
        private void InitThesisListWithCommand(string command)
        {
            listThesis = thesisDAO.SelectList(command);
            LoadThesisList();
        }
        private void UpdateThesisList()
        {
            string command = string.Format("SELECT * FROM {0} WHERE idcreator = '{1}'", MyDatabase.DBThesis, people.IdAccount);
            this.listThesis = thesisDAO.SelectList(command);
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
                thesisLine.ThesisEditClicked += ThesisEdit_Clicked;
                thesisLine.ThesisDeleteClicked += ThesisDelete_Clicked;
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
            ByStatus_Clicked(sender, e);

            ThesisListPreviousState();
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
            uCThesisCreate.SetInformation(people);
            AddUserControl(gGradientButtonCreateThesis, uCThesisCreate);
        }

        #endregion

        #region THESIS LINE 

        private void ThesisLine_Clicked(object sender, EventArgs e)
        {
            UCThesisLine thesisLine = sender as UCThesisLine;

            if (thesisLine != null)
            {
                gPanelDataView.Controls.Clear();
                uCThesisDetails.SetInformation(thesisDAO.SelectOnly(thesisLine.ID));
                gPanelDataView.Controls.Add(uCThesisDetails);
            
            }
        }
        private void ThesisDelete_Clicked(object sender, EventArgs e)
        {
            gGradientButtonViewThesis_Click(new object(), new EventArgs());
        }
        private void ThesisEdit_Clicked(object sender, EventArgs e)
        {
            gGradientButtonViewThesis_Click(new object(), new EventArgs());
        }

        #endregion

        #region FUNCTIONS SORT

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

        #endregion

        #region FUNCTIONS SEARCH

        private void SearchThesisTopic_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = sender as Guna2TextBox;

            if (textBox != null)
            {
                string command = string.Format("SELECT * FROM {0} WHERE idcreator = '{1}' and topic LIKE '{2}%'",
                                    MyDatabase.DBThesis, people.IdAccount, textBox.Text);
                this.listThesis = thesisDAO.SelectList(command);
                LoadThesisList();
            }
        }

        #endregion

        #region FUNCTIONS FILTER

        private void Field_SelectedIndexChanged(object sender, EventArgs e)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idcreator = '{1}' and field = '{2}'",
                                    MyDatabase.DBThesis, people.IdAccount, uCThesisList.GComboBoxField.SelectedItem.ToString());

            InitThesisListWithCommand(command);
        }
        private void FieldFilter_Clicked(object sender, EventArgs e)
        {
            uCThesisList.SetSelectAllField();

            if (uCThesisList.SelectAllField)
            {
                Field_SelectedIndexChanged(new object(), new EventArgs());
            }
            else
            {
                string command = string.Format("SELECT * FROM {0} WHERE idcreator = '{1}'", MyDatabase.DBThesis, people.IdAccount);
                InitThesisListWithCommand(command);
            }
        }

        #endregion

    }
}

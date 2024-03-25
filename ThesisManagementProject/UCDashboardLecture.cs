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

namespace ThesisManagementProject
{
    public partial class UCDashboardLecture : UserControl
    {
        #region User Control

        UCThesisList uCThesisList = new UCThesisList();
        UCThesisStatistical uCThesisStatistical = new UCThesisStatistical();
        UCThesisCreate uCThesisCreate = new UCThesisCreate();
        UCThesisDetails uCThesisDetails = new UCThesisDetails();

        #endregion

        #region Class

        ThesisDAO thesisDAO = new ThesisDAO();

        #endregion

        public UCDashboardLecture()
        {
            InitializeComponent();

            gGradientButtonViewTopic_Click(new object(), new EventArgs());

            uCThesisDetails.GButtonBack.Click += gGradientButtonViewTopic_Click;
            uCThesisList.GButtonReset.Click += gGradientButtonViewTopic_Click;
            uCThesisList.GButtonTopic.Click += ByTopic_Clicked;
        }

        #region FUNCTIONS

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

        #endregion

        #region EVENT gGradientButtonViewTopic

        private void LoadThesisList(List<Thesis> list)
        {
            uCThesisList.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                UCThesisLine thesisLine = new UCThesisLine();
                thesisLine.SetInformation(list[i]);
                thesisLine.ThesisLineClicked += ThesisLine_Clicked;
                thesisLine.ThesisDeleteClicked += ThesisDelete_Clicked;
                uCThesisList.AddThesis(thesisLine);
            }
            uCThesisList.SetNumThesis(list.Count);

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisList);
        }

        private void gGradientButtonViewTopic_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonViewThesis);

            LoadThesisList(thesisDAO.SelectList());
        }

        #endregion

        #region EVENT gGradientButtonStatistical

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AddUserControl(gGradientButtonStatistical, uCThesisStatistical);
        }

        #endregion

        #region EVENT gGradientButtonCreateThesis

        private void gGradientButtonCreateThesis_Click(object sender, EventArgs e)
        {
            AddUserControl(gGradientButtonCreateThesis, uCThesisCreate);
        }

        #endregion

        #region METHOD

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
        public void ThesisDelete_Clicked(object sender, EventArgs e)
        {
            gGradientButtonViewTopic_Click(new object(), new EventArgs());
        }
        public void ByTopic_Clicked(object sender, EventArgs e)
        {
            List<Thesis> list = thesisDAO.SelectList();
            LoadThesisList(list.OrderBy(thesis => thesis.Topic).ToList());
        }

        #endregion


    }
}

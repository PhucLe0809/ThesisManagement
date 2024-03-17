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

namespace ThesisManagementProject
{
    public partial class UCDashboardLecture : UserControl
    {
        UCThesisList uCThesisList = new UCThesisList();
        UCThesisStatistical uCThesisStatistical = new UCThesisStatistical();
        UCThesisCreate uCThesisCreate = new UCThesisCreate();

        UCThesisDetails uCThesisDetails = new UCThesisDetails();

        public UCDashboardLecture()
        {
            InitializeComponent();

            gGradientButtonViewTopic_Click(new object(), new EventArgs());

            uCThesisDetails.GButtonBack.Click += ThesisDetailsButtonBack_Click;
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

        private void gGradientButtonViewTopic_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonViewThesis);

            uCThesisList.Clear();
            for (int i = 0; i < 4; i++)
            {
                UCThesisLine thesis = new UCThesisLine();
                thesis.SetFavorites();
                thesis.ThesisLineClicked += ThesisLine_Clicked;
                uCThesisList.AddThesis(thesis);
            }
            for (int i = 0; i < 12; i++)
            {
                UCThesisLine thesis = new UCThesisLine();
                thesis.ThesisLineClicked += ThesisLine_Clicked;
                uCThesisList.AddThesis(thesis);
            }

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisList);
        }

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonStatistical);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisStatistical);
        }

        private void gGradientButtonCreateThesis_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonCreateThesis);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisCreate);
        }

        private void ThesisLine_Clicked(object sender, EventArgs e)
        {
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisDetails);
        }

        private void ThesisDetailsButtonBack_Click(object sender, EventArgs e)
        {
            gGradientButtonViewTopic_Click(new object(), new EventArgs());
        }
    }
}

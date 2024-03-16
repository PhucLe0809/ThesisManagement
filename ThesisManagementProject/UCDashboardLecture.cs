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
        UCThesisList uCThesisListView = new UCThesisList();
        UCThesisStatistical uCThesisStatistical = new UCThesisStatistical();
        UCThesisCreate uCThesisCreate = new UCThesisCreate();

        public UCDashboardLecture()
        {
            InitializeComponent();

            gGradientButtonViewTopic_Click(new object(), new EventArgs());
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

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisListView);

            uCThesisListView.Clear();
            for (int i = 0; i < 4; i++)
            {
                UCThesisLine thesis = new UCThesisLine();
                thesis.SetFavorites();
                uCThesisListView.AddThesis(thesis);
            }
            for (int i = 0; i < 12; i++)
            {
                uCThesisListView.AddThesis(new UCThesisLine());
            }
        }

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonStatistical);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisStatistical);
        }

        private void gGradientButtonFavorites_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisListView);

            uCThesisListView.Clear();
            for (int i = 0; i < 8; i++)
            {
                UCThesisLine thesis = new UCThesisLine();
                thesis.SetFavorites();
                uCThesisListView.AddThesis(thesis);
            }
        }

        private void gGradientButtonCreateThesis_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonCreateThesis);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCThesisCreate);
        }
    }
}

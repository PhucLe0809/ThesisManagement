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
    public partial class UCTopic : UserControl
    {
        UCTopicList uCTopicListView = new UCTopicList();
        UCTopicStatistical uCStatisticsTopic = new UCTopicStatistical();
        UCTopicCreate uCAddTopic = new UCTopicCreate();

        public UCTopic()
        {
            InitializeComponent();

            flpRecent.Controls.Clear();
            flpFavorites.Controls.Clear();
            flpDataView.Controls.Clear();

            for (int i = 0; i < 6; i++)
            {
                UCTopicMiniLine uC = new UCTopicMiniLine();
                flpRecent.Controls.Add(uC);
            }
            for (int i = 0; i < 6; i++)
            {
                UCTopicMiniLine uC = new UCTopicMiniLine();
                flpFavorites.Controls.Add(uC);
            }

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
            ButtonStandardColor(gGradientButtonViewTopic);
            ButtonStandardColor(gGradientButtonStatistical);
            ButtonStandardColor(gGradientButtonCreateTopic);
        }

        private void gGradientButtonViewTopic_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonViewTopic);

            uCTopicListView.Clear();
            for (int i = 0; i < 12; i++)
            {
                uCTopicListView.AddThesis(new UCTopicLine());
            }

            flpDataView.Controls.Clear();
            flpDataView.Controls.Add(uCTopicListView);
        }
        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonStatistical);
            flpDataView.Controls.Clear();
            flpDataView.Controls.Add(uCStatisticsTopic);
        }
        private void gGradientButtonAddTopic_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonCreateTopic);
            flpDataView.Controls.Clear();
            flpDataView.Controls.Add(uCAddTopic);
        }

        private void gButtonFilter_Click(object sender, EventArgs e)
        {
            FTopicFilter fFilterSetting = new FTopicFilter();
            fFilterSetting.ShowDialog();
        }

        private void gGradientButtonRecentSeeAll_Click(object sender, EventArgs e)
        {
            uCTopicListView.Clear();
            for (int i = 0; i < 7; i++)
            {
                uCTopicListView.AddThesis(new UCTopicLine());
            }

            flpDataView.Controls.Clear();
            flpDataView.Controls.Add(uCTopicListView);
        }

        private void gGradientButtonFavoritesSeeAll_Click(object sender, EventArgs e)
        {
            uCTopicListView.Clear();
            for (int i = 0; i < 5; i++)
            {
                UCTopicLine line = new UCTopicLine();
                line.SetFavorites();
                uCTopicListView.AddThesis(line);
            }

            flpDataView.Controls.Clear();
            flpDataView.Controls.Add(uCTopicListView);
        }
    }
}
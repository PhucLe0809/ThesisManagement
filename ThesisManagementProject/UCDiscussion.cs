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
    public partial class UCDiscussion : UserControl
    {
        UCDiscussionView uCDiscussionView = new UCDiscussionView();
        UCDiscussionStatistical uCDiscussionStatistical = new UCDiscussionStatistical();

        public UCDiscussion()
        {
            InitializeComponent();

            for (int i = 0; i < 12; i++)
            {
                UCDiscussionLine uCLineDiscuss = new UCDiscussionLine();
                flpLineDiscuss.Controls.Add(uCLineDiscuss);
            }

            gGradientButtonDiscuss_Click(new object(), new EventArgs());
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
            ButtonStandardColor(gGradientButtonDiscuss);
            ButtonStandardColor(gGradientButtonStatistical);
            ButtonStandardColor(gGradientButtonResources);
        }

        private void gGradientButtonDiscuss_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonDiscuss);
            gPanelDataView.Controls.Clear();

            uCDiscussionView.Clear();
            for (int i = 0; i < 10; i++)
            {
                uCDiscussionView.AddMessage(new UCDiscussionMessage());
            }
            gPanelDataView.Controls.Add(uCDiscussionView);
        }

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonStatistical);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCDiscussionStatistical);
        }

        private void gGradientButtonResources_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonResources);
            UCDescussionResource uCDescussionResource = new UCDescussionResource();
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCDescussionResource);
        }
    }
}

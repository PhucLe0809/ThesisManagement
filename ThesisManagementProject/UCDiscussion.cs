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
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCDiscussion : UserControl
    {
        private MyProcess myProcess = new MyProcess();
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
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonDiscuss);
            myProcess.ButtonStandardColor(gGradientButtonStatistical);
            myProcess.ButtonStandardColor(gGradientButtonResources);
        }

        private void gGradientButtonDiscuss_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonDiscuss);
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
            myProcess.ButtonSettingColor(gGradientButtonStatistical);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCDiscussionStatistical);
        }

        private void gGradientButtonResources_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonResources);
            UCDiscussionResource uCDescussionResource = new UCDiscussionResource();
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCDescussionResource);
        }
    }
}

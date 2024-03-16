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
    public partial class UCStudents : UserControl
    {
        UCIndividualList uCStudentList = new UCIndividualList();
        UCTeamList uCTeamList = new UCTeamList();
        UCStudentStatistical uCStudentStatistical = new UCStudentStatistical();

        public UCStudents()
        {
            InitializeComponent();

            gGradientButtonStudentList_Click(new object(), new EventArgs());
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
            ButtonStandardColor(gGradientButtonIndividualList);
            ButtonStandardColor(gGradientButtonTeamList);
            ButtonStandardColor(gGradientButtonStatistical);
        }

        private void gGradientButtonStudentList_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonIndividualList);
            
            uCStudentList.Clear();
            for (int i = 0; i < 4; i++)
            {
                UCIndividualLine line = new UCIndividualLine();
                line.SetFavorites();
                uCStudentList.AddStudent(line);
            }
            for (int i = 0; i < 8; i++)
            {
                uCStudentList.AddStudent(new UCIndividualLine());
            }

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCStudentList);
        }

        private void gGradientButtonTeamList_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonTeamList);
            
            uCTeamList.Clear();
            for (int i = 0; i < 3; i++)
            {
                UCTeamLine line = new UCTeamLine();
                line.SetFavorites();
                uCTeamList.AddTeam(line);
            }
            for (int i = 0; i < 4; i++)
            {
                uCTeamList.AddTeam(new UCTeamLine());
            }

            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCTeamList);
        }

        private void gGradientButtonStatistical_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            ButtonSettingColor(gGradientButtonStatistical);
            gPanelDataView.Controls.Clear();
            gPanelDataView.Controls.Add(uCStudentStatistical);
        }
    }
}

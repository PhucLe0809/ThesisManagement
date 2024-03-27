using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Models;

namespace ThesisManagementProject
{
    public partial class FTeamDetails : Form
    {
        private Team team = new Team();

        public FTeamDetails()
        {
            InitializeComponent();

            for (int i = 0;  i < 10; i++)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine();
                line.SetButtonAddImageNull();
                flpMembers.Controls.Add(line);
            }
        }
        public FTeamDetails(Team team)
        {
            InitializeComponent();

            this.team = team;
            for (int i = 0; i < 10; i++)
            {
                UCPeopleMiniLine line = new UCPeopleMiniLine();
                line.SetButtonAddImageNull();
                flpMembers.Controls.Add(line);
            }
        }
    }
}

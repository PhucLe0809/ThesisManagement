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
    public partial class FTeamDetails : Form
    {
        public FTeamDetails()
        {
            InitializeComponent();

            for (int i = 0;  i < 10; i++)
            {
                UCStudentMiniLine line = new UCStudentMiniLine();
                line.SetButtonAddImageNull();
                flpMembers.Controls.Add(line);
            }
        }
    }
}

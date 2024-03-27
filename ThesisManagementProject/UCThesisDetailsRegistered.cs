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
    public partial class UCThesisDetailsRegistered : UserControl
    {
        public UCThesisDetailsRegistered()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            flpTeamRegistered.Controls.Clear();
        }
        public void AddTeam(UCTeamMiniLine line)
        {
            flpTeamRegistered.Controls.Add(line);
        }
    }
}

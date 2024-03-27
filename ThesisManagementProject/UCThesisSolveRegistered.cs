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
    public partial class UCThesisSolveRegistered : UserControl
    {
        public UCThesisSolveRegistered()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            flpTeamRegistered.Controls.Clear();
        }
        public void AddRegistered(UCTeamMiniLine line)
        {
            flpTeamRegistered.Controls.Add(line);
        }
    }
}

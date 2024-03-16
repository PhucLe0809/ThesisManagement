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
    public partial class UCTeamList : UserControl
    {
        public UCTeamList()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            flpDataView.Controls.Clear();
        }

        public void AddTeam(UCTeamLine line)
        {
            flpDataView.Controls.Add(line);
        }

        private void gButtonFilter_Click(object sender, EventArgs e)
        {
            FTeamFilter filter = new FTeamFilter();
            filter.ShowDialog();
        }

        private void gGradientButtonCreateTeam_Click(object sender, EventArgs e)
        {
            FTeamCreate fTeamCreate = new FTeamCreate();
            fTeamCreate.ShowDialog();
        }
    }
}

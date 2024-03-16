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
    public partial class FTeamCreate : Form
    {
        public FTeamCreate()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                UCStudentMiniLine line = new UCStudentMiniLine();
                flpLineStudent.Controls.Add(line);
            }

            for (int i = 0; i < 15; i++)
            {
                UCStudentItemAdd item = new UCStudentItemAdd();
                flpStudentAvatar.Controls.Add(item);    
            }
        }

        private void gButtonFilter_Click(object sender, EventArgs e)
        {
            FStudentFilter filter = new FStudentFilter();
            filter.ShowDialog();
        }

        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gGradientButtonCreate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

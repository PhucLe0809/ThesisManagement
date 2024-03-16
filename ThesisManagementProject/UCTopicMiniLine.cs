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
    public partial class UCTopicMiniLine : UserControl
    {
        public UCTopicMiniLine()
        {
            InitializeComponent();
        }

        private void gGradientButton_Click(object sender, EventArgs e)
        {
            FTopicDetails fTopicDetails = new FTopicDetails();
            fTopicDetails.Show();
        }
    }
}

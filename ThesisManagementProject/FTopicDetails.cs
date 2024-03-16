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
    public partial class FTopicDetails : Form
    {
        public FTopicDetails()
        {
            InitializeComponent();
        }

        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gGradientButtonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class FDisplayMain : Form
    {
        UCDisplayLecture uCDisplayLecture = new UCDisplayLecture();
        UCDisplayWelcome uCDisplayWelcome = new UCDisplayWelcome();
        public FDisplayMain()
        {
            InitializeComponent();

            gPanelDisplay.Controls.Add(uCDisplayWelcome);

            uCDisplayWelcome.GGradientButtonLecture.Click += gGradientButtonLecture_Click;
            uCDisplayLecture.GButtonLogOut.Click += gButtonLogOut_Click;
        }

        private void gGradientButtonLecture_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayLecture);
        }

        private void gButtonLogOut_Click(object sender, EventArgs e)
        {
            gPanelDisplay.Controls.Clear();
            gPanelDisplay.Controls.Add(uCDisplayWelcome);
        }
    }
}

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
    public partial class UCThesisMiniLine : UserControl
    {
        public UCThesisMiniLine()
        {
            InitializeComponent();
        }

        private void UCThesisMiniLine_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisEdit = new FThesisEdit();
            fThesisEdit.ShowDialog();
        }
    }
}

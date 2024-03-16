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
    public partial class UCTopicList : UserControl
    {
        UCTopicLine uCLineThesis = new UCTopicLine();
        public UCTopicList()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            flpDataView.Controls.Clear();
        }

        public void AddThesis(UCTopicLine uCTopicLine)
        {
            flpDataView.Controls.Add(uCTopicLine);
        }
    }
}

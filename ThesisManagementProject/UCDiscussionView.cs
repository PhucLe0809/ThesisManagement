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
    public partial class UCDiscussionView : UserControl
    {
        public UCDiscussionView()
        {
            InitializeComponent();

            for (int i = 0; i < 2; i++)
            { 
                UCDiscussionMessage uCMessageSent = new UCDiscussionMessage();
                flpMessage.Controls.Add(uCMessageSent);
            }

            UCDiscussionMessage uC = new UCDiscussionMessage();
            flpMessage.Controls.Add(uC);
        }

        public void Clear()
        {
            flpMessage.Controls.Clear();
        }

        public void AddMessage(UCDiscussionMessage message)
        {
            flpMessage.Controls.Add(message);
        }
    }
}

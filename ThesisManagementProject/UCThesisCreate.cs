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
    public partial class UCThesisCreate : UserControl
    {
        int btnNowCount = 0;
        public UCThesisCreate()
        {
            InitializeComponent();
        }

        private void gButtonTopicilter_Click(object sender, EventArgs e)
        {
            FTopicFilter topicFilter = new FTopicFilter();
            topicFilter.ShowDialog();
        }

        private void gButtonPublishNow_Click(object sender, EventArgs e)
        {
            btnNowCount++;

            if (btnNowCount % 2 != 0)
            {
                gButtonPublishNow.Image = Properties.Resources.PicItemOff;
                gDateTimePickerPublish.Enabled = true;
            }
            else
            {
                gButtonPublishNow.Image = Properties.Resources.PicItemOn;
                gDateTimePickerPublish.Enabled = false;

            }
        }
    }
}

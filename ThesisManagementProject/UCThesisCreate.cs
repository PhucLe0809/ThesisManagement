using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCThesisCreate : UserControl
    {
        int btnNowCount = 0;
        Thesis thesis = new Thesis();
        ThesisDAO thesisDAO = new ThesisDAO();

        public UCThesisCreate()
        {
            InitializeComponent();
        }

        #region EVENT FORM     

        private void UCThesisCreate_Load(object sender, EventArgs e)
        {
            MyProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            MyProcess.AddEnumsToComboBox(gComboBoxLevel, typeof(ELevel));
        }

        #endregion

        #region EVENT gButtonTopicilter

        private void gButtonTopicilter_Click(object sender, EventArgs e)
        {
            FTopicFilter topicFilter = new FTopicFilter();
            topicFilter.ShowDialog();
        }

        #endregion

        #region EVENT gButtonPublishNow

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

        #endregion

        #region EVENT gGradientButtonCreate

        private void gGradientButtonCreate_Click(object sender, EventArgs e)
        {
            this.thesis = new Thesis(gTextBoxTopic.Text, 
                (EField)gComboBoxField.SelectedItem, (ELevel)gComboBoxLevel.SelectedItem,
                MyProcess.ConvertStringToInt32(gTextBoxMembers.Text), gTextBoxDescription.Text, gTextBoxReference.Text, 
                gDateTimePickerPublish.Value, gTextBoxTechnology.Text, gTextBoxFunctions.Text, gTextBoxRequirements.Text);
            thesisDAO.Insert(thesis);
        }

        #endregion

    }
}

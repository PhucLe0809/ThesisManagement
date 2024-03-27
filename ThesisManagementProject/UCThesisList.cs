using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCThesisList : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        public event EventHandler ThesisLineClicked;
        public event EventHandler ThesisEditClicked;
        public event EventHandler ThesisDeleteClicked;
        private bool selectAllField = true;

        public UCThesisList()
        {
            InitializeComponent();

            myProcess.AddEnumsToComboBox(gComboBoxField, typeof(EField));
            gComboBoxField.StartIndex = 0;
            SetSelectAllField();
        }

        #region PROPERTIES

        public Guna2GradientButton GButtonFavorite
        {
            get { return this.gGradientButtonTag; }
        }
        public Guna2GradientButton GButtonFavorite
        {
            get { return this.GButtonFavorite; }
        }
        public Guna2GradientButton GButtonTopic
        {
            get { return this.gGradientButtonThesisTopic; }
        }
        public Guna2GradientButton GButtonStatus
        {
            get { return this.gGradientButtonStatus; }
        }
        public Guna2GradientButton GButtonThesisCode
        {
            get { return this.gGradientButtonThesisCode; }
        }
        public Guna2GradientButton GButtonCreator
        {
            get { return this.gGradientButtonCreator; }
        }
<<<<<<< HEAD
        public Guna2TextBox GTextBoxSearch
        {
            get { return this.gTextBoxSearch; }
        }
        public bool SelectAllField
        {
            get { return this.selectAllField; }
        }
        public Guna2Button GButtonFieldFilter
        {
            get { return this.gButtonTopicSelectAll; }
        }
        public Guna2ComboBox GComboBoxField
        {
            get { return this.gComboBoxField; }
        }
=======
>>>>>>> fc16c9125eadc08d3b2f0e878131e290d403669f

        #endregion

        #region FUNCTIONS

        public void Clear()
        {
            flpThesisList.Controls.Clear();
        }
        public void AddThesis(UCThesisLine thesisLine)
        {
            thesisLine.ThesisLineClicked += ThesisLine_Clicked;
            thesisLine.ThesisDeleteClicked += ThesisDelete_Clicked;
            flpThesisList.Controls.Add(thesisLine);
        }
        public void SetNumThesis(int num)
        {
            lblNumThesis.Text = num.ToString();
        }
        public void SetSelectAllField()
        {
            selectAllField = !selectAllField;

            gComboBoxField.Enabled = selectAllField;
            gPictureBoxField.Enabled = selectAllField;
            if (selectAllField)
            {
                gButtonTopicSelectAll.Image = Properties.Resources.PicItemOn;
                gPictureBoxField.BackColor = Color.White;
            }
            else
            {
                gButtonTopicSelectAll.Image = Properties.Resources.PicItemOff;
                gPictureBoxField.BackColor = SystemColors.ControlLight;
            }
        }

        #endregion

        #region EVENT gButtonFilter

        private void gButtonFilter_Click(object sender, EventArgs e)
        {
            FThesisFilter fFilterSetting = new FThesisFilter();
            fFilterSetting.ShowDialog();
        }

        #endregion

        #region METHOD

        private void ThesisLine_Clicked(object sender, EventArgs e)
        {
            OnThesisLineClicked(EventArgs.Empty);
        }
        protected virtual void OnThesisLineClicked(EventArgs e)
        {
            ThesisLineClicked?.Invoke(this, e);
        }
        public virtual void ThesisEdit_Clicked(object sender, EventArgs e)
        {
            OnThesisEditClicked(EventArgs.Empty);
        }
        public virtual void OnThesisEditClicked(EventArgs e)
        {
            ThesisEditClicked?.Invoke(this, e);
        }
        public virtual void ThesisDelete_Clicked(object sender, EventArgs e)
        {
            OnThesisDeleteClicked(EventArgs.Empty);
        }
        public virtual void OnThesisDeleteClicked(EventArgs e)
        {
            ThesisDeleteClicked?.Invoke(this, e);
        }

        #endregion

    }
}

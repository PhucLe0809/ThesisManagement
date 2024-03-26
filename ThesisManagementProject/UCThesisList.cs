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

namespace ThesisManagementProject
{
    public partial class UCThesisList : UserControl
    {
        public event EventHandler ThesisLineClicked;
        public event EventHandler ThesisDeleteClicked;

        public UCThesisList()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public Guna2GradientButton GButtonReset
        {
            get { return this.gGradientButtonReset; }
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

        #endregion

        #region FUNCTIONS

        public void Clear()
        {
            flpDataView.Controls.Clear();
        }
        public void AddThesis(UCThesisLine thesisLine)
        {
            thesisLine.ThesisLineClicked += ThesisLine_Clicked;
            thesisLine.ThesisDeleteClicked += ThesisDelete_Clicked;
            flpDataView.Controls.Add(thesisLine);
        }
        public void SetNumThesis(int num)
        {
            lblNumThesis.Text = num.ToString();
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
        public virtual void ThesisDelete_Clicked(object sender, EventArgs e)
        {
            OnThesisDeleteClicked(EventArgs.Empty);
        }
        public virtual void OnThesisDeleteClicked(EventArgs e)
        {
            ThesisDeleteClicked?.Invoke(this, e);
        }
        private void gGradientButtonReset_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}

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
        }

        #region PROPERTIES

        public Guna2GradientButton GButtonFavorite
        {
            get { return this.gGradientButtonTag; }
        }
        public Guna2GradientButton GButtonTopic
        {
            get { return this.gGradientButtonThesisTopic; }
        }
        public Guna2GradientButton GButtonFilter
        {
            get { return this.gGradientButtonFilter; }
        }
        public Guna2TextBox GTextBoxSearch
        {
            get { return this.gTextBoxSearch; }
        }
        public Guna2Button GButtonReset
        {
            get { return this.gButtonResetList; }
        }

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

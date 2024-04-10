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
        public event EventHandler ThesisLineClicked;
        private int numThesis = 0;

        public UCThesisList()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public Guna2GradientButton GButtonCreateThesis
        {
            get { return this.gGradientButtonCreateThesis; }
        }
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
            SetNumThesis(1, false);
        }
        public void SetNumThesis(int num, bool flagReset)
        {
            if (flagReset) numThesis = num; else numThesis += num;
            lblNumThesis.Text = numThesis.ToString();
        }
        public void SetFilter(bool flag)
        {
            if (flag)
            {
                gGradientButtonFilter.Image = Properties.Resources.PicItemGradientFilter;
                gGradientButtonFilter.FillColor = SystemColors.ButtonFace;
                gGradientButtonFilter.FillColor2 = SystemColors.ButtonFace;
            }
            else
            {
                gGradientButtonFilter.Image = Properties.Resources.PicItemFilter;
                gGradientButtonFilter.FillColor = Color.White;
                gGradientButtonFilter.FillColor2 = Color.White;
            }
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
        public void ThesisDelete_Clicked(object sender, EventArgs e)
        {
            UCThesisLine line = sender as UCThesisLine;

            if (line != null)
            {
                foreach (Control control in flpThesisList.Controls)
                {
                    if (control.GetType() == typeof(UCThesisLine))
                    {
                        UCThesisLine thesisLine = (UCThesisLine)control;
                        if (thesisLine == line)
                        {
                            flpThesisList.Controls.Remove(control);
                            control.Dispose();
                            SetNumThesis(-1, false);
                            break;
                        }
                    }
                }
            }
        }

        #endregion

    }
}

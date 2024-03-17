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

        public UCThesisList()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            flpDataView.Controls.Clear();
        }

        public void AddThesis(UCThesisLine thesis)
        {
            thesis.ThesisLineClicked += ThesisLine_Clicked;
            flpDataView.Controls.Add(thesis);
        }

        private void gButtonFilter_Click(object sender, EventArgs e)
        {
            FThesisFilter fFilterSetting = new FThesisFilter();
            fFilterSetting.ShowDialog();
        }

        private void ThesisLine_Clicked(object sender, EventArgs e)
        {
            OnThesisLineClicked(EventArgs.Empty);
        }

        protected virtual void OnThesisLineClicked(EventArgs e)
        {
            ThesisLineClicked?.Invoke(this, e);
        }
    }
}

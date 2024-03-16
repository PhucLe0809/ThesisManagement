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
            flpDataView.Controls.Add(thesis);
        }

        private void gButtonFilter_Click(object sender, EventArgs e)
        {
            FThesisFilter fFilterSetting = new FThesisFilter();
            fFilterSetting.ShowDialog();
        }
    }
}

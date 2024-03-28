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
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class FThesisEdit : Form
    {
        private UCThesisCreate uCThesisCreate = new UCThesisCreate();

        public FThesisEdit()
        {
            InitializeComponent();

            gPanelEdit.Controls.Clear();
            gPanelEdit.Controls.Add(new UCThesisCreate());
        }
        public FThesisEdit(People people, Thesis thesis)
        {
            InitializeComponent();

            InitUserControl(people, thesis);
        }

        public void InitUserControl(People people, Thesis thesis)
        {
            gPanelEdit.Controls.Clear();
            uCThesisCreate.SetEditState(people, thesis);
            gPanelEdit.Controls.Add(uCThesisCreate);

            uCThesisCreate.GButtonCancel.Click += ButtonCancel_Clicked;
        }
        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

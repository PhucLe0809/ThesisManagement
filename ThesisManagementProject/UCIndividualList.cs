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
    public partial class UCIndividualList : UserControl
    {
        public UCIndividualList()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            flpDataView.Controls.Clear();
        }

        public void AddStudent(UCIndividualLine student)
        {
            flpDataView.Controls.Add(student);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FStudentFilter fStudentFilter = new FStudentFilter();
            fStudentFilter.ShowDialog();
        }
    }
}

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

namespace ThesisManagementProject
{
    public partial class UCStudentMiniLine : UserControl
    {
        public event EventHandler ThesisMiniLineClicked;
        private Student student = new Student();

        public UCStudentMiniLine()
        {
            InitializeComponent();
        }

        public Guna2Button GButtonAdd
        {
            get { return this.gButtonAdd; }
        }
        public Student GetStudent
        {
            get { return this.student; }
        }

        public void SetInformation(Student student)
        {
            this.student = student;

            UserControlLoad();
        }

        private void UserControlLoad()
        {
            lblUserName.Text = student.Handle;
            lblGender.Text = student.Gender.ToString();
        }

        public void SetButtonAddImageNull()
        {
            gButtonAdd.Image = null;
            gButtonAdd.HoverState.Image = null;
            gButtonAdd.Enabled = false;
        }

        private void ShowStudentInformation()
        {
            FStudentDetails fStudentDetails = new FStudentDetails();
            fStudentDetails.UpdateStudent(MyProcess.SelectStudent(student.IdAccount));
            fStudentDetails.ShowDialog();
        }

        private void gCirclePictureBoxAvatar_Click(object sender, EventArgs e)
        {
            ShowStudentInformation();
        }

        private void gShadowPanelBack_Click(object sender, EventArgs e)
        {
            ShowStudentInformation();
        }

        private void gButtonAdd_Click(object sender, EventArgs e)
        {
            OnThesisMiniLineClicked(EventArgs.Empty);
        }

        public virtual void OnThesisMiniLineClicked(EventArgs e)
        {
            ThesisMiniLineClicked?.Invoke(this, e);
        }
    }
}

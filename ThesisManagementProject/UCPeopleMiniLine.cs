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

namespace ThesisManagementProject
{
    public partial class UCPeopleMiniLine : UserControl
    {
        public event EventHandler ThesisMiniLineClicked;
        private People people = new People();
        private PeopleDAO peopleDAO = new PeopleDAO();

        public UCPeopleMiniLine()
        {
            InitializeComponent();
        }
        public UCPeopleMiniLine(People people)
        {
            InitializeComponent();

            this.people = people;
            UserControlLoad();
        }

        public Guna2Button GButtonAdd
        {
            get { return this.gButtonAdd; }
        }
        public People GetPeople
        {
            get { return this.people; }
        }

        private void UserControlLoad()
        {
            lblUserName.Text = people.Handle;
            lblGender.Text = people.Gender.ToString();
        }

        public void SetButtonAddImageNull()
        {
            gButtonAdd.Image = null;
            gButtonAdd.HoverState.Image = null;
            gButtonAdd.Enabled = false;
        }

        private void ShowPeopleInformation()
        {
            FStudentDetails fStudentDetails = new FStudentDetails();
            fStudentDetails.UpdateStudent(peopleDAO.SelectOnlyByID(people.IdAccount));
            fStudentDetails.ShowDialog();
        }

        private void gCirclePictureBoxAvatar_Click(object sender, EventArgs e)
        {
            ShowPeopleInformation();
        }

        private void gShadowPanelBack_Click(object sender, EventArgs e)
        {
            ShowPeopleInformation();
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

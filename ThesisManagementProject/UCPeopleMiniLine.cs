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
    public partial class UCPeopleMiniLine : UserControl
    {
        public event EventHandler ThesisMiniLineClicked;
        private MyProcess myProcess = new MyProcess();
        private People people = new People();
        private Color uCBackColor = Color.White;
        private Color uCHoverColor = SystemColors.ButtonFace;

        public UCPeopleMiniLine()
        {
            InitializeComponent();
        }
        public UCPeopleMiniLine(People people)
        {
            InitializeComponent();

            SetInformation(people);
        }

        #region PROPERTIES

        public Guna2Button GButtonAdd
        {
            get { return this.gButtonAdd; }
        }
        public People GetPeople
        {
            get { return this.people; }
        }

        #endregion

        #region FUNCTIONS

        public void SetInformation(People people)
        {
            this.people = people;
            InitUserControl();
        }
        private void InitUserControl()
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(people.AvatarName);
            lblUserName.Text = people.Handle;
            lblPeopleCode.Text = people.IdAccount;
            gButtonAdd.Show();
        }
        public void SetButtonAddImageNull()
        {
            gButtonAdd.Hide();
        }
        public void SetBackGroundColor(Color color)
        {
            this.uCBackColor = color;
            this.uCHoverColor = (this.BackColor == Color.White) ? SystemColors.ButtonFace : Color.White;
            ExecuteBackGroundColor(color);
        }
        private void ExecuteBackGroundColor(Color color)
        {
            gShadowPanelBack.FillColor = color;
            gCirclePictureBoxAvatar.BackColor = color;
            lblUserName.BackColor = color;
            lblPeopleCode.BackColor = color;
        }

        private void ShowPeopleInformation()
        {
            FStudentDetails fStudentDetails = new FStudentDetails(people);
            fStudentDetails.ShowDialog();
        }

        #endregion

        #region EVENT CONTROLS

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

        private void gShadowPanelBack_MouseEnter(object sender, EventArgs e)
        {
            ExecuteBackGroundColor(uCHoverColor);
        }
        private void gShadowPanelBack_MouseLeave(object sender, EventArgs e)
        {
            ExecuteBackGroundColor(uCBackColor);
        }

        #endregion

    }
}

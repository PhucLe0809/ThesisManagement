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
        public event EventHandler ButtonAddClicked;
        public event EventHandler ButtonDeleteClicked;

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
        }
        public void SetDeleteMode(bool deleteMode)
        {
            if (deleteMode) gButtonAdd.Show();
            else gButtonAdd.Hide();
        }
        public void SetButtonDelete()
        {
            gButtonAdd.Image = Properties.Resources.PicItemRemove;
            gButtonAdd.FillColor = this.uCBackColor;
            gButtonAdd.BackColor = this.uCBackColor;
            gButtonAdd.HoverState.FillColor = this.uCBackColor;
            gButtonAdd.HoverState.Image = gButtonAdd.Image;
            gButtonAdd.Click += gButtonDelete_Click;
        }
        public void SetBackGroundColor(Color color)
        {
            this.uCBackColor = color;
            this.uCHoverColor = (this.BackColor == Color.White) ? SystemColors.ButtonFace : Color.White;
            ExecuteBackGroundColor(color);
        }
        public void SetSize(Size size)
        {
            this.Size = size;
            gShadowPanelBack.Size = new Size(size.Width - 5, size.Height);
        }
        private void ExecuteBackGroundColor(Color color)
        {
            gShadowPanelBack.FillColor = color;
            gCirclePictureBoxAvatar.BackColor = color;
            lblUserName.BackColor = color;
            lblPeopleCode.BackColor = color;
            gButtonAdd.FillColor = color;
            gButtonAdd.BackColor = color;
            gButtonAdd.PressedColor = color;
        }

        private void ShowPeopleInformation()
        {
            FPeopleDetails fStudentDetails = new FPeopleDetails(people);
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
            OnButtonAddClicked(EventArgs.Empty);
        }
        private void gButtonDelete_Click(object sender, EventArgs e)
        {
            OnButtonDeleteClicked(EventArgs.Empty);
        }
        public virtual void OnThesisMiniLineClicked(EventArgs e)
        {
            ThesisMiniLineClicked?.Invoke(this, e);
        }
        public virtual void OnButtonAddClicked(EventArgs e)
        {
            ButtonAddClicked?.Invoke(this, e);
        }
        public virtual void OnButtonDeleteClicked(EventArgs e)
        {
            ButtonDeleteClicked?.Invoke(this, e);
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

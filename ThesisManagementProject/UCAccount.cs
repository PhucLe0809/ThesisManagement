using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;
using ThesisManagementProject.Properties;

namespace ThesisManagementProject
{
    public partial class UCAccount : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();

        public UCAccount()
        {
            InitializeComponent();
            InitUserControl();
        }
        public UCAccount(People people)
        {
            InitializeComponent();
            SetInformation(people);
        }

        #region FUNCTIONS FORM

        public void SetInformation(People people)
        {
            this.people = people;
            InitUserControl();
        }
        private void InitUserControl()
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(people.AvatarName);
            lblViewHandle.Text = people.Handle;
            lblViewRole.Text = people.Role.ToString();

            gTextBoxFullname.Text = people.FullName;
            gTextBoxCitizencode.Text = people.CitizenCode;
            gDateTimePickerBirthday.Value = people.Birthday;
            gComboBoxGender.SelectedItem = people.Gender.ToString();
            gTextBoxEmail.Text = people.Email;
            gTextBoxPhonenumber.Text = people.PhoneNumber;
            gTextBoxHandle.Text = people.Handle;
            gTextBoxWorkcode.Text = people.WorkCode;

            gPanelEditInfor.Enabled = false;
            gPictureBoxGender.BackColor = Color.Gainsboro;

            for (int i = 0; i < 10; i++)
            {
                flpTheses.Controls.Add(new UCThesisMiniLine());
            }
        }

        #endregion

        #region CONTROL CLICK

        private void gGradientButtonEdit_Click(object sender, EventArgs e)
        {
            gPanelEditInfor.Enabled = true;
            gPictureBoxGender.BackColor = Color.White;
        }

        private void gCirclePictureBoxAvatar_MouseEnter(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureCameraHover;
        }

        private void gCirclePictureBoxAvatar_MouseLeave(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = myProcess.NameToImage(people.AvatarName);
        }

        #endregion

    }
}

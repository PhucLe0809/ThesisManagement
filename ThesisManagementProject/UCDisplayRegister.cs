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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCDisplayRegister : UserControl
    {
        People people = new People();

        public UCDisplayRegister()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        #endregion

        #region EVENT FORM

        private void UCDisplayRegister_Load(object sender, EventArgs e)
        {
            MyProcess.AddEnumsToComboBox(gComboBoxGender, typeof(EGender));
        }

        #endregion

        #region EVENT gCirclePictureBoxAvatar

        private void gCirclePictureBoxAvatar_MouseEnter(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureCameraHover;
        }

        private void gCirclePictureBoxAvatar_MouseLeave(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PicAvatarDemoUser;
        }

        #endregion

        #region EVENT gButtonRegister

        private ERole GetRole()
        {
            if (gRadioButtonStudent.Checked == true)
            {
                return ERole.Student;
            }
            return ERole.Lecture;
        }
        private EClassify GetClassify()
        {
            if (gRadioButtonStudent.Checked == true)
            {
                return EClassify.Student;
            }
            return EClassify.Lecture;
        }

        private void gButtonRegister_Click(object sender, EventArgs e)
        {
            this.people = new People(gTextBoxFullname.Text, gTextBoxCitizencode.Text, gDateTimePickerBirthday.Value,
                (EGender)gComboBoxGender.SelectedItem, gTextBoxEmail.Text, gTextBoxPhonenumber.Text, gTextBoxHandle.Text,
                GetRole(), gTextBoxWorkcode.Text, gTextBoxPassword.Text, GetClassify());
        }

        #endregion

    }
}

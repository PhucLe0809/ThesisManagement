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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject
{
    public partial class UCDisplayRegister : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();
        private bool flagCheck = false;

        private Image pictureAvatar = Properties.Resources.PicAvatarDemoUser;

        public UCDisplayRegister()
        {
            InitializeComponent();

            InitAvatarList();
            gButtonLoadLogin.Hide();
        }

        #region PROPERTIES

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }
        public bool FlagCheck
        {
            set { flagCheck = value; }
        }
        public Guna2Button GButtonLoadLogin
        {
            get { return this.gButtonLoadLogin; }
        }

        #endregion

        #region FUNCTIONS

        private void InitAvatarList()
        {
            // gShadowPanelAvatar.Hide();
            flpAvatarList.Controls.Clear();
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarOne));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarTwo));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarThree));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarFive));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarSix));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarSeven));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarEight));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarNine));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarTen));
            flpAvatarList.Controls.Add(CreateAvatarPictureBox(Properties.Resources.PicAvatarDemoUser));
        }
        public void InitDataControls()
        {
            gTextBoxFullname.Text = string.Empty;
            gTextBoxCitizencode.Text = string.Empty;
            DateTime dateTime = DateTime.Now.AddYears(-18);
            gDateTimePickerBirthday.Value = dateTime;
            gComboBoxGender.StartIndex = 0;
            gTextBoxEmail.Text = string.Empty;
            gTextBoxPhonenumber.Text = string.Empty;
            gTextBoxHandle.Text = string.Empty;
            gTextBoxPassword.Text = string.Empty;
            gTextBoxConfirmPassword.Text = string.Empty;
            gTextBoxWorkcode.Text = string.Empty;
        }
        public void RunCheckInformation()
        {
            myProcess.RunCheckDataValid(people.CheckFullName() || flagCheck, erpFullName, gTextBoxFullname, "Name cannot be empty");
            myProcess.RunCheckDataValid(people.CheckCitizenCode() || flagCheck, erpCitizenCode, gTextBoxCitizencode, "Citizen code is already exists or empty");
            myProcess.RunCheckDataValid(people.CheckBirthday() || flagCheck, erpBirthday, gDateTimePickerBirthday, "Not yet 18 years old");
            myProcess.RunCheckDataValid(people.CheckGender() || flagCheck, erpGender, gComboBoxGender, "Gender cannot be empty");
            myProcess.RunCheckDataValid(people.CheckEmail() || flagCheck, erpEmail, gTextBoxEmail, "Email is already exists or invalid");
            myProcess.RunCheckDataValid(people.CheckPhoneNumber() || flagCheck, erpPhonenumber, gTextBoxPhonenumber, "Phone number is already exists or invalid");
            myProcess.RunCheckDataValid(people.CheckHandle() || flagCheck, erpHandle, gTextBoxHandle, "Handle is already exists or invalid");
            myProcess.RunCheckDataValid(people.CheckPassWord() || flagCheck, erpConfirmPassword, gTextBoxConfirmPassword, "Confirmation password does not match");
            myProcess.RunCheckDataValid(people.CheckWorkCode() || flagCheck, erpWorkCode, gTextBoxWorkcode, "Work code is already exists or invalid");
        }
        private bool CheckInformationValid()
        {
            RunCheckInformation();

            return people.CheckFullName() && people.CheckCitizenCode() && people.CheckBirthday() && people.CheckGender() && people.CheckEmail()
                    && people.CheckPhoneNumber() && people.CheckHandle() && people.CheckPassWord() && people.CheckWorkCode();
        }
        private PictureBox CreateAvatarPictureBox(Image image)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(100, 100);
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.White;
            pictureBox.Click += PictureBoxAvatar_Clicked;

            return pictureBox;
        }

        #endregion

        #region EVENT FORM

        private void UCDisplayRegister_Load(object sender, EventArgs e)
        {
            myProcess.AddEnumsToComboBox(gComboBoxGender, typeof(EGender));
        }

        #endregion

        #region EVENT gCirclePictureBoxAvatar

        private void gCirclePictureBoxAvatar_MouseEnter(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = Properties.Resources.PictureCameraHover;
        }

        private void gCirclePictureBoxAvatar_MouseLeave(object sender, EventArgs e)
        {
            gCirclePictureBoxAvatar.Image = this.pictureAvatar;
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
            this.people = new People(gTextBoxFullname.Text, gTextBoxCitizencode.Text, gDateTimePickerBirthday.Value, (EGender)gComboBoxGender.SelectedItem,
                gTextBoxEmail.Text, gTextBoxPhonenumber.Text, gTextBoxHandle.Text, GetRole(), gTextBoxWorkcode.Text, gTextBoxPassword.Text, gTextBoxConfirmPassword.Text,
                myProcess.ImageToName(gCirclePictureBoxAvatar.Image), GetClassify());

            this.flagCheck = false;
            if (CheckInformationValid())
            {
                DBConnection execute = new DBConnection();
                execute.ExecuteQueryPeople(this.people,
                    "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'," +
                    " '{10}', '{11}', '{12}', '{13}', '{14}')", "Register", false);
                this.flagCheck = true;
                gButtonLoadLogin.PerformClick();
            }
        }

        #endregion

        #region EVENT gCirclePictureBoxAvatar

        private void PictureBoxAvatar_Clicked(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            this.pictureAvatar = pictureBox.Image;
            gCirclePictureBoxAvatar.Image = this.pictureAvatar;
            // gShadowPanelAvatar.Hide();
        }
        private void gCirclePictureBoxAvatar_Click(object sender, EventArgs e)
        {
            gShadowPanelAvatar.Show();
        }

        #endregion

        #region EVENT TextChanged and ValueChanged

        private void gTextBoxFullname_TextChanged(object sender, EventArgs e)
        {
            this.people.FullName = gTextBoxFullname.Text;
            myProcess.RunCheckDataValid(people.CheckFullName() || flagCheck, erpFullName, gTextBoxFullname, "Name cannot be empty");
        }
        private void gTextBoxCitizencode_TextChanged(object sender, EventArgs e)
        {
            this.people.CitizenCode = gTextBoxCitizencode.Text;
            myProcess.RunCheckDataValid(people.CheckCitizenCode() || flagCheck, erpCitizenCode, gTextBoxCitizencode, "Citizen code is already exists or empty");
        }
        private void gDateTimePickerBirthday_ValueChanged(object sender, EventArgs e)
        {
            this.people.Birthday = gDateTimePickerBirthday.Value;
            myProcess.RunCheckDataValid(people.CheckBirthday() || flagCheck, erpBirthday, gDateTimePickerBirthday, "Not yet 18 years old");
        }
        private void gComboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.people.Gender = (EGender)myProcess.ConvertStringToEnum(gComboBoxGender, typeof(EGender));
            myProcess.RunCheckDataValid(people.CheckGender() || flagCheck, erpGender, gComboBoxGender, "Gender cannot be empty");
        }
        private void gTextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            this.people.Email = gTextBoxEmail.Text;
            myProcess.RunCheckDataValid(people.CheckEmail() || flagCheck, erpEmail, gTextBoxEmail, "Email is already exists or invalid");
        }
        private void gTextBoxPhonenumber_TextChanged(object sender, EventArgs e)
        {
            this.people.PhoneNumber = gTextBoxPhonenumber.Text;
            myProcess.RunCheckDataValid(people.CheckPhoneNumber() || flagCheck, erpPhonenumber, gTextBoxPhonenumber, "Phone number is already exists or invalid");
        }
        private void gTextBoxHandle_TextChanged(object sender, EventArgs e)
        {
            this.people.Handle = gTextBoxHandle.Text;
            myProcess.RunCheckDataValid(people.CheckHandle() || flagCheck, erpHandle, gTextBoxHandle, "Handle is already exists or invalid");
        }
        private void gTextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.people.Password = gTextBoxPassword.Text;
            myProcess.RunCheckDataValid(people.CheckPassWord() || flagCheck, erpConfirmPassword, gTextBoxConfirmPassword, "Confirmation password does not match");
        }
        private void gTextBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            this.people.ConfirmPassword = gTextBoxConfirmPassword.Text;
            myProcess.RunCheckDataValid(people.CheckPassWord() || flagCheck, erpConfirmPassword, gTextBoxConfirmPassword, "Confirmation password does not match");
        }
        private void gTextBoxWorkcode_TextChanged(object sender, EventArgs e)
        {
            this.people.WorkCode = gTextBoxWorkcode.Text;
            myProcess.RunCheckDataValid(people.CheckWorkCode() || flagCheck, erpWorkCode, gTextBoxWorkcode, "Work code is already exists or invalid");
        }

        #endregion

    }
}

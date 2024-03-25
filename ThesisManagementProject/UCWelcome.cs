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

namespace ThesisManagementProject
{
    public partial class UCWelcome : UserControl
    {
        public UCWelcome()
        {
            InitializeComponent();
        }
        public UCWelcome(People people)
        {
            InitializeComponent();

            gCirclePictureBoxAvatar.Image = MyProcess.NameToImage(people.AvatarName);
            lblViewHandle.Text = people.Handle;
            gTextBoxFullname.Text = people.FullName;
            gTextBoxCitizencode.Text = people.CitizenCode;
            gTextBoxBirthday.Text = people.Birthday.ToString("dd/MM/yyyy");
            gTextBoxEmail.Text = people.Email;
            gTextBoxPhonenumber.Text = people.PhoneNumber;
        }
    }
}

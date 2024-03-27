using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Resources;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;

namespace ThesisManagementProject.Process
{
    #region ENUM

    public enum EClassify
    {
        Admin = 11,
        Lecture = 22,
        Student = 33,
        Thesis = 44,
        Team = 55,
    }

    #endregion

    internal class MyProcess
    {
        private DBConnection dBConnection = new DBConnection();

        public string FormatStringLength(string str, int length)
        {
            if (str.Length <= length)
            {
                return str;
            }

            return str.Substring(0, length - 3) + "...";
        }
        public void SetItemFavorite(Guna2Button button, bool flag)
        {
            if (flag) button.Image = Properties.Resources.PicInLineGradientStar;
            else button.Image = Properties.Resources.PicInLineStar;
        }
        public void RunCheckDataValid(bool flag, ErrorProvider errorProvider, Control control, string error)
        {
            if (flag == false)
            {
                errorProvider.SetError(control, error);
            }
            else
            {
                errorProvider.SetError(control, string.Empty);
            }
        }

        #region GenIDbyClassify

        private int GetLastestID(string field, string command)
        {
            DataTable dataTable = dBConnection.Select(command);
            int ind = dataTable.Rows.Count;
            string str = dataTable.Rows[ind - 1][field].ToString();
            return Convert.ToInt32(str.Substring(str.Length - 5));
        }
        public string GenIDClassify(EClassify eClassify)
        {
            int year = DateTime.Now.Year % 100;
            string classify = ((int)eClassify).ToString().PadLeft(2, '0');

            int cntAccount = 0;
            switch (eClassify)
            {
                case EClassify.Lecture:
                    cntAccount = GetLastestID("idaccount", string.Format("SELECT * FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, EClassify.Lecture.ToString()));
                    break;
                case EClassify.Student:
                    cntAccount = GetLastestID("idaccount", string.Format("SELECT * FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, EClassify.Student.ToString()));
                    break;
                case EClassify.Team:
                    cntAccount = GetLastestID("idteam", string.Format("SELECT * FROM {0}", MyDatabase.DBTeam));
                    break;
                case EClassify.Thesis:
                    cntAccount = GetLastestID("idthesis", string.Format("SELECT * FROM {0}", MyDatabase.DBThesis));
                    break;
            }
            cntAccount++;
            string counterStr = cntAccount.ToString().PadLeft(5, '0');

            if (cntAccount > 99999)
            {
                throw new InvalidOperationException("Has exceeded the limit.");
            }

            string id = $"{year}{classify}{counterStr}";

            return id;
        }

        #endregion

        #region ConvertStringToInt32

        public int ConvertStringToInt32(string input)
        {
            try
            {
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException)
            {
                MessageBox.Show("The input string is not a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("The input string is too long or exceeds the limit of a 32-bit integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region ImageToName

        public string ImageToName(Image image)
        {
            if (ImageEquals(image, Properties.Resources.PicAvatarOne)) return "PicAvatarOne";
            if (ImageEquals(image, Properties.Resources.PicAvatarTwo)) return "PicAvatarTwo";
            if (ImageEquals(image, Properties.Resources.PicAvatarThree)) return "PicAvatarThree";
            if (ImageEquals(image, Properties.Resources.PicAvatarFive)) return "PicAvatarFive";
            if (ImageEquals(image, Properties.Resources.PicAvatarSix)) return "PicAvatarSix";
            if (ImageEquals(image, Properties.Resources.PicAvatarSeven)) return "PicAvatarSeven";
            if (ImageEquals(image, Properties.Resources.PicAvatarEight)) return "PicAvatarEight";
            if (ImageEquals(image, Properties.Resources.PicAvatarNine)) return "PicAvatarNine";
            if (ImageEquals(image, Properties.Resources.PicAvatarTen)) return "PicAvatarTen";
            return "PicAvatarDemoUser";
        }
        private bool ImageEquals(Image img1, Image img2)
        {
            if (img1 == null || img2 == null)
                return false;

            using (MemoryStream ms1 = new MemoryStream())
            using (MemoryStream ms2 = new MemoryStream())
            {
                img1.Save(ms1, img1.RawFormat);
                img2.Save(ms2, img2.RawFormat);
                byte[] img1Bytes = ms1.ToArray();
                byte[] img2Bytes = ms2.ToArray();

                return StructuralComparisons.StructuralEqualityComparer.Equals(img1Bytes, img2Bytes);
            }
        }

        #endregion

        #region NameToImage
        public Image NameToImage(string imageName)
        {
            if (imageName.Equals("PicAvatarOne")) return Properties.Resources.PicAvatarOne;
            if (imageName.Equals("PicAvatarTwo")) return Properties.Resources.PicAvatarTwo;
            if (imageName.Equals("PicAvatarThree")) return Properties.Resources.PicAvatarThree;
            if (imageName.Equals("PicAvatarFive")) return Properties.Resources.PicAvatarFive;
            if (imageName.Equals("PicAvatarSix")) return Properties.Resources.PicAvatarSix;
            if (imageName.Equals("PicAvatarSeven")) return Properties.Resources.PicAvatarSeven;
            if (imageName.Equals("PicAvatarEight")) return Properties.Resources.PicAvatarEight;
            if (imageName.Equals("PicAvatarNine")) return Properties.Resources.PicAvatarNine;
            if (imageName.Equals("PicAvatarTen")) return Properties.Resources.PicAvatarTen;
            return Properties.Resources.PicAvatarDemoUser;
        }

        #endregion

        #region FUNCTIONS ENUM

        public string GetEnumDescription(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return descriptionAttribute.Description;
        }

        public void AddEnumsToComboBox(Guna2ComboBox comboBox, Type enumType)
        {
            comboBox.Items.Clear();
            comboBox.DisplayMember = "Name";

            foreach (Enum enumValue in Enum.GetValues(enumType))
            {
                comboBox.Items.Add(enumValue);
            }

            comboBox.SelectedIndex = 0;
        }

        public TEnum GetEnumFromDisplayName<TEnum>(string displayName) where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            var enumNames = Enum.GetNames(enumType);

            foreach (var name in enumNames)
            {
                var member = enumType.GetMember(name).First();
                var displayAttribute = member.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
                if (displayAttribute != null && displayAttribute.Name == displayName)
                {
                    return (TEnum)Enum.Parse(enumType, name);
                }
            }

            throw new ArgumentException($"There is no enum value with Display Name: {displayName}");
        }

        public Enum ConvertStringToEnum(Guna2ComboBox comboBox, Type enumType)
        {
            try
            {
                if (!enumType.IsEnum)
                {
                    MessageBox.Show("Type is not an enum.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                if (comboBox.SelectedItem == null)
                {
                    MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                string selectedValue = comboBox.SelectedItem.ToString();
                Enum enumValue = (Enum)Enum.Parse(enumType, selectedValue);

                if (Enum.IsDefined(enumType, enumValue))
                {
                    return enumValue;
                }
                else
                {
                    MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Selected item is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region FUNCTIONS OFF ON EDIT

        public void SetTextBoxReadOnly(Guna2TextBox textBox, int thickness, Color colors, bool flag)
        {
            textBox.ReadOnly = flag;
            textBox.BorderThickness = thickness;
            textBox.FillColor = colors;
        }
        public void SetComboBoxReadOnly(Guna2ComboBox comboBox, int thickness, Color colors, bool flag)
        {
            comboBox.Enabled = !flag;
            comboBox.BorderThickness = thickness;
            comboBox.FillColor = colors;
        }

        #endregion

        #region SET BUTTON COLOR as CARD

        public void ButtonStandardColor(Guna2GradientButton button)
        {
            button.FillColor = SystemColors.ControlLight;
            button.FillColor2 = SystemColors.ButtonFace;
            button.ForeColor = Color.Black;
            button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }
        public void ButtonSettingColor(Guna2GradientButton button)
        {
            button.FillColor = Color.FromArgb(94, 148, 255);
            button.FillColor2 = Color.FromArgb(255, 77, 165);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        #endregion

        #region EXTEND

        //public void InitializeObjectCode()
        //{
        //    this.cntThesis = GetLastestID("idthesis", string.Format("SELECT * FROM {0}", MyDatabase.DBThesis));
        //    this.cntLecture = GetLastestID("idaccount", string.Format("SELECT * FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, EClassify.Lecture.ToString()));
        //    this.cntStudent = GetLastestID("idaccount", string.Format("SELECT * FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, EClassify.Student.ToString()));
        //    this.cntTeam = GetLastestID("idteam", string.Format("SELECT * FROM {0}", MyDatabase.DBTeam));
        //}

        #endregion

    }
}

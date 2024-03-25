using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Resources;
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
        private static DBConnection dBConnection = new DBConnection();

        public static bool ComparePublished(DateTime timer)
        {
            return timer <= DateTime.Now;
        }
        public static string FormatStringLength(string str, int length)
        {
            if (str.Length <= length)
            {
                return str;
            }

            return str.Substring(0, length - 3) + "...";
        }
        public static void SetItemFavorite(Guna2Button button, bool flag)
        {
            if (flag) button.Image = Properties.Resources.PicInLineGradientStar;
            else button.Image = Properties.Resources.PicInLineStar;
        }

        #region GenIDbyClassify

        public static string GenIDClassify(EClassify eClassify)
        {
            int year = DateTime.Now.Year % 100;
            string classify = ((int)eClassify).ToString().PadLeft(2, '0');

            string command = string.Empty;
            if (eClassify == EClassify.Thesis)
            {
                command = string.Format("SELECT * FROM {0}", MyDatabase.DBThesis);
            }
            else
            {
                command = string.Format("SELECT * FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, eClassify.ToString());
            }
            int cntAccount = dBConnection.Select(command).Rows.Count + 1;
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

        public static int ConvertStringToInt32(string input)
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

        public static string ImageToName(Image image)
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
        private static bool ImageEquals(Image img1, Image img2)
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
        public static Image NameToImage(string imageName)
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

        public static string GetEnumDescription(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return descriptionAttribute.Description;
        }

        public static void AddEnumsToComboBox(Guna2ComboBox comboBox, Type enumType)
        {
            comboBox.Items.Clear();
            comboBox.DisplayMember = "Name";

            foreach (Enum enumValue in Enum.GetValues(enumType))
            {
                comboBox.Items.Add(enumValue);
            }

            comboBox.SelectedIndex = 0;
        }

        public static TEnum GetEnumFromDisplayName<TEnum>(string displayName) where TEnum : Enum
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

        public static Enum ConvertStringToEnum(Guna2ComboBox comboBox, Type enumType)
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


    }
}

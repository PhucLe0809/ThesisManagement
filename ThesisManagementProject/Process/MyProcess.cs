﻿using Guna.UI2.WinForms;
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
        Task = 66,
        Comment = 77,
        Evaluation = 88,
        Notification = 99,
    }

    #endregion

    internal class MyProcess
    {
        private DBConnection dBConnection = new DBConnection();

        #region MY UTILS

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
                control.Focus();
                errorProvider.SetError(control, error);
            }
            else
            {
                errorProvider.SetError(control, null);
            }
        }
        public void SetTextBoxState(List<Guna2TextBox> list, bool flag)
        {
            foreach (Guna2TextBox textBox in list)
            {
                textBox.ReadOnly = flag;

                if (flag)
                {
                    textBox.BorderThickness = 0;
                    textBox.FillColor = SystemColors.ButtonFace;
                }
                else
                {
                    textBox.BorderThickness = 1;
                    textBox.FillColor = Color.White;
                }
            }
        }

        #endregion

        #region CREATE WINFORM CONTROL

        public Label CreateLabel(string content)
        {
            Label label = new Label();

            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.Gray;
            label.Name = "label";
            label.Size = new Size(315, 62);
            label.TabIndex = 5;
            label.Text = content;

            return label;
        }

        #endregion

        #region CREATE GUNA2 CONTROL

        public Guna2PictureBox CreatePictureBox(Image image)
        {
            Guna2PictureBox pictureBox = new Guna2PictureBox();

            pictureBox.ImageRotate = 0F;
            pictureBox.Image = image;
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(399, 266);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;

            return pictureBox;
        }

        #endregion

        #region FUNCTIONS GenIDbyClassify

        private int GetLastestID(string command)
        {
            DataTable dataTable = dBConnection.Select(command);
            string str = dataTable.Rows[0]["MaxID"].ToString();
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
                    cntAccount = GetLastestID(string.Format("SELECT max(idaccount) as MaxID FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, EClassify.Lecture.ToString()));
                    break;
                case EClassify.Student:
                    cntAccount = GetLastestID(string.Format("SELECT max(idaccount) as MaxID FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, EClassify.Student.ToString()));
                    break;
                case EClassify.Team:
                    cntAccount = GetLastestID(string.Format("SELECT max(idteam) as MaxID FROM {0}", MyDatabase.DBTeam));
                    break;
                case EClassify.Thesis:
                    cntAccount = GetLastestID(string.Format("SELECT max(idthesis) as MaxID FROM {0}", MyDatabase.DBThesis));
                    break;
                case EClassify.Task:
                    cntAccount = GetLastestID(string.Format("SELECT max(idtask) as MaxID FROM {0}", MyDatabase.DBTask));
                    break;
                case EClassify.Comment:
                    cntAccount = GetLastestID(string.Format("SELECT max(idcomment) as MaxID FROM {0}", MyDatabase.DBComment));
                    break;
                case EClassify.Evaluation:
                    cntAccount = GetLastestID(string.Format("SELECT max(idevaluation) as MaxID FROM {0}", MyDatabase.DBEvaluation));
                    break;
                case EClassify.Notification:
                    cntAccount = GetLastestID(string.Format("SELECT max(idnotification) as MaxID FROM {0}", MyDatabase.DBNotification));
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

        #region FUNCTIONS with STRING and INT32T FLOAT

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
        public float ConvertStringToFloat(string input)
        {
            try
            {
                float number = float.Parse(input);
                return number;
            }
            catch (FormatException)
            {
                MessageBox.Show("The input string is not a valid float.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("The input string is too long or exceeds the limit of a float number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region FUNCTIONS IMAGE and AVATAR NAME

        public string ImageToName(Image image)
        {
            if (ImageEquals(image, Properties.Resources.PicAvatarOne)) return "PicAvatarOne";
            if (ImageEquals(image, Properties.Resources.PicAvatarTwo)) return "PicAvatarTwo";
            if (ImageEquals(image, Properties.Resources.PicAvatarThree)) return "PicAvatarThree";
            if (ImageEquals(image, Properties.Resources.PicAvatarFour)) return "PicAvatarFour";
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
        public Image NameToImage(string imageName)
        {
            if (imageName.Equals("PicAvatarOne")) return Properties.Resources.PicAvatarOne;
            if (imageName.Equals("PicAvatarTwo")) return Properties.Resources.PicAvatarTwo;
            if (imageName.Equals("PicAvatarThree")) return Properties.Resources.PicAvatarThree;
            if (imageName.Equals("PicAvatarFour")) return Properties.Resources.PicAvatarFour;
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

        #region FUNCTIONS SET GUNA2 BUTTON

        public void ButtonStandardColor(Guna2GradientButton button)
        {
            button.FillColor = SystemColors.ControlLight;
            button.FillColor2 = SystemColors.ButtonFace;
            button.ForeColor = Color.Black;
            button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }
        public void ButtonStandardColor(Guna2GradientButton button, Color one, Color two)
        {
            button.FillColor = one;
            button.FillColor2 = two;
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
        public void ButtonStandardColor(Guna2Button button)
        {
            button.FillColor = Color.Transparent;
            button.ForeColor = Color.White;
            button.Font = new System.Drawing.Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
        public void ButtonSettingColor(Guna2Button button)
        {
            button.FillColor = Color.White;
            button.ForeColor = Color.Black;
            button.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, FontStyle.Bold);
        }
        public void AllButtonStandardColor(List<Guna2Button> listButton, List<Image> listImage)
        {
            if (listButton.Count != listImage.Count) return;

            for (int i = 0; i < listButton.Count; i++)
            {
                Guna2Button button = listButton[i];
                ButtonStandardColor(button);
                button.CustomImages.Image = listImage[i];
            }
        }

        #endregion

    }
}

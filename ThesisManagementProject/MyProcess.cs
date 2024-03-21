using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject
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
        static int cntAccount = 100;

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

        #region Selct Only Thesis - Student

        public static Thesis SelectThesis(string id)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select("SELECT * FROM " + MyDatabase.DBThesis + " WHERE idthesis = " + "'" + id + "'");

            if (dt.Rows.Count > 0) return GetThesisFromDataRow(dt.Rows[0]);
            return new Thesis();
        }
        public static Student SelectStudent(string id)
        {
            DBConnection db = new DBConnection();
            DataTable dt = db.Select("SELECT * FROM " + MyDatabase.DBPeople + " WHERE idaccount = '" + id + "'");

            if (dt.Rows.Count > 0) return GetStudentFromDataRow(dt.Rows[0]);
            return new Student();
        }

        #endregion

        #region GetStudentFromDataRow

        public static Student GetStudentFromDataRow(DataRow row)
        {
            string idaccount = row["idaccount"].ToString();
            string fullname = row["fullname"].ToString();
            string citizenCode = row["citizencode"].ToString();
            DateTime birthday = DateTime.Parse(row["birthday"].ToString());
            EGender gender = GetEnumFromDisplayName<EGender>(row["gender"].ToString());
            string email = row["email"].ToString();
            string phoneNumber = row["phonenumber"].ToString();
            string handle = row["handle"].ToString();
            ERole role = GetEnumFromDisplayName<ERole>(row["role"].ToString());
            string workCode = row["workcode"].ToString();
            string password = row["password"].ToString();

            Student student = new Student(idaccount, fullname, citizenCode, birthday, gender, email, phoneNumber, 
                                    handle, role, workCode, password);
            return student;

        }

        #endregion

        #region GetThesisFromDataRow

        public static Thesis GetThesisFromDataRow(DataRow row)
        {
            string idThesis = row["idthesis"].ToString();
            string topic = row["topic"].ToString();
            EField field = GetEnumFromDisplayName<EField>(row["field"].ToString());
            ELevel level = GetEnumFromDisplayName<ELevel>(row["tslevel"].ToString());
            int maxMembers = int.Parse(row["maxmembers"].ToString());
            string description = row["description"].ToString();
            string reference = row["reference"].ToString();
            DateTime publishDate = DateTime.Parse(row["publishdate"].ToString());
            string technology = row["technology"].ToString();
            string functions = row["functions"].ToString();
            string requirements = row["requirements"].ToString();
            string idCreator = row["idcreator"].ToString();
            bool isFavorite = (row["isfavorite"].ToString() == "True") ? (true) : (false);
            int numPending = int.Parse(row["pending"].ToString());
            int numAccepted = int.Parse(row["accepted"].ToString());
            int numCompleted = int.Parse(row["completed"].ToString());

            Thesis thesis = new Thesis(idThesis, topic, field, level, maxMembers, description,
                                        reference, publishDate, technology, functions, requirements,
                                        idCreator, isFavorite, numPending, numAccepted, numCompleted);
            return thesis;
        }

        #endregion

        #region GetEnumFromDisplayName

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

        #endregion

        #region GenIDClassify

        public static string GenIDClassify(EClassify eClassify)
        {
            int year = DateTime.Now.Year % 100;
            string classify = ((int)eClassify).ToString().PadLeft(2, '0');

            cntAccount++;
            string counterStr = cntAccount.ToString().PadLeft(4, '0');

            if (cntAccount > 9999)
            {
                throw new InvalidOperationException("Has exceeded the limit.");
            }

            string id = $"{year}{classify}{counterStr}";

            return id;
        }

        #endregion

        #region AddEnumsToComboBox

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

        #endregion

        #region GetEnumDescription

        public static string GetEnumDescription(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return descriptionAttribute.Description;
        }

        #endregion

        #region ConvertStringToEnum

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


    }
}

using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCAccount : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private People people = new People();
        private People dynamicPeople = new People();
        private int totalContributions = 0;

        private PeopleDAO peopleDAO = new PeopleDAO();
        private TeamDAO teamDAO = new TeamDAO();
        private EvaluationDAO evaluationDAO = new EvaluationDAO();
        private ThesisDAO thesisDAO = new ThesisDAO();

        private bool flagCheck = false;

        public UCAccount()
        {
            InitializeComponent();
        }

        #region FUNCTIONS FORM

        public void SetInformation(People people)
        {
            this.people = people;
            this.dynamicPeople = people.Clone();
            myProcess.AddEnumsToComboBox(gComboBoxGender, typeof(EGender));
            SetupComboBoxSelectYear();
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
            gTextBoxUserName.Text = people.Handle;
            gTextBoxWorkcode.Text = people.WorkCode;

            myProcess.SetTextBoxState(gTextBoxUniversity, true);
            myProcess.SetTextBoxState(gTextBoxFaculty, true);
            myProcess.SetTextBoxState(gTextBoxWorkcode, true);

            SetViewSate(true);
            SetTeamsList();

            UpdateBarChart();
            SetupTotalContributions();
        }
        private void SetViewSate(bool onlyView)
        {
            myProcess.SetTextBoxState(gTextBoxFullname, onlyView);
            myProcess.SetTextBoxState(gTextBoxCitizencode, onlyView);
            myProcess.SetTextBoxState(gTextBoxEmail, onlyView);
            myProcess.SetTextBoxState(gTextBoxPhonenumber, onlyView);
            myProcess.SetTextBoxState(gTextBoxUserName, onlyView);
            myProcess.SetDatePickerState(gDateTimePickerBirthday, onlyView);
            myProcess.SetComboBoxState(gComboBoxGender, onlyView);

            if (onlyView)
            {
                gButtonCancel.Hide();
                gGradientButtonSave.Hide();
                gPictureBoxGender.BackColor = Color.Gainsboro;
            }
            else
            {
                gButtonCancel.Show();
                gGradientButtonSave.Show();
                gPictureBoxGender.BackColor = Color.White;
            }
            gCirclePictureBoxAvatar.Focus();
        }
        private void SetTeamsList()
        {
            flpTeams.Controls.Clear();
            if (people.Role == ERole.Lecture)
            {
                Guna2PictureBox pictureBox = myProcess.CreatePictureBox(Properties.Resources.PictureEmptyState, new Size(370, 325));
                flpTeams.Controls.Add(pictureBox);
                return;
            }

            List<Team> list = teamDAO.SelectFollowPeople(people);
            foreach (Team team in list)
            {
                UCTeamMiniLine line = new UCTeamMiniLine(team);
                line.SetSize(new Size(350, 60));
                line.SetBackColor(SystemColors.ButtonFace);
                line.SetSimpleLine();
                flpTeams.Controls.Add(line);
            }
        }
        public void RunCheckInformation()
        {
            myProcess.RunCheckDataValid(dynamicPeople.CheckFullName() || flagCheck, erpFullName, gTextBoxFullname, "Name cannot be empty");
            myProcess.RunCheckDataValid(dynamicPeople.CheckCitizenCode() || flagCheck || people.CitizenCode == dynamicPeople.CitizenCode,
                erpCitizenCode, gTextBoxCitizencode, "Citizen code is already exists or empty");
            myProcess.RunCheckDataValid(dynamicPeople.CheckBirthday() || flagCheck, erpBirthday, gDateTimePickerBirthday, "Not yet 18 years old");
            myProcess.RunCheckDataValid(dynamicPeople.CheckGender() || flagCheck, erpGender, gComboBoxGender, "Gender cannot be empty");
            myProcess.RunCheckDataValid(dynamicPeople.CheckEmail() || flagCheck || people.Email == dynamicPeople.Email,
                erpEmail, gTextBoxEmail, "Email is already exists or invalid");
            myProcess.RunCheckDataValid(dynamicPeople.CheckPhoneNumber() || flagCheck || people.PhoneNumber == dynamicPeople.PhoneNumber,
                erpPhonenumber, gTextBoxPhonenumber, "Phone number is already exists or invalid");
            myProcess.RunCheckDataValid(dynamicPeople.CheckHandle() || flagCheck || people.Handle == dynamicPeople.Handle,
                erpHandle, gTextBoxUserName, "Username is already exists or invalid");
        }
        private bool CheckInformationValid()
        {
            RunCheckInformation();

            return dynamicPeople.CheckFullName() && (dynamicPeople.CheckCitizenCode() || people.CitizenCode == dynamicPeople.CitizenCode)
                   && dynamicPeople.CheckBirthday() && dynamicPeople.CheckGender() && (dynamicPeople.CheckEmail() || people.Email == dynamicPeople.Email)
                   && (dynamicPeople.CheckPhoneNumber() || people.PhoneNumber == dynamicPeople.PhoneNumber)
                   && (dynamicPeople.CheckHandle() || people.Handle == dynamicPeople.Handle);
        }

        #endregion

        #region CONTROL CLICK

        private void gGradientButtonEdit_Click(object sender, EventArgs e)
        {
            SetViewSate(false);
        }
        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            SetViewSate(true);
        }
        private void gGradientButtonSave_Click(object sender, EventArgs e)
        {
            this.dynamicPeople = new People(dynamicPeople.IdAccount, gTextBoxFullname.Text, gTextBoxCitizencode.Text, gDateTimePickerBirthday.Value,
                                     (EGender)myProcess.ConvertStringToEnum(gComboBoxGender, typeof(EGender)), gTextBoxEmail.Text, gTextBoxPhonenumber.Text, gTextBoxUserName.Text,
                                     dynamicPeople.Role, gTextBoxWorkcode.Text, dynamicPeople.Password, dynamicPeople.AvatarName);

            this.flagCheck = false;
            if (CheckInformationValid())
            {
                this.people = dynamicPeople.Clone();
                peopleDAO.Update(this.people);
                this.flagCheck = true;
                SetViewSate(true);
                lblViewHandle.Text = this.people.Handle;
            }
        }

        #endregion

        #region EVENT TextChanged and ValueChanged

        private void gTextBoxFullname_TextChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.FullName = gTextBoxFullname.Text;
            myProcess.RunCheckDataValid(dynamicPeople.CheckFullName() || flagCheck, erpFullName, gTextBoxFullname, "Name cannot be empty");
        }
        private void gTextBoxCitizencode_TextChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.CitizenCode = gTextBoxCitizencode.Text;
            myProcess.RunCheckDataValid(dynamicPeople.CheckCitizenCode() || flagCheck || people.CitizenCode == dynamicPeople.CitizenCode,
                erpCitizenCode, gTextBoxCitizencode, "Citizen code is already exists or empty");
        }
        private void gDateTimePickerBirthday_ValueChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.Birthday = gDateTimePickerBirthday.Value;
            myProcess.RunCheckDataValid(dynamicPeople.CheckBirthday() || flagCheck, erpBirthday, gDateTimePickerBirthday, "Not yet 18 years old");
        }
        private void gComboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.Gender = (EGender)myProcess.ConvertStringToEnum(gComboBoxGender, typeof(EGender));
            myProcess.RunCheckDataValid(dynamicPeople.CheckGender() || flagCheck, erpGender, gComboBoxGender, "Gender cannot be empty");
        }
        private void gTextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.Email = gTextBoxEmail.Text;
            myProcess.RunCheckDataValid(dynamicPeople.CheckEmail() || flagCheck || people.Email == dynamicPeople.Email,
                erpEmail, gTextBoxEmail, "Email is already exists or invalid");
        }
        private void gTextBoxPhonenumber_TextChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.PhoneNumber = gTextBoxPhonenumber.Text;
            myProcess.RunCheckDataValid(dynamicPeople.CheckPhoneNumber() || flagCheck || people.PhoneNumber == dynamicPeople.PhoneNumber,
                erpPhonenumber, gTextBoxPhonenumber, "Phone number is already exists or invalid");
        }
        private void gTextBoxHandle_TextChanged(object sender, EventArgs e)
        {
            this.dynamicPeople.Handle = gTextBoxUserName.Text;
            myProcess.RunCheckDataValid(dynamicPeople.CheckHandle() || flagCheck || people.Handle == dynamicPeople.Handle,
                erpHandle, gTextBoxUserName, "Username is already exists or invalid");
        }

        #endregion

        #region COMBO BOX
        public void SetupComboBoxSelectYear()
        {
            int currentYear = DateTime.Now.Year;
            List<int> recentYears = new List<int> { currentYear, currentYear - 1, currentYear - 2 };

            this.gComboBoxSelectYear.DataSource = recentYears;
            this.gComboBoxSelectYear.SelectedIndex = 0;
        }
        private void gComboBoxSelectYear_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateBarChart();
            SetupTotalContributions();
        }
        #endregion

        #region LABEL TOTAL CONTRIBUTIONS

        void SetupTotalContributions()
        {
            string textContribution = this.totalContributions > 1 ? "contributions" : "contribution";
            int year = (int)this.gComboBoxSelectYear.SelectedItem;
            this.lblTotalContributions.Text = $"{this.totalContributions} {textContribution} in {year}";
        }

        #endregion

        #region MIXED BAR AND SPLINE CHART
        IEnumerable<object> GetContributionForTeacher(int selectedYear)
        {
            List<Thesis> listTheses = thesisDAO.SelectListRoleLecture(this.people.IdAccount)
                                     .Where(thesis => thesis.PublishDate.Year == selectedYear)
                                     .ToList();

            this.totalContributions = listTheses.Count;
            var allMonths = Enumerable.Range(1, 12);
            var contributions = allMonths
            .GroupJoin(listTheses,
                       month => month,
                       thesis => thesis.PublishDate.Month,
                       (month, evaluation) => new
                       {
                           Month = month,
                           Count = evaluation.Count(),
                       })
            .Select(result => new
            {
                result.Month,
                result.Count
            });
            return contributions;
        }

        IEnumerable<object> GetContributionForStudent(int selectedYear)
        {
            List<Evaluation> listEvaluations = evaluationDAO.SelectListByPeople(this.people.IdAccount);
            this.totalContributions = listEvaluations.Count;
            var allMonths = Enumerable.Range(1, 12);
            var contributions = allMonths
            .GroupJoin(listEvaluations,
                       month => month,
                       evaluation => evaluation.Created.Month,
                       (month, evaluation) => new
                       {
                           Month = month,
                           Count = evaluation.Where(thesis => thesis.Created.Year == selectedYear).Count()
                       })
            .Select(result => new
            {
                result.Month,
                result.Count
            });
            return contributions;
        }

        public void UpdateBarChart()
        {
            int selectedYear = (int)gComboBoxSelectYear.SelectedItem;

            var contributions = people.Role == ERole.Lecture ? GetContributionForTeacher(selectedYear) : GetContributionForStudent(selectedYear);

            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string monthName;
            this.gBarDataset.DataPoints.Clear();
            this.gBarChart.Datasets.Clear();
            foreach (var group in contributions)
            {
                var month = (int)group.GetType().GetProperty("Month").GetValue(group, null);
                var count = (int)group.GetType().GetProperty("Count").GetValue(group, null);

                monthName = dtfi.GetMonthName(month);
                this.gBarDataset.DataPoints.Add(monthName, count);
            }
            this.gBarChart.Datasets.Add(gBarDataset);
            this.gBarChart.Update();
        }
        #endregion
    }
}

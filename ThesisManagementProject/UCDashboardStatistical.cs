using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.Charts.WinForms;
using System.Globalization;
using Guna.UI2.WinForms;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCDashboardStatistical : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        private List<Thesis> listTheses;

        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();

        public UCDashboardStatistical()
        {
            InitializeComponent();
            SetupFlpStatus();
        }

        #region FUNCTIONS

        public void SetInformation(List<Thesis> listTheses)
        {
            this.listTheses = listTheses;
            SetupUserControl();
        }
        void SetupUserControl()
        {
            UpdateDoughnutChart();
            SetupComboBoxTop();
            SetupComboBoxSelectYear();
        }

        #endregion

        #region FLOW PANEL STATUS

        void SetupFlpStatus()
        {
            List<EThesisStatus> statusList = new List<EThesisStatus>((EThesisStatus[])Enum.GetValues(typeof(EThesisStatus)));
            foreach (var status in statusList)
            {
                Guna2Button button = new Guna2Button();
                button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                button.Text = status.ToString();
                button.ForeColor = Color.White;
                button.Size = new Size(105, 25);
                button.BorderRadius = 5;
                button.FillColor = myProcess.GetThesisStatusColor(status);
                this.flpStatus.Controls.Add(button);
            }
        }

        #endregion

        #region DOUGHNUT CHART
        public void UpdateDoughnutChart()
        {
            this.lblTotal.Text = this.listTheses.Count.ToString();
            var thesisGroupedByStatus = this.listTheses
            .GroupBy(thesis => thesis.Status)
            .Select(group => new
            {
                Status = group.Key,
                Count = group.Count(),
            });
            this.gDoughnutChart.Datasets.Clear();
            foreach (var group in thesisGroupedByStatus)
            {
                int ind = myProcess.GetThesisStatusIndex(group.Status);
                this.gDoughnutDataset.DataPoints[ind].Y = group.Count;
                this.gDoughnutDataset.FillColors[ind] = myProcess.GetThesisStatusColor(group.Status);
            }
            this.gDoughnutChart.Datasets.Add(gDoughnutDataset);
            this.gDoughnutChart.Update();
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
            UpdateMixedBarAndSplineChart();
        }
        public void SetupComboBoxTop()
        {
            this.gComboBoxTop.SelectedIndex = 0;
        }
        private void gComboBoxTop_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateHorizontalbarChart();
        }
        #endregion

        #region HORIZONTALBAR CHART
        IEnumerable<object> ByLecture()
        {
            List<Dictionary<Thesis, int>> getThesisByMaxSubscribers = thesisDAO.GetMaxSubscribers();
            List<string> lectures = peopleDAO.SelectListID(ERole.Lecture);
            var result = from dict in getThesisByMaxSubscribers
                         join lecture in lectures on dict.Keys.FirstOrDefault().IdInstructor equals lecture
                         select new { Lecture = lecture, Count = dict.Values.FirstOrDefault() };
            var groupedResult = result.GroupBy(
                item => item.Lecture,
                (key, group) => new
                {
                    Name = key,
                    Count = group.Sum(item => item.Count)
                }
            ).ToList();
            return groupedResult;

        }
        IEnumerable<object> ByField()
        {
            var thesisGroupedByField = this.listTheses
              .GroupBy(thesis => thesis.Field)
              .Select(group => new
              {
                  Name = group.Key,
                  Count = group.Count()
              });
            thesisGroupedByField = thesisGroupedByField.OrderByDescending(item => item.Count);
            return thesisGroupedByField;
        }
        public void UpdateHorizontalbarChart()
        {
            string selectedFilter = gComboBoxTop.SelectedItem.ToString();
            var thesisGroupedByField = selectedFilter == "Field" ? ByField() : ByLecture();
            int max = 5;
            int i = 0;
            this.gHorizontalBarDataset.DataPoints.Clear();
            this.gHorizontalBarChart.Datasets.Clear();
            foreach (var group in thesisGroupedByField)
            {
                var name = group.GetType().GetProperty("Name").GetValue(group, null).ToString();
                if (selectedFilter == "Lecture")
                {
                    People people = peopleDAO.SelectOnlyByID(name);
                    name = people.Handle;
                }
                var count = (int)group.GetType().GetProperty("Count").GetValue(group, null);
                this.gHorizontalBarDataset.DataPoints.Add(name, count);
                i++;
                if (i == max) break;
            }
            this.gHorizontalBarChart.Datasets.Add(gHorizontalBarDataset);
            this.gHorizontalBarChart.Update();
        }
        #endregion

        #region MIXED BAR AND SPLINE CHART
        public void UpdateMixedBarAndSplineChart()
        {
            var allMonths = Enumerable.Range(1, 12);
            int selectedYear = (int)gComboBoxSelectYear.SelectedItem;
            var thesisGroupedByMonth = allMonths
                .GroupJoin(this.listTheses,
                           month => month,
                           thesis => thesis.PublishDate.Month,
                           (month, theses) => new
                           {
                               Month = month,
                               Count = theses.Where(thesis => thesis.PublishDate.Year == selectedYear).Count()
                           })
                .Select(result => new
                {
                    result.Month,
                    result.Count
                });
            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string monthName;
            this.gSplineDataset.DataPoints.Clear();
            this.gBarDataset.DataPoints.Clear();
            this.gMixedBarAndSplineChart.Datasets.Clear();
            foreach (var group in thesisGroupedByMonth)
            {
                monthName = dtfi.GetMonthName(group.Month);
                this.gSplineDataset.DataPoints.Add(monthName, group.Count);
                this.gBarDataset.DataPoints.Add(monthName, group.Count);
            }
            this.gMixedBarAndSplineChart.Datasets.Add(gBarDataset);
            this.gMixedBarAndSplineChart.Datasets.Add(gSplineDataset);
            this.gMixedBarAndSplineChart.Update();
        }
        #endregion

    }
}

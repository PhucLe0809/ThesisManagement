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
        private List<Thesis> listTheses;

        private MyProcess myProcess = new MyProcess();
        public UCDashboardStatistical()
        {
            InitializeComponent();
        }
        public UCDashboardStatistical(List<Thesis> listTheses)
        {
            this.listTheses = listTheses;
            InitializeComponent();
            SetupUserControl();
        }

        void SetupUserControl()
        {
            SetupFlpStatus();
            UpdateDoughnutChart();
            UpdateHorizontalbarChart();
            SetupComboBoxSelectYear();
            
        }

        #region FLOW PANEL STATUS

        void SetupFlpStatus()
        {
            List<EThesisStatus> statusList = new List<EThesisStatus>((EThesisStatus[])Enum.GetValues(typeof(EThesisStatus)));
            foreach (var status in statusList)
            {
                Guna2Button button = new Guna2Button();
                button.Font = new Font("Segoe UI", 8F);
                button.Text = status.ToString();
                button.ForeColor = SystemColors.ControlText;
                button.Size = new Size(100, 25);
                button.BorderRadius = 5;
                button.FillColor = myProcess.GetThesisStatusColor(status);
                this.flpStatus.Controls.Add(button);
            }
        }

        #endregion

        #region DOUGHNUT CHART
        public void UpdateDoughnutChart()
        {
            this.lblTotalThesis.Text += this.listTheses.Count.ToString();
            var thesisGroupedByStatus = this.listTheses
            .GroupBy(thesis => thesis.Status)
            .Select(group => new
            {
                Status = group.Key,
                Count = group.Count(),
            });
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

        #region HORIZONTALBAR CHART
        public void UpdateHorizontalbarChart()
        {
            var thesisGroupedByField = this.listTheses
                .GroupBy(thesis => thesis.Field)
                .Select(group => new
                {
                    Field = group.Key,
                    Count = group.Count()
                });
            thesisGroupedByField = thesisGroupedByField.OrderByDescending(item => item.Count);
            int max = 5;
            int i = 0;
            foreach (var group in thesisGroupedByField)
            {
                this.gHorizontalBarDataset.DataPoints.Add(group.Field.ToString(), group.Count);
                i++;
                if (i == max) break;
            }
            this.gHorizontalBarChart.Datasets.Add(gHorizontalBarDataset);
            this.gHorizontalBarChart.Update();
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

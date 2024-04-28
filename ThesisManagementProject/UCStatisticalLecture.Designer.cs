namespace ThesisManagementProject
{
    partial class UCStatisticalLecture
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gMixedBarAndSplineChart = new Guna.Charts.WinForms.GunaChart();
            gBarDataset = new Guna.Charts.WinForms.GunaBarDataset();
            gSplineDataset = new Guna.Charts.WinForms.GunaSplineDataset();
            lblThesisStatistical = new Label();
            gComboBoxSelectYear = new Guna.UI2.WinForms.Guna2ComboBox();
            SuspendLayout();
            // 
            // gMixedBarAndSplineChart
            // 
            gMixedBarAndSplineChart.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { gBarDataset, gSplineDataset });
            chartFont1.FontName = "Arial";
            gMixedBarAndSplineChart.Legend.LabelFont = chartFont1;
            gMixedBarAndSplineChart.Location = new Point(3, 75);
            gMixedBarAndSplineChart.Name = "gMixedBarAndSplineChart";
            gMixedBarAndSplineChart.Size = new Size(744, 204);
            gMixedBarAndSplineChart.TabIndex = 1;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gMixedBarAndSplineChart.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            gMixedBarAndSplineChart.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gMixedBarAndSplineChart.Tooltips.TitleFont = chartFont4;
            gMixedBarAndSplineChart.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            chartFont5.Size = 10;
            tick1.Font = chartFont5;
            gMixedBarAndSplineChart.XAxes.Ticks = tick1;
            gMixedBarAndSplineChart.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            gMixedBarAndSplineChart.YAxes.Ticks = tick2;
            gMixedBarAndSplineChart.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            gMixedBarAndSplineChart.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            gMixedBarAndSplineChart.ZAxes.Ticks = tick3;
            // 
            // gBarDataset
            // 
            gBarDataset.CornerRadius = 5;
            gBarDataset.Label = "Bar";
            gBarDataset.LegendBoxBorderColor = Color.FromArgb(192, 255, 192);
            gBarDataset.LegendBoxFillColor = Color.FromArgb(128, 255, 128);
            gBarDataset.TargetChart = gMixedBarAndSplineChart;
            // 
            // gSplineDataset
            // 
            gSplineDataset.BorderColor = Color.Empty;
            gSplineDataset.FillColor = Color.Empty;
            gSplineDataset.Label = "Spline";
            gSplineDataset.TargetChart = gMixedBarAndSplineChart;
            // 
            // lblThesisStatistical
            // 
            lblThesisStatistical.AutoSize = true;
            lblThesisStatistical.BackColor = Color.Transparent;
            lblThesisStatistical.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThesisStatistical.Location = new Point(238, 9);
            lblThesisStatistical.Name = "lblThesisStatistical";
            lblThesisStatistical.Size = new Size(313, 28);
            lblThesisStatistical.TabIndex = 10;
            lblThesisStatistical.Text = "STATISTICAL THESIS IN YEAR";
            // 
            // gComboBoxSelectYear
            // 
            gComboBoxSelectYear.BackColor = Color.Transparent;
            gComboBoxSelectYear.BorderRadius = 10;
            gComboBoxSelectYear.CustomizableEdges = customizableEdges1;
            gComboBoxSelectYear.DrawMode = DrawMode.OwnerDrawFixed;
            gComboBoxSelectYear.DropDownStyle = ComboBoxStyle.DropDownList;
            gComboBoxSelectYear.FocusedColor = Color.FromArgb(94, 148, 255);
            gComboBoxSelectYear.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gComboBoxSelectYear.Font = new Font("Segoe UI", 10F);
            gComboBoxSelectYear.ForeColor = Color.FromArgb(68, 88, 112);
            gComboBoxSelectYear.ItemHeight = 30;
            gComboBoxSelectYear.Location = new Point(42, 33);
            gComboBoxSelectYear.Name = "gComboBoxSelectYear";
            gComboBoxSelectYear.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gComboBoxSelectYear.Size = new Size(175, 36);
            gComboBoxSelectYear.TabIndex = 9;
            gComboBoxSelectYear.SelectedValueChanged += gComboBoxSelectYear_SelectedValueChanged;
            // 
            // UCStatisticalLecture
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblThesisStatistical);
            Controls.Add(gComboBoxSelectYear);
            Controls.Add(gMixedBarAndSplineChart);
            Name = "UCStatisticalLecture";
            Size = new Size(750, 295);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.Charts.WinForms.GunaChart gMixedBarAndSplineChart;
        private Guna.Charts.WinForms.GunaBarDataset gBarDataset;
        private Guna.Charts.WinForms.GunaSplineDataset gSplineDataset;
        private Label lblThesisStatistical;
        private Guna.UI2.WinForms.Guna2ComboBox gComboBoxSelectYear;
    }
}

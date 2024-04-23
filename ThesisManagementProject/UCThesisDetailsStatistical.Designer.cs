namespace ThesisManagementProject
{
    partial class UCThesisDetailsStatistical
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gShadowPanelShowInfor = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gChart = new Guna.Charts.WinForms.GunaChart();
            gSplineAreaDataset = new Guna.Charts.WinForms.GunaSplineAreaDataset();
            gCircleProgressBarThree = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            gCircleProgressBarTwo = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            gCircleProgressBarOne = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            flpMemberStatistical = new FlowLayoutPanel();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            gProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            lblDescription = new Label();
            gShadowPanelShowInfor.SuspendLayout();
            gCircleProgressBarThree.SuspendLayout();
            gCircleProgressBarTwo.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // gShadowPanelShowInfor
            // 
            gShadowPanelShowInfor.BackColor = Color.Transparent;
            gShadowPanelShowInfor.Controls.Add(gChart);
            gShadowPanelShowInfor.Controls.Add(gCircleProgressBarThree);
            gShadowPanelShowInfor.FillColor = Color.White;
            gShadowPanelShowInfor.Location = new Point(23, 341);
            gShadowPanelShowInfor.Name = "gShadowPanelShowInfor";
            gShadowPanelShowInfor.Radius = 10;
            gShadowPanelShowInfor.ShadowColor = Color.Black;
            gShadowPanelShowInfor.ShadowShift = 8;
            gShadowPanelShowInfor.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            gShadowPanelShowInfor.Size = new Size(669, 275);
            gShadowPanelShowInfor.TabIndex = 1;
            // 
            // gChart
            // 
            gChart.AutoScroll = true;
            gChart.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { gSplineAreaDataset });
            gChart.ImeMode = ImeMode.NoControl;
            chartFont1.FontName = "Arial";
            chartFont1.Size = 10;
            chartFont1.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gChart.Legend.LabelFont = chartFont1;
            gChart.Legend.LabelForeColor = SystemColors.ControlText;
            gChart.Location = new Point(17, 3);
            gChart.Name = "gChart";
            gChart.Size = new Size(622, 256);
            gChart.TabIndex = 3;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gChart.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            gChart.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            gChart.Tooltips.TitleFont = chartFont4;
            gChart.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            gChart.XAxes.Ticks = tick1;
            gChart.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            tick2.HasMaximum = true;
            tick2.HasMinimum = true;
            gChart.YAxes.Ticks = tick2;
            gChart.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            gChart.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            gChart.ZAxes.Ticks = tick3;
            // 
            // gSplineAreaDataset
            // 
            gSplineAreaDataset.BorderColor = SystemColors.ActiveCaptionText;
            gSplineAreaDataset.BorderWidth = 2;
            gSplineAreaDataset.FillColor = Color.Empty;
            gSplineAreaDataset.IndexLabelForeColor = Color.White;
            gSplineAreaDataset.Label = "Statistical Task";
            gSplineAreaDataset.PointRadius = 3;
            gSplineAreaDataset.TargetChart = gChart;
            // 
            // gCircleProgressBarThree
            // 
            gCircleProgressBarThree.Animated = true;
            gCircleProgressBarThree.AnimationSpeed = 0.5F;
            gCircleProgressBarThree.BackColor = Color.Transparent;
            gCircleProgressBarThree.Controls.Add(gCircleProgressBarTwo);
            gCircleProgressBarThree.FillColor = Color.FromArgb(200, 213, 218, 223);
            gCircleProgressBarThree.FillThickness = 25;
            gCircleProgressBarThree.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gCircleProgressBarThree.ForeColor = Color.DimGray;
            gCircleProgressBarThree.Location = new Point(93, 46);
            gCircleProgressBarThree.Minimum = 0;
            gCircleProgressBarThree.Name = "gCircleProgressBarThree";
            gCircleProgressBarThree.ProgressColor = Color.FromArgb(94, 148, 255);
            gCircleProgressBarThree.ProgressColor2 = Color.FromArgb(255, 77, 165);
            gCircleProgressBarThree.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            gCircleProgressBarThree.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            gCircleProgressBarThree.ProgressThickness = 25;
            gCircleProgressBarThree.ShadowDecoration.CustomizableEdges = customizableEdges3;
            gCircleProgressBarThree.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCircleProgressBarThree.Size = new Size(0, 0);
            gCircleProgressBarThree.TabIndex = 2;
            gCircleProgressBarThree.Value = 75;
            // 
            // gCircleProgressBarTwo
            // 
            gCircleProgressBarTwo.Animated = true;
            gCircleProgressBarTwo.AnimationSpeed = 0.3F;
            gCircleProgressBarTwo.BackColor = Color.Transparent;
            gCircleProgressBarTwo.Controls.Add(gCircleProgressBarOne);
            gCircleProgressBarTwo.FillColor = Color.FromArgb(200, 213, 218, 223);
            gCircleProgressBarTwo.FillThickness = 17;
            gCircleProgressBarTwo.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gCircleProgressBarTwo.ForeColor = Color.DimGray;
            gCircleProgressBarTwo.Location = new Point(54, 54);
            gCircleProgressBarTwo.Minimum = 0;
            gCircleProgressBarTwo.Name = "gCircleProgressBarTwo";
            gCircleProgressBarTwo.ProgressColor = Color.FromArgb(94, 148, 255);
            gCircleProgressBarTwo.ProgressColor2 = Color.FromArgb(128, 255, 255);
            gCircleProgressBarTwo.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            gCircleProgressBarTwo.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            gCircleProgressBarTwo.ProgressThickness = 17;
            gCircleProgressBarTwo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gCircleProgressBarTwo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCircleProgressBarTwo.Size = new Size(150, 150);
            gCircleProgressBarTwo.TabIndex = 1;
            gCircleProgressBarTwo.Value = 30;
            // 
            // gCircleProgressBarOne
            // 
            gCircleProgressBarOne.Animated = true;
            gCircleProgressBarOne.AnimationSpeed = 0.2F;
            gCircleProgressBarOne.BackColor = Color.Transparent;
            gCircleProgressBarOne.FillColor = Color.White;
            gCircleProgressBarOne.FillThickness = 12;
            gCircleProgressBarOne.Font = new Font("Trebuchet MS", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gCircleProgressBarOne.ForeColor = Color.DimGray;
            gCircleProgressBarOne.Location = new Point(34, 35);
            gCircleProgressBarOne.Minimum = 0;
            gCircleProgressBarOne.Name = "gCircleProgressBarOne";
            gCircleProgressBarOne.ProgressColor = Color.FromArgb(255, 77, 165);
            gCircleProgressBarOne.ProgressColor2 = Color.FromArgb(128, 255, 255);
            gCircleProgressBarOne.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            gCircleProgressBarOne.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            gCircleProgressBarOne.ProgressThickness = 12;
            gCircleProgressBarOne.ShadowDecoration.CustomizableEdges = customizableEdges1;
            gCircleProgressBarOne.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            gCircleProgressBarOne.ShowText = true;
            gCircleProgressBarOne.Size = new Size(80, 80);
            gCircleProgressBarOne.TabIndex = 2;
            gCircleProgressBarOne.Value = 50;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(flpMemberStatistical);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(23, 85);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowShift = 8;
            guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            guna2ShadowPanel1.Size = new Size(671, 250);
            guna2ShadowPanel1.TabIndex = 2;
            // 
            // flpMemberStatistical
            // 
            flpMemberStatistical.AutoScroll = true;
            flpMemberStatistical.Location = new Point(25, 18);
            flpMemberStatistical.Name = "flpMemberStatistical";
            flpMemberStatistical.Padding = new Padding(5, 0, 0, 0);
            flpMemberStatistical.Size = new Size(620, 215);
            flpMemberStatistical.TabIndex = 0;
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(gProgressBar);
            guna2ShadowPanel2.Controls.Add(lblDescription);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(21, 20);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.ShadowShift = 8;
            guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            guna2ShadowPanel2.Size = new Size(671, 59);
            guna2ShadowPanel2.TabIndex = 3;
            // 
            // gProgressBar
            // 
            gProgressBar.BorderRadius = 10;
            gProgressBar.CustomizableEdges = customizableEdges4;
            gProgressBar.FillColor = Color.Transparent;
            gProgressBar.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gProgressBar.ForeColor = Color.DimGray;
            gProgressBar.Location = new Point(147, 15);
            gProgressBar.Name = "gProgressBar";
            gProgressBar.ProgressColor = Color.FromArgb(94, 148, 255);
            gProgressBar.ProgressColor2 = Color.FromArgb(128, 255, 255);
            gProgressBar.ShadowDecoration.CustomizableEdges = customizableEdges5;
            gProgressBar.ShowText = true;
            gProgressBar.Size = new Size(491, 28);
            gProgressBar.TabIndex = 7;
            gProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            gProgressBar.Value = 50;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(19, 15);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(122, 28);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "PROGRESS\r\n";
            // 
            // UCThesisDetailsStatistical
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(gShadowPanelShowInfor);
            DoubleBuffered = true;
            Name = "UCThesisDetailsStatistical";
            Size = new Size(715, 635);
            gShadowPanelShowInfor.ResumeLayout(false);
            gCircleProgressBarThree.ResumeLayout(false);
            gCircleProgressBarTwo.ResumeLayout(false);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.Charts.WinForms.GunaSplineAreaDataset gunaSplineAreaDataset1;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelShowInfor;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2CircleProgressBar gCircleProgressBarThree;
        private Guna.UI2.WinForms.Guna2CircleProgressBar gCircleProgressBarTwo;
        private Guna.UI2.WinForms.Guna2CircleProgressBar gCircleProgressBarOne;
        private FlowLayoutPanel flpMemberStatistical;
        private Guna.Charts.WinForms.GunaChart gChart;
        private Guna.Charts.WinForms.GunaSplineAreaDataset gSplineAreaDataset;
        private Label lblDescription;
        private Guna.UI2.WinForms.Guna2ProgressBar gProgressBar;
    }
}

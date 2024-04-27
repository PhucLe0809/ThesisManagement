namespace ThesisManagementProject
{
    partial class UCStatisticalStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCStatisticalStudent));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gLineDataset = new Guna.Charts.WinForms.GunaLineDataset();
            label1 = new Label();
            gChart = new Guna.Charts.WinForms.GunaChart();
            gShadowPanelThesis = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblNoteStatisThesis = new Label();
            gPictureBoxItemThesis = new Guna.UI2.WinForms.Guna2PictureBox();
            lblNumThesis = new Label();
            gShadowPanelThesis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gPictureBoxItemThesis).BeginInit();
            SuspendLayout();
            // 
            // gLineDataset
            // 
            gLineDataset.BorderColor = Color.Empty;
            gLineDataset.BorderWidth = 0;
            gLineDataset.FillColor = Color.Empty;
            gLineDataset.Label = "Score";
            gLineDataset.LegendBoxBorderColor = Color.Transparent;
            gLineDataset.LegendBoxFillColor = Color.FromArgb(255, 255, 192);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(288, 50);
            label1.Name = "label1";
            label1.Size = new Size(214, 31);
            label1.TabIndex = 35;
            label1.Text = "ACADEMIC CHART";
            // 
            // gChart
            // 
            gChart.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { gLineDataset });
            gChart.Legend.Display = false;
            chartFont1.FontName = "Arial";
            gChart.Legend.LabelFont = chartFont1;
            gChart.Location = new Point(8, 86);
            gChart.Name = "gChart";
            gChart.Size = new Size(735, 206);
            gChart.TabIndex = 34;
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
            tick2.Maximum = 10D;
            gChart.YAxes.Ticks = tick2;
            gChart.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            gChart.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            gChart.ZAxes.Ticks = tick3;
            // 
            // gShadowPanelThesis
            // 
            gShadowPanelThesis.BackColor = Color.Transparent;
            gShadowPanelThesis.Controls.Add(lblNoteStatisThesis);
            gShadowPanelThesis.Controls.Add(gPictureBoxItemThesis);
            gShadowPanelThesis.Controls.Add(lblNumThesis);
            gShadowPanelThesis.FillColor = Color.White;
            gShadowPanelThesis.Location = new Point(36, 10);
            gShadowPanelThesis.Name = "gShadowPanelThesis";
            gShadowPanelThesis.Radius = 7;
            gShadowPanelThesis.ShadowColor = Color.Black;
            gShadowPanelThesis.ShadowShift = 4;
            gShadowPanelThesis.Size = new Size(227, 70);
            gShadowPanelThesis.TabIndex = 33;
            // 
            // lblNoteStatisThesis
            // 
            lblNoteStatisThesis.AutoSize = true;
            lblNoteStatisThesis.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoteStatisThesis.ForeColor = Color.Gray;
            lblNoteStatisThesis.Location = new Point(78, 40);
            lblNoteStatisThesis.Name = "lblNoteStatisThesis";
            lblNoteStatisThesis.Size = new Size(132, 17);
            lblNoteStatisThesis.TabIndex = 9;
            lblNoteStatisThesis.Text = "completed theses";
            // 
            // gPictureBoxItemThesis
            // 
            gPictureBoxItemThesis.CustomizableEdges = customizableEdges1;
            gPictureBoxItemThesis.FillColor = Color.Transparent;
            gPictureBoxItemThesis.Image = (Image)resources.GetObject("gPictureBoxItemThesis.Image");
            gPictureBoxItemThesis.ImageRotate = 0F;
            gPictureBoxItemThesis.Location = new Point(17, 7);
            gPictureBoxItemThesis.Name = "gPictureBoxItemThesis";
            gPictureBoxItemThesis.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gPictureBoxItemThesis.Size = new Size(50, 50);
            gPictureBoxItemThesis.SizeMode = PictureBoxSizeMode.StretchImage;
            gPictureBoxItemThesis.TabIndex = 10;
            gPictureBoxItemThesis.TabStop = false;
            // 
            // lblNumThesis
            // 
            lblNumThesis.AutoSize = true;
            lblNumThesis.Font = new Font("Trebuchet MS", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumThesis.Location = new Point(78, 7);
            lblNumThesis.Name = "lblNumThesis";
            lblNumThesis.Size = new Size(44, 32);
            lblNumThesis.TabIndex = 11;
            lblNumThesis.Text = "24";
            // 
            // UCStatisticalStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(gChart);
            Controls.Add(gShadowPanelThesis);
            Name = "UCStatisticalStudent";
            Size = new Size(750, 295);
            gShadowPanelThesis.ResumeLayout(false);
            gShadowPanelThesis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gPictureBoxItemThesis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.Charts.WinForms.GunaLineDataset gLineDataset;
        private Label label1;
        private Guna.Charts.WinForms.GunaChart gChart;
        private Guna.UI2.WinForms.Guna2ShadowPanel gShadowPanelThesis;
        private Label lblNoteStatisThesis;
        private Guna.UI2.WinForms.Guna2PictureBox gPictureBoxItemThesis;
        private Label lblNumThesis;
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisManagementProject
{
    public partial class UCTeamLine : UserControl
    {
        public UCTeamLine()
        {
            InitializeComponent();
        }

        public void SetFavorites()
        {
            gButtonStar.Image = Properties.Resources.PicInLineGradientStar;
        }
        private void SetColor(Color color)
        {
            this.BackColor = color;
            gTextBoxTeamCode.FillColor = color;
            gTextBoxNumTopics.FillColor = color;
            gTextBoxNumTheses.FillColor = color;
            gTextBoxNumMembers.FillColor = color;
        }

        private void UCTeamLine_Click(object sender, EventArgs e)
        {
            FTeamDetails fTeamDetails = new FTeamDetails();
            fTeamDetails.Show();
        }

        private void UCTeamLine_MouseEnter(object sender, EventArgs e)
        {
            SetColor(Color.Gainsboro);
        }

        private void UCTeamLine_MouseLeave(object sender, EventArgs e)
        {
            SetColor(Color.White);
        }
    }
}

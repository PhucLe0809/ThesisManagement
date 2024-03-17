using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ThesisManagementProject
{
    public partial class UCThesisLine : UserControl
    {
        public event EventHandler ThesisLineClicked;

        public UCThesisLine()
        {
            InitializeComponent();
        }

        public void SetFavorites()
        {
            gButtonStar.Image = Properties.Resources.PicInLineGradientStar;
        }

        public Guna2Button GetGButtonStar
        {
            get { return this.gButtonStar; }
        }

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            OnThesisLineClicked(EventArgs.Empty);
        }

        private void SetColor(Color color)
        {
            this.BackColor = color;
            gTextBoxThesisCode.FillColor = color;
            gTextBoxPending.FillColor = color;
            gTextBoxAccepted.FillColor = color;
            gTextBoxCompleted.FillColor = color;
        }

        private void UCThesisLine_MouseEnter(object sender, EventArgs e)
        {
            SetColor(Color.Gainsboro);
        }

        private void UCThesisLine_MouseLeave(object sender, EventArgs e)
        {
            SetColor(Color.White);
        }

        private void UCThesisLine_Click(object sender, EventArgs e)
        {
            OnThesisLineClicked(EventArgs.Empty);
        }

        public virtual void OnThesisLineClicked(EventArgs e)
        {
            ThesisLineClicked?.Invoke(this, e);
        }
    }
}

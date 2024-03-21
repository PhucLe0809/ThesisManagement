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
        public event EventHandler ThesisDeleteClicked;

        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();

        public UCThesisLine()
        {
            InitializeComponent();
        }

        private void UserControlLoad()
        {
            MyProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);

            lblThesisTopic.Text = MyProcess.FormatStringLength(thesis.Topic, 30);
            gTextBoxStatus.Text = (MyProcess.ComparePublished(thesis.PublishDate)) ? ("Published") : ("Unpublish");
            gTextBoxThesisCode.Text = thesis.IdThesis;
            gTextBoxPending.Text = thesis.NumPending.ToString();
            gTextBoxAccepted.Text = thesis.NumAccepted.ToString();
            gTextBoxCompleted.Text = thesis.NumAccepted.ToString();
        }

        #region METHOD

        public void SetInformation(Thesis thesis)
        {
            this.thesis = thesis;
            UserControlLoad();
        }

        private void SetColor(Color color)
        {
            this.BackColor = color;
            gTextBoxThesisCode.FillColor = color;
            gTextBoxPending.FillColor = color;
            gTextBoxAccepted.FillColor = color;
            gTextBoxCompleted.FillColor = color;
        }

        #endregion

        #region PROPERTIES

        public Guna2Button GetGButtonStar
        {
            get { return this.gButtonStar; }
        }
        public string ID
        {
            get { return this.gTextBoxThesisCode.Text; }
        }

        #endregion

        #region EVENT USER CONTROL

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

        #endregion

        #region EVENT Toolbar

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisEdit = new FThesisEdit();
            fThesisEdit.UpdateThesis(MyProcess.SelectThesis(gTextBoxThesisCode.Text));
            fThesisEdit.ShowDialog();
        }

        private void gButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete thesis " + gTextBoxThesisCode.Text,
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                thesisDAO.Delete(MyProcess.SelectThesis(gTextBoxThesisCode.Text));
                OnThesisDeleteClicked(EventArgs.Empty);
            }
        }
        public virtual void OnThesisDeleteClicked(EventArgs e)
        {
            ThesisDeleteClicked?.Invoke(this, e);
        }

        #endregion

        private void gButtonStar_Click(object sender, EventArgs e)
        {
            thesis.IsFavorite = !thesis.IsFavorite;

            MyProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            thesisDAO.SQLByCommand(string.Format("Update " + MyDatabase.DBThesis + " Set isfavorite = {0} Where idthesis = '{1}'",
                                    (thesis.IsFavorite)?(1):(0), thesis.IdThesis));
            
            UserControlLoad();
        }
    }
}

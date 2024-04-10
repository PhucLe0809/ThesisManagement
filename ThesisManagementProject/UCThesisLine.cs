﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCThesisLine : UserControl
    {
        private MyProcess myProcess = new MyProcess();
        public event EventHandler ThesisLineClicked;
        public event EventHandler ThesisDeleteClicked;

        private Thesis thesis = new Thesis();
        private People creator = new People();
        private People instructor = new People();
        private ThesisDAO thesisDAO = new ThesisDAO();
        private PeopleDAO peopleDAO = new PeopleDAO();

        public UCThesisLine()
        {
            InitializeComponent();
        }

        #region FUNCTIONS

        public void SetInformation(Thesis thesis)
        {
            this.thesis = thesis;
            this.creator = peopleDAO.SelectOnlyByID(thesis.IdCreator);
            this.instructor = peopleDAO.SelectOnlyByID(thesis.IdInstructor);
            InitUserControl();
        }
        private void InitUserControl()
        {
            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);

            lblThesisTopic.Text = myProcess.FormatStringLength(thesis.Topic, 120);
            gTextBoxStatus.Text = thesis.Status.ToString();
            gTextBoxStatus.FillColor = thesis.GetStatusColor();
            lblCreator.Text = creator.FullName;
            lblInstructor.Text = instructor.FullName;
        }
        private void SetColor(Color color)
        {
            this.BackColor = color;
        }
        public void HideToolBar()
        {
            gButtonEdit.Hide();
            gButtonDelete.Hide();
        }

        #endregion

        #region PROPERTIES

        public Guna2Button GetGButtonEdit 
        { 
            get => gButtonEdit; 
        }
        public Guna2Button GetGButtonDelete
        {
            get => gButtonDelete;
        }
        public string ID
        {
            get { return this.thesis.IdThesis; }
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
            FThesisEdit fThesisEdit = new FThesisEdit(instructor, thesis);
            fThesisEdit.ShowDialog();
            this.thesis = thesisDAO.SelectOnly(thesis.IdThesis);
            InitUserControl();
        }
        private void gButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete thesis " + thesis.IdThesis,
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                thesisDAO.Delete(thesisDAO.SelectOnly(thesis.IdThesis));
                OnThesisDeleteClicked(EventArgs.Empty);
            }
        }
        public virtual void OnThesisDeleteClicked(EventArgs e)
        {
            ThesisDeleteClicked?.Invoke(this, e);
        }

        #endregion

        #region EVENT gButtonStar

        private void gButtonStar_Click(object sender, EventArgs e)
        {
            thesis.IsFavorite = !thesis.IsFavorite;

            myProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            thesisDAO.SQLExecuteByCommand(string.Format("Update " + MyDatabase.DBThesis + " Set isfavorite = {0} Where idthesis = '{1}'",
                                    (thesis.IsFavorite)?(1):(0), thesis.IdThesis));
        }

        #endregion

    }
}

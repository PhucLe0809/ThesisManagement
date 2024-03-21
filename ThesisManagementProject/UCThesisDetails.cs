using Guna.UI2.WinForms;
using System;
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
    public partial class UCThesisDetails : UserControl
    {
        private Thesis thesis = new Thesis();
        private ThesisDAO thesisDAO = new ThesisDAO();

        public UCThesisDetails()
        {
            InitializeComponent();

        }

        private void AddStudentToFLP(FlowLayoutPanel flpanel, List<Student> list, bool flag)
        {
            flpanel.Controls.Clear();
            foreach (Student student in list)
            {
                UCStudentMiniLine line = new UCStudentMiniLine();
                line.SetInformation(student);
                if (flag) line.SetButtonAddImageNull();
                line.ThesisMiniLineClicked += GButtonAdd_Click;
                flpanel.Controls.Add(line);
            }
        }

        private void GButtonAdd_Click(object sender, EventArgs e)
        {
            UCStudentMiniLine line = sender as UCStudentMiniLine;

            if (line != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to accept " + line.GetStudent.Handle,
                                                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    thesisDAO.SQLByCommand("update " + MyDatabase.DBThesisStatus + " set sta = '" + EThesisStatus.Accepted.ToString() + "' " +
                        "where idaccount = '" + line.GetStudent.IdAccount + "' and idthesis = '" + thesis.IdThesis + "'");

                    AddStudentToFLP(flpPending, thesisDAO.SelectByStatus(EThesisStatus.Pending.ToString(), thesis.IdThesis), false);
                    AddStudentToFLP(flpAccepted, thesisDAO.SelectByStatus(EThesisStatus.Accepted.ToString(), thesis.IdThesis), true);
                }
            }

        }

        private void UserControlLoad()
        {
            AddStudentToFLP(flpPending, thesisDAO.SelectByStatus(EThesisStatus.Pending.ToString(), thesis.IdThesis), false);
            AddStudentToFLP(flpAccepted, thesisDAO.SelectByStatus(EThesisStatus.Accepted.ToString(), thesis.IdThesis), true);
            AddStudentToFLP(flpCompleted, thesisDAO.SelectByStatus(EThesisStatus.Completed.ToString(), thesis.IdThesis), true);

            gGradientButtonThesisReset_Click(new object(), new EventArgs());

        }

        #region PROPERTIES

        public Guna2Button GButtonBack
        {
            get { return this.gButtonBack; }
        }

        #endregion

        #region FUNCTIONS

        public void UpdateThesis(Thesis thesis)
        {
            this.thesis = thesis;
            UserControlLoad();
        }

        #endregion

        #region EVENT gButtonEdit

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            FThesisEdit fThesisDetails = new FThesisEdit();
            fThesisDetails.UpdateThesis(thesis);
            fThesisDetails.ShowDialog();
        }

        #endregion

        private void gGradientButtonThesisReset_Click(object sender, EventArgs e)
        {
            this.thesis = MyProcess.SelectThesis(thesis.IdThesis);

            MyProcess.SetItemFavorite(gButtonStar, thesis.IsFavorite);
            gTextBoxTopic.Text = thesis.Topic;
            gTextBoxField.Text = thesis.Field.ToString();
            gTextBoxLevel.Text = thesis.Level.ToString();
            gTextBoxMembers.Text = thesis.MaxMembers.ToString();
        }
    }
}

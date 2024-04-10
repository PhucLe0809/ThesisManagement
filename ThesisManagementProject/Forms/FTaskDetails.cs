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
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Forms
{
    public partial class FTaskDetails : Form
    {
        private MyProcess myProcess = new MyProcess();

        private People people = new People();
        private Tasks tasks = new Tasks();
        private People creator = new People();
        private Team team = new Team();
        private Tasks dynamicTask = new Tasks();
        private TasksDAO tasksDAO = new TasksDAO();
        private UCTaskComment uCTaskComment = new UCTaskComment();
        private UCTaskEvaluate uCTaskEvaluate = new UCTaskEvaluate();
        private bool isProcessing = true;
        private bool flagCheck = false;
        private bool edited = false;

        public FTaskDetails(People people, Tasks tasks, People creator, Team team, bool isProcessing)
        {
            InitializeComponent();
            this.people = people;
            this.tasks = tasks;
            this.creator = creator;
            this.team = team;
            this.isProcessing = isProcessing;
            SetUpUserControl();
        }

        #region PROPERTIES

        public bool Edited
        {
            get { return this.edited; }
        }

        #endregion

        #region FUNCTIONS

        private void SetUpUserControl()
        {
            this.dynamicTask = tasks.Clone();
            InitUserControl();
            SetViewState();
        }
        private void InitUserControl()
        {
            lblCreator.Text = creator.FullName;
            gTextBoxTitle.Text = tasks.Title;
            gTextBoxDescription.Text = tasks.Description;
            gTextBoxProgress.Text = tasks.Progress.ToString();
            gCirclePictureBoxCreator.Image = myProcess.NameToImage(creator.AvatarName);
            myProcess.SetItemFavorite(gButtonStar, tasks.IsFavorite);

            if (!isProcessing || tasks.IdCreator != people.IdAccount)
            {
                gButtonEdit.Hide();
                gButtonStar.Location = new Point(383, 17);
            }

            uCTaskComment.SetInformation(people, tasks, isProcessing);
            gShadowPanelView.Controls.Add(uCTaskComment);
            gShadowPanelView.Controls.Add(uCTaskEvaluate);
            gGradientButtonComment.PerformClick();
        }
        private void SetViewState()
        {
            gButtonCancel.Hide();
            gButtonSave.Hide();
            myProcess.SetTextBoxState(new List<Guna2TextBox> { gTextBoxTitle, gTextBoxDescription, gTextBoxProgress }, true);
        }
        private void SetEditState()
        {
            gButtonCancel.Show();
            gButtonSave.Show();
            myProcess.SetTextBoxState(new List<Guna2TextBox> { gTextBoxTitle, gTextBoxDescription, gTextBoxProgress }, false);
        }
        private bool CheckInformationValid()
        {
            myProcess.RunCheckDataValid(tasks.CheckTitle() || flagCheck, erpTitle, gTextBoxTitle, "Title cannot be empty");
            myProcess.RunCheckDataValid(tasks.CheckDescription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
            myProcess.RunCheckDataValid((gTextBoxProgress.Text != string.Empty && tasks.CheckProgress()) || flagCheck, erpProgress, gTextBoxProgress, "Can only take values from 0 to 100");

            return tasks.CheckTitle() && tasks.CheckDescription() && (gTextBoxProgress.Text != string.Empty && tasks.CheckProgress());
        }
        private void AllButtonStandardColor()
        {
            myProcess.ButtonStandardColor(gGradientButtonComment, Color.White, Color.White);
            myProcess.ButtonStandardColor(gGradientButtonEvaluate, Color.White, Color.White);
        }

        #endregion

        #region EVENT BUTTON CLICK

        private void gButtonEdit_Click(object sender, EventArgs e)
        {
            SetEditState();
        }
        private void gButtonCancel_Click(object sender, EventArgs e)
        {
            gTextBoxTitle.Text = tasks.Title;
            gTextBoxDescription.Text = tasks.Description;
            gTextBoxProgress.Text = tasks.Progress.ToString();
            SetViewState();
        }
        private void gButtonSave_Click(object sender, EventArgs e)
        {
            this.tasks = new Tasks(tasks.IdTask, gTextBoxTitle.Text, gTextBoxDescription.Text, this.creator.IdAccount, this.team.IDTeam,
                                        tasks.IsFavorite, int.Parse(gTextBoxProgress.Text.ToString()), tasks.CreatedDate);

            this.flagCheck = false;
            if (CheckInformationValid())
            {
                tasksDAO.Update(tasks);
                this.flagCheck = true;
                this.edited = true;
                SetViewState();
            }
        }
        private void gGradientButtonComment_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonComment);
            uCTaskEvaluate.Hide();
            uCTaskComment.Show();
        }
        private void gGradientButtonEvaluate_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonEvaluate);
            uCTaskEvaluate.Show();
            uCTaskComment.Hide();
        }

        #endregion

        #region EVENT TEXTCHANGED

        private void gTextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            this.dynamicTask.Title = gTextBoxTitle.Text;
            myProcess.RunCheckDataValid(dynamicTask.CheckTitle() || flagCheck, erpTitle, gTextBoxTitle, "Title cannot be empty");
        }
        private void gTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            this.dynamicTask.Description = gTextBoxDescription.Text;
            myProcess.RunCheckDataValid(dynamicTask.CheckDescription() || flagCheck, erpDescription, gTextBoxDescription, "Description cannot be empty");
        }
        private void gTextBoxProgress_TextChanged(object sender, EventArgs e)
        {
            if (gTextBoxProgress.Text != string.Empty)
            {
                this.dynamicTask.Progress = myProcess.ConvertStringToInt32(gTextBoxProgress.Text);
            }
            bool isValid = (gTextBoxProgress.Text != string.Empty && dynamicTask.CheckProgress()) || flagCheck;
            myProcess.RunCheckDataValid(isValid, erpProgress, gTextBoxProgress, "Can only take values from 0 to 100");
            if (isValid) gProgressBarToLine.Value = dynamicTask.Progress;
        }

        #endregion

    }
}

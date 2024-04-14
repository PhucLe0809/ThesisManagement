using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Forms
{
    public partial class FTaskDetails : Form
    {
        private MyProcess myProcess = new MyProcess();

        private People host = new People();
        private People creator = new People();
        private People instructor = new People();
        private Team team = new Team();
        private Tasks tasks = new Tasks();
        private Tasks dynamicTask = new Tasks();

        private TasksDAO tasksDAO = new TasksDAO();
        private EvaluationDAO evaluationDAO = new EvaluationDAO();

        private UCTaskComment uCTaskComment = new UCTaskComment();
        private UCTaskEvaluateList uCTaskEvaluateList = new UCTaskEvaluateList();
        private UCTaskEvaluateDetails uCTaskEvaluateDetails = new UCTaskEvaluateDetails();
        private UCPeopleMiniLine peopleLineClicked = new UCPeopleMiniLine();
        private bool isProcessing = true;
        private bool flagCheck = false;
        private bool edited = false;

        public FTaskDetails(People host, People instructor, Tasks tasks, People creator, Team team, bool isProcessing)
        {
            InitializeComponent();
            this.host = host;
            this.instructor = instructor;
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

            if (!isProcessing || (host.Role == ERole.Student && tasks.IdCreator != host.IdAccount))
            {
                gButtonEdit.Hide();
                gButtonStar.Location = new Point(383, 17);
            }

            uCTaskComment.SetUpUserControl(host, instructor, tasks, isProcessing);
            gShadowPanelView.Controls.Add(uCTaskComment);

            uCTaskEvaluateList.SetUpUserControl(tasks, team, host);
            uCTaskEvaluateList.ClickEvaluate += Line_ClickEvaluate;
            gShadowPanelView.Controls.Add(uCTaskEvaluateList);

            uCTaskEvaluateDetails.GButtonBack.Click += GButtonBack_Click;
            gShadowPanelView.Controls.Add(uCTaskEvaluateDetails);

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
            int progress = 0;
            bool checkProgress = int.TryParse(gTextBoxProgress.Text, out progress);
            if (checkProgress) tasks.Progress = progress;
            myProcess.RunCheckDataValid((checkProgress && tasks.CheckProgress()) || flagCheck, erpProgress, gTextBoxProgress, "Can only take values from 0 to 100");

            return tasks.CheckTitle() && tasks.CheckDescription() && (checkProgress && tasks.CheckProgress());
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
            this.flagCheck = false;
            if (CheckInformationValid())
            {
                this.tasks = new Tasks(tasks.IdTask, gTextBoxTitle.Text, gTextBoxDescription.Text, this.creator.IdAccount, this.team.IDTeam,
                                            tasks.IsFavorite, int.Parse(gTextBoxProgress.Text.ToString()), tasks.CreatedDate);

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
            uCTaskEvaluateList.Hide();
            uCTaskEvaluateDetails.Hide();
            uCTaskComment.Show();
        }
        private void gGradientButtonEvaluate_Click(object sender, EventArgs e)
        {
            AllButtonStandardColor();
            myProcess.ButtonSettingColor(gGradientButtonEvaluate);
            uCTaskComment.Hide();
            uCTaskEvaluateDetails.Hide();
            uCTaskEvaluateList.Show();
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
            int progress = 0;
            bool checkProgress = int.TryParse(gTextBoxProgress.Text, out progress);
            if (checkProgress)
            {
                tasks.Progress = progress;
                gProgressBarToLine.Value = progress;
            }
            myProcess.RunCheckDataValid((checkProgress && tasks.CheckProgress()) || flagCheck, erpProgress, gTextBoxProgress, "Can only take values from 0 to 100");
        }

        #endregion

        #region METHOD UCTASK EVALUATE

        private void Line_ClickEvaluate(object sender, EventArgs e)
        {
            UCPeopleMiniLine line = uCTaskEvaluateList.GetPeopleLine;

            if (line != null)
            {
                this.peopleLineClicked = line;
                uCTaskEvaluateDetails.SetUpUserControl(this.tasks, line.GetPeople, line.GetEvaluation, host, isProcessing);
                uCTaskComment.Hide();
                uCTaskEvaluateList.Hide();
                uCTaskEvaluateDetails.Show();
            }
        }
        private void GButtonBack_Click(object sender, EventArgs e)
        {
            Evaluation evaluation = evaluationDAO.SelectOnly(tasks.IdTask, this.peopleLineClicked.GetPeople.IdAccount);
            this.peopleLineClicked.SetEvaluateMode(evaluation, true);
            gGradientButtonEvaluate.PerformClick();
        }

        #endregion

    }
}

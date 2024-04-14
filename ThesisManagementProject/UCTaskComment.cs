using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ThesisManagementProject.DAOs;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject
{
    public partial class UCTaskComment : UserControl
    {
        private MyProcess myProcess = new MyProcess();

        private People people = new People();
        private People instructor = new People();
        private Thesis thesis = new Thesis();
        private Tasks tasks = new Tasks();
        private Team team = new Team();
        private Comment comment = new Comment();

        private TeamDAO teamDAO = new TeamDAO();
        private CommentDAO commentDAO = new CommentDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();

        private bool isProcessing = true;

        public UCTaskComment()
        {
            InitializeComponent();
        }

        #region FUNCTIONS

        public void SetUpUserControl(People people, People instructor, Thesis thesis, Tasks tasks, bool isProcessing)
        {
            this.people = people;
            this.tasks = tasks;
            this.thesis = thesis;
            this.instructor = instructor;
            this.isProcessing = isProcessing;
            this.team = teamDAO.SelectOnly(tasks.IdTeam);
            InitUserControl();
        }
        private void InitUserControl()
        {
            gCirclePictureBoxCommentator.Image = myProcess.NameToImage(people.AvatarName);
            if (!isProcessing)
            {
                gCirclePictureBoxCommentator.Hide();
                gTextBoxComment.Hide();
                ptbEmoji.Hide();
                gButtonSend.Hide();
                gSeparatorUnder.Location = new Point(14, 505);
                flpComment.Size = new Size(670, 435);
            }
            LoadTaskComment();
        }
        private void LoadTaskComment()
        {
            List<Comment> listComment = commentDAO.SelectList(this.tasks);

            flpComment.Controls.Clear();
            UCCommentLine line = new UCCommentLine();
            foreach (Comment comment in listComment)
            {
                line = new UCCommentLine(comment);
                flpComment.Controls.Add(line);
            }
            flpComment.ScrollControlIntoView(line);
        }

        #endregion

        #region EVENT COMMENT

        private void SendComment()
        {
            if (gTextBoxComment.Text != string.Empty)
            {
                this.comment = new Comment(tasks.IdTask, people.IdAccount, gTextBoxComment.Text, "EmojiLike", DateTime.Now);
                UCCommentLine line = new UCCommentLine(comment);
                flpComment.Controls.Add(line);
                flpComment.ScrollControlIntoView(line);
                commentDAO.Insert(comment);

                List<People> peoples = team.Members.ToList();
                peoples.Add(this.instructor);
                string content = Notification.GetContentTypeComment(people.FullName, comment.Content, tasks.Title);
                notificationDAO.InsertFollowListPeople(people.IdAccount, thesis.IdThesis, comment.IdComment, content, peoples);

                gTextBoxComment.Clear();
            }
        }
        private void gButtonSend_Click(object sender, EventArgs e)
        {
            SendComment();
        }
        private void gTextBoxComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendComment();
            }
        }
        private void gTextBoxComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }

        }

        #endregion

    }
}

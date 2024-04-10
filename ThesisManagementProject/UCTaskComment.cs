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

namespace ThesisManagementProject
{
    public partial class UCTaskComment : UserControl
    {
        private MyProcess myProcess = new MyProcess();

        private People people = new People();
        private Tasks tasks = new Tasks();
        private CommentDAO commentDAO = new CommentDAO();
        private bool isProcessing = true;

        public UCTaskComment()
        {
            InitializeComponent();
        }

        #region FUNCTIONS

        public void SetInformation(People people, Tasks tasks, bool isProcessing)
        {
            this.people = people;
            this.tasks = tasks;
            this.isProcessing = isProcessing;
            SetUpUserControl();
        }
        private void SetUpUserControl()
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
            string command = string.Format("SELECT * FROM {0} WHERE idtask = '{1}' ORDER BY created",
                                            MyDatabase.DBComment, tasks.IdTask);
            List<Comment> listComment = commentDAO.SelectList(command);

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
                Comment comment = new Comment(tasks.IdTask, people.IdAccount, gTextBoxComment.Text, "EmojiLike", DateTime.Now);
                UCCommentLine line = new UCCommentLine(comment);
                flpComment.Controls.Add(line);
                flpComment.ScrollControlIntoView(line);
                commentDAO.Insert(comment);
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

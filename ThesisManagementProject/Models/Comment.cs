using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Comment
    {
        MyProcess myProcess = new MyProcess();

        #region COMMENT ATTRIBUTES

        private string idComment;
        private string idTask;
        private string idCreator;
        private string content;
        private string emoji;
        private DateTime created;

        #endregion

        #region COMMENT CONSTRUCTOR

        public Comment()
        {
            this.idComment = string.Empty;
            this.idTask = string.Empty;
            this.idCreator = string.Empty;
            this.content = string.Empty;
            this.emoji = "EmojiLike";
            this.created = DateTime.Now;
        }
        public Comment(string idTask, string idCreator, string content, string emoji, DateTime created)
        {
            this.idComment = myProcess.GenIDClassify(EClassify.Comment);
            this.idTask = idTask;
            this.idCreator = idCreator;
            this.content = content;
            this.emoji = emoji;
            this.created = created;
        }
        public Comment(string idComment, string idTask, string idCreator, string content, string emoji, DateTime created)
        {
            this.idComment = idComment;
            this.idTask = idTask;
            this.idCreator = idCreator;
            this.content = content;
            this.emoji = emoji;
            this.created = created;
        }

        #endregion

        #region COMMENT PROPERTIES

        public string IdComment
        {
            get { return this.idComment; }
        }
        public string IdTask
        {
            get { return this.idTask; }
        }
        public string IdCreator
        {
            get { return this.idCreator; }
        }
        public string Content
        {
            get { return this.content; }
        }
        public string Emoji
        {
            get { return this.emoji; }
        }
        public DateTime Created
        {
            get { return this.created; }
        }

        #endregion

        #region CHECK INFORMATIONS

        public bool CheckContent()
        {
            return this.content != string.Empty;
        }

        #endregion

    }
}

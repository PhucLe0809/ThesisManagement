using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ThesisManagementProject.Models
{
    #region NOTIFICATION ENUM

    public enum ENotificationType
    {
        [Display(Name = "Thesis")]
        Thesis,
        [Display(Name = "Task")]
        Task,
        [Display(Name = "Evaluation")]
        Evaluation,
        [Display(Name = "Comment")]
        Comment,
        [Display(Name = "Null")]
        Null,
    }

    #endregion

    public class Notification
    {
        private MyProcess myProcess = new MyProcess();

        #region NOTIFICATION ATTRIBUTES

        private string idNotification;
        private string idHost;
        private string idSender;
        private string idThesis;
        private string idObject;
        private string content;
        private string type;
        private ENotificationType notype;
        private DateTime created;
        private bool isFavorite;
        private bool isSaw;

        #endregion

        #region NOTIFICATION CONTRUCTOR

        public Notification()
        {
            this.idNotification = string.Empty;
            this.idHost = string.Empty;
            this.idSender = string.Empty;
            this.idThesis = string.Empty;
            this.idObject = string.Empty;
            this.content = string.Empty;
            this.type = string.Empty;
            this.notype = ENotificationType.Null;
            this.created = DateTime.MinValue;
            this.isFavorite = false;
            this.isSaw = false;
        }
        public Notification(string idNotification, string idHost, string idSender, string idThesis, string idObject, string content, 
                            ENotificationType type, DateTime created, bool isFavorite, bool isSaw)
        {
            this.idNotification = idNotification;
            this.idHost = idHost;
            this.idSender = idSender;
            this.idThesis = idThesis;
            this.idObject= idObject;
            this.content = content;
            this.notype = type;
            this.type = this.notype.ToString();
            this.created = created;
            this.isFavorite = isFavorite;
            this.isSaw = isSaw;
        }
        public Notification(string idHost, string idSender, string idThesis, string idOject, string content, DateTime created, bool isFavorite, bool isSaw)
        {
            this.idNotification = myProcess.GenIDClassify(EClassify.Notification);
            this.idHost = idHost;
            this.idSender = idSender;
            this.idThesis = idThesis;
            this.idObject = idOject; 
            this.content = content;
            this.notype = GetNotificationType();
            this.type = this.notype.ToString();
            this.created = created;
            this.isFavorite = isFavorite;
            this.isSaw = isSaw;
        }

        #endregion

        #region PROPERTIES

        [Key]
        public string IdNotification
        {
            get { return this.idNotification; }
            set { this.idNotification = value; }
        }
        public string IdHost
        {
            get { return this.idHost; }
            set { this.idHost = value; }
        }
        public string IdSender
        {
            get { return this.idSender; }
            set { this.idSender = value; }
        }
        public string IdThesis
        {
            get { return this.idThesis; }
            set { this.idThesis = value; }
        }
        public string IdObject
        {
            get { return this.idObject; }
            set { this.idObject = value; }
        }
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
        public string Type
        {
            get { return this.type; }
            set 
            { 
                this.type = value;
                this.notype = myProcess.GetEnumFromDisplayName<ENotificationType>(this.type);
            }
        }
        [NotMapped]
        public ENotificationType OnType
        {
            get { return this.notype; }
            set
            {
                this.notype = value;
                this.type = this.notype.ToString();
            }
        }
        public DateTime Created
        {
            get { return this.created; }
            set { this.created = value; }
        }
        public bool IsFavorite
        {
            get { return this.isFavorite; }
            set { this.isFavorite = value; }
        }
        public bool IsSaw
        {
            get { return this.isSaw; }
            set { this.isSaw = value; }
        }

        #endregion

        #region FUNCTIONS 

        private ENotificationType GetNotificationType()
        {
            if (this.idObject.Length < 4) return ENotificationType.Null;

            string pattern = this.idObject.Substring(2, 2);
            if (pattern == ConvertEClassifyToString(EClassify.Thesis))  return ENotificationType.Thesis;
            if (pattern == ConvertEClassifyToString(EClassify.Task)) return ENotificationType.Task;
            if (pattern == ConvertEClassifyToString(EClassify.Evaluation)) return ENotificationType.Evaluation;
            if (pattern == ConvertEClassifyToString(EClassify.Comment)) return ENotificationType.Comment;
            return ENotificationType.Null;
        }
        private string ConvertEClassifyToString(EClassify eClassify)
        {
            return ((int)eClassify).ToString().PadLeft(2, '0');
        }
        public Color GetTypeColor()
        {
            switch (this.notype)
            {
                case ENotificationType.Thesis:
                    return Color.FromArgb(255, 87, 87);
                case ENotificationType.Task:
                    return Color.FromArgb(94, 148, 255);
                case ENotificationType.Evaluation:
                    return Color.FromArgb(45, 237, 55);
                default:
                    return Color.Gray;
            }
        }
        public static string GetContentTypeThesis(string senderName, string thesisTopic)
        {
            return string.Format("{0} has suggested the [{1}] thesis to you", senderName, thesisTopic);
        }
        public static string GetContentTypeRegistered(string teamName, string thesisTopic)
        {
            return string.Format("{0} team has registered for the [{1}] thesis", teamName, thesisTopic);
        }
        public static string GetContentRegisteredMembers(string senderName, string teamName, string thesisTopic)
        {
            return string.Format("{0} has registered team [{1}] with you for the thesis [{2}]", senderName, teamName, thesisTopic);
        }
        public static string GetContentTypeAccepted(string senderName, string thesisTopic)
        {
            return string.Format("{0} has agreed with your team for the thesis [{1}]", senderName, thesisTopic);
        }
        public static string GetContentTypeTask(string senderName, string taskTitle, string thesisTopic)
        {
            return string.Format("{0} has created a [{1}] task in the [{2}] thesis", senderName, taskTitle, thesisTopic);
        }
        public static string GetContentTypeEvaluation(string senderName, string taskTitle)
        {
            return string.Format("{0} evaluated you in [{1}] task", senderName, taskTitle);
        }
        public static string GetContentTypeComment(string senderName, string comment, string taskTitle)
        {
            return string.Format("{0} commented [{1}] in [{2}] task", senderName, comment, taskTitle);
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Tasks
    {
        MyProcess myProcess = new MyProcess();

        #region TASK ATTRIBUTES

        private string idTask;
        private string title;
        private string description;
        private string idCreator;
        private string idTeam;
        private bool isFavorite;
        private int progress;
        private DateTime created;

        #endregion

        #region TASK CONTRUCTOR

        public Tasks() 
        {
            this.idTask = string.Empty;
            this.title = string.Empty;
            this.description = string.Empty;
            this.idCreator = string.Empty;
            this.idTeam = string.Empty;
            this.isFavorite = false;
            this.progress = 0;
            this.created = DateTime.Now;
        }
        public Tasks(string title, string description, string idCreator, string idTeam, bool isFavorite, int progress, DateTime created)
        {
            this.idTask = myProcess.GenIDClassify(EClassify.Task);
            this.title = title;
            this.description = description;
            this.idCreator = idCreator;
            this.idTeam = idTeam;
            this.isFavorite = isFavorite;
            this.progress = progress;
            this.created = created;
        }
        public Tasks(string idTask, string title, string description, string idCreator, string idTeam, bool isFavorite, int progress, DateTime created)
        {
            this.idTask = idTask;
            this.title = title;
            this.description = description;
            this.idCreator = idCreator;
            this.idTeam = idTeam;
            this.isFavorite = isFavorite;
            this.progress = progress;
            this.created = created;
        }

        #endregion

        #region TASK PROPERTIES

        public string IdTask
        {
            get { return this.idTask; }
        }
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public string IdCreator
        {
            get { return this.idCreator; }
        }
        public string IdTeam
        {
            get { return this.idTeam; }
        }
        public bool IsFavorite
        {
            get { return this.isFavorite; }
            set { this.isFavorite = value; }
        }
        public int Progress
        {
            get { return this.progress; }
            set { this.progress = value; }
        }
        public DateTime CreatedDate
        {
            get { return this.created; }
        }

        #endregion

        #region CHECK INFORMATIONS

        public bool CheckTitle()
        {
            return this.title != string.Empty;
        }
        public bool CheckDescription()
        {
            return this.description != string.Empty;
        }
        public bool CheckProgress()
        {
            return this.progress >= 0 && this.progress <= 100;
        }

        #endregion

        #region FUNCTIONS

        public Tasks Clone()
        {
            return new Tasks(idTask, title, description, idCreator, idTeam, isFavorite, progress, created);
        }

        #endregion

    }
}

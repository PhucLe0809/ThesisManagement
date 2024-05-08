using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Meeting
    {
        private MyProcess myProcess = new MyProcess();

        #region MEETING ATTRIBUTES

        private string idMeeting;
        private string idThesis;
        private string title;
        private string description;
        private DateTime start;
        private DateTime theEnd;
        private string location;
        private string link;
        private string idCreator;
        private DateTime created;

        #endregion

        #region MEETING CONTRUCTOR

        public Meeting()
        {
            this.idMeeting = string.Empty;
            this.idThesis = string.Empty;
            this.title = string.Empty;
            this.description = string.Empty;
            this.start = DateTime.MinValue;
            this.theEnd = DateTime.MinValue;
            this.location = string.Empty;
            this.link = string.Empty;
            this.idCreator = string.Empty;
            this.created = DateTime.MinValue;
        }
        public Meeting(string idThesis, string title, string description, DateTime start, DateTime theEnd, string location, string link, string idCreator)
        {
            this.idMeeting = myProcess.GenIDClassify(EClassify.Meeting);
            this.idThesis = idThesis;
            this.title = title;
            this.description = description;
            this.start = start;
            this.theEnd = theEnd;
            this.location = location;
            this.link = link;
            this.idCreator = idCreator;
            this.created = DateTime.Now;
        }
        public Meeting(string idMeeting, string idThesis, string title, string description, DateTime start, DateTime theEnd, 
                        string location, string link, string idCreator, DateTime created)
        {
            this.idMeeting = idMeeting;
            this.idThesis = idThesis;
            this.title = title;
            this.description = description;
            this.start = start;
            this.theEnd = theEnd;
            this.location = location;
            this.link = link;
            this.idCreator = idCreator;
            this.created = created;
        }

        #endregion

        #region MEETING PROPERTIES

        public string IdMeeting 
        {
            get { return this.idMeeting; } 
        }
        public string IdThesis
        {
            get { return this.idThesis; }
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
        public DateTime Start
        { 
            get { return this.start; } 
            set { this.start = value; }
        }
        public DateTime TheEnd
        {
            get { return this.theEnd; }
            set { this.theEnd = value; }
        }
        public string Location
        { 
            get { return this.location; }
            set { this.location = value; }
        }
        public string Link
        { 
            get { return this.link; } 
            set { this.link = value; }
        }
        public string IdCreator
        {
            get { return this.idCreator; }
        }
        public DateTime Created
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
        public bool CheckStart()
        {
            return this.start >= DateTime.Now;
        }
        public bool CheckTheEnd()
        {
            return this.theEnd >= this.start;
        }
        public bool CheckLocation()
        {
            return this.location != string.Empty;
        }

        #endregion

    }
}

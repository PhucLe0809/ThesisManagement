using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject.Models
{
    public class GiveUp
    {
        private string idThesis;
        private string idRepresent;
        private string idTeam;
        private string reason;
        private DateTime created;

        public GiveUp()
        {
            this.idThesis = string.Empty;
            this.idRepresent = string.Empty;
            this.idTeam = string.Empty;
            this.reason = string.Empty;
            this.created = DateTime.Now;
        }
        public GiveUp(string idThesis, string idRepresent, string idTeam, string reason, DateTime created)
        {
            this.idThesis = idThesis;
            this.idRepresent = idRepresent;
            this.idTeam = idTeam;
            this.reason = reason;
            this.created = created;
        }

        public string IdThesis
        {
            get { return this.idThesis; }
        }
        public string IdRepresent
        {
            get { return this.idRepresent; }
        }
        public string IdTeam
        {
            get { return this.idTeam; }
        }
        public string Reason
        {
            get { return this.reason; }
            set { this.reason = value; }
        }
        public DateTime Created
        {
            get { return this.created; }
        }

        public bool CheckReason()
        {
            return this.reason != string.Empty;
        }
    }
}

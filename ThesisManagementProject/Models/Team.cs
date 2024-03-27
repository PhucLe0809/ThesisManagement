using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Team
    {
        private MyProcess myProcess = new MyProcess();

        #region ATTRIBUTES

        private string idteam;
        private string teamName;
        private string avatarName;
        private DateTime created;
        private List<People> members;

        #endregion

        #region CONTRUCTOR

        public Team()
        {
            this.idteam = "xxx";
            this.teamName = "Anonymous";
            this.avatarName = "PicAvatarDemoUser";
            this.created = DateTime.Now;
            this.members = new List<People>();
        }
        public Team(string teamName, string avatarName, DateTime created, List<People> members)
        {
            this.idteam = myProcess.GenIDClassify(EClassify.Team);
            this.teamName = teamName;
            this.avatarName = avatarName;
            this.created = created;
            this.members = members;
        }
        public Team(string idteam, string teamName, string avatarName, DateTime created, List<People> members)
        {
            this.idteam = idteam;
            this.teamName = teamName;
            this.avatarName = avatarName;
            this.created = created;
            this.members = members;
        }

        #endregion

        #region PROPERTIES

        public string IDTeam
        {
            get { return this.idteam; }
        }
        public string TeamName
        {
            get { return this.teamName; }
        }
        public string AvatarName
        {
            get { return this.avatarName; }
        }
        public DateTime Created
        {
            get { return this.created; }
        }
        public List<People> Members
        {
            get { return this.members; }
        }

        #endregion

    }
}

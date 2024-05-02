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

        #region TEAM ATTRIBUTES

        private string idteam;
        private string name;
        private string avatarName;
        private DateTime created;
        private List<People> members;

        #endregion

        #region TEAM CONTRUCTOR

        public Team()
        {
            this.idteam = string.Empty;
            this.name = "Anonymous";
            this.avatarName = "PicAvatarDemoUser";
            this.created = DateTime.Now;
            this.members = new List<People>();
        }
        public Team(List<People> members)
        {
            this.idteam = myProcess.GenIDClassify(EClassify.Team);
            this.name = "Anonymous";
            this.avatarName = "PicAvatarDemoUser";
            this.created = DateTime.Now;
            this.members = members;
        }
        public Team(string name, string avatarName, List<People> members)
        {
            this.idteam = myProcess.GenIDClassify(EClassify.Team);
            this.name = name;
            this.avatarName = avatarName;
            this.created = DateTime.Now;
            this.members = members;
        }
        public Team(string name, string avatarName, DateTime created, List<People> members)
        {
            this.idteam = myProcess.GenIDClassify(EClassify.Team);
            this.name = name;
            this.avatarName = avatarName;
            this.created = created;
            this.members = members;
        }
        public Team(string idteam, string name, string avatarName, DateTime created, List<People> members)
        {
            this.idteam = idteam;
            this.name = name;
            this.avatarName = avatarName;
            this.created = created;
            this.members = members;
        }

        #endregion

        #region TEAM PROPERTIES

        public string IdTeam
        {
            get { return this.idteam; }
            set { this.idteam = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string AvatarName
        {
            get { return this.avatarName; }
            set { this.avatarName = value; }
        }
        public DateTime Created
        {
            get { return this.created; }
            set { this.created = value; }
        }
        public List<People> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        #endregion

    }
}

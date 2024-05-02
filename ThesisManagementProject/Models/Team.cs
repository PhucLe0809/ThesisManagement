using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private string idTeam;
        private string name;
        private string avatarName;
        private DateTime created;
        private List<People> members;

        #endregion

        #region TEAM CONTRUCTOR

        public Team()
        {
            this.idTeam = string.Empty;
            this.name = "Anonymous";
            this.avatarName = "PicAvatarDemoUser";
            this.created = DateTime.Now;
            this.members = new List<People>();
        }
        public Team(List<People> members)
        {
            this.idTeam = myProcess.GenIDClassify(EClassify.Team);
            this.name = "Anonymous";
            this.avatarName = "PicAvatarDemoUser";
            this.created = DateTime.Now;
            this.members = members;
        }
        public Team(string name, string avatarName, List<People> members)
        {
            this.idTeam = myProcess.GenIDClassify(EClassify.Team);
            this.name = name;
            this.avatarName = avatarName;
            this.created = DateTime.Now;
            this.members = members;
        }
        public Team(string name, string avatarName, DateTime created, List<People> members)
        {
            this.idTeam = myProcess.GenIDClassify(EClassify.Team);
            this.name = name;
            this.avatarName = avatarName;
            this.created = created;
            this.members = members;
        }
        public Team(string idTeam, string name, string avatarName, DateTime created, List<People> members)
        {
            this.idTeam = idTeam;
            this.name = name;
            this.avatarName = avatarName;
            this.created = created;
            this.members = members;
        }

        #endregion

        #region TEAM PROPERTIES

        [Key]
        public string IdTeam
        {
            get { return this.idTeam; }
            set { this.idTeam = value; }
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

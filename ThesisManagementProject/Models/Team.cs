using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject.Models
{
    internal class Team
    {
        private string idteam;
        private string nameteam;
        private string avatarName;
        private DateTime created;

        public Team()
        {
            this.idteam = "xxx";
            this.nameteam = "Anonymous";
            this.avatarName = "PicAvatarDemoUser";
            this.created = DateTime.Now;
        }
        public Team(string idteam, string nameteam, string avatarName, DateTime created)
        {
            this.idteam = idteam;
            this.nameteam = nameteam;
            this.avatarName = avatarName;
            this.created = created;
        }
    }
}

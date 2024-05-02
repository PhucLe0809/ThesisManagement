using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Models
{
    public class Member
    {
        private string idTeam;
        private string idAccount;
        private string name;
        private DateTime created;
        private string avatarName;

        public Member()
        {
            this.idTeam = string.Empty;
            this.idAccount = string.Empty;
            this.name = "Anonymous";
            this.created = DateTime.Now;
            this.avatarName = "PicAvatarDemoUser";
        }
        public Member(string idTeam, string idAccount, string name, DateTime created, string avatarName)
        {
            this.idTeam = idTeam;
            this.idAccount = idAccount;
            this.name = name;
            this.created = created;
            this.avatarName = avatarName;
        }

        [Key]
        public string IdTeam
        {
            get { return this.idTeam; }
            set { this.idTeam = value; }
        }
        [Key]
        public string IdAccount
        {
            get { return this.idAccount; }
            set { this.idAccount = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public DateTime Created
        {
            get { return this.created; }
            set { this.created = value; }
        }
        public string AvatarName
        {
            get { return this.avatarName; }
            set { this.avatarName = value; }
        }
    }
}

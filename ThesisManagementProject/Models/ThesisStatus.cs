using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Process;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThesisManagementProject.Models
{

    public class ThesisStatus
    {
        private MyProcess myProcess = new MyProcess();

        private string idTeam;
        private string idThesis;
        private string status;
        private EThesisStatus tsstatus;

        public ThesisStatus()
        {
            this.idTeam = string.Empty;
            this.idThesis = string.Empty;
            this.status = string.Empty;
            this.tsstatus = EThesisStatus.Published;
        }
        public ThesisStatus(string idTeam, string idThesis, EThesisStatus status)
        {
            this.idTeam = idTeam;
            this.idThesis = idThesis;
            this.tsstatus = status;
            this.status = tsstatus.ToString();
        }

        [Key]
        public string IdTeam
        {
            get { return idTeam; }
            set { idTeam = value; }
        }
        [Key]
        public string IdThesis
        {
            get { return idThesis; }
            set { idThesis = value; }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                tsstatus = myProcess.GetEnumFromDisplayName<EThesisStatus>(status);
            }
        }
        [NotMapped]
        public EThesisStatus OnStatus
        {
            get { return tsstatus; }
            set
            {
                tsstatus = value;
                status = tsstatus.ToString();
            }
        }

    }
}

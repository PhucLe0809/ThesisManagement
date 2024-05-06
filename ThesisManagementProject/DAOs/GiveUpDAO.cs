using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.DAOs
{
    internal class GiveUpDAO : DBConnection
    {
        public GiveUpDAO() { }

        public GiveUp SelectFollowThesis(string idThesis)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idthesis = '{1}'", MyDatabase.DBGiveUp, idThesis));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new GiveUp();

        }
        public void Insert(GiveUp giveUp)
        {
            ExecuteQueryGiveUp(giveUp, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}')",
                "Create", false);
        }
        private GiveUp GetFromDataRow(DataRow row)
        {
            string idThesis = row["idthesis"].ToString();
            string idRepresent = row["idrepresent"].ToString();
            string idTeam = row["idteam"].ToString();
            string reason = row["reason"].ToString();
            DateTime created = DateTime.Parse(row["created"].ToString());

            GiveUp giveUp = new GiveUp(idThesis, idRepresent, idTeam, reason, created);
            return giveUp;
        }
    }
}

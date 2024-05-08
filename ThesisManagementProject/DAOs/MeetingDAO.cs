using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Database;
using ThesisManagementProject.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ThesisManagementProject.DAOs
{
    internal class MeetingDAO : DBConnection
    {
        public MeetingDAO() { }

        #region SELECT MEETING

        private List<Meeting> SelectList(string command)
        {
            DataTable dataTable = Select(command);

            List<Meeting> list = new List<Meeting>();
            foreach (DataRow row in dataTable.Rows)
            {
                Meeting meeting = GetFromDataRow(row);
                list.Add(meeting);
            }

            return list;
        }
        public Meeting SelectOnly(string idMeeting)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idmeeting = '{1}'",
                                            MyDatabase.DBMeeting, idMeeting);
            DataTable dt = Select(command);

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new Meeting();
        }
        public List<Meeting> SelectByThesis(string idThesis)
        {
            string command = string.Format("SELECT * FROM {0} WHERE idthesis = '{1}' ORDER BY start",
                                            MyDatabase.DBMeeting, idThesis);
            return SelectList(command);
        }

        #endregion

        #region MEETING DAO EXCUTION

        public void Insert(Meeting meeting)
        {
            ExecuteQueryMeeting(meeting, "INSERT INTO {0} VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                "Create", true);
        }
        public void Delete(Meeting meeting)
        {
            ExecuteQueryMeeting(meeting, "DELETE FROM {0} WHERE idmeeting = '{1}'",
                "Delete", false);
        }
        public void Update(Meeting meeting)
        {
            ExecuteQueryMeeting(meeting, "UPDATE {0} SET " +
                "idthesis = '{2}', title = '{3}', description = '{4}', start = '{5}', theend = '{6}', location = '{7}', " +
                "link = '{8}', idcreator = '{9}', created = '{10}' WHERE idmeeting = '{1}'",
                "Update", false);
        }

        #endregion

        #region Get Meeting From Data Row

        private Meeting GetFromDataRow(DataRow row)
        {
            string idMeeting = row["idmeeting"].ToString();
            string idThesis = row["idthesis"].ToString();
            string title = row["title"].ToString();
            string description = row["description"].ToString();
            DateTime start = DateTime.Parse(row["start"].ToString());
            DateTime theEnd = DateTime.Parse(row["theend"].ToString());
            string location = row["location"].ToString();
            string link = row["link"].ToString();
            string creator = row["idcreator"].ToString();
            DateTime created = DateTime.Parse(row["created"].ToString());

            Meeting meeting = new Meeting(idMeeting, idThesis, title, description, start, theEnd, location, link, creator, created);
            return meeting;
        }

        #endregion

    }
}

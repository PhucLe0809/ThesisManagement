﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Models;
using ThesisManagementProject.Process;

namespace ThesisManagementProject.Database
{
    internal class PeopleDAO : DBConnection
    {
        private MyProcess myProcess = new MyProcess();

        public PeopleDAO() { }

        #region SELECT PEOPLE

        public List<People> SelectListByUserName(string username, ERole role)
        {
            string command = string.Format("SELECT * FROM {0} WHERE handle LIKE '{1}%' and role = '{2}'",
                                MyDatabase.DBAccount, username, role);

            DataTable dataTable = Select(command);

            List<People> list = new List<People>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(GetFromDataRow(row));
            }

            return list;
        }
        public People SelectOnlyByID(string id)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE idaccount = '{1}'", MyDatabase.DBAccount, id));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new People();
        }
        public People SelectOnlyByEmailAndPassword(string email, string password)
        {
            DataTable dt = Select(string.Format("SELECT * FROM {0} WHERE email = '{1}' and password = '{2}'",
                                        MyDatabase.DBAccount, email, password));

            if (dt.Rows.Count > 0) return GetFromDataRow(dt.Rows[0]);
            return new People();
        }

        #endregion

        #region SELECT LIST ID PEOPLE

        public List<string> SelectListID(ERole role)
        {
            string command = string.Format("SELECT idaccount FROM {0} WHERE role = '{1}'", MyDatabase.DBAccount, role.ToString());
            DataTable table = Select(command);
            List<string> list = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(row["idaccount"].ToString());
            }
            return list;
        }

        #endregion

        #region Get From Data Row

        public People GetFromDataRow(DataRow row)
        {
            string idaccount = row["idaccount"].ToString();
            string fullname = row["fullname"].ToString();
            string citizenCode = row["citizencode"].ToString();
            DateTime birthday = DateTime.Parse(row["birthday"].ToString());
            EGender gender = myProcess.GetEnumFromDisplayName<EGender>(row["gender"].ToString());
            string email = row["email"].ToString();
            string phoneNumber = row["phonenumber"].ToString();
            string handle = row["handle"].ToString();
            ERole role = myProcess.GetEnumFromDisplayName<ERole>(row["role"].ToString());
            string workCode = row["workcode"].ToString();
            string password = row["password"].ToString();
            string avatarName = row["avatarname"].ToString();

            People people = new People(idaccount, fullname, citizenCode, birthday, gender,
                                        email, phoneNumber, handle, role, workCode, password, avatarName);

            return people;
        }

        #endregion

    }
}

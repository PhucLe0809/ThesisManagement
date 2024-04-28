using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject.DAOs
{
    internal class LectureDAO : PeopleDAO
    {
        ThesisDAO thesisDAO = new ThesisDAO();
        public LectureDAO() : base() { }
        
    }
}

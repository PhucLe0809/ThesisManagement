using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.DAOs
{
    internal class TechnologyDAO
    {
        public TechnologyDAO() { }

        public List<Technology> SelectFollowField(string field)
        {
            using (var dbContext = new AppDbContext())
            {
                var listTech = dbContext.Technology.Where(t => t.Field == field).ToList();

                if (listTech != null) return listTech;
                else return new List<Technology>();
            }
        }
    }
}

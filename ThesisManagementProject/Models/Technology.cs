using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementProject.Models
{
    public class Technology
    {
        private string field;
        private string tech;

        public Technology()
        {
            this.field = string.Empty;
            this.tech = string.Empty;
        }
        public Technology(string field, string tech)
        {
            this.field = field;
            this.tech = tech;
        }

        [Key]
        public string Field 
        { 
            get { return field; } 
            set { field = value; } 
        }
        [Key]
        public string Tech 
        { 
            get {  return tech; } 
            set {  tech = value; } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entities
{
    public class UserRole
    {
        public Guid UserID { get; set; }
        public Guid CompanyID { get; set; }
        public string RoleName { get; set; } 
        public string JobTitle { get; set; } 

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }

}

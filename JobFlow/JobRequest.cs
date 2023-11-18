
using CRM.Entities;

namespace JobFlow
{
    public class JobRequest
    {
        public Guid JobRequestId { get; set; }
        public string Title { get; set; }
        public Guid CompanyID { get; set; }
        public string Status { get; set; }
        // Other properties like Priority, Deadline, etc.

        // Navigation properties
        public virtual Company Company { get; set; }
        // Additional navigation properties if necessary

        // Constructor, if needed
    }

}

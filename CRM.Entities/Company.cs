namespace CRM.Entities
{
    public class Company
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }

        // Owner of the company
        public Guid OwnerID { get; set; }
        public virtual User Owner { get; set; }

        // List of roles
        public enum Role
        {
            Manager,
            Sales,
            Admin,
            Technician
            // ... other roles ...
        }
        // Navigation property for UserRoles
        public virtual ICollection<UserRole> UserRoles { get; set; }



        // Initialize the Roles list
        public List<Role> Roles { get; set; }

        public Company()
        {
            Roles = new List<Role>();
            UserRoles = new HashSet<UserRole>();
        }

        // Add more properties 
    }
}
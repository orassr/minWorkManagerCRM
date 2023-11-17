namespace CRM.Entities
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public string? TenantName { get; set; }

        // Navigation property
        public virtual ICollection<User> Users { get; set; }

        public Tenant()
        {
            Users = new HashSet<User>();
        }
    }
}
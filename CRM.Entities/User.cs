namespace CRM.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public string? Username { get; set; }
        // ... Other properties like Email, Password

        // Foreign key for Tenant
        public Guid TenantID { get; set; }

        // Navigation property
        public virtual Tenant Tenant { get; set; }

        public User()
        {
            // UserBusinesses collection removed
        }
    }
}
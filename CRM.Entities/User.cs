namespace CRM.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        // ... Other properties like Email, Password

        // Foreign key for Tenant
        public int TenantID { get; set; }

        // Navigation property
        public virtual Tenant Tenant { get; set; }

        public User()
        {
            // UserBusinesses collection removed
        }
    }
}
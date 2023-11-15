namespace CRM.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Ensure this is hashed

        // Foreign key for Tenant
        public int TenantID { get; set; }

        // Navigation properties
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<UserBusiness> UserBusinesses { get; set; }

        public User()
        {
            UserBusinesses = new HashSet<UserBusiness>();
        }
    }
}
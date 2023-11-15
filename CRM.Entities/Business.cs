namespace CRM.Entities
{
    public class Business
    {
        public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }

        // Foreign key for Tenant
        public int TenantID { get; set; }

        // Navigation properties
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<UserBusiness> UserBusinesses { get; set; }

        public Business()
        {
            UserBusinesses = new HashSet<UserBusiness>();
        }
    }
}
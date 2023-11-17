namespace CRM.Entities
{
    public class Business
    {
        public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        // ... Other properties like BusinessType

        public int TenantID { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<UserBusiness> UserBusinesses { get; set; }

        public Business()
        {
            UserBusinesses = new HashSet<UserBusiness>();
        }
    }
}
namespace CRM.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int TenantID { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<UserBusiness> UserBusinesses { get; set; }

        public User()
        {
            UserBusinesses = new HashSet<UserBusiness>();
        }
    }
}
namespace CRM.Entities
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public string TenantName { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }

        public Tenant()
        {
            Users = new HashSet<User>();
            Businesses = new HashSet<Business>();
        }
    }
}
namespace CRM.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Navigation properties
        //public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Company> OwnedCompanies { get; set; }

        public User()
        {
            //UserRoles = new HashSet<UserRole>();
            OwnedCompanies = new HashSet<Company>();
        }
    }

}
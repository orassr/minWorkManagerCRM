namespace CRM.Entities
{
    public class UserBusiness
    {
        public int UserBusinessID { get; set; }
        public int UserID { get; set; }
        public int BusinessID { get; set; }
        public string Role { get; set; } // e.g., owner, manager

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Business Business { get; set; }
    }
}
namespace CRM.Entities
{
    public class User
    {
        // Primary Key
        public int UserID { get; set; }

        // User information
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
namespace CRM.Entities
{
    public class Business
    {
        // Primary Key
        public int BusinessID { get; set; }

        // Business information
        public string? BusinessName { get; set; }
        public string? BusinessType { get; set; }
    }
}
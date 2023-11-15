namespace CRM.Entities
{
    public class Tenant
    {
        // Primary Key
        public int TenantID { get; set; }

        // Tenant information
        public string? TenantName { get; set; }
        public string? DatabaseConnectionString { get; set; }
    }
}
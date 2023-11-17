using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRM.Data
{
    public class CRMDbContextFactory : IDesignTimeDbContextFactory<EntitiesDbContext>
    {
        public CRMDbContextFactory()
        {
        }

        public EntitiesDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EntitiesDbContext>();
            var connectionString = configuration.GetConnectionString("minCRM");

            builder.UseSqlServer(connectionString);

            return new EntitiesDbContext(builder.Options);
        }
    }
}
using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

// Namespace should match your project's structure
namespace CRM.Data
{
    // The YourDbContext class inherits from DbContext and represents the session with the database.
    public class EntitiesDbContext : DbContext
    {

        private readonly string connectionString;

        // The constructor accepts DbContextOptions and passes it to the base DbContext constructor.
        // This allows for configuration options (like connection strings) to be injected from outside.
        public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options) 
            : base(options)
        {
        }


        public EntitiesDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // DbSets represent the tables in the database. Each DbSet corresponds to an entity.
        public DbSet<User> Users { get; set; }
        //public DbSet<Business> Businesses { get; set; }
        //public DbSet<UserBusiness> UserBusinesses { get; set; }
        public DbSet<Tenant> Tenants { get; set; }




        // OnModelCreating is overridden to apply configurations set up in separate classes.
        // This approach keeps the method clean and the configurations modular and organized.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tenant>().ToTable("Tenants");
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant
                {
                    TenantID = 1,
                    TenantName = "Tenant 1"
                },
                new Tenant
                {
                    TenantID = 2,
                    TenantName = "Tenant 2"
                },
                new Tenant
                {
                    TenantID = 3,
                    TenantName = "Tenant 3"
                },
                new Tenant
                {
                    TenantID = 4,
                    TenantName = "Tenant 4"
                },  
                new Tenant
                {
                    TenantID = 5,
                    TenantName = "Tenant 5"
                },
                new Tenant
                {
                    TenantID = 6, 
                    TenantName = "Tenant 6"
                }
                
                
            );

            // Apply all configurations from the current assembly.
            // This way, you don't need to manually add each configuration class.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Alternatively, if you want to apply each configuration manually, uncomment the following lines:
             modelBuilder.ApplyConfiguration(new TenantConfiguration());
             modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            //modelBuilder.ApplyConfiguration(new UserBusinessConfiguration());


            // ... other model configurations
        }

        // If you need to override SaveChanges for features like auditing, you can do so here.
        // public override int SaveChanges()
        // {
        //     // Your custom logic here
        //     return base.SaveChanges();
        // }

        // Other custom logic and methods, such as bulk operations or complex queries, can be added here.
    }
}
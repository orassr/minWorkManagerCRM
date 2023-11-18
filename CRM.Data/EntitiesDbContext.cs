using CRM.Entities;
using CRM.EntitiesConfigurations;
using JobFlow;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
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
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<JobRequest> JobRequests { get; set; }



        // OnModelCreating is overridden to apply configurations set up in separate classes.
        // This approach keeps the method clean and the configurations modular and organized.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var dummyUsers = new List<User>
            {
                new User
                {
                    UserID = Guid.NewGuid(),
                    Username = "user1",
                    Email = "user1@example.com",
                    Address = "123 First Avenue"
                },
                new User
                {
                    UserID = Guid.NewGuid(),
                    Username = "user2",
                    Email = "user2@example.com",
                    Address = "456 Second Street"
                },
                // ... additional dummy users ...
            };

            modelBuilder.Entity<User>().HasData(dummyUsers);

            // Seeding Companies
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyID = Guid.NewGuid(),
                    CompanyName = "Dummy Company 1",
                    OwnerID = dummyUsers[0].UserID,
                    Roles = new List<Company.Role> { Company.Role.Manager, Company.Role.Technician }
                },
                new Company
                {
                    CompanyID = Guid.NewGuid(),
                    CompanyName = "Dummy Company 2",
                    OwnerID = dummyUsers[1].UserID,
                    Roles = new List<Company.Role> { Company.Role.Sales, Company.Role.Admin }
                }
            );

            // Apply all configurations from the current assembly.
            // This way, you don't need to manually add each configuration class.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Alternatively, if you want to apply each configuration manually, uncomment the following lines:
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());


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
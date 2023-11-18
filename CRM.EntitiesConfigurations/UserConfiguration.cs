using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserID);

        // Configure the one-to-many relationship with OwnedCompanies
        builder.HasMany(u => u.OwnedCompanies)
               .WithOne(c => c.Owner)
               .HasForeignKey(c => c.OwnerID);

        // Configure the one-to-many relationship with UserRoles
        //builder.HasMany(u => u.UserRoles)
        //       .WithOne(ur => ur.User)
        //       .HasForeignKey(ur => ur.UserID);
    }
}
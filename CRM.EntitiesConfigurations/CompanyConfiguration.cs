using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CRM.Entities.Company;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.CompanyID);

        // Configure the one-to-one relationship with User as owner
        builder.HasOne(c => c.Owner)
               .WithMany(u => u.OwnedCompanies)
               .HasForeignKey(c => c.OwnerID)
               .OnDelete(DeleteBehavior.Restrict);

        // Configure the one-to-many relationship with UserRoles
        builder.HasMany(c => c.UserRoles)
               .WithOne(ur => ur.Company)
               .HasForeignKey(ur => ur.CompanyID);

        // Configure the Roles property to store enums as strings
        builder.Property(c => c.Roles)
               .HasConversion(
                   v => string.Join(",", v.Select(e => e.ToString())),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                         .Select(e => Enum.Parse<Company.Role>(e))
                         .ToList()
               )
               .Metadata.SetValueComparer(new ValueComparer<List<Company.Role>>(
                   (c1, c2) => c1.SequenceEqual(c2),
                   c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                   c => c.ToList()));
    }
}

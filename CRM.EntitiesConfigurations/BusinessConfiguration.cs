using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasKey(b => b.BusinessID);

        builder.HasOne(b => b.Tenant)
               .WithMany(t => t.Businesses)
               .HasForeignKey(b => b.TenantID);

        builder.HasMany(b => b.UserBusinesses)
               .WithOne(ub => ub.Business)
               .HasForeignKey(ub => ub.BusinessID)
               .OnDelete(DeleteBehavior.NoAction);

    }
}

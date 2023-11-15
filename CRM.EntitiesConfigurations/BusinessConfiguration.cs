using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasKey(b => b.BusinessID);

        builder.HasMany(b => b.UserBusinesses)
            .WithOne(ub => ub.Business)
            .HasForeignKey(ub => ub.BusinessID);
    }
}

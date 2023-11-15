using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserID);

        builder.HasMany(u => u.UserBusinesses)
            .WithOne(ub => ub.User)
            .HasForeignKey(ub => ub.UserID);
    }
}

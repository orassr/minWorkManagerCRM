using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class UserBusinessConfiguration : IEntityTypeConfiguration<UserBusiness>
{
    public void Configure(EntityTypeBuilder<UserBusiness> builder)
    {
        builder.HasKey(ub => ub.UserBusinessID);

        builder.HasOne(ub => ub.User)
               .WithMany(u => u.UserBusinesses)
               .HasForeignKey(ub => ub.UserID);

        builder.HasOne(ub => ub.Business)
               .WithMany(b => b.UserBusinesses)
               .HasForeignKey(ub => ub.BusinessID);

    }
}
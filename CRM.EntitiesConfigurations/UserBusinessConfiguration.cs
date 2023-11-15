using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserBusinessConfiguration : IEntityTypeConfiguration<UserBusiness>
{
    public void Configure(EntityTypeBuilder<UserBusiness> builder)
    {
        builder.HasKey(ub => ub.UserBusinessID);
    }
}

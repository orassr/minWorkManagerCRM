﻿using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(t => t.TenantID);

        builder.HasMany(t => t.Users)
               .WithOne(u => u.Tenant)
               .HasForeignKey(u => u.TenantID)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
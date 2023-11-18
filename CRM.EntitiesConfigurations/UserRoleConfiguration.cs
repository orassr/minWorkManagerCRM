using CRM.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntitiesConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => new { ur.UserID, ur.CompanyID, ur.RoleName });

            // Configure the many-to-one relationship with User
            //builder.HasOne(ur => ur.User)
            //       .WithMany(u => u.UserRoles)
            //       .HasForeignKey(ur => ur.UserID);

            // Configure the many-to-one relationship with Company
            builder.HasOne(ur => ur.Company)
                   .WithMany(c => c.UserRoles)
                   .HasForeignKey(ur => ur.CompanyID);
        }
    }
}
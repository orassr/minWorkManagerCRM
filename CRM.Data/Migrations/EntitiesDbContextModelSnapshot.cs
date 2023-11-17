﻿// <auto-generated />
using CRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM.Data.Migrations
{
    [DbContext(typeof(EntitiesDbContext))]
    partial class EntitiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRM.Entities.Tenant", b =>
                {
                    b.Property<int>("TenantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantID"));

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantID");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            TenantID = 1,
                            TenantName = "Tenant 1"
                        },
                        new
                        {
                            TenantID = 2,
                            TenantName = "Tenant 2"
                        },
                        new
                        {
                            TenantID = 3,
                            TenantName = "Tenant 3"
                        },
                        new
                        {
                            TenantID = 4,
                            TenantName = "Tenant 4"
                        },
                        new
                        {
                            TenantID = 5,
                            TenantName = "Tenant 5"
                        },
                        new
                        {
                            TenantID = 6,
                            TenantName = "Tenant 6"
                        });
                });

            modelBuilder.Entity("CRM.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("TenantID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CRM.Entities.User", b =>
                {
                    b.HasOne("CRM.Entities.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("CRM.Entities.Tenant", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

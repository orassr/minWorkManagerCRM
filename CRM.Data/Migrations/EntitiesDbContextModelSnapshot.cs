﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("CRM.Entities.Company", b =>
                {
                    b.Property<Guid>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyID = new Guid("d8dc6302-4eac-40d9-bc29-9387d055686f"),
                            CompanyName = "Dummy Company 1",
                            OwnerID = new Guid("86a0836e-7a8e-4a9e-b892-1da19ee2004f"),
                            Roles = "Manager,Technician"
                        },
                        new
                        {
                            CompanyID = new Guid("0e1e5972-691c-473b-9dd6-43295425a421"),
                            CompanyName = "Dummy Company 2",
                            OwnerID = new Guid("d1cff27c-e633-498b-8858-5327fecd0b16"),
                            Roles = "Sales,Admin"
                        });
                });

            modelBuilder.Entity("CRM.Entities.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = new Guid("86a0836e-7a8e-4a9e-b892-1da19ee2004f"),
                            Address = "123 First Avenue",
                            Email = "user1@example.com",
                            Username = "user1"
                        },
                        new
                        {
                            UserID = new Guid("d1cff27c-e633-498b-8858-5327fecd0b16"),
                            Address = "456 Second Street",
                            Email = "user2@example.com",
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("CRM.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID", "CompanyID", "RoleName");

                    b.HasIndex("CompanyID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("JobFlow.JobRequest", b =>
                {
                    b.Property<Guid>("JobRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobRequestId");

                    b.HasIndex("CompanyID");

                    b.ToTable("JobRequests");
                });

            modelBuilder.Entity("CRM.Entities.Company", b =>
                {
                    b.HasOne("CRM.Entities.User", "Owner")
                        .WithMany("OwnedCompanies")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CRM.Entities.UserRole", b =>
                {
                    b.HasOne("CRM.Entities.Company", "Company")
                        .WithMany("UserRoles")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobFlow.JobRequest", b =>
                {
                    b.HasOne("CRM.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CRM.Entities.Company", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CRM.Entities.User", b =>
                {
                    b.Navigation("OwnedCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}

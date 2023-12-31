﻿// <auto-generated />
using System;
using CRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM.Data.Migrations
{
    [DbContext(typeof(EntitiesDbContext))]
    [Migration("20231117215849_createor")]
    partial class createor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CompanyID = new Guid("2055f247-df2a-449a-a432-97b28ca089db"),
                            CompanyName = "Dummy Company 1",
                            OwnerID = new Guid("b7e76eb3-7d03-4fa8-b6e2-00d7c7356ef7"),
                            Roles = "Manager,Technician"
                        },
                        new
                        {
                            CompanyID = new Guid("20491f2a-ec77-4a33-820e-cd08e8a48a37"),
                            CompanyName = "Dummy Company 2",
                            OwnerID = new Guid("75d8ce69-a8cc-42bf-8651-fe848def2ab2"),
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
                            UserID = new Guid("b7e76eb3-7d03-4fa8-b6e2-00d7c7356ef7"),
                            Address = "123 First Avenue",
                            Email = "user1@example.com",
                            Username = "user1"
                        },
                        new
                        {
                            UserID = new Guid("75d8ce69-a8cc-42bf-8651-fe848def2ab2"),
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

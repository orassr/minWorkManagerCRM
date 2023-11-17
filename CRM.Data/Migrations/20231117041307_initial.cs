using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantID", "TenantName" },
                values: new object[,]
                {
                    { new Guid("298ba02c-723c-4cbb-a6bb-7a433ad8fa28"), "Tenant 6" },
                    { new Guid("607debc9-1d16-47fe-badf-1bf98b1c40c6"), "Tenant 5" },
                    { new Guid("6e5e254e-692b-47ea-b1ad-1f589a14eebc"), "Tenant 3" },
                    { new Guid("9b3f7c3f-43a6-46c9-8c69-d59effc0652f"), "Tenant 1" },
                    { new Guid("ab0d651f-eeb6-4d8b-b1f5-db5bbe4cfd42"), "Tenant 4" },
                    { new Guid("b63674c5-4cb5-40c4-a41f-90450d96b010"), "Tenant 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantID",
                table: "Users",
                column: "TenantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

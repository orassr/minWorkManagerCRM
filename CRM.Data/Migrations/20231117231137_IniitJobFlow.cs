using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Data.Migrations
{
    /// <inheritdoc />
    public partial class IniitJobFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyID",
                keyValue: new Guid("20491f2a-ec77-4a33-820e-cd08e8a48a37"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyID",
                keyValue: new Guid("2055f247-df2a-449a-a432-97b28ca089db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("75d8ce69-a8cc-42bf-8651-fe848def2ab2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("b7e76eb3-7d03-4fa8-b6e2-00d7c7356ef7"));

            migrationBuilder.CreateTable(
                name: "JobRequests",
                columns: table => new
                {
                    JobRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequests", x => x.JobRequestId);
                    table.ForeignKey(
                        name: "FK_JobRequests_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "Email", "Username" },
                values: new object[,]
                {
                    { new Guid("86a0836e-7a8e-4a9e-b892-1da19ee2004f"), "123 First Avenue", "user1@example.com", "user1" },
                    { new Guid("d1cff27c-e633-498b-8858-5327fecd0b16"), "456 Second Street", "user2@example.com", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "CompanyName", "OwnerID", "Roles" },
                values: new object[,]
                {
                    { new Guid("0e1e5972-691c-473b-9dd6-43295425a421"), "Dummy Company 2", new Guid("d1cff27c-e633-498b-8858-5327fecd0b16"), "Sales,Admin" },
                    { new Guid("d8dc6302-4eac-40d9-bc29-9387d055686f"), "Dummy Company 1", new Guid("86a0836e-7a8e-4a9e-b892-1da19ee2004f"), "Manager,Technician" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobRequests_CompanyID",
                table: "JobRequests",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobRequests");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyID",
                keyValue: new Guid("0e1e5972-691c-473b-9dd6-43295425a421"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyID",
                keyValue: new Guid("d8dc6302-4eac-40d9-bc29-9387d055686f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("86a0836e-7a8e-4a9e-b892-1da19ee2004f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("d1cff27c-e633-498b-8858-5327fecd0b16"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "Email", "Username" },
                values: new object[,]
                {
                    { new Guid("75d8ce69-a8cc-42bf-8651-fe848def2ab2"), "456 Second Street", "user2@example.com", "user2" },
                    { new Guid("b7e76eb3-7d03-4fa8-b6e2-00d7c7356ef7"), "123 First Avenue", "user1@example.com", "user1" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "CompanyName", "OwnerID", "Roles" },
                values: new object[,]
                {
                    { new Guid("20491f2a-ec77-4a33-820e-cd08e8a48a37"), "Dummy Company 2", new Guid("75d8ce69-a8cc-42bf-8651-fe848def2ab2"), "Sales,Admin" },
                    { new Guid("2055f247-df2a-449a-a432-97b28ca089db"), "Dummy Company 1", new Guid("b7e76eb3-7d03-4fa8-b6e2-00d7c7356ef7"), "Manager,Technician" }
                });
        }
    }
}

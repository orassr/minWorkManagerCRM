using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adjust1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Tenants_TenantID",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinesses_Businesses_BusinessID",
                table: "UserBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinesses_Users_UserID",
                table: "UserBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantID",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Tenants_TenantID",
                table: "Businesses",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinesses_Businesses_BusinessID",
                table: "UserBusinesses",
                column: "BusinessID",
                principalTable: "Businesses",
                principalColumn: "BusinessID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinesses_Users_UserID",
                table: "UserBusinesses",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantID",
                table: "Users",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Tenants_TenantID",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinesses_Businesses_BusinessID",
                table: "UserBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinesses_Users_UserID",
                table: "UserBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantID",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Tenants_TenantID",
                table: "Businesses",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinesses_Businesses_BusinessID",
                table: "UserBusinesses",
                column: "BusinessID",
                principalTable: "Businesses",
                principalColumn: "BusinessID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinesses_Users_UserID",
                table: "UserBusinesses",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantID",
                table: "Users",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

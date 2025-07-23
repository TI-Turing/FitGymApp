using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailVerifiedAndSeedVerificationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailVerified",
                table: "User");

            migrationBuilder.InsertData(
                table: "VerificationType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Ip", "IsActive", "Nombre", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b1a1e1c1-1111-4e1a-8e1a-111111111111"), new DateTime(2025, 7, 23, 12, 43, 2, 219, DateTimeKind.Utc).AddTicks(8185), null, null, true, "Email", null },
                    { new Guid("b2b2e2c2-2222-4e2a-8e2a-222222222222"), new DateTime(2025, 7, 23, 12, 43, 2, 219, DateTimeKind.Utc).AddTicks(8376), null, null, true, "Phone", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b1a1e1c1-1111-4e1a-8e1a-111111111111"));

            migrationBuilder.DeleteData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b2b2e2c2-2222-4e2a-8e2a-222222222222"));

            migrationBuilder.AddColumn<bool>(
                name: "EmailVerified",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
